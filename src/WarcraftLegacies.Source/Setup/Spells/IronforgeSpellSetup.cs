using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.UnitTypeTraits;

namespace WarcraftLegacies.Source.Setup.Spells;

public static class IronforgeSpellSetup
{
  /// <summary>
  /// Sets up <see cref="IronforgeSpellSetup"/>.
  /// </summary>
  public static void Setup()
  {
    SpellRegistry.Register(new TitanForgeArtifact(ABILITY_A0T3_TITANFORGE_ARTIFACT_IRONFORGE)
    {
      DefaultTitanforgedAbility = FourCC("A0VJ"),
      UniqueTitanforgedAbilitiesByItemTypeId = new Dictionary<int, int>
      {
        { ITEM_I016_ZIN_ROKH_DESTROYER_OF_WORLDS, ABILITY_A0VM_TITANFORGED_9_STRENGTH },
        { ITEM_I015_XAL_ATATH_BLADE_OF_THE_BLACK_EMPIRE, ABILITY_A0VM_TITANFORGED_9_STRENGTH }
      },
      GoldCost = 25
    });

    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_A10J_MASTER_OF_LIGHTNING_STORMRIDERS)
    {
      DummyAbilityId = ABILITY_ACFL_FORKED_LIGHTNING_LIGHT_BLUE_HIGHBORNE,
      DummyOrderId = ORDER_FORKED_LIGHTNING,
      ProcChance = 0.15f
    }, UNIT_H03Z_STORMRIDER_IRONFORGE);
  }
}
