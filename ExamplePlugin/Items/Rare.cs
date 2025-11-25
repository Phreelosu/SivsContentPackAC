using R2API;
using RoR2;
using SivsContentPack.Config;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using SivsContentPack;
using static SivsContentPack.Config.Configuration.Items;
using System.Diagnostics;


namespace SivsContentPack.Items
{
    internal class HealthBasedDamageBonus : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("HealthBasedDamageBonus");
            this.displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayHealthBasedDamageBonus");
            Content.ProcTypes.healthBasedDamageBonus = Content.CreateProcType();
        }

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.HealthBasedDamageBonus.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matDragonBand");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matBlood");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGlassSeeThrough");
            //m.shader = Shader.Find("Hopoo Games/FX/Cloud Intersection Remap");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_HEALTHBASEDDAMAGEBONUS_NAME","Dragon Blood");
            LanguageAPI.Add("ITEM_HEALTHBASEDDAMAGEBONUS_PICKUP", "Deal bonus damage equal to 25% of your max health. Increases max health.");
            LanguageAPI.Add("ITEM_HEALTHBASEDDAMAGEBONUS_DESCRIPTION", "Increases <style=cIsHealth>max health</style> by <style=cIsUtility>25% </style><style=cStack>(+25% per stack)</style>. Your attacks deal <style=cIsDamage>bonus damage</style> equal to <style=cIsHealth>25% of your max health</style>.");
            //LanguageAPI.Add("ITEM_HEALTHBASEDDAMAGEBONUS_LORE", "");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "UpperArmL",
localPos = new Vector3(0.12185F, 0.19595F, -0.0017F),
localAngles = new Vector3(0F, 180F, 180F),
localScale = new Vector3(0.5F, 0.5F, 0.5F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "UpperArmL",
localPos = new Vector3(0.10751F, 0.1299F, -0.00001F),
localAngles = new Vector3(0F, 180F, 180F),
localScale = new Vector3(0.5F, 0.5F, 0.5F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MainWeapon",
localPos = new Vector3(-0.19068F, 0.51906F, 0.00107F),
localAngles = new Vector3(1.48572F, 188.0644F, 0.21048F),
localScale = new Vector3(0.5F, 0.5F, 0.5F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmL",
localPos = new Vector3(1.63078F, 2.49236F, -0.00002F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(5.97673F, 5.97673F, 5.97673F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.01839F, 0.09301F, 0.1195F),
localAngles = new Vector3(8.4801F, 97.63795F, 194.4005F),
localScale = new Vector3(0.5F, 0.5F, 0.5F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "FootFrontL",
localPos = new Vector3(0.18613F, 0.44244F, -0.16479F),
localAngles = new Vector3(10.89537F, 210.0295F, 177.381F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.13097F, 0.18302F, -0.02186F),
localAngles = new Vector3(357.3733F, 190.2989F, 168.8229F),
localScale = new Vector3(0.43476F, 0.43476F, 0.43476F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmL",
localPos = new Vector3(0.12272F, 0.12436F, -0.02938F),
localAngles = new Vector3(0.10668F, 188.7582F, 179.3076F),
localScale = new Vector3(0.54103F, 0.54103F, 0.54103F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmL",
localPos = new Vector3(0.1221F, 0.43612F, -0.01364F),
localAngles = new Vector3(14.03491F, 187.0578F, 174.836F),
localScale = new Vector3(0.61704F, 0.61704F, 0.61704F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CalfL",
localPos = new Vector3(-1.251F, 1.9962F, 0.4421F),
localAngles = new Vector3(8.21558F, 20.95576F, 177.4052F),
localScale = new Vector3(4.40831F, 3.94373F, 3.94373F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.06079F, 0.12308F, 0.13153F),
localAngles = new Vector3(0.30974F, 106.4062F, 180.0912F),
localScale = new Vector3(0.5F, 0.5F, 0.5F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "UpperArmL",
localPos = new Vector3(0.00533F, 0.10901F, 0.10378F),
localAngles = new Vector3(0.91436F, 91.9761F, 176.9776F),
localScale = new Vector3(0.40641F, 0.40641F, 0.40641F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "ForeArmL",
localPos = new Vector3(-0.07027F, 0.11129F, 0.15811F),
localAngles = new Vector3(2.71662F, 65.49751F, 184.1594F),
localScale = new Vector3(0.65185F, 0.65185F, 0.65185F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "UpperArmL",
localPos = new Vector3(0.12085F, 0.09482F, 0.0353F),
localAngles = new Vector3(15.25854F, 179.3374F, 190.1176F),
localScale = new Vector3(0.5628F, 0.5628F, 0.5628F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandL",
localPos = new Vector3(0.55541F, 0.25726F, 0.06616F),
localAngles = new Vector3(351.9043F, 6.52663F, 289.2021F),
localScale = new Vector3(0.56883F, 0.56883F, 0.56883F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(-0.0088F, -0.12008F, -0.02909F),
localAngles = new Vector3(346.0643F, 185.595F, 272.7427F),
localScale = new Vector3(0.5783F, 0.5783F, 0.5783F)
                }
            ]);
            itemDisplayRules.Add("EngiTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Neck",
localPos = new Vector3(0.38913F, 0.25748F, 0.11423F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1.75292F, 1.75292F, 1.75292F)
                }
            ]);
            itemDisplayRules.Add("EngiWalkerTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Neck",
localPos = new Vector3(0.38913F, 0.25748F, 0.11423F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1.75292F, 1.75292F, 1.75292F)
                }
            ]);
            itemDisplayRules.Add("ScavBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmL",
localPos = new Vector3(-1.18068F, 2.13116F, 0.00021F),
localAngles = new Vector3(0F, 0F, 175.6954F),
localScale = new Vector3(5.52051F, 5.52051F, 5.52051F)
                }
            ]);
        }
        protected override void Hooks()
        {
            RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
            On.RoR2.HealthComponent.TakeDamage += HealthComponent_TakeDamage;
        }

        private void HealthComponent_TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            GameObject attacker = damageInfo.attacker;
            if(damageInfo.procCoefficient > 0)
            {
                if (attacker != null)
                {
                    CharacterBody cb = attacker.GetComponent<CharacterBody>();
                    if (cb != null)
                    {
                        Inventory i = cb.inventory;
                        if (i != null)
                        {
                            int itemCount = i.GetItemCountEffective(Content.Items.HealthBasedDamageBonus);
                            if (itemCount > 0)
                            {
                                if (!damageInfo.procChainMask.HasProc(Content.ProcTypes.healthBasedDamageBonus))
                                {
                                    float damageBonus = Configuration.Items.HealthBasedDamageBonus.healthToDamageCoefficient;
                                    damageInfo.damage += ((cb.maxHealth * damageBonus) * damageInfo.procCoefficient);
                                    if (damageInfo.damageColorIndex == DamageColorIndex.Default)
                                    {
                                        damageInfo.damageColorIndex = DamageColorIndex.Item;
                                    }
                                    damageInfo.procChainMask.AddProc(Content.ProcTypes.healthBasedDamageBonus);
                                }
                            }
                        }
                    }
                }
            }
            
            orig.Invoke(self, damageInfo);
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if(sender != null)
            {
                Inventory i = sender.inventory;
                if(i != null)
                {
                    int itemCount = i.GetItemCountEffective(Content.Items.HealthBasedDamageBonus);
                    if (itemCount > 0)
                    {
                        args.healthMultAdd += Util.GetStackingBehavior(Configuration.Items.HealthBasedDamageBonus.healthBoost, Configuration.Items.HealthBasedDamageBonus.healthBoostStack, itemCount);
                    }
                }
            }
        }

    }
    internal class BlockLowDamageHits : ItemFactory
    {
        private GameObject procEffect;
        /// <summary>
        /// A list of damage types that Nuclear Cuisine won't attempt to block.
        /// </summary>
        public static List<DamageType> unblockableDamageTypes = new List<DamageType>()
        {
                DamageType.BypassBlock,
                DamageType.OutOfBounds,
                DamageType.VoidDeath,
        };

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.BlockLowDamageHits.enabled.Value;
        }
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("BlockLowDamageHits");
            this.displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayBlockLowDamageHits");
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matNuclearPasta");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTrimSheetConstructionNuclearPasta");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matNeutronium");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matNuclearPastaDistortion");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Distortion");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGlassSeeThrough");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matNuclearGlow");
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
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.108F, 0.09298F, 0.01729F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.25981F, 0.25981F, 0.25981F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.11888F, 0.00047F, -0.01866F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.20888F, 0.20888F, 0.20888F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Stomach",
localPos = new Vector3(0.20801F, 0.02309F, 0.00061F),
localAngles = new Vector3(0.53464F, 0.13074F, 3.30028F),
localScale = new Vector3(0.18289F, 0.18289F, 0.18289F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0F, 1.16817F, 3.42385F),
localAngles = new Vector3(0F, 0F, 90.5098F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmL",
localPos = new Vector3(0.00002F, 0.16312F, -0.11187F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.13142F, 0.13142F, 0.13142F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "WeaponPlatform",
localPos = new Vector3(0.00001F, -0.67866F, 0.4274F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.48822F, 0.48822F, 0.48822F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MechHandRight",
localPos = new Vector3(0F, 0.33125F, 0.13926F),
localAngles = new Vector3(0F, 0F, 90F),
localScale = new Vector3(0.16999F, 0.16999F, 0.16999F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.11367F, 0F, 0F),
localAngles = new Vector3(0F, 0F, 349.6922F),
localScale = new Vector3(0.27253F, 0.27253F, 0.27253F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandL",
localPos = new Vector3(-0.1284F, 0.13573F, 0.00006F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.24949F, 0.24949F, 0.24949F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.07736F, 5.04367F, 1.99175F),
localAngles = new Vector3(0F, 0F, 273.1424F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.16696F, 0.06033F, 0.00001F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.30475F, 0.30475F, 0.30475F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "GunStock",
localPos = new Vector3(0F, 0.14362F, -0.00002F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.25171F, 0.25171F, 0.25171F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CannonEnd",
localPos = new Vector3(0.32338F, -0.28573F, 0.00001F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.38064F, 0.38064F, 0.38064F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.36009F, 0.29388F, -0.3787F),
localAngles = new Vector3(357.3275F, 356.7998F, 50.17429F),
localScale = new Vector3(0.26845F, 0.26845F, 0.26845F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0F, 0.36692F, -0.24729F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.35652F, 0.35652F, 0.35652F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.32743F, 0.00169F, 0.25205F),
localAngles = new Vector3(0F, 0F, 92.51158F),
localScale = new Vector3(0.24028F, 0.24028F, 0.24028F)
                }
            ]);
            itemDisplayRules.Add("EngiTurretBody", [
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
            On.RoR2.HealthComponent.TakeDamage += HealthComponent_TakeDamage;
        }

        private void HealthComponent_TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            CharacterBody cb = self.body;
            if (cb != null)
            {
                Inventory i = cb.inventory;
                if (i != null)
                {
                    int itemStack = i.GetItemCountEffective(Content.Items.BlockLowDamageHits);
                    if (itemStack > 0)
                    {

                        bool flag = false;
                        foreach (var type in unblockableDamageTypes)
                        {
                            if (((damageInfo.damageType & type) > 0UL))
                            {
                                flag = true;
                            }
                        }
                        if(cb.HasBuff(RoR2Content.Buffs.Immune) || cb.HasBuff(RoR2Content.Buffs.HiddenInvincibility))
                        {
                            flag = false;
                        }
                        if (!flag)
                        {
                            float threshold = CalculateThreshold(itemStack);
                            float requiredDamage = threshold * self.combinedHealth;
                            //UnityEngine.Debug.LogFormat("Damage Dealt: {0} vs Required Damage {1} ({2}% threshold)", damageInfo.damage, requiredDamage, threshold);
                            if (damageInfo.damage <= requiredDamage)
                            {
                                EffectData ed = new EffectData()
                                {
                                    start = cb.corePosition,
                                    origin = cb.corePosition,
                                };
                                EffectManager.SpawnEffect(Content.Effects.BlockLowDamageHitsProc.prefab, ed, true);
                                damageInfo.rejected = true;
                            }
                        }
                        
                    }
                }
            }
            orig.Invoke(self, damageInfo);

        }
        private float CalculateThreshold(int stack)
        {
            return RoR2.Util.ConvertAmplificationPercentageIntoReductionPercentage(Configuration.Items.BlockLowDamageHits.damageThreshold * stack);
        }
    }
    internal class FrenzyOnBossKill : ItemFactory
    {
        private GameObject procEffect;

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.FrenzyOnBossKill.enabled.Value;
        }
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("FrenzyOnBossKill");
            this.displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayFrenzyOnBossKill");
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matGoldSaber");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_FRENZYONBOSSKILL_NAME", "Golden Glory");
            LanguageAPI.Add("ITEM_FRENZYONBOSSKILL_PICKUP", "Enter a frenzy after killing a boss that makes you invulnerable and lucky.");
            LanguageAPI.Add("ITEM_FRENZYONBOSSKILL_DESCRIPTION", "Killing a boss <style=cIsDamage>sends you into a frenzy</style> for <style=cIsDamage>5</style> <style=cStack>(+5 per stack)</style> seconds. The frenzy makes you <style=cIsUtility>invulnerable</style> and <style=cIsHealing>increases your luck by 1</style>.");
            //LanguageAPI.Add("ITEM_FRENZYONBOSSKILL_LORE", "");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.27882F, 0.20078F, -0.03999F),
localAngles = new Vector3(51.93562F, 147.2794F, 11.22411F),
localScale = new Vector3(0.8F, 0.8F, 0.8F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.04952F, 0.10992F, -0.18534F),
localAngles = new Vector3(312.7787F, 102.3897F, 164.6321F),
localScale = new Vector3(0.66767F, 0.66767F, 0.66767F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.15069F, 0.18997F, -0.19248F),
localAngles = new Vector3(84.31325F, 236.3143F, 52.26466F),
localScale = new Vector3(0.5434F, 0.5434F, 0.5434F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmL",
localPos = new Vector3(0.12586F, 3.30989F, 1.17135F),
localAngles = new Vector3(0F, 251.9925F, 0F),
localScale = new Vector3(3.52738F, 3.52738F, 3.52738F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandL",
localPos = new Vector3(-0.31983F, 0.2177F, -0.02795F),
localAngles = new Vector3(75.91338F, 316.0683F, 45.19383F),
localScale = new Vector3(0.58694F, 0.58694F, 0.58694F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "WeaponPlatform",
localPos = new Vector3(0.02473F, 0.94521F, 0.08457F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1.0549F, 1.0549F, 1.0549F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MechHandL",
localPos = new Vector3(-0.47259F, 0.3093F, -0.15496F),
localAngles = new Vector3(87.01023F, 180.0003F, 289.1194F),
localScale = new Vector3(0.8476F, 0.8476F, 0.8476F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandR",
localPos = new Vector3(0.41288F, 0.15616F, 0.02151F),
localAngles = new Vector3(75.46143F, 335.752F, 245.0463F),
localScale = new Vector3(0.72524F, 0.72524F, 0.72524F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.12925F, 0.13504F, -0.24946F),
localAngles = new Vector3(322.0045F, 83.61742F, 188.428F),
localScale = new Vector3(0.67473F, 0.67473F, 0.67473F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandL",
localPos = new Vector3(0.33854F, 2.89132F, -3.88562F),
localAngles = new Vector3(76.26456F, 135.6879F, 312.9782F),
localScale = new Vector3(6.92226F, 6.92226F, 6.92226F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandL",
localPos = new Vector3(-0.42642F, 0.17309F, -0.05225F),
localAngles = new Vector3(89.50742F, 268.7607F, 0.0004F),
localScale = new Vector3(0.70072F, 0.70072F, 0.70072F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.09345F, 0.01063F, -0.10014F),
localAngles = new Vector3(52.8749F, 173.9095F, 355.1373F),
localScale = new Vector3(0.5222F, 0.5222F, 0.5222F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.22281F, 0.0986F, -0.40236F),
localAngles = new Vector3(293.7534F, 268.8997F, 260.384F),
localScale = new Vector3(0.4842F, 0.4842F, 0.4842F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandL",
localPos = new Vector3(0.266F, 0.13298F, 0.01846F),
localAngles = new Vector3(73.99597F, 150.8381F, 60.44049F),
localScale = new Vector3(0.48041F, 0.48041F, 0.48041F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandL",
localPos = new Vector3(1.56515F, 1.06191F, 0.19502F),
localAngles = new Vector3(58.3532F, 59.489F, 337.6826F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.24312F, -0.37992F, 0.06148F),
localAngles = new Vector3(0.3346F, 347.4301F, 271.5003F),
localScale = new Vector3(0.66354F, 0.66354F, 0.66354F)
                }
            ]);
            itemDisplayRules.Add("EngiTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LegBar1",
localPos = new Vector3(0F, 0.2467F, 0.20469F),
localAngles = new Vector3(0F, 255.3672F, 0F),
localScale = new Vector3(1F, 1F, 1F)
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
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(1.60842F, 2.04935F, -7.18161F),
localAngles = new Vector3(40.65158F, 197.4378F, 207.9655F),
localScale = new Vector3(4.37066F, 4.37066F, 4.37066F)
                }
            ]);
        }
        protected override void Hooks()
        {
            On.RoR2.GlobalEventManager.OnCharacterDeath += GlobalEventManager_OnCharacterDeath;
        }

        private void GlobalEventManager_OnCharacterDeath(On.RoR2.GlobalEventManager.orig_OnCharacterDeath orig, GlobalEventManager self, DamageReport damageReport)
        {
            CharacterBody attacker = damageReport.attackerBody;
            CharacterBody victim = damageReport.victimBody;
            CharacterMaster vcm = damageReport.victimMaster;
            if (victim != null)
            {
                if (damageReport.victimIsBoss)
                {
                    if (attacker != null)
                    {
                        Inventory i = attacker.inventory;
                        if (i != null)
                        {
                            int itemStack = i.GetItemCountEffective(Content.Items.FrenzyOnBossKill);
                            if (itemStack > 0)
                            {
                                float duration = Util.GetStackingBehavior(Configuration.Items.FrenzyOnBossKill.buffDuration, Configuration.Items.FrenzyOnBossKill.buffDurationStack, itemStack);
                                EffectManager.SpawnEffect(Content.Effects.FrenzyOnBossKillProc.prefab, new EffectData
                                {
                                    origin = attacker.corePosition,
                                    rootObject = attacker.gameObject,
                                    rotation = Quaternion.Euler(attacker.characterDirection.forward),
                                    start = attacker.corePosition,
                                }, true);
                                attacker.AddTimedBuff(Content.Buffs.BossKillFrenzy, duration);
                            }
                        }
                    }
                }
            }
            orig.Invoke(self, damageReport);
            
        }
    }
    internal class Shieldbreaker : ItemFactory
    {

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.ShieldBreaker.enabled.Value;
        }
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("Shieldbreaker");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayShieldbreaker");
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matShieldbreaker");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_SHIELDBREAKER_NAME", "Shieldbreaker");
            LanguageAPI.Add("ITEM_SHIELDBREAKER_PICKUP", "Your attacks ignore enemy armor and deal more damage to shields and barrier.");
            LanguageAPI.Add("ITEM_SHIELDBREAKER_DESCRIPTION", "Your attacks <style=cIsDamage>ignore enemy armor</style> and deal an additional <style=cIsDamage>+50%</style> <style=cStack>(+50% per stack)</style> bonus damage to <style=cIsUtility>shields</style> and <style=cIsDamage>barrier</style>.");
            //LanguageAPI.Add("ITEM_???_LORE", "");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0F, 0.22886F, -0.27896F),
localAngles = new Vector3(32.88631F, 256.28F, 0F),
localScale = new Vector3(0.43483F, 0.43483F, 0.43483F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pelvis",
localPos = new Vector3(-0.00935F, -0.07849F, 0.1075F),
localAngles = new Vector3(280.9503F, 54.73865F, 36.25689F),
localScale = new Vector3(0.38206F, 0.38206F, 0.38206F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pelvis",
localPos = new Vector3(0.2052F, 0.03765F, 0.08575F),
localAngles = new Vector3(45.55319F, 347.9855F, 343.4001F),
localScale = new Vector3(0.30697F, 0.30697F, 0.30697F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.01402F, 0.03733F, 0.95142F),
localAngles = new Vector3(0F, 94.29795F, 11.31351F),
localScale = new Vector3(2.87004F, 2.87004F, 2.87004F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandR",
localPos = new Vector3(-0.10568F, 0.18976F, 0.12011F),
localAngles = new Vector3(305.5491F, 68.28056F, 48.85648F),
localScale = new Vector3(0.29957F, 0.29957F, 0.29957F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "FlowerBase",
localPos = new Vector3(0.6302F, 0.86626F, -0.11678F),
localAngles = new Vector3(72.02506F, 191.7077F, 242.5451F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MechHandR",
localPos = new Vector3(0.17602F, 0.30089F, -0.03538F),
localAngles = new Vector3(273.9818F, 251.8195F, 36.58089F),
localScale = new Vector3(0.45022F, 0.45022F, 0.45022F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.00734F, -0.03394F, -0.21726F),
localAngles = new Vector3(66.88314F, 103.7919F, 186.7567F),
localScale = new Vector3(0.42672F, 0.42672F, 0.42672F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.06568F, 0.13035F, -0.2697F),
localAngles = new Vector3(61.80594F, 250.0267F, 162.2386F),
localScale = new Vector3(0.32509F, 0.32509F, 0.32509F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.14163F, -0.13106F, 4.46871F),
localAngles = new Vector3(70.54587F, 68.43301F, 343.4596F),
localScale = new Vector3(3.09297F, 3.09297F, 3.09297F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.00113F, 0.14472F, -0.32184F),
localAngles = new Vector3(45.34761F, 263.9627F, 351.2727F),
localScale = new Vector3(0.48324F, 0.48324F, 0.48324F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.10027F, -0.0083F, -0.11767F),
localAngles = new Vector3(0F, 317.7785F, 12.97304F),
localScale = new Vector3(0.33992F, 0.33992F, 0.33992F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ForeArmR",
localPos = new Vector3(0.35246F, 0.34885F, 0.00003F),
localAngles = new Vector3(0F, 0F, 350.3822F),
localScale = new Vector3(0.56478F, 0.56478F, 0.56478F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pack",
localPos = new Vector3(0F, 0F, -0.39843F),
localAngles = new Vector3(45.67843F, 75.26591F, 0F),
localScale = new Vector3(0.5204F, 0.5204F, 0.5204F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandL",
localPos = new Vector3(1.71393F, 0.89848F, 0.01938F),
localAngles = new Vector3(0F, 0F, 292.355F),
localScale = new Vector3(0.6715F, 0.6715F, 0.6715F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.07707F, -0.49375F, 0.10576F),
localAngles = new Vector3(1.41818F, 41.99127F, 88.42503F),
localScale = new Vector3(0.37443F, 0.37443F, 0.37443F)
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
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-6.42763F, -5.57937F, -10.01141F),
localAngles = new Vector3(350.1958F, 15.62358F, 266.1553F),
localScale = new Vector3(4.28787F, 4.28787F, 4.28787F)
                }
            ]);
        }
        protected override void Hooks()
        {
            On.RoR2.HealthComponent.TakeDamage += HealthComponent_TakeDamage;
        }

        private void HealthComponent_TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            if (damageInfo.procCoefficient > 0)
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
                            int itemCount = i.GetItemCountEffective(Content.Items.ShieldBreaker);
                            if (itemCount > 0)
                            {
                                if (self.body.armor > 0 && (!((damageInfo.damageType & DamageType.BypassArmor) > 0UL)))
                                {
                                    damageInfo.damageType |= DamageType.BypassArmor;
                                }
                                if (self.shield > 0 || self.barrier > 0)
                                {
                                    damageInfo.damage *= 1 + (Util.GetStackingBehavior(Configuration.Items.ShieldBreaker.shieldDamageBonus, Configuration.Items.ShieldBreaker.shieldDamageBonusStack, itemCount));
                                }
                            }
                        }
                    }
                }
            }
            orig.Invoke(self, damageInfo);
        }
    }
    internal class Placebo : ItemFactory
    {

        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Placebo.enabled.Value;
        }
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("Placebo");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayPill");
            Content.ProcTypes.placebo = Content.CreateProcType();
        }
        protected override void HandleMaterials()
        {

            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matPill");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPillTransparent");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_PLACEBO_NAME", "Critical Placebo");
            LanguageAPI.Add("ITEM_PLACEBO_PICKUP", "It really works!");
            LanguageAPI.Add("ITEM_PLACEBO_DESCRIPTION", "<style=cIsUtility>All of your attacks</style> are considered <style=cIsDamage>critical strikes</style>, benefiting from items but <style=cDeath>not receiving a damage increase</style>. Actual critical strikes have their <style=cIsUtility>proc coefficients</style> increased by <style=cIsDamage>50% <style=cStack>(+50% per stack)</style></style>.");
            //LanguageAPI.Add("ITEM_PLACEBO_LORE", "");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleRight",
localPos = new Vector3(0.02428F, -0.01104F, -0.20679F),
localAngles = new Vector3(80.79858F, 318.8981F, 321.4613F),
localScale = new Vector3(0.12727F, 0.12727F, 0.12727F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandL",
localPos = new Vector3(0F, 0.07823F, 0.03761F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.08275F, 0.08275F, 0.08275F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "SideWeapon",
localPos = new Vector3(0.00001F, -0.22771F, 0.14093F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.06442F, 0.06442F, 0.06442F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(1.41479F, 0.97453F, 1.26645F),
localAngles = new Vector3(325.7843F, 0F, 329.2502F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.11231F, 0.10499F, -0.08035F),
localAngles = new Vector3(7.88261F, 349.6695F, 358.568F),
localScale = new Vector3(0.0687F, 0.0687F, 0.0687F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleSyringe",
localPos = new Vector3(0.00002F, -0.03343F, 0.0518F),
localAngles = new Vector3(89.66196F, 180F, 180F),
localScale = new Vector3(0.16792F, 0.16792F, 0.16792F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.07541F, 0.0516F, 0.12882F),
localAngles = new Vector3(0F, 0F, 351.1815F),
localScale = new Vector3(0.17647F, 0.17647F, 0.17647F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandL",
localPos = new Vector3(0F, 0.13731F, 0.0698F),
localAngles = new Vector3(0F, 0F, 86.24754F),
localScale = new Vector3(0.09432F, 0.09432F, 0.09432F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pelvis",
localPos = new Vector3(-0.12698F, -0.11262F, -0.16648F),
localAngles = new Vector3(3.89846F, 0F, 0F),
localScale = new Vector3(0.12055F, 0.12055F, 0.12055F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MouthMuzzle",
localPos = new Vector3(1.09266F, 2.53132F, 3.69699F),
localAngles = new Vector3(10.19692F, 348.248F, 310.3966F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CannonHeadL",
localPos = new Vector3(0F, 0.38663F, 0.20035F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.14067F, 0.14067F, 0.14067F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Backpack",
localPos = new Vector3(0.02979F, -0.00006F, -0.13058F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.10237F, 0.10237F, 0.10237F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ShoulderL",
localPos = new Vector3(0.09311F, 0.33385F, 0.0225F),
localAngles = new Vector3(359.9721F, 183.2494F, 270.4913F),
localScale = new Vector3(0.10558F, 0.10558F, 0.10558F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pelvis",
localPos = new Vector3(-0.04993F, 0F, 0.16822F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.08841F, 0.08841F, 0.08841F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.17322F, 0F, 0.23327F),
localAngles = new Vector3(279.9094F, 0F, 342.0578F),
localScale = new Vector3(0.14742F, 0.14742F, 0.14742F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Cleaver",
localPos = new Vector3(-0.01307F, 0.49831F, 0.00576F),
localAngles = new Vector3(86.00066F, 180F, 180F),
localScale = new Vector3(0.22973F, 0.22973F, 0.22973F)
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
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(2.60777F, 0.0001F, -0.00002F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
        }
        protected override void Hooks()
        {
            On.RoR2.GlobalEventManager.OnHitEnemy += GlobalEventManager_OnHitEnemy;
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender != null)
            {
                Inventory i = sender.inventory;
                if (i != null) {
                    int itemCount = i.GetItemCountEffective(Content.Items.Placebo);
                    if (itemCount > 0)
                    {
                        args.critDamageMultAdd += Util.GetStackingBehavior(Configuration.Items.Placebo.critProcCoefficientBonus, Configuration.Items.Placebo.critProcCoefficientBonusStack, itemCount);
                    }
                }
            }
        }

        private void GlobalEventManager_OnHitEnemy(On.RoR2.GlobalEventManager.orig_OnHitEnemy orig, GlobalEventManager self, DamageInfo damageInfo, GameObject victim)
        {
            bool attackWasAlreadyCrit = damageInfo.crit;
            orig.Invoke(self, damageInfo, victim);
            if (!attackWasAlreadyCrit)
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
                            int itemCount = i.GetItemCountEffective(Content.Items.Placebo);
                            if (itemCount > 0)
                            {
                                CharacterMaster cm = cb.master;
                                if (cm != null)
                                {
                                    if (!damageInfo.procChainMask.HasProc(Content.ProcTypes.placebo))
                                    {
                                        damageInfo.procChainMask.AddProc(Content.ProcTypes.placebo);
                                        self.OnCrit(cb, damageInfo, cm, damageInfo.procCoefficient, damageInfo.procChainMask);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }
    }
}
