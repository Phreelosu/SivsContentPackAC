using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SivsContentPack.Items
{
    internal static class ItemDisplays
    {
        internal static GameObject FindCharacterModelFromVanillaBodyName(string bodyName)
        {
            GameObject result = null;
            GameObject gameObject = Resources.Load<GameObject>("Prefabs/CharacterBodies/" + bodyName);
            bool flag = gameObject != null;
            if (flag)
            {
                ModelLocator component = gameObject.GetComponent<ModelLocator>();
                bool flag2 = component != null;
                if (flag2)
                {
                    result = component.modelTransform.gameObject;
                }
            }
            return result;
        }
        internal static ItemDisplayRuleSet GetIDRSFromModelObject(GameObject model)
        {
            ItemDisplayRuleSet result = null;
            bool flag = model != null;
            if (flag)
            {
                CharacterModel component = model.GetComponent<CharacterModel>();
                bool flag2 = component != null;
                if (flag2)
                {
                    result = component.itemDisplayRuleSet;
                }
            }
            return result;
        }
        private static void RegisterItemDisplayRules(GameObject displayPrefab, ItemDef itemDef)
        {
            Dictionary<string, ItemDisplayRuleSet> vitalBodiesIDRS = ItemDisplays.GetVitalBodiesIDRS();
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["CommandoBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["HuntressBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["Bandit2Body"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["ToolbotBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["MageBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["TreebotBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["LoaderBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["MercBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["CaptainBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["CrocoBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["EngiBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["EngiTurretBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["EquipmentDroneBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
            ItemDisplays.AddItemDisplayToIDRS(vitalBodiesIDRS["ScavBody"], itemDef, new DisplayRuleGroup
            {
                rules = new ItemDisplayRule[]
                {
                    new ItemDisplayRule
                    {
                        childName = "Base",
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = displayPrefab,
                        localAngles = new Vector3(0f, 0f, 0f),
                        localPos = new Vector3(0f, 0f, 0f),
                        localScale = Vector3.one * 1f
                    }
                }
            });
        }

        internal static void AddItemDisplayToIDRS(ItemDisplayRuleSet idrs, ItemDef itemDef, DisplayRuleGroup displayRules)
        {
            idrs.SetDisplayRuleGroup(itemDef, displayRules);
            idrs.GenerateRuntimeValues();
        }

        internal static void AddEquipDisplayToIDRS(ItemDisplayRuleSet idrs, EquipmentDef equipmentDef, DisplayRuleGroup displayRules)
        {
            idrs.SetDisplayRuleGroup(equipmentDef, displayRules);
            idrs.GenerateRuntimeValues();
        }

        internal static Dictionary<string, ItemDisplayRuleSet> GetVitalBodiesIDRS()
        {
            Dictionary<string, ItemDisplayRuleSet> dictionary = new Dictionary<string, ItemDisplayRuleSet>();
            foreach (string text in ItemDisplays.vitalItemDisplayBodies)
            {
                dictionary.Add(text, ItemDisplays.GetIDRSFromModelObject(ItemDisplays.FindCharacterModelFromVanillaBodyName(text)));
            }
            return dictionary;
        }

        internal static List<string> vitalItemDisplayBodies = new List<string>
        {
            "CommandoBody",
            "HuntressBody",
            "Bandit2Body",
            "ToolbotBody",
            "MageBody",
            "TreebotBody",
            "LoaderBody",
            "MercBody",
            "CaptainBody",
            "CrocoBody",
            "EngiBody",
            "RailgunnerBody",
            "VoidSurvivorBody",
            "SeekerBody",
            "FalseSonBody",
            "EngiTurretBody",
            "EngiWalkerTurretBody",
            "EquipmentDroneBody",
            "ScavBody"
        };
    }
}
