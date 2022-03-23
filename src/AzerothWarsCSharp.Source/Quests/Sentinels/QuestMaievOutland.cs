using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestMaievOutland : QuestData
  {
    protected override string CompletionPopup =>
  }

  protected override string CompletionDescription =>
  "Control of MaievFourCC(s Outland outpost && moves Maiev to Outland";

  protected override void OnComplete(){
  internal SetUnitPosition(LEGEND_MAIEV.Unit, -5252, -27597);
  internal UnitRemoveAbilityBJ(FourCC("A0J5"), LEGEND_MAIEV.Unit);
  GeneralHelpers.RescueUnitsInGroup(udg_MaievUnlockOutland, this.Holder.Player);
  }

  public QuestMaievOutland ( ) : base("Driven by Vengeance",
  "Maiev drive for vengeance leads her to chase Illidan all the way to other worlds.",
  "ReplaceableTextures\\CommandButtons\\BTNMaievArmor.blp"){
  this.
  internal AddQuestItem(
  internal new QuestItemCastSpell(FourCC("A0J5"), true));
  this.
  internal AddQuestItem(

  internal new QuestItemControlLegend(LEGEND_MAIEV, true));
    ;;
  }
}

}