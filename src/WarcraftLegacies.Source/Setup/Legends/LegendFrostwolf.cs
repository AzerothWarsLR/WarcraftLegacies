using System.Collections.Generic;
using MacroTools.Artifacts;
using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendFrostwolf
{
  public LegendaryHero Cairne { get; }
  public LegendaryHero Thrall { get; }
  public LegendaryHero Rexxar { get; }
  public LegendaryHero Voljin { get; }
  public Capital ThunderBluff { get; }
  public Capital DarkspearHold { get; }

  public LegendFrostwolf()
  {
    Cairne = new LegendaryHero("Cairne Bloodhoof")
    {
      UnitType = UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_FROSTWOLF,

      DeathMessage =
        "Cairne's spirit has passed on from this world. The Tauren have already begun to revere their fallen ancestor.",
      StartingXp = 1800,
      StartingArtifacts = new List<Artifact>()
      {
        new(item.Create(ITEM_I00L_BLOODHOOF_TOTEM, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      }
    };

    Thrall = new LegendaryHero("Thrall")
    {
      UnitType = UNIT_OTHR_WARCHIEF_OF_THE_HORDE_FROSTWOLF,
      StartingArtifacts = new()
      {
        new(item.Create(ITEM_I004_THE_DOOMHAMMER, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      }
    };

    ThunderBluff = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_O00J_THUNDER_BLUFF_FROSTWOLF_OTHER),
      Capturable = true,
      DeathMessage =
        "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home.",
      Essential = true
    };

    DarkspearHold = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_O02D_DARKSPEAR_HOLD_FROSTWOLF_OTHER),
      Essential = true
    };

    Rexxar = new LegendaryHero("Rexxar")
    {
      UnitType = UNIT_OREX_BEASTMASTER_FROSTWOLF,
      StartingXp = 1800
    };

    Voljin = new LegendaryHero("Vol'jin")
    {
      UnitType = UNIT_ORKN_CHIEFTAIN_OF_THE_DARKSPEAR_TRIBE_FROSTWOLF,
      StartingXp = 2800
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Cairne);
    LegendaryHeroManager.Register(Thrall);
    LegendaryHeroManager.Register(Rexxar);
    LegendaryHeroManager.Register(Voljin);
    CapitalManager.Register(ThunderBluff);
    CapitalManager.Register(DarkspearHold);
  }
}
