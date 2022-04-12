using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using WCSharp.Shared.Data;
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
      AddQuestItem(new QuestItemEitherOf(new QuestItemKillUnit(acolyte),
        new QuestItemAnyUnitInRect(new Rectangle(-813, -183, -460, 183), "that square to the left", false)));
      AddQuestItem(new QuestItemResearch(FourCC("Rhde"), FourCC("Hbar")));
      AddQuestItem(new QuestItemTrain(FourCC("hfoo"), FourCC("Hbar"), 3));
    }

    protected override string RewardDescription => "Just the greatest things.";
    protected override string CompletionPopup => "Wow! Good job!";
  }
}