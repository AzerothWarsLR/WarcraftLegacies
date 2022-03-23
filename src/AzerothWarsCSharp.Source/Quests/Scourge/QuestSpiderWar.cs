using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestSpiderWar : QuestData{

  
    private static readonly int QuestResearchId = FourCC("R03A");
  


    protected override string CompletionPopup => "Northrend && the Icecrown Citadel is now under full control of the Lich King && the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Access to the Plague Research at the Frozen Throne, KelFourCC(tuzad && Rivendare trainable && a base in Icecrown";

    protected override void OnFail( ){
      RescueNeutralUnitsInRect(Regions.IceCrown.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(Regions.IceCrown.Rect, Holder.Player);
      SetPlayerTechResearched(Holder.Player, FourCC("R03A"), 1);
      if (GetLocalPlayer() == Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\ScourgeTheme.mp3" );
      }
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(QuestResearchId, 1);
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
      
    }


  }
}
