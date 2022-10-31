using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Forsaken
{
  public sealed class QuestScholomanceBuild : QuestData
  {
    public QuestScholomanceBuild() : base("Secret Buildup",
      "The Scholomance is the secret staging ground for the invasion of Lordaeron, build your infrastructure and be ready for war.",
      "ReplaceableTextures\\CommandButtons\\BTNAffinityII.blp")
    {
      AddObjective(new ObjectiveBuild(FourCC("u011"), 2));
      AddObjective(new ObjectiveBuild(FourCC("h08C"), 20));
      AddObjective(new ObjectiveBuild(FourCC("u014"), 1));
      AddObjective(new ObjectiveBuild(FourCC("u01J"), 2));
      AddObjective(new ObjectiveUpgrade(FourCC("h08B"), FourCC("h089")));
      ResearchId = FourCC("R04Z");
      Required = true;
    }

    //Todo: bad flavour
    protected override string CompletionPopup => "Putress is now trainable.";

    protected override string RewardDescription => "Putress is trainable at the altar";
  }
}