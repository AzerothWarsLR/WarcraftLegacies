using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Gilneas
{
  /// <summary>
  /// Darius gets released from Prison " 
  /// </summary>
  public sealed class QuestCrowley : QuestData
  {
    private const int AltarId = Constants.UNIT_H02X_ALTAR_OF_KINGS_GILNEAS_ALTAR;

    /// <summary>
    /// IniInitializes a new instance of the <see cref="QuestCrowley"/> class.
    /// </summary>
    public QuestCrowley() : base("The Rebel",
      "Darius Crowley has been imprisoned for a long time, if Gilneas were to be in grave peril, an early release might be the soloution.",
      @"ReplaceableTextures/CommandButtons/BTNWorgenHunt.blp")
    {
      AddObjective(new ObjectiveTime(900));
      ResearchId = Constants.UPGRADE_MD05_QUEST_COMPLETED_THE_REBEL;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "With the threat of the Scourge and the Plague, Genn Greymane has decided to forgive Darius Crowly for the Northgate Rebellion so that he can help Gilneas in their dire times.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Learn to train Darius Crowley from the {GetObjectName(AltarId)}";
  }
}
