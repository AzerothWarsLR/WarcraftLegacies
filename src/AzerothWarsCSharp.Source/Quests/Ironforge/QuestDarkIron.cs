using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestDarkIron : QuestData{

  
    private static readonly int HeroId = FourCC("H03G");
    private static readonly int ResearchId = FourCC("R01A");
  


    protected override string CompletionPopup => "The peace talk were succesful, The Dark Iron will join the Dwarven Empire.";

    protected override string CompletionDescription => "You gain control of Shadowforge City && can train the hero Dagran Thaurassian from the Altar of Fortitude";

    protected override void OnComplete(){
      group tempGroup = CreateGroup();
      unit u;
      //Transfer all Neutral Passive units in region to Ironforge
      GroupEnumUnitsInRect(tempGroup, Regions.ShadowforgeCity.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, Holder.Player);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(ResearchId, UNLIMITED);
      Holder.ModObjectLimit(HeroId, 1);
    }

    public  QuestDarkIron ( ){
      thistype this = thistype.allocate("Dark Iron Alliance", "The Dark Iron dwarves are renegades. Bring Magni to their capital to open negotiations for an alliance.", "ReplaceableTextures\\CommandButtons\\BTNRPGDarkIron.blp");
      AddQuestItem(new QuestItemLegendInRect(LEGEND_MAGNI, Regions.ShadowforgeGate.Rect, "Shadowforge"));
      ;;
    }


  }
}
