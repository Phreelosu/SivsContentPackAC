using R2API;
using RoR2;
using RoR2.Projectile;
using SivsContentPack.Config;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;

namespace SivsContentPack.Items
{
    internal class FireburstOnFreeze : EquipFactory
    {
        protected override void LoadAssets(ref EquipmentDef equipmentDef)
        {
            equipmentDef = Assets.AssetBundles.Items.LoadAsset<EquipmentDef>("FireBurstOnFreeze");
        }

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.FireburstOnFreeze.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matThermostat");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matThermoScreen");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            /*itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiTurretBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiWalkerTurretBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EquipmentDroneBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("ScavBody", [
                new ItemDisplayRule()
                {
                    childName = "Base",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);*/
        }
        protected override void Hooks()
        {
            On.EntityStates.FrozenState.FixedUpdate += FrozenState_FixedUpdate;
            On.RoR2.EquipmentSlot.PerformEquipmentAction += EquipmentSlot_PerformEquipmentAction;
        }

        private void FrozenState_FixedUpdate(On.EntityStates.FrozenState.orig_FixedUpdate orig, EntityStates.FrozenState self)
        {
            orig.Invoke(self);
            CharacterBody body = self.characterBody;
            if (body != null)
            {
                EquipmentSlot equipSlot = body.equipmentSlot;
                if (equipSlot != null)
                {
                    if (equipSlot.equipmentIndex == Content.Items.FireburstOnFreeze.equipmentIndex)
                    {
                        if (equipSlot.ExecuteIfReady())
                        {
                            self.outer.SetNextStateToMain();
                        }
                    }
                }
            }
        }

        private bool EquipmentSlot_PerformEquipmentAction(On.RoR2.EquipmentSlot.orig_PerformEquipmentAction orig, EquipmentSlot self, EquipmentDef equipmentDef)
        {
            if (equipmentDef == Content.Items.FireburstOnFreeze)
            {
                bool flag = false;
                CharacterBody cb = self.characterBody;
                if (cb != null)
                {
                    HealthComponent hc = cb.GetComponent<HealthComponent>();
                    if (hc != null)
                    {
                        flag = hc.isInFrozenState;
                    }
                }

                Func<EquipmentSlot, bool> func = null;
                func = new Func<EquipmentSlot, bool>(FireFireburstOnFreeze);
                return (flag && func != null && func(self));
            }
            else
            {
                return orig.Invoke(self, equipmentDef);
            }
        }
        private bool FireFireburstOnFreeze(EquipmentSlot equipmentSlot)
        {
            CharacterBody body = equipmentSlot.characterBody;
            Vector3 corePosition = body.corePosition;
            EffectData effectData = new EffectData
            {
                origin = corePosition
            };
            effectData.SetHurtBoxReference(body.mainHurtBox);
            EffectManager.SpawnEffect(LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/CleanseEffect"), effectData, true);
            BlastAttack attack = new BlastAttack
            {
                attacker = body.gameObject,
                baseDamage = body.damage * Configuration.Items.FireburstOnFreeze.burnDamageCoefficient,
                crit = body.RollCrit(),
                damageType = DamageType.IgniteOnHit,
                procCoefficient = 1,
                radius = Configuration.Items.FireburstOnFreeze.burnDuration,
                position = corePosition,
                teamIndex = body.teamComponent.teamIndex
            };
            attack.Fire();
            return true;
        }

    }

    internal class DeathImmunity : EquipFactory
    {
        protected override void LoadAssets(ref EquipmentDef equipmentDef)
        {
            equipmentDef = Assets.AssetBundles.Items.LoadAsset<EquipmentDef>("DeathImmunity");
        }

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.DeathImmunity.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matAngel");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            
        }
        protected override void Hooks()
        {
            On.RoR2.EquipmentSlot.PerformEquipmentAction += EquipmentSlot_PerformEquipmentAction;
        }

        private bool EquipmentSlot_PerformEquipmentAction(On.RoR2.EquipmentSlot.orig_PerformEquipmentAction orig, EquipmentSlot self, EquipmentDef equipmentDef)
        {
            if (equipmentDef == Content.Items.DeathImmunity)
            {
                Func<EquipmentSlot, bool> func = null;
                func = new Func<EquipmentSlot, bool>(FireDeathImmunity);
                return (func != null && func(self));
            }
            else
            {
                return orig.Invoke(self, equipmentDef);
            }
        }
        private bool FireDeathImmunity(EquipmentSlot equipmentSlot)
        {
            CharacterBody body = equipmentSlot.characterBody;
            EffectData ed = new EffectData()
            {
                origin = body.coreTransform.position,
                start = body.coreTransform.position,
                rootObject = body.gameObject,
                rotation = Quaternion.identity,
                scale = body.modelLocator.modelScaleCompensation
            };
            EffectManager.SpawnEffect(Content.Effects.DeathImmunityProc.prefab, ed, true);
            body.AddTimedBuff(Content.Buffs.DeathImmunity, Configuration.Items.DeathImmunity.buffDuration);
            return true;
        }

    }

    internal class SlowTime : EquipFactory
    {

        protected override void LoadAssets(ref EquipmentDef equipmentDef)
        {
            equipmentDef = Assets.AssetBundles.Items.LoadAsset<EquipmentDef>("SlowTime");
            Content.Misc.SlowTimeBubble = Assets.AssetBundles.Items.LoadAsset<GameObject>("SlowTimeAreaIndicator");
            SlowDownProjectiles sdp = Content.Misc.SlowTimeBubble.GetComponent<SlowDownProjectiles>();
            if(sdp != null)
            {
                sdp.slowDownCoefficient = (1- Configuration.Items.SlowTime.speedMult);
            }
            ContentAddition.AddProjectile(Content.Misc.SlowTimeBubble);
        }

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.SlowTime.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matPocketWatch");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGlass");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Distortion");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSlowTimeBubble");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTimeIndicator");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTimeRuneRibbon");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTimeParticle");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTimeDistortion");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Distortion");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
        protected override void Hooks()
        {
            On.RoR2.EquipmentSlot.PerformEquipmentAction += EquipmentSlot_PerformEquipmentAction;
        }

        private bool EquipmentSlot_PerformEquipmentAction(On.RoR2.EquipmentSlot.orig_PerformEquipmentAction orig, EquipmentSlot self, EquipmentDef equipmentDef)
        {
            if (equipmentDef == Content.Items.SlowTime)
            {
                Func<EquipmentSlot, bool> func = null;
                func = new Func<EquipmentSlot, bool>(FireSlowTime);
                return (func != null && func(self));
            }
            else
            {
                return orig.Invoke(self, equipmentDef);
            }
        }
        private bool FireSlowTime(EquipmentSlot equipmentSlot)
        {
            FireProjectileInfo fpi = new FireProjectileInfo()
            {
                owner = equipmentSlot.gameObject,
                position = equipmentSlot.characterBody.corePosition,
                projectilePrefab = Content.Misc.SlowTimeBubble,
                rotation = Quaternion.identity,
                procChainMask = default,
                crit = false,
                damage = 0f,
            };
            ProjectileManager.instance.FireProjectile(fpi);
            return true;
        }

    }
    internal class LevelUp : EquipFactory
    {
        protected override void LoadAssets(ref EquipmentDef equipmentDef)
        {
            equipmentDef = Assets.AssetBundles.Items.LoadAsset<EquipmentDef>("LevelUp");
        }

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.LevelUp.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matAngel");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
        protected override void Hooks()
        {
            On.RoR2.EquipmentSlot.PerformEquipmentAction += EquipmentSlot_PerformEquipmentAction;
        }

        private bool EquipmentSlot_PerformEquipmentAction(On.RoR2.EquipmentSlot.orig_PerformEquipmentAction orig, EquipmentSlot self, EquipmentDef equipmentDef)
        {
            if (equipmentDef == Content.Items.LevelUp)
            {
                Func<EquipmentSlot, bool> func = null;
                func = new Func<EquipmentSlot, bool>(FireLevelUp);
                return (func != null && func(self));
            }
            else
            {
                return orig.Invoke(self, equipmentDef);
            }
        }
        private bool FireLevelUp(EquipmentSlot equipmentSlot)
        {
            CharacterBody body = equipmentSlot.characterBody;
            body.level++;
            body.OnLevelUp();
            body.statsDirty = true;
            return true;
        }

    }


    internal class Egg : EquipFactory
    {
        protected override void LoadAssets(ref EquipmentDef equipmentDef)
        {
            equipmentDef = Assets.AssetBundles.Items.LoadAsset<EquipmentDef>("Egg");
        }

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Egg.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matEgg");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matEggStar");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matEggPlanet1");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matEggPlanet2");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matEggPlanet3");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
        protected override void Hooks()
        {
            On.RoR2.EquipmentSlot.PerformEquipmentAction += EquipmentSlot_PerformEquipmentAction;
        }

        private bool EquipmentSlot_PerformEquipmentAction(On.RoR2.EquipmentSlot.orig_PerformEquipmentAction orig, EquipmentSlot self, EquipmentDef equipmentDef)
        {
            if (equipmentDef == Content.Items.Egg)
            {
                Func<EquipmentSlot, bool> func = null;
                func = new Func<EquipmentSlot, bool>(FireEgg);
                return (func != null && func(self));
            }
            else
            {
                return orig.Invoke(self, equipmentDef);
            }
        }
        private bool FireEgg(EquipmentSlot equipmentSlot)
        {
            CharacterBody body = equipmentSlot.characterBody;
            body.level++;
            body.OnLevelUp();
            body.statsDirty = true;
            equipmentSlot.equipmentIndex = Content.Items.EggUsed.equipmentIndex;
            return true;
        }

    }

    internal class EggUsed : EquipFactory
    {
        protected override void LoadAssets(ref EquipmentDef equipmentDef)
        {
            equipmentDef = Assets.AssetBundles.Items.LoadAsset<EquipmentDef>("EggUsed");
        }

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Egg.enabled.Value;
        }
        protected override void HandleMaterials()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
        protected override void Hooks()
        {
            On.RoR2.EquipmentSlot.PerformEquipmentAction += EquipmentSlot_PerformEquipmentAction;
        }

        private bool EquipmentSlot_PerformEquipmentAction(On.RoR2.EquipmentSlot.orig_PerformEquipmentAction orig, EquipmentSlot self, EquipmentDef equipmentDef)
        {
            if (equipmentDef == Content.Items.EggUsed)
            {
                Func<EquipmentSlot, bool> func = null;
                func = new Func<EquipmentSlot, bool>(FireEggUsed);
                return (func != null && func(self));
            }
            else
            {
                return orig.Invoke(self, equipmentDef);
            }
        }
        private bool FireEggUsed(EquipmentSlot equipmentSlot)
        {
            
            return true;
        }

    }

    internal class ChargingLaser : EquipFactory
    {

        protected override void LoadAssets(ref EquipmentDef equipmentDef)
        {
            equipmentDef = Assets.AssetBundles.Items.LoadAsset<EquipmentDef>("ChargingLaser");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayChargingLaser");
        }

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.ChargingLaser.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matChargingLaserTrimsheet");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matChargingLaserHolo");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matCLDisplayGlow");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matCLElectric");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matCLEmbers");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matCLLaser");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matCLLightning");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matCLTracer");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTracerBlack");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiWalkerTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EquipmentDroneBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("ScavBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
        }
        protected override void Hooks()
        {
            On.RoR2.EquipmentSlot.PerformEquipmentAction += EquipmentSlot_PerformEquipmentAction;
        }

        private bool EquipmentSlot_PerformEquipmentAction(On.RoR2.EquipmentSlot.orig_PerformEquipmentAction orig, EquipmentSlot self, EquipmentDef equipmentDef)
        {
            if (equipmentDef == Content.Items.ChargingLaser)
            {
                Func<EquipmentSlot, bool> func = null;
                func = new Func<EquipmentSlot, bool>(FireChargingLaser);
                return (func != null && func(self));
            }
            else
            {
                return orig.Invoke(self, equipmentDef);
            }
        }
        private bool FireChargingLaser(EquipmentSlot equipmentSlot)
        {
            
            return true;
        }


    }

    internal class EquipEliteShadow : EquipFactory
    {
        protected override void LoadAssets(ref EquipmentDef equipmentDef)
        {
            equipmentDef = Assets.AssetBundles.Elites.LoadAsset<EquipmentDef>("eqEliteShadow");
            displayPrefab = Assets.AssetBundles.Elites.LoadAsset<GameObject>("DisplayEliteShadow");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Elites.Obscuring.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Elites.LoadAsset<Material>("matEliteShadowPickup");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Elites.LoadAsset<Material>("matAnglerStem");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Elites.LoadAsset<Material>("matAnglerLight");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Elites.LoadAsset<Material>("matObscuringLureGlow");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterLanguageTokens()
        {
            
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.00121F, 0.37194F, 0.08543F),
localAngles = new Vector3(333.4449F, 359.8797F, 0.08415F),
localScale = new Vector3(0.25811F, 0.25811F, 0.25811F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.28724F, -0.00001F),
localAngles = new Vector3(322.5405F, 0F, 0F),
localScale = new Vector3(0.27245F, 0.27245F, 0.27245F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Hat",
localPos = new Vector3(-0.00001F, 0.07795F, 0.10022F),
localAngles = new Vector3(322.1343F, 0F, 0F),
localScale = new Vector3(0.31152F, 0.31152F, 0.31152F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 3.92869F, 0.00012F),
localAngles = new Vector3(278.9633F, 189.892F, 353.8126F),
localScale = new Vector3(2.496F, 2.496F, 2.496F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, 0.07031F, 0.1108F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.27615F, 0.27615F, 0.27615F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0.10087F, -0.04515F, 0.02354F),
localAngles = new Vector3(297.9987F, 111.812F, 148.3222F),
localScale = new Vector3(0.54361F, 0.54361F, 0.54361F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, 0.09714F, 0.06515F),
localAngles = new Vector3(331.3503F, 0F, 0F),
localScale = new Vector3(0.36306F, 0.36306F, 0.36306F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, 0.10289F, 0.11309F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.37786F, 0.37786F, 0.37786F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.16976F, 0.13848F),
localAngles = new Vector3(346.6392F, 0F, 0F),
localScale = new Vector3(0.25627F, 0.25627F, 0.25627F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.03559F, 1.33847F, 1.59255F),
localAngles = new Vector3(324.1848F, 1.09923F, 178.122F),
localScale = new Vector3(1.88526F, 1.88526F, 1.88526F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, 0.0803F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.56383F, 0.56383F, 0.56383F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.16898F, 0F),
localAngles = new Vector3(324.1895F, 0F, 0F),
localScale = new Vector3(0.28638F, 0.28638F, 0.28638F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.11496F, 0.00001F),
localAngles = new Vector3(325.3504F, 0F, 0F),
localScale = new Vector3(0.44979F, 0.44979F, 0.44979F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.18026F, 0.08174F),
localAngles = new Vector3(337.2538F, 0F, 0F),
localScale = new Vector3(0.29911F, 0.29911F, 0.29911F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.4073F, 0.14474F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.34137F, 0.34137F, 0.34137F)
                }
            ]);

            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.4073F, 0.14474F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.34137F, 0.34137F, 0.34137F)
                }
            ]);
            itemDisplayRules.Add("EngiTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiWalkerTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EquipmentDroneBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("BeetleBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.56819F, 0F),
localAngles = new Vector3(310.4039F, 171.3028F, 7.87055F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("VultureBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.00001F, 1.24138F, -0.57015F),
localAngles = new Vector3(316.6147F, 180F, 180F),
localScale = new Vector3(3.70156F, 3.70156F, 3.70156F)
                }
            ]);
            itemDisplayRules.Add("BeetleGuardBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.00469F, 0.82961F, 0.9652F),
localAngles = new Vector3(287.4995F, 358.5989F, 180.4945F),
localScale = new Vector3(2.24396F, 2.24396F, 2.24396F)
                }
            ]);
            itemDisplayRules.Add("BisonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.357F, 0.47909F),
localAngles = new Vector3(286.2722F, 11.48201F, 165.209F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("VerminBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.59514F, -0.45013F),
localAngles = new Vector3(314.0683F, 180F, 180F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("FlyingVerminBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.95066F, -1.06749F),
localAngles = new Vector3(278.76F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("BellBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "BellEnd",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("ChildBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.3635F, 0F),
localAngles = new Vector3(340.5645F, 0F, 0F),
localScale = new Vector3(0.7261F, 0.7261F, 0.7261F)
                }
            ]);
            itemDisplayRules.Add("ClayGrenadierBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0F, 0F),
localAngles = new Vector3(281.1756F, 0F, 0F),
localScale = new Vector3(0.38145F, 0.38145F, 0.38145F)
                }
            ]);
            itemDisplayRules.Add("ClayBruiserBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.00001F, 0.21557F, 0.27059F),
localAngles = new Vector3(324.3655F, 0F, 0F),
localScale = new Vector3(0.69173F, 0.69173F, 0.69173F)
                }
            ]);
            itemDisplayRules.Add("LemurianBruiserBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.01379F, 3.78198F, 0.1192F),
localAngles = new Vector3(292.6585F, 359.5644F, 180.548F),
localScale = new Vector3(3.00959F, 3.00959F, 3.00959F)
                }
            ]);
            itemDisplayRules.Add("LemurianBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.02694F, 1.75244F, -0.99641F),
localAngles = new Vector3(294.09F, 177.5273F, 177.1449F),
localScale = new Vector3(3.37178F, 3.37178F, 3.37178F)
                }
            ]);

            itemDisplayRules.Add("GupBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, -0.00001F, 0.93956F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.41753F, 0.41753F, 0.41753F)
                }
            ]);
            itemDisplayRules.Add("GreaterWispBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MaskBase",
localPos = new Vector3(0F, 0.66394F, 0.77868F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("WispBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.02155F, 0.29279F, 0.50232F),
localAngles = new Vector3(273.6025F, 350.5713F, 191.8427F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("HalcyoniteBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.70682F, 0.43666F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("HermitCrabBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.31256F, 0.50631F, 0.4215F),
localAngles = new Vector3(0F, 326.6768F, 0F),
localScale = new Vector3(0.76232F, 0.76232F, 0.76232F)
                }
            ]);
            itemDisplayRules.Add("ImpBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.00233F, 0.00001F, -0.17845F),
localAngles = new Vector3(332.3448F, 179.2506F, 0F),
localScale = new Vector3(0.4211F, 0.4211F, 0.4211F)
                }
            ]);
            itemDisplayRules.Add("JellyfishBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Hull2",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("AcidLarvaBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Head",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                },
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Head",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("LunarExploderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("LunarWispBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("LunarGolemBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("MiniMushroomBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.14432F, -1.13077F, -0.01637F),
localAngles = new Vector3(87.32241F, 180.0003F, 268.9865F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("ParentBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-28.73032F, 138.2682F, -3.03467F),
localAngles = new Vector3(311.6366F, 91.25723F, 354.5409F),
localScale = new Vector3(79.83963F, 79.83963F, 79.83963F)
                }
            ]);
            itemDisplayRules.Add("ScorchlingBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.20791F, 0.23346F, -0.0514F),
localAngles = new Vector3(300.1342F, 85.983F, 18.25761F),
localScale = new Vector3(1.74186F, 1.74186F, 1.74186F)
                }
            ]);
            itemDisplayRules.Add("RoboBallMiniBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(0.00094F, 0.34381F, 0.90494F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("GolemBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.96207F, 0.23793F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("VoidBarnacleBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.48696F, 0F, -0.01567F),
localAngles = new Vector3(0F, 274.188F, 94.15979F),
localScale = new Vector3(1.33652F, 1.33652F, 1.33652F)
                }
            ]);
            itemDisplayRules.Add("NullifierBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.01166F, 0.12788F, 2.14347F),
localAngles = new Vector3(29.04727F, 359.939F, 0.1472F),
localScale = new Vector3(1.88341F, 1.88341F, 1.88341F)
                }
            ]);
            itemDisplayRules.Add("VoidJailerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.47717F, 0.01915F, 0.46125F),
localAngles = new Vector3(357.418F, 322.3184F, 83.99445F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("BeetleQueen2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 2.10058F, -1.50764F),
localAngles = new Vector3(30.77937F, 175.3811F, 356.3507F),
localScale = new Vector3(2.12632F, 2.12632F, 2.12632F)
                }
            ]);
            itemDisplayRules.Add("ClayBossBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "PotLidTop",
localPos = new Vector3(0F, 0.2349F, 2.16835F),
localAngles = new Vector3(350.5547F, 0F, 0F),
localScale = new Vector3(2.07212F, 2.07212F, 2.07212F)
                }
            ]);
            itemDisplayRules.Add("GrandParentBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Head",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("GravekeeperBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Mask",
localPos = new Vector3(0.01012F, 0.17377F, 1.67276F),
localAngles = new Vector3(294.2587F, 191.574F, 351.5567F),
localScale = new Vector3(2.48427F, 2.48427F, 2.48427F)
                }
            ]);
            itemDisplayRules.Add("ImpBossBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, -0.01801F, -0.6358F),
localAngles = new Vector3(3.25789F, 180.9697F, 0.02762F),
localScale = new Vector3(1.2192F, 1.2192F, 1.2192F)
                }
            ]);
            itemDisplayRules.Add("RoboBallBossBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "EyeballMuzzle1",
localPos = new Vector3(0.00051F, -0.00312F, -0.05584F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.76562F, 0.76562F, 0.76562F)
                }
            ]);
            itemDisplayRules.Add("TitanBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.08978F, 5.68319F, 1.67604F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(3.72262F, 3.72262F, 3.72262F)
                }
            ]);
            itemDisplayRules.Add("VagrantBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Hull",
localPos = new Vector3(0.00152F, 1.68488F, -0.00987F),
localAngles = new Vector3(336.3325F, 0.09105F, 359.6878F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("VoidMegaCrabBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Head",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("MegaConstructBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("ScavBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 3.69178F, -3.60423F),
localAngles = new Vector3(292.1495F, 180F, 180F),
localScale = new Vector3(5.87727F, 5.87727F, 5.87727F)
                }
            ]);
        }

    }

    internal class EquipEliteUnstable : EquipFactory
    {
        protected override void LoadAssets(ref EquipmentDef equipmentDef)
        {
            equipmentDef = Assets.AssetBundles.Elites.LoadAsset<EquipmentDef>("eqEliteUnstable");
            displayPrefab = Assets.AssetBundles.Elites.LoadAsset<GameObject>("DisplayEliteUnstable");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Elites.Unstable.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Elites.LoadAsset<Material>("matEliteUnstablePickup");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Elites.LoadAsset<Material>("matAffixUnstableDonut");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Elites.LoadAsset<Material>("matAffixUnstableSpark");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.00111F, 0.20304F, 0.22431F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.2F, 0.2F, 0.2F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.21194F, 0.15977F),
localAngles = new Vector3(346.1687F, 0F, 0F),
localScale = new Vector3(0.27245F, 0.27245F, 0.27245F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.05291F, 0.13538F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.14453F, 0.14453F, 0.14453F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.3538F, 3.33699F, -1.16504F),
localAngles = new Vector3(50.79097F, 0F, 0F),
localScale = new Vector3(1.26252F, 1.26252F, 1.26252F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, -0.05872F, 0.14736F),
localAngles = new Vector3(13.83291F, 0F, 0F),
localScale = new Vector3(0.15279F, 0.15279F, 0.15279F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Eye",
localPos = new Vector3(0F, 0.88838F, 0.00002F),
localAngles = new Vector3(270.7913F, 0F, 0F),
localScale = new Vector3(0.326F, 0.326F, 0.326F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, -0.02798F, 0.18771F),
localAngles = new Vector3(1.03669F, 0F, 0F),
localScale = new Vector3(0.14339F, 0.14339F, 0.14339F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, -0.00256F, 0.17038F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.17146F, 0.17146F, 0.17146F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.06078F, 0.18278F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.10804F, 0.10804F, 0.10804F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.03559F, 5.86937F, 0.43564F),
localAngles = new Vector3(79.33236F, 180F, 180F),
localScale = new Vector3(2.44671F, 2.44671F, 2.44671F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, -0.02379F, 0.22044F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.14401F, 0.14401F, 0.14401F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.06301F, 0.16037F),
localAngles = new Vector3(352.6674F, 0F, 0F),
localScale = new Vector3(0.10889F, 0.10889F, 0.10889F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0F, 0F),
localAngles = new Vector3(292.0145F, 180F, 180F),
localScale = new Vector3(0.37724F, 0.37724F, 0.37724F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.08457F, 0.18636F),
localAngles = new Vector3(0.71976F, 0F, 0F),
localScale = new Vector3(0.20742F, 0.20742F, 0.20742F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.18804F, 0.24978F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.25982F, 0.25982F, 0.25982F)
                }
            ]);

            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.19096F, 0.25985F, -0.0061F),
localAngles = new Vector3(271.1922F, 0F, 0F),
localScale = new Vector3(0.18365F, 0.18365F, 0.18365F)
                }
            ]);
            itemDisplayRules.Add("EngiTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiWalkerTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EquipmentDroneBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("LunarExploderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleCore",
localPos = new Vector3(0F, 0.45F, 0F),
localAngles = new Vector3(270.0198F, 0F, 0F),
localScale = new Vector3(1.25504F, 1.25504F, 1.53065F)
                }
            ]);
            itemDisplayRules.Add("LunarWispBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MaskBase",
localPos = new Vector3(0F, -1.09F, 4.14F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(2.7955F, 2.7955F, 2.7955F)
                }
            ]);
            itemDisplayRules.Add("LunarGolemBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.299F, 1.51F),
localAngles = new Vector3(0.00002F, -0.00001F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
        }

    }
    internal class EquipEliteTar : EquipFactory
    {
        protected override void LoadAssets(ref EquipmentDef equipmentDef)
        {
            equipmentDef = Assets.AssetBundles.Elites.LoadAsset<EquipmentDef>("eqEliteTar");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Elites.Tar.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            
        }
        protected override void RegisterLanguageTokens()
        {

        }

    }

}
