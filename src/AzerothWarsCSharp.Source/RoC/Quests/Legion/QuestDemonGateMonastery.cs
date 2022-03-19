using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Legion
{
  public class QuestDemonGateMonastery{

  
    private const int DEMONGATE_ID = FourCC(n081);
  


    private QuestItemKillUnit questItemKillMonastery;

    protected override string CompletionPopup => 
      return "The great Scarlet Monastery has fallen, && from its ashes rises an even greater Demon Gate.";
    }

    protected override string CompletionDescription => 
      return "A new Demon Gate at the MonasteryFourCC(s location";
    }

    protected override void OnComplete(){
      CreateUnit(Holder.Player, DEMONGATE_ID, GetUnitX(questItemKillMonastery.Target), GetUnitY(questItemKillMonastery.Target), 270);
      SetDoodadAnimationRectBJ( "hide", FourCC(YObb), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "hide", FourCC(ZSab), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "hide", FourCC(YOsw), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "show", FourCC(LOsm), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "hide", FourCC(YOlp), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "hide", FourCC(ZCv2), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "hide", FourCC(ZCv1), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "show", FourCC(ZCv1), gg_rct_ScarletMonastery );
    }

    public  thistype ( ){
      thistype this = thistype.allocate("A Scarlet Rift", "The energies surrounding the Scarlet Monastery are extraordinary. Destroy this bastion of light to fabricate a Demon Gate in its place.", "ReplaceableTextures\\CommandButtons\\BTNMaskOfDeath.blp");
      questItemKillMonastery = this.AddQuestItem(QuestItemKillUnit.create(gg_unit_h00T_0786));
      ;;
    }


  }
}
