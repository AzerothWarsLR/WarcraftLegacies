using MacroTools.LegendSystem;
using MacroTools.PreplacedWidgetsSystem;

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

  public LegendNeutral()
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
      Unit = PreplacedWidgets.Units.Get(UNIT_H026_AUCHINDOUN_CREEP)
    };

    DraktharonKeep = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_O016_DRAK_THARON_KEEP)
    };

    Oshugun = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_H02Z_OSHU_GUN_CREEP)
    };

    Jinthaalor = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_O02G_JINTHA_ALOR)
    };

    ShrineOfUlatek = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_O00Q_SHRINE_OF_ULA_TEK_CREEP_ALTAR)
    };

    Seradane = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_E014_SERADANE_GREAT_TREE_CREEP)
    };

    Zulgurub = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_O018_SHRINE_OF_ZUL_GURUB)
    };

    Dazaralor = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_O00V_DAZAR_ALOR_CREEP),
      Essential = true
    };

    Gundrak = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_O00N_GUNDRAK)
    };

    DuskwoodGraveyard = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_H01F_DUSKWOOD_GRAVEYARD_STORMWIND_OTHER)
    };

    GrimBatol = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_H01Z_GRIM_BATOL_CREEP_TWILIGHT)
    };

    Ethelrethor = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_H05I_ETHEL_RETHOR_CREEP)
    };

    TheNexus = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H04P_THE_NEXUS),
      Capturable = true
    };

    Karazhan = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H00G_KARAZHAN_CREEP),
      Capturable = true
    };

    Zulfarrak = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_O00K_GRAND_PYRAMID_OF_ZUL_FARRAK)
    };

    FountainOfBlood = new Capital
    {
      Capturable = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_NBFL_FOUNTAIN_OF_BLOOD_WARSONG)
    };

    Vaelastrasz = new LegendaryHero("Vaelastrasz")
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_NRWM_VAELASTRASZ)
    };

    Caerdarrow = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_U01M_CAER_DARROW_KEEP_SCOURGE_OTHER),
      Capturable = true
    };

    Shaladrassil = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_E01W_SHALADRASSIL_DRUIDS_OTHER),
      Capturable = true
    };

    BlackrookHold = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H03C_BLACK_ROOK_HOLD_NEUTRAL_HOSTILE),
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
