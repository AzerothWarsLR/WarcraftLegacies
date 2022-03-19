using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Dalaran
{
  public class QuestFallenGuardian{

  
    private const int RESEARCH_ID = FourCC(R04K);
    private const int MEDIVH_ID = FourCC(Haah);
  


    protected override string CompletionPopup => 
      return "MedivhFourCC(s spirit has been cleansed of Sargeras) influence, allowing him to return to Azeroth for a time.";
    }

    protected override string CompletionDescription => 
      return "You can summon Medivh from the Altar of Knowledge";
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
      Holder.ModObjectLimit(MEDIVH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Fallen Guardian", "MedivhFourCC(s body was corrupted by Sargeras at conception. Now that he is dead, the secrets of the Tomb of Sargeras && Sargeras combined might allow the mages of Dalaran to cleanse his spirit.", "ReplaceableTextures\\CommandButtons\\BTNMedivh.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_KARAZHAN, false));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n00J))));
      this.ResearchId = FourCC(R04K);
      ;;
    }


  }
}
