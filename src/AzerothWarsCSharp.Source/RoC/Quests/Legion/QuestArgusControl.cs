using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Legion
{
  public class QuestArgusControl{

  
    private const int QUESTRESEARCH_ID = FourCC(R055)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "Enable to research Astral Walk && build a shop" ;//Todo: where is Astral Walk researched? What is the shop called?
    }

    private string operator CompletionDescription( ){
      return "Enable to research Astral Walk && build a shop";
    }

    private void OnComplete( ){
      UnitRescue(gg_unit_n0BE_3261, FACTION_LEGION.Player);
      UnitRescue(gg_unit_n0BE_3262, FACTION_LEGION.Player);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Argus Incursion", "The planet of Argus is !fully under the control of the Legion. Bring it under control!", "ReplaceableTextures\\CommandButtons\\BTNMastersLodge.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_h09U_3138)) ;//Knight
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n0BF))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n0BH))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n0BG))));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUESTRESEARCH_ID;
      ;;
    }


  }
}
