using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public sealed class QuestYoggSaron : QuestData
  {
    public QuestYoggSaron() : base("Fiend of a Thousand Faces",
      "Yogg-Saron was imprisoned beneath Northrend by the Titans countless millenia ago. ",
      "ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n053"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00I"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n02S"))));
      ResearchId = FourCC("R07R");
    }

    protected override string RewardDescription =>
      "The old god Yogg-Saron will join the Black Empire and enable to train Forgotten ones.";


    protected override string CompletionPopup => "Yogg-saron has been awoken.";

    protected override void OnComplete(Faction completingFaction)
    {
      LegendBlackEmpire.legendYogg.Unit.Rescue(completingFaction.Player);
    }
  }
}