using AzerothWarsCSharp.MacroTools.Factions;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public sealed class QuestTriumvirate : QuestData
  {
    public QuestTriumvirate() : base("Crown of the Triumvirate",
      "Eons ago, the council that led the Eredar was the Triumvirate. If Velen could reconquer Argus, he could reform the Crown of the Triumvirate",
      "ReplaceableTextures\\CommandButtons\\BTNNeverMeltingCrown.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0BH"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0BL"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n09X"))));
      AddQuestItem(new QuestItemLegendNotPermanentlyDead(LegendDraenei.LegendVelen));
      Global = true;
    }

    protected override string CompletionPopup => "Velen has liberated Argus && re-assembled the Crown of Triumvirate";

    protected override string RewardDescription => "You gain the powerful item, the Crown of the Triumvirate";
    

    protected override void OnComplete()
    {
      UnitAddItemSafe(LegendDraenei.LegendVelen.Unit, ArtifactSetup.ArtifactCrowntriumvirate.Item);
    }
  }
}