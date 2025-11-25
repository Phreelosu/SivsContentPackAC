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
    public class ChargingLaserBaseState : EntityState
    {
        public float charge;
        public GameObject displayInstance;
        protected bool linkedToDisplay;
        protected Transform muzzleTransform;
        protected ChildLocator childLocator;
        protected Animator animator;
        protected NetworkedBodyAttachment bodyAttachment;
        public override void OnEnter()
        {
            this.bodyAttachment = this.outer.GetComponent<NetworkedBodyAttachment>();
            base.OnEnter();

        }

        public void LinkToDisplay()
        {
            if (linkedToDisplay)
            {
                return;
            }
            Transform m = this.GetModelTransform();
            if (m != null)
            {
                CharacterModel cm = m.GetComponent<CharacterModel>();
                List<GameObject> displays = cm.GetEquipmentDisplayObjects(Content.Items.ChargingLaser.equipmentIndex);
                if(displays.Count > 0)
                {
                    displayInstance = displays.First();
                    linkedToDisplay = true;
                }
            }
        }
    }

    public class CL_Spawn : ChargingLaserBaseState
    {
        private static float duration = 0.75f;
        public override void OnEnter()
        {
            base.OnEnter();
            this.charge = 0f;
            LinkToDisplay();
            if (linkedToDisplay)
            {
                if(this.modelLocator != null)
                {
                    modelLocator.modelTransform = displayInstance.transform;
                    animator = displayInstance.GetComponent<Animator>();
                    childLocator = displayInstance.GetComponent<ChildLocator>();
                }
            }
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if(base.isAuthority && this.fixedAge > duration)
            {

            }
        }
    }
    public class CL_Idle : ChargingLaserBaseState
    {
        
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.isAuthority)
            {

            }
        }

        private float GetChargeAmount()
        {
            float result = Configuration.Items.ChargingLaser.chargePerSecond;
            if (this.bodyAttachment)
            {
                CharacterBody cb = this.bodyAttachment.attachedBody;
                if (cb != null)
                {
                    EquipmentSlot eq = cb.equipmentSlot;
                    if (eq != null)
                    {
                        
                    }
                }
            }
            return result;
        }
    }
}
