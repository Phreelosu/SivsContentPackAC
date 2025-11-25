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

namespace SivsContentPack
{
    internal class Design : ArtifactFactory
    {
        /// <summary>
        /// Design cannot give an enemy a higher stack count than what is described within this dictionary. Each entry has a string - corresponding to the name of an itemdef - and an int. Integer values of 0 or less will prevent the item from being granted outright. If an item is not present in this dictionary, the item has no limit.
        /// </summary>
        public static Dictionary<string, int> itemLimitDictionary = new Dictionary<string, int>()
        {
            {"BeetleGland", 2},
            {"RoboBallBuddy", 0},
            {"OrbitingConstructs", 0},
            {"GodMode", 2},
            {"VoidEye", 10},
            {"ThunderAura", 2},
        };

        /// <summary>
        /// Place an entry of two strings - one for the name of a characterbody, and one for the name of an itemdef - to allow Design to grant the body the desired item regardless of whether or not it appears in the body's BossDropTable. Will happen WITH the default Design behavior.
        /// </summary>
        public static Dictionary<string, string> overrideItemDictionary = new Dictionary<string, string>()
        {
            {"BrotherBody", "GodMode"},
            {"TitanGoldBody", "Knurl"},
            {"FalseSonBossBodyLunarShard", "ThunderAura"},
            {"FalseSonBossBody", "ThunderAura"},
            {"MiniVoidRaidCrabBodyPhase1", "VoidEye"},
            {"MiniVoidRaidCrabBodyPhase2", "VoidEye"},
        };

        protected override void LoadAssets(ref ArtifactDef artifactDef)
        {
            artifactDef = Assets.AssetBundles.Artifacts.LoadAsset<ArtifactDef>("adSpecializedItems");
            artifactCode = Assets.AssetBundles.Artifacts.LoadAsset<ArtifactCode>("acodeSpecializedItems");
            
        }

        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Artifacts.LoadAsset<Material>("matDesignCore");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }

        protected override void Hooks()
        {
            On.RoR2.CharacterMaster.OnBodyStart += CharacterMaster_OnBodyStart;
            On.RoR2.Run.Awake += Run_Awake;
        }

        private void Run_Awake(On.RoR2.Run.orig_Awake orig, Run self)
        {
            orig.Invoke(self);
            DesignItemController dic = self.gameObject.AddComponent<DesignItemController>();
        }

        private void CharacterMaster_OnBodyStart(On.RoR2.CharacterMaster.orig_OnBodyStart orig, CharacterMaster self, CharacterBody body)
        {
            orig.Invoke(self, body);
            if (RunArtifactManager.instance.IsArtifactEnabled(Content.Artifacts.EnemySpecializedItems) && DesignItemController.instance != null)
            {
                TeamComponent tc = body.teamComponent;
                if (tc != null)
                {
                    if (tc.teamIndex != TeamIndex.Player)
                    {
                        DeathRewards dr = body.GetComponent<DeathRewards>();
                        if (dr != null)
                        {
                            ExplicitPickupDropTable epdt = dr.bossDropTable as ExplicitPickupDropTable;
                            if (epdt != null)
                            {
                                foreach (var pickupEntry in epdt.pickupEntries)
                                {
                                    ItemDef item = pickupEntry.pickupDef as ItemDef;
                                    if (item != null) {
                                        bool flag = item.ContainsTag(ItemTag.AIBlacklist);
                                        int itemAmount = DesignItemController.instance.GetItemCountEffective(item);
                                        if (itemAmount > 0 && !flag)
                                        {
                                            Debug.LogFormat("Design: Drop table found. Granting {0} {1} of item {2}.", body.gameObject, itemAmount, item.name);
                                            Inventory i = body.inventory;
                                            if (i != null)
                                            {
                                                i.GiveItemPermanent(item, itemAmount);
                                            }
                                        }
                                        
                                    }
                                }
                            }

                        }
                        string name = body.gameObject.name.Replace("(Clone)", "");
                        if (overrideItemDictionary.ContainsKey(name))
                        {
                            ItemDef item = ItemCatalog.GetItemDef(ItemCatalog.itemNameToIndex[overrideItemDictionary[name]]);
                            if (item != null)
                            {
                                bool flag = item.ContainsTag(ItemTag.AIBlacklist);
                                int itemAmount = DesignItemController.instance.GetItemCountEffective(item);
                                if (itemAmount > 0 && !flag)
                                {
                                    Debug.LogFormat("Design: Body override found. Granting {0} {1} of item {2}.", body.gameObject, itemAmount, item.name);
                                    Inventory i = body.inventory;
                                    if (i != null)
                                    {
                                        i.GiveItemPermanent(item, itemAmount);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public class DesignItemController : MonoBehaviour
        {
            public static DesignItemController instance;

            private void OnEnable()
            {
                if (!instance)
                {
                    instance = this;
                }
                else
                {
                    Destroy(this);
                }
            }
            private void OnDisable()
            {
                if(instance == this)
                {
                    instance = null;
                }
            }
        
        
            public int GetItemCountEffective(ItemDef item)
            {
                if (itemLimitDictionary.ContainsKey(item.name))
                {
                    return Math.Clamp(Run.instance.stageClearCount + 1, 0, itemLimitDictionary[item.name]);
                }
                return Run.instance.stageClearCount + 1;
            }
        }
    }
}
