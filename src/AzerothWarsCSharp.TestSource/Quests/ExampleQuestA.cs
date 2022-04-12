using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Quests
{
  public sealed class ExampleQuestA : QuestData
  {
    public ExampleQuestA() : base("Example Quest", "You have to do something fun.",
      "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp")
    {
      var acolyte = CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE), FourCC("uaco"), 0, 0, 0);
      CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE), FourCC("uaco"), 0, 0, 0);
      CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE), FourCC("uaco"), 0, 0, 0);
      CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE), FourCC("uaco"), 0, 0, 0);
      CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE), FourCC("uaco"), 0, 0, 0);
      AddQuestItem(new QuestItemKillUnit(acolyte));
      AddQuestItem(new QuestItemKillXUnit(FourCC("uaco"), 3));
      AddQuestItem(new QuestItemTime(7));
      AddQuestItem(new QuestItemCastSpell(FourCC("AHfs"), false));
    }

    protected override string RewardDescription => "Just the greatest things.";
    protected override string CompletionPopup => "Wow! Good job!";
  }
}