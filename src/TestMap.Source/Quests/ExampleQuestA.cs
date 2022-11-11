using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using TestMap.Source.Setup;
using WCSharp.Shared.Data;

namespace TestMap.Source.Quests
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