using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>The Wildhammer dwarves of Aerie Peak, who carry on after Ironforge is lost.</summary>
public sealed class WildhammerFaction : Faction
{
  private static readonly HashSet<int> _leftBehind = new()
  {
    UNIT_H00S_KING_OF_KHAZ_MODAN_IRONFORGE,
    UNIT_HMBR_HIGH_THANE_OF_THE_BRONZEBEARDS_IRONFORGE,
    UNIT_H03G_EMPEROR_OF_BLACKROCK_IRONFORGE
  };

  /// <summary>Creates the Wildhammer with whatever <paramref name="ironforge"/> can currently build, train and research.</summary>
  public WildhammerFaction(Faction ironforge)
    : base("Wildhammer", playercolor.Turquoise, @"ReplaceableTextures\CommandButtons\BTNHeroGriffonWarrior.blp")
  {
    TraditionalTeam = TeamSetup.NorthAlliance;
    ControlPointDefenderUnitTypeId = ironforge.ControlPointDefenderUnitTypeId;
    CinematicMusic = ironforge.CinematicMusic;
    FoodMaximum = ironforge.FoodMaximum;
    Nicknames = new List<string>
    {
      "wh",
      "wild",
      "wildhammer"
    };

    ProcessObjectInfo(IronforgeObjectInfo.GetAllObjectLimits().Where(x => !_leftBehind.Contains(x.ObjectTypeId)));
    foreach (var (objectId, limit) in ironforge.GetAllObjectLimits())
    {
      if (!_leftBehind.Contains(objectId))
      {
        SetObjectLimit(objectId, limit);
      }
    }

    SetObjectLimit(UNIT_H0CW_SKY_THANE_OF_THE_WILDHAMMER_WILDHAMMER, 1);
    SetObjectLimit(UNIT_H0CX_GRYPHON_MASTER_OF_AERIE_PEAK_WILDHAMMER, 1);
  }
}
