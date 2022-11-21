using MacroTools;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendNeutral
  {
    public static Legend Ragnaros { get; private set; }
    public static Legend Morghor { get; private set; }
    public static Legend SeaWitch { get; private set; }
    public static Legend Auchindoun { get; private set; }
    public static Legend DraktharonKeep { get; private set; }
    public static Legend Oshugun { get; private set; }
    public static Legend Jinthaalor { get; private set; }
    public static Legend ShrineOfUlatek { get; private set; }
    public static Legend Seradane { get; private set; }
    public static Legend Zulgurub { get; private set; }
    public static Legend Dazaralor { get; private set; }
    public static Legend Gundrak { get; private set; }
    public static Legend DuskwoodGraveyard { get; private set; }
    public static Legend GrimBatol { get; private set; }
    public static Legend Ethelrethor { get; private set; }
    public static Legend TheNexus { get; private set; }
    public static Legend Karazhan { get; private set; }
    public static Legend Zulfarrak { get; private set; }
    public static Legend FountainOfHealth { get; private set; }
    public static Legend FountainOfHealthWetlands { get; private set; }
    public static Legend FountainOfHealthFeralas { get; private set; }
    public static Legend FountainOfHealthTomb { get; private set; }
    public static Legend FountainOfHealthDalaran { get; private set; }
    public static Legend FountainOfBlood { get; private set; }
    public static Legend CentaurKhan { get; private set; }
    public static Legend Immolthar { get; private set; }
    public static Legend Vaelastrasz { get; private set; }
    public static Legend Occulus { get; private set; }
    public static Legend Saragosa { get; private set; }
    public static Legend Caerdarrow { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Ragnaros = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("N00D")),
        DeathMessage = "Ragnaros, the King of Fire and Lord of the Firelands, has been extinguished."
      };
      Legend.Register(Ragnaros);

      Morghor = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("N0DA")),
        PermaDies = true
      };
      Legend.Register(Morghor);

      SeaWitch = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("O02L"))
      };
      Legend.Register(SeaWitch);

      Auchindoun = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h026"))
      };
      Legend.Register(Auchindoun);

      DraktharonKeep = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o016"))
      };
      Legend.Register(DraktharonKeep);

      Oshugun = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h02Z"))
      };
      Legend.Register(Oshugun);

      Jinthaalor = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o02G"))
      };
      Legend.Register(Jinthaalor);

      ShrineOfUlatek = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00Q"))
      };
      Legend.Register(ShrineOfUlatek);

      Seradane = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("e014"))
      };
      Legend.Register(Seradane);

      Zulgurub = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o018"))
      };
      Legend.Register(Zulgurub);

      Dazaralor = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00V"))
      };
      Legend.Register(Dazaralor);

      Gundrak = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00N"))
      };
      Legend.Register(Gundrak);

      DuskwoodGraveyard = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h01F"))
      };
      Legend.Register(DuskwoodGraveyard);

      GrimBatol = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h01Z"))
      };
      Legend.Register(GrimBatol);

      Ethelrethor = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h05I"))
      };
      Legend.Register(Ethelrethor);

      TheNexus = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h04P")),
        Capturable = true
      };
      Legend.Register(TheNexus);

      Karazhan = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h00G")),
        Capturable = true
      };
      Legend.Register(Karazhan);

      Zulfarrak = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00K"))
      };
      Legend.Register(Zulfarrak);

      FountainOfHealth = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("nfoh"), Regions.AlteracAmbient.Center)
      };
      Legend.Register(FountainOfHealth);

      FountainOfHealthWetlands = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("nfoh"), Regions.WetlandAmbient1.Center)
      };
      Legend.Register(FountainOfHealthWetlands);

      FountainOfHealthFeralas = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("nfoh"), Regions.FeralasAmbient1.Center)
      };
      Legend.Register(FountainOfHealthFeralas);

      FountainOfHealthTomb = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("nfoh"), Regions.InstanceSargerasTomb.Center)
      };
      Legend.Register(FountainOfHealthTomb);

      FountainOfHealthDalaran = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("nfoh"), Regions.DalaranDungeon.Center)
      };
      Legend.Register(FountainOfHealthDalaran);

      FountainOfBlood = new Legend
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("nbfl"))
      };
      Legend.Register(FountainOfBlood);

      CentaurKhan = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("ncnk"), Regions.ThunderBluff.Center)
      };
      Legend.Register(CentaurKhan);

      Immolthar = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("n04R"))
      };
      Legend.Register(Immolthar);

      Vaelastrasz = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("nrwm"))
      };
      Legend.Register(Vaelastrasz);

      Occulus = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("O025")),
        PermaDies = true
      };
      Legend.Register(Occulus);

      Saragosa = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("nadr"))
      };
      Legend.Register(Saragosa);

      Caerdarrow = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("u01M")),
        Capturable = true
      };
      Legend.Register(Caerdarrow);
    }
  }
}