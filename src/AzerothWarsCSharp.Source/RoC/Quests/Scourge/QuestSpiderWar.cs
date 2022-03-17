using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Scourge
{
  public class QuestSpiderWar{

  
    private const int QUEST_RESEARCH_ID = FourCC(R03A);
  


    private string operator CompletionPopup( ){
      return "Northrend && the Icecrown Citadel is now under full control of the Lich King && the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Access to the Plague Research at the Frozen Throne, KelFourCC(tuzad && Rivendare trainable && a base in Icecrown";
    }

    private void OnFail( ){
      RescueNeutralUnitsInRect(gg_rct_Ice_Crown, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      RescueNeutralUnitsInRect(gg_rct_Ice_Crown, this.Holder.Player);
      SetPlayerTechResearched(Holder.Player, FourCC(R03A), 1);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\ScourgeTheme.mp3" );
      }
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("War of the Spider", "The proud Nerubians have declared war on the newly formed Lich King, destroy them to secure the continent of Northrend.", "ReplaceableTextures\\CommandButtons\\BTNNerubianQueen.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n00I))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n08D))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n00G))));
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_n074_1565)) ;//Nezar)azret
      this.AddQuestItem(QuestItemUpgrade.create(FourCC(unp2), )unpl)));
      this.AddQuestItem(QuestItemExpire.create(1480));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
