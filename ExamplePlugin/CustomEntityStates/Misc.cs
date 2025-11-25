using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;
using EntityStates;
using UnityEngine.Networking;
using SivsContentPack.Config;
using SivsContentPack.Items;
using RoR2.Projectile;
using RoR2.Orbs;
using System.Linq;

namespace SivsContentPack.CustomEntityStates
{
    public class VoidMine_Arming : EntityState
    {
        private static float duration = 1.5f;

        protected GameObject owner;

        protected ProjectileDamage damageComponent;

        protected ProjectileController controllerComponent;

        protected TeamFilter teamFilter;

        protected ProjectileTargetComponent targetComponent;

        protected ProjectileSphereTargetFinder targetFinder;

        protected ChildLocator childLocator;

        public override void OnEnter()
        {
            base.OnEnter();
            this.controllerComponent = base.GetComponent<ProjectileController>();
            this.damageComponent = base.GetComponent<ProjectileDamage>();
            this.teamFilter = base.GetComponent<TeamFilter>();
            this.targetComponent = base.GetComponent<ProjectileTargetComponent>();
            this.targetFinder = base.GetComponent<ProjectileSphereTargetFinder>();
            this.childLocator = base.GetComponent<ChildLocator>();
            if (targetFinder)
            {
                targetFinder.enabled = false;
            }
            if(this.controllerComponent != null)
            {
                this.owner = controllerComponent.owner;
            }
            if (this.childLocator)
            {
                Transform a = childLocator.FindChild("RangeIndicator");
                if (a != null)
                {
                    a.gameObject.SetActive(true);
                }
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.fixedAge >= VoidMine_Arming.duration && base.isAuthority)
            {
                targetFinder.enabled = true;
                this.outer.SetNextState(new VoidMine_Armed());
                return;
            }
        }

    }
    public class VoidMine_Armed : EntityState
    {
        private static float duration = 1.5f;

        protected GameObject owner;

        protected ProjectileDamage damageComponent;

        protected ProjectileController controllerComponent;

        protected TeamFilter teamFilter;

        protected ProjectileTargetComponent targetComponent;

        protected ProjectileSphereTargetFinder targetFinder;

        protected ProjectileExplosion explosion;

        public override void OnEnter()
        {
            base.OnEnter();
            this.controllerComponent = base.GetComponent<ProjectileController>();
            this.damageComponent = base.GetComponent<ProjectileDamage>();
            this.teamFilter = base.GetComponent<TeamFilter>();
            this.targetComponent = base.GetComponent<ProjectileTargetComponent>();
            this.targetFinder = base.GetComponent<ProjectileSphereTargetFinder>();
            this.explosion = base.GetComponent<ProjectileExplosion>();
            if (this.controllerComponent != null)
            {
                this.owner = controllerComponent.owner;
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if(this.targetComponent != null)
            {
                bool flag = this.targetComponent.transform != null;
                if(flag && base.isAuthority)
                {
                    if (this.explosion)
                    {
                        this.explosion.Detonate();
                    }
                }
            }
        }

    }
    public class FireEyeOrb : GenericDamageOrb
    {
        public override GameObject GetOrbEffect()
        {
            return Content.Effects.FireEyeOrb.prefab;
        }
        public override void OnArrival()
        {
            if (this.target)
            {
                CharacterBody cb = this.attacker.GetComponent<CharacterBody>();
                if(cb != null)
                {
                    Inventory i = cb.inventory;
                    if(i != null)
                    {
                        int itemCount = i.GetItemCountEffective(Content.Items.FireEye);
                        float coefficient = Util.GetStackingBehavior(Configuration.Items.FireEye.burnDamageCoefficient, Configuration.Items.FireEye.burnDamageCoefficientStack, itemCount);
                        InflictDotInfo idi = new InflictDotInfo()
                        {
                            attackerObject = this.attacker,
                            damageMultiplier = 1f,
                            duration = Configuration.Items.FireEye.burnDuration,
                            dotIndex = DotController.DotIndex.Burn,
                            totalDamage = this.damageValue * coefficient,
                            victimObject = this.target.healthComponent.gameObject
                        };
                        StrengthenBurnUtils.CheckDotForUpgrade(i, ref idi);
                        DotController.InflictDot(ref idi);
                    }
                }
            }
        }
    }
    public class FireEyeActive : BaseBodyAttachmentState
    {
        private float rechargeFrequency
        {
            get
            {
                return FireEyeActive.baseRechargeFrequency * (base.attachedBody ? base.attachedBody.attackSpeed : 1f);
            }
        }

        private float fireFrequency
        {
            get
            {
                return Mathf.Max(Configuration.Items.FireEye.blockInterval, this.rechargeFrequency);
            }
        }

        private float timeBetweenFiring
        {
            get
            {
                return 1f / this.fireFrequency;
            }
        }

        private bool isReadyToFire
        {
            get
            {
                return this.rechargeTimer <= 0f;
            }
        }

        protected int GetItemStack()
        {
            if (!base.attachedBody || !base.attachedBody.inventory)
            {
                return 1;
            }
            return base.attachedBody.inventory.GetItemCountEffective(Content.Items.FireEye);
        }

        protected GameObject GetItemDisplay()
        {
            CharacterBody cb = base.attachedBody;
            if (cb != null)
            {
                ModelLocator ml = cb.modelLocator;
                if (ml != null)
                {
                    CharacterModel cm = ml.modelTransform.GetComponent<CharacterModel>();
                    if (cm != null)
                    {
                        List<GameObject> obj = cm.GetItemDisplayObjects(Content.Items.FireEye.itemIndex);
                        if(obj.Count > 0)
                        {
                            return obj.First();
                        }
                    }
                }
            }
            return null;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            this.rechargeTimer = 0f;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (!NetworkServer.active)
            {
                return;
            }
            if (!linkedToDisplay)
            {
                //Debug.LogFormat("Linking to item display...");
                this.displayInstance = GetItemDisplay();
            }
            this.rechargeTimer -= base.GetDeltaTime();
            if (base.fixedAge > this.timeBetweenFiring)
            {
                base.fixedAge -= this.timeBetweenFiring;
                if (this.isReadyToFire && this.DeleteNearbyProjectile())
                {
                    if (linkedToDisplay)
                    {
                        Animator anim = displayInstance.GetComponent<Animator>();
                        if(anim != null)
                        {
                            anim.Play(animationHash);
                        }
                    }
                    this.rechargeTimer = this.rechargeFrequency;
                }
            }
        }

        private bool DeleteNearbyProjectile()
        {
            Vector3 vector = base.attachedBody ? base.attachedBody.corePosition : Vector3.zero;
            TeamIndex teamIndex = base.attachedBody ? base.attachedBody.teamComponent.teamIndex : TeamIndex.None;
            float num = FireEyeActive.projectileEraserRadius * FireEyeActive.projectileEraserRadius;
            int num2 = 0;
            int itemStack = this.GetItemStack();
            bool result = false;
            List<ProjectileController> instancesList = InstanceTracker.GetInstancesList<ProjectileController>();
            List<ProjectileController> list = new List<ProjectileController>();
            int num3 = 0;
            int count = instancesList.Count;
            while (num3 < count && num2 < itemStack)
            {
                ProjectileController projectileController = instancesList[num3];
                float dist = (projectileController.transform.position - vector).sqrMagnitude;
                Vector3 vect = (projectileController.transform.position - vector).normalized;
                if (!projectileController.cannotBeDeleted && projectileController.teamFilter.teamIndex != teamIndex && dist < num && Vector3.Dot(this.attachedBody.inputBank.aimDirection, vect) >= Configuration.Items.FireEye.dotThreshold)
                {
                    Debug.LogFormat("Found projectile! Dot Product: {0}", Vector3.Dot(this.attachedBody.inputBank.aimDirection, vect));
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
                    result = true;
                    Vector3 position = this.attachedBody.coreTransform.position;
                    ProjectileDamage pd = projectileController2.GetComponent<ProjectileDamage>();
                    if (pd != null)
                    {
                        if (projectileController2.owner)
                        {
                            
                            CharacterBody vo = projectileController2.owner.GetComponent<CharacterBody>();
                            if (vo != null)
                            {
                                Vector3 origin = position;
                                if (displayInstance)
                                {

                                    ChildLocator cl = displayInstance.GetComponent<ChildLocator>();
                                    if (cl != null)
                                    {
                                        Transform muzzle = cl.FindChild("Muzzle");
                                        if (muzzle != null)
                                        {
                                            origin = muzzle.position;
                                        }
                                    }
                                }
                                OrbManager.instance.AddOrb(new FireEyeOrb()
                                {
                                    attacker = this.attachedBody.gameObject,
                                    damageValue = pd.damage,
                                    isCrit = false,
                                    origin = origin,
                                    target = vo.mainHurtBox,
                                });
                                EffectData ed = new EffectData
                                {
                                    origin = projectileController2.transform.position,
                                    start = projectileController2.transform.position,
                                    rotation = projectileController2.transform.rotation,
                                };
                                EffectManager.SpawnEffect(Content.Effects.FireEyeProc.prefab, ed, true);
                                EntityState.Destroy(projectileController2.gameObject);
                            }
                        }
                        
                    }
                }
                i++;
            }
            return result;
        }

        private GameObject displayInstance;

        private bool linkedToDisplay
        {
            get
            {
                return displayInstance != null;
            }
        }
        public static int animationHash = Animator.StringToHash("animProc");

        public static float projectileEraserRadius = Configuration.Items.FireEye.projectileBlockRadius;

        public static float minimumFireFrequency;

        public static float baseRechargeFrequency = Configuration.Items.FireEye.blockInterval;

        private float rechargeTimer;
    }
    public class TarBodyAttachmentState : BaseBodyAttachmentState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            ChildLocator component = base.GetComponent<ChildLocator>();
            if (component)
            {
                Transform transform = component.FindChild("TarDrip");
                this.dripFX = ((transform != null) ? transform.GetComponent<ParticleSystem>() : null);
                if (this.dripFX)
                {
                    ParticleSystem.ShapeModule shape = this.dripFX.shape;
                    SkinnedMeshRenderer skinnedMeshRenderer = this.FindAttachedBodyMainRenderer();
                    if (skinnedMeshRenderer)
                    {
                        shape.skinnedMeshRenderer = this.FindAttachedBodyMainRenderer();
                        ParticleSystem.MainModule main = this.dripFX.main;
                        float x = skinnedMeshRenderer.transform.lossyScale.x;
                        main.startSize = 0.5f / x;
                    }
                }
            }
        }


        private SkinnedMeshRenderer FindAttachedBodyMainRenderer()
        {
            if (!base.attachedBody)
            {
                return null;
            }
            ModelLocator modelLocator = base.attachedBody.modelLocator;
            CharacterModel.RendererInfo[] array;
            if (modelLocator == null)
            {
                array = null;
            }
            else
            {
                CharacterModel component = modelLocator.modelTransform.GetComponent<CharacterModel>();
                array = ((component != null) ? component.baseRendererInfos : null);
            }
            CharacterModel.RendererInfo[] array2 = array;
            if (array2 == null)
            {
                return null;
            }
            for (int i = 0; i < array2.Length; i++)
            {
                SkinnedMeshRenderer skinnedMeshRenderer = array2[i].renderer as SkinnedMeshRenderer;
                if (skinnedMeshRenderer != null)
                {
                    return skinnedMeshRenderer;
                }
            }
            return null;
        }

        protected ParticleSystem dripFX;
    }
}
