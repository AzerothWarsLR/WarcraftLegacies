using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;

namespace WarcraftLegacies.Source.Quests.Twilight
{
  public sealed class QuestSpreadTheWord : QuestData
  {
    public QuestSpreadTheWord() : base("Spread the Whispers of the Old God",
      "The world shall hear the whispers of the Old God. Spread the visions of the end",
      "ReplaceableTextures\\CommandButtons\\BTNOldGodWhispers.blp")
    {
      AddObjective(new ObjectiveBuild(Constants.UNIT_O03C_ALTAR_OF_VISIONS_TWILIGHT, 1));
      AddObjective(new ObjectiveTrain(Constants.UNIT_OBOT_HORDE_TRANSPORT_SHIP_WARSONG_FROSTWOLF_FEL_HORDE,
        Constants.UNIT_O03I_TWILIGHT_DOCK_TWILIGHT, 3));
      ResearchId = Constants.UPGRADE_R05F_QUEST_COMPLETED_SPREAD_THE_WORDS_OF_THE_OLD_GOD;
      Required = true;
    }

    protected override string CompletionPopup => "The high priestess Azil is now trainable";

    protected override string RewardDescription => "The high priestess Azil is trainable at the altar";
  }
}