using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestSpiderWar : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R03A");
  


    protected override string CompletionPopup => "Northrend && the Icecrown Citadel is now under full control of the Lich King && the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Access to the Plague Research at the Frozen Throne, KelFourCC(tuzad && Rivendare trainable && a base in Icecrown";

    private void OnFail( ){
      RescueNeutralUnitsInRect(Regions.Ice_Crown.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(Regions.Ice_Crown.Rect, Holder.Player);
      SetPlayerTechResearched(Holder.Player, FourCC("R03A"), 1);
      if (GetLocalPlayer() == Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\ScourgeTheme.mp3" );
      }
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("War of the Spider", "The proud Nerubians have declared war on the newly formed Lich King, destroy them to secure the continent of Northrend.", "ReplaceableTextures\\CommandButtons\\BTNNerubianQueen.blp");
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00I"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n08D"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00G"))));
      AddQuestItem(QuestItemKillUnit.create(gg_unit_n074_1565)) ;//Nezar)azret
      this.AddQuestItem(new QuestItemUpgrade(FourCC("unp2"), )unpl)));
      AddQuestItem(new QuestItemExpire(1480));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
