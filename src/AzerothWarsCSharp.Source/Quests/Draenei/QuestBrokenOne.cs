using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public sealed class QuestBrokenOne : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R083"); //This research is given when the quest is completed

    public QuestBrokenOne() : base("The Broken One",
      "The great shaman Nobundo is fighting to enable Velen and most of the Draenei to escape. If the Draenei hold out long enough, he might have time to join the survivors aboard the Exodar",
      "ReplaceableTextures\\CommandButtons\\BTNAkamanew.blp")
    {
      AddQuestItem(new QuestItemTime(720));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n02O"))));
      ResearchId = QuestResearchId;
    }

    protected override string CompletionPopup => "The hero Nobundo is now trainable at the Altar";

    protected override string RewardDescription => "Nobundo will join the survivors on the Exodar";
  }
}