using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendNeutral
  {
    public static LegendaryHero Ragnaros { get; private set; }
    public static LegendaryHero Morghor { get; private set; }
    public static LegendaryHero MurlocSorc { get; private set; }
    public static Capital Auchindoun { get; private set; }
    public static Capital DraktharonKeep { get; private set; }
    public static Capital Oshugun { get; private set; }
    public static Capital Jinthaalor { get; private set; }
    public static Capital ShrineOfUlatek { get; private set; }
    public static Capital Seradane { get; private set; }
    public static Capital Zulgurub { get; private set; }
    public static Capital Dazaralor { get; private set; }
    public static Capital Gundrak { get; private set; }
    public static Capital DuskwoodGraveyard { get; private set; }
    public static Capital GrimBatol { get; private set; }
    public static Capital Ethelrethor { get; private set; }
    public static Capital TheNexus { get; private set; }
    public static Capital Karazhan { get; private set; }
    public static Capital Zulfarrak { get; private set; }
    public static Capital FountainOfHealth { get; private set; }
    public static Capital FountainOfHealthWetlands { get; private set; }
    public static Capital FountainOfHealthFeralas { get; private set; }
    public static Capital FountainOfBlood { get; private set; }
    public static LegendaryHero CentaurKhan { get; private set; }
    public static LegendaryHero Vaelastrasz { get; private set; }
    public static LegendaryHero Occulus { get; private set; }
    public static LegendaryHero Saragosa { get; private set; }
    public static Capital Caerdarrow { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Ragnaros = new LegendaryHero
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("N00D")),
        DeathMessage = "Ragnaros, the King of Fire and Lord of the Firelands, has been extinguished."
      };
      Legend.Register(Ragnaros);

      Morghor = new LegendaryHero
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("N0DA")),
        PermaDies = true
      };
      Legend.Register(Morghor);

      MurlocSorc = new LegendaryHero
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("N089")),
        PermaDies = true
      };
      Legend.Register(MurlocSorc);

      Auchindoun = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h026"))
      };
      Legend.Register(Auchindoun);

      DraktharonKeep = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o016"))
      };
      Legend.Register(DraktharonKeep);

      Oshugun = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h02Z"))
      };
      Legend.Register(Oshugun);

      Jinthaalor = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o02G"))
      };
      Legend.Register(Jinthaalor);

      ShrineOfUlatek = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00Q"))
      };
      Legend.Register(ShrineOfUlatek);

      Seradane = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("e014"))
      };
      Legend.Register(Seradane);

      Zulgurub = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o018"))
      };
      Legend.Register(Zulgurub);

      Dazaralor = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00V"))
      };
      Legend.Register(Dazaralor);

      Gundrak = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00N"))
      };
      Legend.Register(Gundrak);

      DuskwoodGraveyard = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h01F"))
      };
      Legend.Register(DuskwoodGraveyard);

      GrimBatol = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h01Z"))
      };
      Legend.Register(GrimBatol);

      Ethelrethor = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h05I"))
      };
      Legend.Register(Ethelrethor);

      TheNexus = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h04P")),
        Capturable = true
      };
      Legend.Register(TheNexus);

      Karazhan = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h00G")),
        Capturable = true
      };
      Legend.Register(Karazhan);

      Zulfarrak = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00K"))
      };
      Legend.Register(Zulfarrak);

      FountainOfHealth = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("nfoh"), Regions.AlteracAmbient.Center)
      };
      Legend.Register(FountainOfHealth);

      FountainOfHealthWetlands = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("nfoh"), Regions.WetlandAmbient1.Center)
      };
      Legend.Register(FountainOfHealthWetlands);

      FountainOfHealthFeralas = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("nfoh"), Regions.FeralasAmbient1.Center)
      };
      Legend.Register(FountainOfHealthFeralas);

      FountainOfBlood = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("nbfl"))
      };
      Legend.Register(FountainOfBlood);

      CentaurKhan = new LegendaryHero
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("ncnk"), Regions.ThunderBluff.Center)
      };
      Legend.Register(CentaurKhan);

      Vaelastrasz = new LegendaryHero
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("nrwm"))
      };
      Legend.Register(Vaelastrasz);

      Occulus = new LegendaryHero
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("O025")),
        PermaDies = true
      };
      Legend.Register(Occulus);

      Saragosa = new LegendaryHero
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("nadr"))
      };
      Legend.Register(Saragosa);

      Caerdarrow = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("u01M")),
        Capturable = true
      };
      Legend.Register(Caerdarrow);
    }
  }
}