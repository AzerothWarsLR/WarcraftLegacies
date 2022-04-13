using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestTakeRevenge : QuestData
  {
    public QuestTakeRevenge() : base("Cold-Hearted Revenge",
      "Sylvanas longs to take revenge on the Lich King. Killing him and absorbing his power would maybe satisfy the emptiness inside her",
      "ReplaceableTextures\\CommandButtons\\BTNHelmofdomination.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0BC"))));
      AddQuestItem(new QuestItemControlLegend(LegendForsaken.LegendSylvanasv, true));
      AddQuestItem(new QuestItemLegendDead(LegendScourge.LegendLichking));
    }
    
    protected override string CompletionPopup =>
      "With the Lich King eliminated, Sylvanas vengeance is finally complete. She has absorbed his power and has become the Banshee Queen";

    protected override string RewardDescription => "Sylvanas gains 20 intelligence, 20 strength and Chaos damage";

    protected override void OnComplete()
    {
      unit whichUnit = LegendForsaken.LegendSylvanasv.Unit;
      BlzSetUnitName(whichUnit, "Banshee Queen");
      AddSpecialEffectTarget("war3mapImported\\SoulArmor.mdx", whichUnit, "chest");
      BlzSetUnitWeaponIntegerField(whichUnit, UNIT_WEAPON_IF_ATTACK_ATTACK_TYPE, 0, 5); //Chaos
      AddHeroAttributes(whichUnit, 20, 0, 20);
      LegendForsaken.LegendSylvanasv.ClearUnitDependencies();
    }
  }
}