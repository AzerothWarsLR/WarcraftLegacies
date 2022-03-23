using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestCapitalCity : QuestData{

  
    private const int RESEARCH_ID = FourCC("R04Y")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "Capital City has been liberated, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Capital City";

    protected override void OnFail( ){
      RescueNeutralUnitsInRect(Regions.Terenas.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(Regions.Terenas.Rect, Holder.Player);
      SetUnitInvulnerable(gg_unit_nemi_0019, true);
      if (GetLocalPlayer() == Holder.Player){
        PlayThematicMusicBJ("war3mapImported\\CapitalCity.mp3");
      }
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, 1);
    }

    public  QuestCapitalCity ( ){
      thistype this = thistype.allocate("Hearthlands", "The territories of Lordaeron are fragmented. Regain control of the old AllianceFourCC("s hold to secure the kingdom.", "ReplaceableTextures\\CommandButtons\\BTNCastle.blp"");
      AddQuestItem(new QuestItemControlLegend(LEGEND_CAERDARROW, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01M"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01C"))));
      AddQuestItem(new QuestItemExpire(1472));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = RESEARCH_ID;
      
    }


  }
}
