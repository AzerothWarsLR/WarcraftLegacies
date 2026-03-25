using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Skywall;

public static class SkywallTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_AELP_SHOCKING_BLADES_ANIMATED_ARMOR)
    {
      DummyAbilityId = ABILITY_AEPU_PURGE_SHOCKING_BLADE,
      DummyOrderId = ORDER_PURGE,
      ProcChance = 0.20f,
      RequiredResearch = UPGRADE_RELP_SHOCKING_BLADES_SKYWALL
    }, UNIT_O01I_ANIMATED_ARMOR_SKYWALL);


    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_A0Y6_WATER_PRISON_ELEMENTAL_LORD)
    {
      DummyAbilityId = ABILITY_A0Y0_WATER_PRISON_REAL,
      DummyOrderId = ORDER_ENTANGLING_ROOTS,
      ProcChance = 0.2f,
      Cooldown = 10f,
      RequiredResearch = UPGRADE_RSW3_QUEST_COMPLETED_SUBDUING_NEPTULON
    }, UNIT_N08S_ELEMENTAL_LORD_SKYWALL);
  }
}
