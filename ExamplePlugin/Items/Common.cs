using R2API;
using RoR2;
using SivsContentPack.Config;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SivsContentPack.Items
{
    internal class GlassShield : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("GlassShield");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayGlassShield");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.GlassShield.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matGlassShield");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGlassShards");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_GLASSSHIELD_NAME", "Glass Shield");
            LanguageAPI.Add("ITEM_GLASSSHIELD_PICKUP", "Blocks an instance of fatal damage. Breaks on use.");
            LanguageAPI.Add("ITEM_GLASSSHIELD_DESCRIPTION", "Blocks <style=cIsUtility>1</style> <style=cStack>(+1 per stack)</style> instance of <style=cDeath>fatal damage</style>. Breaks after use.");
            //LanguageAPI.Add("ITEM_GLASSSHIELD_LORE", "");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.06508F, -0.00384F, -0.03492F),
localAngles = new Vector3(23.65892F, 264.0768F, 168.8151F),
localScale = new Vector3(0.25922F, 0.25922F, 0.25922F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.00001F, 0.21434F, -0.05181F),
localAngles = new Vector3(351.6508F, 180F, 180F),
localScale = new Vector3(0.26725F, 0.26725F, 0.26725F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzlePistol",
localPos = new Vector3(0.01384F, 0.02858F, -0.11615F),
localAngles = new Vector3(307.707F, 75.40884F, 288.213F),
localScale = new Vector3(0.21919F, 0.21919F, 0.21919F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-1.88577F, 1.31668F, 3.32025F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.06513F, 0.05005F, 0.00666F),
localAngles = new Vector3(4.65272F, 276.2664F, 180.5103F),
localScale = new Vector3(0.20089F, 0.20089F, 0.20089F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighFrontR",
localPos = new Vector3(0.03566F, 0.15199F, -0.02406F),
localAngles = new Vector3(359.0902F, 128.1029F, 181.1599F),
localScale = new Vector3(0.37575F, 0.37575F, 0.37575F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MechUpperArmR",
localPos = new Vector3(-0.06697F, 0.00088F, 0.01397F),
localAngles = new Vector3(31.54689F, 284.0083F, 184.1519F),
localScale = new Vector3(0.26551F, 0.26551F, 0.26551F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.12101F, -0.01613F, -0.00899F),
localAngles = new Vector3(40.44711F, 265.7571F, 180F),
localScale = new Vector3(0.25286F, 0.25286F, 0.25286F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.12773F, 0.18311F, 0.18296F),
localAngles = new Vector3(0F, 346.7662F, 0F),
localScale = new Vector3(0.11475F, 0.11475F, 0.11475F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmR",
localPos = new Vector3(0.32299F, 1.95398F, 0.79513F),
localAngles = new Vector3(9.20478F, 43.32292F, 188.5791F),
localScale = new Vector3(4.28601F, 4.28601F, 4.28601F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.08905F, -0.00001F, 0F),
localAngles = new Vector3(0.34415F, 274.1998F, 175.3238F),
localScale = new Vector3(0.24297F, 0.24297F, 0.24297F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.03752F, 0.08405F, 0.00818F),
localAngles = new Vector3(358.6424F, 290.8463F, 183.9226F),
localScale = new Vector3(0.16991F, 0.16991F, 0.16991F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ForeArmR",
localPos = new Vector3(0.23764F, -0.06514F, -0.00389F),
localAngles = new Vector3(7.4769F, 55.91333F, 195.2883F),
localScale = new Vector3(0.26661F, 0.26661F, 0.26661F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(0.01572F, 0.12587F, 0.07562F),
localAngles = new Vector3(0F, 0F, 178.6278F),
localScale = new Vector3(0.21441F, 0.21441F, 0.21441F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ClavR",
localPos = new Vector3(-0.01687F, 0.59191F, 0.17487F),
localAngles = new Vector3(341.364F, 1.27729F, 174.274F),
localScale = new Vector3(0.29404F, 0.29404F, 0.29404F)
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
            On.RoR2.HealthComponent.TakeDamage += HealthComponent_TakeDamage;
        }
        private void HealthComponent_TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            CharacterBody body = self.body;
            if (body != null)
            {
                bool flag = (body.HasBuff(RoR2Content.Buffs.Immune) || body.HasBuff(RoR2Content.Buffs.HiddenInvincibility));
                if (!flag)
                {
                    Inventory inventory = body.inventory;
                    if (inventory != null)
                    {
                        bool hasGlassShield = inventory.GetItemCountEffective(Content.Items.GlassShield) > 0;
                        if (hasGlassShield && damageInfo.damage >= self.combinedHealth)
                        {
                            bool canBeBlocked = (!((damageInfo.damageType & DamageType.BypassBlock) > DamageType.Generic) && !((damageInfo.damageType & DamageType.NonLethal) > DamageType.Generic));
                            if (canBeBlocked)
                            {
                                EffectManager.SpawnEffect(Content.Effects.GlassShieldBreakProc.prefab, new EffectData
                                {
                                    origin = body.corePosition,
                                    start = body.corePosition,
                                    rotation = Quaternion.identity,
                                    rootObject = body.gameObject,
                                }, true);
                                inventory.RemoveItemPermanent(Content.Items.GlassShield);
                                inventory.GiveItemPermanent(Content.Items.GlassShieldBroken);
                                damageInfo.rejected = true;
                                CharacterMasterNotificationQueue.PushItemTransformNotification(body.master, Content.Items.GlassShield.itemIndex, Content.Items.GlassShieldBroken.itemIndex, CharacterMasterNotificationQueue.TransformationType.Default);
                            }
                        }
                    }
                }
            }
            orig.Invoke(self, damageInfo);
        }
    }
    internal class GlassShieldBroken : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("GlassShieldBroken");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.GlassShield.enabled.Value;
        }
        protected override void HandleMaterials()
        {

        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_GLASSSHIELDBROKEN_NAME", "Glass Shield (Broken)");
            LanguageAPI.Add("ITEM_GLASSSHIELDBROKEN_PICKUP", "A spent item with no remaining power.");
            LanguageAPI.Add("ITEM_GLASSSHIELDBROKEN_DESCRIPTION", "A spent item with no remaining power.");
            //LanguageAPI.Add("ITEM_GLASSSHIELDBROKEN_LORE", "A spent item with no remaining power.");
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
    internal class MaterialTester : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Main.LoadAsset<ItemDef>("MaterialTester");
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Main.LoadAsset<Material>("matMaterialTester");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
        protected override void Hooks()
        {

        }

    }
    internal class FlatHealIncrease : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("FlatHealingIncrease");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.FlatHealIncrease.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matMilk");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_FLATHEALINGINCREASE_NAME", "Pasteurized Milk");
            LanguageAPI.Add("ITEM_FLATHEALINGINCREASE_PICKUP", "Increases all healing by a flat 1.");
            LanguageAPI.Add("ITEM_FLATHEALINGINCREASE_DESCRIPTION", "Increases all <style=cIsDamage>non-passive</style> healing by a flat <style=cIsHealing>1</style> <style=cStack>(+1 per stack)</style>.");
            //LanguageAPI.Add("ITEM_FLATHEALINGINCREASE_LORE", "");
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
            On.RoR2.HealthComponent.Heal += HealthComponent_Heal;
        }

        private float HealthComponent_Heal(On.RoR2.HealthComponent.orig_Heal orig, HealthComponent self, float amount, ProcChainMask procChainMask, bool nonRegen)
        {
            if (nonRegen)
            {
                if (self != null)
                {
                    CharacterBody cb = self.body;
                    if (cb != null)
                    {
                        Inventory i = cb.inventory;
                        if (i != null)
                        {
                            int itemCount = i.GetItemCountEffective(Content.Items.FlatHealIncrease);
                            if (itemCount > 0)
                            {
                                float bonus = Util.GetStackingBehavior(Configuration.Items.FlatHealIncrease.healBonus, Configuration.Items.FlatHealIncrease.healBonusStack, itemCount);

                                amount += bonus;
                            }
                        }
                    }
                }
            }
            return orig.Invoke(self, amount, procChainMask, nonRegen);
        }
    }
    internal class ProcBoost : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ProcBoost");
            this.displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayCoin");
            Content.ProcTypes.procBonus = Content.CreateProcType();
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.ProcBoost.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matCoin");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSparkle");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            //m = Assets.AssetBundles.Items.LoadAsset<Material>("matSparkle");
            //m.shader = Shader.Find("Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_PROCBOOST_NAME", "Commemorative Coin");
            LanguageAPI.Add("ITEM_PROCBOOST_PICKUP", "Slightly boosts the effectiveness of on-hit items.");
            LanguageAPI.Add("ITEM_PROCBOOST_DESCRIPTION", "Increases the proc coefficient of your attacks by <style=cIsUtility>+5%</style> <style=cStack>(+5% per stack)</style>.");
            //LanguageAPI.Add("ITEM_PROCBOOST_LORE", "");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.12667F, -0.01506F, 0.00001F),
localAngles = new Vector3(273.3336F, 77.0217F, 354.5286F),
localScale = new Vector3(0.04359F, 0.04359F, 0.04359F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Muzzle",
localPos = new Vector3(0F, -0.01746F, -0.1103F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.05748F, 0.05748F, 0.05748F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pelvis",
localPos = new Vector3(-0.10666F, -0.04954F, -0.16618F),
localAngles = new Vector3(311.5876F, 16.58031F, 10.79871F),
localScale = new Vector3(0.0758F, 0.0758F, 0.0758F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-1.2704F, 1.69862F, 2.17536F),
localAngles = new Vector3(47.96568F, 34.5633F, 324.8845F),
localScale = new Vector3(0.53177F, 0.53177F, 0.53177F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ClavicleL",
localPos = new Vector3(0.07673F, -0.02796F, 0.1854F),
localAngles = new Vector3(333.9945F, 14.41329F, 242.6214F),
localScale = new Vector3(0.06007F, 0.06007F, 0.06007F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "PlatformBase",
localPos = new Vector3(-0.32295F, -0.00425F, 0.4827F),
localAngles = new Vector3(47.84775F, 344.1435F, 6.89719F),
localScale = new Vector3(0.12435F, 0.12435F, 0.12435F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.07632F, 0.19974F, 0.18121F),
localAngles = new Vector3(61.46915F, 0F, 0F),
localScale = new Vector3(0.07049F, 0.07049F, 0.07049F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.1231F, -0.00157F, 0.05688F),
localAngles = new Vector3(289.9419F, 82.68011F, 174.0233F),
localScale = new Vector3(0.0613F, 0.0613F, 0.0613F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.20497F, 0.14458F),
localAngles = new Vector3(77.49195F, 0F, 0F),
localScale = new Vector3(0.05952F, 0.05952F, 0.05952F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(0.19341F, 2.03848F, 1.13388F),
localAngles = new Vector3(305.2968F, 110.0876F, 88.708F),
localScale = new Vector3(0.53989F, 0.53989F, 0.53989F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.12242F, 0.15594F, 0.25646F),
localAngles = new Vector3(81.09012F, 205.6061F, 181.7302F),
localScale = new Vector3(0.07291F, 0.07291F, 0.07291F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.02428F, 0.01213F, 0.04662F),
localAngles = new Vector3(287.6243F, 112.5412F, 120.2245F),
localScale = new Vector3(0.03372F, 0.03372F, 0.03372F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.15136F, 0.14305F, 0.0461F),
localAngles = new Vector3(304.2212F, 60.12348F, 187.5721F),
localScale = new Vector3(0.12651F, 0.12651F, 0.12651F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.13227F, 0.20786F, 0.03645F),
localAngles = new Vector3(62.02614F, 0F, 0F),
localScale = new Vector3(0.06681F, 0.06681F, 0.06681F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.38628F, 0.1683F),
localAngles = new Vector3(66.30972F, 0F, 0F),
localScale = new Vector3(0.0847F, 0.0847F, 0.0847F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.41808F, 0.16147F, 0.05878F),
localAngles = new Vector3(7.47116F, 94.01743F, 18.17991F),
localScale = new Vector3(0.1147F, 0.1147F, 0.1147F)
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
            On.RoR2.Util.CheckRoll_float_float_CharacterMaster += Util_CheckRoll_float_float_CharacterMaster;
        }

        private bool Util_CheckRoll_float_float_CharacterMaster(On.RoR2.Util.orig_CheckRoll_float_float_CharacterMaster orig, float percentChance, float luck, CharacterMaster effectOriginMaster)
        {
            bool flag = false;
            if (effectOriginMaster != null)
            {
                Inventory i = effectOriginMaster.inventory;
                if (i != null)
                {
                    int itemCount = i.GetItemCountEffective(Content.Items.ProcBoost);
                    flag = itemCount > 0;
                    if(flag)
                    {

                        float increase = Util.GetStackingBehavior(Configuration.Items.ProcBoost.baseBoost, Configuration.Items.ProcBoost.stackBoost, itemCount);
                        percentChance *= 1 + increase;
                        
                    }
                }
            }
            bool flag2 = orig.Invoke(percentChance, luck, effectOriginMaster);
            if (flag2 && flag)
            {
                if (effectOriginMaster != null)
                {
                    GameObject obj = effectOriginMaster.GetBodyObject();
                    if (obj != null)
                    {
                        CharacterBody cb = obj.GetComponent<CharacterBody>();
                        if (obj != null)
                        {
                            EffectManager.SimpleEffect(Content.Effects.ProcBoostEffect.prefab, cb.mainHurtBox.transform.position, Quaternion.identity, false);
                        }
                    }
                }
            }
            return flag2;
        }


    }
    internal class BoostExperience : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("BoostExperience");
        }
        protected override void HandleMaterials()
        {

        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_BOOSTEXPERIENCE_NAME", "Survival Booklet");
            LanguageAPI.Add("ITEM_BOOSTEXPERIENCE_PICKUP", "Monsters drop more experience.");
            LanguageAPI.Add("ITEM_BOOSTEXPERIENCE_DESCRIPTION", "Enemies drop <style=cIsUtility>10%</style> <style=cStack>(+10% per stack)</style> <style=cIsUtility>more experience</style> upon death.");
            //LanguageAPI.Add("ITEM_BOOSTEXPERIENCE_LORE", "");
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
    internal class GoldStar : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("GoldStar");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.GoldStar.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matGoldStar");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matStarEffect");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
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

        }

    }
    internal class HealOnCooldown : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("HealOnCooldown");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayWaterBottle");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.HealOnCooldown.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matWBWater");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matWBPlastic");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matWBCap");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pelvis",
localPos = new Vector3(0.18926F, -0.02578F, 0.09779F),
localAngles = new Vector3(0F, 180F, 180F),
localScale = new Vector3(0.2906F, 0.2906F, 0.2906F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pelvis",
localPos = new Vector3(0.19291F, 0.00376F, 0.08483F),
localAngles = new Vector3(352.9737F, 180F, 198.335F),
localScale = new Vector3(0.26968F, 0.26968F, 0.26968F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pelvis",
localPos = new Vector3(0.21882F, 0.00053F, -0.05617F),
localAngles = new Vector3(343.4808F, 195.1349F, 184.0298F),
localScale = new Vector3(0.20814F, 0.20814F, 0.20814F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CalfL",
localPos = new Vector3(-0.70721F, 1.58243F, 0.00004F),
localAngles = new Vector3(358.0923F, 180F, 180F),
localScale = new Vector3(2.1441F, 2.1441F, 2.1441F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.08427F, -0.00001F, 0.06461F),
localAngles = new Vector3(0.43359F, 179.9279F, 170.5582F),
localScale = new Vector3(0.2001F, 0.2001F, 0.2001F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "FlowerBase",
localPos = new Vector3(-0.37118F, 0.13267F, 0.28694F),
localAngles = new Vector3(291.7786F, 180F, 130.8074F),
localScale = new Vector3(0.60876F, 0.60876F, 0.60876F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0F, 0.31277F, -0.0754F),
localAngles = new Vector3(334.565F, 180F, 180F),
localScale = new Vector3(0.24935F, 0.24935F, 0.24935F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.11133F, -0.00226F, 0.05538F),
localAngles = new Vector3(88.35765F, 179.9999F, 164.8121F),
localScale = new Vector3(0.24223F, 0.24223F, 0.24223F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CalfR",
localPos = new Vector3(0.0936F, 0.28128F, 0F),
localAngles = new Vector3(15.26767F, 180F, 180F),
localScale = new Vector3(0.32773F, 0.32773F, 0.32773F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, 4.74049F, -0.41729F),
localAngles = new Vector3(0.67136F, 180F, 180F),
localScale = new Vector3(2.87069F, 2.87069F, 2.87069F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.1422F, 0.10181F, 0.00051F),
localAngles = new Vector3(359.7159F, 180F, 180F),
localScale = new Vector3(0.28069F, 0.28069F, 0.28069F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Backpack",
localPos = new Vector3(-0.0917F, 0.50772F, -0.02534F),
localAngles = new Vector3(0F, 0F, 179.5778F),
localScale = new Vector3(0.22769F, 0.22769F, 0.22769F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.10514F, -0.20351F, -0.08801F),
localAngles = new Vector3(10.93449F, 53.02918F, 81.8738F),
localScale = new Vector3(0.32657F, 0.32657F, 0.32657F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.16866F, -0.14749F, 0.01446F),
localAngles = new Vector3(47.97961F, 0F, 0F),
localScale = new Vector3(0.23638F, 0.23638F, 0.23638F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pelvis",
localPos = new Vector3(-0.24277F, 0.23133F, 0F),
localAngles = new Vector3(8.89208F, 0F, 0F),
localScale = new Vector3(0.24029F, 0.24029F, 0.24029F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleCenter",
localPos = new Vector3(0.06456F, 0.01199F, -0.06723F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.2202F, 0.2202F, 0.2202F)
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
            On.RoR2.GenericSkill.RestockSteplike += GenericSkill_RestockSteplike;
        }

        private void GenericSkill_RestockSteplike(On.RoR2.GenericSkill.orig_RestockSteplike orig, GenericSkill self)
        {
            orig.Invoke(self);
            CharacterBody cb = self.characterBody;
            if (cb != null)
            {
                Inventory i = cb.inventory;
                if (i != null)
                {
                    int itemCount = i.GetItemCountEffective(Content.Items.HealOnCooldown);
                    if (itemCount > 0)
                    {
                        HealthComponent hc = cb.healthComponent;
                        if (hc != null)
                        {
                            if(self.baseRechargeInterval > 0)
                            {
                                RoR2.Util.PlaySound("Play_item_use_passive_healing", self.gameObject);
                                float healthRestored = Configuration.Items.HealOnCooldown.flatHeal + (cb.maxHealth * Util.GetStackingBehavior(Configuration.Items.HealOnCooldown.healPercentage, Configuration.Items.HealOnCooldown.healPercentageStack, itemCount));
                                hc.Heal(healthRestored, default, true);
                            }
                        }
                    }
                }
            }
        }
    }
    internal class Bomb : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("Bomb");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.GlassShield.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matGlassShield");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGlassShards");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_GLASSSHIELD_NAME", "Glass Shield");
            LanguageAPI.Add("ITEM_GLASSSHIELD_PICKUP", "Blocks an instance of fatal damage. Breaks on use.");
            LanguageAPI.Add("ITEM_GLASSSHIELD_DESCRIPTION", "Blocks <style=cIsUtility>1</style> <style=cStack>(+1 per stack)</style> instance of <style=cDeath>fatal damage</style>. Breaks after use.");
            //LanguageAPI.Add("ITEM_GLASSSHIELD_LORE", "");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.06508F, -0.00384F, -0.03492F),
localAngles = new Vector3(23.65892F, 264.0768F, 168.8151F),
localScale = new Vector3(0.25922F, 0.25922F, 0.25922F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.00001F, 0.21434F, -0.05181F),
localAngles = new Vector3(351.6508F, 180F, 180F),
localScale = new Vector3(0.26725F, 0.26725F, 0.26725F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzlePistol",
localPos = new Vector3(0.01384F, 0.02858F, -0.11615F),
localAngles = new Vector3(307.707F, 75.40884F, 288.213F),
localScale = new Vector3(0.21919F, 0.21919F, 0.21919F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-1.88577F, 1.31668F, 3.32025F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.06513F, 0.05005F, 0.00666F),
localAngles = new Vector3(4.65272F, 276.2664F, 180.5103F),
localScale = new Vector3(0.20089F, 0.20089F, 0.20089F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighFrontR",
localPos = new Vector3(0.03566F, 0.15199F, -0.02406F),
localAngles = new Vector3(359.0902F, 128.1029F, 181.1599F),
localScale = new Vector3(0.37575F, 0.37575F, 0.37575F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MechUpperArmR",
localPos = new Vector3(-0.06697F, 0.00088F, 0.01397F),
localAngles = new Vector3(31.54689F, 284.0083F, 184.1519F),
localScale = new Vector3(0.26551F, 0.26551F, 0.26551F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.12101F, -0.01613F, -0.00899F),
localAngles = new Vector3(40.44711F, 265.7571F, 180F),
localScale = new Vector3(0.25286F, 0.25286F, 0.25286F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.12773F, 0.18311F, 0.18296F),
localAngles = new Vector3(0F, 346.7662F, 0F),
localScale = new Vector3(0.11475F, 0.11475F, 0.11475F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmR",
localPos = new Vector3(0.32299F, 1.95398F, 0.79513F),
localAngles = new Vector3(9.20478F, 43.32292F, 188.5791F),
localScale = new Vector3(4.28601F, 4.28601F, 4.28601F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.08905F, -0.00001F, 0F),
localAngles = new Vector3(0.34415F, 274.1998F, 175.3238F),
localScale = new Vector3(0.24297F, 0.24297F, 0.24297F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.03752F, 0.08405F, 0.00818F),
localAngles = new Vector3(358.6424F, 290.8463F, 183.9226F),
localScale = new Vector3(0.16991F, 0.16991F, 0.16991F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ForeArmR",
localPos = new Vector3(0.23764F, -0.06514F, -0.00389F),
localAngles = new Vector3(7.4769F, 55.91333F, 195.2883F),
localScale = new Vector3(0.26661F, 0.26661F, 0.26661F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(0.01572F, 0.12587F, 0.07562F),
localAngles = new Vector3(0F, 0F, 178.6278F),
localScale = new Vector3(0.21441F, 0.21441F, 0.21441F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ClavR",
localPos = new Vector3(-0.01687F, 0.59191F, 0.17487F),
localAngles = new Vector3(341.364F, 1.27729F, 174.274F),
localScale = new Vector3(0.29404F, 0.29404F, 0.29404F)
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
            On.RoR2.HealthComponent.TakeDamage += HealthComponent_TakeDamage;
        }
        private void HealthComponent_TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            CharacterBody body = self.body;
            if (body != null)
            {
                Inventory inventory = body.inventory;
                ItemIndex from = Content.Items.GlassShield.itemIndex;
                ItemIndex to = Content.Items.GlassShieldBroken.itemIndex;
                if (inventory != null)
                {
                    bool hasGlassShield = inventory.GetItemCountEffective(Content.Items.GlassShield) > 0;
                    if (hasGlassShield && damageInfo.damage >= self.combinedHealth)
                    {
                        bool canBeBlocked = (!((damageInfo.damageType & DamageType.BypassBlock) > DamageType.Generic) && !((damageInfo.damageType & DamageType.NonLethal) > DamageType.Generic));
                        if (canBeBlocked)
                        {
                            EffectManager.SpawnEffect(Content.Effects.GlassShieldBreakProc.prefab, new EffectData
                            {
                                origin = body.corePosition,
                                rootObject = body.gameObject,
                            }, true);
                            Inventory.ItemTransformation transform = new Inventory.ItemTransformation
                            {
                                originalItemIndex = from,
                                newItemIndex = to
                            };
                            //inventory.RemoveItem(Content.Items.GlassShield);
                            //inventory.GiveItem(Content.Items.GlassShieldBroken);
                            damageInfo.rejected = true;
                            CharacterMasterNotificationQueue.PushItemTransformNotification(body.master, Content.Items.GlassShield.itemIndex, Content.Items.GlassShieldBroken.itemIndex, CharacterMasterNotificationQueue.TransformationType.Default);
                        }
                    }
                }
            }
            orig.Invoke(self, damageInfo);
        }


    }
}
