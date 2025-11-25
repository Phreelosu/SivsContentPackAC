using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;
using EntityStates;
using UnityEngine.Networking;
using SivsContentPack.Config;
using SivsContentPack.Items;

namespace SivsContentPack.CustomEntityStates
{
    public class BaseTarbineState : EntityState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            this.networkedBodyAttachment = base.GetComponent<NetworkedBodyAttachment>();
            if (this.networkedBodyAttachment)
            {
                this.bodyGameObject = this.networkedBodyAttachment.attachedBodyObject;
                this.body = this.networkedBodyAttachment.attachedBody;
                if (this.bodyGameObject)
                {
                    this.bodyMaster = this.body.master;
                    this.bodyInputBank = this.bodyGameObject.GetComponent<InputBankTest>();
                    this.bodyEquipmentSlot = this.body.equipmentSlot;
                    ModelLocator component = this.body.GetComponent<ModelLocator>();
                    if (component)
                    {
                        this.bodyAimAnimator = component.modelTransform.GetComponent<AimAnimator>();
                    }
                    this.LinkToDisplay();
                }
            }
        }

        private void LinkToDisplay()
        {
            if (this.linkedToDisplay || this.body.inventory.GetItemCountEffective(Content.Items.Tarbine) <= 0)
            {
                return;
            }

            ModelLocator ml = this.body.modelLocator;
            if (ml != null)
            {
                CharacterModel cm = ml.modelTransform.GetComponent<CharacterModel>();
                if(cm != null)
                {
                    try
                    {
                        List<GameObject> displays = cm.GetItemDisplayObjects(Content.Items.Tarbine.itemIndex);
                        if (displays != null)
                        {
                            GameObject gunTransform = displays[0];
                            if (gunTransform != null)
                            {
                                ChildLocator cl = gunTransform.GetComponent<ChildLocator>();
                                if (cl != null)
                                {
                                    this.gunTransform = gunTransform.transform;
                                    this.gunChildLocator = cl;
                                    this.linkedToDisplay = true;
                                }
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException) //no display found
                    {
                        Debug.LogWarning("Warning - entity has no IDRS for Tarbine. Defaulting to core transform for origin.");
                        this.gunTransform = cm.transform;
                        this.linkedToDisplay = true;
                    }
                    
                }
            }
        }

        public override void FixedUpdate()
        {
            base.Update();
            if (base.isAuthority && this.bodyInputBank)
            {
                this.shouldFire = (this.body.HasBuff(Content.Buffs.Tarbine));
            }
            this.LinkToDisplay();
        }

        protected bool CheckReturnToIdle()
        {
            if (!base.isAuthority)
            {
                return false;
            }
            if (this.bodyMaster && !this.shouldFire)
            {
                this.outer.SetNextState(new TarbineIdle
                {
                    shouldFire = !this.shouldFire
                });
                return true;
            }
            return false;
        }

        protected NetworkedBodyAttachment networkedBodyAttachment;

        protected GameObject bodyGameObject;

        protected CharacterBody body;

        protected ChildLocator gunChildLocator;

        protected Animator gunAnimator;

        protected Transform gunTransform;

        protected CharacterMaster bodyMaster;

        protected EquipmentSlot bodyEquipmentSlot;

        protected InputBankTest bodyInputBank;

        protected AimAnimator bodyAimAnimator;

        public bool shouldFire;

        private bool linkedToDisplay;
    }

    public class TarbineFire : BaseTarbineState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            this.FireBullet();
        }

        private void FireBullet()
        {
            
            this.body.SetAimTimer(2f);
            float t = Mathf.Clamp01(this.totalStopwatch / TarbineFire.windUpDuration);
            this.fireFrequency = Configuration.Items.Tarbine.bulletsPerSecond;
            float num = Mathf.Lerp(TarbineFire.minSpread, TarbineFire.maxSpread, t);
            if (base.isAuthority)
            {
                UnityEngine.Object aimOriginTransform = this.body.aimOriginTransform;
                if (this.gunChildLocator)
                {
                    this.gunChildLocator.FindChild("Muzzle");
                }
                if (aimOriginTransform)
                {
                    float damageCoefficient = Configuration.Items.Tarbine.bulletDmgCoefficient;
                    Inventory i = this.body.inventory;
                    if (i != null)
                    {
                        int itemCount = i.GetItemCountEffective(Content.Items.Tarbine);
                        damageCoefficient = Util.GetStackingBehavior(Configuration.Items.Tarbine.bulletDmgCoefficient, Configuration.Items.Tarbine.bulletDmgCoefficientStack, itemCount);
                    }
                    BulletAttack ba = new BulletAttack
                    {
                        owner = this.networkedBodyAttachment.attachedBodyObject,
                        aimVector = this.bodyInputBank.aimDirection,
                        origin = this.bodyInputBank.aimOrigin,
                        falloffModel = BulletAttack.FalloffModel.DefaultBullet,
                        force = TarbineFire.force,
                        damage = this.body.damage * damageCoefficient,
                        damageColorIndex = DamageColorIndex.Item,
                        bulletCount = 1U,
                        minSpread = 0f,
                        procChainMask = default(ProcChainMask),
                        maxSpread = num,
                        tracerEffectPrefab = TarbineFire.tracerEffectPrefab,
                        isCrit = RoR2.Util.CheckRoll(this.body.crit, this.bodyMaster),
                        procCoefficient = TarbineFire.procCoefficient,
                        muzzleName = "Muzzle",
                        weapon = base.gameObject
                    };
                    ba.procChainMask.AddProc(Content.ProcTypes.tarbine);
                    ba.Fire();
                }
            }
            EffectManager.SimpleMuzzleFlash(TarbineFire.muzzleFlashEffectPrefab, base.gameObject, "Muzzle", false);
        }

        public override void Update()
        {
            base.Update();
            float deltaTime = Time.deltaTime;
            this.totalStopwatch += deltaTime;
            this.stopwatch += deltaTime;
            if (base.CheckReturnToIdle())
            {
                return;
            }
            if (this.stopwatch > 1f / this.fireFrequency)
            {
                this.stopwatch = 0f;
                this.FireBullet();
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public static float minSpread = 0f;

        public static float maxSpread = 2.5f;

        public static float windUpDuration = 0.5f;

        public static float force = 50f;

        public static float procCoefficient = 0.5f;

        public static GameObject tracerEffectPrefab = EntityStates.ClayBruiser.Weapon.MinigunFire.bulletTracerEffectPrefab;

        public static GameObject impactEffectPrefab = EntityStates.ClayBruiser.Weapon.MinigunFire.bulletHitEffectPrefab;

        public static GameObject muzzleFlashEffectPrefab = EntityStates.ClayBruiser.Weapon.MinigunFire.muzzleVfxPrefab;

        public static string windUpSoundString;

        public static string windUpRTPC;

        public float totalStopwatch;

        private float stopwatch;

        private float fireFrequency;

        private uint loopSoundID;

    }

    public class TarbineIdle : BaseTarbineState
    {
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void Update()
        {
            if (base.isAuthority && this.shouldFire && this.body.inventory.GetItemCountEffective(Content.Items.Tarbine) > 0)
            {
                this.outer.SetNextState(new TarbineFire
                {
                    shouldFire = this.shouldFire
                });
                return;
            }
        }

    }
}
