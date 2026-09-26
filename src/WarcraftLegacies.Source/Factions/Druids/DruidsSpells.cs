using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Druids.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Druids;

public static class DruidsSpells
{
  public static void Setup()
  {
    SpellRegistry.Register(new Devour(ABILITY_A0NP_DEVOUR_TORTOLLA)
    {
      PercentageOfMaxHealth = 0.5f,
      Damage = new LeveledAbilityField<float>
      {
        Base = 100,
        PerLevel = 100
      }
    });

    SpellRegistry.Register(new Devour(ABILITY_A0S0_DEVOUR_OURO)
    {
      PercentageOfMaxHealth = 0.5f,
      Damage = new LeveledAbilityField<float>
      {
        Base = 100,
        PerLevel = 100
      }
    });

    SpellRegistry.Register(new UndyingGroveSpell(ABILITY_A15R_UNDYING_GROVE_DRUIDS_HEARTWOOD_ANCIENT)
    {
      HealFraction = 0.3f,
      AreaEffectPath = @"Abilities\Spells\NightElf\Tranquility\TranquilityTarget.mdl",
      SaveEffectPath = @"Abilities\Spells\Human\Resurrect\ResurrectTarget.mdl"
    });

    SpellRegistry.Register(new SpiritsOfTheForestSpell(ABILITY_A15S_SPIRITS_OF_THE_FOREST_DRUIDS_HEARTWOOD_ANCIENT)
    {
      DismissAbilityId = ABILITY_A15U_DISMISS_SPIRITS_OF_THE_FOREST_DRUIDS_HEARTWOOD_ANCIENT,
      ManaPerSecond = 5,
      HealFractionPerSecond = 0.01f,
      CasterEffectPath = @"Abilities\Spells\NightElf\ThornsAura\ThornsAura.mdl",
      HealEffectPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
    });

    SpellRegistry.Register(
      new DismissSpiritsOfTheForestSpell(ABILITY_A15U_DISMISS_SPIRITS_OF_THE_FOREST_DRUIDS_HEARTWOOD_ANCIENT));

    SpellRegistry.Register(new RootTapSpell(ABILITY_A15T_ROOT_TAP_DRUIDS_HEARTWOOD_ANCIENT)
    {
      LifeFraction = 0.1f,
      ManaPerLife = 0.5f,
      EffectPath = @"Abilities\Spells\NightElf\MoonWell\MoonWellCasterArt.mdl"
    });
  }
}
