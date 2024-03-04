using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;


namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up <see cref="Spell"/>s and <see cref="PassiveAbility"/>s related to Illidan.
  /// </summary>
  public static class IllidanSpellSetup
  {
    /// <summary>
    /// Sets up all <see cref="Spell"/>s and <see cref="PassiveAbility"/>s related to Illidan.
    /// </summary>
    public static void Setup()
    {
      var illidanVariations = new[]
      {
        Constants.UNIT_EILL_THE_BETRAYER_ILLIDARI,
        FourCC("Eidm"),
        Constants.UNIT_EEVM_DEMON_HUNTER_EVIL_MORPHED,
        Constants.UNIT_EILM_DEMON_HUNTER,
        Constants.UNIT_EEVI_BETRAYER_ILLIDARI,
        Constants.UNIT_E00G_DEMON_HUNTER_EVIL_MORPHED_LEVEL_3,
        Constants.UNIT_E00E_DEMON_HUNTER_MORPHED_LEVEL_2,
        Constants.UNIT_E00D_DEMON_HUNTER_MORPHED_LEVEL_3
      };

      var warglaivesOfAzzinoth = new WarglaivesOfAzzinoth(illidanVariations,
        Constants.ABILITY_A0YW_WARGLAIVES_OF_AZZINOTH_GREEN_LIGHT_BLUE_ILLIDAN)
      {
        Radius = 150,
        DamageBase = 4,
        DamageLevel = 14,
        DamageMultiplierAgainstDemons = 1.2f,
        Effect = @"war3mapImported\Culling Cleave.mdx",
        EffectScale = 1.2f,
        DamageType = DAMAGE_TYPE_MAGIC
      };
      PassiveAbilityManager.Register(warglaivesOfAzzinoth);
    }
  }
}