using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.BansheesHost.Spells;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Forsaken.Spells;

/// <summary>Rain of Fire that ends with an Infernal crashing into the centre, if the caster channels to the end.</summary>
public sealed class HellfireRainSpell : Spell
{
  private readonly Dictionary<unit, HellfireRainCast> _casts = new();

  public required int[] WavesByLevel { get; init; }
  public required float WaveInterval { get; init; }
  public required float ChannelFractionNeeded { get; init; }
  public required LeveledAbilityField<float> MeteorDamage { get; init; }
  public required float MeteorRadius { get; init; }
  public required float MeteorDelay { get; init; }
  public required int StunAbilityId { get; init; }
  public required LeveledAbilityField<float> FelFireDamagePerSecond { get; init; }
  public required float FelFireDuration { get; init; }
  public required string MeteorEffectPath { get; init; }
  public required string FelFireEffectPath { get; init; }
  public required string FelFireTickEffectPath { get; init; }

  public HellfireRainSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    EndCast(caster);
    var level = GetAbilityLevel(caster);
    var waves = WavesByLevel[System.Math.Min(level, WavesByLevel.Length) - 1];
    var cast = new HellfireRainCast(targetPoint.X, targetPoint.Y, level);
    _casts[caster] = cast;
    cast.Timer.Start(waves * WaveInterval * ChannelFractionNeeded, false, () => cast.Channelled = true);
  }

  /// <inheritdoc />
  public override void OnStop(unit caster)
  {
    if (!_casts.TryGetValue(caster, out var cast))
    {
      return;
    }

    EndCast(caster);
    if (cast.Channelled)
    {
      DropInfernal(caster, cast);
    }
  }

  private void EndCast(unit caster)
  {
    if (_casts.TryGetValue(caster, out var cast))
    {
      cast.Timer.Dispose();
      _casts.Remove(caster);
    }
  }

  private void DropInfernal(unit caster, HellfireRainCast cast)
  {
    var x = cast.X;
    var y = cast.Y;
    var damage = MeteorDamage.GetValue(cast.Level);
    var felFireDamage = FelFireDamagePerSecond.GetValue(cast.Level);
    EffectSystem.Add(effect.Create(MeteorEffectPath, x, y), 3);
    var impact = timer.Create();
    impact.Start(MeteorDelay, false, () =>
    {
      impact.Dispose();
      var damageSource = unit.Create(caster.Owner, DummyCasterManager.UnitTypeId, x, y, 0);
      foreach (var nearby in GlobalGroup.EnumUnitsInRange(x, y, MeteorRadius))
      {
        if (!CastFilters.IsTargetEnemyAndAliveUnits(damageSource, nearby) || nearby.UnitType == DummyCasterManager.UnitTypeId)
        {
          continue;
        }

        damageSource.DealDamage(nearby, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
        if (nearby.Alive)
        {
          DummyCasterManager.GetGlobalDummyCaster()
            .CastUnit(damageSource, StunAbilityId, ORDER_THUNDERBOLT, 1, nearby, DummyCastOriginType.Target);
        }
      }

      HazardSystem.Add(new LingeringGriefHazard(damageSource, x, y)
      {
        Radius = MeteorRadius,
        DamagePerTick = felFireDamage,
        SpiritEffectPath = FelFireEffectPath,
        TickEffectPath = FelFireTickEffectPath,
        Interval = 1,
        Duration = FelFireDuration
      });
      damageSource.Dispose();
    });
  }
}

/// <summary>One channel of <see cref="HellfireRainSpell"/>.</summary>
public sealed class HellfireRainCast
{
  public HellfireRainCast(float x, float y, int level)
  {
    X = x;
    Y = y;
    Level = level;
  }

  public float X { get; }
  public float Y { get; }
  public int Level { get; }
  public timer Timer { get; } = timer.Create();
  public bool Channelled { get; set; }
}
