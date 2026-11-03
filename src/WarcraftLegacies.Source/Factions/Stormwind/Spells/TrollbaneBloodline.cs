using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Utils;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>Every few attacks, the unit's attack also hits enemies around its target.</summary>
public sealed class TrollbaneBloodline
{
  private readonly Dictionary<unit, int> _attackCounts = new();

  public required int AbilityTypeId { get; init; }
  public required int AttacksPerCleave { get; init; }
  public required float CleaveFraction { get; init; }
  public required float Radius { get; init; }
  public required string CleaveEffectPath { get; init; }

  /// <summary>Starts listening for attacks.</summary>
  public void Register() => PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, OnAnyUnitDamaged);

  private void OnAnyUnitDamaged()
  {
    var attacker = @event.DamageSource;
    if (!@event.IsAttack || attacker.GetAbilityLevel(AbilityTypeId) == 0)
    {
      return;
    }

    var count = 1;
    if (_attackCounts.TryGetValue(attacker, out var previous))
    {
      count = previous + 1;
    }

    if (count < AttacksPerCleave)
    {
      _attackCounts[attacker] = count;
      return;
    }

    _attackCounts[attacker] = 0;
    var target = @event.Unit;
    var damage = (BlzGetUnitBaseDamage(attacker, 0) + BlzGetUnitDiceNumber(attacker, 0) * (BlzGetUnitDiceSides(attacker, 0) + 1) / 2f) * CleaveFraction;
    effect.Create(CleaveEffectPath, target.X, target.Y).Dispose();
    foreach (var victim in GlobalGroup.EnumUnitsInRange(target.X, target.Y, Radius))
    {
      if (victim == target || !victim.Alive || !victim.IsEnemyTo(attacker.Owner) ||
          victim.IsUnitType(unittype.Structure) || victim.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      attacker.DealDamage(victim, damage, false, false, attacktype.Normal, damagetype.Normal, weapontype.WhoKnows);
    }
  }
}
