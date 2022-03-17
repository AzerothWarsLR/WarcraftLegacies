using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.RoC.Mechanics.BlackEmpire;

namespace AzerothWarsCSharp.Source.RoC.Quests.BlackEmpire
{
  public class QuestThirdObelisk{

  
    private const int QUEST_RESEARCH_ID = FourCC(R07K)   ;//This research is given when the quest is completed
  


    boolean operator Global( ){
      return true;
    }

    private string operator CompletionPopup( ){
      return "The Merging of Realities has come to pass. The NyaFourCC(lothan portals to Storm Peaks, Northern Highlands, && Tanaris have been permanently opened.";
    }

    private string operator CompletionDescription( ){
      return "The NyaFourCC(lothan portals to Storm Peaks, Northern Highlands, && Tanaris will be permanently opened";
    }

    //Opens the central portals in Nyalotha permanently.
    private void OpenPortals( ){
      this.Holder.ModObjectLimit(FourCC(u02E), -UNLIMITED) ;//Herald
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

    private void OnComplete( ){
      PlayThematicMusicBJ("war3mapImported\\BlackEmpireTheme.mp3");
      this.OpenPortals();
    }

    private void OnFail( ){
      this.OpenPortals();
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Merging of Realities", "Reality frays at the seams as madness threatents to overtake it. Once an Obelisk has been established in the Twilight Highlands, the mirror worlds of Azeroth && NyFourCC(alotha will finally be one, && the Black Empire will be unleashed.", "ReplaceableTextures\\CommandButtons\\BTNHorrorSoul.blp");
      this.AddQuestItem(QuestItemObelisk.create(ControlPoint.ByUnitType(FourCC(n02S))));
      this.AddQuestItem(QuestItemObelisk.create(ControlPoint.ByUnitType(FourCC(n04V))));
      this.AddQuestItem(QuestItemObelisk.create(ControlPoint.ByUnitType(FourCC(n0BD))));
      this.AddQuestItem(QuestItemExpire.create(1800));
      ;;
    }


  }
}
