using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public class QuestReanimateSylvanas{

  
    private const int SYLVANAS_ID = FourCC("Usyl");
    private const int ALTAR_ID = FourCC("uaod");
  


    protected override string CompletionPopup => 
      return "QuelFourCC("thalas has fallen to the Scourge")s onslaught. The Sunwell itself has been corrupted, cutting the quel)dorei off from the source of their longevity. Sylvanas is denied a clean death following her tenacious defense, && she becomes the first of the High Elven Banshees.";
    }

    protected override string CompletionDescription => 
      return "You can summon Sylvanas from the " + GetObjectName(ALTAR_ID);
    }

    protected override void OnComplete(){
      SetUnitAnimation(LEGEND_SUNWELL.Unit, "stand second");
      SetUnitAnimation(LEGEND_SUNWELL.Unit, "stand third");
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The First Banshee", "Sylvanas, the Ranger-General of Silvermoon, stands between the legions of the Scourge && the Sunwell. Destroy her people, && her soul will be transformed into a tormented Banshee under the ScourgeFourCC("s control.", "ReplaceableTextures\\CommandButtons\\BTNBansheeRanger.blp"");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_SUNWELL, false));
      this.ResearchId = FourCC("R02D");
      ;;
    }


  }
}
