using BepInEx;
using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;

namespace SivsContentPack.Config
{
    public static class Configuration
    {
        public static ConfigFile config;
        public static class General
        {
            private static string header = "General Options";
            public static ConfigEntry<bool> godModeMithrixBonusesEnabled = config.Bind<bool>(header, "First Design Mithrix bonuses", true, "Toggles the unique bonus effects Mithrix receives from First Design.");
            public static ConfigEntry<bool> voidEyeVoidlingBonusesEnabled = config.Bind<bool>(header, "Juvenile Megalopa Voidling bonuses", true, "Toggles the unique bonus effects Voidling receives from Juvenile Megalopa.");
        }
        public static class Items
        {
            private static string itemEnabledSection = "Enabled Items";
            public static class GlassShield
            {
                private static string text = "Glass Shield";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class GoldStar
            {
                private static string text = "Gold Star";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class FlatHealIncrease
            {
                private static string text = "Pasteurized Milk";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float healBonus = 1f;
                public static float healBonusStack = 1f;
            }
            public static class ProcBoost
            {
                private static string text = "Commemorative Coin";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float baseBoost = 0.1f;
                public static float stackBoost = 0.1f;
            }
            public static class BoostExperience
            {
                private static string text = "Survival Booklet";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class DebuffBoss
            {
                private static string text = "Tau Construct";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static int stackCount = 1;
                public static float detectionRadius = 20f;
                public static float interval = 2f;
                public static float debuffDuration = 4f;
            }

            public static class RandomExplode
            {
                private static string text = "Powder Bomb";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float damageCoefficient = 4;
                public static float damageCoefficientStack = 4f;
                public static float checkInterval = 1f;
                public static float detonateChance = 0.2f;
                public static float checkRadius = 10f;
            }

            public static class HealOnCooldown
            {
                private static string text = "Water Bottle";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float flatHeal = 5f;
                public static float healPercentage = 0.01f;
                public static float healPercentageStack = 0.01f;
            }

            public static class HealOnLevelUp
            {
                private static string text = "Celebratory Cupcake";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float healPercentage = 0.4f;
                public static float healPercentStack = 0.15f;
                public static float invincibilityDuration = 1f;
            }
            public static class TeleporterArmorZone
            {
                private static string text = "Police Tape";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float armorBonus = 50f;
                public static float armorBonusStack = 15f;
                public static float armorZoneRadius = 15f;
                public static int armorCoverNumber = 4;
                public static float armorCoverDistance = 20f;
                public static float armorCoverKnockbackForce = 100f;
            }
            public static class MoneyObjectOnSpawn
            {
                private static string text = "Meteorite Fragment";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float fragmentHealth = 75f;
                public static float fragmentGoldDrop = 75f;
                public static float fragmentGoldDropStack = 25f;
            }
            public static class RevengeDamageBonus
            {
                private static string text = "Know Thy Enemy";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float damageBonus = 1f;
                public static float damageBonusStack = 1f;
            }
            public static class ExtraPrinterRoll
            {
                private static string text = "Hobby Kit";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float extraItemChance = 0.2f;
                public static int chanceAmount = 1;
                public static int chanceAmountStack = 1;
            }
            public static class ProjectileBoost
            {
                private static string text = "Modular Thruster";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float speedBoost = 0.2f;
                public static float speedBoostStack = 0.07f;
                public static float trackingBoost = 0.3f;
                public static float critDamageBonus = 0.15f;
                public static float critDamageBonusStack = 0.05f;
            }

            public static class BulletsIntoLasers
            {
                private static string text = "LED Array";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float rangeBoost = 25f;
                public static float rangeBoostStack = 10f;
                public static float armorPiercing = 20f;
                public static float armorPiercingStack = 5f;

            }
            public static class DropYellowItemOnKill
            {
                private static string text = "Trophy Hunters Medallion";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float dropChance = 30f;
            }

            public static class UpgradeChests
            {
                private static string text = "Law Suit";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float upgradeChance = 30f;
                public static int upgradeAmount = 0;
                public static int upgradeAmountStack = 1;
            }

            public static class GoldIdol
            {
                private static string text = "Idol of Gold";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float portalChanceIncrease = 0.5f;
                public static float procChance = 30f;
                public static int procAmount = 1;
                public static int procAmountStack = 1;
            }
            public static class BlockLowDamageHits
            {
                private static string text = "Nuclear Cuisine";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float damageThreshold = 0.1f;
            }
            public static class FrenzyOnBossKill
            {
                private static string text = "Golden Glory";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float buffDuration = 10f;
                public static float buffDurationStack = 10f;
                public static float luckBonus = 1f;
            }
            public static class ShieldBreaker
            {
                private static string text = "Shieldbreaker";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float shieldDamageBonus = 0.5f;
                public static float shieldDamageBonusStack = 0.5f;
            }
            public static class Placebo
            {
                private static string text = "Critical Placebo";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float critProcCoefficientBonus = 0.5f;
                public static float critProcCoefficientBonusStack = 0.5f;
            }
            public static class HealthBasedDamageBonus
            {
                private static string text = "Dragon Blood";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float healthBoost = 0.25f;
                public static float healthBoostStack = 0.25f;
                public static float healthToDamageCoefficient = 0.25f;
            }
            public static class StunNearbyFoes
            {
                private static string text = "Bison Horn";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float cooldown = 30f;
                public static float radius = 15f;
            }
            public static class ChargingLaser
            {
                private static string text = "Positron Lance";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float cooldown = 5f;
                public static float chargePerSecond = 20f;
                public static float damageCoefficientPerSecond = 5.5f;
                public static float tickRate = 10;
                public static float consumptionRatePerSecond = 100f;
                public static float chargeBonusPerFuelCell = 5f;
            }
            public static class FireburstOnFreeze
            {
                private static string text = "Insulated Blanket";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float cooldown = 10f;
                public static float radius = 15f;
                public static float burnDamageCoefficient = 2.5f;
                public static float burnDuration = 3f;
            }
            public static class DeathImmunity
            {
                private static string text = "Deus Ex Machina";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float cooldown = 77f;
                public static float buffDuration = 3f;
                public static float buffExtension = 2f;
            }
            public static class SlowTime
            {
                private static string text = "Golden Pocket Watch";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float cooldown = 120f;
                public static float radius = 20f;
                public static float speedMult = 0.8f;
            }
            public static class LevelUp
            {
                private static string text = "Drone Assistant";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float cooldown = 120f;
                public static float levelBoost = 1f;
            }
            public static class WakeOfVulturesVoid
            {
                private static string text = "Leviathan Bones";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float shardDropChance = 0.1f;
                public static float shardDropChanceStack = 0.1f;
                public static float shardDamageBonus = 1f;
            }
            public static class AegisVoid
            {
                private static string text = "First-Aid Cell";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float maxHpPerSecond = 0.1f;
                public static float maxHpPerSecondStack = 0.1f;
                public static float healthStorageMult = 1f;
                public static float healthStorageMultStack = 1f;
            }
            public static class WaxQuailVoid
            {
                private static string text = "Warp Feather";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float teleportDistance = 5f;
                public static float teleportDistanceStack = 2.5f;
            }
            public static class StickyBombVoid
            {
                private static string text = "Phosphorescent Mote";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float bombDamage = 1.8f;
                public static float bombDamageStack = 0.8f;
                public static float procChance = 20f;
            }
            public static class EnergyDrinkVoid
            {
                private static string text = "Higgs Solution";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float speedBonus = 0.15f;
                public static float speedBonusStack = 0.15f;
            }
            public static class VoidSeedSpawner
            {
                private static string text = "Abyssal Seedpod";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static int voidSeedAmount = 1;
                public static float creditMult = 1.5f;
                public static float radiusIncrease = 0.3f;
            }
            public static class PiggyBank
            {
                private static string text = "Boarlit Bank";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float interest = 0.75f;
                public static float interestPerStack = 0.25f;
            }
            public static class Monocle
            {
                private static string text = "Vintage Monocle";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float eliteDamageBonus = 0.2f;
                public static float eliteDamageBonusStack = 0.2f;
                public static float nonEliteDamagePenalty = 0.2f;
                public static float nonEliteDamagePenaltyStack = 0.2f;
            }

            public static class OminousLoanNote
            {
                private static string text = "Ominous Loan Note";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float goldOnPickup = 200f;
                public static float interest = 0.1f;
            }
            public static class Chimera
            {
                private static string text = "Hungry Chimera";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float duration = 60f;
                public static int itemsConsumed = 1;
                public static int itemsConsumedStack = 1;

                public static class Blessings
                {
                    public static float hpBonus = 0.1f;
                    public static float hpBonusStack = 0.1f;
                    public static float shieldBonus = 0.1f;
                    public static float shieldBonusStack = 0.1f;
                    public static float regenBonus = 2f;
                    public static float regenBonusStack = 2f;
                    public static float damageBonus = 0.1f;
                    public static float damageBonusStack = 0.1f;
                    public static float critBonus = 0.07f;
                    public static float critBonusStack = 0.07f;
                    public static float attackSpeedBonus = 0.1f;
                    public static float attackSpeedBonusStack = 0.1f;
                    public static float armorBonus = 10f;
                    public static float armorBonusStack = 10f;
                    public static float moveSpeedBonus = 0.1f;
                    public static float moveSpeedBonusStack = 0.1f;
                    public static float cooldownBonus = 0.5f;
                    public static float cooldownBonusStack = 0.5f;
                    public static float luckBonus = 1f;
                    public static float luckBonusStack = 1;
                }

            }
            public static class Grudge
            {
                private static string text = "Lingering Resentment";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float damageCoefficient = 10f;
                public static float damageCoefficientStack = 2.5f;
                public static float nearSpeedThreshold = 10f;
                public static float farSpeedThreshold = 100f;
                public static float baseSpeed = 5f;
                public static float nearSpeedMult = 0.75f;
                public static float farSpeedMult = 10f;
                public static float baseRotationSpeed = 45f;

            }

            public static class Egg
            {
                private static string text = "Cosmic Egg";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float cooldown = 77f;
            }

            public static class BeetlePlush
            {
                private static string text = "Workers Bond";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float radius = 20f;
                public static float radiusStack = 8f;
                public static float regenBonus = 2.5f;
            }
            public static class Tentacle
            {
                private static string text = "Frayed Tentacle";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float procChance = 10f;
                public static float tetherTotalDPS = 1f;
                public static float tetherDuration = 3f;
                public static float tetherDurationStack = 1f;
                public static int ticksPerSecond = 6;
                public static int baseTetherLimit = 1;
                public static int stackTetherLimit = 1;
            }
            public static class ImpEye
            {
                private static string text = "Imps Eye";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float damageBonus = 0.01f;
                public static float damageBonusStack = 0.01f;
                public static float speedReductionMultiplier = 0.5f;
            }
            public static class WispOnKill
            {
                private static string text = "Abandoned Wisp";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static int wispMax = 3;
                public static int wispMaxStack = 1;
                public static float wispRecoveryInterval = 3f;
                public static float wispDamageCoefficient = 1.5f;
            }
            public static class ArmorWhenEnteringCombat
            {
                private static string text = "???";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class BeetleFallBoots
            {
                private static string text = "Chitin Hammer";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float slamDamage = 3.6f;
                public static float slamDamageStack = 1.2f;
                public static float fallDamageReduction = 0.1f;
                public static float fallDamageReductionStack = 0.05f;
                public static float fallDamageLimit = 1f;
            }
            public static class Geode
            {
                private static string text = "Mourning Geode";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static int armorBonus = 15;
                public static int armorStack = 15;
                public static float regenMult = 10f;
                public static float regenMultStack = 3.5f;
                public static float duration = 1f; //in seconds
                public static float durationStack = 0.25f;
            }
            public static class Tarbine
            {
                private static string text = "Frenzied Tarbine";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");

                public static int hitThreshold = 3;
                public static float bulletsPerSecond = 10f;
                public static float attackSpeedBonus = 0.15f;
                public static float attackWindowDuration = 0.25f;
                public static float bulletDmgCoefficient = 0.8f;
                public static float bulletDmgCoefficientStack = 0.2f;
                public static float barrageActiveDuration = 2f;
            }
            public static class SmiteOnHit
            {
                private static string text = "Mythic Spark";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static int smiteCount = 1;
                public static int smiteCountStack = 1;
                public static float smiteDistance = 10f;
                public static float fuse = 1f;
                public static float fuseInterval = 0.25f;
                public static float damageCoefficient = 4.5f;
                public static float procChance = 10f;
            }
            public static class BighornBuckler
            {
                private static string text = "Bighorn Buckler";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float rechargeTime = 3f;
                public static float damageCoefficient = 2.5f;
                public static float damageCoefficientStack = 1.6f;
                public static float sprintSpeedBonus = 0.2f;
                public static float knockbackForce = 500f;
                public static float refreshInterval = 0.75f;
            }
            public static class IgniteOnHit
            {
                private static string text = "Living Furnace";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float procChance = 10f;
                public static float burnDamageCoefficient = 2.5f;
                public static float durationBase = 2f;
                public static float durationStack = 1f;
            }
            public static class ShieldWhenStationary
            {
                private static string text = "No Place Like Home";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float timeStill = 2f;
                public static int attacksBlocked = 3;
                public static int attacksBlockedStack = 1;
                public static float refreshDuration = 10f;
            }
            public static class DroneCoupon
            {
                private static string text = "Alloy Remote";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class MushroomOnKill
            {
                private static string text = "Mushrum Spore";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static int mushroomCount = 3;
                public static int mushroomStack = 1;
                public static float radius = 25f;
                public static float radiusStack = 18f;
                public static float damagePerSecond = 1f;
                public static float damagePerSecondStack = 0.4f;
            }
            public static class ProjectileKiller
            {
                private static string text = "Brass Mechanism";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float fuse = 3f;
                public static float fuseStack = 1f;
                public static float damageCoefficient = 0.5f;
                public static float radius = 20f;
            }
            public static class GriefFlower
            {
                private static string text = "The Second Stage";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float buffDuration = 3f;
                public static float buffStack = 1.5f;
                public static float damageMult = 2f;
                public static float armorBoost = 300f;
                public static float moveSpeedMult = 0.5f;
                public static float attackSpeedMult = 0.5f;
                public static float regenMult = 10f;
            }
            public static class OrbitingConstructs
            {
                private static string text = "Beta Constructs";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static int constructCount = 1;
                public static int constructStack = 1;
                public static float damageCoefficient = 2f;
                public static float orbitSpeed = 10f;
                public static float orbitRadius = 2f;
                public static int ringCount = 12;
                public static int ringStack = 4;
            }
            public static class DoubleProjectiles
            {
                private static string text = "Royal Jelly";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static int projectileCount = 2;
                public static float procChance = 5f;
                public static float procChanceStack = 5f;
                public static float totalDamageBonus = 1.5f;
                public static float angleBetweenShots = 5f;
            }
            public static class TarBallsOnHit
            {
                private static string text = "???";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class ExplodeOnDeath
            {
                private static string text = "???";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class LunarFlight
            {
                private static string text = "???";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class LowHealthShield
            {
                private static string text = "???";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class HoverWings
            {
                private static string text = "???";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class MeleeAttackSpeed
            {
                private static string text = "Rapid Incisor";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float distance = 15f;
                public static float buffDuration = 1f;
                public static float buffInterval = 0.5f;
                public static float attackSpeedMult = 0.2f;
                public static float attackSpeedMultStack = 0.2f;
            }
            public static class AcidSack
            {
                private static string text = "???";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class VoidChains
            {
                private static string text = "???";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class VoidBarnacleMinion
            {
                private static string text = "???";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class NullSeed
            {
                private static string text = "Null Seed";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float radius = 5f;
                public static float cooldown = 30f;
                public static float cooldownReduction = 0.15f;
            }
            public static class SafeZone
            {
                private static string text = "???";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
            }
            public static class FireEye
            {
                private static string text = "Scorching Witness";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static int projectileBlock = 1;
                public static int projectileBlockStack = 1;
                public static float dotThreshold = 0.6f;
                public static float blockInterval = 1f;
                public static float burnDuration = 3.5f;
                public static float burnDamageCoefficient = 1.25f;
                public static float burnDamageCoefficientStack = 0.8f;
                public static float projectileBlockRadius = 40f;
            }
            public static class GoldArmorBoost
            {
                private static string text = "Halcyon Shard";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float goldPercentage = 0.08f;
                public static float goldThreshold = 25f;
                public static float armorPerThreshold = 10f;
                public static float goldPercentageStack = 0.02f;
                public static float armorCap = 60f;
                public static float armorCapStack = 20f;
            }
            public static class GodMode
            {
                private static string text = "First Design";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");

                public static float crippleDuration = 2f;
                public static float crippleDurationStack = 2f;
                public static float shockwaveDamage = 3f;
                public static float shockwaveDamageStack = 3f;
                public static int shockwaveCount = 3;
                public static float shockwaveAngle = 2.5f;
                public static float shockwaveCooldown = 5f;
                public static float summonDuration = 15f;
                public static float summonReduction = 0.5f;
                public static int summonLimit = 3;
                public static int summonLimitStack = 3;
                public static float shieldPercentage = 0.25f;
                public static float moveSpeedBonus = 0.25f;

                public static float brotherSlamShockwaveCount = 8f;
                public static float brotherUltShockwaveInterval = 1f;

            }
            public static class VoidEye
            {
                private static string text = "Juvenile Megalopa";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float singularityInterval = 5f;
                public static float voidFogRadius = 20f;
                public static float voidFogRadiusStack = 20f;
                public static float singularityDamageCoeff = 40f;
                public static float corruptionChance = 20f;
                public static float corruptionChanceStack = 20f;

                public static float raidCrabSingularityInterval = 1f;
                public static float raidCrabSingularityRadius = 100f;
            }
            public static class ThunderAura
            {
                private static string text = "Clouded Heart";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");
                public static float lunarRuinDuration = 5f;
                public static float lunarRuinDurationStack = 5f;
                public static float lightningDuration = 2f;
                public static float lightningFuse = 2f;
                public static float lightningDamage = 4f;
                public static float lightningDamageStack = 4f;
                public static float lightningMaxDistance = 30f;
                public static int orbiterMax = 4;
                public static int orbiterMaxStack = 4;
                public static float orbiterDamageCoefficient = 4.5f;
                public static float orbiterRechargeInterval = 4f;
            }

            public static class LunarRosary
            {
                private static string text = "Anathemic Rosary";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(itemEnabledSection, text, true, "Toggle to prevent this item from appearing.");

                public static int baseCorruptionCap = 4;
                public static int corruptionCapPerLunarItem = 1;
                public static int corruptionCapPerLunarItemStack = 1;
                public static float corruptionInterval = 5f;
                public static float corruptionDegradeTime = 1f;
                public static float corruptionDegradeTimeStack = 1f;

                public static float transformationTimer = 1.2f;

                public static class LunarCorruption
                {
                    public static float healthPenalty = 0.025f;
                    public static float damagePenalty = 0.1f;
                    public static float movementPenalty = 0.05f;
                    public static float cooldownPenalty = 0.25f;
                    public static float experienceGainPenalty = 0.25f;
                }

                public static class FullyCorrupted
                {
                    public static float healthBonus = 0.25f;
                    public static float damageBonus = 0.125f;
                    public static float luckBonus = 0.25f;
                    public static float movementBonus = 0.1f;

                    public static float experienceGainBonus = 0.5f;
                    public static float cooldownBonus = 0.1f;

                    public static float spikeDamageCoefficient = 2.5f;
                    public static float spikeCooldown = 4f;
                    public static float spikeInterval = 0.15f;

                    public static int spikeCount = 5;
                    public static float spikeAngleInterval = 10f;

                }

            }
        }
        public static class Elites
        {
            private static string eliteEnabledSection = "Enabled Elites";
            public static class Empowering
            {
                private static string text = "Empowering";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(eliteEnabledSection, text, true, "Toggle to prevent this elite from appearing.");
                public static float effectRadius = 30f;
                public static float interval = 2f;
                public static int maxTethers = 8;
            }
            public static class Tank
            {
                private static string text = "Armored";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(eliteEnabledSection, text, true, "Toggle to prevent this elite from appearing.");
                public static float armorBonus = 20f;
                public static float armorBonusDuration = 4f;
            }
            public static class Unstable
            {
                private static string text = "Prototype";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(eliteEnabledSection, text, true, "Toggle to prevent this elite from appearing.");
                public static float healthMult = 0.5f;
                public static float damageMult = 1f;
                public static float fireBallDamageCoefficient = 1.5f;
                public static int fireBallCount = 3;
                public static float fireballInterval = 5f;
            }

            public static class Obscuring
            {
                private static string text = "Obscuring";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(eliteEnabledSection, text, true, "Toggle to prevent this elite from appearing.");
                public static float blindnessDuration = 10f;
            }
            public static class Tar
            {
                private static string text = "Tar Symbiont";
                public static ConfigEntry<bool> enabled = config.Bind<bool>(eliteEnabledSection, text, true, "Toggle to prevent this elite from appearing.");
                public static float costMult = 4f;
                public static float lifeStealCoefficient = 1f;
                public static float tarDuration = 5f;
            }
        }
    }
}
