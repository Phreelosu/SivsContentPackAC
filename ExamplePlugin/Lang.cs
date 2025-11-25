using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using System.IO;
using R2API;

namespace SivsContentPack
{
    public static class Languages
    {
        //The name of the folder that contains the language tree
        public const string LanguageFolder = "Languages";
        public static string RootLanguageFolderPath => System.IO.Path.Combine(System.IO.Path.GetDirectoryName(SivsContentPack.PInfo.Location), LanguageFolder);

        public static void Init()
        {
            LanguageAPI.AddPath(System.IO.Path.Combine(RootLanguageFolderPath, "items.language"));
        }

    }
}
