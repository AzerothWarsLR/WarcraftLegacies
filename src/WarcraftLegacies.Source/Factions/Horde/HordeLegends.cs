using System.Collections.Generic;
using MacroTools.Artifacts;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Factions.Horde;

public sealed class HordeLegends
{
  public LegendaryHero Cairne { get; }
  public LegendaryHero Thrall { get; }
  public LegendaryHero Voljin { get; }
  public Capital ThunderBluff { get; }
  public Capital DarkspearHold { get; }
  public Capital Orgrimmar { get; }

  public HordeLegends()
  {
    Cairne = new LegendaryHero("Cairne Bloodhoof")
    {
      UnitType = UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_HORDE,

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
      UnitType = UNIT_OTHR_WARCHIEF_OF_THE_HORDE_HORDE,
      StartingArtifacts = new()
      {
        new(item.Create(ITEM_I004_THE_DOOMHAMMER, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      }
    };

    ThunderBluff = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O00J_THUNDER_BLUFF_HORDE_OTHER),
      Capturable = true,
      DeathMessage =
        "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home.",
      Essential = true
    };

    DarkspearHold = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O02D_DARKSPEAR_HOLD_HORDE_OTHER),
      Essential = true
    };

    Voljin = new LegendaryHero("Vol'jin")
    {
      UnitType = UNIT_ORKN_CHIEFTAIN_OF_THE_DARKSPEAR_TRIBE_HORDE,
      StartingXp = 2800
    };

    Orgrimmar = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O01B_ORGRIMMAR_HORDE),
      DeathMessage = "Orgrimmar has been demolished, and with it die the hopes and dreams of a wartorn race seeking refuge in a new world.",
      Essential = true
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Cairne);
    LegendaryHeroManager.Register(Thrall);
    LegendaryHeroManager.Register(Voljin);
    CapitalManager.Register(ThunderBluff);
    CapitalManager.Register(DarkspearHold);
  }
}
