using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <inheritdoc/>
  public sealed class QuestInterdimensionalPortal : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestInterdimensionalPortal"/> class.
    /// </summary>
    public QuestInterdimensionalPortal(Rectangle questRect) : base("The Interdimensional Gateway",
      "The Interdimensional Gateway will be useless unless it is first powered by the Maelstrom itself", "ReplaceableTextures\\CommandButtons\\BTNAltar of Starlight1.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "at the Maelstrom", Constants.UNIT_O05U_LIGHTFORGED_GATEWAY_DRAENEI_SPECIALIST));
      ResearchId = Constants.UPGRADE_R04H_QUEST_COMPLETED_THE_INTERDIMENSIONAL_GATEWAY;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Interdimensional Gateway has been constructed and has made contact with the Lightforged thanks to the power of the Maelstrom";

    /// <inheritdoc/>
    protected override string RewardDescription => $"Can now summon A'dal and train Lightforged units from the Interdimensional Portals";
  }
}