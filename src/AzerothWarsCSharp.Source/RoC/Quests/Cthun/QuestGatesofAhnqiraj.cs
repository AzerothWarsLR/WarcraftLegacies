using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Cthun
{
  public sealed class QuestGatesofAhnqiraj : QuestData
  {
    protected override string CompletionPopup => "The Old God C'thun has awaken && is now ready to unleash the Qiraji on the world of Azeorth.";
    
    protected override string CompletionDescription => "Gain control of C'thun && enable you to open the Gates of Ahn'qiraj";
      
    protected override void OnComplete()
    {
      WaygateActivate(gg_unit_h03V_3441, true);
      ShowUnitShow(gg_unit_h03V_3441);
      WaygateSetDestinationLocBJ(gg_unit_h03V_3441, GetRectCenter(gg_rct_WorldTunnelEntrance));
      WaygateActivateBJ(gg_unit_h03V_3449, true);
      ShowUnitShow(gg_unit_h03V_3449);
      WaygateSetDestinationLocBJ(gg_unit_h03V_3449, GetRectCenter(gg_rct_WorldTunnelExit));
      SetUnitInvulnerable(gg_unit_h02U_2413, false);
      PlayThematicMusicBJ("war3mapImported\\CthunTheme.mp3");
    }
      
    public QuestGatesofAhnqiraj() : base("The Gates of Ahn'qiraj",
      "At the conclusion of the War of the Shifting Sands, the Dragonflights sealed the Qiraji behind the Scarab Wall. Now centuries later, C'thun is once again ready to open the gates to his ancient empire.",
      "ReplaceableTextures\\CommandButtons\\BTNScarabMedal.blp")
    {
      Global = true;
      this.AddQuestItem(new QuestItemCastSpell(FourCC("A0O1"), true));
    }
  }
}