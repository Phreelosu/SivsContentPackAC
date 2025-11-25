//using IL.RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnityEngine;
using RoR2;
using SivsContentPack.Config;
using System.Reflection;
using UnityEngine.SocialPlatforms;

namespace SivsContentPack
{
    public static class Util
    {
        public static float GetStackingBehavior(float baseValue, float stackValue, int stack)
        {
            return baseValue + (stackValue * (stack - 1));
        }

        public static void ManageShaders(ref Material[] materials)
        {
            foreach (Material mat in materials)
            {
                Shader s = Shader.Find(mat.shader.name);
                if (s != null)
                {
                    mat.shader = s;
                }
                Debug.LogFormat("Assigning proper shader {0} for material {1}.", mat.shader.name, mat.name);
            }
        }

        public static void ApplyVisualCountdownBuff(ref CharacterBody body, BuffDef buff, int duration)
        {
            for (int x = 1; x < duration + 1; x++)
            {
                body.AddTimedBuff(buff, (float)x);
            }
        }
        public static Type[] GetInheritedClasses(Type MyType, string nameSpace)
        {
            //if you want the abstract classes drop the !TheType.IsAbstract but it is probably to instance so its a good idea to keep it.
            Type[] t = Assembly.GetAssembly(MyType).GetTypes().Where(TheType => TheType.IsClass && TheType.IsAbstract && TheType.IsSubclassOf(MyType)).ToArray<Type>();
            foreach (var item in t)
            {
                Debug.LogFormat("Found type {0} from namespace {1}.", item.Name, item.Namespace);
            }
            return t;
        }

        public static float GetUnarmoredDamage(float damage, float armor, float ignoreLimit = -1, bool onlyIgnorePositiveArmor = false)
        {
            float result = damage;
            float ignoreAmount = armor;
            if(armor != 0)
            {
                if (ignoreLimit > 0)
                {
                    ignoreAmount = Mathf.Clamp(armor, 0, ignoreLimit);

                }
                if (armor > 0)
                {
                    result /= (100 / (100 + ignoreAmount));
                }
                else
                {
                    if (!onlyIgnorePositiveArmor)
                    {
                        ignoreAmount = Mathf.Max(ignoreAmount, -99.9999f);
                        result /= (2 - 100 / (100 - ignoreAmount));
                    }
                }
            }
            return result;
        }
    }
}
