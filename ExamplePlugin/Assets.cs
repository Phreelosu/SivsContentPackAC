using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;

namespace SivsContentPack
{

    //Static class for ease of access
    public static class Assets
    {
        public static class AssetBundles
        {
            public static AssetBundle Main;
            public static AssetBundle Items;
            public static AssetBundle Elites;
            public static AssetBundle Artifacts;
            public static AssetBundle Objects;
            public static AssetBundle Champions;

        }
        //The mod's AssetBundle
        
        // Not necesary, but useful if you want to store the bundle on its own folder.
        public const string assetBundleFolder = "Assets";

        //The direct path to your AssetBundle
        public static string AssetBundlePath(string bundleName)
        {
            return Path.Combine(Path.GetDirectoryName(SivsContentPack.PInfo.Location), assetBundleFolder, bundleName);
        }

        public static void Init()
        {
            //Loads the assetBundle from the Path, and stores it in the static field.
            AssetBundles.Main = AssetBundle.LoadFromFile(AssetBundlePath("sivscontentpack_main"));
            AssetBundles.Items = AssetBundle.LoadFromFile(AssetBundlePath("sivscontentpack_items"));
            AssetBundles.Elites = AssetBundle.LoadFromFile(AssetBundlePath("sivscontentpack_elites"));
            AssetBundles.Artifacts = AssetBundle.LoadFromFile(AssetBundlePath("sivscontentpack_artifacts"));
            AssetBundles.Objects = AssetBundle.LoadFromFile(AssetBundlePath("sivscontentpack_objects"));
            AssetBundles.Champions = AssetBundle.LoadFromFile(AssetBundlePath("sivscontentpack_champions"));
        }
    }
}
