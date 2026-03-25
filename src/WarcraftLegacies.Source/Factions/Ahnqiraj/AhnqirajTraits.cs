using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Ahnqiraj.UnitTraits.DefensiveCocoon;
using WarcraftLegacies.Source.Factions.Ahnqiraj.UnitTraits.Incubate;
using WarcraftLegacies.Source.Factions.Ahnqiraj.UnitTraits.SpellConduction;
using WarcraftLegacies.Source.Shared.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits.MassiveAttack;

namespace WarcraftLegacies.Source.Factions.Ahnqiraj;

public static class AhnqirajTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new DefensiveCocoonTrait(ABILITY_ZBEG_DEFENSIVE_COCOON_AHN_QIRAJ)
    {
      MaximumHealthPercentage = 0.5f,
      Duration = 45,
      EggId = UNIT_ZBBG_COCOON_CTHUN_DEFENSIVE_COCOON,
      ReviveEffect = @"Abilities\Spells\Undead\RaiseSkeletonWarrior\RaiseSkeleton.mdl",
      RequiredResearch = UPGRADE_ZBEH_DEFENSIVE_COCOOON_AHN_QIRAJ
    }, new int[]
    {
      UNIT_U02S_ANCIENT_SAND_WORM,
      UNIT_E005_THE_PROPHET,
      UNIT_U00Z_OBSIDIAN_DESTROYER
    });

    UnitTypeTraitRegistry.Register(new Incubate(ABILITY_ZBRD_INCUBATE_VILE_CORRUPTOR)
    {
      HatchedUnitTypeId = UNIT_N06I_SOLDIER_CTHUN_SILITHID_WARRIOR,
      MaturationDuration = new LeveledAbilityField<float>
      {
        Base = 315f,
        PerLevel = -135f
      }
    }, UNIT_H01N_VILE_CORRUPTER_CTHUN);

    UnitTypeTraitRegistry.Register(new SpellConductionTrait
    {
      RedirectionPercentage = 0.40f,
      RedirectableAttackTypes = new attacktype[]
      {
        attacktype.Normal,
        attacktype.Magic
      },
      RequiredResearch = UPGRADE_ZBML_SPELL_CONDUCTION_C_THUN,
      Radius = 500
    }, UNIT_SL2O_OBSIDIAN_ERADICATOR_CTHUN);

    UnitTypeTraitRegistry.Register(new HideousAppendages
    {
      TentacleUnitTypeId = UNIT_N073_TENTACLE_HIDEOUS_APPENDAGES_C_THUN,
      TentacleCount = 9,
      RadiusOffset = 520
    }, UNIT_U00R_OLD_GOD_CTHUN);

    UnitTypeTraitRegistry.Register(new InfiniteInfluence
    {
      Radius = 800
    }, UNIT_U00R_OLD_GOD_CTHUN);

    UnitTypeTraitRegistry.Register(new MassiveAttackAbility
    {
      AttackDamagePercentage = 1,
      Distance = 400,
      IgnoreAttackTarget = true
    }, UNIT_ZBTH_TENTACLE_SPAWN_TENTACLE_C_THUN);
  }
}
