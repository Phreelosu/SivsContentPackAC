using HarmonyLib;
using HG;
using R2API;
using RoR2;
using RoR2.Orbs;
using RoR2.Projectile;
using RoR2.Stats;
using SivsContentPack.Config;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

namespace SivsContentPack.Items
{
    internal class HealOnLevelUp : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("HealOnLevelUp");
            itemDef.tags.AddToArray<ItemTag>(ItemTag.CanBeTemporary);
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matHealOnLevelUp");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_HEALONLEVELUP_NAME", "Celebratory Cupcake");
            LanguageAPI.Add("ITEM_HEALONLEVELUP_PICKUP", "Heal and become briefly invincible on level up.");
            LanguageAPI.Add("ITEM_HEALONLEVELUP_DESCRIPTION", "Upon leveling up, heal for <style=cIsHealing>40%</style> <style=cStack>(+10% per stack)</style> max health and become <style=cIsUtility>invulnerable</style> for <style=cIsDamage>1 second.</style>");
            //LanguageAPI.Add("ITEM_HEALONLEVELUP_LORE", "");
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
            On.RoR2.CharacterBody.OnLevelUp += CharacterBody_OnLevelUp;
        }

        private void CharacterBody_OnLevelUp(On.RoR2.CharacterBody.orig_OnLevelUp orig, CharacterBody self)
        {
            orig.Invoke(self);
            if (self != null)
            {
                Inventory i = self.inventory;
                if (i != null)
                {
                    int itemCount = i.GetItemCountEffective(Content.Items.HealOnLevelUp);
                    if (itemCount > 0)
                    {
                        EffectManager.SpawnEffect(Content.Effects.CupcakeProc.prefab, new EffectData
                        {
                            origin = self.corePosition,
                            rotation = self.transform.rotation,
                            start = self.corePosition
                        }, true);
                        HealthComponent hc = self.GetComponent<HealthComponent>();
                        if(hc != null)
                        {
                            float healAmount = Util.GetStackingBehavior(Configuration.Items.HealOnLevelUp.healPercentage, Configuration.Items.HealOnLevelUp.healPercentStack, itemCount);
                            self.healthComponent.HealFraction(healAmount, new ProcChainMask());
                        }
                        self.AddTimedBuff(RoR2Content.Buffs.Immune, Configuration.Items.HealOnLevelUp.invincibilityDuration);
                    }
                }
            }
        }
    }

    internal class TeleporterArmorZone : ItemFactory
    {
        public static GameObject armorZone;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("TeleporterArmorZone");
            armorZone = Assets.AssetBundles.Items.LoadAsset<GameObject>("ArmorZone");
            itemDef.tags.AddToArray<ItemTag>(ItemTag.CanBeTemporary);
        }

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.TeleporterArmorZone.enabled.Value; 
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matPoliceTape");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matArmorZone");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matDustOpaque");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matHumanChainlink");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_TELEPORTERARMORZONE_NAME", "Police Tape");
            LanguageAPI.Add("ITEM_TELEPORTERARMORZONE_PICKUP", "???");
            LanguageAPI.Add("ITEM_TELEPORTERARMORZONE_DESCRIPTION", "???");
            //LanguageAPI.Add("ITEM_TELEPORTERARMORZONE_LORE", "");
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
            On.RoR2.HoldoutZoneController.Awake += HoldoutZoneController_Awake;
        }

        private void HoldoutZoneController_Awake(On.RoR2.HoldoutZoneController.orig_Awake orig, HoldoutZoneController self)
        {
            orig.Invoke(self);
            HoldOutArmorZoneController hoazc = self.gameObject.AddComponent<HoldOutArmorZoneController>();
            hoazc.holdOutZone = self;
        }

        public class HoldOutArmorZoneController : MonoBehaviour
        {
            public HoldoutZoneController holdOutZone;
            private TeamIndex teamIndex
            {
                get
                {
                    return holdOutZone.chargingTeam;
                }
            }
            private bool isCharging
            {
                get
                {
                    return holdOutZone.charge > 0;
                }
            }
            public static float armorBonus
            {
                get
                {
                    return Util.GetStackingBehavior(Configuration.Items.TeleporterArmorZone.armorBonus, Configuration.Items.TeleporterArmorZone.armorBonusStack, combinedStacks);
                }
            }

            public static int combinedStacks;

            public GameObject effectInstance;

            private void OnDisable()
            {
                if (effectInstance != null)
                {
                    GameObject.Destroy(effectInstance);
                }
            }

            private void Start()
            {
                TeamFilter tf = this.GetComponent<TeamFilter>();
                if (tf != null)
                {
                    tf.teamIndex = holdOutZone.chargingTeam;
                }
            }
            private void FixedUpdate()
            {

                combinedStacks = 0;
                List<CharacterBody> cbodies = CharacterBody.instancesList;
                foreach (var cb in cbodies)
                {
                    if (cb != null)
                    {
                        TeamComponent tc = cb.teamComponent;
                        if (tc != null)
                        {
                            if (tc.teamIndex == holdOutZone.chargingTeam)
                            {
                                Inventory i = cb.inventory;
                                if (i != null)
                                {
                                    int itemStack = i.GetItemCountEffective(Content.Items.TeleporterArmorZone);
                                    combinedStacks += itemStack;
                                }
                            }
                        }
                    }
                }
                if (isCharging)
                {
                    if(combinedStacks > 0)
                    {
                        if(!effectInstance)
                        {
                            effectInstance = GameObject.Instantiate(TeleporterArmorZone.armorZone, this.transform.position, this.transform.rotation, this.transform);
                            TeamFilter filter = armorZone.GetComponent<TeamFilter>();
                            if(filter != null)
                            {
                                filter.teamIndex = holdOutZone.chargingTeam;
                                Debug.LogFormat("Team Index: {0}", filter.teamIndex);
                            }
                            BuffWard bw = armorZone.gameObject.GetComponent<BuffWard>();
                            bw.buffDef = Content.Buffs.ArmorZone;
                        }
                    }
                }
            }
        }

    }

    internal class ProjectileBoost : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ProjectileBoost");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayThruster");
            itemDef.tags.AddToArray<ItemTag>(ItemTag.CanBeTemporary);
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.ProjectileBoost.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matTrimsheetThruster");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matThrusterExhaust");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_PROJECTILEBOOST_NAME", "???");
            LanguageAPI.Add("ITEM_PROJECTILEBOOST_PICKUP", "???");
            LanguageAPI.Add("ITEM_PROJECTILEBOOST_DESCRIPTION", "???");
            //LanguageAPI.Add("ITEM_PROJECTILEBOOST_LORE", "");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LeftJet",
localPos = new Vector3(-0.00002F, 0.01164F, 0.0426F),
localAngles = new Vector3(270.1342F, 0F, 0F),
localScale = new Vector3(0.31203F, 0.31203F, 0.31203F)
                },
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "RightJet",
localPos = new Vector3(0.00836F, -0.00198F, 0.04669F),
localAngles = new Vector3(275.8848F, 0F, 0F),
localScale = new Vector3(0.31203F, 0.31203F, 0.31203F)
                },
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmR",
localPos = new Vector3(0.0395F, -0.03992F, -0.01561F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.21017F, 0.21017F, 0.21017F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleShotgun",
localPos = new Vector3(-0.03462F, -0.01274F, 0.05433F),
localAngles = new Vector3(271.2895F, 0F, 0F),
localScale = new Vector3(0.19046F, 0.19046F, 0.19046F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.00001F, 0.53345F, -2.15404F),
localAngles = new Vector3(89.53228F, 0F, 0F),
localScale = new Vector3(3.39047F, 3.39047F, 3.39047F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.11805F, -0.19484F, -0.23754F),
localAngles = new Vector3(7.59871F, 0F, 0F),
localScale = new Vector3(0.60032F, 0.60032F, 0.60032F)
                },
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.1021F, -0.18695F, -0.25644F),
localAngles = new Vector3(6.8538F, 0F, 0F),
localScale = new Vector3(0.60032F, 0.60032F, 0.60032F)
                },
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "WeaponPlatform",
localPos = new Vector3(0.00002F, -0.49159F, 0.40959F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.32351F, 0.32351F, 0.32351F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MechUpperArmL",
localPos = new Vector3(0.00002F, 0.11845F, -0.14474F),
localAngles = new Vector3(79.75172F, 180F, 180F),
localScale = new Vector3(0.2945F, 0.2945F, 0.2945F)
                },
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MechUpperArmR",
localPos = new Vector3(-0.00001F, 0.11432F, -0.14213F),
localAngles = new Vector3(83.70144F, 180F, 180F),
localScale = new Vector3(0.2945F, 0.2945F, 0.2945F)
                },
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0F, 0.18542F, -0.27645F),
localAngles = new Vector3(76.12807F, 180F, 180F),
localScale = new Vector3(0.36487F, 0.36487F, 0.36487F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.11414F, 0.26106F, -0.26454F),
localAngles = new Vector3(78.98817F, 180F, 180F),
localScale = new Vector3(0.38264F, 0.38264F, 0.38264F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(1.26336F, 2.18413F, 1.27027F),
localAngles = new Vector3(281.0941F, 208.9451F, 190.0469F),
localScale = new Vector3(4.03633F, 4.03633F, 4.03633F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleRight",
localPos = new Vector3(0F, 0F, 0F),
localAngles = new Vector3(271.4663F, 0F, 0F),
localScale = new Vector3(0.81474F, 0.81474F, 0.81474F)
                },
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleLeft",
localPos = new Vector3(0F, -0.00148F, 0.04156F),
localAngles = new Vector3(272.7122F, 180F, 180F),
localScale = new Vector3(0.81474F, 0.81474F, 0.81474F)
                },
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Backpack",
localPos = new Vector3(0.09441F, -0.48779F, 0.00001F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.46232F, 0.46232F, 0.46232F)
                },
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Backpack",
localPos = new Vector3(-0.13963F, -0.48844F, 0.00001F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.46232F, 0.46232F, 0.46232F)
                },
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.14627F, 0.05322F, -0.25555F),
localAngles = new Vector3(81.3965F, -0.00001F, 7.19979F),
localScale = new Vector3(0.3487F, 0.3487F, 0.3487F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pack",
localPos = new Vector3(0.25578F, -0.36556F, -0.16726F),
localAngles = new Vector3(357.97F, 357.9467F, 45.34506F),
localScale = new Vector3(0.49301F, 0.49301F, 0.49301F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(-0.19709F, 0.21922F, -0.08073F),
localAngles = new Vector3(358.652F, 330.6453F, 269.7079F),
localScale = new Vector3(0.59184F, 0.59184F, 0.59184F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.34642F, -0.34988F, 0.002F),
localAngles = new Vector3(88.42554F, 338.5451F, 68.9141F),
localScale = new Vector3(0.57956F, 0.57956F, 0.57956F)
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
            On.RoR2.Projectile.ProjectileController.Start += ProjectileController_Start;
        }

        private void ProjectileController_Start(On.RoR2.Projectile.ProjectileController.orig_Start orig, ProjectileController self)
        {
            orig.Invoke(self);
            GameObject owner = self.owner;
            if (owner != null)
            {
                CharacterBody cb = owner.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    Inventory i = cb.inventory;
                    if (i != null)
                    {
                        int itemCount = i.GetItemCountEffective(Content.Items.ProjectileBoost);
                        if (itemCount > 0)
                        {
                            float speedMod = (1 + Util.GetStackingBehavior(Configuration.Items.ProjectileBoost.speedBoost, Configuration.Items.ProjectileBoost.speedBoostStack, itemCount));
                            MissileController mc = self.gameObject.GetComponent<MissileController>();
                            if(mc != null)
                            {
                                mc.maxVelocity *= speedMod;
                                mc.acceleration *= speedMod;
                            }
                            ProjectileSimple ps = self.gameObject.GetComponent<ProjectileSimple>();
                            if (ps != null)
                            {
                                ps.desiredForwardSpeed *= speedMod;
                            }
                            CleaverProjectile cp = self.gameObject.GetComponent<CleaverProjectile>();
                            if(cp != null)
                            {
                                cp.travelSpeed *= speedMod;
                            }
                            SoulSpiralProjectile ssp = self.gameObject.GetComponent<SoulSpiralProjectile>();
                            if(ssp != null)
                            {
                                ssp.degreesPerSecond *= speedMod;
                            }
                            BoomerangProjectile bp = self.gameObject.GetComponent<BoomerangProjectile>();
                            if (bp != null)
                            {
                                bp.travelSpeed *= speedMod;
                            }
                            ProjectileDamage pd = self.gameObject.GetComponent<ProjectileDamage>();
                            if (pd != null)
                            {
                                if (pd.crit)
                                {
                                    float damageModifier = 1 + (Util.GetStackingBehavior(Configuration.Items.ProjectileBoost.critDamageBonus, Configuration.Items.ProjectileBoost.critDamageBonusStack, itemCount));
                                    pd.damage *= damageModifier;
                                }
                            }
                            ProjectileSteerTowardTarget pstt = self.gameObject.GetComponent<ProjectileSteerTowardTarget>();
                            if(pstt != null)
                            {
                                pstt.rotationSpeed *= 1 + Configuration.Items.ProjectileBoost.trackingBoost;
                            }
                            
                        }
                    }
                }
            }
        }
    }

    internal class BulletsIntoLasers : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ProjectileBoost");
            Content.DamageTypes.ArmorPiercingLaser = R2API.DamageAPI.ReserveDamageType();
            itemDef.tags.AddToArray<ItemTag>(ItemTag.CanBeTemporary);
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.BulletsIntoLasers.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matTrimsheetThruster");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matThrusterExhaust");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            
        }
        protected override void Hooks()
        {
            On.RoR2.BulletAttack.Fire += BulletAttack_Fire;
            On.RoR2.HealthComponent.TakeDamageProcess += HealthComponent_TakeDamageProcess;
        }

        private void HealthComponent_TakeDamageProcess(On.RoR2.HealthComponent.orig_TakeDamageProcess orig, HealthComponent self, DamageInfo damageInfo)
        {
            if(DamageAPI.HasModdedDamageType(damageInfo, Content.DamageTypes.ArmorPiercingLaser))
            {
                GameObject attacker = damageInfo.attacker;
                if (attacker != null)
                {
                    CharacterBody cb = attacker.GetComponent<CharacterBody>();
                    if (cb != null)
                    {
                        Inventory i = cb.inventory;
                        if (i != null)
                        {
                            int itemCount = i.GetItemCountEffective(Content.Items.BulletsIntoLasers);
                            if (itemCount > 0)
                            {
                                float armorToIgnore = Util.GetStackingBehavior(Configuration.Items.BulletsIntoLasers.armorPiercing, Configuration.Items.BulletsIntoLasers.armorPiercingStack, itemCount);
                                if (armorToIgnore > 0)
                                {
                                    CharacterBody vb = self.body;
                                    if(vb != null)
                                    {
                                        damageInfo.damage = Util.GetUnarmoredDamage(damageInfo.damage, vb.armor, armorToIgnore);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            orig.Invoke(self, damageInfo);
        }

        private void BulletAttack_Fire(On.RoR2.BulletAttack.orig_Fire orig, BulletAttack self)
        {
            GameObject owner = self.owner;
            if (owner != null)
            {
                CharacterBody cb = owner.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    Inventory i = cb.inventory;
                    if (i != null)
                    {
                        int itemCount = i.GetItemCountEffective(Content.Items.BulletsIntoLasers);
                        if (itemCount > 0)
                        {
                            self.falloffModel = BulletAttack.FalloffModel.None;
                            self._maxDistance += Util.GetStackingBehavior(Configuration.Items.BulletsIntoLasers.rangeBoost, Configuration.Items.BulletsIntoLasers.rangeBoostStack, itemCount);
                            if (!((self.damageType & DamageType.BypassArmor) > 0UL))
                            {
                                self.AddModdedDamageType(Content.DamageTypes.ArmorPiercingLaser);
                            }
                        }
                    }
                }
            }
            orig.Invoke(self);
        }
    }

    internal class RevengeDamageBonus : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("RevengeDamageBonus");
            itemDef.tags.AddToArray<ItemTag>(ItemTag.CanBeTemporary);
        }
        protected override void HandleMaterials()
        {

        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_REVENGEDAMAGEBONUS_NAME", "Know Thy Enemy");
            LanguageAPI.Add("ITEM_REVENGEDAMAGEBONUS_PICKUP", "???");
            LanguageAPI.Add("ITEM_REVENGEDAMAGEBONUS_DESCRIPTION", "???");
            //LanguageAPI.Add("ITEM_REVENGEDAMAGEBONUS_LORE", "");
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

        }



    }

    internal class UpgradeChests : ItemFactory
    {
        /// <summary>
        /// A dictionary of object names and their addressable addresses. Used to load objects so they can be compatible with UpgradeChests.
        /// </summary>
        public static Dictionary<string, string> objectToAddressableStringDictionary = new Dictionary<string, string>()
        {
            {"Chest1","RoR2/Base/Chest1/Chest1.prefab"},
            {"Chest2","RoR2/Base/Chest2/Chest2.prefab"},
            {"GoldChest","RoR2/Base/GoldChest/GoldChest.prefab"},
            {"CategoryChestDamage", "RoR2/Base/CategoryChest/CategoryChestDamage.prefab"},
            {"CategoryChestHealing", "RoR2/Base/CategoryChest/CategoryChestHealing.prefab"},
            {"CategoryChestUtility", "RoR2/Base/CategoryChest/CategoryChestUtility.prefab"},
            {"CategoryChest2Damage Variant", "RoR2/DLC1/CategoryChest2/CategoryChest2Damage Variant.prefab"},
            {"CategoryChest2Healing Variant", "RoR2/DLC1/CategoryChest2/CategoryChest2Healing Variant.prefab"},
            {"CategoryChest2Utility Variant", "RoR2/DLC1/CategoryChest2/CategoryChest2Utility Variant.prefab"},
            {"TripleShop","RoR2/Base/TripleShop/TripleShop.prefab"},
            {"TripleShopLarge","RoR2/Base/TripleShop/TripleShopLarge.prefab"},
            {"Duplicator","RoR2/Base/Duplicator/Duplicator.prefab"},
            {"DuplicatorLarge","RoR2/Base/Duplicator/DuplicatorLarge.prefab"},
            {"DuplicatorMilitary","RoR2/Base/Duplicator/DuplicatorMilitary.prefab"},
            {"DuplicatorWild","RoR2/Base/Duplicator/DuplicatorWild.prefab"},
        };
        /// <summary>
        /// A dictionary that pairs a name and an object. Used to locate objects when upgrading - an object must have an entry in this dictionary in order to be upgraded.
        /// </summary>
        public static Dictionary<string, GameObject> objectToAddressableDictionary = new Dictionary<string, GameObject>();

        /// <summary>
        /// A dictionary of two strings, each corresponding to an object. The key is the object to upgrade, and the value is the object to upgrade to. If an object does not have an entry in this dictionary, it will not be upgraded. The object must also have an entry in the objectToAddressableDictionary.
        /// </summary>
        public static Dictionary<string, string> upgradeAtlas = new Dictionary<string, string>()
        {
            {"Chest1", "Chest2"},
            {"Chest2", "GoldChest"},
            {"CategoryChestDamage", "CategoryChest2Damage Variant"},
            {"CategoryChestHealing", "CategoryChest2Healing Variant"},
            {"CategoryChestUtility", "CategoryChest2Utility Variant"},
            {"TripleShop", "TripleShopLarge"},
            {"Duplicator", "DuplicatorLarge"},
            {"DuplicatorLarge", "DuplicatorMilitary"},
            {"DuplicatorMilitary", "DuplicatorWild"},
        };

        public static GameObject upgradeEffectPrefab;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("UpgradeChests");
            this.displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayEnvelope");
            upgradeEffectPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("UpgradeEffect");
            LoadObjects();
        }
        private void LoadObjects()
        {
            Debug.LogFormat("UpgradeChests: Attempting to load upgradable assets...");
            foreach (var item in objectToAddressableStringDictionary)
            {
                GameObject v = Addressables.LoadAssetAsync<GameObject>(item.Value).WaitForCompletion();
                if (v != null) {
                    Debug.LogFormat(" - Loaded object {0} and filed under key {1}.", v, item.Key);
                    objectToAddressableDictionary.Add(item.Key, v);
                }
            }
            Debug.LogFormat("UpgradeChests: loaded {0} upgradable assets.", objectToAddressableDictionary.Count);
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matEnvelope");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matUpgradeEffect");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSquareParticle");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.UpgradeChests.enabled.Value;
        }
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.11167F, 0.12206F, 0.06454F),
localAngles = new Vector3(0F, 51.91463F, 184.6302F),
localScale = new Vector3(0.22371F, 0.22371F, 0.22371F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CalfL",
localPos = new Vector3(-0.07665F, 0.31416F, 0.02395F),
localAngles = new Vector3(354.8383F, 254.1212F, 177.0662F),
localScale = new Vector3(0.29391F, 0.29391F, 0.29391F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CalfR",
localPos = new Vector3(0.00001F, 0.26936F, -0.05826F),
localAngles = new Vector3(359.2202F, 180F, 180F),
localScale = new Vector3(0.25305F, 0.25305F, 0.25305F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Hip",
localPos = new Vector3(1.42753F, 0.93629F, -0.05693F),
localAngles = new Vector3(0.17203F, 87.83874F, 178.5361F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.07038F, 0.09022F, 0.12575F),
localAngles = new Vector3(0F, 302.9455F, 185.7873F),
localScale = new Vector3(0.14338F, 0.14338F, 0.14338F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CalfBackL",
localPos = new Vector3(0.06638F, 0.32585F, 0.00119F),
localAngles = new Vector3(6.3405F, 90.76689F, 276.9109F),
localScale = new Vector3(0.25913F, 0.25913F, 0.25913F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.11792F, 0.12761F, 0.10971F),
localAngles = new Vector3(15.39945F, 65.74738F, 183.4339F),
localScale = new Vector3(0.23884F, 0.23884F, 0.23884F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pelvis",
localPos = new Vector3(-0.20301F, 0.21879F, 0.06011F),
localAngles = new Vector3(19.02172F, 309.2261F, 181.078F),
localScale = new Vector3(0.32478F, 0.32478F, 0.32478F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.17961F, 0.14365F, 0.15479F),
localAngles = new Vector3(0F, 329.2208F, 347.1048F),
localScale = new Vector3(0.22084F, 0.22084F, 0.22084F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(1.46223F, 3.53348F, -0.60471F),
localAngles = new Vector3(-0.00001F, 48.65088F, 291.0734F),
localScale = new Vector3(1.54876F, 1.54876F, 1.54876F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.17807F, 0.03306F, -0.04138F),
localAngles = new Vector3(359.5154F, 276.8185F, 185.9248F),
localScale = new Vector3(0.21218F, 0.21218F, 0.21218F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Backpack",
localPos = new Vector3(0.14006F, -0.49953F, -0.12271F),
localAngles = new Vector3(352.8854F, 177.0545F, 0F),
localScale = new Vector3(0.17799F, 0.17799F, 0.17799F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.00088F, 0.102F, -0.11735F),
localAngles = new Vector3(2.74388F, 177.1254F, 164.115F),
localScale = new Vector3(0.25831F, 0.25831F, 0.25831F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pack",
localPos = new Vector3(0.11165F, -0.13988F, -0.33001F),
localAngles = new Vector3(351.2787F, 161.2592F, 312.7365F),
localScale = new Vector3(0.15792F, 0.15792F, 0.15792F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ClavL",
localPos = new Vector3(0.07758F, 0.94305F, -0.20603F),
localAngles = new Vector3(299.2998F, 130.1654F, 225.9361F),
localScale = new Vector3(0.20903F, 0.20903F, 0.20903F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.08487F, -0.39813F, 0.1513F),
localAngles = new Vector3(88.4712F, -0.00038F, 74.2F),
localScale = new Vector3(0.43586F, 0.43586F, 0.43586F)
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
            SceneDirector.onPostPopulateSceneServer += SceneDirector_onPostPopulateSceneServer;
            On.RoR2.ChestBehavior.Open += ChestBehavior_Open;
        }

        private void ChestBehavior_Open(On.RoR2.ChestBehavior.orig_Open orig, ChestBehavior self)
        {
            orig.Invoke(self);
            Transform t = self.transform.Find("UpgradeEffect(Clone)");
            if (t != null)
            {
                t.gameObject.SetActive(false);
            }
        }

        private void SceneDirector_onPostPopulateSceneServer(SceneDirector obj)
        {
            if (SceneInfo.instance.countsAsStage || SceneInfo.instance.sceneDef.allowItemsToSpawnObjects)
            {
                if (RunArtifactManager.instance.IsArtifactEnabled(RoR2Content.Artifacts.sacrificeArtifactDef))
                {

                    Debug.LogFormat("UpgradeChests: Sacrifice is active, canceling operation.");
                    return;
                }
                Debug.LogFormat("UpgradeChests: beginning operation.");
                int num = 0; //players with lawsuit (upgrade 1 chest per)
                int num2 = 0; //additional chests to upgrade
                Xoroshiro128Plus xoroshiro128Plus = new Xoroshiro128Plus(obj.rng.nextUlong);
                using (IEnumerator<CharacterMaster> enumerator = CharacterMaster.readOnlyInstancesList.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        int itemCount = enumerator.Current.inventory.GetItemCountPermanent(Content.Items.UpgradeChests);
                        if (itemCount > 0)
                        {
                            num++;
                            int extraRolls = (int)Util.GetStackingBehavior(Configuration.Items.UpgradeChests.upgradeAmount, Configuration.Items.UpgradeChests.upgradeAmountStack, itemCount);
                            Debug.LogFormat("Master found with UpgradeChests. Beginning additional roll count ({0} additional rolls)...", extraRolls);
                            for (int i = 0; i < extraRolls; i++)
                            {
                                bool flag = RoR2.Util.CheckRoll(Configuration.Items.UpgradeChests.upgradeChance, enumerator.Current);
                                if (flag)
                                {
                                    num2++;
                                }
                            }
                            Debug.LogFormat("{0} additional rolls succeeded out of {1}.", num2, extraRolls);
                        }
                    }
                }
                Debug.LogFormat("Guaranteed Chests to Upgrade: {0}. Additional Chests to Upgrade: {1}.", num, num2);
                int total = num + num2;
                List<PurchaseInteraction> purchaseInteractions = PurchaseInteraction.FindObjectsOfType<PurchaseInteraction>().ToList<PurchaseInteraction>();

                purchaseInteractions.RemoveAll(pi =>
                {
                    string s = pi.gameObject.name.Replace("(Clone)", "");
                    if (!upgradeAtlas.ContainsKey(s))
                    {
                        return true;
                    }
                    string upgrade = upgradeAtlas[s];
                    if (objectToAddressableDictionary.ContainsKey(upgrade))
                    {
                        return false;
                    }
                    return true;
                });
                int num4 = 0;
                if(purchaseInteractions.Count <= 0)
                {
                    Debug.LogFormat("No valid interactables remaining. Aborting.");
                    return;
                }
                List<GameObject> objectsToUpgrade = new List<GameObject>();
                Xoroshiro128Plus xoroshiro128Plus2 = new Xoroshiro128Plus(obj.rng.nextUlong);
                for (int i = 0; i < total; i++)
                {
                    PurchaseInteraction pi = purchaseInteractions.First<PurchaseInteraction>();
                    if(pi != null)
                    {
                        Debug.LogFormat("- Selected object {0} for upgrading.", pi.gameObject);
                        objectsToUpgrade.Add(pi.gameObject);
                        purchaseInteractions.Remove(pi);
                    }
                }
                Debug.LogFormat("Upgrading {0} objects.", objectsToUpgrade.Count);
                foreach (var item in objectsToUpgrade)
                {
                    UpgradeObject(item);
                }
            }
        }

        private void UpgradeObject(GameObject obj)
        {
            string s = obj.gameObject.name.Replace("(Clone)", "");
            string upgrade = upgradeAtlas[s];
            if (objectToAddressableDictionary.ContainsKey(upgrade))
            {
                GameObject g = objectToAddressableDictionary[upgrade];
                Debug.LogFormat("- Located object {0}. Attempting to upgrade to {1}...", obj.gameObject.name, g.name);
                if (g != null)
                {
                    GameObject instance = GameObject.Instantiate(g, obj.transform.position, obj.transform.rotation);
                    if (NetworkServer.active)
                    {
                        NetworkServer.Spawn(instance);
                    }
                    PurchaseInteraction pi = instance.GetComponent<PurchaseInteraction>();
                    if (pi != null)
                    {
                        pi.Networkcost = Run.instance.GetDifficultyScaledCost(pi.cost);
                    }
                    Debug.LogFormat("- Successfully upgraded {0} to {1}.", obj.gameObject.name, instance.name);
                    GameObject effect = GameObject.Instantiate(upgradeEffectPrefab, instance.transform);
                    effect.transform.localPosition = Vector3.zero;
                    if (NetworkServer.active)
                    {
                        NetworkServer.Spawn(effect);
                    }
                    GameObject.Destroy(obj);
                }
            }
        }
    }

    internal class ExtraPrinterRoll : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ExtraPrinterRoll");
            itemDef.tags.AddToArray<ItemTag>(ItemTag.CanBeTemporary);
        }
        protected override void HandleMaterials()
        {

        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_???_NAME", "???");
            LanguageAPI.Add("ITEM_???_PICKUP", "???");
            LanguageAPI.Add("ITEM_???_DESCRIPTION", "???");
            //LanguageAPI.Add("ITEM_???_LORE", "");
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
            On.EntityStates.Duplicator.Duplicating.DropDroplet += Duplicating_DropDroplet;
        }

        private void Duplicating_DropDroplet(On.EntityStates.Duplicator.Duplicating.orig_DropDroplet orig, EntityStates.Duplicator.Duplicating self)
        {
            orig.Invoke(self);
        }
    }

    internal class DropYellowItemOnKill : ItemFactory
    {
        private static GameObject procEffect;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("DropYellowItemOnKill");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayMedal");
            procEffect = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/BossHunter/BossHunterKillEffect.prefab").WaitForCompletion();
            itemDef.tags.AddToArray<ItemTag>(ItemTag.CanBeTemporary);
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.DropYellowItemOnKill.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matPickupMedal");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matMedalGhost");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.12455F, 0.28143F, 0.2049F),
localAngles = new Vector3(339.9862F, 0F, 0F),
localScale = new Vector3(0.16051F, 0.16051F, 0.16051F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.09074F, 0.17997F, 0.15634F),
localAngles = new Vector3(323.3096F, 339.5457F, 0F),
localScale = new Vector3(0.2047F, 0.2047F, 0.2047F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.10705F, 0.27893F, 0.13992F),
localAngles = new Vector3(338.7798F, 340.7076F, 0F),
localScale = new Vector3(0.17408F, 0.17408F, 0.17408F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(1.61688F, 3.87124F, 0.05764F),
localAngles = new Vector3(304.9093F, 104.3496F, 58.47727F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.06246F, 0.14077F, 0.13942F),
localAngles = new Vector3(333.3145F, 349.8924F, 4.80872F),
localScale = new Vector3(0.16622F, 0.16622F, 0.16622F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Eye",
localPos = new Vector3(-0.13456F, 0.79523F, -0.12206F),
localAngles = new Vector3(334.9541F, 217.2406F, 150.3537F),
localScale = new Vector3(0.56901F, 0.56901F, 0.56901F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.13787F, 0.215F, 0.1715F),
localAngles = new Vector3(333.0914F, 351.1566F, 3.99408F),
localScale = new Vector3(0.13775F, 0.13775F, 0.13775F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.08982F, 0.12912F, 0.19821F),
localAngles = new Vector3(339.6862F, 349.1294F, 3.81417F),
localScale = new Vector3(0.19457F, 0.19457F, 0.19457F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.08944F, 0.25687F, 0.17682F),
localAngles = new Vector3(341.3586F, 350.351F, 1.69519F),
localScale = new Vector3(0.13208F, 0.13208F, 0.13208F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(-0.11107F, 3.9448F, 1.08491F),
localAngles = new Vector3(318.9929F, 0.41711F, 178.8255F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.09418F, 0.24827F, 0.27115F),
localAngles = new Vector3(346.3462F, 350.4664F, 2.27027F),
localScale = new Vector3(0.3124F, 0.3124F, 0.3124F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.10843F, 0.10016F, 0.15311F),
localAngles = new Vector3(347.6228F, 332.3511F, 0.34114F),
localScale = new Vector3(0.17503F, 0.17503F, 0.17503F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.09736F, 0.09788F, 0.19863F),
localAngles = new Vector3(347.7296F, 345.6589F, 0F),
localScale = new Vector3(0.13367F, 0.13367F, 0.13367F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.08297F, 0.18532F, 0.0536F),
localAngles = new Vector3(326.7997F, 352.0071F, 5.06089F),
localScale = new Vector3(0.08769F, 0.08769F, 0.08769F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.2646F, 0.17239F, 0.25897F),
localAngles = new Vector3(340.5397F, 342.499F, 4.17754F),
localScale = new Vector3(0.19982F, 0.19982F, 0.19982F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0.61253F, 0.18916F, 0.00253F),
localAngles = new Vector3(270.8316F, -0.00059F, 90.02129F),
localScale = new Vector3(0.23456F, 0.23456F, 0.23456F)
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
            On.RoR2.GlobalEventManager.OnCharacterDeath += GlobalEventManager_OnCharacterDeath;
        }
        private void GlobalEventManager_OnCharacterDeath(On.RoR2.GlobalEventManager.orig_OnCharacterDeath orig, GlobalEventManager self, DamageReport damageReport)
        {
            orig.Invoke(self, damageReport);
            CharacterBody attackerBody = damageReport.attackerBody;
            if (attackerBody != null)
            {
                Inventory i = attackerBody.inventory;
                ItemIndex from = Content.Items.DropYellowItemOnKill.itemIndex;
                ItemIndex to = Content.Items.DropYellowItemOnKillUsed.itemIndex;
                if (i != null)
                {
                    int itemCount = i.GetItemCountEffective(Content.Items.DropYellowItemOnKill);
                    if (itemCount > 0)
                    {
                        HealthComponent victim = damageReport.victim;
                        if (victim != null)
                        {
                            DeathRewards deathRewards = victim.GetComponent<DeathRewards>();
                            if(deathRewards != null)
                            {
                                if(deathRewards.bossDropTable != null)
                                {
                                    float chance = Configuration.Items.DropYellowItemOnKill.dropChance;
                                    bool flag = RoR2.Util.CheckRoll(chance, attackerBody.master);
                                    if (flag)
                                    {
                                        Vector3 vector = victim.body.mainHurtBox.transform ? victim.body.mainHurtBox.transform.position : UnityEngine.Vector3.zero;
                                        Vector3 normalized = (vector - attackerBody.corePosition).normalized;
                                        PickupDropletController.CreatePickupDroplet(deathRewards.bossDropTable.GeneratePickup(Run.instance.bossRewardRng), vector, normalized * 15f);
                                        Quaternion rotation = RoR2.Util.QuaternionSafeLookRotation(normalized, Vector3.up);
                                        EffectManager.SpawnEffect(procEffect, new EffectData
                                        {
                                            origin = vector,
                                            rotation = rotation
                                        }, true);
                                        Inventory.ItemTransformation itemTransformation = new Inventory.ItemTransformation
                                        {
                                            originalItemIndex = from,
                                            newItemIndex = to
                                        };

                                        if (itemTransformation.TryTake(i, out Inventory.ItemTransformation.TakeResult takeResult))
                                        {
                                            takeResult.GiveTakenItem(i, itemTransformation.newItemIndex);
                                        }
                                        /*Inventory.ItemTransformation transform = new Inventory.ItemTransformation
                                        {
                                            originalItemIndex = from,
                                            newItemIndex = to,
                                            minToTransform = 1,
                                            maxToTransform = 1,
                                        };*/
                                        //i.RemoveItem(Content.Items.DropYellowItemOnKill, 1);
                                        //i.GiveItem(Content.Items.DropYellowItemOnKillUsed, 1);
                                        CharacterMasterNotificationQueue.PushItemTransformNotification(attackerBody.master, Content.Items.DropYellowItemOnKill.itemIndex, Content.Items.DropYellowItemOnKillUsed.itemIndex, CharacterMasterNotificationQueue.TransformationType.Default);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    internal class DropYellowItemOnKillConsumed : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("DropYellowItemOnKillUsed");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayMedalUsed");
            itemDef.tags.AddToArray<ItemTag>(ItemTag.CanBeTemporary);
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.DropYellowItemOnKill.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matMedalUsed");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.12455F, 0.28143F, 0.2049F),
localAngles = new Vector3(339.9862F, 0F, 0F),
localScale = new Vector3(0.16051F, 0.16051F, 0.16051F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.09074F, 0.17997F, 0.15634F),
localAngles = new Vector3(323.3096F, 339.5457F, 0F),
localScale = new Vector3(0.2047F, 0.2047F, 0.2047F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.10705F, 0.27893F, 0.13992F),
localAngles = new Vector3(338.7798F, 340.7076F, 0F),
localScale = new Vector3(0.17408F, 0.17408F, 0.17408F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(1.61688F, 3.87124F, 0.05764F),
localAngles = new Vector3(304.9093F, 104.3496F, 58.47727F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.06246F, 0.14077F, 0.13942F),
localAngles = new Vector3(333.3145F, 349.8924F, 4.80872F),
localScale = new Vector3(0.16622F, 0.16622F, 0.16622F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Eye",
localPos = new Vector3(-0.13456F, 0.79523F, -0.12206F),
localAngles = new Vector3(334.9541F, 217.2406F, 150.3537F),
localScale = new Vector3(0.56901F, 0.56901F, 0.56901F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.13787F, 0.215F, 0.1715F),
localAngles = new Vector3(333.0914F, 351.1566F, 3.99408F),
localScale = new Vector3(0.13775F, 0.13775F, 0.13775F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.08982F, 0.12912F, 0.19821F),
localAngles = new Vector3(339.6862F, 349.1294F, 3.81417F),
localScale = new Vector3(0.19457F, 0.19457F, 0.19457F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.08944F, 0.25687F, 0.17682F),
localAngles = new Vector3(341.3586F, 350.351F, 1.69519F),
localScale = new Vector3(0.13208F, 0.13208F, 0.13208F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(-0.11107F, 3.9448F, 1.08491F),
localAngles = new Vector3(318.9929F, 0.41711F, 178.8255F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.09418F, 0.24827F, 0.27115F),
localAngles = new Vector3(346.3462F, 350.4664F, 2.27027F),
localScale = new Vector3(0.3124F, 0.3124F, 0.3124F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.10843F, 0.10016F, 0.15311F),
localAngles = new Vector3(347.6228F, 332.3511F, 0.34114F),
localScale = new Vector3(0.17503F, 0.17503F, 0.17503F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.09736F, 0.09788F, 0.19863F),
localAngles = new Vector3(347.7296F, 345.6589F, 0F),
localScale = new Vector3(0.13367F, 0.13367F, 0.13367F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.08297F, 0.18532F, 0.0536F),
localAngles = new Vector3(326.7997F, 352.0071F, 5.06089F),
localScale = new Vector3(0.08769F, 0.08769F, 0.08769F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.2646F, 0.17239F, 0.25897F),
localAngles = new Vector3(340.5397F, 342.499F, 4.17754F),
localScale = new Vector3(0.19982F, 0.19982F, 0.19982F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0.61253F, 0.18916F, 0.00253F),
localAngles = new Vector3(270.8316F, -0.00059F, 90.02129F),
localScale = new Vector3(0.23456F, 0.23456F, 0.23456F)
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
            
        }
    }

    internal class GoldIdol : ItemFactory
    {
        private static InteractableSpawnCard iscGoldShrine;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("GoldIdol");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayGoldIdol");
            iscGoldShrine = Addressables.LoadAssetAsync<InteractableSpawnCard>("RoR2/Base/ShrineGoldshoresAccess/iscShrineGoldshoresAccess.asset").WaitForCompletion();
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.GoldIdol.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matGoldIdol");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matRuneGold");
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
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(-0.00166F, 0.00826F, 0.10787F),
localAngles = new Vector3(27.76179F, 6.07127F, 192.8626F),
localScale = new Vector3(0.11519F, 0.11519F, 0.11519F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.00001F, 0.178F, -0.07595F),
localAngles = new Vector3(3.34936F, 200.7582F, 181.4459F),
localScale = new Vector3(0.11741F, 0.11741F, 0.11741F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CalfL",
localPos = new Vector3(0F, 0.28566F, -0.09032F),
localAngles = new Vector3(17.46853F, 180F, 180F),
localScale = new Vector3(0.13211F, 0.13211F, 0.13211F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-1.93357F, 2.94173F, 2.50912F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.10536F, 0.29271F, -0.18523F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.10516F, 0.10516F, 0.10516F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "FlowerBase",
localPos = new Vector3(-0.46789F, 0.08504F, 0.28068F),
localAngles = new Vector3(0F, 322.0351F, 0F),
localScale = new Vector3(0.17262F, 0.17262F, 0.17262F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0F, 0.11159F, 0.20476F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.12002F, 0.12002F, 0.12002F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.19477F, -0.00002F, -0.00001F),
localAngles = new Vector3(35.7488F, 269.587F, 179.9395F),
localScale = new Vector3(0.11455F, 0.11455F, 0.11455F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CalfR",
localPos = new Vector3(0.08526F, 0.24001F, 0.02845F),
localAngles = new Vector3(12.61965F, 83.81758F, 168.7667F),
localScale = new Vector3(0.1343F, 0.1343F, 0.1343F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.00314F, 0.01981F, -2.46361F),
localAngles = new Vector3(347.4316F, 182.014F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleLeft",
localPos = new Vector3(0.20253F, 0.07609F, -0.1747F),
localAngles = new Vector3(11.81477F, 94.0451F, 185.1928F),
localScale = new Vector3(0.11894F, 0.11894F, 0.11894F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.05264F, 0.10365F, -0.00176F),
localAngles = new Vector3(20.4247F, 265.223F, 180.7889F),
localScale = new Vector3(0.05534F, 0.05534F, 0.05534F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.1039F, -0.05376F, -0.20592F),
localAngles = new Vector3(5.48042F, 198.2242F, 334.0793F),
localScale = new Vector3(0.11593F, 0.11593F, 0.11593F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pack",
localPos = new Vector3(0.02622F, -0.08444F, -0.31422F),
localAngles = new Vector3(4.28555F, 171.3484F, 23.89683F),
localScale = new Vector3(0.06692F, 0.06692F, 0.06692F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ClavR",
localPos = new Vector3(-0.09915F, 0.5819F, 0.21668F),
localAngles = new Vector3(5.65681F, 76.6915F, 87.16519F),
localScale = new Vector3(0.14977F, 0.14977F, 0.14977F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "OvenDoor",
localPos = new Vector3(-0.20776F, 0F, 0.09414F),
localAngles = new Vector3(339.9871F, 0F, 0F),
localScale = new Vector3(0.19817F, 0.19817F, 0.19817F)
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
            On.RoR2.GoldshoresMissionController.SpawnBeacons += GoldshoresMissionController_SpawnBeacons;
            SceneDirector.onPostPopulateSceneServer += SceneDirector_onPostPopulateSceneServer;
        }

        private void SceneDirector_onPostPopulateSceneServer(SceneDirector obj)
        {
            if (SceneInfo.instance.countsAsStage || SceneInfo.instance.sceneDef.allowItemsToSpawnObjects)
            {
                
                bool flag = false;
                Xoroshiro128Plus xoroshiro128Plus = new Xoroshiro128Plus(obj.rng.nextUlong);
                using (IEnumerator<CharacterMaster> enumerator = CharacterMaster.readOnlyInstancesList.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        int itemCount = enumerator.Current.inventory.GetItemCountEffective(Content.Items.GoldIdol);
                        if (itemCount > 0)
                        {
                            flag = true;
                        }
                    }
                }
                if (flag)
                {
                    GameObject goldShrine = DirectorCore.instance.TrySpawnObject(new DirectorSpawnRequest(iscGoldShrine, new DirectorPlacementRule
                    {
                        placementMode = DirectorPlacementRule.PlacementMode.Random
                    }, xoroshiro128Plus));
                    if (goldShrine != null)
                    {
                        PurchaseInteraction pi = goldShrine.GetComponent<PurchaseInteraction>();
                        if (pi != null)
                        {
                            pi.Networkcost = Run.instance.GetDifficultyScaledCost(pi.cost);
                        }
                    }
                }
            }
        }

        private void GoldshoresMissionController_SpawnBeacons(On.RoR2.GoldshoresMissionController.orig_SpawnBeacons orig, GoldshoresMissionController self)
        {
            orig.Invoke(self);
            Debug.LogFormat("GoldIdol: beginning operation.");
            int num = 0; //Beacons to repair
            Xoroshiro128Plus xoroshiro128Plus = new Xoroshiro128Plus(self.rng.nextUlong);
            List<GameObject> beaconsToRepair = self.beaconInstanceList;
            using (IEnumerator<CharacterMaster> enumerator = CharacterMaster.readOnlyInstancesList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if(beaconsToRepair.Count > 0)
                    {
                        int itemCount = enumerator.Current.inventory.GetItemCountEffective(Content.Items.GoldIdol);
                        if (itemCount > 0)
                        {

                            int extraRolls = (int)Util.GetStackingBehavior(Configuration.Items.GoldIdol.procAmount, Configuration.Items.GoldIdol.procAmountStack, itemCount);
                            Debug.LogFormat("Master found with GoldIdol. Beginning roll count ({0} total rolls)...", extraRolls);
                            for (int i = 0; i < extraRolls; i++)
                            {
                                bool flag = RoR2.Util.CheckRoll(Configuration.Items.GoldIdol.procChance, enumerator.Current);
                                if (flag)
                                {
                                    Debug.LogFormat("- Roll succeeded. Locating beacon to repair...");
                                    if(beaconsToRepair.Count > 0)
                                    {
                                        GameObject beacon = beaconsToRepair.First();
                                        if (beacon != null)
                                        {
                                            Debug.LogFormat("- Beacon located. Beginning repair sequence...");
                                            EntityStateMachine esm = beacon.GetComponent<EntityStateMachine>();
                                            if (esm != null)
                                            {
                                                esm.SetState(new EntityStates.Interactables.GoldBeacon.Ready());
                                                num++;
                                                Debug.LogFormat("- Successfully activated beacon. Removing beacon from list.");
                                                beaconsToRepair.Remove(beacon);
                                            }
                                        }
                                    }
                                }
                            }
                            Debug.LogFormat("{0} rolls succeeded out of {1}.", num, extraRolls);
                        }
                    }
                    else
                    {
                        Debug.LogFormat("No remaining beacons to be repaired. Aborting.");
                        break;
                    }
                    
                }
            }
            Debug.LogFormat("GoldIdol: finishing operation.");
        }
    }
}
