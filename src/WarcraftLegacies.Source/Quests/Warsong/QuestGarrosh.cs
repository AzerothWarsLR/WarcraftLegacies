using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  public sealed class QuestGarrosh : QuestData
  {
    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "With Kalimdor now under the Horde's control, the Warsong will be able to expand towards new conquests";

    /// <inheritdoc/>
    protected override string RewardDescription => $"The Warsong Expedition and Garrosh will become available";

    public QuestGarrosh(Capital darnassus) : base("Thirst for Conquest",
      "The Night Elven Druids stand in the way of the Warsong's expansion, they will need to be eliminated for the Horde to grow",
      "ReplaceableTextures\\CommandButtons\\BTNWC1UnholyArmorRemasteredAlt.blp")
    {
      AddObjective(new ObjectiveCapitalDead(darnassus));
      ResearchId = Constants.UPGRADE_R044_QUEST_COMPLETED_NATURAL_CONTEST_DRUIDS;
    }

  }
}