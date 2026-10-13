using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Stormwind;

/// <summary>The kingdom of Stromgarde under the Trollbanes, who carry on after Stormwind is lost.</summary>
public sealed class StromgardeFaction : Faction
{
  private static readonly HashSet<int> _leftBehind = new()
  {
    UNIT_H00R_KING_OF_STORMWIND_STORMWIND,
    UNIT_H017_HIGHLORD_OF_THE_ALLIANCE_STORMWIND,
    UNIT_H05Y_LORD_WIZARD_STORMWIND
  };

  /// <summary>Creates Stromgarde with whatever <paramref name="stormwind"/> can currently build, train and research.</summary>
  public StromgardeFaction(Faction stormwind)
    : base("Stromgarde", playercolor.LightGray, @"ReplaceableTextures\CommandButtons\BTNTheCaptain.blp")
  {
    TraditionalTeam = TeamSetup.NorthAlliance;
    ControlPointDefenderUnitTypeId = stormwind.ControlPointDefenderUnitTypeId;
    CinematicMusic = stormwind.CinematicMusic;
    FoodMaximum = stormwind.FoodMaximum;
    Nicknames = new List<string>
    {
      "sg",
      "strom",
      "stromgarde"
    };

    ProcessObjectInfo(StormwindObjectInfo.GetAllObjectLimits().Where(x => !_leftBehind.Contains(x.ObjectTypeId)));
    foreach (var (objectId, limit) in stormwind.GetAllObjectLimits())
    {
      if (!_leftBehind.Contains(objectId))
      {
        SetObjectLimit(objectId, limit);
      }
    }

    SetObjectLimit(UNIT_H0CY_KING_OF_STROMGARDE_STROMGARDE, 1);
    SetObjectLimit(UNIT_H0CZ_COMMANDER_OF_THE_STROMGARDE_MILITIA_STROMGARDE, 1);
  }
}
