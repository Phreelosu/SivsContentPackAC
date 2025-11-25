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

namespace SivsContentPack
{
    
    public static class Content
    {
        public static R2APISerializableContentPack contentPack;
        public static ExpansionDef expansionDef;
        public static void Init()
        {
            contentPack = Assets.AssetBundles.Main.LoadAsset<R2APISerializableContentPack>("cpSivsContentPack");
            R2APIContentManager.AddPreExistingSerializableContentPack(contentPack, true);
            expansionDef = Assets.AssetBundles.Main.LoadAsset<ExpansionDef>("exSivsContentPack");
            R2API.ContentAddition.AddExpansionDef(expansionDef);
            Effects.Init();
            ItemTiers.Init();
            Elites.Init();
            Unlockables.Init();
            Champions.Init();
            Interactables.Init();
            Buffs.Init();
            Artifacts.Init();
            SerializableEntityStates.Init();
            Characters.Init();
            ItemRelationships.Init();
            Items.Init();
        }

        private static int lastProcType = (int)ProcType.Count + 1;
        public static ProcType CreateProcType()
        {
            ProcType result = (ProcType)(lastProcType);
            Debug.LogFormat("Created new ProcType at index {0}.", result);
            lastProcType++;
            return result;
        }

        private static int lastDeployableSlot = (int)DeployableSlot.None + 1;
        public static DeployableSlot CreateDeployableSlot()
        {
            DeployableSlot result = (DeployableSlot)(lastDeployableSlot);
            Debug.LogFormat("Created new DeployableSlot at index {0}.", result);
            lastDeployableSlot++;
            return result;
        }

        private static ItemRelationshipProvider itemRelationshipProvider;

        private static int lastItemTier = (int)ItemTier.AssignedAtRuntime + 1;
        public static ItemTier CreateItemTier()
        {
            ItemTier result = (ItemTier)(lastItemTier);
            Debug.LogFormat("Created new ItemTier at index {0}.", result);
            lastItemTier++;
            return result;
        }

        private static List<AddressablePickupPair> addressablePickupPairs = new List<AddressablePickupPair>();
        public struct AddressablePickupPair
        {

            [TypeRestrictedReference(new Type[]
            {
        typeof(ItemDef),
        typeof(EquipmentDef),
        typeof(MiscPickupDef)
            })]
            public UnityEngine.Object pickupDef;

            public string objectAddress;
        }
        public static void SubmitAddressablePickupPair(AddressablePickupPair pair)
        {
            addressablePickupPairs.Add(pair);
        }
        public static void ValidateAddressablePickupPairs()
        {
            Debug.LogFormat("Validating AddressablePickupPairs... ({0} pair(s) found)", addressablePickupPairs.Count);
            foreach (var pair in addressablePickupPairs)
            {
                GameObject obj = Addressables.LoadAsset<GameObject>(pair.objectAddress).WaitForCompletion();
                if (obj != null)
                {
                    DeathRewards deathRewards = obj.GetComponent<DeathRewards>();
                    if(deathRewards != null)
                    {
                        if(deathRewards.bossDropTable == null)
                        {

                            ExplicitPickupDropTable epdt = ScriptableObject.CreateInstance<ExplicitPickupDropTable>();
                            epdt.canDropBeReplaced = true;
                            epdt.pickupEntries = new ExplicitPickupDropTable.PickupDefEntry[1];
                            epdt.pickupEntries[0] = new ExplicitPickupDropTable.PickupDefEntry()
                            {
                                pickupDef = pair.pickupDef,
                                pickupWeight = 1f,
                            };
                            deathRewards.bossDropTable = epdt;
                            Debug.LogFormat("- Validated pair {0}/{1}.", obj, pair.pickupDef);
                        }
                    }
                }
            }
        }
        public struct PendingArtifactCode
        {
            public ArtifactDef artifactDef;
            public ArtifactCode codeAsset;
        }
        private static List<PendingArtifactCode> pendingArtifactCodes = new List<PendingArtifactCode>();

        public static void SubmitArtifactCode(PendingArtifactCode pendingArtifactCode)
        {
            pendingArtifactCodes.Add(pendingArtifactCode);
        }

        public static void ValidatePendingArtifactCodes()
        {
            foreach (var pair in pendingArtifactCodes)
            {
                ArtifactCodeAPI.AddCode(pair.artifactDef, pair.codeAsset);
            }
        }
        public struct PendingItemPair
        {
            public ItemDef item1;
            public ItemDef item2;
            public ItemRelationshipType relationshipType;
        }


        private static List<PendingItemPair> pendingItemPairs = new List<PendingItemPair>();
        public static void SubmitPendingItemPair(PendingItemPair pair)
        {
            pendingItemPairs.Add(pair);
        }

        public static void ValidatePendingItemPairs()
        {
            Debug.LogFormat("SivsContentPack: Validating pending item pairs.");
            foreach (var pair in pendingItemPairs)
            {
                Debug.LogFormat("- Located pair with relationship {0} ({1}/{2}).", pair.relationshipType, pair.item1, pair.item2);
                if (pair.relationshipType == DLC1Content.ItemRelationshipTypes.ContagiousItem)
                {
                    ItemDef.Pair[] array = Content.ItemRelationships.RelationshipProviders.contagiousItems.relationships;
                    array = array.AddToArray(new ItemDef.Pair()
                    {
                        itemDef1 = pair.item1,
                        itemDef2 = pair.item2,
                    });
                    Content.ItemRelationships.RelationshipProviders.contagiousItems.relationships = array;
                    Debug.LogFormat("- Added item pair to item relationship provider.");
                }
            }
            ItemCatalog.SetItemRelationships(new ItemRelationshipProvider[]
            {
                Content.ItemRelationships.RelationshipProviders.contagiousItems
            });
        }

        public struct PendingSpawnCard
        {
            public SpawnCard card;
            public List<string> sceneInfoAddresses;
        }
        private static List<PendingSpawnCard> pendingSpawnCards = new List<PendingSpawnCard>();
        public static void AddPendingSpawnCard(PendingSpawnCard pendingSpawnCard)
        {
            pendingSpawnCards.Add(pendingSpawnCard);
        }

        public static void ValidatePendingSpawnCards()
        {
            Debug.LogFormat("Validating Spawn Cards... ({0} pairs to validate)", pendingSpawnCards.Count);
            foreach (var spawnCardPair in pendingSpawnCards)
            {
                if(spawnCardPair.sceneInfoAddresses.Count > 0)
                {
                    if (spawnCardPair.card)
                    {
                        Debug.LogFormat("- Validating spawn card {0} ({1} sceneDef(s) to add to).", spawnCardPair.card, spawnCardPair.sceneInfoAddresses.Count);
                        foreach(var address in spawnCardPair.sceneInfoAddresses)
                        {
                            DirectorCardCategorySelection dccs = Addressables.LoadAssetAsync<DirectorCardCategorySelection>(address).WaitForCompletion();
                            if (dccs != null)
                            {
                                dccs.AddCard(0, new DirectorCard()
                                {
                                    spawnCard = spawnCardPair.card,
                                    selectionWeight = 10
                                });
                                Debug.LogFormat("- Added spawn card to {0}.", dccs);
                            }
                        }
                    }
                }
            }
        }
        public static class Characters
        {
            public static void Init()
            {

            }


            public static GameObject DocBody;
            public static GameObject DocMaster;

            public static GameObject MarbleGolemBody;
            public static GameObject MarbleGolemMaster;

            public static GameObject SuperBeetleBody;
            public static GameObject SuperBeetleMaster;

            public static GameObject AnimaBody;
            public static GameObject AnimaMaster;

        }
        public static class Survivors
        {
            public static SurvivorDef Doc;
            public static SurvivorDef Reaper;
            public static SurvivorDef King;
            public static SurvivorDef Imp;
            public static SurvivorDef Devotee;
            public static SurvivorDef Anima;
        }
        public static class SpawnCards
        {

        }
        public static class Champions
        {
            public static DirectorCardCategorySelection dccsChampions;


            public static GameObject halcyoniteArmoredMaster;
            public static CharacterSpawnCard iscHalcyoniteArmoredMaster;

            public static GameObject killerBeetleMaster;
            public static CharacterSpawnCard iscKillerBeetle;

            public static GameObject jellyTankMaster;
            public static CharacterSpawnCard iscJellyTank;

            public static GameObject kjaroMaster;
            public static CharacterSpawnCard iscKjaro;

            public static GameObject runaldMaster;
            public static CharacterSpawnCard iscRunald;

            public static GameObject shadowRingMaster;
            public static CharacterSpawnCard iscShadowRing;

            public static GameObject smiterMaster;
            public static CharacterSpawnCard iscSmiter;

            public static GameObject miniWorshipUnitMaster;
            public static CharacterSpawnCard iscMiniWorshipUnit;

            public static GameObject redBaronMaster;
            public static CharacterSpawnCard iscRedBaron;

            public static GameObject deathUrchinMaster;
            public static CharacterSpawnCard iscDeathUrchin;

            public static GameObject sniperHermitMaster;
            public static CharacterSpawnCard iscSniperHermit;

            public static GameObject hereticMaster;
            public static CharacterSpawnCard iscHeretic;

            public static GameObject aurelioniteMaster;
            public static CharacterSpawnCard iscAurelionite;

            public static string GetChampionSubtitle(ChampionType type)
            {
                switch (type)
                {
                    case ChampionType.Lunar:
                        return "CHAMPION_SUBTITLE_LUNAR";
                    case ChampionType.Imp:
                        return "CHAMPION_SUBTITLE_IMP";
                    case ChampionType.Void:
                        return "CHAMPION_SUBTITLE_VOID";
                    case ChampionType.Heretic:
                        return "CHAMPION_SUBTITLE_HERETIC";
                    case ChampionType.Aurelionite:
                        return "CHAMPION_SUBTITLE_AURELIONITE";
                    case ChampionType.Generic:
                    default:
                        return "CHAMPION_SUBTITLE_GENERIC";
                }
            }
            public static void Init()
            {
                On.RoR2.CharacterMaster.OnBodyStart += CharacterMaster_OnBodyStart;
                On.RoR2.CharacterMaster.Start += CharacterMaster_Start; ;

                new KillerBeetle().Init(ref killerBeetleMaster, ref iscKillerBeetle);
                new ArmoredHalcyonite().Init(ref halcyoniteArmoredMaster, ref iscHalcyoniteArmoredMaster);
                new JellyfishTank().Init(ref jellyTankMaster, ref iscJellyTank);
                new Kjaro().Init(ref kjaroMaster, ref iscKjaro);
                new Runald().Init(ref runaldMaster, ref iscRunald);
                new ShadowRing().Init(ref shadowRingMaster, ref iscShadowRing);
                new Smiter().Init(ref smiterMaster, ref iscSmiter);
                new MiniWorshipUnit().Init(ref miniWorshipUnitMaster, ref iscMiniWorshipUnit);
                new RedBaron().Init(ref redBaronMaster, ref iscRedBaron);
                new DeathUrchin().Init(ref deathUrchinMaster, ref iscDeathUrchin);
                new SniperHermit().Init(ref sniperHermitMaster, ref iscSniperHermit);
                new Heretic().Init(ref hereticMaster, ref iscHeretic);
                new Aurelionite().Init(ref aurelioniteMaster, ref iscAurelionite);

                dccsChampions = ScriptableObject.CreateInstance<DirectorCardCategorySelection>();
                int index = dccsChampions.AddCategory("champions", 10);
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscKillerBeetle,
                    selectionWeight = 1,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscHalcyoniteArmoredMaster,
                    selectionWeight = 5,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscJellyTank,
                    selectionWeight = 5,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscKjaro,
                    selectionWeight = 5,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscRunald,
                    selectionWeight = 5,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscShadowRing,
                    selectionWeight = 5,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscSmiter,
                    selectionWeight = 5,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscMiniWorshipUnit,
                    selectionWeight = 5,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscRedBaron,
                    selectionWeight = 5,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscDeathUrchin,
                    selectionWeight = 5,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscSniperHermit,
                    selectionWeight = 5,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscHeretic,
                    selectionWeight = 1,
                });
                dccsChampions.AddCard(index, new DirectorCard()
                {
                    spawnCard = iscAurelionite,
                    selectionWeight = 1,
                });
            }

            private static void CharacterMaster_Start(On.RoR2.CharacterMaster.orig_Start orig, CharacterMaster self)
            {
                orig.Invoke(self);
                ChampionComponent cc = self.GetComponent<ChampionComponent>();
                if (cc != null)
                {

                    Inventory i = self.GetComponent<Inventory>();
                    if (i != null)
                    {
                        Debug.LogFormat("ChampionComponent: Granting pickups to {0}.", self.gameObject);
                        if (cc.equipment != "")
                        {
                            i.GiveEquipmentString(cc.equipment);
                            Debug.LogFormat("- Granting equipment {0}.", cc.equipment);
                        }
                        if (cc.pickupList != null)
                        {
                            Debug.LogFormat("ChampionComponent: {0} pickup(s) to grant:", cc.pickupList.Count);
                            foreach (var pickup in cc.pickupList)
                            {
                                i.GiveItemString(pickup.pickupName, pickup.amount);
                                Debug.LogFormat("- Granting {1} of item {0}.", pickup.pickupName, pickup.amount);
                            }
                        }
                    }
                }
            }


            private static void CharacterMaster_OnBodyStart(On.RoR2.CharacterMaster.orig_OnBodyStart orig, CharacterMaster self, CharacterBody body)
            {
                orig.Invoke(self, body);
                ChampionComponent cc = self.GetComponent<ChampionComponent>();
                if(cc != null)
                {
                    if(body != null)
                    {
                        body.baseNameToken = cc.characterNameToken;
                        body.subtitleNameToken = GetChampionSubtitle(cc.championType);
                    }
                }
            }

        }
        public static class ItemRelationships
        {
            public static class RelationshipProviders
            {
                public static ItemRelationshipProvider contagiousItems;
            }
            public static ItemRelationshipType contagiousItem;

            public static void Init()
            {
                RelationshipProviders.contagiousItems = ScriptableObject.CreateInstance<ItemRelationshipProvider>();
                ItemRelationships.contagiousItem = Addressables.LoadAssetAsync<ItemRelationshipType>("RoR2/DLC1/Common/ContagiousItem.asset").WaitForCompletion();
                if(contagiousItem != null)
                {
                    RelationshipProviders.contagiousItems.relationshipType = contagiousItem;
                }
            }
        }
        public static class ItemTiers
        {
            public static void Init()
            {
                //new GodTier().Init();
            }
            //public static ItemTierDef GodTier;

            public static class ItemMasks
            {
                //public static ItemMask GodTier;
            }
        }
        public static class Items
        {

            
            public static void Init()
            {

                //new MaterialTester().Init(ref Content.Items.MaterialTester);
                new ChampionAura().Init(ref Content.Items.ChampionAura);

                new GlassShield().Init(ref Content.Items.GlassShield);
                new GlassShieldBroken().Init(ref Content.Items.GlassShieldBroken);
                new FlatHealIncrease().Init(ref Content.Items.FlatHealIncrease);
                new ProcBoost().Init(ref Content.Items.ProcBoost);
                new HealOnCooldown().Init(ref Content.Items.HealOnCooldown);
                //new GoldStar().Init(ref Content.Items.GoldStar); // untested

                //new HealOnLevelUp().Init(ref Content.Items.HealOnLevelUp); // untested
                new ProjectileBoost().Init(ref Content.Items.ProjectileBoost);
                new TeleporterArmorZone().Init(ref Content.Items.TeleporterArmorZone);
                new UpgradeChests().Init(ref Content.Items.UpgradeChests);
                new DropYellowItemOnKill().Init(ref Content.Items.DropYellowItemOnKill);
                new DropYellowItemOnKillConsumed().Init(ref Content.Items.DropYellowItemOnKillUsed);
                //new MoneyObjectOnSpawn().Init(ref Content.Items.MoneyObjectOnSpawn); // untested
                //new RevengeDamageBonus().Init(ref Content.Items.RevengeDamageBonus); // untested
                //new ExtraPrinterRoll().Init(ref Content.Items.ExtraPrinterRoll); // untested
                //new RuneChance().Init(ref Content.Items.RuneChance); // untested
                new GoldIdol().Init(ref Content.Items.GoldIdol);

                new BlockLowDamageHits().Init(ref Content.Items.BlockLowDamageHits);
                new FrenzyOnBossKill().Init(ref Content.Items.FrenzyOnBossKill);
                new HealthBasedDamageBonus().Init(ref Content.Items.HealthBasedDamageBonus);
                new Placebo().Init(ref Content.Items.Placebo);
                new Shieldbreaker().Init(ref Content.Items.ShieldBreaker);

                new VoidSeedSpawner().Init(ref Content.Items.VoidSeedSpawner);
                new Monocle().Init(ref Content.Items.Monocle);
                //new Egg().Init(ref Content.Items.Egg); // untested
                //new EggUsed().Init(ref Content.Items.EggUsed); // untested
                new ChimeraArmor().Init(ref Content.Items.ChimeraArmor);
                new ChimeraCooldown().Init(ref Content.Items.ChimeraCooldown);
                new ChimeraCrit().Init(ref Content.Items.ChimeraCrit);
                new ChimeraDamage().Init(ref Content.Items.ChimeraDamage);
                new ChimeraHealth().Init(ref Content.Items.ChimeraHealth);
                new ChimeraLuck().Init(ref Content.Items.ChimeraLuck);
                new ChimeraRegen().Init(ref Content.Items.ChimeraRegen);
                new ChimeraShields().Init(ref Content.Items.ChimeraShields);
                new ChimeraSpeed().Init(ref Content.Items.ChimeraSpeed);
                new Chimera().Init(ref Content.Items.Chimera);
                new Grudge().Init(ref Content.Items.Grudge);

                //new FireburstOnFreeze().Init(ref Content.Items.FireburstOnFreeze); // untested
                new DeathImmunity().Init(ref Content.Items.DeathImmunity);
                new SlowTime().Init(ref Content.Items.SlowTime);
                //new ChargingLaser().Init(ref Content.Items.ChargingLaser); // untested

                new StickyBombVoid().Init(ref Content.Items.StickyBombVoid); // untested
                //new EnergyDrinkVoid().Init(ref Content.Items.EnergyDrinkVoid); // untested

                new BeetlePlush().Init(ref Content.Items.BeetlePlush);
                new Geode().Init(ref Content.Items.Geode);
                new MiniWispOnKill().Init(ref Content.Items.WispOnKill);
                new Tentacle().Init(ref Content.Items.Tentacle);
                new ImpEye().Init(ref Content.Items.ImpEye);
                new BisonShield().Init(ref Content.Items.BighornBuckler);
                new SmiteOnHit().Init(ref Content.Items.SmiteOnHit);
                new IgniteOnHit().Init(ref Content.Items.IgniteOnHit);
                new Tarbine().Init(ref Content.Items.Tarbine);
                new MushroomOnKill().Init(ref Content.Items.MushroomOnKill);
                new ProjectileKiller().Init(ref Content.Items.ProjectileKiller);
                new GriefFlower().Init(ref Content.Items.GriefFlower);
                new OrbitingConstructs().Init(ref Content.Items.OrbitingConstructs);
                new DoubleProjectiles().Init(ref Content.Items.DoubleProjectiles);
                new MeleeAttackSpeed().Init(ref Content.Items.MeleeAttackSpeed);
                new FireEye().Init(ref Content.Items.FireEye);
                new GoldArmorBoost().Init(ref Content.Items.GoldArmorBoost);
                new NullSeed().Init(ref Content.Items.NullSeed);
                new VoidShackles().Init(ref Content.Items.VoidChains);

                new GodMode().Init(ref Content.Items.Godmode);
                new VoidEye().Init(ref Content.Items.VoidEye);
                new ThunderAura().Init(ref Content.Items.ThunderAura);
                new LunarRosary().Init(ref Content.Items.LunarRosary);

                new EquipEliteShadow().Init(ref Content.Items.AffixShadow);
                new EquipEliteUnstable().Init(ref Content.Items.AffixUnstable);
                new EquipEliteTar().Init(ref Content.Items.AffixTar);

            }
            
            //Common
            public static ItemDef GlassShield;
            public static ItemDef GlassShieldBroken;
            public static ItemDef GoldStar;
            public static ItemDef FlatHealIncrease;
            public static ItemDef ProcBoost;
            public static ItemDef BoostExperience;
            public static ItemDef DebuffBoss;
            public static ItemDef PrizeTicket;
            public static ItemDef HealOnCooldown;
            public static ItemDef SprintFireMissiles;
            public static ItemDef MaterialTester;

            //Uncommon
            public static ItemDef HealOnLevelUp;
            public static ItemDef TeleporterArmorZone;
            public static ItemDef MoneyObjectOnSpawn;
            public static ItemDef RevengeDamageBonus;
            public static ItemDef ExtraPrinterRoll;
            public static ItemDef UpgradeChests;
            public static ItemDef ShieldArmor;
            public static ItemDef DropYellowItemOnKill;
            public static ItemDef DropYellowItemOnKillUsed;
            public static ItemDef ProjectileBoost;
            public static ItemDef BulletsIntoLasers;
            public static ItemDef GoldIdol;
            //public static ItemDef RuneChance;
            //public static ItemDef MoneyObjectOnSpawn;

            //Rare
            public static ItemDef BlockLowDamageHits;
            public static ItemDef FrenzyOnBossKill;
            public static ItemDef ShieldBreaker;
            public static ItemDef Placebo;
            public static ItemDef HealthBasedDamageBonus;

            //Equipment
            public static EquipmentDef StunNearbyFoes;
            public static EquipmentDef ChargingLaser;
            public static EquipmentDef FireburstOnFreeze;
            public static EquipmentDef SlowTime;
            public static EquipmentDef LevelUp;
            public static EquipmentDef DeathImmunity;

            //Elite Aspects
            public static EquipmentDef AffixTank;
            public static EquipmentDef AffixShadow;
            public static EquipmentDef AffixTar;
            public static EquipmentDef AffixToxic;
            public static EquipmentDef AffixEmpowering;
            public static EquipmentDef AffixSuperboss;
            public static EquipmentDef AffixUnstable;

            //Void
            public static ItemDef WakeOfVulturesVoid;
            public static ItemDef AspectShardBase;
            public static ItemDef AegisVoid;
            public static ItemDef WaxQuailVoid;
            public static ItemDef StickyBombVoid;
            public static ItemDef EnergyDrinkVoid;

            //Lunar
            public static ItemDef VoidSeedSpawner;
            public static ItemDef PiggyBank;
            public static ItemDef Monocle;
            public static ItemDef Chimera;
            public static ItemDef Grudge;
            public static EquipmentDef Egg;
            public static EquipmentDef EggUsed;


            public static ItemDef ChimeraHealth;
            public static ItemDef ChimeraRegen;
            public static ItemDef ChimeraShields;
            public static ItemDef ChimeraDamage;
            public static ItemDef ChimeraCrit;
            public static ItemDef ChimeraArmor;
            public static ItemDef ChimeraCooldown;
            public static ItemDef ChimeraSpeed;
            public static ItemDef ChimeraLuck;

            //Enemy Items
            public static ItemDef BeetlePlush; //beetle
            public static ItemDef Tentacle; //jellyfish
            public static ItemDef ImpEye; //imp
            public static ItemDef WispOnKill; //lesser wisp
            public static ItemDef ArmorWhenEnteringCombat; //lemurian
            public static ItemDef BeetleFallBoots; //beetle guard
            public static ItemDef Geode; //golem
            public static ItemDef Tarbine; //clay templar
            public static ItemDef SmiteOnHit; //greater wisp
            public static ItemDef BighornBuckler; //bison
            public static ItemDef IgniteOnHit; //elder lemurian
            public static ItemDef ShieldWhenStationary; //hermit crab
            public static ItemDef DroneCoupon; //alloy vulture
            public static ItemDef MushroomOnKill; //mushrum
            public static ItemDef ProjectileKiller; //brass contraption
            public static ItemDef GriefFlower; //parent
            public static ItemDef OrbitingConstructs; //alpha construct
            public static ItemDef DoubleProjectiles; //gup, gip, geep
            public static ItemDef TarBallsOnHit; //clayGrenadier
            public static ItemDef ExplodeOnDeath; //lunar exploder
            public static ItemDef LunarFlight; //lunar wisp
            public static ItemDef LowHealthShield; //lunar golem
            public static ItemDef HoverWings; //blind pest
            public static ItemDef MeleeAttackSpeed; //blind vermin
            public static ItemDef AcidSack; //larva
            public static ItemDef VoidChains; //void jailer
            public static ItemDef VoidBarnacleMinion; //void barnacle
            public static ItemDef NullSeed; //void reaver
            public static ItemDef SafeZone; //child
            public static ItemDef FireEye; //scorch wurm
            public static ItemDef GoldArmorBoost; //halcyonite
            public static ItemDef ScavBonus; //scavenger

            public static ItemDef Godmode; //mithrix
            public static ItemDef VoidEye; //voidling
            public static ItemDef ThunderAura; //false son
            public static ItemDef LunarRosary; //twisted scavenger

            //Other
            public static ItemDef ChampionAura;
        }
        
        public static class SerializableEntityStates
        {
            private static Type[] statesToLoad =
            {
                typeof(BaseTarbineState),
                typeof(TarbineFire),
                typeof(TarbineIdle),
                typeof(BaseMiniConstructState),
                typeof(MC_BaseShellChangeState),
                typeof(MC_AIState),
                typeof(MC_Attack),
                typeof(MC_IdleOpen),
                typeof(MC_IdleClosed),
                typeof(MC_Closing),
                typeof(MC_Opening),
                typeof(FireEyeActive),
                typeof(VoidMine_Arming),
                typeof(VoidMine_Armed),
                typeof(TarBodyAttachmentState),
            };

            public static Dictionary<string, SerializableEntityStateType> EntityStateDictionary = new Dictionary<string, SerializableEntityStateType>();
            public static void Init()
            {
                Debug.LogFormat("Siv's Content Pack: Checking for entity state types...");
                Debug.LogFormat("Siv's Content Pack: {0} Entity State(s) found. Beginning addition to content pack.", statesToLoad.Count<Type>());
                foreach (var t in statesToLoad)
                {
                    Debug.LogFormat("- Loading entity state {0} ({1}).", t.Name, t.Namespace);
                    bool wasAdded = false;
                    SerializableEntityStateType sest = ContentAddition.AddEntityState(t, out wasAdded);
                    if (wasAdded)
                    {
                        Debug.LogFormat("- Added entity state type {0} to content pack.", t.Name);
                        EntityStateDictionary.Add(t.Name, sest);
                    }
                }
            }
        }
        public static class Buffs
        {
            public static void Init()
            {
                new BeetlePlushRegen().Init(ref Content.Buffs.BeetleRegen);
                new BossKillFrenzy().Init(ref Content.Buffs.BossKillFrenzy);
                new GeodeArmor().Init(ref Content.Buffs.GeodeArmor);
                new Grief().Init(ref Content.Buffs.Grief);
                new MiniWispStock().Init(ref Content.Buffs.MiniWispStock);
                new MeleeAttackSpeedBuff().Init(ref Content.Buffs.MeleeAttackSpeed);
                new BisonShieldActive().Init(ref Content.Buffs.BisonShieldActive);
                new BisonShieldCooldown().Init(ref Content.Buffs.BisonShieldCooldown);
                new NullSeedActive().Init(ref Content.Buffs.NullSeedActive);
                new NullSeedCooldown().Init(ref Content.Buffs.NullSeedCooldown);
                new TarbineBuff().Init(ref Content.Buffs.Tarbine);
                new DeathImmunityBuff().Init(ref Content.Buffs.DeathImmunity);
                new TimeSlowed().Init(ref Content.Buffs.SlowedTime);
                new ArmorZone().Init(ref Content.Buffs.ArmorZone);
                new LunarCorruption().Init(ref Content.Buffs.LunarCorruption);
                new FullyCorrupted().Init(ref Content.Buffs.FullyCorrupted);

                //new ShadowCloak().Init(ref Content.Buffs.DarknessCamo);
                new EliteTankArmorBonus().Init(ref Content.Buffs.TankArmorBonus);

                new AffixBlack().Init(ref Content.Buffs.AffixShadow);
                new AffixUnstable().Init(ref Content.Buffs.AffixUnstable);
                new AffixTar().Init(ref Content.Buffs.AffixTar);
            }
            public static BuffDef AffixTank;
            public static BuffDef AffixTar;
            public static BuffDef AffixToxic;
            public static BuffDef AffixShadow;
            public static BuffDef AffixEmpowering;
            public static BuffDef AffixSuperboss;
            public static BuffDef AffixUnstable;

            public static BuffDef GeodeArmor;
            public static BuffDef MiniWispStock;
            public static BuffDef TankArmorBonus;
            public static BuffDef Blindness;
            public static BuffDef DarknessCamo;
            public static BuffDef Tarbine;
            public static BuffDef ArmorZone;
            public static BuffDef MeleeAttackSpeed;
            public static BuffDef Grief;
            public static BuffDef BeetleRegen;
            public static BuffDef BisonShieldActive;
            public static BuffDef BisonShieldCooldown;
            public static BuffDef SlowedTime;
            public static BuffDef BossKillFrenzy;
            public static BuffDef StoredLunarCoins;
            public static BuffDef NullSeedActive;
            public static BuffDef NullSeedCooldown;
            public static BuffDef LunarCorruption;
            public static BuffDef FullyCorrupted;
            public static BuffDef DeathImmunity;
        }
        public static class Elites
        {
            public static void Init()
            {
                new Shadow().Init(ref Content.Elites.EliteShadow);
                new Unstable().Init(ref Content.Elites.EliteUnstable);
                new Tar().Init(ref Content.Elites.EliteTar);
            }
            public static EliteDef EliteTank;
            public static EliteDef EliteToxic;
            public static EliteDef EliteTar;
            public static EliteDef EliteShadow;
            public static EliteDef EliteEmpowering;
            public static EliteDef EliteSuperboss;
            public static EliteDef EliteUnstable;
        }
        public static class Artifacts
        {

            public static void Init()
            {
                Material m = Assets.AssetBundles.Artifacts.LoadAsset<Material>("matArtifact");
                Materials.SubmitMaterialFix(m, "Hopoo Games/Deferred/Standard");
                m = Assets.AssetBundles.Artifacts.LoadAsset<Material>("matCompoundCircle");
                Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
                m = Assets.AssetBundles.Artifacts.LoadAsset<Material>("matCompoundDiamond");
                Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
                m = Assets.AssetBundles.Artifacts.LoadAsset<Material>("matCompoundSquare");
                Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");
                m = Assets.AssetBundles.Artifacts.LoadAsset<Material>("matCompoundTriangle");
                Materials.SubmitMaterialFix(m, "Hopoo Games/FX/Opaque Cloud Remap");

                new Design().Init(ref Content.Artifacts.EnemySpecializedItems);
            }

            public static ArtifactDef FloorIsLava;
            public static ArtifactDef EnemySpecializedItems;
            public static ArtifactDef SuperBeetleCompanion;
        }
        public static class Effects
        {
            public static void Init()
            {
                new BlockLowDamageHitsProc().Init(ref Content.Effects.BlockLowDamageHitsProc);
                new DoubleProjectilesProc().Init(ref Content.Effects.DoubleProjectilesProc);
                new CupcakeProc().Init(ref Content.Effects.CupcakeProc);
                new CoinProc().Init(ref Content.Effects.ProcBoostEffect);
                new GoldStarProc().Init(ref Content.Effects.GoldStarProc);
                new GriefProc().Init(ref Content.Effects.GriefProc);
                new SmiteEffect().Init(ref Content.Effects.SmiteFX);
                new GlassShieldBreakProc().Init(ref Content.Effects.GlassShieldBreakProc);
                new FrenzyOnBossKillProc().Init(ref Content.Effects.FrenzyOnBossKillProc);
                new EliteUnstableFX().Init(ref Content.Effects.EliteUnstableImpact);
                new MiniConstructHitSparks().Init(ref Content.Effects.MiniConstructHitSparks);
                new MiniConstructCharge().Init(ref Content.Effects.MiniConstructCharge);
                new MiniConstructMuzzleFlash().Init(ref Content.Effects.MiniConstructMuzzleFlash);
                new MiniConstructOrbTracer().Init(ref Content.Effects.MiniConstructOrb);
                new VoidMineVFX().Init(ref Content.Effects.VoidMineFX);
                new ThunderAuraOrbiterImpact().Init(ref Content.Effects.ThunderAuraOrbiterImpact);
                new LightningStrikeEffect().Init(ref Content.Effects.ThunderAuraLightning);
                new ShadowCloakBreak().Init(ref Content.Effects.ShadowCloakBreak);
                new FireEyeOrb().Init(ref Content.Effects.FireEyeOrb);
                new FireEyeProcEffect().Init(ref Content.Effects.FireEyeProc);
                new WispOnHitMuzzleFlash().Init(ref Content.Effects.MiniWispMuzzleFlash);
                new DeathImmunityProc().Init(ref Content.Effects.DeathImmunityProc);
                new WispOnHitImpact().Init(ref Content.Effects.MiniWispImpact);
                new SingularityBlast().Init(ref Content.Effects.SingularityBlast);
                new TarLifeStealOrbFX().Init(ref Content.Effects.TarLifeStealOrb);
                new CorruptedSpikeImpact().Init(ref Content.Effects.CorruptedSpikeImpact);
                new CorruptionTakesHold().Init(ref Content.Effects.CorruptionTakesHold);
                new CorruptionLifts().Init(ref Content.Effects.CorruptionLifts);
                new TransformationComplete().Init(ref Content.Effects.TransformationComplete);
            }
            public static EffectDef BlockLowDamageHitsProc;
            public static EffectDef DoubleProjectilesProc;
            public static EffectDef ProcBoostEffect;
            public static EffectDef CupcakeProc;
            public static EffectDef GoldStarProc;
            public static EffectDef GoldStarOrb;
            public static EffectDef GlassShieldBreakProc;
            public static EffectDef FrenzyOnBossKillProc;
            public static EffectDef MiniConstructHitSparks;
            public static EffectDef MiniConstructMuzzleFlash;
            public static EffectDef MiniConstructOrb;
            public static EffectDef MiniConstructCharge;
            public static EffectDef MiniWispMuzzleFlash;
            public static EffectDef MiniWispImpact;
            public static EffectDef EliteUnstableImpact;
            public static EffectDef VoidMineFX;
            public static EffectDef TarLifeStealOrb;
            public static EffectDef SmiteFX;
            public static EffectDef DeathImmunityProc;
            public static EffectDef ThunderAuraOrbiterImpact;
            public static EffectDef ThunderAuraLightning;
            public static EffectDef FireEyeOrb;
            public static EffectDef FireEyeProc;
            public static EffectDef GriefProc;
            public static EffectDef CorruptedSpikeImpact;
            public static EffectDef SingularityBlast;
            public static EffectDef ShadowCloakBreak;
            public static EffectDef CorruptionTakesHold;
            public static EffectDef CorruptionLifts;
            public static EffectDef TransformationComplete;
        }
        public static class Orbs
        {

        }
        public static class Interactables
        {

            public static void Init()
            {
                new BossShrine().Init(ref Content.Interactables.iscBossShrine, ref Content.Interactables.BossShrine);

            }

            public static InteractableSpawnCard BountyTerminal;
            public static InteractableSpawnCard ZigguratLightningRod;

            public static InteractableSpawnCard iscEnemyChest;
            public static GameObject EnemyChest;

            public static InteractableSpawnCard iscBossShrine;
            public static GameObject BossShrine;
            public static DirectorCard dcBossShrine;
        }
        public static class Skills
        {
            public static class Huntress
            {
                public static SkillDef HeavyGlaive;
                public static SkillDef LuckyGlaive;
            }
            public static class Toolbot
            {
                public static SkillDef HaulingMode;
            }
            public static class FalseSon
            {
                public static SkillDef AltLunarSpikes;
                public static SkillDef ThunderStorm;
            }
        }
        public static class Unlockables
        {
            public static void Init()
            {
                new ArtifactSpecializedItems().Init(ref Content.Unlockables.UnlockSpecializedItems);
                new UnlockGodTier().Init(ref Content.Unlockables.UnlockGodTier);
                new UnlockGodMode().Init(ref Content.Unlockables.UnlockGodMode);
                new UnlockVoidEye().Init(ref Content.Unlockables.UnlockVoidEye);
                new UnlockThunderAura().Init(ref Content.Unlockables.UnlockThunderAura);
                new UnlockLunarRosary().Init(ref Content.Unlockables.UnlockLunarRosary);
            }

            public static UnlockableDef UnlockSpecializedItems;
            public static UnlockableDef UnlockGodMode;
            public static UnlockableDef UnlockThunderAura;
            public static UnlockableDef UnlockVoidEye;
            public static UnlockableDef UnlockGodTier;
            public static UnlockableDef UnlockLunarRosary;
        }
        public static class SceneDefs
        {
            public static SceneDef Ziggurat;
            public static SceneDef LemurianHome;
            public static SceneDef ConstructFactory;
        }
        public static class Misc
        {
            public static GameObject VoidMine;
            public static GameObject GodModeShockwave;
            public static GameObject ThunderAuraLightning;
            public static GameObject MushroomWard;
            public static GameObject MushroomSpawner;
            public static GameObject SlowTimeBubble;
            public static GameObject ProjectileKillerPrefab;
            public static GameObject VoidEyeSingularity;
            public static GameObject GrudgeFollower;
            public static GameObject MiniWispProjectile;
            public static GameObject EliteUnstableFireball;
            public static GameObject Smite;
            public static GameObject CorruptedSpike;
            public static GameObject ThunderAuraOrbiter;
        }
        public static class DeployableSlots
        {
            public static DeployableSlot GodModeLunarAlly;
            public static DeployableSlot Mushroom;
            public static DeployableSlot ProjectileKiller;
            public static DeployableSlot Singularity;
            public static DeployableSlot GrudgeProjectile;
            public static DeployableSlot ThunderAuraOrbiter;
        }
        public static class ProcTypes
        {
            public static ProcType procBonus;
            public static ProcType smite;
            public static ProcType revengeDamageBonus;
            public static ProcType placebo;
            public static ProcType miniWispOnHit;
            public static ProcType healthBasedDamageBonus;
            public static ProcType stickyBombVoid;
            public static ProcType monocle;
            public static ProcType tentacle;
            public static ProcType tarbine;
            public static ProcType igniteOnHit;
            public static ProcType voidChains;
            public static ProcType singularity;
            public static ProcType eliteTarLifesteal;

        }

        public static class DamageTypes
        {
            public static DamageAPI.ModdedDamageType ArmorPiercingLaser;
        }
    }
}
