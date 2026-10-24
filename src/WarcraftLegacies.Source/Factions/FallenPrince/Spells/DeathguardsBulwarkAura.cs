using System.Collections.Generic;
using MacroTools.UnitTraits;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Spells;

/// <summary>Friendly units near a hero with this aura take less damage from spells.</summary>
public sealed class DeathguardsBulwarkAura : UnitTrait, IEffectOnCreated
{
  private readonly List<unit> _carriers = new();

  public required int AbilityTypeId { get; init; }
  public required int BuffId { get; init; }
  public required float Radius { get; init; }
  public required float[] ReductionByLevel { get; init; }

  public DeathguardsBulwarkAura()
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, OnAnyUnitDamaged);
  }

  /// <inheritdoc />
  public void OnCreated(unit createdUnit)
  {
    if (!_carriers.Contains(createdUnit))
    {
      _carriers.Add(createdUnit);
    }
  }

  private void OnAnyUnitDamaged()
  {
    var target = @event.Unit;
    if (_carriers.Count == 0 || @event.IsAttack || target.GetAbilityLevel(BuffId) == 0)
    {
      return;
    }

    var reduction = 0f;
    for (var i = _carriers.Count - 1; i >= 0; i--)
    {
      var carrier = _carriers[i];
      if (!carrier.Alive)
      {
        _carriers.RemoveAt(i);
        continue;
      }

      var level = carrier.GetAbilityLevel(AbilityTypeId);
      if (level == 0 || !target.IsAllyTo(carrier.Owner) || !IsInRange(carrier, target))
      {
        continue;
      }

      var levelReduction = ReductionByLevel[level - 1];
      if (levelReduction > reduction)
      {
        reduction = levelReduction;
      }
    }

    if (reduction > 0)
    {
      @event.Damage *= 1 - reduction;
    }
  }

  private bool IsInRange(unit carrier, unit target)
  {
    var dx = carrier.X - target.X;
    var dy = carrier.Y - target.Y;
    return dx * dx + dy * dy <= Radius * Radius;
  }
}
