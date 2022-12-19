using MacroTools.ControlPointSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  public sealed class QuestBrokenOne : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R083"); //This research is given when the quest is completed

    public QuestBrokenOne() : base("The Broken One",
      "The great shaman Nobundo is fighting to enable Velen and most of the Draenei to escape. If the Draenei hold out long enough, he might have time to join the survivors aboard the Exodar",
      "ReplaceableTextures\\CommandButtons\\BTNAkamanew.blp")
    {
      AddObjective(new ObjectiveTime(660));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N02O_NETHERSTORM_10GOLD_MIN)));
      ResearchId = QuestResearchId;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "The hero Nobundo is now trainable at the Altar";

    /// <inheritdoc />
    protected override string RewardDescription => "Nobundo will join the survivors on the Exodar";
  }
}