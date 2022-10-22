using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public sealed class QuestSurvivorsShattrah : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R082"); //This research is given when the quest is completed

    public QuestSurvivorsShattrah() : base("The Survivors of Shattrah",
      "The Shattrah massacre was swift and brutal, if (the Draenei hold long enough in Outland, they might regroup with some of the survivors.",
      "ReplaceableTextures\\CommandButtons\\BTNGlazeroth.blp")
    {
      AddObjective(new ObjectiveTime(480));
      this.AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendDraenei.LegendExodarship));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = QuestResearchId;
    }


    protected override string CompletionPopup => "The hero Maraad is now trainable at the Altar";

    protected override string RewardDescription => "Maraad will join the survivors on the Exodar";
  }
}