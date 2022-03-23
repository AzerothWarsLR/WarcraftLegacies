using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestFallenGuardian : QuestData{

  
    private const int RESEARCH_ID = FourCC("R04K");
    private const int MEDIVH_ID = FourCC("Haah");
  


    protected override string CompletionPopup => "Medivh's spirit has been cleansed of Sargeras' influence, allowing him to return to Azeroth for a time.";

    protected override string CompletionDescription => "You can summon Medivh from the Altar of Knowledge";

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
      Holder.ModObjectLimit(MEDIVH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Fallen Guardian", "Medivh's body was corrupted by Sargeras at conception. Now that he is dead, the secrets of the Tomb of Sargeras and Karazhan combined might allow the mages of Dalaran to cleanse his spirit.", "ReplaceableTextures\\CommandButtons\\BTNMedivh.blp");
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_KARAZHAN, false));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00J"))));
      this.ResearchId = FourCC("R04K");
      ;;
    }


  }
}
