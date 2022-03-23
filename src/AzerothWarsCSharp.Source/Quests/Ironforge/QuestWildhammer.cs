using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestWildhammer : QuestData{

  
    private const int HERO_ID = FourCC("H028");
    private const int RESEARCH_ID = FourCC("R01C");
  


    protected override string CompletionPopup => "Magni has spoken with Falstad Wildhammer && secured an alliance with the Wildhammer Clan.";

    protected override string CompletionDescription => "You gain control of Aerie Peak && you can train the hero Falstad Wildhammer from the Altar of Fortitude";

    protected override void OnComplete(){
      group tempGroup = CreateGroup();
      unit u;







      //Transfer all Neutral Passive units in region to Ironforge
      GroupEnumUnitsInRect(tempGroup, Regions.Aerie_Peak.Rect, null);

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
      this.AddQuestItem(new QuestItemLegendInRect(LEGEND_MAGNI, Regions.Aerie_Peak.Rect, "Aerie Peak"));
      ;;
    }


  }
}
