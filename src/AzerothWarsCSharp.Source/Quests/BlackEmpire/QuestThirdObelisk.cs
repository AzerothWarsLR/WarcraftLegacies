using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Mechanics.BlackEmpire;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public sealed class QuestThirdObelisk : QuestData : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R07K")   ;//This research is given when the quest is completed
  


    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "The Merging of Realities has come to pass. The NyaFourCC(lothan portals to Storm Peaks, Northern Highlands, && Tanaris have been permanently opened.";
    }

    protected override string CompletionDescription => 
      return "The NyaFourCC(lothan portals to Storm Peaks, Northern Highlands, && Tanaris will be permanently opened";
    }

    //Opens the central portals in Nyalotha permanently.
    private void OpenPortals( ){
      this.Holder.ModObjectLimit(FourCC("u02E"), -UNLIMITED) ;//Herald
      this.Holder.SetObjectLevel(QUEST_RESEARCH_ID, 1);
      BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS.PortalState = BLACKEMPIREPORTALSTATE_OPEN;
      BLACKEMPIREPORTAL_TANARIS.PortalState = BLACKEMPIREPORTALSTATE_OPEN;
      BLACKEMPIREPORTAL_NORTHREND.PortalState = BLACKEMPIREPORTALSTATE_OPEN;




      RemoveUnit(Herald.Instance.unit);
      BlackEmpirePortal.GoToNext();
      if (GetLocalPlayer() == this.Holder.Player){
        SetCameraPosition(-25528, -1979);
      }
    }

    protected override void OnComplete(){
      PlayThematicMusicBJ("war3mapImported\\BlackEmpireTheme.mp3");
      OpenPortals();
    }

    private void OnFail( ){
      OpenPortals();
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Merging of Realities", "Reality frays at the seams as madness threatents to overtake it. Once an Obelisk has been established in the Twilight Highlands, the mirror worlds of Azeroth && NyFourCC("alotha will finally be one, && the Black Empire will be unleashed.", "ReplaceableTextures\\CommandButtons\\BTNHorrorSoul.blp"");
      this.AddQuestItem(new QuestItemObelisk(ControlPoint.GetFromUnitType(FourCC("n02S"))));
      this.AddQuestItem(new QuestItemObelisk(ControlPoint.GetFromUnitType(FourCC("n04V"))));
      this.AddQuestItem(new QuestItemObelisk(ControlPoint.GetFromUnitType(FourCC("n0BD"))));
      this.AddQuestItem(new QuestItemExpire(1800));
      ;;
    }


  }
}
