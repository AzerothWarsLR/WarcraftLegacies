using System.Collections.Generic;

using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Ironforge.Spells;
using WarcraftLegacies.Source.Factions.Ironforge.Spells.GryphonOrbit;

namespace WarcraftLegacies.Source.Factions.Ironforge;

public static class IronforgeSpells
{
  /// <summary>
  /// Sets up <see cref="IronforgeSpells"/>.
  /// </summary>
  public static void Setup()
  {
    SpellRegistry.Register(new TitanForgeArtifact(ABILITY_A0T3_TITANFORGE_ARTIFACT_IRONFORGE)
    {
      DefaultTitanforgedAbility = ABILITY_A0VJ_TITANFORGED_3_ALL_STATS,
      UniqueTitanforgedAbilitiesByItemTypeId = new Dictionary<int, int>
      {
        { ITEM_I016_ZIN_ROKH_DESTROYER_OF_WORLDS, ABILITY_A0VM_TITANFORGED_9_STRENGTH },
        { ITEM_I015_XAL_ATATH_BLADE_OF_THE_BLACK_EMPIRE, ABILITY_A0VM_TITANFORGED_9_STRENGTH }
      },
      GoldCost = 25
    });

    SpellRegistry.Register(new GryphonOrbitSpell(ABILITY_TP10_STORMGUARD_MAGNI_BRONZEBEARD)
    {
      GryphonTypeId = UNIT_HGRY_GRYPHON_RIDER_IRONFORGE,
      StormRiderTypeId = UNIT_H03Z_STORMRIDER_IRONFORGE,
      Damage = new LeveledAbilityField<float> { Base = 30, PerLevel = 20 },
      Duration = new LeveledAbilityField<float> { Base = 25, PerLevel = 5 },
      CollisionRadius = 100,
      OrbitRadius = 300,
      OrbitalPeriod = 4,
      BaseProjectileCount = 3,
      ArmorBonus = 35,
      ArmorBuffEffect = "war3mapImported/Effect_ShieldBuff_Yellow.mdx"
    });
    var volatileFlask = new VolatileFlask(ABILITY_TP11_VOLATILE_FLASK_IRONFORGE)
    {
      Damage = 25f,
      Radius = 175f,
      MaxDamage = 300f
    };
    SpellRegistry.Register(volatileFlask);

    SpellRegistry.Register(new Stormbolt(ABILITY_TP49_MURADIN_S_STORMBOLT_MURADIN)
    {
      Damage = new LeveledAbilityField<float>
      {
        Base = 25f,
        PerLevel = 50f
      },
      StunAbilityId = ABILITY_TP50_MURADIN_S_STORMBOLT_DUMMY_STUN_MURADIN,
    });
  }
}
