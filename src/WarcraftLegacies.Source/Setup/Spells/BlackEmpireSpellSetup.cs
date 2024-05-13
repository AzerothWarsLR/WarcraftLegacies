using MacroTools;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class BlackEmpireSpellSetup
  {
    /// <summary>
    /// Sets up <see cref="BlackEmpireSpellSetup"/>.
    /// </summary>
    public static void Setup()
    {
      var genesisAttack = new SpellOnAttack(UNIT_U029_STYGIAN_HULK_YOGG,
        ABILITY_ABES_GENESIS_ATTACK_ICON_STYGIAN_HULK)
      {
        DummyAbilityId = ABILITY_ABEG_PARASITE_GENESIS_ATTACK_REAL,
        DummyOrderId = OrderId("parasite"),
        ProcChance = 1.0f
      };
      PassiveAbilityManager.Register(genesisAttack);

      var shadowVeilPassive = new NoTargetSpellOnAttack(UNIT_N0AH_DEFORMED_CHIMERA_YOGG,
  ABILITY_ABEV_SHADOW_VEIL)
      {
        DummyAbilityId = ABILITY_ABSV_SHADOW_VEIL_SHADOW_VEIL_REAL,
        DummyOrderId = OrderId("howlofterror"),
        ProcChance = 0.25f
      };
      PassiveAbilityManager.Register(shadowVeilPassive);

      var shadowVeilSpell = new MassAnySpell(ABILITY_ABSV_SHADOW_VEIL_SHADOW_VEIL_REAL)
      {
        DummyAbilityId = ABILITY_ABEI_INVISIBILITY_BLACK_EMPIRE,
        DummyAbilityOrderId = OrderId("invisibility"),
        Radius = 300,
        CastFilter = CastFilters.IsTargetOrganicAndAlive,
        TargetType = SpellTargetType.None
      };
      SpellSystem.Register(shadowVeilSpell);

      var paralysingFear = new SpellOnAttack(UNIT_O01G_BRUTE_YOGG,
        ABILITY_ABPF_PARALYSING_FEAR)
      {
        DummyAbilityId = ABILITY_ABSF_SLOW_PARALYSING_FEAR,
        DummyOrderId = OrderId("slow"),
        ProcChance = 0.2f
      };
      PassiveAbilityManager.Register(paralysingFear);

      var greaterParalysingFear = new SpellOnAttack(UNIT_H09F_DEEP_FIEND_YOGG,
        ABILITY_ABGP_GREATER_PARALYSING_FEAR)
      {
        DummyAbilityId = ABILITY_ABSG_SLOW_GREATER_PARALYSING_FEAR,
        DummyOrderId = OrderId("slow"),
        ProcChance = 0.4f
      };
      PassiveAbilityManager.Register(greaterParalysingFear);
    }
  }
}