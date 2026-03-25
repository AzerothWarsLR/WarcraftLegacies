using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Factions.BlackEmpire;

public static class BlackEmpireTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new HideousAppendages
    {
      TentacleUnitTypeId = UNIT_N098_NZOTHTENTACLE_HIDEOUS_APPENDAGES_N_ZOTH,
      TentacleCount = 9,
      RadiusOffset = 520
    }, UNIT_U01Z_OLD_GOD_NZOTH);

    UnitTypeTraitRegistry.Register(new InfiniteInfluence
    {
      Radius = 800
    }, UNIT_U01Z_OLD_GOD_NZOTH);

    UnitTypeTraitRegistry.Register(new SpellOnCast(ABILITY_AXK2_VOID_RIFT_ICON_XKORR)
    {
      DummyAbilityId = ABILITY_AXK1_VOIDBOLTDUMMY_X_KORR_DUMMY_SPELL,
      DummyOrderId = ORDER_FAN_OF_KNIVES,
      AbilityWhitelist = new List<int>
      {
        ABILITY_A032_ARCANE_BOMBARDMENT_ORANGE_ANTONIDAS_MEDIVH,
        ABILITY_ABEH_HEALING_WAVE_BLACK_EMPIRE,
        ABILITY_A10U_MANA_BURN_DALARAN_YOGG,
        ABILITY_A11O_BLACK_HOLE_KHADGAR,
      },
      TargetType = SpellTargetType.None
    }, UNIT_E01D_HARBINGER_OF_NY_ALOTHA_NZOTH);

    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_ABES_GENESIS_ATTACK_ICON_STYGIAN_HULK)
    {
      DummyAbilityId = ABILITY_ABEG_PARASITE_GENESIS_ATTACK_REAL,
      DummyOrderId = ORDER_PARASITE,
      ProcChance = 1.0f
    }, UNIT_U029_STYGIAN_HULK_NZOTH);

    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_ABPF_PARALYSING_FEAR_ICON)
    {
      DummyAbilityId = ABILITY_ABSF_SLOW_PARALYSING_FEAR,
      DummyOrderId = ORDER_SLOW,
      ProcChance = 0.2f
    }, UNIT_O01G_BRUTE_NZOTH);

    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_ABGP_GREATER_PARALYSING_FEAR_ICON)
    {
      DummyAbilityId = ABILITY_ABSG_SLOW_GREATER_PARALYSING_FEAR,
      DummyOrderId = ORDER_SLOW,
      ProcChance = 0.4f
    }, UNIT_H09F_DEEP_FIEND_NZOTH);
  }
}
