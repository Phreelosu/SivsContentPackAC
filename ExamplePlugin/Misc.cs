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
    public class ShrineBossDropTable : PickupDropTable
    {
        public override void Regenerate(Run run)
        {
            this.GenerateWeightedSelection(run);
        }
        public void RegenerateDropTable(Run run)
        {
            this.GenerateWeightedSelection(run);
        }

        public bool IsFilterRequired()
        {
            return this.requiredItemTags.Length != 0 || this.bannedItemTags.Length != 0;
        }
        public bool PassesFilter(PickupIndex pickupIndex)
        {
            PickupDef pickupDef = PickupCatalog.GetPickupDef(pickupIndex);
            if (pickupDef.itemIndex != ItemIndex.None)
            {
                ItemDef itemDef = ItemCatalog.GetItemDef(pickupDef.itemIndex);
                foreach (ItemTag value in this.requiredItemTags)
                {
                    if (Array.IndexOf<ItemTag>(itemDef.tags, value) == -1)
                    {
                        return false;
                    }
                }
                foreach (ItemTag value2 in this.bannedItemTags)
                {
                    if (Array.IndexOf<ItemTag>(itemDef.tags, value2) != -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void Add(List<PickupIndex> sourceDropList, float chance)
        {
            if (chance <= 0f || sourceDropList.Count == 0)
            {
                return;
            }
            foreach (PickupIndex pickupIndex in sourceDropList)
            {
                if (!this.IsFilterRequired() || this.PassesFilter(pickupIndex))
                {
                    this.selector.AddChoice(pickupIndex, chance);
                }
            }
        }
        private void GenerateWeightedSelection(Run run)
        {
            this.selector.Clear();
            this.Add(run.availableBossDropList, this.bossWeight);
        }

        public override PickupIndex GenerateDropPreReplacement(Xoroshiro128Plus rng)
        {
            return PickupDropTable.GenerateDropFromWeightedSelection(rng, this.selector);
        }

        public override int GetPickupCount()
        {
            return this.selector.Count;
        }
        public override PickupIndex[] GenerateUniqueDropsPreReplacement(int maxDrops, Xoroshiro128Plus rng)
        {
            return PickupDropTable.GenerateUniqueDropsFromWeightedSelection(maxDrops, rng, this.selector);
        }

        public ItemTag[] requiredItemTags = Array.Empty<ItemTag>();

        public ItemTag[] bannedItemTags = Array.Empty<ItemTag>();

        public float bossWeight;

        public float godTierWeight;

        private readonly WeightedSelection<PickupIndex> selector = new WeightedSelection<PickupIndex>(8);
    }
}

