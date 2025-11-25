using HarmonyLib;
using R2API;
using RoR2;
using RoR2.ExpansionManagement;
using RoR2.Projectile;
using SivsContentPack.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SivsContentPack.Items
{
    internal class EnergyDrinkVoid : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("EnergyDrinkVoid");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayVoidSoda");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.EnergyDrinkVoid.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidSoda");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidSodaSingularity");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidSodaSwirly");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void SetUpExpansionRequirements(ref ItemDef itemDef)
        {
            
        }
        protected override void SetUpItemRelationships(ref ItemDef itemDef)
        {
            ItemDef soda = Addressables.LoadAssetAsync<ItemDef>("RoR2/Base/SprintBonus/SprintBonus.asset").WaitForCompletion();
            if (soda != null)
            {
                Content.SubmitPendingItemPair(new Content.PendingItemPair()
                {
                    item1 = soda,
                    item2 = itemDef,
                    relationshipType = Content.ItemRelationships.contagiousItem
                });
            }
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.10152F, -0.01062F, 0.04986F),
localAngles = new Vector3(84.62885F, 97.50381F, 249.0927F),
localScale = new Vector3(0.4F, 0.4F, 0.4F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.141F, 0.032F, 0.129F),
localAngles = new Vector3(79.11995F, 33.5396F, 225.153F),
localScale = new Vector3(0.3F, 0.3F, 0.3F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.1399F, 0.0188F, 0.0666F),
localAngles = new Vector3(82.98796F, 352.9673F, 145.1805F),
localScale = new Vector3(0.25503F, 0.25503F, 0.25503F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(1.14F, 2F, -0.38F),
localAngles = new Vector3(270F, 282.6426F, 0F),
localScale = new Vector3(2F, 2F, 2F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.069F, 0.173F, 0.115F),
localAngles = new Vector3(81.86362F, 156.2937F, 293.0987F),
localScale = new Vector3(0.4F, 0.4F, 0.4F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "FlowerBase",
localPos = new Vector3(-0.355F, 0.119F, 0.273F),
localAngles = new Vector3(270F, 225.0001F, 0F),
localScale = new Vector3(0.4F, 0.4F, 0.4F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.114F, 0.128F, 0.137F),
localAngles = new Vector3(87.72351F, 140.3445F, 281.4359F),
localScale = new Vector3(0.4F, 0.4F, 0.4F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.071F, 0.11F, 0.102F),
localAngles = new Vector3(87.7217F, 140.3441F, 281.4355F),
localScale = new Vector3(0.4F, 0.4F, 0.4F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.071F, 0.11F, 0.102F),
localAngles = new Vector3(87.72231F, 140.3445F, 281.4358F),
localScale = new Vector3(0.4F, 0.4F, 0.4F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-1.02F, 1.05F, 0.88F),
localAngles = new Vector3(87.72488F, 140.3451F, 281.4363F),
localScale = new Vector3(3F, 3F, 3F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.158F, -0.029F, 0.058F),
localAngles = new Vector3(84.02745F, 234.9039F, 17.58886F),
localScale = new Vector3(0.4F, 0.4F, 0.4F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "GunStock",
localPos = new Vector3(-0.0035F, -0.1331F, 0.019F),
localAngles = new Vector3(90F, 298.9576F, 0F),
localScale = new Vector3(0.25041F, 0.25041F, 0.25041F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.103F, 0.131F, 0.188F),
localAngles = new Vector3(35.43869F, 207.3286F, 16.06219F),
localScale = new Vector3(0.4F, 0.4F, 0.4F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.1008F, -0.037F, 0.0537F),
localAngles = new Vector3(75.06905F, 136.8462F, 283.6814F),
localScale = new Vector3(0.4F, 0.4F, 0.4F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(0.052F, 0.46F, 0.159F),
localAngles = new Vector3(78.81857F, 354.2007F, 70.22336F),
localScale = new Vector3(0.4F, 0.4F, 0.4F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-0.072F, -0.007F, -0.402F),
localAngles = new Vector3(0F, 353.1522F, 0.00001F),
localScale = new Vector3(0.4F, 0.4F, 0.4F)
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
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
            On.RoR2.CharacterMotor.OnLeaveStableGround += CharacterMotor_OnLeaveStableGround;
            On.RoR2.CharacterMotor.OnLanded += CharacterMotor_OnLanded;
        }

        private void CharacterMotor_OnLanded(On.RoR2.CharacterMotor.orig_OnLanded orig, CharacterMotor self)
        {
            orig.Invoke(self);
            CharacterBody cb = self.body;
            if (cb != null)
            {
                cb.statsDirty = true;
            }
        }

        private void CharacterMotor_OnLeaveStableGround(On.RoR2.CharacterMotor.orig_OnLeaveStableGround orig, CharacterMotor self)
        {
            orig.Invoke(self);
            CharacterBody cb = self.body;
            if (cb != null)
            {
                cb.statsDirty = true;
            }
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender != null)
            {
                Inventory i = sender.inventory;
                if (i != null)
                {
                    CharacterMotor cm = sender.characterMotor;
                    if (cm != null)
                    {
                        if (!cm.isGrounded)
                        {
                            int itemCount = i.GetItemCountEffective(Content.Items.EnergyDrinkVoid);
                            if (itemCount > 0)
                            {
                                args.moveSpeedMultAdd += Util.GetStackingBehavior(Configuration.Items.EnergyDrinkVoid.speedBonus, Configuration.Items.EnergyDrinkVoid.speedBonusStack, itemCount);
                            }
                        }
                    }
                }
            }
        }
    }
    internal class StickyBombVoid : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("StickyBombVoid");
            Content.Misc.VoidMine = Assets.AssetBundles.Items.LoadAsset<GameObject>("VoidMine");
            EntityStateMachine.FindByCustomName(Content.Misc.VoidMine, "Main").mainStateType = Content.SerializableEntityStates.EntityStateDictionary["VoidMine_Armed"];
            EntityStateMachine.FindByCustomName(Content.Misc.VoidMine, "Main").initialStateType = Content.SerializableEntityStates.EntityStateDictionary["VoidMine_Arming"];
            Content.contentPack.projectilePrefabs.AddItem<GameObject>(Content.Misc.VoidMine);
            Content.ProcTypes.stickyBombVoid = Content.CreateProcType();
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.StickyBombVoid.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matSBVFragment");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSBVAura");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidMineFlame");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidMineLight");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidMineProximity");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void SetUpExpansionRequirements(ref ItemDef itemDef)
        {

        }
        protected override void SetUpItemRelationships(ref ItemDef itemDef)
        {

            /*ItemDef.Pair[] idp = ItemCatalog.itemRelationships[DLC1Content.ItemRelationshipTypes.ContagiousItem];
            if (idp != null)
            {
                ItemDef.Pair pair = new ItemDef.Pair
                {
                    itemDef1 = RoR2Content.Items.StickyBomb, //energy drink
                    itemDef2 = itemDef //this one
                };
                idp.AddItem(pair);
            }*/
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            /*itemDisplayRules.Add("CommandoBody", [
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
            ]);*/
        }
        protected override void Hooks()
        {
            On.RoR2.GlobalEventManager.OnHitEnemy += GlobalEventManager_OnHitEnemy;
        }

        private void GlobalEventManager_OnHitEnemy(On.RoR2.GlobalEventManager.orig_OnHitEnemy orig, GlobalEventManager self, DamageInfo damageInfo, GameObject victim)
        {
            orig.Invoke(self, damageInfo, victim);
            if (damageInfo.procChainMask.HasProc(Content.ProcTypes.stickyBombVoid))
            {
                return;
            }
            GameObject attacker = damageInfo.attacker;
            if (attacker != null)
            {
                CharacterBody cb = attacker.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    CharacterMaster cm = cb.master;
                    if (cm != null)
                    {
                        Inventory i = cm.inventory;
                        int itemCount = i.GetItemCountEffective(Content.Items.StickyBombVoid);
                        if (itemCount > 0)
                        {
                            bool flag = RoR2.Util.CheckRoll(Configuration.Items.StickyBombVoid.procChance, cm);
                            if (flag)
                            {
                                float damageCoefficient = Util.GetStackingBehavior(Configuration.Items.StickyBombVoid.bombDamage, Configuration.Items.StickyBombVoid.bombDamageStack, itemCount);
                                ProcChainMask pcm = default;
                                pcm.AddProc(Content.ProcTypes.stickyBombVoid);
                                FireProjectileInfo fireProjectileInfo = new FireProjectileInfo
                                {
                                    crit = cb.RollCrit(),
                                    damage = damageInfo.damage * damageCoefficient,
                                    damageColorIndex = DamageColorIndex.Void,
                                    owner = attacker,
                                    position = damageInfo.position,
                                    procChainMask = pcm,
                                    projectilePrefab = Content.Misc.VoidMine,
                                    rotation = Quaternion.LookRotation(UnityEngine.Random.onUnitSphere),
                                };
                                ProjectileManager.instance.FireProjectile(fireProjectileInfo);
                            }
                        }
                    }
                }
            }
        }
    }

    internal class AegisVoid : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("StickyBombVoid");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.AegisVoid.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matSBVFragment");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSBVAura");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidMineFlame");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidMineLight");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidMineProximity");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void SetUpItemRelationships(ref ItemDef itemDef)
        {

            /*ItemDef.Pair[] idp = ItemCatalog.itemRelationships[DLC1Content.ItemRelationshipTypes.ContagiousItem];
            if (idp != null)
            {
                ItemDef.Pair pair = new ItemDef.Pair
                {
                    itemDef1 = RoR2Content.Items.StickyBomb, //energy drink
                    itemDef2 = itemDef //this one
                };
                idp.AddItem(pair);
            }*/
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            /*itemDisplayRules.Add("CommandoBody", [
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
            ]);*/
        }
        protected override void Hooks()
        {
            
        }

        public class AegisVoidController : CharacterBody.ItemBehavior
        {
            public float storedHealing;
        }
    }

}
