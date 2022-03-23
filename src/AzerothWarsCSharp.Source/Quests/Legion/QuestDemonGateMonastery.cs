using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestDemonGateMonastery : QuestData{

  
    private static readonly int DemongateId = FourCC("n081");
  


    private QuestItemKillUnit _questItemKillMonastery;

    protected override string CompletionPopup => "The great Scarlet Monastery has fallen, && from its ashes rises an even greater Demon Gate.";

    protected override string CompletionDescription => "A new Demon Gate at the MonasteryFourCC(s location";

    protected override void OnComplete(){
      CreateUnit(Holder.Player, DemongateId, GetUnitX(_questItemKillMonastery.Target), GetUnitY(_questItemKillMonastery.Target), 270);
      SetDoodadAnimationRectBJ( "hide", FourCC("YObb"), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "hide", FourCC("ZSab"), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "hide", FourCC("YOsw"), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "show", FourCC("LOsm"), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "hide", FourCC("YOlp"), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "hide", FourCC("ZCv2"), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "hide", FourCC("ZCv1"), gg_rct_ScarletMonastery );
      SetDoodadAnimationRectBJ( "show", FourCC("ZCv1"), gg_rct_ScarletMonastery );
    }

    public  thistype ( ){
      thistype this = thistype.allocate("A Scarlet Rift", "The energies surrounding the Scarlet Monastery are extraordinary. Destroy this bastion of light to fabricate a Demon Gate in its place.", "ReplaceableTextures\\CommandButtons\\BTNMaskOfDeath.blp");
      _questItemKillMonastery = AddQuestItem(new QuestItemKillUnit(gg_unit_h00T_0786));
      
    }


  }
}
