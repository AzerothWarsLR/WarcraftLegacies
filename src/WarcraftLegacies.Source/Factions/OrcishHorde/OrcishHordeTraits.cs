using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Warsong.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Factions.OrcishHorde;

public static class OrcishHordeTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new Execute
    {
      DamageMultNonResistant = 4,
      DamageMultResistant = 1.5f
    }, UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_ORCISH_HORDE);

    UnitTypeTraitRegistry.Register(new Execute
    {
      DamageMultNonResistant = 3,
      DamageMultResistant = 1.15f
    }, UNIT_O00G_BLADEMASTER_ORCISH_HORDE);

    UnitTypeTraitRegistry.Register(new ResoluteHeart(ABILITY_A0TY_RESOLUTE_HEART_ICON)
    {
      Radius = 300f,
      BaseProcChance = 0.1f,
      EffectPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
    }, UNIT_O06L_WARLORD_OF_THE_WARSONG_CLAN_ORCISH_HORDE);
  }
}
