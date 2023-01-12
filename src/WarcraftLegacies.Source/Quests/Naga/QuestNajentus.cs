using MacroTools.ControlPointSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Naga
{
  
  /// <summary>
  /// Capture control points in Nazjatar to unlock a hero
  /// </summary>
  public sealed class QuestNajentus : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestNajentus"/> class.
    /// </summary>
    public QuestNajentus() : base("Lord of the Depths",
      "The sea floor is wild and unconquered, if Illidan captures it, the Naga Lord Naj'entus will join us",
      "ReplaceableTextures\\CommandButtons\\BTNLordNaj.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N04B_GISHAN_CAVERNS_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N02P_MAK_ARA_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N00P_THE_ABYSS_25GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N028_DROWNED_REACHES_10GOLD_MIN)));
      ResearchId = Constants.UPGRADE_R08W_QUEST_COMPLETED_LORD_OF_THE_DEPTHS;
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "Now that the sea floor is under Illidan's control, Lady Vashj's champion Lord Naj'entus has joined Illidan's forces.";

    /// <inheritdoc/>
    protected override string RewardDescription => $" Naj'entus can be trained from the {GetObjectName(Constants.UNIT_NNAD_ALTAR_OF_THE_BETRAYER_ILLIDARI_ALTAR)}";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
    }

    /// <inheritdoc/>
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}