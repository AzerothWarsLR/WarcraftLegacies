using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Spells;

public sealed class WrathOfTheEarthMother : Spell
{
  public required LeveledAbilityField<float> Amount { get; init; }

  public required float Radius { get; init; }

  public required float Duration { get; init; }

  public required float Period { get; init; }

  public required int RootAbilityId { get; init; }

  public required int RootBuffId { get; init; }

  public string AreaEffect { get; init; } = @"Abilities\Spells\NightElf\Tranquility\Tranquility.mdl";

  public string HealEffect { get; init; } = @"Abilities\Spells\NightElf\Tranquility\TranquilityTarget.mdl";

  private readonly Dictionary<unit, WrathOfTheEarthMotherHazard> _activeHazards = new();

  public WrathOfTheEarthMother(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var hazard = new WrathOfTheEarthMotherHazard(caster, caster.X, caster.Y)
    {
      Amount = Amount.GetValue(GetAbilityLevel(caster)),
      Radius = Radius,
      RootAbilityId = RootAbilityId,
      RootBuffId = RootBuffId,
      AreaEffect = AreaEffect,
      HealEffect = HealEffect,
      Interval = Period,
      Duration = Duration
    };
    _activeHazards[caster] = hazard;
    HazardSystem.Add(hazard);
  }

  public override void OnStop(unit caster)
  {
    if (_activeHazards.TryGetValue(caster, out var hazard))
    {
      _activeHazards.Remove(caster);
      hazard.Duration = 0;
    }
  }
}

public sealed class WrathOfTheEarthMotherHazard : Hazard
{
  public float Amount { get; init; }

  public float Radius { get; init; }

  public int RootAbilityId { get; init; }

  public int RootBuffId { get; init; }

  public string AreaEffect { get; init; } = "";

  public string HealEffect { get; init; } = "";

  private effect? _areaEffect;

  private readonly List<unit> _rootedUnits = new();

  public WrathOfTheEarthMotherHazard(unit caster, float x, float y) : base(caster, x, y)
  {
  }

  public override void OnCreate()
  {
    _areaEffect = effect.Create(AreaEffect, Position.X, Position.Y);
  }

  protected override void OnPeriodic()
  {
    if (Caster == null)
    {
      return;
    }

    foreach (var target in GlobalGroup.EnumUnitsInRange(Position.X, Position.Y, Radius))
    {
      if (!target.Alive || target.IsUnitType(unittype.Structure) || target.IsUnitType(unittype.Mechanical))
      {
        continue;
      }

      if (target.IsEnemyTo(Caster.Owner) && !target.IsInvulnerable)
      {
        Caster.DealDamage(target, Amount, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
        if (!_rootedUnits.Contains(target))
        {
          _rootedUnits.Add(target);
          DummyCasterManager.GetGlobalDummyCaster()
            .CastUnit(Caster, RootAbilityId, ORDER_ENTANGLING_ROOTS, 1, target, DummyCastOriginType.Target);
        }
      }
      else if (target.IsAllyTo(Caster.Owner))
      {
        target.Life += Amount;
        effect.Create(HealEffect, target, "origin").Dispose();
      }
    }
  }

  protected override void OnDispose()
  {
    _areaEffect?.Dispose();
    foreach (var rootedUnit in _rootedUnits)
    {
      rootedUnit.RemoveAbility(RootBuffId);
    }

    _rootedUnits.Clear();
  }
}
