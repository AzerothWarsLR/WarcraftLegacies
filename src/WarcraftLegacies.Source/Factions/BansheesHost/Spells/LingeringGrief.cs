using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using MacroTools.Utils;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Spells;

/// <summary>When the unit dies, its grief lingers where it fell and damages nearby enemies for a while.</summary>
public sealed class LingeringGrief : UnitTrait, IEffectOnDeath
{
  public required float Duration { get; init; }
  public required float Radius { get; init; }
  public required float DamagePerSecond { get; init; }
  public required string SpiritEffectPath { get; init; }
  public required string TickEffectPath { get; init; }

  /// <inheritdoc />
  public void OnDeath()
  {
    HazardSystem.Add(new LingeringGriefHazard(@event.Unit)
    {
      Radius = Radius,
      DamagePerTick = DamagePerSecond,
      SpiritEffectPath = SpiritEffectPath,
      TickEffectPath = TickEffectPath,
      Interval = 1,
      Duration = Duration
    });
  }
}

/// <summary>The grieving spirit left behind by <see cref="LingeringGrief"/>.</summary>
public sealed class LingeringGriefHazard : Hazard
{
  private readonly unit _source;
  private readonly float _x;
  private readonly float _y;
  private effect? _spirit;

  public required float Radius { get; init; }
  public required float DamagePerTick { get; init; }
  public required string SpiritEffectPath { get; init; }
  public required string TickEffectPath { get; init; }

  public LingeringGriefHazard(unit source) : base(source, source.X, source.Y)
  {
    _source = source;
    _x = source.X;
    _y = source.Y;
  }

  public override void OnCreate()
  {
    _spirit = effect.Create(SpiritEffectPath, _x, _y);
    _spirit.SetAlpha(160);
  }

  protected override void OnPeriodic()
  {
    foreach (var target in GlobalGroup.EnumUnitsInRange(_x, _y, Radius))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(_source, target))
      {
        continue;
      }

      effect.Create(TickEffectPath, target, "chest").Dispose();
      target.Damage(_source, DamagePerTick, attacktype.Magic);
    }
  }

  protected override void OnDispose()
  {
    if (_spirit != null)
    {
      _spirit.Dispose();
    }
  }
}
