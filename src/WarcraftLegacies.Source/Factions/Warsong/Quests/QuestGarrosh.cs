using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Warsong.Quests;

public sealed class QuestGarrosh : QuestData
{
  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The Elven resistance has been shattered, allowing Garrosh and the Warsong clan to rally and press forward towards new territories.";

  /// <inheritdoc/>
  protected override string RewardDescription => Loc.Format(
    "Can now train Garrosh from the {altar} and research the Warsong expedition from the {shipyard}",
    ("{altar}", GetObjectName(UNIT_O020_ALTAR_OF_CONQUERORS_WARSONG_ALTAR)),
    ("{shipyard}", GetObjectName(UNIT_O02T_SHIPYARD_WARSONG_SHIPYARD)));

  public QuestGarrosh() : base("Twilight's Reckoning",
    "The elfs has controlled kalimdor for long enough. Destroy their last holdout and claim the continent for the Horde.",
    @"ReplaceableTextures\CommandButtons\BTNFacelessMadness.blp")
  {
    AddObjective(new ObjectiveCapitalDead(AllLegends.Druids.TempleOfTheMoon));
    ResearchId = UPGRADE_R062_QUEST_COMPLETED_TWILIGHT_S_RECKONING;
  }

}
