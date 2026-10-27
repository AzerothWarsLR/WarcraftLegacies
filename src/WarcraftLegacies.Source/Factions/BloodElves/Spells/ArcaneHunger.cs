using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Shared.Data;
using Environment = MacroTools.Utils.Environment;

namespace WarcraftLegacies.Source.Factions.BloodElves.Spells;

/// <summary>Units with the ability feed on enemy spells cast nearby, restoring mana and empowering their spells, with a floating sphere per stack.</summary>
public sealed class ArcaneHunger
{
  private const int MaxStacks = 3;
  private const float OrbitInterval = 0.03f;
  private const float OrbitRadius = 70;
  private const float OrbitHeight = 110;
  private const float OrbitSpeed = 3;

  private readonly Dictionary<unit, int> _stacks = new();
  private readonly Dictionary<unit, timer> _timers = new();
  private readonly Dictionary<unit, List<effect>> _spheres = new();
  private timer? _orbitTimer;
  private float _orbitAngle;

  public required int AbilityTypeId { get; init; }
  public required int FedAbilityTypeId { get; init; }
  public required float Radius { get; init; }
  public required float ManaRestored { get; init; }
  public required float DamageBonusPerStack { get; init; }
  public required float Duration { get; init; }
  public required string EffectPath { get; init; }
  public required string SpherePath { get; init; }

  /// <summary>Starts listening for spells.</summary>
  public void Register() => PlayerUnitEvents.Register(UnitTypeEvent.SpellEffect, OnAnySpellEffect);

  /// <summary>How much <paramref name="whichUnit"/>'s spell damage is multiplied by.</summary>
  public float GetDamageMultiplier(unit whichUnit)
  {
    if (!_stacks.TryGetValue(whichUnit, out var stacks))
    {
      return 1;
    }

    return 1 + stacks * DamageBonusPerStack;
  }

  /// <summary>Spends all of <paramref name="whichUnit"/>'s stacks.</summary>
  public void Consume(unit whichUnit)
  {
    if (_timers.TryGetValue(whichUnit, out var expiry))
    {
      expiry.Dispose();
    }

    Clear(whichUnit);
  }

  private void OnAnySpellEffect()
  {
    var caster = @event.Unit;
    if (caster.UnitType == DummyCasterManager.UnitTypeId)
    {
      return;
    }

    foreach (var nearby in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (nearby.Alive && nearby.GetAbilityLevel(AbilityTypeId) > 0 && caster.IsEnemyTo(nearby.Owner))
      {
        Feed(nearby);
      }
    }
  }

  private void Feed(unit magister)
  {
    magister.Mana += ManaRestored;
    effect.Create(EffectPath, magister, "origin").Dispose();
    _stacks.TryGetValue(magister, out var stacks);
    if (stacks < MaxStacks)
    {
      _stacks[magister] = stacks + 1;
      AddSphere(magister);
    }

    if (magister.GetAbilityLevel(FedAbilityTypeId) == 0)
    {
      magister.AddAbility(FedAbilityTypeId);
    }

    if (!_timers.TryGetValue(magister, out var expiry))
    {
      expiry = timer.Create();
      _timers[magister] = expiry;
    }

    expiry.Start(Duration, false, () =>
    {
      expiry.Dispose();
      Clear(magister);
    });
  }

  private void AddSphere(unit magister)
  {
    if (!_spheres.TryGetValue(magister, out var spheres))
    {
      spheres = new List<effect>();
      _spheres[magister] = spheres;
    }

    spheres.Add(effect.Create(SpherePath, magister.X, magister.Y));
    if (_orbitTimer == null)
    {
      _orbitTimer = timer.Create();
      _orbitTimer.Start(OrbitInterval, true, MoveSpheres);
    }
  }

  private void MoveSpheres()
  {
    _orbitAngle += OrbitSpeed * OrbitInterval;
    foreach (var pair in _spheres)
    {
      var magister = pair.Key;
      var spheres = pair.Value;
      var z = Environment.GetPositionZ(new Point(magister.X, magister.Y)) + OrbitHeight;
      for (var i = 0; i < spheres.Count; i++)
      {
        var angle = _orbitAngle + i * 2 * MathEx.Pi / MaxStacks;
        spheres[i].SetPosition(magister.X + OrbitRadius * Cos(angle), magister.Y + OrbitRadius * Sin(angle), z);
      }
    }
  }

  private void Clear(unit magister)
  {
    magister.RemoveAbility(FedAbilityTypeId);
    _stacks.Remove(magister);
    _timers.Remove(magister);
    if (!_spheres.TryGetValue(magister, out var spheres))
    {
      return;
    }

    foreach (var sphere in spheres)
    {
      sphere.Dispose();
    }

    _spheres.Remove(magister);
  }
}
