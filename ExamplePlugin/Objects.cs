using BepInEx;
using R2API;
using RoR2;
using SivsContentPack.Items;
using System;
using UnityEngine;
using RoR2.Skills;
using RoR2.ExpansionManagement;
using UnityEngine.AddressableAssets;
using SivsContentPack;
using RoR2.ContentManagement;
using static SivsContentPack.Content;
using System.Collections;
using R2API.ScriptableObjects;
using R2API.ContentManagement;
using HarmonyLib;
using static Rewired.UI.ControlMapper.ControlMapper;
using EntityStates;
using System.Linq;
using System.Collections.Generic;
using SivsContentPack.CustomEntityStates;
using SivsContentPack.CustomEntityStates.MiniConstructs;
using UnityEngine.Bindings;
using SivsContentPack.Characters;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace SivsContentPack
{
    public class EnemyChest : InteractableFactory
    {
        protected override void LoadAssets(ref InteractableSpawnCard isc, ref GameObject prefab)
        {
            prefab = Assets.AssetBundles.Objects.LoadAsset<GameObject>("ChestEnemyItem");
            isc = Assets.AssetBundles.Objects.LoadAsset<InteractableSpawnCard>("iscEnemyItemChest");
            
        }

        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Objects.LoadAsset<Material>("matEnemyItemChest");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matEnemyChestHighlight");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matEnemyChestRadiusIndicator");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matEnemyChestHighlightActive");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matEnemyChestHighlightComplete");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matBillboard");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matActivate");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }

        protected override void Hooks()
        {
            SceneDirector.onPostPopulateSceneServer += SceneDirector_onPostPopulateSceneServer;
            RoR2Application.onLoad += new System.Action(ManagePickupDropTable);
        }

        private void ManagePickupDropTable()
        {
            GameObject obj = Content.Interactables.EnemyChest;
            ChestBehavior cb = obj.GetComponent<ChestBehavior>();
            if (cb != null)
            {
                ExplicitPickupDropTable epdt = cb.dropTable as ExplicitPickupDropTable;
                if (epdt != null)
                {
                    ExplicitPickupDropTable.PickupDefEntry[] entries = epdt.pickupEntries;
                    entries = entries.AddRangeToArray(new ExplicitPickupDropTable.PickupDefEntry[]
                    {
                        new ExplicitPickupDropTable.PickupDefEntry()
                        {
                            pickupDef = RoR2Content.Items.FireballsOnHit,
                            pickupWeight = 1f,
                        },
                        new ExplicitPickupDropTable.PickupDefEntry()
                        {
                            pickupDef = RoR2Content.Items.LightningStrikeOnHit,
                            pickupWeight = 1f,
                        },new ExplicitPickupDropTable.PickupDefEntry()
                        {
                            pickupDef = RoR2Content.Items.Knurl,
                            pickupWeight = 1f,
                        },new ExplicitPickupDropTable.PickupDefEntry()
                        {
                            pickupDef = RoR2Content.Items.RoboBallBuddy,
                            pickupWeight = 1f,
                        },new ExplicitPickupDropTable.PickupDefEntry()
                        {
                            pickupDef = RoR2Content.Items.SprintWisp,
                            pickupWeight = 1f,
                        },new ExplicitPickupDropTable.PickupDefEntry()
                        {
                            pickupDef = RoR2Content.Items.SiphonOnLowHealth,
                            pickupWeight = 1f,
                        },new ExplicitPickupDropTable.PickupDefEntry()
                        {
                            pickupDef = RoR2Content.Items.NovaOnLowHealth,
                            pickupWeight = 1f,
                        },new ExplicitPickupDropTable.PickupDefEntry()
                        {
                            pickupDef = RoR2Content.Items.ParentEgg,
                            pickupWeight = 1f,
                        },new ExplicitPickupDropTable.PickupDefEntry()
                        {
                            pickupDef = RoR2Content.Items.BeetleGland,
                            pickupWeight = 1f,
                        },new ExplicitPickupDropTable.PickupDefEntry()
                        {
                            pickupDef = RoR2Content.Items.BleedOnHitAndExplode,
                            pickupWeight = 1f,
                        },new ExplicitPickupDropTable.PickupDefEntry()
                        {
                            pickupDef = DLC1Content.Items.MinorConstructOnKill,
                            pickupWeight = 1f,
                        },
                    });
                    epdt.pickupEntries = entries;
                }
            }
        }

        private void SceneDirector_onPostPopulateSceneServer(SceneDirector obj)
        {
            DirectorPlacementRule placementRule = new DirectorPlacementRule
            {
                placementMode = DirectorPlacementRule.PlacementMode.Random
            };
            DirectorCore.instance.TrySpawnObject(new DirectorSpawnRequest(Content.Interactables.iscEnemyChest, placementRule, obj.rng));
        }
    }

    public class BossShrine : InteractableFactory
    {
        protected override void LoadAssets(ref InteractableSpawnCard isc, ref GameObject prefab)
        {
            prefab = Assets.AssetBundles.Objects.LoadAsset<GameObject>("ProvShrine");
            isc = Assets.AssetBundles.Objects.LoadAsset<InteractableSpawnCard>("iscProvShrine");
            CombatDirector cd = prefab.GetComponent<CombatDirector>();
            if (cd != null)
            {
                if(Content.Champions.dccsChampions != null)
                {
                    cd.monsterCards = Champions.dccsChampions;
                }
            }
            Content.Interactables.dcBossShrine = new DirectorCard()
            {
                minimumStageCompletions = 4,
                selectionWeight = 1,
                spawnCard = isc,
                requiredUnlockableDef = Content.Unlockables.UnlockGodTier,
                preventOverhead = true,
            };
        }

        protected override List<string> AddToSceneInfos()
        {
            return new List<string>
            {
                "arena",
                "blackbeach",
                "blackbeach2",
                "golemplains",
                "golemplains2",
                "snowyforest",
                "village",
                "villagenight",
                "lakes",
                "lakesnight",
                "lemuriantemple",
                "sulfurpools",
                "goolake",
                "foggyswamp",
                "dampcavesimple",
                "frozenwall",
                "rootjungle",
                "shipgraveyard",
                "skymeadow",
                "wispgraveyard",
                "ancientloft",
                "artifactworld01",
                "artifactworld",
                "artifactworld02",
                "artifactworld03",
                "helminthroost",
                "habitat",
                "habitatfall"
            };
        }

        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Objects.LoadAsset<Material>("matStatue");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matStatueCrystal");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matChampionBarrier");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matChampionBarrierBreak");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matStatueEye");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matBossShrineWave");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matStatueParticle");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Objects.LoadAsset<Material>("matStatueShard");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }

        protected override void Hooks()
        {
            On.RoR2.ClassicStageInfo.RebuildCards += ClassicStageInfo_RebuildCards;
        }

        private void ClassicStageInfo_RebuildCards(On.RoR2.ClassicStageInfo.orig_RebuildCards orig, ClassicStageInfo self, DirectorCardCategorySelection forcedMonsterCategory, DirectorCardCategorySelection forcedInteractableCategory)
        {
            orig.Invoke(self, forcedMonsterCategory, forcedInteractableCategory);
            if (this.sceneAddresses.Contains(SceneCatalog.GetSceneDefForCurrentScene().cachedName))
            {
                DirectorCardCategorySelection dccs = self.interactableCategories;
                if (dccs != null)
                {
                    bool flag = false;
                    foreach (var c in dccs.categories)
                    {
                        if (c.name == "bossShrine")
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        int index = dccs.AddCategory("bossShrine", 0.5f);
                        dccs.AddCard(index, Content.Interactables.dcBossShrine);
                    }
                }
            }
        }

    }
}
