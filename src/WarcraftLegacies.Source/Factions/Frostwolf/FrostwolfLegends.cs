using System.Collections.Generic;
using MacroTools.Artifacts;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Factions.Frostwolf;

public sealed class FrostwolfLegends
{
  public LegendaryHero Cairne { get; }
  public LegendaryHero Rexxar { get; }
  public Capital ThunderBluff { get; }
  public Capital DarkspearHold { get; }

  public FrostwolfLegends()
  {
    Cairne = new LegendaryHero("Cairne Bloodhoof")
    {
      UnitType = UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_TAUREN_TRIBES,

      DeathMessage =
        "Cairne's spirit has passed on from this world. The Tauren have already begun to revere their fallen ancestor.",
      StartingXp = 1800,
      StartingArtifacts = new List<Artifact>()
      {
        new(item.Create(ITEM_I00L_BLOODHOOF_TOTEM, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      }
    };

    ThunderBluff = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O00J_THUNDER_BLUFF_FROSTWOLF_OTHER),
      Capturable = true,
      DeathMessage =
        "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home.",
      Essential = true
    };

    DarkspearHold = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O02D_DARKSPEAR_HOLD_FROSTWOLF_OTHER),
      Essential = true
    };

    Rexxar = new LegendaryHero("Rexxar")
    {
      UnitType = UNIT_OREX_BEASTMASTER_TAUREN_TRIBES,
      StartingXp = 1800
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Cairne);
    LegendaryHeroManager.Register(Rexxar);
    CapitalManager.Register(ThunderBluff);
    CapitalManager.Register(DarkspearHold);
  }
}
