using MacroTools;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendNeutral
  {
    public static LegendaryHero Ragnaros { get; private set; }
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
    public static Capital FountainOfBlood { get; private set; }
    public static LegendaryHero Vaelastrasz { get; private set; }
    public static Capital Caerdarrow { get; private set; }
    public static Capital Shaladrassil { get; private set; }
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Ragnaros = new LegendaryHero("Ragnaros")
      {
        UnitType = Constants.UNIT_N00D_PRIMARY_FIRELORD_CREEP,
        DeathMessage = "Ragnaros, the King of Fire and Lord of the Firelands, has been extinguished.",
        StartingArtifactItemTypeIds = new[]
        {
          Constants.ITEM_I00H_SULFURAS_HAND_OF_RAGNAROS
        },
        StartingXp = 15404
      };
      LegendaryHeroManager.Register(Ragnaros);

      Auchindoun = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h026"))
      };
      CapitalManager.Register(Auchindoun);

      DraktharonKeep = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o016"))
      };
      CapitalManager.Register(DraktharonKeep);

      Oshugun = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h02Z"))
      };
      CapitalManager.Register(Oshugun);

      Jinthaalor = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o02G"))
      };
      CapitalManager.Register(Jinthaalor);

      ShrineOfUlatek = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00Q"))
      };
      CapitalManager.Register(ShrineOfUlatek);

      Seradane = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("e014"))
      };
      CapitalManager.Register(Seradane);

      Zulgurub = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o018"))
      };
      CapitalManager.Register(Zulgurub);

      Dazaralor = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00V"))
      };
      CapitalManager.Register(Dazaralor);

      Gundrak = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00N"))
      };
      CapitalManager.Register(Gundrak);

      DuskwoodGraveyard = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h01F"))
      };
      CapitalManager.Register(DuskwoodGraveyard);

      GrimBatol = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h01Z"))
      };
      CapitalManager.Register(GrimBatol);

      Ethelrethor = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("h05I"))
      };
      CapitalManager.Register(Ethelrethor);

      TheNexus = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h04P")),
        Capturable = true
      };
      CapitalManager.Register(TheNexus);

      Karazhan = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h00G")),
        Capturable = true
      };
      CapitalManager.Register(Karazhan);

      Zulfarrak = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00K"))
      };
      CapitalManager.Register(Zulfarrak);

      FountainOfBlood = new Capital
      {
        Capturable = true,
        Unit = preplacedUnitSystem.GetUnit(FourCC("nbfl"))
      };
      CapitalManager.Register(FountainOfBlood);

      Vaelastrasz = new LegendaryHero("Vaelastrasz")
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("nrwm"))
      };
      LegendaryHeroManager.Register(Vaelastrasz);

      Caerdarrow = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("u01M")),
        Capturable = true
      };
      CapitalManager.Register(Caerdarrow);

      Shaladrassil = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_E01W_SHALADRASSIL_DRUID_OTHER),
        Capturable = true
      };
      CapitalManager.Register(Shaladrassil);
    }
  }
}