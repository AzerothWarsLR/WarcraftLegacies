using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestLegionCaptureSunwell : QuestData{

  
    private const int RESEARCH_ID = FourCC("R054");
  


    protected override string CompletionPopup => "The Sunwell has been captured by the Scourge. It now writhes with necromantic energy.";

    protected override string CompletionDescription => "A research improving your Dreadlords";

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayResearchAcquired(Holder.Player, RESEARCH_ID, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Fall of Silvermoon", "The Sunwell is the source of the High ElvesFourCC(" immortality && magical prowess. Under control of the Scourge, it would be the source of immense necromantic power.", "ReplaceableTextures\\CommandButtons\\BTNOrbOfCorruption.blp"");
      AddQuestItem(new QuestItemControlLegend(LEGEND_SUNWELL, false));
      ;;
    }


  }
}
