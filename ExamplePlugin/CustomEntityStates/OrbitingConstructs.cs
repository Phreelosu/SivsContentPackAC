using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;
using EntityStates;
using UnityEngine.Networking;
using SivsContentPack.Config;
using SivsContentPack.Items;
using RoR2.Orbs;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;

namespace SivsContentPack.CustomEntityStates.MiniConstructs
{
    public class MiniConstructOrb : GenericDamageOrb
    {
        public override GameObject GetOrbEffect()
        {
            return Content.Effects.MiniConstructOrb.prefab;
        }
    }
    public class BaseMiniConstructState : EntityState
    {
        protected enum ConstructState
        {
            Closed,
            Open,
            Opening,
            Closing,
            Attacking,
        }

        public bool isAttacking;

        public bool openShell;
        public bool closeShell;

        protected ConstructState state;
        protected Animator constructAnimator;

        protected ChildLocator childLocator;

        protected NetworkedBodyAttachment bodyAttachment;

        protected CharacterBody parentBody;

        public HurtBox currentTarget;

        protected SphereSearch sphereSearch;

        private bool linkedToObject;



        public override void OnEnter()
        {

            this.bodyAttachment = base.GetComponent<NetworkedBodyAttachment>();
            base.OnEnter();
        }
        public override void OnExit()
        {
            base.OnExit();
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
        protected virtual ConstructState GetShellState()
        {
            return this.state;
        }
    }
    public class MC_AIState : BaseMiniConstructState
    {
        private float currentAttention;

        public static float attentionDuration = 10f;

        private float visionDistance = 50f;

        private EntityStateMachine bodyMachine;
        public override void OnEnter()
        {
            base.OnEnter();
            this.bodyAttachment = this.GetComponent<NetworkedBodyAttachment>();
            this.bodyMachine = EntityStateMachine.FindByCustomName(this.gameObject, "Body");
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if(base.isAuthority && this.bodyAttachment.attachedBody)
            {
                this.isAttacking = false;
                this.openShell = false;
                this.closeShell = false;
                ManageAttention();
                ManageInputs();
                this.state = DetermineBodyState();
                ManageBodyState();
                //DebugLog();
            }
        }
        private void DebugLog()
        {
            string tg = "N/A";
            if (currentTarget)
            {
                tg = currentTarget.healthComponent.gameObject.ToString();
            }
            Debug.LogFormat("Mini Construct #{0}\n- Owner: {5}\n- Body State: {6}\n- Current state: {4}\n- Current Target: {8}\n- Attention: {7}\n- Inputs:\n  - Attack?: {1}\n  - Open Shell?: {2}\n  - Close Shell?: {3}", this.gameObject.GetInstanceID(), isAttacking, openShell, closeShell, this.state.ToString(), this.bodyAttachment.attachedBody, bodyMachine.state.ToString(), currentAttention, tg);
        }
        private void ManageAttention()
        {
            if (this.currentAttention > 0)
            {
                this.currentAttention -= base.GetDeltaTime();

                if (this.currentTarget != null)
                {
                    if (!this.currentTarget.healthComponent.alive || Vector3.Distance(this.transform.position, currentTarget.transform.position) >= visionDistance)
                    {
                        currentTarget = null;
                        this.currentAttention = 0;
                    }
                }
            }
            if (currentAttention <= 0)
            {
                this.currentTarget = null;
            }
            if (!currentTarget)
            {
                this.currentTarget = FindTarget();
            }
        }
        public HurtBox FindTarget()
        {
            if (this.currentTarget)
            {
                return this.currentTarget;
            }
            if (this.sphereSearch == null)
            {
                this.sphereSearch = new SphereSearch();
            }
            HurtBox target = null;
            List<HurtBox> validTargets = new List<HurtBox>();
            this.sphereSearch.mask = LayerIndex.entityPrecise.mask;
            this.sphereSearch.origin = this.transform.position;
            this.sphereSearch.radius = visionDistance + this.bodyAttachment.attachedBody.radius;
            this.sphereSearch.queryTriggerInteraction = QueryTriggerInteraction.UseGlobal;
            this.sphereSearch.RefreshCandidates();
            TeamMask t = TeamMask.GetEnemyTeams(this.bodyAttachment.attachedBody.teamComponent.teamIndex);
            t.RemoveTeam(TeamIndex.Neutral);
            this.sphereSearch.FilterCandidatesByHurtBoxTeam(t);
            this.sphereSearch.OrderCandidatesByDistance();
            this.sphereSearch.FilterCandidatesByDistinctHurtBoxEntities();
            this.sphereSearch.GetHurtBoxes(validTargets);
            this.sphereSearch.ClearCandidates();
            if (validTargets.Count > 0)
            {
                target = validTargets.First<HurtBox>();
                this.currentAttention = MC_AIState.attentionDuration;
            }
            return target;
        }
        private void ManageInputs()
        {
            if(this.currentTarget != null)
            {
                if(this.state != ConstructState.Attacking)
                {
                    this.isAttacking = true;
                }
                if (this.state == ConstructState.Closed)
                {
                    this.openShell = true;
                    return;
                }
            }
            else
            {
                this.isAttacking = false;
                if (this.state == ConstructState.Open)
                {
                    this.closeShell = true;
                    return;
                }
            }
        }
        private ConstructState DetermineBodyState()
        {
            if(this.bodyMachine.state.GetType() == typeof(MC_Opening))
            {
                return ConstructState.Opening;
            };

            if (this.bodyMachine.state.GetType() == typeof(MC_IdleOpen))
            {
                return ConstructState.Open;
            };

            if (this.bodyMachine.state.GetType() == typeof(MC_Attack))
            {
                return ConstructState.Attacking;
            };

            if (this.bodyMachine.state.GetType() == typeof(MC_IdleClosed))
            {
                return ConstructState.Closed;
            };

            if (this.bodyMachine.state.GetType() == typeof(MC_Closing))
            {
                return ConstructState.Closing;
            };
            Debug.Log("Returning default for construct state");
            return ConstructState.Closed;
        }
        private void ManageBodyState()
        {
            if(this.state == ConstructState.Attacking)
            {
                return;
            }
            if (this.isAttacking && this.bodyAttachment.attachedBody && this.state == ConstructState.Open)
            {
                this.bodyMachine.SetState(new MC_Attack()
                {
                    currentTarget = this.currentTarget
                });
                this.isAttacking = false;
                return;
            }
            if (this.closeShell && (this.state == ConstructState.Open))
            {
                this.bodyMachine.SetState(new MC_Closing()
                {
                    currentTarget = this.currentTarget
                });
                this.closeShell = false;
                return;
            }
            if (this.openShell && (this.state == ConstructState.Closed))
            {
                this.bodyMachine.SetState(new MC_Opening()
                {
                    currentTarget = this.currentTarget
                });
                this.openShell = false;
                return;
            }
        }
    }
    public class MC_IdleClosed : BaseMiniConstructState
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
        protected override ConstructState GetShellState()
        {
            return ConstructState.Closed;
        }
    }
    public class MC_IdleOpen : BaseMiniConstructState
    {

        protected override ConstructState GetShellState()
        {
            return ConstructState.Open;
        }
    }
    public class MC_BaseShellChangeState : BaseMiniConstructState
    {
        protected virtual EntityState GetNextState()
        {
            return new BaseMiniConstructState();
        }
        protected virtual bool GetAnimatorBoolValue()
        {
            return false;
        }

        public static float baseDuration = 0.5f;
        public static int ShellBoolHash = Animator.StringToHash("atRest");
        private float duration;
        public override void OnEnter()
        {
            this.duration = MC_BaseShellChangeState.baseDuration;
            this.outer.SetNextState(GetNextState());
            Animator a = this.GetModelAnimator();
            if(a != null)
            {
                a.SetBool(ShellBoolHash, GetAnimatorBoolValue());
            }
            base.OnEnter();

        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.isAuthority && this.fixedAge >= duration)
            {
                this.outer.SetNextStateToMain();
            }
        }
    }
    public class MC_Opening : MC_BaseShellChangeState
    {
        protected override ConstructState GetShellState()
        {
            return ConstructState.Opening;
        }
        protected override EntityState GetNextState()
        {
            return new MC_IdleOpen();
        }
        protected override bool GetAnimatorBoolValue()
        {
            return false;
        }
    }
    public class MC_Closing : MC_BaseShellChangeState
    {
        protected override ConstructState GetShellState()
        {
            return ConstructState.Closing;
        }
        protected override EntityState GetNextState()
        {
            return new MC_IdleClosed();
        }
        protected override bool GetAnimatorBoolValue()
        {
            return true;
        }
    }
    public class MC_Attack : BaseMiniConstructState
    {
        protected override ConstructState GetShellState()
        {
            return ConstructState.Attacking;
        }
        public override void OnEnter()
        {
            base.OnEnter();
            this.fixedAge = 0;
            this.firedShot = false;
            this.duration = MC_Attack.baseDuration / this.bodyAttachment.attachedBody.attackSpeed;
            this.attackTime = MC_Attack.baseAttackTime / this.bodyAttachment.attachedBody.attackSpeed;
            Transform muzzle = this.GetModelChildLocator().FindChild("Muzzle");
            GameObject chargeFX = GameObject.Instantiate(Content.Effects.MiniConstructCharge.prefab, muzzle.transform.position, muzzle.transform.rotation, muzzle);
            ScaleParticleSystemDuration component = chargeFX.GetComponent<ScaleParticleSystemDuration>();
            if (component)
            {
                component.newDuration = this.attackTime;
            }
            this.PlayAnim();
        }
        protected virtual void PlayAnim()
        {
            base.PlayCrossfade("Body", MC_Attack.FireStateHash, MC_Attack.AttackSpeedHash, this.duration, 0.1f);
        }
        public override void FixedUpdate()
        {
            if (base.isAuthority)
            {

                if (this.fixedAge >= this.attackTime && !this.firedShot)
                {
                    FireOrbAttack();
                }
                if (this.fixedAge >= this.duration)
                {
                    this.isAttacking = false;
                    this.outer.SetNextState(new MC_IdleOpen());
                    return;
                }
            }
            base.FixedUpdate();
        }
        private void FireOrbAttack()
        {
            if (!this.bodyAttachment.attachedBody || !NetworkServer.active)
            {
                return;
            }
            RoR2.Util.PlaySound("Play_minorConstruct_attack_shoot", this.outer.gameObject);
            GenericDamageOrb genericDamageOrb = this.CreateShotOrb();
            genericDamageOrb.damageValue = this.bodyAttachment.attachedBody.damage * Configuration.Items.OrbitingConstructs.damageCoefficient;
            genericDamageOrb.isCrit = this.bodyAttachment.attachedBody.RollCrit();
            genericDamageOrb.teamIndex = TeamComponent.GetObjectTeam(this.bodyAttachment.attachedBody.gameObject);
            genericDamageOrb.attacker = this.bodyAttachment.attachedBody.gameObject;
            genericDamageOrb.procCoefficient = orbProcCoefficient;
            HurtBox hurtBox = this.currentTarget;
            if (hurtBox)
            {
                Transform transform = this.GetModelChildLocator().FindChild(MC_Attack.muzzleString);
                EffectManager.SimpleMuzzleFlash(Content.Effects.MiniConstructMuzzleFlash.prefab, base.gameObject, MC_Attack.muzzleString, true);
                genericDamageOrb.origin = transform.position;
                genericDamageOrb.target = hurtBox;
                OrbManager.instance.AddOrb(genericDamageOrb);
            }
            this.firedShot = true;
        }
        protected virtual GenericDamageOrb CreateShotOrb()
        {
            return new MiniConstructOrb();
        }

        
        protected float duration;
        protected float attackTime;

        protected bool firedShot;

        public static float baseDuration = 2f;

        public static float orbProcCoefficient = 1.0f;

        public static float baseAttackTime = 1.5f;

        public static string muzzleString = "Muzzle";

        private static int FireStateHash = Animator.StringToHash("Fire");
        private static int AttackSpeedHash = Animator.StringToHash("AttackSpeed");
    }
}
