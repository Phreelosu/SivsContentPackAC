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

namespace SivsContentPack
{
    public class Shadow : EliteFactory
    {
        protected override void LoadAssets(ref EliteDef eliteDef)
        {
            eliteDef = Assets.AssetBundles.Elites.LoadAsset<EliteDef>("edShadow");
            this.colorRamp = Assets.AssetBundles.Elites.LoadAsset<Texture2D>("texRampEliteObscuring");

        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Elites.Obscuring.enabled.Value;
        }
        protected override IEnumerable<CombatDirector.EliteTierDef> GetEliteTiers()
        {

            return new CombatDirector.EliteTierDef[]
            {
                EliteAPI.VanillaEliteTiers[1],
                EliteAPI.VanillaEliteTiers[2],
                EliteAPI.VanillaEliteTiers[3],
            };
        }
    }
    public class Unstable : EliteFactory
    {
        protected override void LoadAssets(ref EliteDef eliteDef)
        {
            eliteDef = Assets.AssetBundles.Elites.LoadAsset<EliteDef>("edUnstable");
            this.colorRamp = Assets.AssetBundles.Elites.LoadAsset<Texture2D>("texRampEliteUnstable");

        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Elites.Unstable.enabled.Value;
        }
        protected override IEnumerable<CombatDirector.EliteTierDef> GetEliteTiers()
        {

            return new CombatDirector.EliteTierDef[]
            {
                EliteAPI.VanillaEliteTiers[5]
            };
        }
    }
    public class Tar : EliteFactory
    {
        /// <summary>
        /// A list of strings that correspond to the names of SceneDefs. When checking to see if a Tar elite can spawn, the combat director references this list to see if the current Scene is in this list. If so, then Tar elites follow normal Elite spawning rules. If not, Tar elites won't spawn at all.
        /// </summary>
        public static List<string> validSpawns = new List<string>()
        {
            "goolake",
            "ancientloft",
            "drybasin",
            "artifactworld01",
            "artifactworld02",
            "habitatfall",
            "arena",
            "itancientloft",
            "itgoolake",
            "sulfurpools",
        };
        public static CombatDirector.EliteTierDef eliteTierDef;
        protected override void LoadAssets(ref EliteDef eliteDef)
        {
            eliteDef = Assets.AssetBundles.Elites.LoadAsset<EliteDef>("edTar");
            this.colorRamp = Assets.AssetBundles.Elites.LoadAsset<Texture2D>("texRampEliteTar");
            eliteTierDef = new CombatDirector.EliteTierDef()
            {
                costMultiplier = Configuration.Elites.Tar.costMult,
                isAvailable = ((SpawnCard.EliteRules rules) => IsTarAvailable(rules)),
                eliteTypes = new EliteDef[]
                {
                    eliteDef
                },
                canSelectWithoutAvailableEliteDef = false
            };
            EliteAPI.AddCustomEliteTier(eliteTierDef);
        }

        private bool IsTarAvailable(SpawnCard.EliteRules rules)
        {
            SceneDef sc = SceneCatalog.currentSceneDef;
            if (sc != null)
            {
                string s = sc.cachedName;
                if (validSpawns.Contains(s) || RunArtifactManager.instance.IsArtifactEnabled(RoR2Content.Artifacts.mixEnemyArtifactDef))
                {
                    return (rules == SpawnCard.EliteRules.Default);
                }
            }
            return false;
        }

        protected override bool CheckIfEnabled()
        {
            return Configuration.Elites.Tar.enabled.Value;
        }
        protected override void Hooks()
        {
            On.RoR2.CombatDirector.Awake += CombatDirector_Awake;
        }

        private void CombatDirector_Awake(On.RoR2.CombatDirector.orig_Awake orig, CombatDirector self)
        {
            orig.Invoke(self);

        }

        protected override IEnumerable<CombatDirector.EliteTierDef> GetEliteTiers()
        {

            return new CombatDirector.EliteTierDef[]
            {
                eliteTierDef
            };
        }
    }
    public class Tank : EliteFactory
    {
        protected override void LoadAssets(ref EliteDef eliteDef)
        {
            eliteDef = Assets.AssetBundles.Elites.LoadAsset<EliteDef>("edTank");
            this.colorRamp = Assets.AssetBundles.Elites.LoadAsset<Texture2D>("texRampEliteTank");

        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Elites.Tank.enabled.Value;
        }
        protected override IEnumerable<CombatDirector.EliteTierDef> GetEliteTiers()
        {
            return new CombatDirector.EliteTierDef[]
            {
                EliteAPI.VanillaFirstTierDef,
            };
        }
    }
    public class Empowering : EliteFactory
    {
        protected override void LoadAssets(ref EliteDef eliteDef)
        {
            eliteDef = Assets.AssetBundles.Elites.LoadAsset<EliteDef>("edEmpowering");
            this.colorRamp = Assets.AssetBundles.Elites.LoadAsset<Texture2D>("texRampEliteEmpowering");
        }
        protected override bool CheckIfEnabled()
        {
            return Configuration.Elites.Empowering.enabled.Value;
        }
    }
    public class Champion : EliteFactory
    {
        public class ChampionInventory
        {
            public Dictionary<ItemDef, int> items;
        }
        protected override void LoadAssets(ref EliteDef eliteDef)
        {
            base.LoadAssets(ref eliteDef);
        }
        protected override bool CheckIfEnabled()
        {
            return true;
        }
    }
}
