using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine.Networking;
using RoR2;
using HG;
using UnityEngine;

namespace SivsContentPack
{
    [RequireComponent(typeof(NetworkedBodyAttachment))]
    public class HealNearbyController : NetworkBehaviour
    {
        protected void Awake()
        {
            this.transform = base.transform;
            this.networkedBodyAttachment = base.GetComponent<NetworkedBodyAttachment>();
            this.sphereSearch = new SphereSearch();
            this.timer = 0f;
        }

        protected void FixedUpdate()
        {
            this.timer -= Time.fixedDeltaTime;
            if (this.timer <= 0f)
            {
                this.timer += 1f / this.tickRate;
                this.Tick();
            }
        }

        protected void Tick()
        {
            if (!this.networkedBodyAttachment || !this.networkedBodyAttachment.attachedBody || !this.networkedBodyAttachment.attachedBodyObject)
            {
                return;
            }
            List<HurtBox> list = CollectionPool<HurtBox, List<HurtBox>>.RentCollection();
            this.SearchForTargets(list);
            float amount = this.damagePerSecondCoefficient * this.networkedBodyAttachment.attachedBody.damage / this.tickRate;
            List<Transform> list2 = CollectionPool<Transform, List<Transform>>.RentCollection();
            int i = 0;
            while (i < list.Count)
            {
                HurtBox hurtBox = list[i];
                if (!hurtBox || !hurtBox.healthComponent || !this.networkedBodyAttachment.attachedBody.healthComponent.alive || hurtBox.healthComponent.body.isElite || hurtBox.healthComponent.body.HasBuff(Content.Buffs.AffixEmpowering))
                {
                    goto IL_14A;
                }
                
                IL_158:
                i++;
                continue;
                IL_14A:
                if (list2.Count < this.maxTargets)
                {
                    goto IL_158;
                }
                break;
            }
            this.isTetheredToAtLeastOneObject = ((float)list2.Count > 0f);
            if (this.tetherVfxOrigin)
            {
                this.tetherVfxOrigin.SetTetheredTransforms(list2);
            }
            if (this.activeVfx)
            {
                this.activeVfx.SetActive(this.isTetheredToAtLeastOneObject);
            }
            CollectionPool<Transform, List<Transform>>.ReturnCollection(list2);
            CollectionPool<HurtBox, List<HurtBox>>.ReturnCollection(list);
        }

        private void GrantTargetAffix(CharacterBody body)
        {
            if(body != null)
            {
                ulong seed = (ulong)body.gameObject.GetInstanceID() + (ulong)body.master.gameObject.GetInstanceID() + Run.instance.seed + (ulong)Run.instance.time;
                bool alreadyHasEquipment = true;
                Inventory i = body.inventory;
                

            }
        }

        protected void SearchForTargets(List<HurtBox> dest)
        {
            TeamMask none = TeamMask.none;
            none.AddTeam(this.networkedBodyAttachment.attachedBody.teamComponent.teamIndex);
            this.sphereSearch.mask = LayerIndex.entityPrecise.mask;
            this.sphereSearch.origin = this.transform.position;
            this.sphereSearch.radius = this.radius + this.networkedBodyAttachment.attachedBody.radius;
            this.sphereSearch.queryTriggerInteraction = QueryTriggerInteraction.UseGlobal;
            this.sphereSearch.RefreshCandidates();
            this.sphereSearch.FilterCandidatesByHurtBoxTeam(none);
            this.sphereSearch.OrderCandidatesByDistance();
            this.sphereSearch.FilterCandidatesByDistinctHurtBoxEntities();
            this.sphereSearch.GetHurtBoxes(dest);
            this.sphereSearch.ClearCandidates();
        }

        private void UNetVersion()
        {
        }

        public float Networkradius
        {
            get
            {
                return this.radius;
            }
            [param: In]
            set
            {
                base.SetSyncVar<float>(value, ref this.radius, 1U);
            }
        }

        public int NetworkmaxTargets
        {
            get
            {
                return this.maxTargets;
            }
            [param: In]
            set
            {
                base.SetSyncVar<int>(value, ref this.maxTargets, 2U);
            }
        }

        public override bool OnSerialize(NetworkWriter writer, bool forceAll)
        {
            if (forceAll)
            {
                writer.Write(this.radius);
                writer.WritePackedUInt32((uint)this.maxTargets);
                return true;
            }
            bool flag = false;
            if ((base.syncVarDirtyBits & 1U) != 0U)
            {
                if (!flag)
                {
                    writer.WritePackedUInt32(base.syncVarDirtyBits);
                    flag = true;
                }
                writer.Write(this.radius);
            }
            if ((base.syncVarDirtyBits & 2U) != 0U)
            {
                if (!flag)
                {
                    writer.WritePackedUInt32(base.syncVarDirtyBits);
                    flag = true;
                }
                writer.WritePackedUInt32((uint)this.maxTargets);
            }
            if (!flag)
            {
                writer.WritePackedUInt32(base.syncVarDirtyBits);
            }
            return flag;
        }

        public override void OnDeserialize(NetworkReader reader, bool initialState)
        {
            if (initialState)
            {
                this.radius = reader.ReadSingle();
                this.maxTargets = (int)reader.ReadPackedUInt32();
                return;
            }
            int num = (int)reader.ReadPackedUInt32();
            if ((num & 1) != 0)
            {
                this.radius = reader.ReadSingle();
            }
            if ((num & 2) != 0)
            {
                this.maxTargets = (int)reader.ReadPackedUInt32();
            }
        }

        public override void PreStartClient()
        {
        }

        [SyncVar]
        public float radius;

        public float damagePerSecondCoefficient;

        [Min(1E-45f)]
        public float tickRate = 1f;

        [SyncVar]
        public int maxTargets;

        public TetherVfxOrigin tetherVfxOrigin;

        public GameObject activeVfx;

        protected new Transform transform;

        protected NetworkedBodyAttachment networkedBodyAttachment;

        protected SphereSearch sphereSearch;

        protected float timer;

        private bool isTetheredToAtLeastOneObject;
    }

    public class GoldDropOnHit : MonoBehaviour
    {
        public float goldDrop;
        public float droppedGold;

        private void Start()
        {

        }
    }
}
