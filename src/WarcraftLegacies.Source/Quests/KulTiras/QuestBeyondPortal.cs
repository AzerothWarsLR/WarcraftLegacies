using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  public sealed class QuestBeyondPortal : QuestData
  {
    public QuestBeyondPortal() : base("Beyond the Dark Portal",
      "The Orc threat from Draenor still looms over all. Eliminate every trace of the Orcs and their bases.",
      "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendFelHorde.LegendBlacktemple, false));
      AddObjective(new ObjectiveLegendDead(LegendFelHorde.LegendHellfirecitadel));
      AddObjective(new ObjectiveLegendDead(LegendFelHorde.LegendBlackrockspire));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R085");
    }
    
    protected override string CompletionPopup => "The orcs are no more and we can now train Fusillier.";

    protected override string RewardDescription => "You will be able to train Fusillier from the Barrack";
  }
}