using System.Collections.Generic;
using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Ironforge.Spells;

namespace WarcraftLegacies.Source.Factions.Ironforge;

public static class IronforgeSpells
{
  /// <summary>nostop
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
    var volatileFlask = new VolatileFlask(ABILITY_TP11_VOLATILE_FLASK_IRONFORGE)
    {
      Damage = 25f,
      AoE = 175f,
      IgniteDuration = 12f,
      IgniteTickInterval = 1f,
      IgniteDamagePerTick = 10f,
      MaxDamage = 300f
    };
    SpellRegistry.Register(volatileFlask);
  }
}
