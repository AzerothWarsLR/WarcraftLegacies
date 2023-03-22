using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Forsaken
{
  /// <summary>
  /// 
  /// </summary>
  public sealed class QuestTakeRevenge : QuestData
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="legendSetup"></param>
    public QuestTakeRevenge(AllLegendSetup legendSetup) : base("Cold-Hearted Revenge",
      "Sylvanas longs to take revenge on the Lich King. Killing him and absorbing his power would maybe satisfy the emptiness inside her",
      "ReplaceableTextures\\CommandButtons\\BTNHelmofdomination.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n0BC"))));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendForsaken.SylvanasUndead));
      AddObjective(new ObjectiveCapitalDead(legendSetup.Scourge.TheFrozenThrone));
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "With the Lich King eliminated, Sylvanas vengeance is finally complete. She has absorbed his power and has become the Banshee Queen";

    /// <inheritdoc />
    protected override string RewardDescription => "Sylvanas gains 20 intelligence, 20 strength and Chaos damage";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      var whichUnit = LegendForsaken.SylvanasUndead.Unit;
      if (whichUnit != null)
      {
        BlzSetUnitName(whichUnit, "Banshee Queen");
        AddSpecialEffectTarget("war3mapImported\\SoulArmor.mdx", whichUnit, "chest");
        BlzSetUnitWeaponIntegerField(whichUnit, UNIT_WEAPON_IF_ATTACK_ATTACK_TYPE, 0, 5); //Chaos
        whichUnit.AddHeroAttributes(20, 0, 20);
        LegendForsaken.SylvanasUndead.ClearUnitDependencies();
      }
    }
  }
}