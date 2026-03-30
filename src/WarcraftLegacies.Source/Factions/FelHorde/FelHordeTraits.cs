using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Factions.FelHorde;

public static class FelHordeTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new SummonUnitOnDeath
    {
      Duration = 40,
      SummonUnitTypeId = UNIT_N00O_SKELETAL_GRUNT_FEL,
      SummonCount = 1,
      SpecialEffectPath = @"Abilities\Spells\Undead\RaiseSkeletonWarrior\RaiseSkeleton.mdl",
      RequiredResearch = UPGRADE_R098_FEL_INFUSED_SKELETON_FEL_HORDE
    }, UNIT_NCHG_FEL_GRUNT_FEL);

    UnitTypeTraitRegistry.Register(new Execute
    {
      DamageMultNonResistant = 4,
      DamageMultResistant = 2
    }, UNIT_O01L_EXECUTIONER_FEL_ELITE);

    UnitTypeTraitRegistry.Register(new Execute
    {
      DamageMultNonResistant = 4,
      DamageMultResistant = 2
    }, UNIT_N0B4_REAPER_NZOTH);
  }
}
