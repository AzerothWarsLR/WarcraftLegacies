public class QuestDemonGateMonastery{

  
    private const int DEMONGATE_ID = FourCC(n081);
  


    private QuestItemKillUnit questItemKillMonastery;

    private string operator CompletionPopup( ){
      return "The great Scarlet Monastery has fallen, && from its ashes rises an even greater Demon Gate.";
    }

    private string operator CompletionDescription( ){
      return "A new Demon Gate at the MonasteryFourCC(s location";
    }

    private void OnComplete( ){
      CreateUnit(Holder.Player, DEMONGATE_ID, GetUnitX(this.questItemKillMonastery.Target), GetUnitY(this.questItemKillMonastery.Target), 270);
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
      this.questItemKillMonastery = this.AddQuestItem(QuestItemKillUnit.create(gg_unit_h00T_0786));
      ;;
    }


}
