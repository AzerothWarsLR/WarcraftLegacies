using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Quests.CrisisSpawn
{
  /// <summary>
  /// Once the horde is dead, Cthun becomes available.
  /// </summary>
  public sealed class QuestHordeDead : QuestData
  {
    /// <inheritdoc/>
    protected override string RewardFlavour => "The Horde is defeated, C'thun is awakening in the sands of Ahn'qiraj";

    /// <inheritdoc/>
    protected override string RewardDescription => "The C'thun faction will become available to pick as a crisis";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestHordeDead"/> class.
    /// </summary>
    public QuestHordeDead() : base("Horde is Defeated",
      "With the Horde eliminated, something stirs in the sands of Ahn'qiraj",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      AddObjective(new ObjectiveFactionDefeated(WarsongSetup.WarsongClan));
      AddObjective(new ObjectiveFactionDefeated(FrostwolfSetup.Frostwolf));
      AddObjective(new ObjectiveEitherOf(
        new ObjectiveFactionDefeated(GoblinSetup.Goblin),
        new ObjectiveFactionDefeated(ZandalarSetup.Zandalar)));
      ResearchId = Constants.UPGRADE_R091_QUEST_COMPLETED_HORDE_OR_NIGHT_ELF_DEFEATED;
      Required = true;
    }

  }
}