using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public class QuestWildhammer{

  
    private const int HERO_ID = FourCC(H028);
    private const int RESEARCH_ID = FourCC(R01C);
  


    protected override string CompletionPopup => 
      return "Magni has spoken with Falstad Wildhammer && secured an alliance with the Wildhammer Clan.";
    }

    protected override string CompletionDescription => 
      return "You gain control of Aerie Peak && you can train the hero Falstad Wildhammer from the Altar of Fortitude";
    }

    protected override void OnComplete(){
      group tempGroup = CreateGroup();
      unit u;







      //Transfer all Neutral Passive units in region to Ironforge
      GroupEnumUnitsInRect(tempGroup, gg_rct_Aerie_Peak, null);

      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          GeneralHelpers.UnitRescue(u, this.Holder.Player);
        }
        GroupRemoveUnit(tempGroup, u);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
      SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
      Holder.ModObjectLimit(HERO_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Wildhammer Alliance", "The Wildhammer dwarves roam freely over the peaks of the Hinterlands. An audience with Magni himself might earn their cooperation.", "ReplaceableTextures\\CommandButtons\\BTNHeroGriffonWarrior.blp");
      this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_MAGNI, gg_rct_Aerie_Peak, "Aerie Peak"));
      ;;
    }


  }
}
