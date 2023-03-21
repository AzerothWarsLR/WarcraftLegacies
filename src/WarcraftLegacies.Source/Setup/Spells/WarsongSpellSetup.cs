using MacroTools;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all <see cref="WarsongSetup.WarsongClan"/> <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
  /// </summary>
  public static class WarsongSpellSetup
  {
    /// <summary>
    /// Sets up <see cref="WarsongSpellSetup"/>.
    /// </summary>
    public static void Setup()
    {
      PassiveAbilityManager.Register(new Execute(Constants.UNIT_O06L_WARLORD_OF_THE_WARSONG_CLAN_WARSONG)
      {
        DamageMultNonResistant = 4,
        DamageMultResistant = 2,
        DamageMultStructure = 1
      });

      PassiveAbilityManager.Register(new Execute(Constants.UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_WARSONG)
      {
        DamageMultNonResistant = 4,
        DamageMultResistant = 2,
        DamageMultStructure = 1
      });

      PassiveAbilityManager.Register(new RestoreManaFromDamage(Constants.UNIT_O06L_WARLORD_OF_THE_WARSONG_CLAN_WARSONG, Constants.ABILITY_A0FR_TRANSFUSION_GORFAX)
      {
        ManaPerDamage = new LeveledAbilityField<float>
        {
          Base = 0.25f,
          PerLevel = 0.25f
        },
        Effect = "Abilities\\Spells\\Undead\\ReplenishMana\\SpiritTouchTarget.mdl"
      });
    }
  }
}