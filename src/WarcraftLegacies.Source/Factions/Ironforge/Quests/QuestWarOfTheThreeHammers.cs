using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>Destroy Aerie Peak to break the last of the three hammers and claim the Hinterlands.</summary>
public sealed class QuestWarOfTheThreeHammers : QuestData
{
  private const int FireWyrmLimitBonus = 2;

  private static readonly int[] _baseTypes =
  {
    UNIT_H0DS_DARK_IRON_KEEP_DARKIRON_T2,
    UNIT_H0DW_DARK_IRON_BARRACKS_DARKIRON_BARRACKS,
    UNIT_H0DU_DARK_IRON_TAVERN_DARKIRON_FARM,
    UNIT_H0E2_GUARD_BUNKER_DARKIRON_TOWER
  };

  private static readonly Point[] _baseSpots =
  {
    new(15344, 4400),
    new(15888, 4144),
    new(15600, 4944),
    new(14800, 3856)
  };

  public QuestWarOfTheThreeHammers(unit aeriePeak) : base("The War of the Three Hammers",
    "Three clans once warred for the throne of Ironforge. The Bronzebeards have been driven out, and only Aerie Peak still defies us. Destroy it and claim the Hinterlands.",
    @"ReplaceableTextures\CommandButtons\BTNDarkIronTownhall.blp")
  {
    AddObjective(new ObjectiveUnitDestroyed(aeriePeak));
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Aerie Peak has fallen and the last of the three hammers is broken. Dark Iron banners rise over the Hinterlands, and the gryphon roosts make fine nests for our wyrms.";

  /// <inheritdoc />
  protected override string RewardDescription => Loc.Format(
    "Gain a {keep}, {barracks}, {tavern} and {bunker} in the Hinterlands, and train {count} more {wyrm}s",
    ("{keep}", GetObjectName(UNIT_H0DS_DARK_IRON_KEEP_DARKIRON_T2)),
    ("{barracks}", GetObjectName(UNIT_H0DW_DARK_IRON_BARRACKS_DARKIRON_BARRACKS)),
    ("{tavern}", GetObjectName(UNIT_H0DU_DARK_IRON_TAVERN_DARKIRON_FARM)),
    ("{bunker}", GetObjectName(UNIT_H0E2_GUARD_BUNKER_DARKIRON_TOWER)),
    ("{count}", FireWyrmLimitBonus.ToString()),
    ("{wyrm}", GetObjectName(UNIT_H0E6_FIRE_WYRM_DARKIRON)));

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.ModObjectLimit(UNIT_H0E6_FIRE_WYRM_DARKIRON, FireWyrmLimitBonus);
    var whichPlayer = completingFaction.Player;
    if (whichPlayer == null)
    {
      return;
    }

    for (var i = 0; i < _baseTypes.Length; i++)
    {
      PathBase.CreateStructure(whichPlayer, _baseTypes[i], _baseSpots[i].X, _baseSpots[i].Y);
    }
  }
}
