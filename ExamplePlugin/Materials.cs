using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SivsContentPack
{
    public static class Materials
    {
        private static Dictionary<Material, string> materialsToFix = new Dictionary<Material, string>();

        public static void SubmitMaterialFix(Material material, string shader)
        {
            if(material != null & shader != null)
            {
                if (materialsToFix.ContainsKey(material))
                {
                    Debug.LogFormat("Material Fix submission denied. Material {0} has already been submitted.", material.name);
                    return;
                }
                materialsToFix.Add(material, shader);
            }
        }

        public static void FixMaterials()
        {
            Debug.LogFormat("Siv's Content Pack: Fixing materials.");
            foreach (var item in materialsToFix)
            {
                Material m = item.Key;
                string s = item.Value;
                if (m != null && s != null)
                {
                    Debug.LogFormat("- Attempting to locate shader {0}...", s);
                    Shader a = Shader.Find(s);
                    if (a != null)
                    {
                        m.shader = a;
                        Debug.LogFormat("- Assigned material {0} the shader {1}.", m.name, m.shader.name);
                    }

                }
            }
            Debug.LogFormat("Sivs' Content Pack: Finished fixing materials.");

        }
    }
}
