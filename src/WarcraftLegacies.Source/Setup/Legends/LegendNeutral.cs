using MacroTools.LegendSystem;
using MacroTools.Systems;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendNeutral
{
  public LegendaryHero Ragnaros { get; }
  public LegendaryHero YoggSaron { get; }
  public Capital Auchindoun { get; }
  public Capital DraktharonKeep { get; }
  public Capital Oshugun { get; }
  public Capital Jinthaalor { get; }
  public Capital ShrineOfUlatek { get; }
  public Capital Seradane { get; }
  public Capital Zulgurub { get; }
  public Capital Dazaralor { get; }
  public Capital Gundrak { get; }
  public Capital DuskwoodGraveyard { get; }
  public Capital GrimBatol { get; }
  public Capital Ethelrethor { get; }
  public Capital TheNexus { get; }
  public Capital Karazhan { get; }
  public Capital Zulfarrak { get; }
  public Capital FountainOfBlood { get; }
  public LegendaryHero Vaelastrasz { get; }
  public Capital Caerdarrow { get; }
  public Capital Shaladrassil { get; }
  public Capital BlackrookHold { get; }

  public LegendNeutral(PreplacedUnitSystem preplacedUnitSystem)
  {
    Ragnaros = new LegendaryHero("Ragnaros")
    {
      UnitType = UNIT_N00D_PRIMARY_FIRELORD_CREEP,
      DeathMessage = "Ragnaros, the King of Fire and Lord of the Firelands, has been extinguished.",
      StartingArtifacts = new()
      {
        new(item.Create(ITEM_I00H_SULFURAS_HAND_OF_RAGNAROS, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      },
      StartingXp = 15404
    };

    YoggSaron = new LegendaryHero("Yogg-Saron")
    {
      UnitType = UNIT_U02C_OLD_GOD,
      PermaDies = true,
      DeathMessage = "Yogg-Saron, the beast with a thousand maws has been destroyed.",
      StartingArtifacts = new()
      {
        new(item.Create(ITEM_IYGL_VAL_ANYR_HAMMER_OF_ANCIENT_KINGS, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      },
      StartingXp = 23800
    };

    Auchindoun = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("h026"))
    };

    DraktharonKeep = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("o016"))
    };

    Oshugun = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("h02Z"))
    };

    Jinthaalor = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(UNIT_O02G_JINTHA_ALOR)
    };

    ShrineOfUlatek = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("o00Q"))
    };

    Seradane = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("e014"))
    };

    Zulgurub = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("o018"))
    };

    Dazaralor = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("o00V")),
      Essential = true
    };

    Gundrak = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("o00N"))
    };

    DuskwoodGraveyard = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("h01F"))
    };

    GrimBatol = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("h01Z"))
    };

    Ethelrethor = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("h05I"))
    };

    TheNexus = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(FourCC("h04P")),
      Capturable = true
    };

    Karazhan = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(FourCC("h00G")),
      Capturable = true
    };

    Zulfarrak = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("o00K"))
    };

    FountainOfBlood = new Capital
    {
      Capturable = true,
      Unit = preplacedUnitSystem.GetUnit(FourCC("nbfl"))
    };

    Vaelastrasz = new LegendaryHero("Vaelastrasz")
    {
      Unit = preplacedUnitSystem.GetUnit(FourCC("nrwm"))
    };

    Caerdarrow = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(FourCC("u01M")),
      Capturable = true
    };

    Shaladrassil = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(UNIT_E01W_SHALADRASSIL_DRUIDS_OTHER),
      Capturable = true
    };

    BlackrookHold = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(UNIT_H03C_BLACK_ROOK_HOLD_NEUTRAL_HOSTILE),
      Capturable = true
    };
    BlackrookHold.Unit.Life = 500;
    BlackrookHold.Unit.Owner = player.NeutralVictim;
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Ragnaros);
    LegendaryHeroManager.Register(YoggSaron);
    LegendaryHeroManager.Register(Vaelastrasz);
    CapitalManager.Register(Auchindoun);
    CapitalManager.Register(DraktharonKeep);
    CapitalManager.Register(Oshugun);
    CapitalManager.Register(Jinthaalor);
    CapitalManager.Register(ShrineOfUlatek);
    CapitalManager.Register(Seradane);
    CapitalManager.Register(Zulgurub);
    CapitalManager.Register(Dazaralor);
    CapitalManager.Register(Gundrak);
    CapitalManager.Register(DuskwoodGraveyard);
    CapitalManager.Register(GrimBatol);
    CapitalManager.Register(Ethelrethor);
    CapitalManager.Register(TheNexus);
    CapitalManager.Register(Karazhan);
    CapitalManager.Register(Zulfarrak);
    CapitalManager.Register(FountainOfBlood);
    CapitalManager.Register(Caerdarrow);
    CapitalManager.Register(Shaladrassil);
    CapitalManager.Register(BlackrookHold);
  }
}
