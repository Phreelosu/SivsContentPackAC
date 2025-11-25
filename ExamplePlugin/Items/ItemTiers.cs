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
using EntityStates;
using SivsContentPack.CustomEntityStates.MiniConstructs;
using System.Linq;
using HarmonyLib;

namespace SivsContentPack.Items
{
    public class GodTier : ItemTierBase<GodTier> // Make sure to use ItemTierBase<T> for singleton structure
    {
        private GameObject godTierSystemPrefab;

        // 1. OVERRIDE VIRTUAL PROPERTIES
        // The base class will use these values in its CreateTier() method.

        // This sets itemTierDef.name
        public override string TierName { get; internal set; } = "GodTier";

        // This sets itemTierDef.canScrap
        public override bool canScrap { get; } = false;

        // This sets itemTierDef.canRestack
        public override bool canRestack { get; } = true;

        // You can also override the default highlightPrefab and dropletDisplayPrefab if necessary.
        // public override GameObject highlightPrefab { get; } = ...;
        // public override GameObject dropletDisplayPrefab { get; } = ...;

        // ---

        // 2. IMPLEMENT THE REQUIRED ABSTRACT METHOD
        // This is the method that was causing the 'GodTier' red underline.
        public override void Init()
        {
            // A. Load the system prefab once.
            godTierSystemPrefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("GodTierSystem");

            // B. Manually set the custom colors using the properties defined in the base class.
            // The base class's CreateTier() will read these properties:
            this.colorIndex = ColorsAPI.RegisterColor(new Color32(255, 191, 0, 255));
            this.darkColorIndex = ColorsAPI.RegisterColor(new Color32(228, 155, 15, 255));

            // C. Call the base method to set up and register the tier.
            // The base class creates the itemTierDef, sets the scrap/restack rules, and calls ContentAddition.AddItemTierDef(itemTierDef).
            base.CreateTier();

            // D. Assign the highlight prefab AFTER CreateTier(), as it might be overwritten by base.
            // The base class sets: itemTierDef.dropletDisplayPrefab = dropletDisplayPrefab
            // But it *doesn't* set itemTierDef.highlightPrefab, so we set it here using the correct field name (tierHighlightPrefab).
            itemTierDef.highlightPrefab = godTierSystemPrefab;
        }
    }
}
