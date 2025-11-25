using R2API;
using RoR2;
using RoR2.Orbs;
using RoR2.Projectile;
using SivsContentPack.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using static UnityEngine.ParticleSystem.PlaybackState;

namespace SivsContentPack.Items
{
    internal class VoidSeedSpawner : ItemFactory
    {
        private InteractableSpawnCard voidSeedCard;
        private GameObject itemEffectPrefab;
        
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("VoidSeedSpawner");
            voidSeedCard = Addressables.LoadAssetAsync<InteractableSpawnCard>("RoR2/DLC1/VoidCamp/iscVoidCamp.asset").WaitForCompletion();
            if (voidSeedCard != null)
            {
                Debug.LogFormat("Loaded iscVoidCamp.");
            }

        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.VoidSeedSpawner.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matVSSSeed");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVSSMetal");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVSSAntimatter");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_VOIDSEEDSPAWNER_NAME", "Abyssal Seedpod");
            LanguageAPI.Add("ITEM_VOIDSEEDSPAWNER_PICKUP", "???");
            LanguageAPI.Add("ITEM_VOIDSEEDSPAWNER_DESCRIPTION", "???");
            //LanguageAPI.Add("ITEM_VOIDSEEDSPAWNER_LORE", "");
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
            SceneDirector.onPostPopulateSceneServer += SceneDirector_onPostPopulateSceneServer;
        }

        private void SceneDirector_onPostPopulateSceneServer(SceneDirector obj)
        {
            //Debug.LogFormat("VoidSeedSpawner: beginning operation.");
            if (SceneInfo.instance.countsAsStage || SceneInfo.instance.sceneDef.allowItemsToSpawnObjects)
            {
                bool powerUpVoidSeedActivated = false;
                int num = 0;
                Xoroshiro128Plus xoroshiro128Plus = new Xoroshiro128Plus(obj.rng.nextUlong);
                using (IEnumerator<CharacterMaster> enumerator = CharacterMaster.readOnlyInstancesList.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.inventory.GetItemCountPermanent(Content.Items.VoidSeedSpawner) > 0)
                        {
                            //Debug.LogFormat("Located inventory containing VoidSeedSpawner.");
                            enumerator.Current.inventory.RemoveItemPermanent(Content.Items.VoidSeedSpawner);
                            powerUpVoidSeedActivated = true;
                            num++;
                        }
                    }
                }
                //Debug.LogFormat("Attempting to spawn {0} Void Seeds...", num);
                for (int j = 0; j < num; j++)
                {
                    GameObject voidSeed = DirectorCore.instance.TrySpawnObject(new DirectorSpawnRequest(voidSeedCard, new DirectorPlacementRule
                    {
                        placementMode = DirectorPlacementRule.PlacementMode.Random
                    }, xoroshiro128Plus));
                }
                if (powerUpVoidSeedActivated)
                {
                    GenericDisplayNameProvider[] voidSeeds = GenericDisplayNameProvider.FindObjectsOfType<GenericDisplayNameProvider>();
                    foreach (var item in voidSeeds)
                    {
                        if(item.displayToken == "VOIDCAMPCENTER_NAME")
                        {
                            //Debug.LogFormat("Void Seed located. Attempting to power up...");
                            OutsideInteractableLocker oil = item.GetComponent<OutsideInteractableLocker>();
                            if(oil != null)
                            {
                                oil.radius *= (1f + Configuration.Items.VoidSeedSpawner.radiusIncrease);
                            }
                            Transform monstersAndInteractibles = item.transform.Find("Camp 1 - Void Monsters & Interactables");
                            if(monstersAndInteractibles != null)
                            {
                                CampDirector cd = monstersAndInteractibles.GetComponent<CampDirector>();
                                if(cd != null)
                                {
                                    cd.baseMonsterCredit = (int)((float)cd.baseMonsterCredit * Configuration.Items.VoidSeedSpawner.creditMult);
                                    cd.baseInteractableCredit = (int)((float)cd.baseInteractableCredit * Configuration.Items.VoidSeedSpawner.creditMult);
                                    //cd.campMinimumRadius *= (1f + Configuration.Items.VoidSeedSpawner.radiusIncrease);
                                    cd.campMaximumRadius *= (1f + Configuration.Items.VoidSeedSpawner.radiusIncrease);
                                    //Debug.LogFormat("Boosted credits and radius for Monsters and Interactables.");
                                }
                                SphereZone sz = monstersAndInteractibles.GetComponent<SphereZone>();
                                if(sz != null)
                                {
                                    sz.radius *= 1f + Configuration.Items.VoidSeedSpawner.radiusIncrease;
                                }
                            }
                            Transform propsAndElites = item.transform.Find("Camp 2 - Flavor Props & Void Elites");
                            if (propsAndElites != null)
                            {
                                CampDirector cd = monstersAndInteractibles.GetComponent<CampDirector>();
                                if (cd != null)
                                {
                                    cd.baseMonsterCredit = (int)((float)cd.baseMonsterCredit * Configuration.Items.VoidSeedSpawner.creditMult);
                                    cd.baseInteractableCredit = (int)((float)cd.baseInteractableCredit * Configuration.Items.VoidSeedSpawner.creditMult);
                                    //cd.campMinimumRadius *= (1f+Configuration.Items.VoidSeedSpawner.radiusIncrease);
                                    cd.campMaximumRadius *= (1f + Configuration.Items.VoidSeedSpawner.radiusIncrease);
                                    //Debug.LogFormat("Boosted credits and radius for Props and Elites.");
                                }
                            }
                            PlayerSpawnInhibitor psi = item.GetComponent<PlayerSpawnInhibitor>();
                            if (psi != null)
                            {
                                psi.radius *= (1f + Configuration.Items.VoidSeedSpawner.radiusIncrease);
                                //Debug.LogFormat("Increased radius of player spawn inhibitor.");
                            }
                            //Debug.LogFormat("Finished powering up void seed.");
                        }
                    }
                }
            }
        
        }
    }

    internal class Monocle : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("Monocle");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Monocle.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matMonocle");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
        protected override void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_MONOCLE_NAME", "Vintage Monocle");
            LanguageAPI.Add("ITEM_MONOCLE_PICKUP", "???");
            LanguageAPI.Add("ITEM_MONOCLE_DESCRIPTION", "???");
            //LanguageAPI.Add("ITEM_MONOCLE_LORE", "");
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
                            int itemStack = i.GetItemCountEffective(Content.Items.Monocle);
                            if (itemStack > 0)
                            {
                                CharacterBody vb = self.body;
                                if (vb != null)
                                {

                                    float damageBonus = Util.GetStackingBehavior(Configuration.Items.Monocle.eliteDamageBonus, Configuration.Items.Monocle.eliteDamageBonusStack, itemStack);
                                    float damagePenalty = Mathf.Pow(1f-Configuration.Items.Monocle.nonEliteDamagePenalty, itemStack);
                                    bool flag = vb.isElite;
                                    if (flag) //is elite
                                    {
                                        damageInfo.damage *= 1 + damageBonus;
                                    }
                                    else //is not elite
                                    {
                                        damageInfo.damage *= damagePenalty;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            orig.Invoke(self, damageInfo);
        }
    }

    internal class PiggyBank : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("PiggyBank");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.PiggyBank.enabled.Value;
        }
        protected override void HandleMaterials()
        {

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

        public class PiggyBankController : MonoBehaviour
        {
            public int storedCoins;

            private Inventory inventory;

            private CharacterMaster master;

            private float bonus;

            private void Awake()
            {
                master = gameObject.GetComponent<CharacterMaster>();
                inventory = gameObject.GetComponent<Inventory>();
            }

            public static void StoreLunarCoins(GameObject master)
            {
                PiggyBankController pbc = master.GetComponent<PiggyBankController>();
                if (pbc != null)
                {

                }
            }

            public static void AwardLunarCoins(GameObject master)
            {
                if (NetworkServer.active)
                {
                    if (master)
                    {
                        PlayerCharacterMasterController pcmc = master.GetComponent<PlayerCharacterMasterController>();
                        if (pcmc)
                        {
                            GameObject networkUserObject = pcmc.networkUserObject;
                            if (networkUserObject)
                            {
                                NetworkUser component2 = networkUserObject.GetComponent<NetworkUser>();
                                if (component2)
                                {
                                    if (component2.isLocalPlayer)
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    internal class Chimera : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("Chimera");
            displayPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DisplayChimera");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Chimera.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matChimera");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matChimeraFire");
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
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.22862F, 0.39238F, -0.01687F),
localAngles = new Vector3(332.2004F, 310.9895F, 337.9388F),
localScale = new Vector3(0.34799F, 0.34799F, 0.34799F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(0.18885F, 0.30237F, 0.0404F),
localAngles = new Vector3(323.7239F, 253.0025F, 10.25201F),
localScale = new Vector3(0.29579F, 0.29579F, 0.29579F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Hat",
localPos = new Vector3(-0.00001F, 0.13837F, -0.05666F),
localAngles = new Vector3(334.9778F, 0F, 0F),
localScale = new Vector3(0.21483F, 0.21483F, 0.21483F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-2.07477F, 2.74083F, -0.00002F),
localAngles = new Vector3(0F, 276.7384F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadCenter",
localPos = new Vector3(0F, 0.08275F, -0.18429F),
localAngles = new Vector3(277.5038F, 0F, 0F),
localScale = new Vector3(0.23083F, 0.23083F, 0.23083F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "HeadBase",
localPos = new Vector3(0F, 0.06049F, -0.63603F),
localAngles = new Vector3(298.2647F, 180F, 180F),
localScale = new Vector3(0.42145F, 0.42145F, 0.42145F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.26527F, 0.35383F, 0.00003F),
localAngles = new Vector3(19.52182F, 280.2296F, 9.4071F),
localScale = new Vector3(0.23704F, 0.23704F, 0.23704F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.21861F, 0.29277F, 0.00388F),
localAngles = new Vector3(4.05915F, 322.4204F, 26.66207F),
localScale = new Vector3(0.21006F, 0.21006F, 0.21006F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.25329F, -0.07878F),
localAngles = new Vector3(334.2847F, 0F, 0F),
localScale = new Vector3(0.20873F, 0.20873F, 0.20873F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(3.53946F, 2.11102F, 1.11078F),
localAngles = new Vector3(0.53833F, 337.301F, 294.9978F),
localScale = new Vector3(1.79694F, 1.79694F, 1.79694F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "MuzzleRight",
localPos = new Vector3(0F, -0.18532F, -0.41801F),
localAngles = new Vector3(333.0662F, 213.6172F, 163.2407F),
localScale = new Vector3(0.34485F, 0.34485F, 0.34485F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0.22526F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.20914F, 0.20914F, 0.20914F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.32938F, 0.24196F, -0.03501F),
localAngles = new Vector3(38.88112F, 262.3446F, 355.8358F),
localScale = new Vector3(0.20846F, 0.20846F, 0.20846F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pack",
localPos = new Vector3(-0.29077F, 0.22303F, -0.22208F),
localAngles = new Vector3(0F, 0F, 42.97366F),
localScale = new Vector3(0.3823F, 0.3823F, 0.3823F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ClavL",
localPos = new Vector3(-0.04002F, 0.5542F, -0.23816F),
localAngles = new Vector3(277.9041F, 359.3891F, 1.15886F),
localScale = new Vector3(0.35016F, 0.35016F, 0.35016F)
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Chest",
localPos = new Vector3(-0.34732F, 0.02078F, 0.30206F),
localAngles = new Vector3(0.96246F, 16.30951F, 86.71444F),
localScale = new Vector3(0.2949F, 0.2949F, 0.2949F)
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
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
            On.RoR2.CharacterMaster.OnInventoryChanged += CharacterMaster_OnInventoryChanged;
        }

        private void CharacterMaster_OnInventoryChanged(On.RoR2.CharacterMaster.orig_OnInventoryChanged orig, CharacterMaster self)
        {
            orig.Invoke(self);
            Inventory i = self.inventory;
            if (i != null)
            {
                int count = i.GetItemCountEffective(Content.Items.ChimeraLuck);
                self.luck += count;
            }
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            Inventory i = sender.inventory;
            if(i != null)
            {
                int armor = i.GetItemCountEffective(Content.Items.ChimeraArmor);
                int cooldown = i.GetItemCountEffective(Content.Items.ChimeraCooldown);
                int crit = i.GetItemCountEffective(Content.Items.ChimeraCrit);
                int damage = i.GetItemCountEffective(Content.Items.ChimeraDamage);
                int health = i.GetItemCountEffective(Content.Items.ChimeraHealth);
                int regen = i.GetItemCountEffective(Content.Items.ChimeraRegen);
                int shield = i.GetItemCountEffective(Content.Items.ChimeraShields);
                int speed = i.GetItemCountEffective(Content.Items.ChimeraSpeed);
                if (armor > 0)
                {
                    args.armorAdd += Util.GetStackingBehavior(Configuration.Items.Chimera.Blessings.armorBonus, Configuration.Items.Chimera.Blessings.armorBonusStack, armor);
                }
                if(cooldown > 0)
                {

                    args.cooldownReductionAdd += Util.GetStackingBehavior(Configuration.Items.Chimera.Blessings.cooldownBonus, Configuration.Items.Chimera.Blessings.cooldownBonusStack, cooldown);
                }
                if (crit > 0)
                {
                    args.critAdd += Util.GetStackingBehavior(Configuration.Items.Chimera.Blessings.critBonus * 100f, Configuration.Items.Chimera.Blessings.critBonusStack * 100f, crit);
                    args.critDamageMultAdd += Util.GetStackingBehavior(Configuration.Items.Chimera.Blessings.critBonus, Configuration.Items.Chimera.Blessings.critBonusStack, crit);
                }
                if(damage > 0)
                {
                    args.damageMultAdd += Util.GetStackingBehavior(Configuration.Items.Chimera.Blessings.damageBonus, Configuration.Items.Chimera.Blessings.damageBonusStack, damage);

                }
                if(health > 0)
                {
                    args.healthMultAdd += Util.GetStackingBehavior(Configuration.Items.Chimera.Blessings.hpBonus, Configuration.Items.Chimera.Blessings.hpBonusStack, health);
                }
                if(regen > 0)
                {
                    args.baseRegenAdd += Util.GetStackingBehavior(Configuration.Items.Chimera.Blessings.regenBonus, Configuration.Items.Chimera.Blessings.regenBonusStack, regen);
                }
                if(shield > 0)
                {
                    args.baseShieldAdd += sender.maxHealth * Util.GetStackingBehavior(Configuration.Items.Chimera.Blessings.shieldBonus, Configuration.Items.Chimera.Blessings.shieldBonusStack, shield);
                }
                if(speed > 0)
                {
                    args.moveSpeedMultAdd += Util.GetStackingBehavior(Configuration.Items.Chimera.Blessings.moveSpeedBonus, Configuration.Items.Chimera.Blessings.moveSpeedBonusStack, speed);
                    args.attackSpeedMultAdd += Util.GetStackingBehavior(Configuration.Items.Chimera.Blessings.attackSpeedBonus, Configuration.Items.Chimera.Blessings.attackSpeedBonusStack, speed);
                }
            }
        }

        private void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            Inventory i = self.inventory;
            if (i != null)
            {
                self.AddItemBehavior<ChimeraController>(i.GetItemCountEffective(Content.Items.Chimera));
            }
        }

        public class ChimeraController : CharacterBody.ItemBehavior
        {
            private static WeightedSelection<ItemDef> blessingPool = new WeightedSelection<ItemDef>();

            private float timer;

            private Xoroshiro128Plus transformRng;

            private void OnEnable()
            {

            }
            private void OnDisable()
            {

            }

            private void Awake()
            {
                timer = Configuration.Items.Chimera.duration;
                ulong seed = Run.instance.seed ^ (ulong)((long)Run.instance.stageClearCount);
                this.transformRng = new Xoroshiro128Plus(seed);
                blessingPool = new WeightedSelection<ItemDef>();
                blessingPool.AddChoice(Content.Items.ChimeraArmor, 3f);
                blessingPool.AddChoice(Content.Items.ChimeraCooldown, 3f);
                blessingPool.AddChoice(Content.Items.ChimeraCrit, 3f);
                blessingPool.AddChoice(Content.Items.ChimeraDamage, 3f);
                blessingPool.AddChoice(Content.Items.ChimeraHealth, 3f);
                blessingPool.AddChoice(Content.Items.ChimeraLuck, 1f);
                blessingPool.AddChoice(Content.Items.ChimeraRegen, 3f);
                blessingPool.AddChoice(Content.Items.ChimeraShields, 3f);
                blessingPool.AddChoice(Content.Items.ChimeraSpeed, 3f);
            }

            private void FixedUpdate()
            {
                if(timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else
                {
                    for (int i = 0; i < this.stack; i++)
                    {
                        List<ItemIndex> list = new List<ItemIndex>(this.body.inventory.itemAcquisitionOrder);
                        ItemIndex itemIndex = ItemIndex.None;
                        RoR2.Util.ShuffleList<ItemIndex>(list, this.transformRng);
                        foreach (ItemIndex itemIndex2 in list)
                        {
                            if (itemIndex2 != Content.Items.Chimera.itemIndex)
                            {
                                ItemDef itemDef = ItemCatalog.GetItemDef(itemIndex2);
                                if (itemDef && itemDef.tier != ItemTier.NoTier)
                                {
                                    itemIndex = itemIndex2;
                                    break;
                                }
                            }
                        }
                        if (itemIndex != ItemIndex.None)
                        {
                            ItemDef gift = blessingPool.Evaluate(transformRng.nextNormalizedFloat);
                            this.body.inventory.RemoveItem(itemIndex, 1);
                            this.body.inventory.GiveItem(gift, 1);
                            CharacterMasterNotificationQueue.SendTransformNotification(this.body.master, itemIndex, gift.itemIndex, CharacterMasterNotificationQueue.TransformationType.LunarSun);
                        }
                    }
                    timer = Configuration.Items.Chimera.duration;

                }
            }
        }
    }
    internal class ChimeraArmor : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ChimeraArmor");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Chimera.enabled.Value;
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            
        }
    }
    internal class ChimeraCooldown : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ChimeraCooldown");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Chimera.enabled.Value;
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
    }
    internal class ChimeraCrit : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ChimeraCrit");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Chimera.enabled.Value;
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
    }
    internal class ChimeraDamage : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ChimeraDamage");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Chimera.enabled.Value;
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
    }
    internal class ChimeraHealth : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ChimeraHealth");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Chimera.enabled.Value;
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
    }
    internal class ChimeraLuck : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ChimeraLuck");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Chimera.enabled.Value;
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
    }
    internal class ChimeraRegen : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ChimeraRegen");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Chimera.enabled.Value;
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
    }
    internal class ChimeraShields : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ChimeraShields");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Chimera.enabled.Value;
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
    }
    internal class ChimeraSpeed : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("ChimeraSpeed");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Chimera.enabled.Value;
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
    }

    internal class Grudge : ItemFactory
    {

        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Items.LoadAsset<ItemDef>("Grudge");
            Content.Misc.GrudgeFollower = Assets.AssetBundles.Items.LoadAsset<GameObject>("GrudgeProjectile");
            ProjectileScaleSpeedWithDistance psswd = Content.Misc.GrudgeFollower.AddComponent<ProjectileScaleSpeedWithDistance>();
            psswd.farDistanceThreshold = Configuration.Items.Grudge.farSpeedThreshold;
            psswd.farSpeedMultiplier = Configuration.Items.Grudge.farSpeedMult;
            psswd.nearDistanceThreshold = Configuration.Items.Grudge.nearSpeedThreshold;
            psswd.nearSpeedMultiplier = Configuration.Items.Grudge.nearSpeedMult;
            psswd.baseSpeed = Configuration.Items.Grudge.baseSpeed;
            psswd.baseRotationSpeed = Configuration.Items.Grudge.baseRotationSpeed;
            Content.DeployableSlots.GrudgeProjectile = Content.CreateDeployableSlot();
            ProjectileDeployToOwner pdto = Content.Misc.GrudgeFollower.GetComponent<ProjectileDeployToOwner>();
            if (pdto != null)
            {
                pdto.deployableSlot = Content.DeployableSlots.GrudgeProjectile;
            }
            ContentAddition.AddProjectile(Content.Misc.GrudgeFollower);
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Items.Grudge.enabled.Value;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matGrudge");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGrudgeNail");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGrudgeBand");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGrudgeAura");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGrudgeTrail");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGrudgeWarning");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
        }
        protected override void RegisterLanguageTokens()
        {

        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

        }
        protected override void Hooks()
        {
            On.RoR2.CharacterMaster.GetDeployableSameSlotLimit += CharacterMaster_GetDeployableSameSlotLimit;
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
        }

        private void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig.Invoke(self);
            Inventory i = self.inventory;
            if (i != null)
            {
                self.AddItemBehavior<GrudgeController>(i.GetItemCountEffective(Content.Items.Grudge));
            }
        }

        private int CharacterMaster_GetDeployableSameSlotLimit(On.RoR2.CharacterMaster.orig_GetDeployableSameSlotLimit orig, CharacterMaster self, DeployableSlot slot)
        {
            if(slot == Content.DeployableSlots.GrudgeProjectile)
            {
                return 1;
            }
            return orig.Invoke(self, slot);
        }

        public class GrudgeController : CharacterBody.ItemBehavior
        {
            private GameObject projectileInstance;

            public AttackerFiltering attackerFiltering = AttackerFiltering.Default;

            private const float updateInterval = 1f;

            private float updateTimer;

            private bool firedProjectile;

            private CharacterMaster master;

            private void OnDisable()
            {
                if (this.projectileInstance)
                {
                    GameObject.Destroy(this.projectileInstance);
                }
            }

            private void Start()
            {
                this.firedProjectile = false;
            }

            private void FixedUpdate()
            {

                if (!this.master)
                {
                    this.master = this.body.master;
                }

                if (!firedProjectile)
                {
                    FireProjectile();
                }
                if (!this.projectileInstance && this.firedProjectile && this.master)
                {
                    LocateInstance();
                }

                UpdateProjectile();
            }

            private void FireProjectile()
            {
                if (NetworkServer.active)
                {
                    float damageCoefficient = Util.GetStackingBehavior(Configuration.Items.Grudge.damageCoefficient, Configuration.Items.Grudge.damageCoefficientStack, stack);
                    if (!this.master.IsDeployableLimited(Content.DeployableSlots.GrudgeProjectile))
                    {
                        FireProjectileInfo fpi = new FireProjectileInfo()
                        {
                            owner = this.gameObject,
                            crit = body.RollCrit(),
                            damage = body.damage * damageCoefficient,
                            damageColorIndex = DamageColorIndex.Item,
                            position = gameObject.transform.position + (gameObject.transform.forward * 3f),
                            procChainMask = default,
                            projectilePrefab = Content.Misc.GrudgeFollower,
                            rotation = Quaternion.identity,
                            target = this.gameObject
                        };
                        ProjectileManager.instance.FireProjectile(fpi);
                        firedProjectile = true;
                    }
                }
            }
            private void UpdateProjectile()
            {
                float damageCoefficient = Util.GetStackingBehavior(Configuration.Items.Grudge.damageCoefficient, Configuration.Items.Grudge.damageCoefficientStack, stack);
                if (this.updateTimer <= 0)
                {
                    if (this.projectileInstance)
                    {

                        ProjectileOverlapAttack poa = projectileInstance.GetComponent<ProjectileOverlapAttack>();
                        if(poa != null)
                        {
                            poa.attack.teamIndex = TeamIndex.None;
                            poa.attack.attackerFiltering = attackerFiltering;
                        }
                        TeamFilter filter = projectileInstance.GetComponent<TeamFilter>();
                        if (filter != null)
                        {
                            //filter.teamIndex = TeamIndex.Neutral;
                        }
                        ProjectileDamage pd = projectileInstance.GetComponent<ProjectileDamage>();
                        if (pd != null)
                        {
                            pd.damage = damageCoefficient * body.damage;
                        }
                        ProjectileTargetComponent ptc = projectileInstance.GetComponent<ProjectileTargetComponent>();
                        if (ptc != null)
                        {
                            ptc.target = this.gameObject.transform;
                        }
                    }
                    this.updateTimer += updateInterval;
                }
                else
                {
                    this.updateTimer -= Time.deltaTime;
                }
            }
            private void LocateInstance()
            {
                if (this.master)
                {
                    if(this.master.deployablesList.Count > 0)
                    {
                        foreach (var item in this.master.deployablesList)
                        {
                            if (item.slot == Content.DeployableSlots.GrudgeProjectile)
                            {
                                this.projectileInstance = item.deployable.gameObject;
                            }
                        }
                    }
                }
            }
        }
        public class ProjectileScaleSpeedWithDistance : MonoBehaviour
        {
            private ProjectileController projectileController;

            private ProjectileTargetComponent targetComponent;

            private ProjectileSteerTowardTarget steerTowardTarget;

            private Rigidbody rigidbody;

            public float baseSpeed;

            public float nearDistanceThreshold;

            public float farDistanceThreshold;

            public float nearSpeedMultiplier;

            public float farSpeedMultiplier;

            public float baseRotationSpeed;

            private float currentMult;

            private void Awake()
            {
                this.rigidbody = base.GetComponent<Rigidbody>();
                this.steerTowardTarget = base.GetComponent<ProjectileSteerTowardTarget>();
                this.projectileController = base.GetComponent<ProjectileController>();
                this.targetComponent = base.GetComponent<ProjectileTargetComponent>();
            }

            private float SolveForSpeedMult()
            {
                Vector3 targetPos = gameObject.transform.position;
                if (this.targetComponent)
                {
                    if (this.targetComponent.target != null)
                    {
                        targetPos = this.targetComponent.target.position;
                    }
                }
                Vector3 currentPos = gameObject.transform.position;

                float distance = Mathf.Clamp(Vector3.Distance(targetPos, currentPos), this.nearDistanceThreshold, this.farDistanceThreshold);

                float mult = Mathf.Lerp(nearSpeedMultiplier, farSpeedMultiplier, (distance/farDistanceThreshold));

                return mult;
            }

            private void FixedUpdate()
            {
                currentMult = SolveForSpeedMult();
                if (this.rigidbody)
                {
                    this.rigidbody.velocity = this.transform.forward * (baseSpeed * currentMult);
                }
                if (this.steerTowardTarget)
                {
                    steerTowardTarget.rotationSpeed = baseRotationSpeed * currentMult;
                }
            }
        }
           
    }
}
