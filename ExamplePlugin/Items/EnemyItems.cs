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
using RoR2.Projectile;
using UnityEngine.AddressableAssets;
using System.Runtime.CompilerServices;
using RoR2.Navigation;
using EntityStates;
using SivsContentPack.CustomEntityStates.MiniConstructs;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using RoR2.Items;
using SivsContentPack.CustomEntityStates;
using HG;
using System.Collections;

namespace SivsContentPack.Items
{
    internal class BeetlePlush : ItemFactory
    {
        public static GameObject wardPrefab;
        private GameObject displayPrefabSitting;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("BeetlePlush");
            this.displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("displayBeetlePlush");
            this.displayPrefabSitting = Assets.AssetBundles.Items.LoadAsset<GameObject>("displayBeetlePlushSitting");
            wardPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("beetlePlushRegenWard");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.BeetlePlush.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matBeetlePlush");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matBeetleRegenWard");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.02809F, 0.38455F, -0.0464F),
localAngles = new Vector3(15.39845F, 0F, 0F),
localScale = new Vector3(0.13786F, 0.13786F, 0.13786F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.06077F, -0.00849F, -0.04399F),
localAngles = new Vector3(24.37812F, 303.2841F, 174.9294F),
localScale = new Vector3(0.13154F, 0.13154F, 0.13154F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.14729F, 0.38973F, -0.06951F),
localAngles = new Vector3(355.4513F, 334.9214F, 2.12547F),
localScale = new Vector3(0.1101F, 0.1101F, 0.1101F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefabSitting,childName = "Chest",
localPos = new Vector3(1.93261F, 2.70573F, 1.97903F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.11567F, 0.34132F, -0.12658F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.08601F, 0.08601F, 0.08601F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefabSitting,childName = "CalfBackL",
localPos = new Vector3(0.00002F, 0.71622F, -0.16383F),
localAngles = new Vector3(281.239F, 0F, 0F),
localScale = new Vector3(0.17743F, 0.17743F, 0.17743F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.12145F, 0.51174F, -0.28763F),
localAngles = new Vector3(30.26274F, 334.6649F, 357.2498F),
localScale = new Vector3(0.11326F, 0.11326F, 0.11326F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.20935F, 0.28801F, -0.01062F),
localAngles = new Vector3(33.30351F, 0F, 21.19352F),
localScale = new Vector3(0.12596F, 0.12596F, 0.12596F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefabSitting,childName = "ThighL",
localPos = new Vector3(-0.5631F, 0.17537F, 0.10236F),
localAngles = new Vector3(308.7712F, 250.4825F, 275.5301F),
localScale = new Vector3(0.10813F, 0.10813F, 0.10813F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefabSitting,childName = "Head",
localPos = new Vector3(0F, 0.07543F, 1.54077F),
localAngles = new Vector3(293.9564F, 11.5244F, 168.8417F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, 0.17714F, 0.03193F),
localAngles = new Vector3(23.39462F, 0F, 0F),
localScale = new Vector3(0.19032F, 0.19032F, 0.19032F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefabSitting,childName = "ThighR",
localPos = new Vector3(-0.10733F, 0.0055F, 0.03401F),
localAngles = new Vector3(293.1494F, 286.119F, 182.4866F),
localScale = new Vector3(0.08822F, 0.08633F, 0.08633F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefabSitting,childName = "Chest",
localPos = new Vector3(-0.1523F, 0.17416F, 0.14656F),
localAngles = new Vector3(293.9189F, 148.5369F, 9.52881F),
localScale = new Vector3(0.17371F, 0.17371F, 0.17371F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.01238F, 0.08893F, 0.07004F),
localAngles = new Vector3(17.50051F, 93.12395F, 79.1179F),
localScale = new Vector3(0.12075F, 0.12075F, 0.12075F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefabSitting,childName = "Chest",
localPos = new Vector3(0.14402F, 0.31735F, -0.6838F),
localAngles = new Vector3(74.23928F, 133.1555F, 320.9202F),
localScale = new Vector3(0.27243F, 0.27243F, 0.27243F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.27838F, -0.22148F, -0.18959F),
localAngles = new Vector3(284.5449F, 288.5071F, 165.1014F),
localScale = new Vector3(0.12024F, 0.12024F, 0.12024F)
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
                },
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefabSitting,
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
                },
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefabSitting,
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
                },
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefabSitting,
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
                    followerPrefab = displayPrefabSitting,childName = "Base",
localPos = new Vector3(-2.40815F, -9.36859F, -0.02229F),
localAngles = new Vector3(357.0298F, 20.77669F, 181.9599F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
        }
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
        }

        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/Beetle/BeetleBody.prefab",
                pickupDef = itemDef
            });
        }

        private void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            Inventory i = self.inventory;
            if (i != null)
            {
                self.AddItemBehavior<BeetlePlushBehaviourController>(i.GetItemCountEffective(Content.Items.BeetlePlush));
            }
        }

        public class BeetlePlushBehaviourController : CharacterBody.ItemBehavior
        {
            public int alliesNearby;
            private GameObject wardInstance;
            private SphereSearch sphereSearch;
            float radius;
            private void Awake()
            {
                this.sphereSearch = new SphereSearch();
            }

            private void OnDisable()
            {
                if (this.body)
                {
                    if (this.wardInstance)
                    {
                        GameObject.Destroy(this.wardInstance);
                    }
                    if (this.body.HasBuff(Content.Buffs.BeetleRegen))
                    {
                        this.body.RemoveBuff(Content.Buffs.BeetleRegen);
                    }
                }
            }

            private void FixedUpdate()
            {
                this.radius = Util.GetStackingBehavior(Configuration.Items.BeetlePlush.radius, Configuration.Items.BeetlePlush.radiusStack, stack);
                this.alliesNearby = CountNearbyAllies();
                ManageWardInstance();
                body.SetBuffCount(Content.Buffs.BeetleRegen.buffIndex, alliesNearby);
            }
            private void ManageWardInstance()
            {
                if (!this.wardInstance)
                {
                    this.wardInstance = GameObject.Instantiate(BeetlePlush.wardPrefab, body.transform);
                    wardInstance.GetComponent<NetworkedBodyAttachment>().AttachToGameObjectAndSpawn(base.gameObject, null);
                }
                Transform t = this.wardInstance.transform.Find("Radius, Spherical");
                if (t != null)
                {
                    t.transform.localScale = Vector3.one * this.radius;
                }
            }

            private int CountNearbyAllies()
            {
                HurtBox target = null;
                List<HurtBox> validTargets = new List<HurtBox>();
                this.sphereSearch.mask = LayerIndex.entityPrecise.mask;
                this.sphereSearch.origin = this.transform.position;
                this.sphereSearch.radius = radius;
                this.sphereSearch.queryTriggerInteraction = QueryTriggerInteraction.UseGlobal;
                this.sphereSearch.RefreshCandidates();
                TeamMask tm = new TeamMask();
                tm.AddTeam(TeamComponent.GetObjectTeam(this.body.gameObject));
                this.sphereSearch.FilterCandidatesByHurtBoxTeam(tm);
                this.sphereSearch.FilterCandidatesByDistinctHurtBoxEntities();
                this.sphereSearch.GetHurtBoxes(validTargets);
                this.sphereSearch.ClearCandidates();
                validTargets.Remove(validTargets.Find(hb => hb.healthComponent.body == this.body));
                return validTargets.Count;

            }
        }
    }
    internal class MiniWispOnKill : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("WispOnKill");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayWispOnKill");
            Content.ProcTypes.miniWispOnHit = Content.CreateProcType();
            Content.Misc.MiniWispProjectile = Assets.AssetBundles.Items.LoadAsset<GameObject>("MiniWispProjectile");
            ContentAddition.AddProjectile(Content.Misc.MiniWispProjectile);
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.WispOnKill.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matWispMineWisp");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matWispMineNapkin");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matMiniWispFire");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matArcaneCircleWisp");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matOmniRing1Generic");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0.9093F, 0F, -0.95171F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0.80345F, -0.44527F, -0.82662F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0.52456F, 0.69623F, -0.75745F),
localAngles = new Vector3(348.9992F, 269.9998F, 90.00011F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(7.10205F, -0.10845F, 5.03685F),
localAngles = new Vector3(270F, 180F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-0.66336F, -0.6714F, -0.6092F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-1.65748F, 0F, -1.20918F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-0.96214F, 0.00001F, -1.0001F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-0.97232F, -0.00001F, -1.00003F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-0.7689F, 0F, -0.99997F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-6.89785F, 0F, 4.99974F),
localAngles = new Vector3(90F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-1.17156F, 0F, -1.00006F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-0.72649F, 0F, -0.99996F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-0.31564F, 0.87153F, 0.68768F),
localAngles = new Vector3(90F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-0.65697F, 2.08137F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(-1.28336F, 2.86714F, 0.00367F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-1.33746F, -0.00367F, 1.01594F),
localAngles = new Vector3(270F, 90F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                },
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
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/Wisp/WispBody.prefab",
                pickupDef = itemDef
            });
        }
        protected override void Hooks()
        {
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
            On.RoR2.GlobalEventManager.OnHitEnemy += GlobalEventManager_OnHitEnemy;
        }

        private void GlobalEventManager_OnHitEnemy(On.RoR2.GlobalEventManager.orig_OnHitEnemy orig, GlobalEventManager self, DamageInfo damageInfo, GameObject victim)
        {
            orig.Invoke(self, damageInfo, victim);
            GameObject attacker = damageInfo.attacker;
            if (attacker != null)
            {
                CharacterBody cb = attacker.GetComponent<CharacterBody>();
                if(cb != null)
                {

                    MiniWispController mwc = cb.GetComponent<MiniWispController>();
                    if (mwc != null)
                    {
                        mwc.FireWisp(damageInfo, victim);
                    }
                }
            }
        }

        private void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            Inventory i = self.inventory;
            if(i != null)
            {
                int itemcount = i.GetItemCountEffective(Content.Items.WispOnKill);
                self.AddItemBehavior<MiniWispController>(itemcount);
            }
        }

        public class MiniWispController : CharacterBody.ItemBehavior
        {
            private int maxStacks
            {
                get
                {
                    return (int)Util.GetStackingBehavior(Configuration.Items.WispOnKill.wispMax, Configuration.Items.WispOnKill.wispMaxStack, stack);
                }
            }

            private void OnDisable()
            {
                if(body.GetBuffCount(Content.Buffs.MiniWispStock) > 0)
                {
                    body.SetBuffCount(Content.Buffs.MiniWispStock.buffIndex, 0);
                }
            }

            private float stockTimer;

            private void FixedUpdate()
            {
                if(this.stockTimer <= 0 && body.GetBuffCount(Content.Buffs.MiniWispStock) < maxStacks)
                {
                    body.AddBuff(Content.Buffs.MiniWispStock);
                    this.stockTimer = Configuration.Items.WispOnKill.wispRecoveryInterval;
                }
                else
                {
                    this.stockTimer -= Time.deltaTime;
                }
            }

            public void FireWisp(DamageInfo damageInfo, GameObject victim = null)
            {
                if(!(body.GetBuffCount(Content.Buffs.MiniWispStock) > 0) || damageInfo.procChainMask.HasProc(Content.ProcTypes.miniWispOnHit) || damageInfo.procCoefficient <= 0 || damageInfo.damage <= 0)
                {
                    return;
                }
                damageInfo.procChainMask.AddProc(Content.ProcTypes.miniWispOnHit);
                EffectManager.SimpleEffect(Content.Effects.MiniWispMuzzleFlash.prefab, body.corePosition, Quaternion.identity, true);
                FireProjectileInfo fpi = new FireProjectileInfo()
                {
                    projectilePrefab = Content.Misc.MiniWispProjectile,
                    crit = body.RollCrit(),
                    damage = damageInfo.damage * Configuration.Items.WispOnKill.wispDamageCoefficient,
                    damageColorIndex = DamageColorIndex.Item,
                    position = body.corePosition,
                    owner = body.gameObject,
                    procChainMask = damageInfo.procChainMask,
                    rotation = RoR2.Util.QuaternionSafeLookRotation(Vector3.up + UnityEngine.Random.insideUnitSphere * 0.1f),
                };
                if(victim != null)
                {
                    fpi.target = victim;
                }
                ProjectileManager.instance.FireProjectile(fpi);
                body.RemoveBuff(Content.Buffs.MiniWispStock);
                stockTimer = Configuration.Items.WispOnKill.wispRecoveryInterval;
            }
        }

        
    }
    internal class Tentacle : ItemFactory
    {
        public static GameObject tetherEffectPrefab;
        public static GameObject tetherAttachment;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("Tentacle");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayTentacle");
            tetherEffectPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("TentacleTether");
            tetherAttachment = Assets.AssetBundles.Items.LoadAsset<GameObject>("TentacleTetherOrigin");
            Content.ProcTypes.tentacle = Content.CreateProcType();
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Tentacle.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matTentacle");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTentacleLightning");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTentacleTether");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
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
            itemDisplayRules.Add("ChefBody", [
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
            ]);*/
        }
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            base.Hooks();
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
            On.RoR2.GlobalEventManager.OnHitEnemy += GlobalEventManager_OnHitEnemy;
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/Jellyfish/JellyfishBody.prefab",
                pickupDef = itemDef
            });
        }
        private void GlobalEventManager_OnHitEnemy(On.RoR2.GlobalEventManager.orig_OnHitEnemy orig, GlobalEventManager self, DamageInfo damageInfo, GameObject victim)
        {
            orig.Invoke(self, damageInfo, victim);
            GameObject attacker = damageInfo.attacker;
            if (attacker != null)
            {
                CharacterBody cb = damageInfo.attacker.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    Inventory i = cb.inventory;
                    if (i != null)
                    {
                        if (i.GetItemCountEffective(Content.Items.Tentacle) > 0)
                        {
                            CharacterMaster cm = cb.master;
                            if (cm != null)
                            {
                                bool flag = RoR2.Util.CheckRoll(Configuration.Items.Tentacle.procChance, cm);
                                if (flag && !damageInfo.procChainMask.HasProc(Content.ProcTypes.tentacle) && damageInfo.procCoefficient > 0f)
                                {
                                    TentacleBehaviourController tbc = attacker.GetComponent<TentacleBehaviourController>();
                                    if (tbc != null)
                                    {
                                        tbc.AddTether(damageInfo, victim);
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }

        private void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            Inventory i = self.inventory;
            if (i != null)
            {
                self.AddItemBehavior<TentacleBehaviourController>(i.GetItemCountEffective(Content.Items.Tentacle));
            }
        }

        public class TentacleBehaviourController : CharacterBody.ItemBehavior
        {
            private class TetherInstance
            {
                public TetherInstance() {
                    this.age = 0f;
                    this.timer = 0f;
                    markedForDeath = false;
                }
                public GameObject target;
                public bool markedForDeath;
                public float duration;
                public float age;
                public float damage;
                public float timer;
            }
            private TetherVfxOrigin vfxOrigin;
            private List<TetherInstance> tethers;
            private GameObject originInstance;
            private NetworkedBodyAttachment networkedBodyAttachment;
            private bool tethersDirty;
            private bool effectsDirty;
            private int GetMaxTethers()
            {
                int t = Configuration.Items.Tentacle.baseTetherLimit;
                CharacterBody cb = this.networkedBodyAttachment.attachedBody;
                if (cb)
                {
                    Inventory i = cb.inventory;
                    if (i != null)
                    {
                        t = (int)Util.GetStackingBehavior(Configuration.Items.Tentacle.baseTetherLimit, Configuration.Items.Tentacle.stackTetherLimit, i.GetItemCountEffective(Content.Items.Tentacle));
                    }
                }
                return t;
            }
            private void OnEnable()
            {
                if (!this.originInstance)
                {
                    this.originInstance = GameObject.Instantiate(Tentacle.tetherAttachment, this.gameObject.transform);
                    this.networkedBodyAttachment = this.originInstance.GetComponent<NetworkedBodyAttachment>();
                    this.networkedBodyAttachment.AttachToGameObjectAndSpawn(this.gameObject);
                    this.vfxOrigin = originInstance.GetComponent<TetherVfxOrigin>();
                    this.tethers = new List<TetherInstance>();
                }
            }

            private void OnDisable()
            {
                this.tethers = new List<TetherInstance>();
                tethersDirty = false;
                UpdateEffectInstances();
                if (this.originInstance)
                {
                    GameObject.Destroy(this.originInstance);
                }
            }

            private void Start()
            {
                this.tethers = new List<TetherInstance>();
            }

            public void AddTether(DamageInfo damageInfo, GameObject victim)
            {
                if (!victim || !this.networkedBodyAttachment)
                {
                    return;
                }
                if (damageInfo.procCoefficient == 0 || damageInfo.procChainMask.HasProc(Content.ProcTypes.tentacle))
                {
                    return;
                }
                if (tethers.Count >= GetMaxTethers() || tethers.Find(t => t.target == victim) != null) {
                    return;
                }
                CharacterBody cb = victim.GetComponent<CharacterBody>();
                if (cb == null)
                {
                    return;
                }
                TetherInstance ti = new TetherInstance();
                ti.duration = Util.GetStackingBehavior(Configuration.Items.Tentacle.tetherDuration, Configuration.Items.Tentacle.tetherDurationStack, stack) * damageInfo.procCoefficient;
                ti.damage = damageInfo.damage;
                ti.target = cb.gameObject;
                ti.markedForDeath = false;
                tethers.Add(ti);
                effectsDirty = true;

            }
            private void FixedUpdate()
            {
                foreach (var tether in tethers)
                {
                    UpdateTether(tether);
                }
                if (tethersDirty)
                {
                    DestroyTethers();
                }
                if (effectsDirty)
                {
                    UpdateEffectInstances();
                    effectsDirty = false;
                }
            }

            private void UpdateEffectInstances()
            {

                List<Transform> transforms = new List<Transform>();
                foreach (var tether in tethers)
                {
                    if(tether != null)
                    {

                        if (tether.target)
                        {
                            if (!tether.markedForDeath)
                            {

                                Transform t = tether.target.transform;
                                HealthComponent hc = tether.target.GetComponent<HealthComponent>();
                                if (hc != null)
                                {
                                    CharacterBody cb = hc.body;
                                    if (cb != null)
                                    {
                                        t = cb.coreTransform;
                                    }
                                }
                                transforms.Add(t);
                            }
                        }
                    }
                }
                this.vfxOrigin.SetTetheredTransforms(transforms);
            }

            private void UpdateTether(TetherInstance tether)
            {
                if (!this.networkedBodyAttachment || !this.networkedBodyAttachment.attachedBody || !this.networkedBodyAttachment.attachedBodyObject)
                {
                    return;
                }
                if(tether == null)
                {
                    return;
                }
                tether.timer += Time.deltaTime;
                tether.age += Time.deltaTime;
                if(tether.age >= tether.duration || !tether.target)
                {

                    tether.markedForDeath = true;
                    tethersDirty = true;
                    return;
                }
                HealthComponent hc = tether.target.GetComponent<HealthComponent>();
                if (!hc.alive)
                {
                    tether.markedForDeath = true;
                    tethersDirty = true;
                    return;
                }
                if (tether.timer >= (1f / (float)Configuration.Items.Tentacle.ticksPerSecond))
                {
                    ProcChainMask pcm = default(ProcChainMask);
                    pcm.AddProc(Content.ProcTypes.tentacle);
                    DamageInfo di = new DamageInfo()
                    {
                        attacker = this.body.gameObject,
                        crit = this.body.RollCrit(),
                        damage = (tether.damage / (float)Configuration.Items.Tentacle.ticksPerSecond),
                        position = tether.target.transform.position,
                        procCoefficient = 0.2f,
                        damageColorIndex = DamageColorIndex.Item,
                        damageType = DamageType.Generic,
                        procChainMask = pcm,
                    };
                    if (tether.target)
                    {
                        if (hc)
                        {
                            hc.TakeDamage(di);
                        }
                    }
                    tether.timer = 0f;
                }
            }

            private void DestroyTethers()
            {
                List<TetherInstance> newList = new List<TetherInstance>(tethers);
                foreach (var tether in newList)
                {
                    if (tether != null)
                    {
                        if (tether.markedForDeath)
                        {
                            tethers.Remove(tether);
                            effectsDirty = true;
                        }
                    }
                }
            }
        }
    }
    internal class Geode : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("Geode");
            this.displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayGeode");
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matGeode");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Geode.enabled.Value;
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.12525F, 0.12986F, 0.03175F),
localAngles = new Vector3(355.2912F, 70.90369F, 28.40833F),
localScale = new Vector3(0.06089F, 0.06089F, 0.06089F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Chest",
localPos = new Vector3(-0.0409F, 0.19525F, 0.16419F),
localAngles = new Vector3(330.1F, 0F, 0F),
localScale = new Vector3(0.04651F, 0.04651F, 0.04651F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.07393F, 0.12598F, 0.07693F),
localAngles = new Vector3(0F, 43.86044F, 0F),
localScale = new Vector3(0.07622F, 0.07622F, 0.07108F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.00003F, -0.00001F, 0.95605F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.60861F, 0.60861F, 0.60861F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.1937F, 0.00098F, -0.281F),
localAngles = new Vector3(354.4759F, 134.6001F, 185.5755F),
localScale = new Vector3(0.1029F, 0.1029F, 0.1029F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(-0.22655F, 0.00002F, 0.05217F),
localAngles = new Vector3(0F, 267.1615F, 0F),
localScale = new Vector3(0.13292F, 0.13292F, 0.13292F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CalfL",
localPos = new Vector3(-0.101F, 0.21324F, -0.01612F),
localAngles = new Vector3(0F, 260.9286F, 0F),
localScale = new Vector3(0.11173F, 0.11173F, 0.11173F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandR",
localPos = new Vector3(-0.02695F, 0.20118F, -0.00766F),
localAngles = new Vector3(7.34629F, 180F, 180F),
localScale = new Vector3(0.07305F, 0.07305F, 0.07305F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.12319F, 0.10016F, 0.00193F),
localAngles = new Vector3(0F, 270.897F, 0F),
localScale = new Vector3(0.08532F, 0.08532F, 0.08532F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Stomach",
localPos = new Vector3(0F, -0.42823F, -1.33555F),
localAngles = new Vector3(346.2773F, 180F, 180F),
localScale = new Vector3(0.70171F, 0.70171F, 0.70171F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.16508F, 0.11483F, 0.19122F),
localAngles = new Vector3(7.74437F, 20.54459F, 0F),
localScale = new Vector3(0.13561F, 0.13561F, 0.13561F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Backpack",
localPos = new Vector3(0F, 0.43103F, 0F),
localAngles = new Vector3(278.3041F, 180F, 180F),
localScale = new Vector3(0.06754F, 0.06754F, 0.06754F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.13539F, 0.08227F, 0F),
localAngles = new Vector3(17.02573F, 83.9696F, 0F),
localScale = new Vector3(0.08159F, 0.08159F, 0.08159F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.00001F, 0.10421F, 0.08923F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.07538F, 0.07538F, 0.07538F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0F, 0.19985F, -0.1498F),
localAngles = new Vector3(357.4286F, 180F, 180F),
localScale = new Vector3(0.08988F, 0.08988F, 0.08988F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(-0.12516F, 0F, -0.08908F),
localAngles = new Vector3(0F, 165.445F, 0F),
localScale = new Vector3(0.12009F, 0.12009F, 0.12009F)
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
                    followerPrefab = displayPrefab,childName = "Weapon",
localPos = new Vector3(0.00001F, -5.68862F, -0.00026F),
localAngles = new Vector3(86.97599F, 0F, 0F),
localScale = new Vector3(2.44245F, 2.44245F, 2.44245F)
                }
            ]);
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_GEODE_NAME", "Mourning Geode");
            LanguageAPI.Add("ITEM_GEODE_PICKUP", "Gain a burst of armor and regeneration on kill.");
            LanguageAPI.Add("ITEM_GEODE_DESCRIPTION", "Gain a burst of armor and regeneration on kill, increasing <style=cIsUtility>armor</style> by <style=cIsUtility>+15</style> <style=cStack>(+15 per stack)</style> and <style=cIsHealing>regeneration</style> by <style=cIsUtility>+95%</style> <style=cStack>(+35% per stack)</style> for <style=cIsUtility>1 second</style>.");
            string s = "To those who trample Mother Earth's fields," + Environment.NewLine + Environment.NewLine + "To those who tear down Her mighty mountains," + Environment.NewLine + Environment.NewLine + "To those who pollute Her sparkling waters," + Environment.NewLine + Environment.NewLine + "And to those who send Her children to the grave," + Environment.NewLine + Environment.NewLine + "Forget not the fury of those who mourn.";
            LanguageAPI.Add("ITEM_GEODE_LORE", "");
        }
        protected override void Hooks()
        {
            base.Hooks();
            On.RoR2.GlobalEventManager.OnCharacterDeath += GlobalEventManager_OnCharacterDeath;
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/Golem/GolemBody.prefab",
                pickupDef = itemDef
            });
        }
        private void GlobalEventManager_OnCharacterDeath(On.RoR2.GlobalEventManager.orig_OnCharacterDeath orig, GlobalEventManager self, DamageReport damageReport)
        {
            orig.Invoke(self, damageReport);
            ReadOnlyCollection<CharacterBody> bodies = CharacterBody.readOnlyInstancesList;
            foreach (var body in bodies)
            {
                if (body != null)
                {
                    Inventory i = body.inventory;
                    if (i != null)
                    {
                        int itemCount = i.GetItemCountEffective(Content.Items.Geode);
                        if (itemCount > 0)
                        {
                            float duration = Util.GetStackingBehavior(Configuration.Items.Geode.duration, Configuration.Items.Geode.durationStack, itemCount);
                            body.AddTimedBuff(Content.Buffs.GeodeArmor, duration);
                        }
                    }   
                }
            }
        }
    }
    internal class ImpEye : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ImpsEye");
            this.displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayImpEye");
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matDisplayImpEye");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPickupImpEye");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matImpEyeHolder");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.ImpEye.enabled.Value;
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Head",
localPos = new Vector3(0.00128F, 0.287F, 0.15793F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.46917F, 0.46917F, 0.46917F)
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
                },
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
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.00035F, 0.05543F, 0.11182F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.28612F, 0.28612F, 0.28612F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.38932F, 2.91665F, -1.00296F),
localAngles = new Vector3(306.7729F, 180F, 180F),
localScale = new Vector3(3.17756F, 3.17756F, 3.17756F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, 0.03136F, 0.10266F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.26487F, 0.26487F, 0.26487F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(-0.00001F, 0.03425F, 0.00001F),
localAngles = new Vector3(270F, 0.00001F, 0.00001F),
localScale = new Vector3(1.03457F, 1.03457F, 1.03457F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.17437F, 0.13217F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.31712F, 0.31712F, 0.31712F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.20078F, 0.15018F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.37609F, 0.37609F, 0.37609F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.06164F, 0.13648F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.26261F, 0.26261F, 0.26261F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule
                {
                    childName = "Head",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new Vector3(198.104f, 106.914f, -91.64999f),
                    localPos = new Vector3(-1.282005f, 1.762984f, 0.3611287f),
                    localScale = Vector3.one * 3.340857f
                },
                new ItemDisplayRule
                {
                    childName = "Head",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new Vector3(195.291f, 253.104f, -270.943f),
                    localPos = new Vector3(1.288987f, 1.762985f, 0.338928f),
                    localScale = Vector3.one * 3.340857f
                },
                new ItemDisplayRule
                {
                    childName = "Head",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new Vector3(189.522f, 118.388f, -93.59f),
                    localPos = new Vector3(-1.053009f, 2.679019f, 0.2590138f),
                    localScale = Vector3.one * 3.228076f
                },
                new ItemDisplayRule
                {
                    childName = "Head",
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    localAngles = new Vector3(193.757f, 241.53f, -271.418f),
                    localPos = new Vector3(1.063996f, 2.684004f, 0.2520248f),
                    localScale = Vector3.one * 3.228076f
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
                },
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
                    followerPrefab = displayPrefab,childName = "GunScope",
localPos = new Vector3(-0.07545F, -0.14716F, 0.30173F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.31431F, 0.31431F, 0.31431F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.00001F, 0.14524F, 0.12279F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.39676F, 0.39676F, 0.39676F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.14928F, 0.13144F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.29937F, 0.29937F, 0.29937F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.19986F, 0.06053F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1.41607F, 1.41607F, 1.41607F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.29392F, 0.12363F, 0F),
localAngles = new Vector3(270F, 0.00001F, 0F),
localScale = new Vector3(0.58758F, 0.58758F, 0.58758F)
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
                    followerPrefab = displayPrefab,childName = "Weapon",
localPos = new Vector3(0.00001F, -5.68862F, -0.00026F),
localAngles = new Vector3(86.97599F, 0F, 0F),
localScale = new Vector3(2.44245F, 2.44245F, 2.44245F)
                }
            ]);
        }
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.CharacterBody.RecalculateStats += CharacterBody_RecalculateStats;
            On.RoR2.HealthComponent.TakeDamage += HealthComponent_TakeDamage;
        }

        private void HealthComponent_TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            CharacterBody cb = self.body;
            if (cb != null) {

                GameObject attacker = damageInfo.attacker;
                if (attacker != null)
                {
                    CharacterBody attackerBody = attacker.GetComponent<CharacterBody>();
                    if (attackerBody != null)
                    {
                        Inventory i = attackerBody.inventory;
                        if (i != null)
                        {
                            int itemCount = i.GetItemCountEffective(Content.Items.ImpEye);
                            if (itemCount > 0)
                            {
                                int bleedStacks = cb.GetBuffCount(RoR2Content.Buffs.Bleeding);
                                if (bleedStacks > 0)
                                {
                                    float damageMult = Util.GetStackingBehavior(Configuration.Items.ImpEye.damageBonus, Configuration.Items.ImpEye.damageBonusStack, itemCount);
                                    damageInfo.damage *= (1 + (damageMult * bleedStacks));
                                    if (damageInfo.damageColorIndex == DamageColorIndex.Default)
                                    {
                                        damageInfo.damageColorIndex = DamageColorIndex.Bleed;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            orig.Invoke(self, damageInfo);
        }

        private void CharacterBody_RecalculateStats(On.RoR2.CharacterBody.orig_RecalculateStats orig, CharacterBody self)
        {
            orig.Invoke(self);
            if (GetEyeBleedStacks(self) > 0)
            {
                self.moveSpeed *= Configuration.Items.ImpEye.speedReductionMultiplier;
            }
        }

        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/Imp/ImpBody.prefab",
                pickupDef = itemDef
            });
        }

        private int GetEyeBleedStacks(CharacterBody victimBody)
        {
            int count = 0;
            DotController component = null;
            if (DotController.dotControllerLocator.TryGetValue(victimBody.gameObject.GetInstanceID(), out component))
            {
                if (component != null)
                {
                    foreach (var item in component.dotStackList)
                    {
                        if (item.dotIndex == DotController.DotIndex.Bleed)
                        {
                            GameObject attacker = item.attackerObject;
                            if (attacker != null)
                            {
                                CharacterBody attackerBody = attacker.GetComponent<CharacterBody>();
                                if (attackerBody != null)
                                {
                                    Inventory i = attackerBody.inventory;
                                    if (i != null)
                                    {
                                        if (i.GetItemCountEffective(Content.Items.ImpEye) > 0)
                                        {
                                            count++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }
    }
    internal class Tarbine : ItemFactory
    {
        public static GameObject controllerObject;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("Tarbine");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayTarbine");
            controllerObject = Assets.AssetBundles.Items.LoadAsset<GameObject>("TarbineController");

        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Tarbine.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matTrimSheetTarbine");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.24258F, 0.48772F, -0.10154F),
localAngles = new Vector3(0.65373F, 2.1475F, 180.8684F),
localScale = new Vector3(0.31368F, 0.31368F, 0.31368F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "BowBase",
localPos = new Vector3(0.15476F, -0.03655F, -0.06757F),
localAngles = new Vector3(76.94839F, 266.5255F, 173.148F),
localScale = new Vector3(0.17192F, 0.17192F, 0.17192F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MainWeapon",
localPos = new Vector3(-0.08301F, 0.24439F, 0.01984F),
localAngles = new Vector3(273.5631F, 180.0002F, 72.68876F),
localScale = new Vector3(0.41372F, 0.41372F, 0.41372F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(1.10256F, 0.79398F, 0.74331F),
localAngles = new Vector3(270.0906F, 82.16277F, 0F),
localScale = new Vector3(3.65828F, 3.65828F, 3.65828F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.21644F, 0.28003F, -0.08971F),
localAngles = new Vector3(352.6551F, 1.15913F, 171.0065F),
localScale = new Vector3(0.26062F, 0.26062F, 0.26062F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "WeaponPlatform",
localPos = new Vector3(0.26082F, 0.00275F, 0.25351F),
localAngles = new Vector3(270.6193F, 179.9989F, 356.7503F),
localScale = new Vector3(0.40663F, 0.40663F, 0.40663F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.2393F, 0.53908F, -0.00135F),
localAngles = new Vector3(3.74782F, 3.24735F, 349.056F),
localScale = new Vector3(0.22798F, 0.22798F, 0.22798F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.24365F, 0.28477F, -0.0703F),
localAngles = new Vector3(346.404F, 0F, 0F),
localScale = new Vector3(0.23398F, 0.23398F, 0.23398F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmL",
localPos = new Vector3(0.02855F, 0.24887F, 0.02727F),
localAngles = new Vector3(280.5746F, 266.4123F, 169.036F),
localScale = new Vector3(0.48646F, 0.48646F, 0.48646F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(2.85053F, 2.44671F, 1.31276F),
localAngles = new Vector3(333.3395F, 179.489F, 4.35609F),
localScale = new Vector3(1.95145F, 1.95145F, 1.95145F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleLeft",
localPos = new Vector3(0.2696F, -0.02222F, -0.44308F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.35533F, 0.35533F, 0.35533F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleSniper",
localPos = new Vector3(0F, 0F, 0F),
localAngles = new Vector3(0F, 0F, 99.09276F),
localScale = new Vector3(0.35787F, 0.35787F, 0.35787F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.18957F, 0.18225F, -0.25724F),
localAngles = new Vector3(336.0322F, 335.3099F, 0F),
localScale = new Vector3(0.39008F, 0.39008F, 0.39008F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.22571F, 0.32793F, -0.23261F),
localAngles = new Vector3(339.2098F, 351.4666F, 3.04862F),
localScale = new Vector3(0.31282F, 0.31282F, 0.31282F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.44213F, 0.46415F, -0.12049F),
localAngles = new Vector3(339.1494F, 15.45078F, 353.2446F),
localScale = new Vector3(0.2789F, 0.2789F, 0.2789F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.39313F, -0.22266F, -0.3608F),
localAngles = new Vector3(278.3754F, 180.0001F, 268.3808F),
localScale = new Vector3(0.38326F, 0.38326F, 0.38326F)
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
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void Hooks()
        {
            On.RoR2.CharacterBody.Awake += CharacterBody_Awake;
            On.RoR2.GlobalEventManager.OnHitEnemy += GlobalEventManager_OnHitEnemy;
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/ClayBruiser/ClayBruiserBody.prefab",
                pickupDef = itemDef
            });
        }
        private void CharacterBody_Awake(On.RoR2.CharacterBody.orig_Awake orig, CharacterBody self)
        {
            orig.Invoke(self);
            TarbineController tbc = self.gameObject.AddComponent<TarbineController>();
        }

        private void GlobalEventManager_OnHitEnemy(On.RoR2.GlobalEventManager.orig_OnHitEnemy orig, GlobalEventManager self, DamageInfo damageInfo, GameObject victim)
        {
            orig.Invoke(self, damageInfo, victim);
            GameObject attacker = damageInfo.attacker;
            if (attacker != null) {
                CharacterBody cb = attacker.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    Inventory i = cb.inventory;
                    if (i != null)
                    {
                        if (i.GetItemCountEffective(Content.Items.Tarbine) > 0)
                        {
                            TarbineController tc = cb.GetComponent<TarbineController>();
                            if (tc != null)
                            {
                                tc.NotifyTarbineController(ref damageInfo);
                            }
                        }
                    }
                }
            }
        }

        public class TarbineController : MonoBehaviour
        {

            private float hitTimer;

            public bool barrageActive;

            private int hitsLanded;

            private EntityStateMachine stateMachine;

            private GameObject controllerInstance;

            CharacterBody body
            {
                get
                {
                    return gameObject.GetComponent<CharacterBody>();
                }
            }

            public void NotifyTarbineController(ref DamageInfo damageInfo)
            {
                if (damageInfo.procCoefficient <= 0 || damageInfo.procChainMask.HasProc(Content.ProcTypes.tarbine))
                {
                    return;
                }
                GameObject attacker = damageInfo.attacker;
                if (attacker != null && attacker == this.gameObject)
                {
                    CharacterBody body = attacker.GetComponent<CharacterBody>();
                    if (body != null)
                    {
                        hitsLanded++;
                        hitTimer = Configuration.Items.Tarbine.attackWindowDuration * damageInfo.procCoefficient;
                        if (hitsLanded >= Configuration.Items.Tarbine.hitThreshold)
                        {
                            Util.ApplyVisualCountdownBuff(ref body, Content.Buffs.Tarbine, (int)Configuration.Items.Tarbine.barrageActiveDuration);
                        }
                    }
                }
            }
            private void Awake()
            {
                barrageActive = false;

                this.stateMachine = EntityStateMachine.FindByCustomName(this.gameObject, "Tarbine");
            }
            private void Start()
            {
                hitTimer = 0;
            }

            private void FixedUpdate()
            {
                if (!body.inventory)
                {
                    return;
                }
                bool flag = body.inventory.GetItemCountEffective(Content.Items.Tarbine) > 0;
                if (flag != this.controllerInstance)
                {
                    if (flag)
                    {
                        this.controllerInstance = UnityEngine.Object.Instantiate<GameObject>(controllerObject);
                        this.controllerInstance.GetComponent<NetworkedBodyAttachment>().AttachToGameObjectAndSpawn(base.gameObject, null);
                        EntityStateMachine.FindByCustomName(this.controllerInstance, "Tarbine").initialStateType = Content.SerializableEntityStates.EntityStateDictionary["TarbineIdle"];
                        EntityStateMachine.FindByCustomName(this.controllerInstance, "Tarbine").mainStateType = Content.SerializableEntityStates.EntityStateDictionary["TarbineIdle"];
                        return;
                    }
                    UnityEngine.Object.Destroy(this.controllerInstance);
                }
                if (hitTimer > 0)
                {
                    hitTimer -= Time.deltaTime;
                }
                else
                {
                    if (hitsLanded > 0)
                    {
                        hitsLanded = 0;
                    }
                }
            }
        }
    }
    internal class IgniteOnHit : ItemFactory
    {
        private GameObject procEffectPrefab;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("IgniteOnHit");
            Content.ProcTypes.igniteOnHit = Content.CreateProcType();
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.IgniteOnHit.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matFlameSac");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            //base.RegisterItemDisplayRules(ref itemDisplayRules);
        }
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.GlobalEventManager.OnHitEnemy += GlobalEventManager_OnHitEnemy;
        }

        private void GlobalEventManager_OnHitEnemy(On.RoR2.GlobalEventManager.orig_OnHitEnemy orig, GlobalEventManager self, DamageInfo damageInfo, GameObject victim)
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
                        int itemCount = i.GetItemCountEffective(Content.Items.IgniteOnHit);
                        if (itemCount > 0)
                        {
                            if (!damageInfo.procChainMask.HasProc(Content.ProcTypes.igniteOnHit))
                            {
                                if (RoR2.Util.CheckRoll(Configuration.Items.IgniteOnHit.procChance, cb.master))
                                {
                                    float duration = Util.GetStackingBehavior(Configuration.Items.IgniteOnHit.durationBase, Configuration.Items.IgniteOnHit.durationStack, itemCount);
                                    InflictDotInfo inflictDotInfo = new InflictDotInfo
                                    {
                                        attackerObject = attacker,
                                        victimObject = victim,
                                        totalDamage = new float?((damageInfo.damage * Configuration.Items.IgniteOnHit.burnDamageCoefficient) * (duration)),
                                        duration = duration,
                                        dotIndex = DotController.DotIndex.Burn,
                                    };
                                    StrengthenBurnUtils.CheckDotForUpgrade(i, ref inflictDotInfo);
                                    DotController.InflictDot(ref inflictDotInfo);
                                    damageInfo.procChainMask.AddProc(Content.ProcTypes.igniteOnHit);

                                }
                            }
                        }
                    }
                }

            }

            orig.Invoke(self, damageInfo, victim);
        }

        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/LemurianBruiser/LemurianBruiserBody.prefab",
                pickupDef = itemDef
            });
        }
    }
    internal class SmiteOnHit : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("SmiteOnHit");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplaySmiteOnHit");
            Content.Misc.Smite = Assets.AssetBundles.Items.LoadAsset<GameObject>("Smite");
            ContentAddition.AddProjectile(Content.Misc.Smite);
            Content.ProcTypes.smite = Content.CreateProcType();
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.SmiteOnHit.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matSpark");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSparkPFlame");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGreaterWispFire");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSmiteIndicatorWall");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGreaterWispTile");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-0.78991F, -0.00001F, -1.11035F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-0.61967F, -0.44528F, -0.82667F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0.18008F, -0.54169F, -0.75748F),
localAngles = new Vector3(340.5799F, 270F, 89.99994F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-5.59195F, -4.35387F, 5.03663F),
localAngles = new Vector3(270F, 180F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0.58678F, -0.67138F, -0.60916F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.91345F, 0F, -1.20924F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1F, 0F, -1F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1F, 0F, -1F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1F, 0F, -1F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(6.47746F, 0F, 4.99994F),
localAngles = new Vector3(90F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1F, 0F, -1F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1F, 0F, -1F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1F, 0.87154F, 0.68769F),
localAngles = new Vector3(90F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0.72143F, 2.08137F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(1.26279F, 2.57192F, 0.02806F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(-1.32172F, 0.00016F, -1.00251F),
localAngles = new Vector3(270F, 90F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                },
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
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.GlobalEventManager.OnHitEnemy += GlobalEventManager_OnHitEnemy;
        }

        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/GreaterWisp/GreaterWispBody.prefab",
                pickupDef = itemDef
            });
        }
        private void GlobalEventManager_OnHitEnemy(On.RoR2.GlobalEventManager.orig_OnHitEnemy orig, GlobalEventManager self, DamageInfo damageInfo, GameObject victim)
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
                        int itemCount = i.GetItemCountEffective(Content.Items.SmiteOnHit);
                        if (itemCount > 0)
                        {
                            if (!damageInfo.procChainMask.HasProc(Content.ProcTypes.smite))
                            {
                                if (RoR2.Util.CheckRoll(Configuration.Items.SmiteOnHit.procChance * damageInfo.procCoefficient, cb.master))
                                {
                                    damageInfo.procChainMask.AddProc(Content.ProcTypes.smite);
                                    CharacterBody vb = victim.GetComponent<CharacterBody>();
                                    if (vb != null)
                                    {
                                        Vector3 targetPos = victim.transform.position;
                                        int count = (int)Util.GetStackingBehavior(Configuration.Items.SmiteOnHit.smiteCount, Configuration.Items.SmiteOnHit.smiteCountStack, itemCount);
                                        for (int j = 0; j < count; j++)
                                        {
                                            float fuse = Util.GetStackingBehavior(Configuration.Items.SmiteOnHit.fuse, Configuration.Items.SmiteOnHit.fuseInterval, j + 1) / cb.attackSpeed;
                                            NodeGraph groundNodes = SceneInfo.instance.groundNodes;
                                            Vector3 position = Vector3.zeroVector;
                                            CharacterMotor cm = vb.characterMotor;
                                            if (cm != null)
                                            {
                                                targetPos += cm.velocity * fuse;
                                            }

                                            if (j > 0)
                                            {
                                                targetPos += (UnityEngine.Random.insideUnitSphere * Configuration.Items.SmiteOnHit.smiteDistance);
                                            }
                                            groundNodes.GetNodePosition(groundNodes.FindClosestNode(targetPos, HullClassification.Human), out position);
                                            FireProjectileInfo fpi = new FireProjectileInfo()
                                            {
                                                crit = cb.RollCrit(),
                                                damage = cb.damage * Configuration.Items.SmiteOnHit.damageCoefficient,
                                                owner = cb.gameObject,
                                                damageColorIndex = DamageColorIndex.Item,
                                                position = position,
                                                projectilePrefab = Content.Misc.Smite,
                                                procChainMask = damageInfo.procChainMask,
                                                useFuseOverride = true,
                                                fuseOverride = fuse,
                                                rotation = Quaternion.Euler(Vector3.one)
                                            };
                                            ProjectileManager.instance.FireProjectile(fpi);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

            orig.Invoke(self, damageInfo, victim);
        }
    }
    internal class BisonShield : ItemFactory
    {
        protected static GameObject dashEffect;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("BisonShield");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayBisonShield");
            dashEffect = Assets.AssetBundles.Items.LoadAsset<GameObject>("BisonChargeEffect");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.BighornBuckler.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matBisonShield");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matBisonShieldCharge");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matBisonShieldCharge 1");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmR",
localPos = new Vector3(-0.02932F, 0.15792F, -0.1047F),
localAngles = new Vector3(354.3701F, 177.3043F, 14.68527F),
localScale = new Vector3(0.25511F, 0.25511F, 0.25511F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmL",
localPos = new Vector3(0.00001F, 0.26107F, -0.09895F),
localAngles = new Vector3(358.4166F, 180F, 180F),
localScale = new Vector3(0.21323F, 0.21323F, 0.21323F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmR",
localPos = new Vector3(0.08162F, 0.1257F, 0.02174F),
localAngles = new Vector3(28.50939F, 86.39874F, 356.7976F),
localScale = new Vector3(0.20855F, 0.20855F, 0.20855F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HandR",
localPos = new Vector3(0.42493F, 2.37131F, 0.70879F),
localAngles = new Vector3(285.5587F, 3.50144F, 79.52834F),
localScale = new Vector3(2.86511F, 2.86511F, 2.86511F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmL",
localPos = new Vector3(-0.03191F, 0.18846F, -0.12272F),
localAngles = new Vector3(0F, 192.3681F, 175.0909F),
localScale = new Vector3(0.3156F, 0.3156F, 0.3156F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "FootFrontL",
localPos = new Vector3(-0.00006F, 0.55509F, -0.19731F),
localAngles = new Vector3(3.80246F, 180F, 180F),
localScale = new Vector3(0.38132F, 0.38132F, 0.38132F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MechUpperArmL",
localPos = new Vector3(0.12603F, 0.18845F, -0.01535F),
localAngles = new Vector3(0.23579F, 97.92215F, 178.3061F),
localScale = new Vector3(0.32786F, 0.32786F, 0.32786F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmR",
localPos = new Vector3(0F, 0.25349F, -0.16592F),
localAngles = new Vector3(352.7098F, 180F, 180F),
localScale = new Vector3(0.2962F, 0.2962F, 0.2962F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.14429F, -0.09016F, -0.01701F),
localAngles = new Vector3(21.50363F, 263.2782F, 168.1036F),
localScale = new Vector3(0.22963F, 0.22963F, 0.22963F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.00031F, 1.44343F, 1.74147F),
localAngles = new Vector3(6.11715F, 0.11646F, 181.0928F),
localScale = new Vector3(1.85177F, 1.85177F, 1.85177F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CannonHeadR",
localPos = new Vector3(-0.14807F, 0.40271F, 0.16113F),
localAngles = new Vector3(317.3624F, 314.9427F, 266.3971F),
localScale = new Vector3(0.29586F, 0.29586F, 0.29586F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmL",
localPos = new Vector3(0.0219F, 0.16117F, -0.07763F),
localAngles = new Vector3(6.6874F, 155.5844F, 0F),
localScale = new Vector3(0.19006F, 0.19006F, 0.19006F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(0.19981F, -0.21539F, 0.02746F),
localAngles = new Vector3(42.44398F, 82.49428F, 177.1701F),
localScale = new Vector3(0.29184F, 0.29184F, 0.29184F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmL",
localPos = new Vector3(0.00001F, 0.26965F, -0.14072F),
localAngles = new Vector3(6.98656F, 180F, 180F),
localScale = new Vector3(0.30766F, 0.30766F, 0.30766F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmR",
localPos = new Vector3(0.03143F, 0.45312F, 0.22614F),
localAngles = new Vector3(0F, 0F, 176.031F),
localScale = new Vector3(0.49177F, 0.49177F, 0.49177F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmR",
localPos = new Vector3(-0.02292F, 0.01438F, -0.11118F),
localAngles = new Vector3(352.78F, 191.6437F, 276.7111F),
localScale = new Vector3(0.31281F, 0.31281F, 0.31281F)
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
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_BISONSHIELD_NAME", "Bighorn Buckler");
            LanguageAPI.Add("ITEM_BISONSHIELD_PICKUP", "Damage enemies by sprinting into them. Recharges after 3 seconds.");
            LanguageAPI.Add("ITEM_BISONSHIELD_DESCRIPTION", "Increase your <style=cIsDamage>sprinting speed</style> by <style=cIsUtility>20%</style>. <style=cIsDamage>Sprint into an enemy</style> for <style=cIsDamage>275%</style> <style=cStack>(+185% per stack)</style> <style=cIsDamage>damage</style>, dealing <style=cIsUtility>more damage the faster you are moving</style>. Recharges after <style=cDeath>3 seconds</style>.");
            //LanguageAPI.Add("ITEM_BISONSHIELD_LORE", "");
        }
        protected override void Hooks()
        {
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
            On.RoR2.CharacterBody.OnBuffFinalStackLost += CharacterBody_OnBuffFinalStackLost;
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/Bison/BisonBody.prefab",
                pickupDef = itemDef
            });
        }

        private void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            if (self != null)
            {
                Inventory i = self.inventory;
                if (i != null)
                {
                    int count = i.GetItemCountEffective(Content.Items.BighornBuckler);
                    BisonShieldController bsc = self.AddItemBehavior<BisonShieldController>(count);
                    if (count > 0)
                    {
                        if (!self.HasBuff(Content.Buffs.BisonShieldActive) && !self.HasBuff(Content.Buffs.BisonShieldCooldown))
                        {
                            self.AddBuff(Content.Buffs.BisonShieldActive);
                        }
                    }
                }
            }
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            if (sender != null)
            {
                Inventory i = sender.inventory;
                if (i != null)
                {
                    int itemCount = i.GetItemCountEffective(Content.Items.BighornBuckler);
                    if (itemCount > 0)
                    {
                        if (sender.isSprinting)
                        {

                            args.moveSpeedMultAdd += Configuration.Items.BighornBuckler.sprintSpeedBonus;
                        }
                    }
                }
            }
        }

        private void CharacterBody_OnBuffFinalStackLost(On.RoR2.CharacterBody.orig_OnBuffFinalStackLost orig, CharacterBody self, BuffDef buffDef)
        {
            orig.Invoke(self, buffDef);
            if (self != null)
            {
                if (buffDef != null)
                {
                    if (buffDef == Content.Buffs.BisonShieldCooldown)
                    {
                        Inventory i = self.inventory;
                        if (i != null)
                        {
                            int count = i.GetItemCountEffective(Content.Items.BighornBuckler);
                            if (count > 0)
                            {
                                self.AddBuff(Content.Buffs.BisonShieldActive);
                            }
                        }
                    }
                }
            }
        }

        private class BisonShieldController : CharacterBody.ItemBehavior
        {
            private GameObject effectInstance;

            private OverlapAttack attack;

            private float resetTimer;

            private void Start()
            {
                resetTimer = 0f;
            }
            private void RefreshAttack()
            {
                float damageCoefficient = Util.GetStackingBehavior(Configuration.Items.BighornBuckler.damageCoefficient, Configuration.Items.BighornBuckler.damageCoefficientStack, stack);
                float speedDamageMult = (this.body.moveSpeed / (this.body.baseMoveSpeed * this.body.sprintingSpeedMultiplier));
                this.attack = new OverlapAttack()
                {
                    attacker = this.body.gameObject,
                    hitBoxGroup = this.effectInstance.GetComponent<HitBoxGroup>(),
                    hitEffectPrefab = EntityStates.Bison.Charge.hitEffectPrefab,
                    attackerFiltering = AttackerFiltering.AlwaysHit,
                    procCoefficient = 1f,
                    damage = (this.body.damage * damageCoefficient) * speedDamageMult,
                    damageType = DamageType.Stun1s,
                    damageColorIndex = DamageColorIndex.Item,
                    pushAwayForce = Configuration.Items.BighornBuckler.knockbackForce,
                    isCrit = this.body.RollCrit(),
                    procChainMask = default(ProcChainMask),
                    forceVector = this.body.coreTransform.forward,
                    teamIndex = this.body.teamComponent.teamIndex,
                    retriggerTimeout = Configuration.Items.BighornBuckler.refreshInterval
                };
            }
            private void FixedUpdate()
            {
                if (this.stack > 0)
                {
                    if (this.body.isSprinting && this.body.HasBuff(Content.Buffs.BisonShieldActive))
                    {
                        
                        if (!this.effectInstance)
                        {
                            Transform t = this.body.coreTransform;
                            ModelLocator ml = this.body.modelLocator;
                            if (ml != null) {
                                t = ml.modelBaseTransform;
                            }
                            this.effectInstance = GameObject.Instantiate(BisonShield.dashEffect, t.position, t.rotation, t);
                            this.effectInstance.transform.Translate(this.body.transform.up);
                            RefreshAttack();
                        }
                        else
                        {
                            if (resetTimer > 0)
                            {
                                resetTimer -= Time.deltaTime;
                                if (resetTimer <= 0)
                                {
                                    RefreshAttack();
                                    resetTimer = Configuration.Items.BighornBuckler.refreshInterval;
                                }
                            }
                            this.attack.Fire(null);
                        }
                    }
                    else
                    {
                        if (this.effectInstance)
                        {
                            this.attack = null;
                            GameObject.DestroyImmediate(this.effectInstance);
                            if (!this.body.HasBuff(Content.Buffs.BisonShieldCooldown))
                            {
                                this.body.RemoveBuff(Content.Buffs.BisonShieldActive);
                                Util.ApplyVisualCountdownBuff(ref body, Content.Buffs.BisonShieldCooldown, (int)Configuration.Items.BighornBuckler.rechargeTime);
                            }
                        }

                    }
                }
                else
                {
                    if (this.effectInstance != null)
                    {
                        this.attack = null;
                        GameObject.DestroyImmediate(this.effectInstance.gameObject);
                    }
                }
            }

            private void OnDisable()
            {
                if (this.effectInstance)
                {
                    UnityEngine.GameObject.DestroyImmediate(this.effectInstance);
                }
                if (this.attack != null)
                {
                    attack = null;
                }
            }
        }
    }
    internal class GriefFlower : ItemFactory
    {
        private GameObject procEffectPrefab;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("GriefFlower");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayGriefFlower");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.GriefFlower.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matGriefFlower");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/Parent/ParentBody.prefab",
                pickupDef = itemDef
            });
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.10775F, 0.27163F, 0.21865F),
localAngles = new Vector3(67.03082F, 64.72299F, 63.243F),
localScale = new Vector3(0.16665F, 0.16665F, 0.16665F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.0858F, 0.31905F, -0.04365F),
localAngles = new Vector3(36.10521F, 68.92094F, 333.0376F),
localScale = new Vector3(0.23267F, 0.23267F, 0.23267F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.1195F, 0.26277F, 0.13981F),
localAngles = new Vector3(70.27785F, 0F, 22.75502F),
localScale = new Vector3(0.1486F, 0.1486F, 0.1486F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(1.86644F, 1.83212F, 3.31651F),
localAngles = new Vector3(89.31244F, 0F, 0F),
localScale = new Vector3(1.46563F, 1.46563F, 1.46563F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0.08901F, 0.07846F, 0F),
localAngles = new Vector3(3.89079F, 354.8297F, 297.8478F),
localScale = new Vector3(0.18846F, 0.18846F, 0.18846F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "FlowerBase",
localPos = new Vector3(-0.14464F, 0.01071F, 1.02277F),
localAngles = new Vector3(73.61587F, 0F, 0F),
localScale = new Vector3(0.57831F, 0.57831F, 0.57831F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.10287F, 0.23344F, 0.06313F),
localAngles = new Vector3(10.36831F, 342.5818F, 299.8412F),
localScale = new Vector3(0.21356F, 0.21356F, 0.21356F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.12072F, 0.19073F, 0.17406F),
localAngles = new Vector3(73.50643F, 0F, 11.91765F),
localScale = new Vector3(0.12402F, 0.12402F, 0.12402F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.08238F, 0.27977F, 0.19002F),
localAngles = new Vector3(76.92883F, 0F, 15.99473F),
localScale = new Vector3(0.17361F, 0.17361F, 0.17361F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.31004F, 2.62608F, 1.42197F),
localAngles = new Vector3(82.55009F, 333.5768F, 328.509F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.18255F, 0.25534F, 0.22752F),
localAngles = new Vector3(83.92756F, 0F, 11.34614F),
localScale = new Vector3(0.11402F, 0.11402F, 0.11402F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.12122F, 0.10657F, 0.0585F),
localAngles = new Vector3(49.71027F, 0F, 47.23411F),
localScale = new Vector3(0.20097F, 0.20097F, 0.20097F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.09001F, 0.14822F, 0.15771F),
localAngles = new Vector3(39.20588F, 330.5676F, 318.2481F),
localScale = new Vector3(0.21285F, 0.21285F, 0.21285F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.08813F, 0.20917F, 0.04961F),
localAngles = new Vector3(62.09298F, 0F, 0F),
localScale = new Vector3(0.15785F, 0.15785F, 0.15785F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.34931F, 0.2048F, 0.24201F),
localAngles = new Vector3(75.40274F, 0F, 334.1322F),
localScale = new Vector3(0.12776F, 0.12776F, 0.12776F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.23465F, -0.02824F, -0.40221F),
localAngles = new Vector3(315.8733F, 306.9055F, 75.0076F),
localScale = new Vector3(0.26119F, 0.26119F, 0.26119F)
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
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.GlobalEventManager.OnCharacterDeath += GlobalEventManager_OnCharacterDeath;
        }

        private void GlobalEventManager_OnCharacterDeath(On.RoR2.GlobalEventManager.orig_OnCharacterDeath orig, GlobalEventManager self, DamageReport damageReport)
        {
            orig.Invoke(self, damageReport);
            ReadOnlyCollection<CharacterBody> bodyInstances = CharacterBody.readOnlyInstancesList;
            foreach (var body in bodyInstances)
            {
                if (body != null)
                {
                    TeamComponent tc = body.teamComponent;
                    if (tc != null)
                    {
                        if (damageReport.victimBody != body)
                        {
                            TeamComponent vc = damageReport.victimBody.teamComponent;
                            if (vc != null)
                            {
                                if (tc.teamIndex == vc.teamIndex) //alhamdulilah they are allies
                                {
                                    Inventory i = body.inventory;
                                    if (i != null)
                                    {
                                        int itemcount = i.GetItemCountEffective(Content.Items.GriefFlower);
                                        if (itemcount > 0)
                                        {
                                            float duration = Util.GetStackingBehavior(Configuration.Items.GriefFlower.buffDuration, Configuration.Items.GriefFlower.buffStack, itemcount);
                                            EffectData ed = new EffectData
                                            {
                                                origin = body.corePosition,
                                                start = body.corePosition,
                                                rotation = body.coreTransform.rotation
                                            };
                                            EffectManager.SpawnEffect(Content.Effects.GriefProc.prefab, ed, true);
                                            RoR2.Util.PlaySound("Play_item_proc_warCry", body.gameObject);
                                            body.AddTimedBuff(Content.Buffs.Grief, duration);
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
    internal class MeleeAttackSpeed : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("MeleeAttackSpeed");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.MeleeAttackSpeed.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matTooth");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matToothOverlay");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            
        }
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
        }

        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/DLC1/Vermin/VerminBody.prefab",
                pickupDef = itemDef
            });
        }

        private void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            Inventory i = self.inventory;
            if (i != null)
            {
                self.AddItemBehavior<MeleeAttackSpeedController>(i.GetItemCountEffective(Content.Items.MeleeAttackSpeed));
            }
        }

        public class MeleeAttackSpeedController : CharacterBody.ItemBehavior
        {

            private SphereSearch sphereSearch;
            private void Awake()
            {
                this.sphereSearch = new SphereSearch();
            }

            private void OnDisable()
            {
                if (this.body)
                {
                    if (this.body.HasBuff(Content.Buffs.MeleeAttackSpeed))
                    {
                        this.body.RemoveBuff(Content.Buffs.MeleeAttackSpeed);
                    }
                }
            }

            private void FixedUpdate()
            {
                if (this.body)
                {
                    this.body.SetBuffCount(Content.Buffs.MeleeAttackSpeed.buffIndex, IsEnemyNearby() ? 1 : 0);
                }
            }

            private bool IsEnemyNearby()
            {
                List<HurtBox> validTargets = new List<HurtBox>();
                this.sphereSearch.mask = LayerIndex.entityPrecise.mask;
                this.sphereSearch.origin = this.transform.position;
                this.sphereSearch.radius = Configuration.Items.MeleeAttackSpeed.distance;
                this.sphereSearch.queryTriggerInteraction = QueryTriggerInteraction.UseGlobal;
                this.sphereSearch.RefreshCandidates();
                this.sphereSearch.FilterCandidatesByHurtBoxTeam(TeamMask.GetEnemyTeams(body.teamComponent.teamIndex));
                this.sphereSearch.FilterCandidatesByDistinctHurtBoxEntities();
                this.sphereSearch.GetHurtBoxes(validTargets);
                this.sphereSearch.ClearCandidates();
                return validTargets.Count > 0;

            }
        }
    }
    internal class ProjectileKiller : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ProjectileKiller");
            Content.DeployableSlots.ProjectileKiller = Content.CreateDeployableSlot();
            Content.Misc.ProjectileKillerPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("ProjectileKillerPrefab");
            Content.Misc.ProjectileKillerPrefab.AddComponent<ProjectileKillerComponent>();
            ProjectileDeployToOwner pdto = Content.Misc.ProjectileKillerPrefab.GetComponent<ProjectileDeployToOwner>();
            if (pdto != null)
            {
                pdto.deployableSlot = Content.DeployableSlots.ProjectileKiller;
            }
            ContentAddition.AddProjectile(Content.Misc.ProjectileKillerPrefab);
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.ProjectileKiller.enabled.Value;
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/Bell/BellBody.prefab",
                pickupDef = itemDef
            });
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matBellTrimsheet");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matOmniExplosionProjectileKiller");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matOmniHitsparkProjectileKiller");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPKRangeIndicator");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPKSoundwave");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPKSoundwave");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            
        }
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.CharacterMaster.GetDeployableSameSlotLimit += CharacterMaster_GetDeployableSameSlotLimit;
            On.RoR2.GlobalEventManager.OnHitEnemy += GlobalEventManager_OnHitEnemy;
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
                    Inventory i = cb.inventory;
                    if (i != null)
                    {
                        int itemCount = i.GetItemCountEffective(Content.Items.ProjectileKiller);
                        if (itemCount > 0)
                        {
                            float fuse = Util.GetStackingBehavior(Configuration.Items.ProjectileKiller.fuse, Configuration.Items.ProjectileKiller.fuseStack, itemCount);
                            bool flag = false;
                            CharacterMaster cm = cb.master;
                            if(cm != null)
                            {
                                flag = !cm.IsDeployableLimited(Content.DeployableSlots.ProjectileKiller);
                            }
                            if (flag && (damageInfo.damage >= cb.damage * 4f))
                            {
                                BlastAttack ba = new BlastAttack()
                                {
                                    radius = Configuration.Items.ProjectileKiller.radius,
                                    damageType = DamageType.Stun1s,
                                    baseDamage = damageInfo.damage * Configuration.Items.ProjectileKiller.damageCoefficient,
                                    attacker = attacker,
                                    canRejectForce = false,
                                    baseForce = 50f,
                                    damageColorIndex = DamageColorIndex.Item,
                                    falloffModel = BlastAttack.FalloffModel.None,
                                    position = damageInfo.position,
                                    crit = cb.RollCrit(),
                                    procChainMask = default,
                                    procCoefficient = 1f,
                                    teamIndex = cb.teamComponent.teamIndex,
                                };
                                FireProjectileInfo fpi = new FireProjectileInfo()
                                {
                                    crit = cb.RollCrit(),
                                    damage = 0f,
                                    position = damageInfo.position,
                                    owner = attacker,
                                    fuseOverride = fuse,
                                    useFuseOverride = true,
                                    procChainMask = default,
                                    projectilePrefab = Content.Misc.ProjectileKillerPrefab,
                                    rotation = Quaternion.identity
                                };
                                ProjectileManager.instance.FireProjectile(fpi);
                            }
                        }
                    }
                }
            }
        }

        private int CharacterMaster_GetDeployableSameSlotLimit(On.RoR2.CharacterMaster.orig_GetDeployableSameSlotLimit orig, CharacterMaster self, DeployableSlot slot)
        {
            if (slot == Content.DeployableSlots.ProjectileKiller)
            {
                return 1;
            }
            return orig.Invoke(self, slot);
        }

        public class ProjectileKillerComponent : MonoBehaviour
        {
            public static float searchInterval = 0.2f;

            private ProjectileController projectileController;
            private float timer;

            private SphereSearch sphereSearch = new SphereSearch();
            private void Awake()
            {
                this.projectileController = gameObject.GetComponent<ProjectileController>();
            }
            private void Start()
            {
                timer = 0f;
                sphereSearch = new SphereSearch();
            }

            private void FixedUpdate()
            {
                if(timer <= 0f)
                {
                    DeleteProjectiles();
                    //FireBlast();
                    timer = ProjectileKillerComponent.searchInterval;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }

            private void FireBlast()
            {
                List<HurtBox> validTargets = new List<HurtBox>();
                this.sphereSearch.mask = LayerIndex.entityPrecise.mask;
                this.sphereSearch.origin = this.transform.position;
                this.sphereSearch.radius = Configuration.Items.ProjectileKiller.radius;
                this.sphereSearch.queryTriggerInteraction = QueryTriggerInteraction.UseGlobal;
                this.sphereSearch.RefreshCandidates();
                this.sphereSearch.FilterCandidatesByHurtBoxTeam(TeamMask.GetEnemyTeams(projectileController.teamFilter.teamIndex));
                this.sphereSearch.FilterCandidatesByDistinctHurtBoxEntities();
                this.sphereSearch.GetHurtBoxes(validTargets);
                this.sphereSearch.ClearCandidates();
                int num = 0;
                int count = validTargets.Count;
                while (num < count)
                {
                    HurtBox target = validTargets[num];
                    if (target != null)
                    {
                        HealthComponent hc = target.healthComponent;
                        if(hc != null)
                        {
                            CharacterBody cb = hc.body;
                            if(cb != null)
                            {
                                SetStateOnHurt ssoh = cb.gameObject.GetComponent<SetStateOnHurt>();
                                if(ssoh != null)
                                {
                                    if (ssoh.canBeStunned)
                                    {
                                        ssoh.SetStun(1f);
                                    }
                                }
                            }
                        }
                    }
                    num++;
                }

            }

            private void DeleteProjectiles()
            {
                Vector3 vector = this.gameObject.transform.position;
                TeamIndex teamIndex = this.projectileController.teamFilter.teamIndex;
                float num = Configuration.Items.ProjectileKiller.radius * Configuration.Items.ProjectileKiller.radius;
                int num2 = 0;
                List<ProjectileController> instancesList = InstanceTracker.GetInstancesList<ProjectileController>();
                List<ProjectileController> list = new List<ProjectileController>();
                int num3 = 0;
                int count = instancesList.Count;
                while (num3 < count)
                {
                    ProjectileController projectileController = instancesList[num3];
                    float dist = (projectileController.transform.position - vector).sqrMagnitude;
                    Vector3 vect = (projectileController.transform.position - vector).normalized;
                    if (!projectileController.cannotBeDeleted && projectileController.teamFilter.teamIndex != teamIndex && dist < num)
                    {
                        list.Add(projectileController);
                        num2++;
                    }
                    num3++;
                }
                int i = 0;
                int count2 = list.Count;
                while (i < count2)
                {
                    ProjectileController projectileController2 = list[i];
                    if (projectileController2)
                    {
                        GameObject.Destroy(projectileController2.gameObject);
                    }
                    i++;
                }
            }
        }
    }
    internal class MushroomOnKill : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("MushroomOnKill");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayMushroom");
            Content.DeployableSlots.Mushroom = Content.CreateDeployableSlot();
            Content.Misc.MushroomSpawner = Assets.AssetBundles.Items.LoadAsset<GameObject>("MushroomSpawner");
            Content.Misc.MushroomWard = Assets.AssetBundles.Items.LoadAsset<GameObject>("MushroomWard");
            ProjectileDeployToOwner pdto = Content.Misc.MushroomWard.GetComponent<ProjectileDeployToOwner>();
            if (pdto != null)
            {
                pdto.deployableSlot = Content.DeployableSlots.Mushroom;
            }
            ContentAddition.AddProjectile(Content.Misc.MushroomWard);
            ContentAddition.AddProjectile(Content.Misc.MushroomSpawner);
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/MiniMushroom/MiniMushroomBody.prefab",
                pickupDef = itemDef
            });
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.MushroomOnKill.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matMushroom");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matMushroomSpore");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSporeGas");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSporeGrenade");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSporeGrenadeTrail");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTeamAreaIndicatorIntersectionMonster");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTeamAreaIndicatorIntersectionPlayer");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.05677F, 0.12249F, 0.01555F),
localAngles = new Vector3(7.87754F, 98.90343F, 96.62351F),
localScale = new Vector3(0.40132F, 0.40132F, 0.40132F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(0.00842F, 0.11834F, -0.00919F),
localAngles = new Vector3(37.18677F, 356.9002F, 174.88F),
localScale = new Vector3(0.3262F, 0.3262F, 0.3262F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighR",
localPos = new Vector3(-0.07152F, 0.20331F, 0.00222F),
localAngles = new Vector3(0.16706F, 91.77269F, 174.6181F),
localScale = new Vector3(0.2643F, 0.2643F, 0.2643F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(0.30179F, -0.00004F, -0.06013F),
localAngles = new Vector3(10.31503F, 274.2498F, 208.5002F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(0F, 0F, 0F),
localAngles = new Vector3(23.53026F, 78.4958F, 180.966F),
localScale = new Vector3(0.30061F, 0.30061F, 0.30061F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "FlowerBase",
localPos = new Vector3(0.85354F, 0.04148F, 0.17941F),
localAngles = new Vector3(0F, 222.2735F, 355.6768F),
localScale = new Vector3(0.51116F, 0.51116F, 0.51116F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(0F, 0.10329F, 0.0091F),
localAngles = new Vector3(33.76705F, 44.53417F, 189.3828F),
localScale = new Vector3(0.27923F, 0.27923F, 0.27923F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.00429F, 0.01322F, -0.07284F),
localAngles = new Vector3(18.278F, 10.06128F, 183.185F),
localScale = new Vector3(0.34141F, 0.34141F, 0.34141F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.02778F, 0.03246F, -0.09061F),
localAngles = new Vector3(13.16411F, 63.94963F, 193.6792F),
localScale = new Vector3(0.25328F, 0.25328F, 0.25328F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(1.50377F, 1.73874F, 3.91336F),
localAngles = new Vector3(3.4381F, 273.6829F, 317.0254F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.06575F, 0.08843F, -0.00061F),
localAngles = new Vector3(4.14545F, 89.51409F, 179.9649F),
localScale = new Vector3(0.24678F, 0.24678F, 0.24678F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Backpack",
localPos = new Vector3(0.17446F, 0.16099F, -0.11522F),
localAngles = new Vector3(0F, 331.3186F, 0F),
localScale = new Vector3(0.14567F, 0.14567F, 0.14567F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.07044F, 0.05901F, -0.18649F),
localAngles = new Vector3(337.7577F, 1.19961F, 20.61512F),
localScale = new Vector3(0.31285F, 0.31285F, 0.31285F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(0F, 0.05115F, 0.03227F),
localAngles = new Vector3(20.36141F, 180F, 219.5785F),
localScale = new Vector3(0.2683F, 0.2683F, 0.2683F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ClavL",
localPos = new Vector3(-0.19149F, 0.60755F, 0.00996F),
localAngles = new Vector3(31.46281F, 95.15421F, 259.4856F),
localScale = new Vector3(0.3205F, 0.3205F, 0.3205F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleOven",
localPos = new Vector3(0.25589F, -0.00001F, -0.26072F),
localAngles = new Vector3(0F, 79.02937F, 0F),
localScale = new Vector3(0.18837F, 0.18837F, 0.18837F)
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
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.GlobalEventManager.OnCharacterDeath += GlobalEventManager_OnCharacterDeath;
            On.RoR2.CharacterMaster.GetDeployableSameSlotLimit += CharacterMaster_GetDeployableSameSlotLimit;
        }

        private int CharacterMaster_GetDeployableSameSlotLimit(On.RoR2.CharacterMaster.orig_GetDeployableSameSlotLimit orig, CharacterMaster self, DeployableSlot slot)
        {
            if (slot == Content.DeployableSlots.Mushroom)
            {
                Inventory i = self.inventory;
                if (i != null)
                {
                    int itemCount = i.GetItemCountEffective(Content.Items.MushroomOnKill);
                    if (itemCount > 0)
                    {
                        return (int)Util.GetStackingBehavior(Configuration.Items.MushroomOnKill.mushroomCount, Configuration.Items.MushroomOnKill.mushroomStack, itemCount);
                    }
                }
            }
            return orig.Invoke(self, slot);
        }

        private void GlobalEventManager_OnCharacterDeath(On.RoR2.GlobalEventManager.orig_OnCharacterDeath orig, GlobalEventManager self, DamageReport damageReport)
        {
            orig.Invoke(self, damageReport);
            CharacterBody cb = damageReport.attackerBody;
            if (cb != null)
            {
                Inventory i = cb.inventory;
                if (i != null)
                {
                    int itemCount = i.GetItemCountEffective(Content.Items.MushroomOnKill);
                    if (itemCount > 0)
                    {
                        CharacterMaster cm = cb.master;
                        if (cm != null)
                        {
                            bool flag = cm.IsDeployableLimited(Content.DeployableSlots.Mushroom);
                            if (!flag)
                            {
                                float damageCoefficient = Util.GetStackingBehavior(Configuration.Items.MushroomOnKill.damagePerSecond, Configuration.Items.MushroomOnKill.damagePerSecondStack, itemCount);
                                FireProjectileInfo fpi = new FireProjectileInfo
                                {
                                    crit = cb.RollCrit(),
                                    damage = cb.damage * damageCoefficient,
                                    owner = cb.gameObject,
                                    position = damageReport.damageInfo.position,
                                    procChainMask = default,
                                    rotation = RoR2.Util.QuaternionSafeLookRotation(Vector3.up),
                                    projectilePrefab = Content.Misc.MushroomSpawner,
                                    speedOverride = 0.5f,
                                    useSpeedOverride = true,
                                };
                                ProjectileManager.instance.FireProjectile(fpi);
                            }
                        }
                    }
                }
            }
        }
    }
    internal class DoubleProjectiles : ItemFactory
    {
        protected List<GameObject> blacklist = new List<GameObject>()
        {

        };
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("DoubleProjectiles");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.DoubleProjectiles.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matRoyalJelly");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            //base.RegisterItemDisplayRules(ref itemDisplayRules);
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_DOUBLEPROJECTILES_NAME", "Royal Jelly");
            LanguageAPI.Add("ITEM_DOUBLEPROJECTILES_PICKUP", "Chance to split a fired projectile into two.");
            LanguageAPI.Add("ITEM_DOUBLEPROJECTILES_DESCRIPTION", "<style=cIsDamage>5%</style> <style=cStack>(+5% per stack)</style> chance to <style=cIsDamage>split a fired projectile into two</style> for <style=cIsUtility>2*75% damage</style>.");
            //LanguageAPI.Add("ITEM_DOUBLEPROJECTILES_LORE", "");
        }
        protected override void Hooks()
        {
            base.Hooks();
            On.RoR2.Projectile.ProjectileManager.FireProjectile_FireProjectileInfo += ProjectileManager_FireProjectile_FireProjectileInfo;
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/DLC1/Gup/GupBody.prefab",
                pickupDef = itemDef
            });
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/DLC1/Gup/GipBody.prefab",
                pickupDef = itemDef
            });
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/DLC1/Gup/GeepBody.prefab",
                pickupDef = itemDef
            });
        }
        private void ProjectileManager_FireProjectile_FireProjectileInfo(On.RoR2.Projectile.ProjectileManager.orig_FireProjectile_FireProjectileInfo orig, RoR2.Projectile.ProjectileManager self, RoR2.Projectile.FireProjectileInfo fireProjectileInfo)
        {
            GameObject owner = fireProjectileInfo.owner;
            if (owner != null)
            {
                CharacterBody body = owner.GetComponent<CharacterBody>();
                if (body != null)
                {
                    Inventory inventory = body.inventory;
                    if (inventory != null)
                    {
                        CharacterMaster master = body.master;
                        if (master != null)
                        {
                            int stack = inventory.GetItemCountEffective(Content.Items.DoubleProjectiles);
                            if (stack > 0)
                            {
                                float chance = Util.GetStackingBehavior(Configuration.Items.DoubleProjectiles.procChance, Configuration.Items.DoubleProjectiles.procChanceStack, stack);
                                bool flag2 = fireProjectileInfo.projectilePrefab.GetComponent<SoulSpiralProjectile>();
                                bool result = RoR2.Util.CheckRoll(chance, master) && !blacklist.Contains(fireProjectileInfo.projectilePrefab);
                                if (result && !flag2)
                                {

                                    EffectManager.SimpleEffect(Content.Effects.DoubleProjectilesProc.prefab, body.coreTransform.position, body.coreTransform.rotation, true);
                                    Ray aimRay = body.inputBank.GetAimRay();
                                    Quaternion quaternion = Quaternion.LookRotation(aimRay.direction);
                                    float startingAngle = -Configuration.Items.DoubleProjectiles.angleBetweenShots / (float)Configuration.Items.DoubleProjectiles.projectileCount;
                                    for (int i = 0; i < Configuration.Items.DoubleProjectiles.projectileCount; i++)
                                    {
                                        FireProjectileInfo newInfo = fireProjectileInfo;
                                        newInfo.damage *= (Configuration.Items.DoubleProjectiles.totalDamageBonus / (float)Configuration.Items.DoubleProjectiles.projectileCount);
                                        newInfo.rotation *= Quaternion.Euler(0f, (startingAngle + (Configuration.Items.DoubleProjectiles.angleBetweenShots * i)), 0f);
                                        orig.Invoke(self, newInfo);
                                    }
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            orig.Invoke(self, fireProjectileInfo);
        }

    }
    internal class OrbitingConstructs : ItemFactory
    {
        protected static GameObject construct;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("OrbitingConstructs");
            construct = Assets.AssetBundles.Items.LoadAsset<GameObject>("OrbitingConstruct");

        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.OrbitingConstructs.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matOrbitingConstructs");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            //base.RegisterItemDisplayRules(ref itemDisplayRules);
        }
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/DLC1/MajorAndMinorConstruct/MinorConstructBody.prefab",
                pickupDef = itemDef
            });
        }
        private void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            Inventory i = self.inventory;
            if (i != null)
            {
                int itemCount = i.GetItemCountEffective(Content.Items.OrbitingConstructs);
                OrbitingConstructController occ = self.gameObject.GetComponent<OrbitingConstructController>();
                if (occ == null)
                {
                    occ = self.gameObject.AddComponent<OrbitingConstructController>();
                }
                occ.stack = itemCount;
            }
        }

        private class OrbitingConstructController : MonoBehaviour
        {
            public CharacterBody body
            {
                get
                {
                    return base.gameObject.GetComponent<CharacterBody>();
                }
            }
            public int stack;
            private List<GameObject> constructs = new List<GameObject>();
            private float orbitTimer;
            private int constructCount
            {
                get
                {
                    return constructs.Count;
                }
            }
            private void SpawnConstruct()
            {
                GameObject constructInstance = GameObject.Instantiate(OrbitingConstructs.construct, body.transform);
                constructInstance.GetComponent<NetworkedBodyAttachment>().AttachToGameObjectAndSpawn(base.gameObject, null);
                EntityStateMachine.FindByCustomName(constructInstance, "Body").initialStateType = Content.SerializableEntityStates.EntityStateDictionary["MC_IdleClosed"];
                EntityStateMachine.FindByCustomName(constructInstance, "Body").mainStateType = Content.SerializableEntityStates.EntityStateDictionary["MC_IdleClosed"];

                EntityStateMachine.FindByCustomName(constructInstance, "AI").initialStateType = Content.SerializableEntityStates.EntityStateDictionary["MC_AIState"];
                EntityStateMachine.FindByCustomName(constructInstance, "AI").mainStateType = Content.SerializableEntityStates.EntityStateDictionary["MC_AIState"];
                constructs.Add(constructInstance);
                return;
            }
            private void DestroyConstruct(GameObject constructInstance)
            {
                constructs.Remove(constructInstance);
                UnityEngine.Object.Destroy(constructInstance);
            }
            private void UpdateConstructCount()
            {
                int difference = this.stack - constructCount;
                if (difference == 0)
                {
                    return;
                }
                if (difference > 0)
                {
                    for (int i = 0; i < difference; i++)
                    {
                        SpawnConstruct();
                    }
                }
                else if (difference < 0)
                {
                    if (difference >= this.constructCount)
                    {
                        DestroyAllConstructs();
                        return;
                    }
                    for (int i = 0; i < Mathf.Abs(difference); i++)
                    {
                        DestroyConstruct(constructs[constructs.Count - (1 + i)]);
                    }
                }
            }
            private void DestroyAllConstructs()
            {
                foreach (GameObject constructInstance in constructs)
                {
                    constructs.Remove(constructInstance);
                    UnityEngine.Object.Destroy(constructInstance);
                }
            }
            private void FixedUpdate()
            {
                UpdateConstructCount();
            }
            private void Update()
            {
                orbitTimer += Time.deltaTime * Configuration.Items.OrbitingConstructs.orbitSpeed;
                UpdateConstructTransforms();
            }
            private void UpdateConstructTransforms()
            {
                int i = 0;
                foreach (var instance in constructs)
                {

                    float orbitDistance = this.body.radius + Configuration.Items.OrbitingConstructs.orbitRadius * (1 + Mathf.Floor(i / Configuration.Items.OrbitingConstructs.ringCount));
                    float angleOffset = (360f / (Mathf.Max(constructs.Count, 1))) * i;
                    float xOffset = Mathf.Cos(Mathf.Deg2Rad * (orbitTimer + angleOffset)) * orbitDistance;
                    float yOffset = Mathf.Sin(Mathf.Deg2Rad * (orbitTimer + angleOffset)) * orbitDistance;

                    Vector3 offset = new Vector3(xOffset, 0, yOffset);
                    instance.transform.position = this.body.transform.position + offset;
                    instance.transform.rotation = Quaternion.LookRotation(offset.normalized, this.body.transform.up);
                    instance.transform.Translate(this.body.transform.up);
                    i++;
                }
            }
        }
    }
    internal class NullSeed : ItemFactory
    {
        private GameObject procEffectPrefab;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("NullSeed");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayNullSeed");

        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.NullSeed.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matNullSeed");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Solid Parallax");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matNullSeedContainer");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0.81828F, 0.33732F, -0.8577F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(1.14869F, 1.00006F, -0.89597F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
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
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.GlobalEventManager.OnCharacterDeath += GlobalEventManager_OnCharacterDeath;
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/Base/Nullifier/NullifierBody.prefab",
                pickupDef = itemDef
            });
        }
        private void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            Inventory i = self.inventory;
            if (i != null)
            {
                bool flag = i.GetItemCountEffective(Content.Items.NullSeed) > 0;
                if (flag)
                {
                    if (!self.HasBuff(Content.Buffs.NullSeedActive) && !self.HasBuff(Content.Buffs.NullSeedCooldown))
                    {
                        self.AddBuff(Content.Buffs.NullSeedActive);
                    }
                }
                else
                {
                    if (self.HasBuff(Content.Buffs.NullSeedActive))
                    {
                        self.RemoveBuff(Content.Buffs.NullSeedActive);
                    }
                    if (self.HasBuff(Content.Buffs.NullSeedCooldown))
                    {
                        self.RemoveBuff(Content.Buffs.NullSeedCooldown);
                    }
                }
            }
        }

        private void GlobalEventManager_OnCharacterDeath(On.RoR2.GlobalEventManager.orig_OnCharacterDeath orig, GlobalEventManager self, DamageReport damageReport)
        {
            orig.Invoke(self, damageReport);
            GameObject attacker = damageReport.attacker;
            if (attacker != null)
            {
                CharacterBody cb = attacker.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    bool flag = cb.HasBuff(Content.Buffs.NullSeedActive);
                    if (flag)
                    {

                        if (RoR2.Util.HasEffectiveAuthority(attacker))
                        {
                            FireProjectileInfo fireProjectileInfo = default(FireProjectileInfo);
                            fireProjectileInfo.projectilePrefab = EntityStates.NullifierMonster.DeathState.deathBombProjectile;
                            fireProjectileInfo.position = damageReport.damageInfo.position;
                            fireProjectileInfo.rotation = Quaternion.identity;
                            fireProjectileInfo.owner = attacker;
                            fireProjectileInfo.damage = cb.damage * 100f;
                            fireProjectileInfo.crit = cb.RollCrit();
                            ProjectileManager.instance.FireProjectile(fireProjectileInfo);
                            Inventory i = cb.inventory;
                            if (i != null)
                            {
                                int itemCount = i.GetItemCountEffective(Content.Items.NullSeed);
                                if (itemCount > 0)
                                {
                                    float duration = Mathf.Max(Configuration.Items.NullSeed.cooldown * Mathf.Pow((1 - Configuration.Items.NullSeed.cooldownReduction), itemCount - 1), 1f);
                                    Util.ApplyVisualCountdownBuff(ref cb, Content.Buffs.NullSeedCooldown, (int)duration);
                                }
                            }
                            cb.RemoveBuff(Content.Buffs.NullSeedActive);
                        }
                    }
                }
            }
        }
    }
    internal class VoidShackles : ItemFactory
    {
        public static GameObject portalPrefab;
        public static GameObject chainPrefab;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("VoidShackles");
            portalPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("VoidShacklePortal");
            chainPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("VoidShackleChain");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.GoldArmorBoost.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidShackles");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVSInterior");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVSPickupChain");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidShacklesPortal");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidShacklesPortalRim");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVSShackle");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVSProcShockwave");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVSPortalSuck");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVSFog");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            
        }
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.GlobalEventManager.OnHitEnemy += GlobalEventManager_OnHitEnemy;
        }

        private void GlobalEventManager_OnHitEnemy(On.RoR2.GlobalEventManager.orig_OnHitEnemy orig, GlobalEventManager self, DamageInfo damageInfo, GameObject victim)
        {
            orig.Invoke(self, damageInfo, victim);
            orig.Invoke(self, damageInfo, victim);
            GameObject attacker = damageInfo.attacker;
            if (attacker != null)
            {
                CharacterBody cb = attacker.GetComponent<CharacterBody>();
                if (cb != null)
                {
                    Inventory i = cb.inventory;
                    if (i != null)
                    {
                        int itemCount = i.GetItemCountEffective(Content.Items.VoidChains);
                        if (itemCount > 0)
                        {
                            
                            if ((damageInfo.damage >= cb.damage * 4f))
                            {
                                Vector3 position = damageInfo.position;
                                GameObject instance = GameObject.Instantiate(portalPrefab, position, Quaternion.identity);
                            }
                        }
                    }
                }
            }
        }
    }
    internal class FireEye : ItemFactory
    {
        protected static GameObject bodyAttachment;
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("FireEye");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayFireEye");
            bodyAttachment = Assets.AssetBundles.Items.LoadAsset<GameObject>("FireEyeBodyAttachment");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.FireEye.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matFireEye");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matFireEyeStalk");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/DLC2/Scorchling/ScorchlingBody.prefab",
                pickupDef = itemDef
            });
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.11467F, 0.33251F, 0.14071F),
localAngles = new Vector3(6.31675F, 110.7957F, 343.8432F),
localScale = new Vector3(0.08764F, 0.08764F, 0.08764F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.00164F, 0.27211F, 0.13303F),
localAngles = new Vector3(0F, 89.29087F, 347.2325F),
localScale = new Vector3(0.0899F, 0.0899F, 0.0899F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.08538F, 0.03355F, 0.09328F),
localAngles = new Vector3(0F, 126.6271F, 0F),
localScale = new Vector3(0.03306F, 0.03306F, 0.03306F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(0.80536F, -0.4919F, 0.01454F),
localAngles = new Vector3(0F, 178.9718F, 32.15694F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(-0.07568F, 0.07726F, -0.18491F),
localAngles = new Vector3(0F, 306.4288F, 344.2832F),
localScale = new Vector3(0.04721F, 0.04721F, 0.04721F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleSyringe",
localPos = new Vector3(-0.00175F, 0.16532F, 0.03118F),
localAngles = new Vector3(0F, 86.74183F, 334.8004F),
localScale = new Vector3(0.17954F, 0.17954F, 0.17954F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MechUpperArmR",
localPos = new Vector3(-0.14299F, 0.05848F, -0.00001F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.09079F, 0.09079F, 0.09079F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ThighL",
localPos = new Vector3(0.13724F, -0.00004F, -0.02731F),
localAngles = new Vector3(0F, 204.4755F, 0F),
localScale = new Vector3(0.1343F, 0.1343F, 0.1343F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmR",
localPos = new Vector3(-0.14494F, 0.05769F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.11993F, 0.11993F, 0.11993F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.02987F, 1.32801F, -2.6436F),
localAngles = new Vector3(0F, 261.3708F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleRight",
localPos = new Vector3(-0.01235F, -0.23434F, -0.06711F),
localAngles = new Vector3(-0.00001F, 100.4326F, 61.35016F),
localScale = new Vector3(0.11885F, 0.11885F, 0.11885F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "GunScope",
localPos = new Vector3(0.07745F, -0.13057F, 0.3238F),
localAngles = new Vector3(0F, 85.04631F, 0F),
localScale = new Vector3(0.09333F, 0.09333F, 0.09333F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ForeArmR",
localPos = new Vector3(0.33356F, 0.24156F, 0.00031F),
localAngles = new Vector3(0.50392F, 2.75363F, 169.4999F),
localScale = new Vector3(0.11009F, 0.11009F, 0.11009F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "CalfR",
localPos = new Vector3(0.11174F, 0.07546F, 0.05416F),
localAngles = new Vector3(0F, 154.137F, 0F),
localScale = new Vector3(0.12991F, 0.12991F, 0.12991F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "LowerArmR",
localPos = new Vector3(0.1162F, 0.30685F, 0.1185F),
localAngles = new Vector3(0F, 134.4427F, 0F),
localScale = new Vector3(0.11952F, 0.11952F, 0.11952F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "OvenDoor",
localPos = new Vector3(-0.25735F, 0F, 0.11723F),
localAngles = new Vector3(0F, 88.75013F, 0F),
localScale = new Vector3(0.14703F, 0.14703F, 0.14703F)
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
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
        }

        private void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            Inventory i = self.inventory;
            if(i != null)
            {
                self.AddItemBehavior<FireEyeController>(i.GetItemCountEffective(Content.Items.FireEye));
            }
        }

        public class FireEyeController : CharacterBody.ItemBehavior
        {

            private void OnDisable()
            {
                this.attachmentActive = false;
            }

            private void FixedUpdate()
            {
                this.attachmentActive = base.body.healthComponent.alive;
            }

            private bool attachmentActive
            {
                get
                {
                    return this.attachment != null;
                }
                set
                {
                    if (value == this.attachmentActive)
                    {
                        return;
                    }
                    if (value)
                    {
                        this.attachmentGameObject = GameObject.Instantiate(bodyAttachment, this.body.transform);
                        EntityStateMachine.FindByCustomName(attachmentGameObject, "FireEye").initialStateType = Content.SerializableEntityStates.EntityStateDictionary["FireEyeActive"];
                        EntityStateMachine.FindByCustomName(attachmentGameObject, "FireEye").mainStateType = Content.SerializableEntityStates.EntityStateDictionary["FireEyeActive"];
                        this.attachment = this.attachmentGameObject.GetComponent<NetworkedBodyAttachment>();
                        this.attachment.AttachToGameObjectAndSpawn(base.body.gameObject, null);
                        return;
                    }
                    UnityEngine.Object.Destroy(this.attachmentGameObject);
                    this.attachmentGameObject = null;
                    this.attachment = null;
                }
            }

            private GameObject attachmentGameObject;

            private NetworkedBodyAttachment attachment;
        }


    }
    internal class GoldArmorBoost : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("GoldArmorBoost");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayGoldShard");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.GoldArmorBoost.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matGoldShard");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {
            Content.SubmitAddressablePickupPair(new Content.AddressablePickupPair
            {
                objectAddress = "RoR2/DLC2/Halcyonite/HalcyoniteBody.prefab",
                pickupDef = itemDef
            });
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.09427F, 0.04302F, -0.00084F),
localAngles = new Vector3(13.49976F, 85.3624F, 349.3976F),
localScale = new Vector3(0.15832F, 0.15832F, 0.15832F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.07841F, 0.08582F, -0.041F),
localAngles = new Vector3(0F, 99.84805F, 0F),
localScale = new Vector3(0.10209F, 0.10209F, 0.10209F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.08211F, 0.12156F, 0.0015F),
localAngles = new Vector3(354.3686F, 66.43991F, 3.0437F),
localScale = new Vector3(0.0843F, 0.0843F, 0.0843F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(-0.59111F, 1.54359F, -0.00002F),
localAngles = new Vector3(0F, 75.52873F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.04311F, 0.03151F, -0.00001F),
localAngles = new Vector3(0F, 278.2668F, 0F),
localScale = new Vector3(0.10094F, 0.10094F, 0.10094F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadBase",
localPos = new Vector3(0F, 0.00003F, -0.61763F),
localAngles = new Vector3(351.8391F, 0F, 68.25645F),
localScale = new Vector3(0.16903F, 0.16903F, 0.16903F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.08998F, 0.18606F, -0.00026F),
localAngles = new Vector3(8.89201F, 271.9792F, 0F),
localScale = new Vector3(0.09593F, 0.09593F, 0.09593F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.07494F, 0.20017F, -0.01045F),
localAngles = new Vector3(354.6299F, 97.94003F, 0F),
localScale = new Vector3(0.08902F, 0.08902F, 0.08902F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(-0.00001F, 0.05683F, -0.10629F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.11298F, 0.11298F, 0.11298F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MouthMuzzle",
localPos = new Vector3(0.68772F, 2.0521F, 4.11074F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.67355F, 0.67355F, 0.67355F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.0763F, 0.07216F, 0F),
localAngles = new Vector3(0F, 260.0381F, 0F),
localScale = new Vector3(0.13459F, 0.13459F, 0.13459F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.03977F, 0.09987F, 0.00216F),
localAngles = new Vector3(0F, 86.85378F, 0F),
localScale = new Vector3(0.0907F, 0.0907F, 0.0907F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.09792F, 0.13479F, 0.02664F),
localAngles = new Vector3(7.23231F, 258.1461F, 0F),
localScale = new Vector3(0.08044F, 0.08044F, 0.08044F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0F, 0.0406F, -0.06148F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.10424F, 0.10424F, 0.10424F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0.12781F, 0.15504F, -0.02842F),
localAngles = new Vector3(357.3236F, 294.6801F, 5.80224F),
localScale = new Vector3(0.2112F, 0.2112F, 0.2112F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "UpperArmL",
localPos = new Vector3(0F, 0F, -0.05203F),
localAngles = new Vector3(0F, 0F, 268.6192F),
localScale = new Vector3(0.15962F, 0.15962F, 0.15962F)
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
        protected override void RegisterLanguageTokens()
        {
            base.RegisterLanguageTokens();
        }
        protected override void Hooks()
        {
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
            On.RoR2.CharacterMaster.GiveMoney += CharacterMaster_GiveMoney;
        }

        private void CharacterMaster_GiveMoney(On.RoR2.CharacterMaster.orig_GiveMoney orig, CharacterMaster self, uint amount)
        {
            orig.Invoke(self, amount);
            Inventory i = self.inventory;
            if (i != null)
            {
                int itemCount = i.GetItemCountEffective(Content.Items.GoldArmorBoost);
                if (itemCount > 0)
                {
                    CharacterBody cb = self.GetBody();
                    if(cb != null)
                    {
                        cb.statsDirty = true;
                    }
                }
            }
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            Inventory i = sender.inventory;
            if (i != null)
            {
                int itemCount = i.GetItemCountEffective(Content.Items.GoldArmorBoost);
                if(itemCount > 0)
                {
                    uint gold = sender.master.money;
                    float cap = Util.GetStackingBehavior(Configuration.Items.GoldArmorBoost.armorCap, Configuration.Items.GoldArmorBoost.armorCapStack, itemCount);
                    float threshold = Run.instance.GetDifficultyScaledCost((int)Configuration.Items.GoldArmorBoost.goldThreshold);
                    float armorBoost = Mathf.Max(Mathf.Min((gold / threshold) * Configuration.Items.GoldArmorBoost.armorPerThreshold, cap), 0);
                    if(armorBoost > 0)
                    {
                        args.armorAdd += armorBoost;
                    }
                }
            }
        }
    }
}
