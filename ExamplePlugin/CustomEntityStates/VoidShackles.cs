using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;
using EntityStates;
using UnityEngine.Networking;
using SivsContentPack.Config;
using SivsContentPack.Items;
using System.Linq;

namespace SivsContentPack.CustomEntityStates
{
    public class BaseVoidShackleState : EntityState
    {
        public HealthComponent target;
        public List<GameObject> chainInstances;
        public override void OnEnter()
        {
            base.OnEnter();
            
        }

        public override void FixedUpdate()
        {
            base.Update();
            if (base.isAuthority)
            {
                if(target == null || !target.alive)
                {
                    this.outer.SetNextStateToMain();
                }
            }
            
        }

    }

    public class VS_Spawn : BaseVoidShackleState
    {
        private static float duration = 1f;
        public override void OnEnter()
        {
            base.OnEnter();

        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.isAuthority && base.fixedAge >= duration)
            {
                this.outer.SetState(new VS_Chaining()
                {
                    target = this.target,
                    chainInstances = this.chainInstances
                });
            }
        }
    }
    public class VS_Destroy : BaseVoidShackleState
    {
        private static float duration = 1f;
        public override void OnEnter()
        {
            base.OnEnter();

        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.isAuthority && base.fixedAge >= duration)
            {
                EntityState.Destroy(this.outer);
            }
        }
    }
    public class VS_Chaining : BaseVoidShackleState
    {
        private static float duration = 1f;
        public override void OnEnter()
        {
            base.OnEnter();
            chainInstances = new List<GameObject>();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.isAuthority && base.fixedAge >= duration)
            {

            }
        }

        private void SpawnChains()
        {
            if (target != null)
            {
                HurtBoxGroup hbg = target.body.hurtBoxGroup;
                if (hbg != null)
                {
                    int chainCount = hbg.hurtBoxes.Length;
                    if (chainCount <= 1)
                    {
                        chainCount = 1;
                    }
                    
                }
            }
        }


    }
}
