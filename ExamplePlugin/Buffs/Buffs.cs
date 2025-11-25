using R2API;
using RoR2;
using SivsContentPack.Config;
using System;
using System.Collections.Generic;
using System.Text;
using HG;
using UnityEngine;
using SivsContentPack;
using SivsContentPack.Items;
using UnityEngine.Networking;
using System.Runtime.InteropServices;
using RoR2.Projectile;
using RoR2.Orbs;
using HarmonyLib;
using MonoMod.Cil;

namespace SivsContentPack
{
    
    public class AffixBlack : BuffFactory
    {
        public static GameObject cloakActiveEffect;
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Elites.LoadAsset<BuffDef>("bdEliteShadow");
            cloakActiveEffect = Assets.AssetBundles.Elites.LoadAsset<GameObject>("ShadowCloakEffect");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Elites.Obscuring.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Elites.LoadAsset<Material>("matShadowCloak");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
            m = Assets.AssetBundles.Elites.LoadAsset<Material>("matShadowTracer");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matDistortion");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Distortion");
        }
        protected override void Hooks()
        {
            On.RoR2.GlobalEventManager.OnHitEnemy += GlobalEventManager_OnHitEnemy;
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
        }

        private void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            if(self != null)
            {
                self.AddItemBehavior<AffixBlackController>(self.HasBuff(Content.Buffs.AffixShadow) ? 1 : 0);
            }
            orig.Invoke(self);
        }

        private class AffixBlackController : CharacterBody.ItemBehavior
        {
            private void FixedUpdate()
            {
                if(stack <= 0)
                {
                    return;
                }
                if (NetworkServer.active && this.body)
                {
                    if(!this.body.HasBuff(RoR2Content.Buffs.Cloak) && (this.body.outOfCombat && this.body.outOfDanger)){
                        RoR2.Util.PlaySound("Play_elite_haunt_ghost_convert", this.body.gameObject);
                        GameObject.Instantiate(cloakActiveEffect, body.transform.position, body.transform.rotation);
                        this.body.AddBuff(RoR2Content.Buffs.Cloak);
                        return;
                    }
                    if(this.body.HasBuff(RoR2Content.Buffs.Cloak) && !(this.body.outOfCombat && this.body.outOfDanger))
                    {
                        EffectData ed = new EffectData
                        {
                            origin = this.body.transform.position,
                            rotation = this.body.transform.rotation,
                            start = this.body.transform.position
                        };
                        EffectManager.SpawnEffect(Content.Effects.ShadowCloakBreak.prefab, ed, true);
                        this.body.RemoveBuff(RoR2Content.Buffs.Cloak);
                        return;
                    }
                }
            }
            private void OnDisable()
            {
                if (this.body.HasBuff(RoR2Content.Buffs.Cloak))
                {
                    EffectData ed = new EffectData
                    {
                        origin = this.body.transform.position,
                        rotation = this.body.transform.rotation,
                        start = this.body.transform.position,
                    };
                    EffectManager.SpawnEffect(Content.Effects.ShadowCloakBreak.prefab, ed, true);
                    this.body.RemoveBuff(RoR2Content.Buffs.Cloak);
                }
            }
        }

        private void GlobalEventManager_OnHitEnemy(On.RoR2.GlobalEventManager.orig_OnHitEnemy orig, GlobalEventManager self, DamageInfo damageInfo, GameObject victim)
        {
            orig.Invoke(self, damageInfo, victim);
            GameObject attacker = damageInfo.attacker;
            if (attacker != null)
            {
                CharacterBody cb = attacker.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    if (cb.HasBuff(Content.Buffs.AffixShadow))
                    {
                        CharacterBody vb = victim.GetComponent<CharacterBody>();
                        if(vb != null)
                        {
                            vb.AddTimedBuff(DLC1Content.Buffs.Blinded, Configuration.Elites.Obscuring.blindnessDuration * damageInfo.procCoefficient);
                        }
                    }
                }
            }
        }
    }
    public class AffixUnstable : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Elites.LoadAsset<BuffDef>("bdEliteUnstable");
            Content.Misc.EliteUnstableFireball = Assets.AssetBundles.Elites.LoadAsset<GameObject>("EliteUnstableFireball");
            ContentAddition.AddProjectile(Content.Misc.EliteUnstableFireball);
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Elites.Unstable.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Elites.LoadAsset<Material>("matUnstableFireball");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Elites.LoadAsset<Material>("matUnstableLightshaft");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");

        }
        protected override void Hooks()
        {
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
            On.RoR2.CharacterBody.OnClientBuffsChanged += CharacterBody_OnClientBuffsChanged;
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender.HasBuff(Content.Buffs.AffixUnstable))
            {
                args.damageMultAdd += Configuration.Elites.Unstable.damageMult;
                args.baseCurseAdd += Configuration.Elites.Unstable.healthMult;
            }
        }

        private void CharacterBody_OnClientBuffsChanged(On.RoR2.CharacterBody.orig_OnClientBuffsChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            self.AddItemBehavior<AffixUnstableController>(self.HasBuff(Content.Buffs.AffixUnstable) ? 1 : 0);
        }

        private class AffixUnstableController : CharacterBody.ItemBehavior
        {
            private float fireballTimer;

            private int fireballsToLaunch;

            private float launchInterval;

            private void Start()
            {
                fireballTimer = Configuration.Elites.Unstable.fireballInterval;
            }
            private void FixedUpdate()
            {
                if(fireballTimer <= 0)
                {
                    if(fireballsToLaunch > 0)
                    {
                        if(launchInterval <= 0)
                        {
                            if (fireballsToLaunch > 0)
                            {
                                FireProjectileInfo fpi = new FireProjectileInfo()
                                {
                                    owner = this.body.gameObject,
                                    crit = this.body.RollCrit(),
                                    damage = body.damage * Configuration.Elites.Unstable.fireBallDamageCoefficient,
                                    position = body.corePosition,
                                    rotation = RoR2.Util.QuaternionSafeLookRotation(Vector3.up + UnityEngine.Random.insideUnitSphere * 0.5f),
                                    projectilePrefab = Content.Misc.EliteUnstableFireball,
                                    procChainMask = default,
                                };
                                ProjectileManager.instance.FireProjectile(fpi);
                                fireballsToLaunch--;
                                launchInterval = Configuration.Elites.Unstable.fireballInterval * 0.05f;
                                if(fireballsToLaunch <= 0)
                                {
                                    fireballTimer = Configuration.Elites.Unstable.fireballInterval;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            launchInterval -= Time.deltaTime;
                        }
                    }
                    else
                    {
                        fireballsToLaunch = Configuration.Elites.Unstable.fireBallCount;
                        launchInterval = Configuration.Elites.Unstable.fireballInterval * 0.05f;
                    }
                }
                else
                {
                    fireballTimer -= Time.deltaTime;
                }
            }
        }

    }
    public class AffixTar : BuffFactory
    {
        public static Material tarOverlayMaterial;
        public static Material tarParticleReplacementMaterial;
        public static GameObject bodyAttachment;
        private static readonly Color tarEliteLightColor = new Color32(170, 89, 59, 204);
        public class TarLifeStealOrb : GenericDamageOrb
        {
            public override GameObject GetOrbEffect()
            {
                return Content.Effects.TarLifeStealOrb.prefab;
            }
            public override void OnArrival()
            {
                if(target != null)
                {
                    HealthComponent hc = target.healthComponent;
                    if(hc != null)
                    {
                        if (hc.alive)
                        {
                            hc.Heal(this.damageValue * Configuration.Elites.Tar.lifeStealCoefficient, this.procChainMask, true);
                        }
                    }
                }
            }
        }
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Elites.LoadAsset<BuffDef>("bdEliteTar");
            bodyAttachment = Assets.AssetBundles.Elites.LoadAsset<GameObject>("TarDripBodyAttachment");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Elites.Tank.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            tarOverlayMaterial = Assets.AssetBundles.Elites.LoadAsset<Material>("matEliteTarOverlay");
            Materials.SubmitMaterialFix(tarOverlayMaterial, "Hopoo Games/FX/Opaque Cloud Remap");
            Material m = Assets.AssetBundles.Elites.LoadAsset<Material>("matTarDroplet");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
            tarParticleReplacementMaterial = Assets.AssetBundles.Elites.LoadAsset<Material>("matEliteTarParticleReplacement");
            Materials.SubmitMaterialFix(tarParticleReplacementMaterial, "Hopoo Games/FX/Opaque Cloud Remap");
        }
        protected override void Hooks()
        {
            On.RoR2.GlobalEventManager.OnHitEnemy += GlobalEventManager_OnHitEnemy;
            On.RoR2.CharacterModel.UpdateRendererMaterials += CharacterModel_UpdateRendererMaterials;
            On.RoR2.CharacterBody.OnClientBuffsChanged += CharacterBody_OnClientBuffsChanged;
            On.RoR2.CharacterModel.InstanceUpdate += CharacterModel_InstanceUpdate;
        }

        private void CharacterModel_InstanceUpdate(On.RoR2.CharacterModel.orig_InstanceUpdate orig, CharacterModel self)
        {
            orig.Invoke(self);
            CharacterBody cb = self.body;
            if (cb)
            {
                bool flag = cb.HasBuff(Content.Buffs.AffixTar);
                if (flag)
                {
                    self.particleMaterialOverride = tarParticleReplacementMaterial;
                    self.lightColorOverride = new Color?(tarEliteLightColor);
                }
            }
        }

        private void CharacterModel_UpdateRendererMaterials(On.RoR2.CharacterModel.orig_UpdateRendererMaterials orig, CharacterModel self, Renderer renderer, Material defaultMaterial, bool ignoreOverlays)
        {
            orig.Invoke(self, renderer, defaultMaterial, ignoreOverlays);
            CharacterBody cb = self.body;
            if (cb)
            {
                bool flag = cb.HasBuff(Content.Buffs.AffixTar);
                if (flag)
                {
                    if(self.visibility == VisibilityLevel.Visible)
                    {
                        if (!ignoreOverlays)
                        {
                            Material[] array = renderer.sharedMaterials;
                            ArrayUtils.ArrayAppend<Material>(ref array, in tarOverlayMaterial);
                            renderer.sharedMaterials = array;
                        }
                    }
                }
            }
        }

        private void CharacterBody_OnClientBuffsChanged(On.RoR2.CharacterBody.orig_OnClientBuffsChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            self.AddItemBehavior<EliteTarController>(self.HasBuff(Content.Buffs.AffixTar) ? 1 : 0);
        }


        private void GlobalEventManager_OnHitEnemy(On.RoR2.GlobalEventManager.orig_OnHitEnemy orig, GlobalEventManager self, DamageInfo damageInfo, GameObject victim)
        {
            orig.Invoke(self, damageInfo, victim);
            GameObject attacker = damageInfo.attacker;
            if (attacker != null)
            {
                CharacterBody cb = attacker.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    bool flag = cb.HasBuff(Content.Buffs.AffixTar);
                    if (flag)
                    {
                        CharacterBody vb = victim.GetComponent<CharacterBody>();
                        if(vb != null)
                        {
                            vb.AddTimedBuff(RoR2Content.Buffs.ClayGoo, Configuration.Elites.Tar.tarDuration);
                        }
                        if (!damageInfo.procChainMask.HasProc(Content.ProcTypes.eliteTarLifesteal))
                        {
                            damageInfo.procChainMask.AddProc(Content.ProcTypes.eliteTarLifesteal);
                            OrbManager.instance.AddOrb(new TarLifeStealOrb()
                            {
                                attacker = attacker,
                                damageValue = damageInfo.damage * damageInfo.procCoefficient,
                                origin = damageInfo.position,
                                procChainMask = damageInfo.procChainMask,
                                target = cb.mainHurtBox,
                                procCoefficient = 0f,
                                isCrit = false,
                            });
                        }
                    }
                }
            }
        }
    
        public class EliteTarController : CharacterBody.ItemBehavior
        {
            private GameObject bodyAttachmentInstance;
            private void OnEnable()
            {
                if (!this.bodyAttachmentInstance)
                {
                    bodyAttachmentInstance = GameObject.Instantiate(bodyAttachment, this.gameObject.transform);
                    NetworkedBodyAttachment nba = bodyAttachmentInstance.GetComponent<NetworkedBodyAttachment>();
                    EntityStateMachine.FindByCustomName(bodyAttachmentInstance, "Main").initialStateType = Content.SerializableEntityStates.EntityStateDictionary["TarBodyAttachmentState"];
                    EntityStateMachine.FindByCustomName(bodyAttachmentInstance, "Main").mainStateType = Content.SerializableEntityStates.EntityStateDictionary["TarBodyAttachmentState"];
                    if (nba != null)
                    {
                        nba.AttachToGameObjectAndSpawn(this.gameObject);
                    }
                }
            }

            private void OnDisable()
            {
                if (this.bodyAttachmentInstance)
                {
                    GameObject.Destroy(this.bodyAttachmentInstance);
                }
            }
        }
    }
    public class ShadowCloak : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Elites.LoadAsset<BuffDef>("bdShadowCloak");
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Elites.LoadAsset<Material>("matShadowCloak");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Elites.LoadAsset<Material>("matShadowTracer");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void Hooks()
        {
            On.RoR2.CharacterBody.GetVisibilityLevel_TeamIndex += CharacterBody_GetVisibilityLevel_TeamIndex;
        }

        private VisibilityLevel CharacterBody_GetVisibilityLevel_TeamIndex(On.RoR2.CharacterBody.orig_GetVisibilityLevel_TeamIndex orig, CharacterBody self, TeamIndex observerTeam)
        {
            if(self.teamComponent.teamIndex != observerTeam && self.HasBuff(Content.Buffs.DarknessCamo))
            {
                return VisibilityLevel.Cloaked;
            }
            return orig.Invoke(self, observerTeam);
        }
    }
    public class LunarCorruption : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdLunarCorruption");
        }
        protected override void HandleMaterials()
        {

        }
        protected override void Hooks()
        {
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
            On.RoR2.CharacterMaster.GiveExperience += CharacterMaster_GiveExperience;
        }

        private void CharacterMaster_GiveExperience(On.RoR2.CharacterMaster.orig_GiveExperience orig, CharacterMaster self, ulong amount)
        {
            GameObject body = self.GetBodyObject();
            if (body != null)
            {
                CharacterBody cb = body.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    int stacks = cb.GetBuffCount(Content.Buffs.LunarCorruption);
                    if (stacks > 0)
                    {
                        amount *= (ulong)(1f - (Configuration.Items.LunarRosary.LunarCorruption.experienceGainPenalty * stacks));
                    }
                }
            }
            orig.Invoke(self, amount);
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender.HasBuff(Content.Buffs.LunarCorruption))
            {
                int stacks = sender.GetBuffCount(Content.Buffs.LunarCorruption);
                args.baseCurseAdd += (sender.maxHealth * (stacks * Configuration.Items.LunarRosary.LunarCorruption.healthPenalty))/ 100f;
                args.moveSpeedReductionMultAdd += stacks * Configuration.Items.LunarRosary.LunarCorruption.movementPenalty;
                args.damageMultAdd -= stacks * Configuration.Items.LunarRosary.LunarCorruption.movementPenalty;

                args.primaryCooldownMultAdd += Configuration.Items.LunarRosary.LunarCorruption.cooldownPenalty * stacks;
                args.secondaryCooldownMultAdd += Configuration.Items.LunarRosary.LunarCorruption.cooldownPenalty * stacks;
                args.utilityCooldownMultAdd += Configuration.Items.LunarRosary.LunarCorruption.cooldownPenalty * stacks;
                args.specialCooldownMultAdd += Configuration.Items.LunarRosary.LunarCorruption.cooldownPenalty * stacks;
            }
        }
    }
    public class FullyCorrupted : BuffFactory
    {
        private static Material corruptionOverlay;
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdFullyCorrupted");
        }
        protected override void HandleMaterials()
        {
            corruptionOverlay = Assets.AssetBundles.Items.LoadAsset<Material>("matCorruptionOverlay");
            Materials.SubmitMaterialFix(corruptionOverlay, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void Hooks()
        {
            //R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
            On.RoR2.CharacterMaster.GiveExperience += CharacterMaster_GiveExperience;
            //On.RoR2.CharacterMaster.OnInventoryChanged += CharacterMaster_OnInventoryChanged;
            On.RoR2.CharacterModel.UpdateRendererMaterials += CharacterModel_UpdateRendererMaterials;
            //On.RoR2.CharacterBody.OnBuffFinalStackLost += CharacterBody_OnBuffFinalStackLost;
            //On.RoR2.CharacterBody.OnBuffFirstStackGained += CharacterBody_OnBuffFirstStackGained;
        }

        private void CharacterMaster_GiveExperience(On.RoR2.CharacterMaster.orig_GiveExperience orig, CharacterMaster self, ulong amount)
        {
            GameObject body = self.GetBodyObject();
            if (body != null)
            {
                CharacterBody cb = body.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    int stacks = cb.GetBuffCount(Content.Buffs.LunarCorruption);
                    if (stacks > 0)
                    {
                        amount *= (ulong)(1f + (Configuration.Items.LunarRosary.FullyCorrupted.experienceGainBonus * stacks));
                    }
                }
            }
            orig.Invoke(self, amount);
        }

        /*private void CharacterMaster_OnInventoryChanged(On.RoR2.CharacterMaster.orig_OnInventoryChanged orig, CharacterMaster self)
        {
            orig.Invoke(self);
            GameObject obj = self.GetBodyObject();
            if (obj != null)
            {
                CharacterBody cb = obj.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    if (cb.HasBuff(Content.Buffs.FullyCorrupted))
                    {
                        LunarRosary.LunarRosaryController lrc = obj.GetComponent<LunarRosary.LunarRosaryController>();
                        if (lrc != null)
                        {
                            int stacks = lrc.corruptionCap;
                            float luckBonus = Configuration.Items.LunarRosary.FullyCorrupted.luckBonus * stacks;
                            self.luck += luckBonus;
                        }
                    }
                }
            }
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender.HasBuff(Content.Buffs.FullyCorrupted))
            {
                LunarRosary.LunarRosaryController lrc = sender.GetComponent<LunarRosary.LunarRosaryController>();
                if (lrc != null)
                {
                    int stacks = lrc.corruptionCap;
                    args.damageMultAdd += Configuration.Items.LunarRosary.FullyCorrupted.damageBonus * stacks;
                    args.moveSpeedMultAdd += Configuration.Items.LunarRosary.FullyCorrupted.movementBonus * stacks;
                    args.healthMultAdd += Configuration.Items.LunarRosary.FullyCorrupted.healthBonus * stacks;
                    args.primaryCooldownMultAdd -= Configuration.Items.LunarRosary.FullyCorrupted.cooldownBonus * stacks;
                    args.secondaryCooldownMultAdd -= Configuration.Items.LunarRosary.FullyCorrupted.cooldownBonus * stacks;
                    args.utilityCooldownMultAdd -= Configuration.Items.LunarRosary.FullyCorrupted.cooldownBonus * stacks;
                    args.specialCooldownMultAdd -= Configuration.Items.LunarRosary.FullyCorrupted.cooldownBonus * stacks;
                }
            }
        }

        private void CharacterBody_OnBuffFirstStackGained(On.RoR2.CharacterBody.orig_OnBuffFirstStackGained orig, CharacterBody self, BuffDef buffDef)
        {
            orig.Invoke(self, buffDef);
            if(buffDef == Content.Buffs.FullyCorrupted)
            {
                CharacterMaster cmaster = self.master;
                if (cmaster != null)
                {
                    LunarRosary.LunarRosaryController lrc = self.GetComponent<LunarRosary.LunarRosaryController>();
                    if(lrc != null)
                    {
                        int stacks = lrc.corruptionCap;
                        float luckBonus = Configuration.Items.LunarRosary.FullyCorrupted.luckBonus * stacks;
                        cmaster.luck += luckBonus;
                    }
                }
                ModelLocator ml = self.modelLocator;
                if (ml != null)
                {
                    Transform m = ml.modelTransform;
                    if (m != null)
                    {
                        CharacterModel cm = m.GetComponent<CharacterModel>();
                        if (cm != null)
                        {
                            cm.materialsDirty = true;
                        }
                    }
                }
            }
        }

        private void CharacterBody_OnBuffFinalStackLost(On.RoR2.CharacterBody.orig_OnBuffFinalStackLost orig, CharacterBody self, BuffDef buffDef)
        {
            orig.Invoke(self, buffDef);
            if(buffDef == Content.Buffs.FullyCorrupted)
            {
                float scale = 1f;
                ModelLocator ml = self.modelLocator;
                if (ml != null)
                {
                    scale = ml.modelScaleCompensation;
                }
                EffectData ed = new EffectData()
                {
                    origin = self.coreTransform.position,
                    start = self.coreTransform.position,
                    rootObject = self.gameObject,
                    scale = scale,
                    rotation = Quaternion.identity,
                };
                EffectManager.SpawnEffect(Content.Effects.CorruptionLifts.prefab, ed, true);
                CharacterMaster cmaster = self.master;
                if (cmaster != null)
                {
                    LunarRosary.LunarRosaryController lrc = self.GetComponent<LunarRosary.LunarRosaryController>();
                    if (lrc != null)
                    {
                        int stacks = lrc.corruptionCap;
                        float luckBonus = Configuration.Items.LunarRosary.FullyCorrupted.luckBonus * stacks;
                        cmaster.luck -= luckBonus;
                    }
                }
                if (ml != null)
                {
                    Transform m = ml.modelTransform;
                    if (m != null)
                    {
                        CharacterModel cm = m.GetComponent<CharacterModel>();
                        if (cm != null)
                        {
                            cm.materialsDirty = true;
                        }
                    }
                }
            }
        }*/


        private void CharacterModel_UpdateRendererMaterials(On.RoR2.CharacterModel.orig_UpdateRendererMaterials orig, CharacterModel self, Renderer renderer, Material defaultMaterial, bool ignoreOverlays)
        {
            orig.Invoke(self, renderer, defaultMaterial, ignoreOverlays);
            CharacterBody cb = self.body;
            if (cb)
            {
                bool flag = cb.HasBuff(Content.Buffs.FullyCorrupted);
                if (flag)
                {
                    if (self.visibility == VisibilityLevel.Visible)
                    {
                        if (!ignoreOverlays)
                        {
                            Material[] array = renderer.sharedMaterials;
                            ArrayUtils.ArrayAppend<Material>(ref array, in corruptionOverlay);
                            renderer.sharedMaterials = array;
                        }
                    }
                }
            }
        }
    }
    public class EliteTankArmorBonus : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Elites.LoadAsset<BuffDef>("bdEliteTankArmorBonus");
        }
        protected override void HandleMaterials()
        {

        }
        protected override void Hooks()
        {
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender)
            {
                args.armorAdd += sender.GetBuffCount(Content.Buffs.TankArmorBonus) * Configuration.Elites.Tank.armorBonus;
            }
        }

        
    }
    public class GeodeArmor : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bgGeodeArmor");
        }
        protected override void Hooks()
        {
            base.Hooks();
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender.HasBuff(Content.Buffs.GeodeArmor))
            {
                Inventory i = sender.inventory;
                if (i != null)
                {
                    int itemCount = i.GetItemCountEffective(Content.Items.Geode);
                    if (itemCount > 0)
                    {
                        args.armorAdd += Util.GetStackingBehavior(Configuration.Items.Geode.armorBonus, Configuration.Items.Geode.armorStack, itemCount);
                        args.baseRegenAdd += (Util.GetStackingBehavior(Configuration.Items.Geode.regenMult, Configuration.Items.Geode.regenMultStack, itemCount));
                    }
                }
            }
        }

    }
    public class BeetlePlushRegen : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("buffBeetlePlushRegenBonus");
        }
        protected override void Hooks()
        {
            base.Hooks();
            On.RoR2.CharacterBody.RecalculateStats += CharacterBody_RecalculateStats;
        }

        private void CharacterBody_RecalculateStats(On.RoR2.CharacterBody.orig_RecalculateStats orig, CharacterBody self)
        {
            orig.Invoke(self);
            if (self.HasBuff(Content.Buffs.BeetleRegen))
            {
                BeetlePlush.BeetlePlushBehaviourController bpbc = self.gameObject.GetComponent<BeetlePlush.BeetlePlushBehaviourController>();
                if (bpbc != null)
                {
                    int alliesNearby = bpbc.alliesNearby;
                    self.regen += Configuration.Items.BeetlePlush.regenBonus * self.GetBuffCount(Content.Buffs.BeetleRegen);
                }
            }
        }


    }
    public class DeathImmunityBuff : BuffFactory
    {
        protected static GameObject tempEffect;
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdDeathImmunity");
            tempEffect = Assets.AssetBundles.Items.LoadAsset<GameObject>("DeathImmunityEffect");
            TempVisualEffectAPI.AddTemporaryVisualEffect(tempEffect, new TempVisualEffectAPI.EffectCondition(target => { return target.HasBuff(Content.Buffs.DeathImmunity); }), true );
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matAngelFeather");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void Hooks()
        {
            On.RoR2.HealthComponent.TakeDamageProcess += HealthComponent_TakeDamageProcess;
            On.RoR2.GlobalEventManager.OnCharacterDeath += GlobalEventManager_OnCharacterDeath;
        }


        private void GlobalEventManager_OnCharacterDeath(On.RoR2.GlobalEventManager.orig_OnCharacterDeath orig, GlobalEventManager self, DamageReport damageReport)
        {
            orig.Invoke(self, damageReport);
            CharacterBody cb = damageReport.attackerBody;
            if (cb != null)
            {
                bool flag = cb.HasBuff(Content.Buffs.DeathImmunity);
                if (flag)
                {
                    foreach (var item in cb.timedBuffs)
                    {
                        if(item.buffIndex == Content.Buffs.DeathImmunity.buffIndex)
                        {
                            item.timer += Configuration.Items.DeathImmunity.buffExtension;
                        }
                    }
                }
            }
        }

        private void HealthComponent_TakeDamageProcess(On.RoR2.HealthComponent.orig_TakeDamageProcess orig, HealthComponent self, DamageInfo damageInfo)
        {
            CharacterBody cb = self.body;
            if (cb != null)
            {
                bool flag = cb.HasBuff(Content.Buffs.DeathImmunity);
                if (flag)
                {
                    damageInfo.damage = Mathf.Clamp(damageInfo.damage, 0f, self.combinedHealth - 1f);
                }
            }
            orig.Invoke(self, damageInfo);
        }
    }
    public class BossKillFrenzy : BuffFactory
    {
        Material overlayMat;
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdFrenzyOnBossKill");
        }
        protected override void HandleMaterials()
        {
            overlayMat = Assets.AssetBundles.Items.LoadAsset<Material>("matFrenzyOnBossKillOverlay");
            Materials.SubmitMaterialFix(overlayMat, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void Hooks()
        {
            base.Hooks();
            On.RoR2.HealthComponent.TakeDamage += HealthComponent_TakeDamage;
            On.RoR2.CharacterModel.UpdateRendererMaterials += CharacterModel_UpdateRendererMaterials;
            On.RoR2.CharacterBody.OnBuffFirstStackGained += CharacterBody_OnBuffFirstStackGained;
            On.RoR2.CharacterBody.OnBuffFinalStackLost += CharacterBody_OnBuffFinalStackLost;
            On.RoR2.CharacterMaster.OnInventoryChanged += CharacterMaster_OnInventoryChanged;
        }

        private void CharacterModel_UpdateRendererMaterials(On.RoR2.CharacterModel.orig_UpdateRendererMaterials orig, CharacterModel self, Renderer renderer, Material defaultMaterial, bool ignoreOverlays)
        {
            orig.Invoke(self, renderer, defaultMaterial, ignoreOverlays);
            CharacterBody cb = self.body;
            if (cb)
            {
                bool flag = cb.HasBuff(Content.Buffs.BossKillFrenzy);
                if (flag)
                {
                    if (self.visibility == VisibilityLevel.Visible)
                    {
                        if (!ignoreOverlays)
                        {
                            Material[] array = renderer.sharedMaterials;
                            ArrayUtils.ArrayAppend<Material>(ref array, in overlayMat);
                            renderer.sharedMaterials = array;
                        }
                    }
                }
            }
        }

        private void CharacterMaster_OnInventoryChanged(On.RoR2.CharacterMaster.orig_OnInventoryChanged orig, CharacterMaster self)
        {
            orig.Invoke(self);
            CharacterBody cb = self.GetBody();
            if (cb != null)
            {
                if (cb.HasBuff(Content.Buffs.BossKillFrenzy))
                {
                    self.luck += Configuration.Items.FrenzyOnBossKill.luckBonus;
                }
            }
        }

        private void CharacterBody_OnBuffFinalStackLost(On.RoR2.CharacterBody.orig_OnBuffFinalStackLost orig, CharacterBody self, BuffDef buffDef)
        {
            orig.Invoke(self, buffDef);
            if (buffDef == Content.Buffs.BossKillFrenzy)
            {
                CharacterMaster master = self.master;
                if (master != null)
                {
                    master.luck -= Configuration.Items.FrenzyOnBossKill.luckBonus;
                }
            }
        }

        private void CharacterBody_OnBuffFirstStackGained(On.RoR2.CharacterBody.orig_OnBuffFirstStackGained orig, CharacterBody self, BuffDef buffDef)
        {
            orig.Invoke(self, buffDef);
            if (buffDef == Content.Buffs.BossKillFrenzy)
            {
                CharacterMaster master = self.master;
                if (master != null)
                {
                    master.luck += Configuration.Items.FrenzyOnBossKill.luckBonus;
                }
            }
        }

        private void HealthComponent_TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            CharacterBody cb = self.body;
            if (cb != null)
            {
                if (cb.HasBuff(Content.Buffs.BossKillFrenzy))
                {
                    EffectData ed = new EffectData
                    {
                        origin = damageInfo.position,
                        start = damageInfo.position,
                        rotation = RoR2.Util.QuaternionSafeLookRotation((damageInfo.force != Vector3.zero) ? damageInfo.force : UnityEngine.Random.onUnitSphere)
                    };
                    EffectManager.SpawnEffect(HealthComponent.AssetReferences.damageRejectedPrefab, ed, true);
                    damageInfo.rejected = true;
                }
            }
            orig.Invoke(self, damageInfo);
        }


    }

    public class TimeSlowed : BuffFactory
    {
        Material overlayMat;
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdSlowTime");
        }
        protected override void Hooks()
        {
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender.HasBuff(Content.Buffs.SlowedTime))
            {
                args.moveSpeedReductionMultAdd += Configuration.Items.SlowTime.speedMult;
                args.attackSpeedReductionMultAdd += Configuration.Items.SlowTime.speedMult;
            }
        }
    }
    public class Grief : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdGrief");
        }
        protected override void Hooks()
        {
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender.HasBuff(Content.Buffs.Grief))
            {
                args.damageMultAdd += Configuration.Items.GriefFlower.damageMult;
                args.armorAdd += Configuration.Items.GriefFlower.armorBoost;
                args.regenMultAdd += Configuration.Items.GriefFlower.regenMult;
                args.moveSpeedMultAdd += Configuration.Items.GriefFlower.moveSpeedMult;
                args.attackSpeedMultAdd += Configuration.Items.GriefFlower.attackSpeedMult;
            }
        }


    }

    public class MiniWispStock : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdWispOnHit");
        }

    }
    public class BisonShieldActive : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("BisonShieldReady");
        }

    }
    public class BisonShieldCooldown : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("BisonShieldCooldown");
        }
    }

    public class MeleeAttackSpeedBuff : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdMeleeAttackSpeed");
        }
        protected override void Hooks()
        {
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender.HasBuff(Content.Buffs.MeleeAttackSpeed))
            {
                Inventory i = sender.inventory;
                if (i != null) {
                    int itemcount = i.GetItemCountEffective(Content.Items.MeleeAttackSpeed);
                    float multiplier = Util.GetStackingBehavior(Configuration.Items.MeleeAttackSpeed.attackSpeedMult, Configuration.Items.MeleeAttackSpeed.attackSpeedMultStack, itemcount);
                    args.attackSpeedMultAdd += multiplier;
                }
            }
        }
    }
    public class NullSeedActive : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdNullSeedReady");
        }

    }
    public class NullSeedCooldown : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdNullSeedCooldown");
        }
        protected override void Hooks()
        {
            On.RoR2.CharacterBody.OnBuffFinalStackLost += CharacterBody_OnBuffFinalStackLost;
        }

        private void CharacterBody_OnBuffFinalStackLost(On.RoR2.CharacterBody.orig_OnBuffFinalStackLost orig, CharacterBody self, BuffDef buffDef)
        {
            orig.Invoke(self, buffDef);
            if (buffDef == Content.Buffs.NullSeedCooldown)
            {
                Inventory i = self.inventory;
                if (i != null)
                {
                    bool flag = i.GetItemCountEffective(Content.Items.NullSeed) > 0;
                    if (flag)
                    {
                        self.AddBuff(Content.Buffs.NullSeedActive);
                    }
                }
            }
        }
    }
    public class StoredLunarCoin : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("BisonShieldCooldown");
        }

    }
    public class ArmorZone : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdArmorZone");
        }
        protected override void Hooks()
        {
            base.Hooks();
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender.HasBuff(Content.Buffs.ArmorZone))
            {
                float armorBonus = TeleporterArmorZone.HoldOutArmorZoneController.armorBonus;
                args.armorAdd += armorBonus;
            }
        }
    }
    public class TarbineBuff : BuffFactory
    {
        protected override void LoadAssets(ref BuffDef buffDef)
        {
            buffDef = Assets.AssetBundles.Items.LoadAsset<BuffDef>("bdTarbineActive");
        }

    }
}
