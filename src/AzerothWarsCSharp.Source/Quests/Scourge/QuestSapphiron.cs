using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestSapphiron : QuestData{

  
    private static readonly int SapphironId = FourCC("ubdd");
    private static readonly int SapphironResearch = FourCC("R025");
  


    protected override string CompletionPopup => "Sapphiron has been slain, && has been reanimated as a mighty Frost Wyrm under the command of the Scourge.";

    protected override string CompletionDescription => "The demihero Sapphiron";

    protected override void OnComplete(){
      CreateUnit(Holder.Player, SapphironId, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), GetUnitFacing(GetTriggerUnit()));
      SetPlayerTechResearched(Holder.Player, SapphironResearch, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(SapphironResearch, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Sapphiron", "Kill Sapphiron the Blue Dragon to have KelFourCC("Tuzad reanimate her as a Frost Wyrm. Sapphiron can be found in Northrend.", "ReplaceableTextures\\CommandButtons\\BTNFrostWyrm.blp"");
      AddQuestItem(new QuestItemKillUnit(gg_unit_ubdr_0668));
      AddQuestItem(new QuestItemControlLegend(LEGEND_KELTHUZAD, false));
      ;;
    }


  }
}
