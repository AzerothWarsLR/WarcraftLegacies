using System.Collections.Generic;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits.BonusDamageAttack;
using WCSharp.Api.Enums;

namespace WarcraftLegacies.Source.Factions.Lordaeron;

public static class LordaeronTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new NoTargetSpellOnAttack(ABILITY_A122_WILL_OF_THE_ASHBRINGER_MOGRAINE)
    {
      DummyAbilityId = ABILITY_A0KA_RESURRECTION_DUMMY_MOGRAINE,
      DummyOrderId = ORDER_RESURRECTION,
      ProcChance = 0.2f
    }, UNIT_H01J_THE_ASHBRINGER_LORDAERON);

    var scourgeBaneConditions = new List<DamageCondition>
    {
        new() {
          Damage = 100,
          Condition = target => IsScourgeCondition(target) && target.IsUnitType(unittype.Summoned),
          Effect = "Abilities\\Spells\\Human\\HolyBolt\\HolyBoltSpecialArt.mdl"
        },
        new() {
          Damage = 25,
          Condition = target => IsScourgeCondition(target),
          Effect = "Abilities\\Spells\\Human\\HolyBolt\\HolyBoltSpecialArt.mdl"
        },
    };

    UnitTypeTraitRegistry.Register(new BonusDamageOnAttack()
    {
      Conditions = scourgeBaneConditions,
      ProcChance = 0.4f,
      DamageType = damagetype.Magic
    }, UNIT_HCTH_SILVER_HAND_SQUIRE_LORDAERON);
  }

  public static bool IsScourgeCondition(unit target)
  {
    return target.UnitClassification == UnitClassifications.Undead
      && target.IsABuilding == false
      && (target.Owner.Name == "Scourge" || target.Owner.Name == "Fel Horde" || target.Owner == player.NeutralAggressive);
  }
}
