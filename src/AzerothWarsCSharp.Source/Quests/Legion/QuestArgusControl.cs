using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestArgusControl : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R055"); //This research is given when the quest is completed


    protected override string CompletionPopup =>
    return
    "Enable to research Astral Walk && build a shop"; //Todo: where is Astral Walk researched? What is the shop called?
  }

  protected override string CompletionDescription => "Enable to research Astral Walk && build a shop";

  protected override void OnComplete(){
  GeneralHelpers.UnitRescue(gg_unit_n0BE_3261, FACTION_LEGION.Player);
  GeneralHelpers.UnitRescue(gg_unit_n0BE_3262, FACTION_LEGION.Player);
  }

  public QuestArgusControl ( ) : base("Argus Incursion",
  "The planet of Argus is !fully under the control of the Legion. Bring it under control!",
  "ReplaceableTextures\\CommandButtons\\BTNMastersLodge.blp"){
  this.

  internal AddQuestItem(QuestItemKillUnit.create(gg_unit_h09U_3138)); //Knight
    this.

  internal AddQuestItem(
  internal new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0BF"))));
  this.
  internal AddQuestItem(
  internal new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0BH"))));
  this.
  internal AddQuestItem(
  internal new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0BG"))));
  this.
  internal AddQuestItem(
  internal new QuestItemSelfExists());
  ResearchId = QuestResearchId;
  ;;
  }
}

}