using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestCapitalCity : QuestData{

  
    private const int RESEARCH_ID = FourCC("R04Y")   ;//This research is given when the quest is completed
  


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
      thistype this = thistype.allocate("Hearthlands", "The territories of Lordaeron are fragmented. Regain control of the old AllianceFourCC("s hold to secure the kingdom.", "ReplaceableTextures\\CommandButtons\\BTNCastle.blp"");
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_CAERDARROW, false));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01M"))));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01C"))));
      this.AddQuestItem(new QuestItemExpire(1472));
      this.AddQuestItem(new QuestItemSelfExists());
      this.ResearchId = RESEARCH_ID;
      ;;
    }


  }
}
