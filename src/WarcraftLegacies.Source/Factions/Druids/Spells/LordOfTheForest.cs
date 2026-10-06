using System;
using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Extensions;
using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Druids.Spells;

public sealed class LordOfTheForest : Spell
{
  public required int TreantTypeId { get; init; }

  public required int AncientTypeId { get; init; }

  public required LeveledAbilityField<int> TreantCount { get; init; }

  public required LeveledAbilityField<int> AncientCount { get; init; }

  public required LeveledAbilityField<float> EmergeDamage { get; init; }

  public required float Radius { get; init; }

  public required float EmergeRadius { get; init; }

  public required float ChannelSeconds { get; init; }

  public required float SummonSeconds { get; init; }

  public required int SlowAbilityId { get; init; }

  public float TreantScale { get; init; } = 1f;

  public float AncientScale { get; init; } = 1f;

  private readonly Dictionary<unit, LordOfTheForestHazard> _activeHazards = new();

  public LordOfTheForest(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var hazard = new LordOfTheForestHazard(caster, targetPoint.X, targetPoint.Y, this,
      TreantCount.GetValue(level), AncientCount.GetValue(level), EmergeDamage.GetValue(level))
    {
      Interval = PeriodicEvents.SYSTEM_INTERVAL,
      Duration = ChannelSeconds
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

  internal void Summon(unit caster, Point center, bool ancient, float emergeDamage)
  {
    var angle = GetRandomReal(0, 2 * MathEx.Pi);
    var distance = GetRandomReal(0, Radius);
    var x = center.X + distance * Cos(angle);
    var y = center.Y + distance * Sin(angle);

    var summoned = unit.Create(caster.Owner, ancient ? AncientTypeId : TreantTypeId, x, y, GetRandomReal(0, 360));
    summoned.SetTimedLife(SummonSeconds, FourCC("BTLF"));
    effect.Create(@"Objects\Spawnmodels\NightElf\EntBirthTarget\EntBirthTarget.mdl", x, y).Dispose();

    if (!ancient)
    {
      GrowFromGround(summoned, TreantScale, 0.6f, null);
      return;
    }

    effect.Create(@"Abilities\Spells\NightElf\EntanglingRoots\EntanglingRootsTarget.mdl", x, y).Dispose();
    var dummyCaster = DummyCasterManager.GetGlobalDummyCaster();
    foreach (var enemy in GlobalGroup.EnumUnitsInRange(x, y, EmergeRadius))
    {
      if (!enemy.Alive || !enemy.IsEnemyTo(caster.Owner) || enemy.IsInvulnerable ||
          enemy.IsUnitType(unittype.Structure))
      {
        continue;
      }

      caster.DealDamage(enemy, emergeDamage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      dummyCaster.CastUnit(caster, SlowAbilityId, ORDER_SLOW, 1, enemy, DummyCastOriginType.Target);
    }

    GrowFromGround(summoned, AncientScale, 1f, () => summoned.IssueOrder(ORDER_TAUNT));
  }

  private static void GrowFromGround(unit whichUnit, float finalScale, float seconds, Action? onGrown)
  {
    var elapsed = 0f;
    whichUnit.SetScale(0.05f, 0.05f, 0.05f);
    PeriodicEvents.AddPeriodicEvent(() =>
    {
      elapsed += PeriodicEvents.SYSTEM_INTERVAL;
      var scale = Math.Max(0.05f, finalScale * Math.Min(1f, elapsed / seconds));
      whichUnit.SetScale(scale, scale, scale);
      if (elapsed < seconds && whichUnit.Alive)
      {
        return true;
      }

      if (whichUnit.Alive)
      {
        onGrown?.Invoke();
      }

      return false;
    }, PeriodicEvents.SYSTEM_INTERVAL);
  }
}

public sealed class LordOfTheForestHazard : Hazard
{
  private readonly LordOfTheForest _spell;
  private readonly float _treantInterval;
  private readonly float _ancientInterval;
  private readonly int _treantCount;
  private readonly int _ancientCount;
  private readonly float _emergeDamage;
  private float _elapsed;
  private int _treantsSummoned;
  private int _ancientsSummoned;

  public LordOfTheForestHazard(unit caster, float x, float y, LordOfTheForest spell, int treantCount,
    int ancientCount, float emergeDamage) : base(caster, x, y)
  {
    _spell = spell;
    _treantCount = treantCount;
    _ancientCount = ancientCount;
    _emergeDamage = emergeDamage;
    _treantInterval = spell.ChannelSeconds / treantCount;
    _ancientInterval = spell.ChannelSeconds / ancientCount;
  }

  protected override void OnPeriodic()
  {
    if (Caster == null)
    {
      return;
    }

    _elapsed += Interval;
    while (_treantsSummoned < _treantCount && _elapsed >= _treantInterval * (_treantsSummoned + 0.5f))
    {
      _treantsSummoned++;
      _spell.Summon(Caster, Position, false, _emergeDamage);
    }

    while (_ancientsSummoned < _ancientCount && _elapsed >= _ancientInterval * (_ancientsSummoned + 0.5f))
    {
      _ancientsSummoned++;
      _spell.Summon(Caster, Position, true, _emergeDamage);
    }
  }
}
