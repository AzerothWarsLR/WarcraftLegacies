using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestDalaran : QuestData{

  
    private static readonly int QuestResearchId = FourCC("R038");
  


    protected override string CompletionPopup => "Dalaran outskirs are now secure, the mages will join " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Dalaran && enables Antonidas to be trained at the Altar";

    private void GrantDalaran(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Dalaran
      GroupEnumUnitsInRect(tempGroup, Regions.Dalaran.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      GroupEnumUnitsInRect(tempGroup, Regions.DalaranDungeon.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    protected override void OnFail( ){
      GrantDalaran(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, FourCC("R038"), 1);
      GrantDalaran(Holder.Player);
      if (GetLocalPlayer() == Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\DalaranTheme.mp3" );
      }
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(QuestResearchId, 1);
    }

    public  QuestDalaran ( ){
      thistype this = thistype.allocate("Outskirts", "The territories of Dalaran are fragmented, secure the lands && protect Dalaran citizens .", "ReplaceableTextures\\CommandButtons\\BTNArcaneCastle.blp");
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01D"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n08M"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n018"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01I"))));
      this.AddQuestItem(new QuestItemUpgrade(FourCC("h068"), )h065)));
      AddQuestItem(new QuestItemExpire(1445));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
