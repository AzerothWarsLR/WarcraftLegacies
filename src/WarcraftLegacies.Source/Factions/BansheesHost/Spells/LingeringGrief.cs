using MacroTools.DummyCasters;
using MacroTools.Hazards;
using MacroTools.UnitTraits;
using MacroTools.Utils;

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
  private readonly player _owner;
  private unit? _damageSource;
  private readonly float _x;
  private readonly float _y;
  private effect? _spirit;

  public required float Radius { get; init; }
  public required float DamagePerTick { get; init; }
  public required string SpiritEffectPath { get; init; }
  public required string TickEffectPath { get; init; }

  public LingeringGriefHazard(unit source) : this(source, source.X, source.Y)
  {
  }

  public LingeringGriefHazard(unit source, float x, float y) : base(source, x, y)
  {
    _owner = source.Owner;
    _x = x;
    _y = y;
  }

  public override void OnCreate()
  {
    _spirit = effect.Create(SpiritEffectPath, _x, _y);
    _damageSource = unit.Create(_owner, DummyCasterManager.UnitTypeId, _x, _y, 0);
    _spirit.SetAlpha(160);
  }

  protected override void OnPeriodic()
  {
    if (_damageSource == null)
    {
      return;
    }

    foreach (var target in GlobalGroup.EnumUnitsInRange(_x, _y, Radius))
    {
      if (!target.Alive || target.IsAllyTo(_owner) || target.UnitType == DummyCasterManager.UnitTypeId ||
          target.IsUnitType(unittype.Structure))
      {
        continue;
      }

      effect.Create(TickEffectPath, target, "chest").Dispose();
      _damageSource.DealDamage(target, DamagePerTick, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    }
  }

  protected override void OnDispose()
  {
    if (_spirit != null)
    {
      _spirit.Dispose();
    }

    if (_damageSource != null)
    {
      _damageSource.Dispose();
    }
  }
}
