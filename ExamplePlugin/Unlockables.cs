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
using RoR2.Achievements;
using RoR2.Achievements.Artifacts;

namespace SivsContentPack
{
    public class ArtifactSpecializedItems : UnlockableFactory
    {
        protected override void LoadAssets(ref UnlockableDef unlockableDef)
        {
            unlockableDef = Assets.AssetBundles.Artifacts.LoadAsset<UnlockableDef>("Artifacts.SpecializedItems");
        }
    }
    public class UnlockGodTier : UnlockableFactory
    {
        protected override void LoadAssets(ref UnlockableDef unlockableDef)
        {
            unlockableDef = Assets.AssetBundles.Objects.LoadAsset<UnlockableDef>("udBossShrine");
        }
    }
    public class UnlockGodMode : UnlockableFactory
    {
        protected override void LoadAssets(ref UnlockableDef unlockableDef)
        {
            unlockableDef = Assets.AssetBundles.Items.LoadAsset<UnlockableDef>("udGodMode");
        }
    }
    public class UnlockLunarRosary : UnlockableFactory
    {
        protected override void LoadAssets(ref UnlockableDef unlockableDef)
        {
            unlockableDef = Assets.AssetBundles.Items.LoadAsset<UnlockableDef>("udLunarRosary");
        }
    }
    public class UnlockThunderAura : UnlockableFactory
    {
        protected override void LoadAssets(ref UnlockableDef unlockableDef)
        {
            unlockableDef = Assets.AssetBundles.Items.LoadAsset<UnlockableDef>("udThunderAura");
        }
    }

    public class UnlockVoidEye : UnlockableFactory
    {
        protected override void LoadAssets(ref UnlockableDef unlockableDef)
        {
            unlockableDef = Assets.AssetBundles.Items.LoadAsset<UnlockableDef>("udVoidEye");
        }
    }

    [RegisterAchievement("UnlockGodMode", "udGodMode", null, 10U, null)]
    public class GodModeUnlockAchievement : BaseAchievement
    {
        public override void OnInstall()
        {
            base.OnInstall();
            RoR2Application.onUpdate += this.CheckIfGodModeObtained;
        }

        public override void OnUninstall()
        {
            RoR2Application.onUpdate -= this.CheckIfGodModeObtained;
            base.OnUninstall();
        }

        public void CheckIfGodModeObtained()
        {
            if (base.localUser != null && base.localUser.cachedBody && base.localUser.cachedBody.inventory.GetItemCountEffective(Content.Items.Godmode) > 0)
            {
                base.Grant();
            }
        }

    }
    [RegisterAchievement("UnlockThunderAura", "udThunderAura", null, 10U, null)]
    public class ThunderAuraUnlockAchievement : BaseAchievement
    {
        public override void OnInstall()
        {
            base.OnInstall();
            RoR2Application.onUpdate += this.CheckIfThunderAuraObtained;
        }

        public override void OnUninstall()
        {
            RoR2Application.onUpdate -= this.CheckIfThunderAuraObtained;
            base.OnUninstall();
        }

        public void CheckIfThunderAuraObtained()
        {
            if (base.localUser != null && base.localUser.cachedBody && base.localUser.cachedBody.inventory.GetItemCountEffective(Content.Items.ThunderAura) > 0)
            {
                base.Grant();
            }
        }

    }
    [RegisterAchievement("UnlockVoidEye", "udVoidEye", null, 10U, null)]
    public class VoidEyeUnlockAchievement : BaseAchievement
    {
        public override void OnInstall()
        {
            base.OnInstall();
            RoR2Application.onUpdate += this.CheckIfVoidEyeObtained;
        }

        public override void OnUninstall()
        {
            RoR2Application.onUpdate -= this.CheckIfVoidEyeObtained;
            base.OnUninstall();
        }

        public void CheckIfVoidEyeObtained()
        {
            if (base.localUser != null && base.localUser.cachedBody && base.localUser.cachedBody.inventory.GetItemCountEffective(Content.Items.VoidEye) > 0)
            {
                base.Grant();
            }
        }

    }

    [RegisterAchievement("UnlockLunarRosary", "udLunarRosary", null, 10U, null)]
    public class LunarRosaryUnlockAchievement : BaseAchievement
    {
        public override void OnInstall()
        {
            base.OnInstall();
            RoR2Application.onUpdate += this.CheckIfLunarRosaryObtained;
        }

        public override void OnUninstall()
        {
            RoR2Application.onUpdate -= this.CheckIfLunarRosaryObtained;
            base.OnUninstall();
        }

        public void CheckIfLunarRosaryObtained()
        {
            if (base.localUser != null && base.localUser.cachedBody && base.localUser.cachedBody.inventory.GetItemCountEffective(Content.Items.LunarRosary) > 0)
            {
                base.Grant();
            }
        }

    }

    [RegisterAchievement("UnlockGodTier", "udBossShrine", null, 3U, null)]
    public class GodTierUnlockAchievement : BaseAchievement
    {

        public static List<String> achievementsToCheckFor = new List<string>()
        {
            "UnlockGodMode",
            "UnlockThunderAura",
            "UnlockVoidEye",
            "UnlockLunarRosary"
        };
        public override void OnInstall()
        {
            base.OnInstall();
            RoR2Application.onUpdate += this.CheckIfGodTierUnlocked;
        }

        public override void OnUninstall()
        {
            RoR2Application.onUpdate -= this.CheckIfGodTierUnlocked;
            base.OnUninstall();
        }

        public void CheckIfGodTierUnlocked()
        {
            if (base.localUser != null)
            {
                bool flag = false;
                foreach (var achievement in achievementsToCheckFor)
                {
                    if (base.localUser.userProfile.achievementsList.Contains(achievement))
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    base.Grant();
                }
            }
        }

    }

    [RegisterAchievement("ObtainArtifactSpecializedItems", "Artifacts.SpecializedItems", null, 3U, null)]
    public class ObtainArtifactSpecializedItems : BaseObtainArtifactAchievement
    {
        public override ArtifactDef artifactDef
        {
            get
            {
                return Content.Artifacts.EnemySpecializedItems;
            }
        }
    }
}
