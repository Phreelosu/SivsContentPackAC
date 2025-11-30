using BepInEx;
using BepInEx.Configuration;
using On.RoR2.ContentManagement;
using R2API;
using R2API.ContentManagement;
using RoR2;
using SivsContentPack;
using SivsContentPack.Config;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SivsContentPack
{
    // This is an example plugin that can be put in
    // BepInEx/plugins/ExamplePlugin/ExamplePlugin.dll to test out.
    // It's a small plugin that adds a relatively simple item to the game,
    // and gives you that item whenever you press F2.

    // This attribute specifies that we have a dependency on a given BepInEx Plugin,
    // We need the R2API ItemAPI dependency because we are using for adding our item to the game.
    // You don't need this if you're not using R2API in your plugin,
    // it's just to tell BepInEx to initialize R2API before this plugin so it's safe to use R2API.
    [BepInDependency(ItemAPI.PluginGUID)]

    // This one is because we use a .language file for language tokens
    // More info in https://risk-of-thunder.github.io/R2Wiki/Mod-Creation/Assets/Localization/
    [BepInDependency(LanguageAPI.PluginGUID)]
    [BepInDependency(RecalculateStatsAPI.PluginGUID)]
    [BepInDependency(PrefabAPI.PluginGUID)]

    // This attribute is required, and lists metadata for your plugin.
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    // This is the main declaration of our plugin class.
    // BepInEx searches for all classes inheriting from BaseUnityPlugin to initialize on startup.
    // BaseUnityPlugin itself inherits from MonoBehaviour,
    // so you can use this as a reference for what you can declare and use in your plugin class
    // More information in the Unity Docs: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
    public class SivsContentPack : BaseUnityPlugin
    {
        // The Plugin GUID should be a unique ID for this plugin,
        // which is human readable (as it is used in places like the config).
        // If we see this PluginGUID as it is on thunderstore,
        // we will deprecate this mod.
        // Change the PluginAuthor and the PluginName !
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "Sivelos";
        public const string PluginName = "SivsContentPack";
        public const string PluginVersion = "1.4.0";
        public const string ModPrefix = "@SivsContentPack:";

        public static PluginInfo PInfo { get; private set; }


        // The Awake() method is run at the very start when the game is initialized.
        public void Awake()
        {
            // Init our logging class so that we can properly log for debugging
            Log.Init(Logger);
            PInfo = Info;
            //On.RoR2.Networking.NetworkManagerSystemSteam.OnClientConnect += (s, u, t) => { };
            Configuration.config = new ConfigFile(Paths.ConfigPath + "\\"+PluginAuthor+"."+PluginName+".cfg", true);
            Assets.Init();
            Content.Init();
            RoR2Application.onLoad += new System.Action(Materials.FixMaterials);
            RoR2Application.onLoad += new System.Action(Content.ValidatePendingArtifactCodes);
            RoR2Application.onLoad += new System.Action(Content.ValidateAddressablePickupPairs);
            RoR2Application.onLoad += new System.Action(Content.ValidatePendingSpawnCards);
        }

        [ConCommand(commandName = "sivscontentpack_drop_all_pickups", flags = ConVarFlags.Cheat, helpText = "Meant to easily unlock all pickups in the logbook.")]
        private static void CCDropAllPickups(ConCommandArgs args)
        {
            Debug.LogFormat("Dropping all items...");
            foreach (var item in Content.contentPack.itemDefs)
            {
                PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(item.pickupToken), args.sender.transform.position, args.sender.transform.forward);
            }
            Debug.LogFormat("Dropping all equipment...");
            foreach (var item in Content.contentPack.equipmentDefs)
            {
                PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(item.pickupToken), args.sender.transform.position, args.sender.transform.forward);
            }
        }

    }
}
