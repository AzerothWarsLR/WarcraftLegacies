using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Forsaken
{
  public sealed class QuestTakeRevenge : QuestData
  {
    public QuestTakeRevenge() : base("Cold-Hearted Revenge",
      "Sylvanas longs to take revenge on the Lich King. Killing him and absorbing his power would maybe satisfy the emptiness inside her",
      "ReplaceableTextures\\CommandButtons\\BTNHelmofdomination.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n0BC"))));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendForsaken.SylvanasUndead));
      AddObjective(new ObjectiveLegendDead(LegendScourge.LegendLichking));
    }

    protected override string CompletionPopup =>
      "With the Lich King eliminated, Sylvanas vengeance is finally complete. She has absorbed his power and has become the Banshee Queen";

    protected override string RewardDescription => "Sylvanas gains 20 intelligence, 20 strength and Chaos damage";

    protected override void OnComplete(Faction completingFaction)
    {
      var whichUnit = LegendForsaken.SylvanasUndead.Unit;
      BlzSetUnitName(whichUnit, "Banshee Queen");
      AddSpecialEffectTarget("war3mapImported\\SoulArmor.mdx", whichUnit, "chest");
      BlzSetUnitWeaponIntegerField(whichUnit, UNIT_WEAPON_IF_ATTACK_ATTACK_TYPE, 0, 5); //Chaos
      whichUnit.AddHeroAttributes(20, 0, 20);
      LegendForsaken.SylvanasUndead.ClearUnitDependencies();
    }
  }
}