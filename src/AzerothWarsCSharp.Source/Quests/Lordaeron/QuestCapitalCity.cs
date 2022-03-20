using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public class QuestCapitalCity{

  
    private const int RESEARCH_ID = FourCC(R04Y)   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => 
      return "Capital City has been liberated, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Control of all units in Capital City";
    }

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_Terenas, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_Terenas, this.Holder.Player);
      SetUnitInvulnerable(gg_unit_nemi_0019, true);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ("war3mapImported\\CapitalCity.mp3");
      }
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Hearthlands", "The territories of Lordaeron are fragmented. Regain control of the old AllianceFourCC(s hold to secure the kingdom.", "ReplaceableTextures\\CommandButtons\\BTNCastle.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_CAERDARROW, false));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n01M))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n01C))));
      this.AddQuestItem(QuestItemExpire.create(1472));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = RESEARCH_ID;
      ;;
    }


  }
}
