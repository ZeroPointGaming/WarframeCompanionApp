using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WarframeTracker.WarframeStats.DropData
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
        public int Chance;

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

    public class Apollodorus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Lares
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Caloris
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Elion
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class TerminusCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Tolstoj
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class NerudaCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Caduceus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Odin
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Suisei
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Mercury
    {
        [JsonProperty("Apollodorus")]
        public Apollodorus Apollodorus;

        [JsonProperty("Lares")]
        public Lares Lares;

        [JsonProperty("Caloris")]
        public Caloris Caloris;

        [JsonProperty("Elion")]
        public Elion Elion;

        [JsonProperty("Terminus (Caches)")]
        public TerminusCaches TerminusCaches;

        [JsonProperty("Tolstoj")]
        public Tolstoj Tolstoj;

        [JsonProperty("Neruda (Caches)")]
        public NerudaCaches NerudaCaches;

        [JsonProperty("Caduceus")]
        public Caduceus Caduceus;

        [JsonProperty("Odin")]
        public Odin Odin;

        [JsonProperty("Suisei")]
        public Suisei Suisei;
    }

    public class BifrostEcho
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class BifrostEchoExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class BifrostEchoCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class BeaconShieldRing
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class BeaconShieldRingExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class BeaconShieldRingCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class OrvinHaarc
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class OrvinHaarcExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class OrvinHaarcCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class VesperStrait
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class VesperStraitExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class VesperStraitCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class LucklessExpanse
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class LucklessExpanseExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class LucklessExpanseCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class FallingGlory
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class FallingGloryExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class FallingGloryCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class VPrime
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class IshtarCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Vesper
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Cytherean
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Linea
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Fossa
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Unda
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Malva
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Venera
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Tessera
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Kiliken
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Romula
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Montes
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Venus
    {
        [JsonProperty("Bifrost Echo")]
        public BifrostEcho BifrostEcho;

        [JsonProperty("Bifrost Echo (Extra)")]
        public BifrostEchoExtra BifrostEchoExtra;

        [JsonProperty("Bifrost Echo (Caches)")]
        public BifrostEchoCaches BifrostEchoCaches;

        [JsonProperty("Beacon Shield Ring")]
        public BeaconShieldRing BeaconShieldRing;

        [JsonProperty("Beacon Shield Ring (Extra)")]
        public BeaconShieldRingExtra BeaconShieldRingExtra;

        [JsonProperty("Beacon Shield Ring (Caches)")]
        public BeaconShieldRingCaches BeaconShieldRingCaches;

        [JsonProperty("Orvin-Haarc")]
        public OrvinHaarc OrvinHaarc;

        [JsonProperty("Orvin-Haarc (Extra)")]
        public OrvinHaarcExtra OrvinHaarcExtra;

        [JsonProperty("Orvin-Haarc (Caches)")]
        public OrvinHaarcCaches OrvinHaarcCaches;

        [JsonProperty("Vesper Strait")]
        public VesperStrait VesperStrait;

        [JsonProperty("Vesper Strait (Extra)")]
        public VesperStraitExtra VesperStraitExtra;

        [JsonProperty("Vesper Strait (Caches)")]
        public VesperStraitCaches VesperStraitCaches;

        [JsonProperty("Luckless Expanse")]
        public LucklessExpanse LucklessExpanse;

        [JsonProperty("Luckless Expanse (Extra)")]
        public LucklessExpanseExtra LucklessExpanseExtra;

        [JsonProperty("Luckless Expanse (Caches)")]
        public LucklessExpanseCaches LucklessExpanseCaches;

        [JsonProperty("Falling Glory")]
        public FallingGlory FallingGlory;

        [JsonProperty("Falling Glory (Extra)")]
        public FallingGloryExtra FallingGloryExtra;

        [JsonProperty("Falling Glory (Caches)")]
        public FallingGloryCaches FallingGloryCaches;

        [JsonProperty("V Prime")]
        public VPrime VPrime;

        [JsonProperty("Ishtar (Caches)")]
        public IshtarCaches IshtarCaches;

        [JsonProperty("Vesper")]
        public Vesper Vesper;

        [JsonProperty("Cytherean")]
        public Cytherean Cytherean;

        [JsonProperty("Linea")]
        public Linea Linea;

        [JsonProperty("Fossa")]
        public Fossa Fossa;

        [JsonProperty("Unda")]
        public Unda Unda;

        [JsonProperty("Malva")]
        public Malva Malva;

        [JsonProperty("Venera")]
        public Venera Venera;

        [JsonProperty("Tessera")]
        public Tessera Tessera;

        [JsonProperty("Kiliken")]
        public Kiliken Kiliken;

        [JsonProperty("Romula")]
        public Romula Romula;

        [JsonProperty("Montes")]
        public Montes Montes;
    }

    public class Mantle
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Cambria
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Everest
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Pacific
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Lith
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class SoverStrait
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class SoverStraitExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class SoverStraitCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class IotaTemple
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class IotaTempleExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class IotaTempleCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Gaia
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class CervantesCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Oro
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Coba
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Erpo
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Tikal
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class OgalCluster
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class OgalClusterExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class OgalClusterCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class KormSBelt
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class KormSBeltExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class KormSBeltCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class BendarCluster
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class BendarClusterExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class BendarClusterCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Earth
    {
        [JsonProperty("Mantle")]
        public Mantle Mantle;

        [JsonProperty("Cambria")]
        public Cambria Cambria;

        [JsonProperty("Everest")]
        public Everest Everest;

        [JsonProperty("Pacific")]
        public Pacific Pacific;

        [JsonProperty("Lith")]
        public Lith Lith;

        [JsonProperty("Sover Strait")]
        public SoverStrait SoverStrait;

        [JsonProperty("Sover Strait (Extra)")]
        public SoverStraitExtra SoverStraitExtra;

        [JsonProperty("Sover Strait (Caches)")]
        public SoverStraitCaches SoverStraitCaches;

        [JsonProperty("Iota Temple")]
        public IotaTemple IotaTemple;

        [JsonProperty("Iota Temple (Extra)")]
        public IotaTempleExtra IotaTempleExtra;

        [JsonProperty("Iota Temple (Caches)")]
        public IotaTempleCaches IotaTempleCaches;

        [JsonProperty("Gaia")]
        public Gaia Gaia;

        [JsonProperty("Cervantes (Caches)")]
        public CervantesCaches CervantesCaches;

        [JsonProperty("Oro")]
        public Oro Oro;

        [JsonProperty("Coba")]
        public Coba Coba;

        [JsonProperty("Erpo")]
        public Erpo Erpo;

        [JsonProperty("Tikal")]
        public Tikal Tikal;

        [JsonProperty("Ogal Cluster")]
        public OgalCluster OgalCluster;

        [JsonProperty("Ogal Cluster (Extra)")]
        public OgalClusterExtra OgalClusterExtra;

        [JsonProperty("Ogal Cluster (Caches)")]
        public OgalClusterCaches OgalClusterCaches;

        [JsonProperty("Korm's Belt")]
        public KormSBelt KormSBelt;

        [JsonProperty("Korm's Belt (Extra)")]
        public KormSBeltExtra KormSBeltExtra;

        [JsonProperty("Korm's Belt (Caches)")]
        public KormSBeltCaches KormSBeltCaches;

        [JsonProperty("Bendar Cluster")]
        public BendarCluster BendarCluster;

        [JsonProperty("Bendar Cluster (Extra)")]
        public BendarClusterExtra BendarClusterExtra;

        [JsonProperty("Bendar Cluster (Caches)")]
        public BendarClusterCaches BendarClusterCaches;
    }

    public class Arcadia
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Olympus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Spear
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Alator
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Arval
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Augustus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Ara
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Martialis
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Kadesh
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class War
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class GradivusCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Wahiba
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Quirinus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Syrtis
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Mars
    {
        [JsonProperty("Arcadia")]
        public Arcadia Arcadia;

        [JsonProperty("Olympus")]
        public Olympus Olympus;

        [JsonProperty("Spear")]
        public Spear Spear;

        [JsonProperty("Alator")]
        public Alator Alator;

        [JsonProperty("Arval")]
        public Arval Arval;

        [JsonProperty("Augustus")]
        public Augustus Augustus;

        [JsonProperty("Ara")]
        public Ara Ara;

        [JsonProperty("Martialis")]
        public Martialis Martialis;

        [JsonProperty("Kadesh")]
        public Kadesh Kadesh;

        [JsonProperty("War")]
        public War War;

        [JsonProperty("Gradivus (Caches)")]
        public GradivusCaches GradivusCaches;

        [JsonProperty("Wahiba")]
        public Wahiba Wahiba;

        [JsonProperty("Quirinus")]
        public Quirinus Quirinus;

        [JsonProperty("Syrtis")]
        public Syrtis Syrtis;
    }

    public class Ganymede
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class AdrasteaCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Amalthea
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Metis
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Io
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Elara
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Callisto
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class CarpoCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Themisto
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class TheRopalolyst
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class TheRopalolystExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Sinai
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Ananke
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Galilea
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Cameria
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Jupiter
    {
        [JsonProperty("Ganymede")]
        public Ganymede Ganymede;

        [JsonProperty("Adrastea (Caches)")]
        public AdrasteaCaches AdrasteaCaches;

        [JsonProperty("Amalthea")]
        public Amalthea Amalthea;

        [JsonProperty("Metis")]
        public Metis Metis;

        [JsonProperty("Io")]
        public Io Io;

        [JsonProperty("Elara")]
        public Elara Elara;

        [JsonProperty("Callisto")]
        public Callisto Callisto;

        [JsonProperty("Carpo (Caches)")]
        public CarpoCaches CarpoCaches;

        [JsonProperty("Themisto")]
        public Themisto Themisto;

        [JsonProperty("The Ropalolyst")]
        public TheRopalolyst TheRopalolyst;

        [JsonProperty("The Ropalolyst (Extra)")]
        public TheRopalolystExtra TheRopalolystExtra;

        [JsonProperty("Sinai")]
        public Sinai Sinai;

        [JsonProperty("Ananke")]
        public Ananke Ananke;

        [JsonProperty("Galilea")]
        public Galilea Galilea;

        [JsonProperty("Cameria")]
        public Cameria Cameria;
    }

    public class Helene
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Titan
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Dione
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class MordoCluster
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class MordoClusterExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class MordoClusterCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class KasioSRest
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class KasioSRestExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class KasioSRestCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class NodoGap
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class NodoGapExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class NodoGapCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class LupalPass
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class LupalPassExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class LupalPassCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class VandCluster
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class VandClusterExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class VandClusterCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Mimas
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Iapetus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Tethys
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Phoebe
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Rhea
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class PalleneCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Aegaeon
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Cassini
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Anthe
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Numa
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class CalypsoCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Pandora
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class CephalonCapture
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class CephalonCaptureExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class TeamAnnihilation
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class TeamAnnihilationExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Annihilation
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class AnnihilationExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class LunaroArena
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class LunaroArenaExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Piscinas
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Caracol
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class VariantCephalonCapture
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class VariantCephalonCaptureExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class VariantTeamAnnihilation
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class VariantTeamAnnihilationExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class VariantAnnihilation
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class VariantAnnihilationExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Saturn
    {
        [JsonProperty("Helene")]
        public Helene Helene;

        [JsonProperty("Titan")]
        public Titan Titan;

        [JsonProperty("Dione")]
        public Dione Dione;

        [JsonProperty("Mordo Cluster")]
        public MordoCluster MordoCluster;

        [JsonProperty("Mordo Cluster (Extra)")]
        public MordoClusterExtra MordoClusterExtra;

        [JsonProperty("Mordo Cluster (Caches)")]
        public MordoClusterCaches MordoClusterCaches;

        [JsonProperty("Kasio's Rest")]
        public KasioSRest KasioSRest;

        [JsonProperty("Kasio's Rest (Extra)")]
        public KasioSRestExtra KasioSRestExtra;

        [JsonProperty("Kasio's Rest (Caches)")]
        public KasioSRestCaches KasioSRestCaches;

        [JsonProperty("Nodo Gap")]
        public NodoGap NodoGap;

        [JsonProperty("Nodo Gap (Extra)")]
        public NodoGapExtra NodoGapExtra;

        [JsonProperty("Nodo Gap (Caches)")]
        public NodoGapCaches NodoGapCaches;

        [JsonProperty("Lupal Pass")]
        public LupalPass LupalPass;

        [JsonProperty("Lupal Pass (Extra)")]
        public LupalPassExtra LupalPassExtra;

        [JsonProperty("Lupal Pass (Caches)")]
        public LupalPassCaches LupalPassCaches;

        [JsonProperty("Vand Cluster")]
        public VandCluster VandCluster;

        [JsonProperty("Vand Cluster (Extra)")]
        public VandClusterExtra VandClusterExtra;

        [JsonProperty("Vand Cluster (Caches)")]
        public VandClusterCaches VandClusterCaches;

        [JsonProperty("Mimas")]
        public Mimas Mimas;

        [JsonProperty("Iapetus")]
        public Iapetus Iapetus;

        [JsonProperty("Tethys")]
        public Tethys Tethys;

        [JsonProperty("Phoebe")]
        public Phoebe Phoebe;

        [JsonProperty("Rhea")]
        public Rhea Rhea;

        [JsonProperty("Pallene (Caches)")]
        public PalleneCaches PalleneCaches;

        [JsonProperty("Aegaeon")]
        public Aegaeon Aegaeon;

        [JsonProperty("Cassini")]
        public Cassini Cassini;

        [JsonProperty("Anthe")]
        public Anthe Anthe;

        [JsonProperty("Numa")]
        public Numa Numa;

        [JsonProperty("Calypso (Caches)")]
        public CalypsoCaches CalypsoCaches;

        [JsonProperty("Pandora")]
        public Pandora Pandora;

        [JsonProperty("Cephalon Capture")]
        public CephalonCapture CephalonCapture;

        [JsonProperty("Cephalon Capture (Extra)")]
        public CephalonCaptureExtra CephalonCaptureExtra;

        [JsonProperty("Team Annihilation")]
        public TeamAnnihilation TeamAnnihilation;

        [JsonProperty("Team Annihilation (Extra)")]
        public TeamAnnihilationExtra TeamAnnihilationExtra;

        [JsonProperty("Annihilation")]
        public Annihilation Annihilation;

        [JsonProperty("Annihilation (Extra)")]
        public AnnihilationExtra AnnihilationExtra;

        [JsonProperty("Lunaro Arena")]
        public LunaroArena LunaroArena;

        [JsonProperty("Lunaro Arena (Extra)")]
        public LunaroArenaExtra LunaroArenaExtra;

        [JsonProperty("Piscinas")]
        public Piscinas Piscinas;

        [JsonProperty("Caracol")]
        public Caracol Caracol;

        [JsonProperty("Variant Cephalon Capture")]
        public VariantCephalonCapture VariantCephalonCapture;

        [JsonProperty("Variant Cephalon Capture (Extra)")]
        public VariantCephalonCaptureExtra VariantCephalonCaptureExtra;

        [JsonProperty("Variant Team Annihilation")]
        public VariantTeamAnnihilation VariantTeamAnnihilation;

        [JsonProperty("Variant Team Annihilation (Extra)")]
        public VariantTeamAnnihilationExtra VariantTeamAnnihilationExtra;

        [JsonProperty("Variant Annihilation")]
        public VariantAnnihilation VariantAnnihilation;

        [JsonProperty("Variant Annihilation (Extra)")]
        public VariantAnnihilationExtra VariantAnnihilationExtra;
    }

    public class Ariel
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Titania
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Umbriel
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Miranda
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Ophelia
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class PortiaCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class DesdemonaCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Cupid
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Rosalind
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Bianca
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class ProsperoCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Mab
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class SetebosCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Caliban
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Ur
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Stephano
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Trinculo
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Caelus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Assur
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Uranus
    {
        [JsonProperty("Ariel")]
        public Ariel Ariel;

        [JsonProperty("Titania")]
        public Titania Titania;

        [JsonProperty("Umbriel")]
        public Umbriel Umbriel;

        [JsonProperty("Miranda")]
        public Miranda Miranda;

        [JsonProperty("Ophelia")]
        public Ophelia Ophelia;

        [JsonProperty("Portia (Caches)")]
        public PortiaCaches PortiaCaches;

        [JsonProperty("Desdemona (Caches)")]
        public DesdemonaCaches DesdemonaCaches;

        [JsonProperty("Cupid")]
        public Cupid Cupid;

        [JsonProperty("Rosalind")]
        public Rosalind Rosalind;

        [JsonProperty("Bianca")]
        public Bianca Bianca;

        [JsonProperty("Prospero (Caches)")]
        public ProsperoCaches ProsperoCaches;

        [JsonProperty("Mab")]
        public Mab Mab;

        [JsonProperty("Setebos (Caches)")]
        public SetebosCaches SetebosCaches;

        [JsonProperty("Caliban")]
        public Caliban Caliban;

        [JsonProperty("Ur")]
        public Ur Ur;

        [JsonProperty("Stephano")]
        public Stephano Stephano;

        [JsonProperty("Trinculo")]
        public Trinculo Trinculo;

        [JsonProperty("Caelus")]
        public Caelus Caelus;

        [JsonProperty("Assur")]
        public Assur Assur;
    }

    public class ThalassaCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Galatea
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Proteus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Triton
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Despina
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class ArvaVector
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class ArvaVectorExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class ArvaVectorCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class NuGuaMines
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class NuGuaMinesExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class NuGuaMinesCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class EnkiduIceDrifts
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class EnkiduIceDriftsExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class EnkiduIceDriftsCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class MammonSProspect
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class MammonSProspectExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class MammonSProspectCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class SovereignGrasp
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class SovereignGraspExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class SovereignGraspCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class BromCluster
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class BromClusterExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class BromClusterCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class HalimedeCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Salacia
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Psamathe
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Laomedeia
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Nereid
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Yursa
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Kelashin
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class TheIndexEnduranceLowRisk
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class TheIndexEnduranceMediumRisk
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class TheIndexEnduranceHighRisk
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class TheIndexEndurance
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Neptune
    {
        [JsonProperty("Thalassa (Caches)")]
        public ThalassaCaches ThalassaCaches;

        [JsonProperty("Galatea")]
        public Galatea Galatea;

        [JsonProperty("Proteus")]
        public Proteus Proteus;

        [JsonProperty("Triton")]
        public Triton Triton;

        [JsonProperty("Despina")]
        public Despina Despina;

        [JsonProperty("Arva Vector")]
        public ArvaVector ArvaVector;

        [JsonProperty("Arva Vector (Extra)")]
        public ArvaVectorExtra ArvaVectorExtra;

        [JsonProperty("Arva Vector (Caches)")]
        public ArvaVectorCaches ArvaVectorCaches;

        [JsonProperty("Nu-Gua Mines")]
        public NuGuaMines NuGuaMines;

        [JsonProperty("Nu-Gua Mines (Extra)")]
        public NuGuaMinesExtra NuGuaMinesExtra;

        [JsonProperty("Nu-Gua Mines (Caches)")]
        public NuGuaMinesCaches NuGuaMinesCaches;

        [JsonProperty("Enkidu Ice Drifts")]
        public EnkiduIceDrifts EnkiduIceDrifts;

        [JsonProperty("Enkidu Ice Drifts (Extra)")]
        public EnkiduIceDriftsExtra EnkiduIceDriftsExtra;

        [JsonProperty("Enkidu Ice Drifts (Caches)")]
        public EnkiduIceDriftsCaches EnkiduIceDriftsCaches;

        [JsonProperty("Mammon's Prospect")]
        public MammonSProspect MammonSProspect;

        [JsonProperty("Mammon's Prospect (Extra)")]
        public MammonSProspectExtra MammonSProspectExtra;

        [JsonProperty("Mammon's Prospect (Caches)")]
        public MammonSProspectCaches MammonSProspectCaches;

        [JsonProperty("Sovereign Grasp")]
        public SovereignGrasp SovereignGrasp;

        [JsonProperty("Sovereign Grasp (Extra)")]
        public SovereignGraspExtra SovereignGraspExtra;

        [JsonProperty("Sovereign Grasp (Caches)")]
        public SovereignGraspCaches SovereignGraspCaches;

        [JsonProperty("Brom Cluster")]
        public BromCluster BromCluster;

        [JsonProperty("Brom Cluster (Extra)")]
        public BromClusterExtra BromClusterExtra;

        [JsonProperty("Brom Cluster (Caches)")]
        public BromClusterCaches BromClusterCaches;

        [JsonProperty("Halimede (Caches)")]
        public HalimedeCaches HalimedeCaches;

        [JsonProperty("Salacia")]
        public Salacia Salacia;

        [JsonProperty("Psamathe")]
        public Psamathe Psamathe;

        [JsonProperty("Laomedeia")]
        public Laomedeia Laomedeia;

        [JsonProperty("Nereid")]
        public Nereid Nereid;

        [JsonProperty("Yursa")]
        public Yursa Yursa;

        [JsonProperty("Kelashin")]
        public Kelashin Kelashin;

        [JsonProperty("Cephalon Capture")]
        public CephalonCapture CephalonCapture;

        [JsonProperty("The Index: Endurance (Low Risk)")]
        public TheIndexEnduranceLowRisk TheIndexEnduranceLowRisk;

        [JsonProperty("The Index: Endurance (Medium Risk)")]
        public TheIndexEnduranceMediumRisk TheIndexEnduranceMediumRisk;

        [JsonProperty("The Index: Endurance (High Risk)")]
        public TheIndexEnduranceHighRisk TheIndexEnduranceHighRisk;

        [JsonProperty("The Index: Endurance")]
        public TheIndexEndurance TheIndexEndurance;
    }

    public class OuterTerminus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Regna
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class CharonCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Hydra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Hades
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class CypressCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Cerberus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Palus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Sechura
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Oceanum
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Hieracon
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Corb
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class KhufuEnvoy
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class KhufuEnvoyExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class KhufuEnvoyCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class SevenSirens
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class SevenSirensExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class SevenSirensCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class ObolCrossing
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class ObolCrossingExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class ObolCrossingCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class FentonSField
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class FentonSFieldExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class FentonSFieldCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class ProfitMargin
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class ProfitMarginExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class ProfitMarginCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class PeregrineAxis
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class PeregrineAxisExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class PeregrineAxisCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Pluto
    {
        [JsonProperty("Outer Terminus")]
        public OuterTerminus OuterTerminus;

        [JsonProperty("Regna")]
        public Regna Regna;

        [JsonProperty("Charon (Caches)")]
        public CharonCaches CharonCaches;

        [JsonProperty("Hydra")]
        public Hydra Hydra;

        [JsonProperty("Hades")]
        public Hades Hades;

        [JsonProperty("Cypress (Caches)")]
        public CypressCaches CypressCaches;

        [JsonProperty("Cerberus")]
        public Cerberus Cerberus;

        [JsonProperty("Palus")]
        public Palus Palus;

        [JsonProperty("Sechura")]
        public Sechura Sechura;

        [JsonProperty("Oceanum")]
        public Oceanum Oceanum;

        [JsonProperty("Hieracon")]
        public Hieracon Hieracon;

        [JsonProperty("Corb")]
        public Corb Corb;

        [JsonProperty("Khufu Envoy")]
        public KhufuEnvoy KhufuEnvoy;

        [JsonProperty("Khufu Envoy (Extra)")]
        public KhufuEnvoyExtra KhufuEnvoyExtra;

        [JsonProperty("Khufu Envoy (Caches)")]
        public KhufuEnvoyCaches KhufuEnvoyCaches;

        [JsonProperty("Seven Sirens")]
        public SevenSirens SevenSirens;

        [JsonProperty("Seven Sirens (Extra)")]
        public SevenSirensExtra SevenSirensExtra;

        [JsonProperty("Seven Sirens (Caches)")]
        public SevenSirensCaches SevenSirensCaches;

        [JsonProperty("Obol Crossing")]
        public ObolCrossing ObolCrossing;

        [JsonProperty("Obol Crossing (Extra)")]
        public ObolCrossingExtra ObolCrossingExtra;

        [JsonProperty("Obol Crossing (Caches)")]
        public ObolCrossingCaches ObolCrossingCaches;

        [JsonProperty("Fenton's Field")]
        public FentonSField FentonSField;

        [JsonProperty("Fenton's Field (Extra)")]
        public FentonSFieldExtra FentonSFieldExtra;

        [JsonProperty("Fenton's Field (Caches)")]
        public FentonSFieldCaches FentonSFieldCaches;

        [JsonProperty("Profit Margin")]
        public ProfitMargin ProfitMargin;

        [JsonProperty("Profit Margin (Extra)")]
        public ProfitMarginExtra ProfitMarginExtra;

        [JsonProperty("Profit Margin (Caches)")]
        public ProfitMarginCaches ProfitMarginCaches;

        [JsonProperty("Peregrine Axis")]
        public PeregrineAxis PeregrineAxis;

        [JsonProperty("Peregrine Axis (Extra)")]
        public PeregrineAxisExtra PeregrineAxisExtra;

        [JsonProperty("Peregrine Axis (Caches)")]
        public PeregrineAxisCaches PeregrineAxisCaches;
    }

    public class Olla
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class ThonCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Bode
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Varro
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Lex
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class KerCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Nuovo
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Hapke
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Exta
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class ExtaExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Casta
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Cinxia
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Egeria
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Draco
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Gabii
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Seimeni
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Ceres
    {
        [JsonProperty("Olla")]
        public Olla Olla;

        [JsonProperty("Thon (Caches)")]
        public ThonCaches ThonCaches;

        [JsonProperty("Bode")]
        public Bode Bode;

        [JsonProperty("Varro")]
        public Varro Varro;

        [JsonProperty("Lex")]
        public Lex Lex;

        [JsonProperty("Ker (Caches)")]
        public KerCaches KerCaches;

        [JsonProperty("Nuovo")]
        public Nuovo Nuovo;

        [JsonProperty("Hapke")]
        public Hapke Hapke;

        [JsonProperty("Exta")]
        public Exta Exta;

        [JsonProperty("Exta (Extra)")]
        public ExtaExtra ExtaExtra;

        [JsonProperty("Casta")]
        public Casta Casta;

        [JsonProperty("Cinxia")]
        public Cinxia Cinxia;

        [JsonProperty("Egeria")]
        public Egeria Egeria;

        [JsonProperty("Draco")]
        public Draco Draco;

        [JsonProperty("Gabii")]
        public Gabii Gabii;

        [JsonProperty("Seimeni")]
        public Seimeni Seimeni;
    }

    public class Cyath
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Cosis
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class CandiruCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Brugia
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class LepisCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class KalaAzar
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Hymeno
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Isos
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Gnathos
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Sporid
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Ixodes
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Phalan
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Oestrus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Ranova
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class PsoroCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Nimus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Akkad
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Sparga
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Xini
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class ViverCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Zabala
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class NaeglarCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Eris
    {
        [JsonProperty("Cyath")]
        public Cyath Cyath;

        [JsonProperty("Cosis")]
        public Cosis Cosis;

        [JsonProperty("Candiru (Caches)")]
        public CandiruCaches CandiruCaches;

        [JsonProperty("Brugia")]
        public Brugia Brugia;

        [JsonProperty("Lepis (Caches)")]
        public LepisCaches LepisCaches;

        [JsonProperty("Kala-Azar")]
        public KalaAzar KalaAzar;

        [JsonProperty("Hymeno")]
        public Hymeno Hymeno;

        [JsonProperty("Isos")]
        public Isos Isos;

        [JsonProperty("Gnathos")]
        public Gnathos Gnathos;

        [JsonProperty("Sporid")]
        public Sporid Sporid;

        [JsonProperty("Ixodes")]
        public Ixodes Ixodes;

        [JsonProperty("Phalan")]
        public Phalan Phalan;

        [JsonProperty("Oestrus")]
        public Oestrus Oestrus;

        [JsonProperty("Ranova")]
        public Ranova Ranova;

        [JsonProperty("Psoro (Caches)")]
        public PsoroCaches PsoroCaches;

        [JsonProperty("Nimus")]
        public Nimus Nimus;

        [JsonProperty("Akkad")]
        public Akkad Akkad;

        [JsonProperty("Sparga")]
        public Sparga Sparga;

        [JsonProperty("Xini")]
        public Xini Xini;

        [JsonProperty("Viver (Caches)")]
        public ViverCaches ViverCaches;

        [JsonProperty("Zabala")]
        public Zabala Zabala;

        [JsonProperty("Naeglar (Caches)")]
        public NaeglarCaches NaeglarCaches;
    }

    public class Kappa
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class RusalkaCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Camenae
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Vodyanoi
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Undine
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Jengu
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Nakki
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Berehynia
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Tikoloshe
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Selkie
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class PhithaleCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Kelpie
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Naga
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Yam
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Merrow
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Hydron
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Scylla
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Yemaja
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Amarna
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Veles
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Sangeru
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Sedna
    {
        [JsonProperty("Kappa")]
        public Kappa Kappa;

        [JsonProperty("Rusalka (Caches)")]
        public RusalkaCaches RusalkaCaches;

        [JsonProperty("Camenae")]
        public Camenae Camenae;

        [JsonProperty("Vodyanoi")]
        public Vodyanoi Vodyanoi;

        [JsonProperty("Undine")]
        public Undine Undine;

        [JsonProperty("Jengu")]
        public Jengu Jengu;

        [JsonProperty("Nakki")]
        public Nakki Nakki;

        [JsonProperty("Berehynia")]
        public Berehynia Berehynia;

        [JsonProperty("Tikoloshe")]
        public Tikoloshe Tikoloshe;

        [JsonProperty("Selkie")]
        public Selkie Selkie;

        [JsonProperty("Phithale (Caches)")]
        public PhithaleCaches PhithaleCaches;

        [JsonProperty("Kelpie")]
        public Kelpie Kelpie;

        [JsonProperty("Naga")]
        public Naga Naga;

        [JsonProperty("Yam")]
        public Yam Yam;

        [JsonProperty("Merrow")]
        public Merrow Merrow;

        [JsonProperty("Hydron")]
        public Hydron Hydron;

        [JsonProperty("Scylla")]
        public Scylla Scylla;

        [JsonProperty("Yemaja")]
        public Yemaja Yemaja;

        [JsonProperty("Amarna")]
        public Amarna Amarna;

        [JsonProperty("Veles")]
        public Veles Veles;

        [JsonProperty("Sangeru")]
        public Sangeru Sangeru;
    }

    public class Abaddon
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Gamygyn
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Eligor
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Lillith
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Naamah
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Valefor
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Ose
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Valac
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Shax
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Paimon
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Orias
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Zagan
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Larzac
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class CryoticFront
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Beleth
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Cholistan
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Europa
    {
        [JsonProperty("Abaddon")]
        public Abaddon Abaddon;

        [JsonProperty("Gamygyn")]
        public Gamygyn Gamygyn;

        [JsonProperty("Eligor")]
        public Eligor Eligor;

        [JsonProperty("Lillith")]
        public Lillith Lillith;

        [JsonProperty("Naamah")]
        public Naamah Naamah;

        [JsonProperty("Valefor")]
        public Valefor Valefor;

        [JsonProperty("Ose")]
        public Ose Ose;

        [JsonProperty("Valac")]
        public Valac Valac;

        [JsonProperty("Shax")]
        public Shax Shax;

        [JsonProperty("Paimon")]
        public Paimon Paimon;

        [JsonProperty("Orias")]
        public Orias Orias;

        [JsonProperty("Zagan")]
        public Zagan Zagan;

        [JsonProperty("Larzac")]
        public Larzac Larzac;

        [JsonProperty("Cryotic Front")]
        public CryoticFront CryoticFront;

        [JsonProperty("Beleth")]
        public Beleth Beleth;

        [JsonProperty("Cholistan")]
        public Cholistan Cholistan;
    }

    public class Teshub
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Hepit
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Taranis
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Tiwaz
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Stribog
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class StribogCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Ani
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Ukko
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Oxomoco
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Belenus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Mot
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Aten
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Marduk
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class MardukCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Mithra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Void
    {
        [JsonProperty("Teshub")]
        public Teshub Teshub;

        [JsonProperty("Hepit")]
        public Hepit Hepit;

        [JsonProperty("Taranis")]
        public Taranis Taranis;

        [JsonProperty("Tiwaz")]
        public Tiwaz Tiwaz;

        [JsonProperty("Stribog")]
        public Stribog Stribog;

        [JsonProperty("Stribog (Caches)")]
        public StribogCaches StribogCaches;

        [JsonProperty("Ani")]
        public Ani Ani;

        [JsonProperty("Ukko")]
        public Ukko Ukko;

        [JsonProperty("Oxomoco")]
        public Oxomoco Oxomoco;

        [JsonProperty("Belenus")]
        public Belenus Belenus;

        [JsonProperty("Mot")]
        public Mot Mot;

        [JsonProperty("Aten")]
        public Aten Aten;

        [JsonProperty("Marduk")]
        public Marduk Marduk;

        [JsonProperty("Marduk (Caches)")]
        public MardukCaches MardukCaches;

        [JsonProperty("Mithra")]
        public Mithra Mithra;
    }

    public class Limtoc
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Grildrig
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Stickney
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Skyresh
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Drunlo
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Monolith
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Kepler
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Gulliver
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Shklovsky
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Wendell
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Todd
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Flimnap
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Memphis
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Iliad
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Opik
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Zeugma
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Phobos
    {
        [JsonProperty("Limtoc")]
        public Limtoc Limtoc;

        [JsonProperty("Grildrig")]
        public Grildrig Grildrig;

        [JsonProperty("Stickney")]
        public Stickney Stickney;

        [JsonProperty("Skyresh")]
        public Skyresh Skyresh;

        [JsonProperty("Drunlo")]
        public Drunlo Drunlo;

        [JsonProperty("Monolith")]
        public Monolith Monolith;

        [JsonProperty("Kepler")]
        public Kepler Kepler;

        [JsonProperty("Gulliver")]
        public Gulliver Gulliver;

        [JsonProperty("Shklovsky")]
        public Shklovsky Shklovsky;

        [JsonProperty("Wendell")]
        public Wendell Wendell;

        [JsonProperty("Todd")]
        public Todd Todd;

        [JsonProperty("Flimnap")]
        public Flimnap Flimnap;

        [JsonProperty("Memphis")]
        public Memphis Memphis;

        [JsonProperty("Iliad")]
        public Iliad Iliad;

        [JsonProperty("Opik")]
        public Opik Opik;

        [JsonProperty("Zeugma")]
        public Zeugma Zeugma;
    }

    public class Hyf
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class FormidoCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Terrorem
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Magnacidium
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Deimos
    {
        [JsonProperty("Hyf")]
        public Hyf Hyf;

        [JsonProperty("Formido (Caches)")]
        public FormidoCaches FormidoCaches;

        [JsonProperty("Terrorem")]
        public Terrorem Terrorem;

        [JsonProperty("Magnacidium")]
        public Magnacidium Magnacidium;
    }

    public class PlatoCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Pavlov
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Tycho
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class StöFler
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Copernicus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class Zeipel
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Apollo
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Lua
    {
        [JsonProperty("Plato (Caches)")]
        public PlatoCaches PlatoCaches;

        [JsonProperty("Pavlov")]
        public Pavlov Pavlov;

        [JsonProperty("Tycho")]
        public Tycho Tycho;

        [JsonProperty("StöFler")]
        public StöFler StöFler;

        [JsonProperty("Copernicus")]
        public Copernicus Copernicus;

        [JsonProperty("Zeipel")]
        public Zeipel Zeipel;

        [JsonProperty("Apollo")]
        public Apollo Apollo;
    }

    public class Nabuk
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Taveuni
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Tamu
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class DakataCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Pago
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Garus
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class KuvaFortress
    {
        [JsonProperty("Nabuk")]
        public Nabuk Nabuk;

        [JsonProperty("Taveuni")]
        public Taveuni Taveuni;

        [JsonProperty("Tamu")]
        public Tamu Tamu;

        [JsonProperty("Dakata (Caches)")]
        public DakataCaches DakataCaches;

        [JsonProperty("Pago")]
        public Pago Pago;

        [JsonProperty("Garus")]
        public Garus Garus;
    }

    public class SanctuaryOnslaught
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class EliteSanctuaryOnslaught
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Sanctuary
    {
        [JsonProperty("Sanctuary Onslaught")]
        public SanctuaryOnslaught SanctuaryOnslaught;

        [JsonProperty("Elite Sanctuary Onslaught")]
        public EliteSanctuaryOnslaught EliteSanctuaryOnslaught;
    }

    public class Flexa
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class FlexaExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class FlexaCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class H2Cloud
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class H2CloudExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class H2CloudCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class R9Cloud
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class R9CloudExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class R9CloudCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class NsuGrid
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class NsuGridExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class NsuGridCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Calabash
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class CalabashExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class CalabashCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Numina
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class NuminaExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class NuminaCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class ArcSilver
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class ArcSilverExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class ArcSilverCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Erato
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class EratoExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class EratoCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class LuYan
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class LuYanExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class LuYanCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class SabmirCloud
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class SabmirCloudExtra
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public List<object> Rewards;
    }

    public class SabmirCloudCaches
    {
        [JsonProperty("gameMode")]
        public string GameMode;

        [JsonProperty("isEvent")]
        public bool IsEvent;

        [JsonProperty("rewards")]
        public Rewards Rewards;
    }

    public class Veil
    {
        [JsonProperty("Flexa")]
        public Flexa Flexa;

        [JsonProperty("Flexa (Extra)")]
        public FlexaExtra FlexaExtra;

        [JsonProperty("Flexa (Caches)")]
        public FlexaCaches FlexaCaches;

        [JsonProperty("H-2 Cloud")]
        public H2Cloud H2Cloud;

        [JsonProperty("H-2 Cloud (Extra)")]
        public H2CloudExtra H2CloudExtra;

        [JsonProperty("H-2 Cloud (Caches)")]
        public H2CloudCaches H2CloudCaches;

        [JsonProperty("R-9 Cloud")]
        public R9Cloud R9Cloud;

        [JsonProperty("R-9 Cloud (Extra)")]
        public R9CloudExtra R9CloudExtra;

        [JsonProperty("R-9 Cloud (Caches)")]
        public R9CloudCaches R9CloudCaches;

        [JsonProperty("Nsu Grid")]
        public NsuGrid NsuGrid;

        [JsonProperty("Nsu Grid (Extra)")]
        public NsuGridExtra NsuGridExtra;

        [JsonProperty("Nsu Grid (Caches)")]
        public NsuGridCaches NsuGridCaches;

        [JsonProperty("Calabash")]
        public Calabash Calabash;

        [JsonProperty("Calabash (Extra)")]
        public CalabashExtra CalabashExtra;

        [JsonProperty("Calabash (Caches)")]
        public CalabashCaches CalabashCaches;

        [JsonProperty("Numina")]
        public Numina Numina;

        [JsonProperty("Numina (Extra)")]
        public NuminaExtra NuminaExtra;

        [JsonProperty("Numina (Caches)")]
        public NuminaCaches NuminaCaches;

        [JsonProperty("Arc Silver")]
        public ArcSilver ArcSilver;

        [JsonProperty("Arc Silver (Extra)")]
        public ArcSilverExtra ArcSilverExtra;

        [JsonProperty("Arc Silver (Caches)")]
        public ArcSilverCaches ArcSilverCaches;

        [JsonProperty("Erato")]
        public Erato Erato;

        [JsonProperty("Erato (Extra)")]
        public EratoExtra EratoExtra;

        [JsonProperty("Erato (Caches)")]
        public EratoCaches EratoCaches;

        [JsonProperty("Lu-Yan")]
        public LuYan LuYan;

        [JsonProperty("Lu-Yan (Extra)")]
        public LuYanExtra LuYanExtra;

        [JsonProperty("Lu-Yan (Caches)")]
        public LuYanCaches LuYanCaches;

        [JsonProperty("Sabmir Cloud")]
        public SabmirCloud SabmirCloud;

        [JsonProperty("Sabmir Cloud (Extra)")]
        public SabmirCloudExtra SabmirCloudExtra;

        [JsonProperty("Sabmir Cloud (Caches)")]
        public SabmirCloudCaches SabmirCloudCaches;
    }

    public class MissionRewards
    {
        [JsonProperty("Mercury")]
        public Mercury Mercury;

        [JsonProperty("Venus")]
        public Venus Venus;

        [JsonProperty("Earth")]
        public Earth Earth;

        [JsonProperty("Mars")]
        public Mars Mars;

        [JsonProperty("Jupiter")]
        public Jupiter Jupiter;

        [JsonProperty("Saturn")]
        public Saturn Saturn;

        [JsonProperty("Uranus")]
        public Uranus Uranus;

        [JsonProperty("Neptune")]
        public Neptune Neptune;

        [JsonProperty("Pluto")]
        public Pluto Pluto;

        [JsonProperty("Ceres")]
        public Ceres Ceres;

        [JsonProperty("Eris")]
        public Eris Eris;

        [JsonProperty("Sedna")]
        public Sedna Sedna;

        [JsonProperty("Europa")]
        public Europa Europa;

        [JsonProperty("Void")]
        public Void Void;

        [JsonProperty("Phobos")]
        public Phobos Phobos;

        [JsonProperty("Deimos")]
        public Deimos Deimos;

        [JsonProperty("Lua")]
        public Lua Lua;

        [JsonProperty("Kuva Fortress")]
        public KuvaFortress KuvaFortress;

        [JsonProperty("Sanctuary")]
        public Sanctuary Sanctuary;

        [JsonProperty("Veil")]
        public Veil Veil;
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
        public List<object> Rewards;

        [JsonProperty("_id")]
        public string Id;
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
        public double EnemyModDropChance;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("chance")]
        public double Chance;

        [JsonProperty("enemyItemDropChance")]
        public double EnemyItemDropChance;

        [JsonProperty("enemyBlueprintDropChance")]
        public double EnemyBlueprintDropChance;
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
        public double Chance;
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
        public MissionRewards MissionRewards;

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
