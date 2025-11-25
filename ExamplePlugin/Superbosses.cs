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
using UnityEngine.Networking;
using UnityEngine.Events;
using RoR2.CharacterAI;
using SivsContentPack.Config;

namespace SivsContentPack
{
    public enum ChampionType
    {
        Generic,
        Void,
        Imp,
        Lunar,
        Heretic,
        Aurelionite,
        Count
    }
    internal class ChampionAura : ItemFactory
    {
        protected override void LoadAssets(ref ItemDef itemDef)
        {
            itemDef = Assets.AssetBundles.Main.LoadAsset<ItemDef>("ChampionAura");
            displayPrefab = Assets.AssetBundles.Main.LoadAsset<GameObject>("DisplayChampionAura");
        }
        protected override void HandleMaterials()
        {
            Material m = Assets.AssetBundles.Main.LoadAsset<Material>("matChampionAura");
            Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Cloud Remap");
        }
        protected override void RegisterItemDisplayRules(ref ItemDisplayRuleDict itemDisplayRules)
        {
            itemDisplayRules.Add("CommandoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 0.64326F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("HuntressBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 1.03353F),
localAngles = new Vector3(270F, -0.00009F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("Bandit2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 0.89947F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("ToolbotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, -0.00001F, -4.67168F),
localAngles = new Vector3(90F, 0F, 0F),
localScale = new Vector3(7F, 7F, 7F)
                }
            ]);
            itemDisplayRules.Add("MageBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 1F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("TreebotBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 0.76489F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(2F, 2F, 2F)
                }
            ]);
            itemDisplayRules.Add("LoaderBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 0.97821F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("MercBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 1.0398F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("CaptainBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, -0.0069F, 0.83481F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("CrocoBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0.19791F, -6.64459F),
localAngles = new Vector3(273.1226F, 16.5934F, 162.1952F),
localScale = new Vector3(8F, 8F, 6F)
                }
            ]);
            itemDisplayRules.Add("EngiBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 0.85091F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("RailgunnerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 1.12967F),
localAngles = new Vector3(270F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("VoidSurvivorBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, -0.2074F, -0.89964F),
localAngles = new Vector3(72.32449F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("SeekerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("FalseSonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(0F, 0F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1.3F, 1.3F, 1.3F)
                }
            ]);

            itemDisplayRules.Add("ChefBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0.3696F, -0.00019F, 0.00288F),
localAngles = new Vector3(0F, 0F, 90F),
localScale = new Vector3(1F, 1F, 1F)
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
            itemDisplayRules.Add("BeetleBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Hip",
localPos = new Vector3(-0.30362F, 0.31496F, -0.7676F),
localAngles = new Vector3(289.4525F, 22.949F, 180F),
localScale = new Vector3(1.52154F, 1.52154F, 1.52154F)
                }
            ]);
            itemDisplayRules.Add("VultureBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(-0.00001F, 1.24138F, -0.57015F),
localAngles = new Vector3(316.6147F, 180F, 180F),
localScale = new Vector3(3.70156F, 3.70156F, 3.70156F)
                }
            ]);
            itemDisplayRules.Add("BeetleGuardBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "SlamZone",
localPos = new Vector3(0F, 0F, -6.33823F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(4.41793F, 4.41793F, 4.41793F)
                }
            ]);
            itemDisplayRules.Add("BisonBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(0F, -0.77203F, 0.47909F),
localAngles = new Vector3(0F, 180F, 0F),
localScale = new Vector3(2F, 2F, 2F)
                }
            ]);
            itemDisplayRules.Add("VerminBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(0F, 0.59514F, -0.45013F),
localAngles = new Vector3(-0.00001F, 0.00001F, 0.00001F),
localScale = new Vector3(2.09544F, 2.09544F, 2.09544F)
                }
            ]);
            itemDisplayRules.Add("FlyingVerminBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Body",
localPos = new Vector3(0F, -0.64736F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1.5F, 1.5F, 1.5F)
                }
            ]);
            itemDisplayRules.Add("BellBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, -2.38367F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1.86218F, 1.86218F, 1.86218F)
                }
            ]);
            itemDisplayRules.Add("ChildBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(0F, 0.3635F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.52851F, 0.52851F, 0.52851F)
                }
            ]);
            itemDisplayRules.Add("ClayGrenadierBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Torso",
localPos = new Vector3(0F, -0.55383F, 0.12162F),
localAngles = new Vector3(335.0654F, 0F, 0F),
localScale = new Vector3(0.38145F, 0.38145F, 0.38145F)
                }
            ]);
            itemDisplayRules.Add("ClayBruiserBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(-0.00001F, 0.21557F, -0.31107F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1.15205F, 1.15205F, 1.15205F)
                }
            ]);
            itemDisplayRules.Add("LemurianBruiserBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "SpawnEffectOrigin",
localPos = new Vector3(0.00433F, -16.33263F, 2.20559F),
localAngles = new Vector3(270F, 180.1124F, 0F),
localScale = new Vector3(6.78351F, 6.78351F, 6.78351F)
                }
            ]);
            itemDisplayRules.Add("LemurianBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Hip",
localPos = new Vector3(-0.02694F, 6.74235F, 1.81835F),
localAngles = new Vector3(18.77029F, 0F, 180F),
localScale = new Vector3(5.10302F, 5.10302F, 5.10302F)
                }
            ]);

            itemDisplayRules.Add("GupBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(0F, 0.04743F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.9497F, 0.9497F, 0.9497F)
                }
            ]);
            itemDisplayRules.Add("GreaterWispBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0F, -0.05483F),
localAngles = new Vector3(90F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("WispBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0F, 0F, -0.65409F),
localAngles = new Vector3(270F, 180F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("HalcyoniteBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(0F, 0.99637F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(2.2029F, 2.2029F, 2.2029F)
                }
            ]);
            itemDisplayRules.Add("HermitCrabBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.76232F, 0.76232F, 0.76232F)
                }
            ]);
            itemDisplayRules.Add("ImpBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0.3817F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.72106F, 0.72106F, 0.72106F)
                }
            ]);
            itemDisplayRules.Add("JellyfishBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Hull2",
localPos = new Vector3(-0.00037F, -0.87956F, -0.00066F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("AcidLarvaBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(0F, 0.86896F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(3.2634F, 3.2634F, 3.2634F)
                }
            ]);
            itemDisplayRules.Add("LunarExploderBody", [
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
            itemDisplayRules.Add("LunarWispBody", [
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
            itemDisplayRules.Add("LunarGolemBody", [
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
            itemDisplayRules.Add("MiniMushroomBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, 0F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("ParentBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Pelvis",
localPos = new Vector3(-0.00003F, -200.4245F, 0.00001F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(216.3171F, 216.3171F, 216.3171F)
                }
            ]);
            itemDisplayRules.Add("ScorchlingBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "BaseDirt",
localPos = new Vector3(0.20791F, 0.23346F, -0.0514F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1.74186F, 1.74186F, 1.74186F)
                }
            ]);
            itemDisplayRules.Add("RoboBallMiniBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(0F, -0.80667F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("GolemBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "ClapZone",
localPos = new Vector3(0F, -2.32651F, -2.86967F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1.6818F, 1.6818F, 1.6818F)
                }
            ]);
            itemDisplayRules.Add("VoidBarnacleBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0.65285F, 0F, 0F),
localAngles = new Vector3(0F, 0F, 90F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("NullifierBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Center",
localPos = new Vector3(0F, -3.24324F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(2.80257F, 2.80257F, 2.80257F)
                }
            ]);
            itemDisplayRules.Add("VoidJailerBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Center",
localPos = new Vector3(0F, -4.28009F, -0.79694F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(3.11351F, 3.11351F, 3.11351F)
                }
            ]);
            itemDisplayRules.Add("BeetleQueen2Body", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "BurrowCenter",
localPos = new Vector3(0F, 1.9442F, 0F),
localAngles = new Vector3(90F, 0F, 0F),
localScale = new Vector3(4.88745F, 4.88745F, 4.88745F)
                }
            ]);
            itemDisplayRules.Add("ClayBossBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "SpawnCenter",
localPos = new Vector3(0F, 2.28958F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1.82034F, 1.82034F, 1.82034F)
                }
            ]);
            itemDisplayRules.Add("GrandParentBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "SpawnMuzzle",
localPos = new Vector3(0F, 1.03985F, 1.79578F),
localAngles = new Vector3(90F, 0F, 0F),
localScale = new Vector3(5.92088F, 5.92088F, 5.92088F)
                }
            ]);
            itemDisplayRules.Add("GravekeeperBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Root",
localPos = new Vector3(0F, 0.21161F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(4.98661F, 4.98661F, 4.98661F)
                }
            ]);
            itemDisplayRules.Add("ImpBossBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "DustCenter",
localPos = new Vector3(0F, 2.51691F, 0F),
localAngles = new Vector3(0F, 180F, 0F),
localScale = new Vector3(2.10789F, 2.10789F, 2.10789F)
                }
            ]);
            itemDisplayRules.Add("RoboBallBossBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Center",
localPos = new Vector3(0F, -0.77411F, 0F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(0.91439F, 0.91439F, 0.91439F)
                }
            ]);
            itemDisplayRules.Add("TitanBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "BurrowCenter",
localPos = new Vector3(0F, 0.01423F, -1.58721F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(4.92785F, 4.92785F, 4.92785F)
                }
            ]);
            itemDisplayRules.Add("VagrantBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,childName = "Head",
localPos = new Vector3(0.00237F, -1.53016F, -0.00468F),
localAngles = new Vector3(0F, 0F, 0F),
localScale = new Vector3(1F, 1F, 1F)
                }
            ]);
            itemDisplayRules.Add("VoidMegaCrabBody", [
                new ItemDisplayRule()
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = displayPrefab,
                    childName = "Head",
                    localAngles = new UnityEngine.Vector3(0f, 0f, 0f),
                    localPos = new UnityEngine.Vector3(0f, 0f, 0f),
                    localScale = new UnityEngine.Vector3(1f, 1f, 1f),
                }
            ]);
            itemDisplayRules.Add("MegaConstructBody", [
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
                    followerPrefab = displayPrefab,childName = "Base",
localPos = new Vector3(0F, -0.00002F, -8.14432F),
localAngles = new Vector3(90F, 0F, 0F),
localScale = new Vector3(9.3294F, 9.3294F, 9.3294F)
                }
            ]);
        }
    }
    internal class KillerBeetle : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject beetleMaster = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Beetle/BeetleMaster.prefab").WaitForCompletion();
            if(beetleMaster != null)
            {
                gameObject = PrefabAPI.InstantiateClone(beetleMaster, "KillerBeetleMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_KILLERBEETLE_NAME";
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "NearbyDamageBonus",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Syringe",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Hoof",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BearVoid",
                        amount = 20
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 500
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostDamage",
                        amount = 100
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if(gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 1000;
                spawnCard.hullSize = HullClassification.Human;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Ground;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class Heretic : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject master = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Heretic/HereticMonsterMaster.prefab").WaitForCompletion();
            if (master != null)
            {
                gameObject = PrefabAPI.InstantiateClone(master, "ChampionHereticMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_HERETIC_NAME";
                cc.championType = ChampionType.Heretic;
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Knurl",
                        amount = 4
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "LunarPrimaryReplacement",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "LunarSecondaryReplacement",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "LunarUtilityReplacement",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "LunarSpecialReplacement",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 1000;
                spawnCard.hullSize = HullClassification.Human;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Ground;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class Aurelionite : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject master = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Titan/TitanGoldMaster.prefab").WaitForCompletion();
            if (master != null)
            {
                gameObject = PrefabAPI.InstantiateClone(master, "AurelioniteMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_AURELIONITE_NAME";
                cc.championType = ChampionType.Aurelionite;
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Knurl",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "GoldArmorBoost",
                        amount = 13
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Geode",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "TitanGoldDuringTP",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ImmuneToDebuff",
                        amount = 5
                    },

                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Shieldbreaker",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "EquipmentMagazineVoid",
                        amount = 2
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ProjectileBoost",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "GoldIdol",
                        amount = 7
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ProcBoost",
                        amount = 100
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Hoof",
                        amount = 5
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "LowerHealthHigherDamage",
                        amount = 5
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "SecondarySkillMagazine",
                        amount = 2
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "AdaptiveArmor",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 1000;
                spawnCard.hullSize = HullClassification.Human;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Ground;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class DeathUrchin : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject beetleMaster = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/ElitePoison/UrchinTurretMaster.prefab").WaitForCompletion();
            if (beetleMaster != null)
            {
                gameObject = PrefabAPI.InstantiateClone(beetleMaster, "DeathUrchinMaster");
                AwakeEvent ae = gameObject.GetComponent<AwakeEvent>();
                GameObject.Destroy(ae);
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_DEATHURCHIN_NAME";
                cc.equipment = "ElitePoisonEquipment";
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Mushroom",
                        amount = 15
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Syringe",
                        amount = 5
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "RepeatHeal",
                        amount = 8
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "NovaOnHeal",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "SiphonOnLowHealth",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ParentEgg",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BarrierOnOverHeal",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 30
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 1000;
                spawnCard.hullSize = HullClassification.Human;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Air;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class SniperHermit : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject beetleMaster = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/HermitCrab/HermitCrabMaster.prefab").WaitForCompletion();
            if (beetleMaster != null)
            {
                gameObject = PrefabAPI.InstantiateClone(beetleMaster, "SniperHermitMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_SNIPERHERMIT_NAME";
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Mushroom",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Syringe",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "RepeatHeal",
                        amount = 5
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Behemoth",
                        amount = 5
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "SprintOutOfCombat",
                        amount = 5
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "OutOfCombatArmor",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "CritGlasses",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 100
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 1000;
                spawnCard.hullSize = HullClassification.Human;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Air;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class ArmoredHalcyonite : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject master = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC2/Halcyonite/HalcyoniteMaster.prefab").WaitForCompletion();
            if (master != null)
            {
                gameObject = PrefabAPI.InstantiateClone(master, "ArmoredHalcyoniteMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_ARMOREDHALCYONITE_NAME";
                cc.equipment = "EliteAurelioniteEquipment";
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "GoldArmorBoost",
                        amount = 13
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "GoldOnHurt",
                        amount = 3
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Hoof",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "GoldIdol",
                        amount = 7
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Knurl",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "EquipmentMagazineVoid",
                        amount = 2
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 1000;
                spawnCard.hullSize = HullClassification.Golem;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Ground;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class Kjaro : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject master = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/LemurianBruiser/LemurianBruiserMaster.prefab").WaitForCompletion();
            if (master != null)
            {
                gameObject = PrefabAPI.InstantiateClone(master, "SuperKjaroMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_ELEMENTALRING_NAME";
                cc.equipment = "EliteFireEquipment";
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "FireRing",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "StrengthenBurn",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "DoubleProjectiles",
                        amount = 20
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ProjectileBoost",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 20
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 750;
                spawnCard.hullSize = HullClassification.Golem;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Ground;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class Runald : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject master = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/LemurianBruiser/LemurianBruiserMaster.prefab").WaitForCompletion();
            if (master != null)
            {
                gameObject = PrefabAPI.InstantiateClone(master, "SuperRunaldMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_ELEMENTALRING_NAME";
                cc.equipment = "EliteIceEquipment";
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "IceRing",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "SlowOnHit",
                        amount = 5
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "DoubleProjectiles",
                        amount = 20
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ProjectileBoost",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 20
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 750;
                spawnCard.hullSize = HullClassification.Golem;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Ground;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class ShadowRing : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject master = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/LemurianBruiser/LemurianBruiserMaster.prefab").WaitForCompletion();
            if (master != null)
            {
                gameObject = PrefabAPI.InstantiateClone(master, "ShadowRingMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_ELEMENTALRING_NAME";
                if (Configuration.Elites.Obscuring.enabled.Value)
                {
                    cc.equipment = "eqEliteShadow";
                }
                else
                {
                    cc.equipment = "EliteLightningEquipment";
                }
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ElementalRingVoid",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "SlowOnHitVoid",
                        amount = 5
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ProcBoost",
                        amount = 100
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "DoubleProjectiles",
                        amount = 20
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ProjectileBoost",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 20
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 1000;
                spawnCard.hullSize = HullClassification.Golem;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Ground;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class MiniWorshipUnit : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject master = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/RoboBallBuddy/RoboBallGreenBuddyMaster.prefab").WaitForCompletion();
            if (master != null)
            {
                gameObject = PrefabAPI.InstantiateClone(master, "MiniWorshipUnitMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_MINIWORSHIPUNIT_NAME";
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "SlowOnHit",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ProcBoost",
                        amount = 25
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "PersonalShield",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "MoreMissile",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Missile",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostDamage",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 5
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 1000;
                spawnCard.hullSize = HullClassification.Golem;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Air;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class RedBaron : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject master = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Imp/ImpMaster.prefab").WaitForCompletion();
            if (master != null)
            {
                gameObject = PrefabAPI.InstantiateClone(master, "RedBaronMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.championType = ChampionType.Imp;
                cc.characterNameToken = "CHAMPION_REDBARON_NAME";
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ImpsEye",
                        amount = 2
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "UtilitySkillMagazine",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "AlienHead",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "CritGlasses",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BleedOnHitAndExplode",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "NearbyDamageBonus",
                        amount = 5
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 75
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 1000;
                spawnCard.hullSize = HullClassification.Golem;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Ground;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class Smiter : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject master = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/GreaterWisp/GreaterWispMaster.prefab").WaitForCompletion();
            if (master != null)
            {
                gameObject = PrefabAPI.InstantiateClone(master, "SmiterMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_SMITER_NAME";
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "SmiteOnHit",
                        amount = 3
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ProjectileBoost",
                        amount = 50
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ProcBoost",
                        amount = 100
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 20
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 1000;
                spawnCard.hullSize = HullClassification.Golem;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Air;
                spawnCard.sendOverNetwork = true;
            }
        }
    }
    internal class JellyfishTank : ChampionFactory
    {
        protected override void CreateChampion(ref GameObject gameObject, ref CharacterSpawnCard spawnCard)
        {
            GameObject master = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Jellyfish/JellyfishMaster.prefab").WaitForCompletion();
            if (master != null)
            {
                gameObject = PrefabAPI.InstantiateClone(master, "JellyfishTankMaster");
                ChampionComponent cc = gameObject.AddComponent<ChampionComponent>();
                cc.characterNameToken = "CHAMPION_JELLYFISHTANK_NAME";
                cc.pickupList = new List<ChampionComponent.GrantedItem>
                {
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ShockNearby",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "HalfSpeedDoubleHealth",
                        amount = 2
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "NearbyDamageBonus",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Tentacle",
                        amount = 3
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "Knurl",
                        amount = 10
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "NovaOnLowHealth",
                        amount = 1
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "BoostHp",
                        amount = 25
                    },
                    new ChampionComponent.GrantedItem()
                    {
                        pickupName = "ChampionAura",
                        amount = 1
                    }
                };
                AISkillDriver[] skillDrivers = gameObject.GetComponents<AISkillDriver>();
                foreach (var item in skillDrivers)
                {
                    if(item.skillSlot == SkillSlot.Secondary)
                    {
                        GameObject.Destroy(item);
                    }
                }
            }
            if (gameObject != null)
            {
                spawnCard = ScriptableObject.CreateInstance<CharacterSpawnCard>();
                spawnCard.prefab = gameObject;
                spawnCard.noElites = true;
                spawnCard.directorCreditCost = 1000;
                spawnCard.hullSize = HullClassification.Human;
                spawnCard.nodeGraphType = RoR2.Navigation.MapNodeGroup.GraphType.Air;
                spawnCard.sendOverNetwork = true;
            }
        }
    }

    public class ChampionComponent : MonoBehaviour
    {
        [Serializable]
        public struct GrantedItem
        {
            public string pickupName;
            public int amount;
        }
        public string equipment;
        public string characterNameToken;
        public string characterSubtitleToken;

        public List<GrantedItem> pickupList;

        public ChampionType championType = ChampionType.Generic;

        private CharacterMaster master;

        private void Awake()
        {
            master = GetComponent<CharacterMaster>();
        }
    }

}
