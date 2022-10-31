using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.Extensions;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public sealed class QuestTriumvirate : QuestData
  {
    public QuestTriumvirate() : base("Crown of the Triumvirate",
      "Eons ago, the council that led the Eredar was the Triumvirate. If Velen could reconquer Argus, he could reform the Crown of the Triumvirate",
      "ReplaceableTextures\\CommandButtons\\BTNNeverMeltingCrown.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0BH"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0BL"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n09X"))));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendDraenei.LegendVelen));
      Global = true;
    }

    protected override string CompletionPopup => "Velen has liberated Argus and re-assembled the Crown of Triumvirate";

    protected override string RewardDescription => "You gain the powerful item, the Crown of the Triumvirate";


    protected override void OnComplete(Faction completingFaction)
    {
      LegendDraenei.LegendVelen.Unit.AddItemSafe(ArtifactSetup.ArtifactCrowntriumvirate.Item);
    }
  }
}