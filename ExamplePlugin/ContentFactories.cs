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
using UnityEngine.AddressableAssets.ResourceLocators;

namespace SivsContentPack
{
    public class ItemFactory
    {
        protected GameObject displayPrefab;
        public void Init(ref ItemDef itemDef)
        {
            if (itemDef != null)
            {
                Debug.LogWarningFormat("Content {0} has already been loaded.", itemDef.name);
                return;
            }
            if (!CheckIfEnabled())
            {
                Debug.LogFormat("Content {0} has been disabled.", this.GetType().Name);
                return;
            }
            LoadAssets(ref itemDef);
            SetUpItemRelationships(ref itemDef);
            HandleMaterials();
            RegisterLanguageTokens();
            ItemDisplayRuleDict idrs = new ItemDisplayRuleDict(null);
            RegisterItemDisplayRules(ref idrs);
            Hooks();
            CustomItem ci = new CustomItem(itemDef, idrs);
            ItemAPI.Add(ci);
            SubmitItemAsAddressablePair(ref itemDef);
            Debug.LogFormat("Loaded item {0} and submitted to content pack.", itemDef.name);
        }
        protected virtual bool CheckIfEnabled()
        {
            return true;
        }
        protected virtual void LoadAssets(ref ItemDef itemDef)
        {

        }
        protected virtual void HandleMaterials()
        {

        }
        protected virtual void SetUpExpansionRequirements(ref ItemDef itemDef)
        {

        }

        protected virtual void SetUpItemRelationships(ref ItemDef itemDef)
        {

        }
        protected virtual void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_???_NAME", "");
            LanguageAPI.Add("ITEM_???_PICKUP", "");
            LanguageAPI.Add("ITEM_???_DESCRIPTION", "");
            LanguageAPI.Add("ITEM_???_LORE", "");
        }
        protected virtual void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiWalkerTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EquipmentDroneBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("ScavBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
        }

        protected virtual void Hooks()
        {

        }

        protected virtual void SubmitItemAsAddressablePair(ref ItemDef itemDef)
        {

        }
    }
    public class EquipFactory
    {
        protected GameObject displayPrefab;
        public void Init(ref EquipmentDef equipDef)
        {
            if (equipDef != null)
            {
                Debug.LogWarningFormat("Content {0} has already been loaded.", equipDef.name);
                return;
            }
            LoadAssets(ref equipDef);
            HandleMaterials();
            RegisterLanguageTokens();
            ItemDisplayRuleDict idrs = new ItemDisplayRuleDict(null);
            RegisterItemDisplayRules(ref idrs);
            Hooks();
            CustomEquipment ce = new CustomEquipment(equipDef, idrs);
            ItemAPI.Add(ce);
            SubmitEquipAsAddressablePair(ref equipDef);
            Debug.LogFormat("Loaded equipment {0} and submitted to content pack.", equipDef.name);
        }
        protected virtual void LoadAssets(ref EquipmentDef equipDef)
        {

        }
        protected virtual bool CheckIfEnabled()
        {
            return true;
        }
        protected virtual void HandleMaterials()
        {

        }
        protected virtual void RegisterLanguageTokens()
        {
            LanguageAPI.Add("ITEM_???_NAME", "");
            LanguageAPI.Add("ITEM_???_PICKUP", "");
            LanguageAPI.Add("ITEM_???_DESCRIPTION", "");
            LanguageAPI.Add("ITEM_???_LORE", "");
        }
        protected virtual void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {

            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EngiWalkerTurretBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Root",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("EquipmentDroneBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("ScavBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Base",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
        }
        protected virtual void Hooks()
        {

        }

        protected virtual void SubmitEquipAsAddressablePair(ref EquipmentDef equipDef)
        {

        }
    }
    public class EffectFactory
    {
        protected GameObject prefab;
        public void Init(ref EffectDef effectDef)
        {
            if (effectDef != null)
            {
                Debug.LogWarningFormat("Content {0} has already been loaded.", effectDef);
                return;
            }
            LoadAssets(ref effectDef);
            if (effectDef.prefab != null)
            {
                effectDef.prefabVfxAttributes = effectDef.prefab.GetComponent<VFXAttributes>();
                effectDef.prefabEffectComponent = effectDef.prefab.GetComponent<EffectComponent>();
            }
            HandleMaterials();
            R2API.ContentAddition.AddEffect(this.prefab);
            Debug.LogFormat("Loaded effect {0} and submitted to content pack.", prefab.name);
        }
        protected virtual void LoadAssets(ref EffectDef effectDef)
        {

        }
        protected virtual void HandleMaterials()
        {

        }
    }
    public class BuffFactory
    {

        public void Init(ref BuffDef buffDef)
        {
            LoadAssets(ref buffDef);
            HandleMaterials();
            Hooks();
            ContentAddition.AddBuffDef(buffDef);
            Debug.LogFormat("Loaded buff {0} and submitted to content pack.", buffDef.name);
        }
        protected virtual void LoadAssets(ref BuffDef buffDef)
        {

        }
        protected virtual bool CheckIfEnabled()
        {
            return true;
        }
        protected virtual void HandleMaterials()
        {

        }
        protected virtual void Hooks()
        {

        }
    }
    public class EliteFactory
    {
        protected Texture2D colorRamp;
        public void Init(ref EliteDef eliteDef)
        {
            if (eliteDef != null)
            {
                Debug.LogWarningFormat("Content {0} has already been loaded.", eliteDef.name);
                return;
            }
            if (!CheckIfEnabled())
            {
                Debug.LogFormat("Content {0} has been disabled.", this.GetType().Name);
                return;
            }
            LoadAssets(ref eliteDef);
            HandleMaterials();
            RegisterLanguageTokens();
            Hooks();
            CustomElite ce = new CustomElite(eliteDef, GetEliteTiers(), this.colorRamp);
            EliteAPI.Add(ce);
            Debug.LogFormat("Loaded elite type {0} and submitted to content pack.", eliteDef.name);
        }
        protected virtual bool CheckIfEnabled()
        {
            return true;
        }

        protected virtual IEnumerable<CombatDirector.EliteTierDef> GetEliteTiers()
        {
            return EliteAPI.VanillaEliteTiers;
        }
        protected virtual void LoadAssets(ref EliteDef eliteDef)
        {

        }
        protected virtual void HandleMaterials()
        {

        }
        protected virtual void RegisterLanguageTokens()
        {

        }
        protected virtual void Hooks()
        {

        }
    }
    public class CharacterFactory
    {
        protected GameObject masterPrefab;
        public void Init(ref GameObject body)
        {
            if (body != null)
            {
                Debug.LogWarningFormat("Content {0}/{1} has already been loaded.", body.name);
                return;
            }
            if (!CheckIfEnabled())
            {
                Debug.LogFormat("Content {0} has been disabled.", this.GetType().Name);
                return;
            }
            LoadAssets(ref body);
            LoadMaster();
            HandleMaterials();
            RegisterLanguageTokens();
            Hooks();
            Content.contentPack.bodyPrefabs.AddItem<GameObject>(body);
            if (masterPrefab != null)
            {
                Content.contentPack.masterPrefabs.AddItem<GameObject>(masterPrefab);
                Debug.LogFormat("Loaded characterbody {0} and charactermaster {1} and submitted to content pack.", body.name, masterPrefab.name);
                return;
            }
            Debug.LogFormat("Loaded characterbody {0} and submitted to content pack.", body.name);
        }
        protected virtual bool CheckIfEnabled()
        {
            return true;
        }
        protected virtual void LoadMaster()
        {

        }
        protected virtual void LoadAssets(ref GameObject body)
        {

        }
        protected virtual void HandleMaterials()
        {

        }
        protected virtual void RegisterLanguageTokens()
        {

        }
        protected virtual void Hooks()
        {

        }
    }
    public class ItemTierFactory
    {
        private static GameObject genericPickup;
        protected GameObject systemPrefab;
        public void Init(ref ItemTierDef itemTierDef)
        {
            if (itemTierDef != null)
            {
                Debug.LogWarningFormat("Content {0} has already been loaded.", itemTierDef.name);
                return;
            }
            if (!CheckIfEnabled())
            {
                Debug.LogFormat("Content {0} has been disabled.", this.GetType().Name);
                return;
            }
            LoadAssets(ref itemTierDef);
            HandleMaterials();
            Hooks();
            //itemTierDef.tier = Content.CreateItemTier();
            On.RoR2.PickupDisplay.RebuildModel += PickupDisplay_RebuildModel;
            R2API.ContentAddition.AddItemTierDef(itemTierDef);
            Debug.LogFormat("Loaded ItemTierDef {0} and submitted to content pack.", itemTierDef.name);
        }

        private void PickupDisplay_RebuildModel(On.RoR2.PickupDisplay.orig_RebuildModel orig, PickupDisplay self, GameObject modelObjectOverride)
        {
            if (systemPrefab != null)
            {
                GenericPickupController gpc = self.gameObject.GetComponentInParent<GenericPickupController>();
                if(gpc != null)
                {
                    GameObject systemInstance = GameObject.Instantiate(systemPrefab);
                    systemInstance.transform.parent = self.transform.parent;
                    systemInstance.name = systemInstance.name.Replace("(Clone)", "");
                    systemInstance.transform.localPosition = Vector3.zero;
                    systemInstance.SetActive(false);
                }
            }
            orig.Invoke(self, modelObjectOverride);
        }


        protected virtual bool CheckIfEnabled()
        {
            return true;
        }
        protected virtual void LoadAssets(ref ItemTierDef itemTierDef)
        {

        }


        protected virtual void HandleMaterials()
        {

        }
        protected virtual void Hooks()
        {

        }
    }
    public class UnlockableFactory
    {
        public void Init(ref UnlockableDef unlockableDef)
        {
            if (unlockableDef != null)
            {
                Debug.LogWarningFormat("Content {0} has already been loaded.", unlockableDef);
                return;
            }
            if (!CheckIfEnabled())
            {
                Debug.LogFormat("Content {0} has been disabled.", this.GetType().Name);
                return;
            }
            LoadAssets(ref unlockableDef);
            Hooks();
            R2API.ContentAddition.AddUnlockableDef(unlockableDef);
            Debug.LogFormat("Loaded UnlockableDef {0} and submitted to content pack.", unlockableDef);
        }

        protected virtual bool CheckIfEnabled()
        {
            return true;
        }

        protected virtual void LoadAssets(ref UnlockableDef unlockableDef)
        {

        }

        protected virtual void Hooks()
        {

        }
    }

    public class InteractableFactory
    {
        protected List<string> sceneAddresses = new List<string>();
        public void Init(ref InteractableSpawnCard isc, ref GameObject prefab)
        {
            if (isc != null)
            {
                Debug.LogWarningFormat("Content {0} has already been loaded.", isc);
                return;
            }
            if (!CheckIfEnabled())
            {
                Debug.LogFormat("Content {0} has been disabled.", this.GetType().Name);
                return;
            }
            LoadAssets(ref isc, ref prefab);
            if(prefab == null)
            {
                Debug.LogErrorFormat("Content {0} is missing a prefab.", isc);
                return;
            }
            Hooks();
            HandleMaterials();
            sceneAddresses = AddToSceneInfos();
            R2API.ContentAddition.AddNetworkedObject(prefab);
            Debug.LogFormat("Loaded Interactible {0} (and prefab {1}) and submitted to content pack.", isc, prefab);
        }
        protected virtual void HandleMaterials()
        {

        }
        protected virtual bool CheckIfEnabled()
        {
            return true;
        }

        protected virtual List<string> AddToSceneInfos()
        {
            return new List<string>();
        }

        protected virtual void LoadAssets(ref InteractableSpawnCard isc, ref GameObject prefab)
        {

        }

        protected virtual void Hooks()
        {

        }
    }

    public class ArtifactFactory
    {
        protected ArtifactCode artifactCode;
        public void Init(ref ArtifactDef artifactDef)
        {
            LoadAssets(ref artifactDef);
            HandleMaterials();
            Hooks();
            if(artifactCode != null)
            {
                Content.SubmitArtifactCode(new PendingArtifactCode()
                {
                    artifactDef = artifactDef,
                    codeAsset = artifactCode
                });
            }
            ContentAddition.AddArtifactDef(artifactDef);
        }

        protected virtual void LoadAssets(ref ArtifactDef artifactDef)
        {

        }

        protected virtual void HandleMaterials()
        {

        }

        protected virtual void Hooks()
        {

        }

    }

    public class ChampionFactory
    {
        public void Init(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            CreateChampion(ref gameObject, ref spawnCard);
            R2API.ContentAddition.AddMaster(gameObject);
            Debug.LogFormat("Loaded Champion {0} and submitted to content pack.", gameObject);
        }

        protected virtual void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {

        }
    }
}
