using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestTheramore : QuestData{

  
    private static readonly int ResearchId = FourCC("R06K");
  


    private static group _theramoreUnits = CreateGroup();

    protected override string CompletionPopup => "A sizeable isle off the coast of Dustwallow Marsh has been colonized && dubbed Theramore, marking the first human settlement to be established on Kalimdor.";

    protected override string CompletionDescription => "Control of all units at Theramore";

    private static void GrantToPlayer(player whichPlayer ){
      unit u;
      while(true){
        u = FirstOfGroup(_theramoreUnits);
        if ( u == null){ break; }
        UnitRescue(u, whichPlayer);
        GroupRemoveUnit(_theramoreUnits, u);
      }
      DestroyGroup(_theramoreUnits);
      u = null;
      _theramoreUnits = null;
    }

    private void OnFail( ){
      thistype.GrantToPlayer(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      Holder.ModObjectLimit(ResearchId, -UNLIMITED);
    }

    protected override void OnComplete(){
      thistype.GrantToPlayer(Holder.Player);
      Holder.ModObjectLimit(ResearchId, -UNLIMITED);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(ResearchId, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Theramore", "The distant lands of Kalimdor remain untouched by human civilization. If the Third War proceeds poorly, it may become necessary to establish a forward base there.", "ReplaceableTextures\\CommandButtons\\BTNHumanArcaneTower.blp");
      AddQuestItem(new QuestItemResearch(ResearchId, FourCC("h076")));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }

    private static void OnInit( ){
      group tempGroup;
      unit u;
      tempGroup = CreateGroup();
      _theramoreUnits = CreateGroup();
      GroupEnumUnitsInRect(tempGroup, Regions.Theramore.Rect, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        SetUnitInvulnerable(u, true);
        SetUnitOwner(u, Player(PLAYER_NEUTRAL_PASSIVE), true);
        GroupAddUnit(_theramoreUnits, u);
        GroupRemoveUnit(tempGroup, u);
      }
      DestroyGroup(tempGroup);
    }


  }
}
