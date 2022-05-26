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
      AddObjective(new ObjectiveChannelRect(new Rectangle(-813, -183, -460, 183), "over here", LegendSetup.Kael, 7, 180));
    }

    protected override string RewardDescription => "Just the greatest things.";
    protected override string CompletionPopup => "Wow! Good job!";
  }
}