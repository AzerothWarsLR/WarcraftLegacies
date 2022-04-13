using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.TestSource.Setup;
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
      AddQuestItem(new QuestItemArtifactInRect(ArtifactSetup.Killmaim, new Rectangle(-813, -183, -460, 183), "over here"));
    }

    protected override string RewardDescription => "Just the greatest things.";
    protected override string CompletionPopup => "Wow! Good job!";
  }
}