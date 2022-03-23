using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestAshenvale : QuestData{

  
    private const int RESEARCH_ID = FourCC("R06R")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "Ashenvale is under control && Cenarius can now be awaken";

    protected override string CompletionDescription => "Control of all units in Ashenvale && make Cenarius trainable at the Altar";

    private void GrantAshenvale(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Ashenvale
      GroupEnumUnitsInRect(tempGroup, Regions.AshenvaleUnlock.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          GeneralHelpers.UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void OnFail( ){
      GrantAshenvale(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantAshenvale(this.Holder.Player);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\DruidTheme.mp3" );
      }
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Spirits of Ashenvale", "The forest needs healing. Regain control of it to summon itFourCC("s Guardian, the Demigod Cenarius", "ReplaceableTextures\\CommandButtons\\BTNKeeperC.blp"");
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_MALFURION, Regions.AshenvaleUnlock.Rect, "Ashenvale"));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n07C"))));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01Q"))));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n08U"))));
      this.AddQuestItem(new QuestItemUpgrade(FourCC("etoa"), )etol)));
      this.AddQuestItem(new QuestItemExpire(1440));
      this.AddQuestItem(new QuestItemSelfExists());
      this.ResearchId = RESEARCH_ID;
      ;;
    }


  }
}
