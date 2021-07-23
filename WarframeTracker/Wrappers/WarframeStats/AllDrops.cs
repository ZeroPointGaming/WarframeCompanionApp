
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WarframeTracker.WarframeStats.AllDropsData
{
    public class A
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("itemName")]
        public string ItemName;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("chance")]
        public double Chance;

        [JsonProperty("stage")]
        public string Stage;
    }

    public class B
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("itemName")]
        public string ItemName;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("chance")]
        public double Chance;

        [JsonProperty("stage")]
        public string Stage;
    }

    public class C
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("itemName")]
        public string ItemName;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("chance")]
        public double Chance;

        [JsonProperty("stage")]
        public string Stage;
    }

    public class Rewards
    {
        [JsonProperty("A")]
        public List<A> A;

        [JsonProperty("B")]
        public List<B> B;

        [JsonProperty("C")]
        public List<C> C;

        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("itemName")]
        public string ItemName;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("chance")]
        public double Chance;

        [JsonProperty("rotation")]
        public string Rotation;
    }

    public class BasicMission
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<Reward> Rewards;
    }

    public class EndlessMission
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Relic
    {
        [JsonProperty("tier")]
        public string Tier;

        [JsonProperty("relicName")]
        public string RelicName;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("rewards")]
        public List<Reward> Rewards;

        [JsonProperty("_id")]
        public string Id;
    }

    public class Reward
    {
        [JsonProperty("_id")]
        public string ID;

        [JsonProperty("itemName")]
        public string ItemName;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("chance")]
        public double Chance;
    }

    public class TransientReward
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("objectiveName")]
        public string ObjectiveName;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Enemy
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("enemyName")]
        public string EnemyName;

        [JsonProperty("enemyModDropChance")]
        public object EnemyModDropChance;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("chance")]
        public object Chance;

        [JsonProperty("enemyItemDropChance")]
        public object EnemyItemDropChance;

        [JsonProperty("enemyBlueprintDropChance")]
        public object EnemyBlueprintDropChance;
    }

    public class ModLocation
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("modName")]
        public string ModName;

        [JsonProperty("enemies")]
        public List<Enemy> Enemies;
    }

    public class Mod
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("modName")]
        public string ModName;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("chance")]
        public object Chance;
    }

    public class EnemyModTable
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("enemyName")]
        public string EnemyName;

        [JsonProperty("ememyModDropChance")]
        public string EmemyModDropChance;

        [JsonProperty("enemyModDropChance")]
        public string EnemyModDropChance;

        [JsonProperty("mods")]
        public List<Mod> Mods;
    }

    public class BlueprintLocation
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("itemName")]
        public string ItemName;

        [JsonProperty("blueprintName")]
        public string BlueprintName;

        [JsonProperty("enemies")]
        public List<Enemy> Enemies;
    }

    public class Item
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("itemName")]
        public string ItemName;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("chance")]
        public double Chance;

        [JsonProperty("item")]
        public string _Item;
    }

    public class EnemyBlueprintTable
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("enemyName")]
        public string EnemyName;

        [JsonProperty("enemyItemDropChance")]
        public string EnemyItemDropChance;

        [JsonProperty("blueprintDropChance")]
        public string BlueprintDropChance;

        [JsonProperty("items")]
        public List<Item> Items;

        [JsonProperty("mods")]
        public List<Mod> Mods;
    }

    public class SortieReward
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("itemName")]
        public string ItemName;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("chance")]
        public double Chance;
    }

    public class KeyReward
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("keyName")]
        public string KeyName;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class CetusBountyReward
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("bountyLevel")]
        public string BountyLevel;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class SolarisBountyReward
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("bountyLevel")]
        public string BountyLevel;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class DeimosReward
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("bountyLevel")]
        public string BountyLevel;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class ResourceByAvatar
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("source")]
        public string Source;

        [JsonProperty("items")]
        public List<Item> Items;
    }

    public class SigilByAvatar
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("source")]
        public string Source;

        [JsonProperty("items")]
        public List<Item> Items;
    }

    public class AdditionalItemByAvatar
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("source")]
        public string Source;

        [JsonProperty("items")]
        public List<Item> Items;
    }

    public class Root
    {
        [JsonProperty("missionRewards")]
        public Dictionary<string, Dictionary<string, object>> MissionRewards;

        [JsonProperty("relics")]
        public List<Relic> Relics;

        [JsonProperty("transientRewards")]
        public List<TransientReward> TransientRewards;

        [JsonProperty("modLocations")]
        public List<ModLocation> ModLocations;

        [JsonProperty("enemyModTables")]
        public List<EnemyModTable> EnemyModTables;

        [JsonProperty("blueprintLocations")]
        public List<BlueprintLocation> BlueprintLocations;

        [JsonProperty("enemyBlueprintTables")]
        public List<EnemyBlueprintTable> EnemyBlueprintTables;

        [JsonProperty("sortieRewards")]
        public List<SortieReward> SortieRewards;

        [JsonProperty("keyRewards")]
        public List<KeyReward> KeyRewards;

        [JsonProperty("cetusBountyRewards")]
        public List<CetusBountyReward> CetusBountyRewards;

        [JsonProperty("solarisBountyRewards")]
        public List<SolarisBountyReward> SolarisBountyRewards;

        [JsonProperty("deimosRewards")]
        public List<DeimosReward> DeimosRewards;

        [JsonProperty("resourceByAvatar")]
        public List<ResourceByAvatar> ResourceByAvatar;

        [JsonProperty("sigilByAvatar")]
        public List<SigilByAvatar> SigilByAvatar;

        [JsonProperty("additionalItemByAvatar")]
        public List<AdditionalItemByAvatar> AdditionalItemByAvatar;
    }
}
