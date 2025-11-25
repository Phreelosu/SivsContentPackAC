using R2API;
using RoR2;
using RoR2.Orbs;
using SivsContentPack.Config;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SivsContentPack
{
    public class BlockLowDamageHitsProc : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("BlockLowDamageHitsProc");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matNuclearGoo");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matNuclearBlock");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }

    public class DoubleProjectilesProc : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("RoyalJellyProc");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matRJProc");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
        }
    }

    public class CupcakeProc : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("efConfettiBurst");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matConfetti");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matDistortion");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Distortion");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matHealingCross");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }


    public class CorruptedSpikeImpact : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("CorruptedSpikeImpact");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {

        }
    }
    public class DeathImmunityProc : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("DeathImmunityProcEffect");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matAngelEffect");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }
    public class TransformationComplete : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("TransformationCompleteFX");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {

        }
    }

    public class CorruptionTakesHold : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("CorruptionTakesHoldFX");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matCorruptionTakesHold");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matCorruptionTakesHold2");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
        }
    }

    public class CorruptionLifts : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("CorruptionLiftsFX");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matCorruptionTakesHold");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
        }
    }

    public class GoldStarProc : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("StarProcEffect");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matStarEffect");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
    }
    public class CoinProc : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("ProcBoostEffect");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {

        }
    }

    public class GoldStarOrbEffect : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("GoldStarRewardOrb");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matStarEffect");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matCoin1");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
    }
    public class SmiteEffect : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("SmiteEffect");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matSmiteLightning");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSmiteBlast");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSmiteGroundImpact");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }

    public class GlassShieldBreakProc : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("GlassShieldBreakEffect");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matGlassShards");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matOmniHitspark 1");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }

    public class FrenzyOnBossKillProc : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("BossKillFrenzyProc");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matDistortion");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Distortion");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matFrenzyOnBossKillWave");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matFrenzyOnBossKillPulse");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPhantomSaberProc");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }
    public class MiniConstructHitSparks : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("HitsparkOrbitingConstructs");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matOmniHitspark1");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matGenericFlash");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matMiniConstructElectric");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }
    public class MiniConstructMuzzleFlash : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("MuzzleFlashMiniConstruct");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matMiniConstructTrail");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matMiniConstructElectric");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }
    public class MiniConstructOrbTracer : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("MiniConstructAttackOrb");
            effectDef.prefab = this.prefab;
            
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matMiniConstructTrail");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matMiniConstructProjectile");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }
    public class MiniConstructCharge : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("MiniConstructChargeFX");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matMiniConstructProjectile");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matMiniConstructElectric");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }
    public class VoidMineVFX : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("VoidMineVFX");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidMineBillboard");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matVoidMineFlame");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTracerBright");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSBVFragment");
            Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
        }
    }
    public class WispOnHitMuzzleFlash : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("MuzzleflashMiniWisp");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matTracerBright");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matArcaneCircleWisp");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matOmniRing1Generic");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matMiniWispFire");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }

    public class EliteUnstableFX : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Elites.LoadAsset<GameObject>("LunarFireballImpact");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Elites.LoadAsset<Material>("matUnstableFireball");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTracer");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matOmniRing1Generic");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }

    public class WispOnHitImpact : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("MiniWispImpact");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matTracerBright");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matArcaneCircleWisp");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matOmniRing1Generic");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matMiniWispFire");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }

    public class LightningStrikeEffect : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("LightningStrikeImpactEffect");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matOpaqueDustLarge");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matOpaqueDustLargeDirectional");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matTracerBright");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPrimeDevastatorVFX1");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matLunarRainSummonVFX2");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPrimeDevastatorVFX3");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matDistortionFaded");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Distortion");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPrimeDevastatorVFX2");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matLightningStrikeImpactEffect1");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }


    public class ThunderAuraOrbiterImpact : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("ThunderAuraProjExplosion");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matTracerBright");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPrimeDevastatorVFX1");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matLunarRainSummonVFX2");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPrimeDevastatorVFX3");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPrimeDevastatorChargeVFX2");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matDistortionFaded");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Distortion");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matPrimeDevastatorVFX2");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matLightningStrikeImpactEffect1");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matShockAttack");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }
    public class GriefProc : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("GriefProc");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matGriefProc");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }
    public class ShadowCloakBreak : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Elites.LoadAsset<GameObject>("ShadowCloakBreak");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Elites.LoadAsset<Material>("matShadowCloak");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
            m = Assets.AssetBundles.Elites.LoadAsset<Material>("matShadowTracer");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matDistortion");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Distortion");
        }
    }
    public class FireEyeOrb : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("FireEyeProcOrb");
            effectDef.prefab = this.prefab;

        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matFireEyeProcOrb");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matFireEyeProcRing");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }
    public class TarLifeStealOrbFX : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Elites.LoadAsset<GameObject>("TarLifeStealOrb");
            effectDef.prefab = this.prefab;

        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Elites.LoadAsset<Material>("matTarLifeSteal");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
        }
    }
    public class FireEyeProcEffect : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("FireEyeProcEffect");
            effectDef.prefab = this.prefab;

        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matFireEyeProcOrb");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matFireEyeProcRing");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }
    public class SingularityBlast : EffectFactory
    {
        protected override void LoadAssets(ref EffectDef effectDef)
        {
            effectDef = new EffectDef();
            this.prefab = Assets.AssetBundles.Items.LoadAsset<GameObject>("SingularityBlast");
            effectDef.prefab = this.prefab;
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Items.LoadAsset<Material>("matSingularityBillboard");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSingularityBlast");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Intersection Remap");
            m = Assets.AssetBundles.Items.LoadAsset<Material>("matSingularityTracer");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
    }
}
