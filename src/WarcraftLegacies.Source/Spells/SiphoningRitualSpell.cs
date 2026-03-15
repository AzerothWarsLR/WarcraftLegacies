using System;
using System.Linq;
using MacroTools.Channels;
using MacroTools.Extensions;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Lightnings;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Absorb life and mana from multiple targets in an area.
/// </summary>
public sealed class SiphoningRitual : Spell
{
  /// <summary>
  /// The maximum number of targets that can be drained simultaneously.
  /// </summary>
  public int TargetCountBase { get; init; }

  /// <summary>
  /// Gets multiplied by the spell level and added to <see cref="TargetCountBase"/>.
  /// </summary>
  public int TargetCountLevel { get; init; }

  /// <summary>
  /// How many hit points to drain per second.
  /// </summary>
  public float LifeDrainedPerSecondBase { get; init; }

  /// <summary>
  /// How many hit points to drain per second. Gets multiplied by the spell level.
  /// </summary>
  public float LifeDrainedPerSecondLevel { get; init; }

  /// <summary>
  /// How much mana to drain per second. Gets multiplied by the spell level.
  /// </summary>
  public float ManaDrainedPerSecondBase { get; init; }

  /// <summary>
  /// How much mana to to drain per second. Gets multiplied by the spell level.
  /// </summary>
  public float ManaDrainedPerSecondLevel { get; init; }

  /// <summary>
  /// If a unit goes beyond this range, the drain breaks.
  /// </summary>
  public float Range { get; init; }

  /// <summary>
  /// The radius around the target position in which to get units for draining.
  /// </summary>
  public float Radius { get; init; }

  /// <summary>
  /// The interval at which to drain units.
  /// </summary>
  public float Interval { get; init; }

  /// <summary>
  /// Initializes a new instance of the <see cref="SiphoningRitual"/> class.
  /// </summary>
  /// <param name="id"><inheritdoc /></param>
  public SiphoningRitual(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var targets = GlobalGroup
      .EnumUnitsInRange(targetPoint, Radius).Where(unit => IsValidTarget(caster, unit))
      .Take(TargetCountBase + TargetCountLevel * GetAbilityLevel(caster));
    foreach (var unit in targets)
    {
      var channel = new SiphoningRitualChannel(caster, unit, Id)
      {
        Interval = Interval,
        LifeDrainedPerSecond = LifeDrainedPerSecondBase + LifeDrainedPerSecondLevel * GetAbilityLevel(caster),
        ManaDrainedPerSecond = ManaDrainedPerSecondBase + ManaDrainedPerSecondLevel * GetAbilityLevel(caster),
        Range = Range + Radius / 2
      };
      ChannelManager.Add(channel);
    }
  }

  private static bool IsValidTarget(unit caster, unit target) =>
    caster != target && !target.IsUnitType(unittype.Structure) && !target.IsUnitType(unittype.Ancient) &&
    !target.IsUnitType(unittype.Mechanical) && target.Alive;
}

/// <summary>
/// Periodically transfer hitpoints and mana from the target to the caster.
/// </summary>
public sealed class SiphoningRitualChannel : Channel
{
  private readonly unit _target;
  private Lightning? _lightning;

  /// <summary>
  /// How many hit points are transferred from the target to the caster per second.
  /// </summary>
  public float LifeDrainedPerSecond { get; init; }

  /// <summary>
  /// How much mana is transferred from the target to the caster per second.
  /// </summary>
  public float ManaDrainedPerSecond { get; init; }

  /// <summary>
  /// Beyond this range, the <see cref="SiphoningRitualChannel"/> is cancelled.
  /// </summary>
  public float Range { get; init; } = float.MaxValue;

  /// <summary>
  /// Initializes a new instance of the <see cref="SiphoningRitualChannel"/> class.
  /// </summary>
  /// <param name="caster"><inheritdoc /></param>
  /// <param name="target">The target having its life force drained.</param>
  /// <param name="spellId"><inheritdoc /></param>
  public SiphoningRitualChannel(unit caster, unit target, int spellId) : base(caster, spellId)
  {
    _target = target;
  }

  /// <inheritdoc />
  public override void OnCreate()
  {
    _lightning = new Lightning("DRAB", Caster, _target)
    {
      Duration = float.MaxValue,
      FadeDuration = 0.25f
    };
    LightningSystem.Add(_lightning);
  }

  /// <inheritdoc />
  protected override void OnPeriodic()
  {
    if (MathEx.GetDistanceBetweenPoints(Caster.GetPosition(), _target.GetPosition()) > Range || !_target.Alive)
    {
      Active = false;
      return;
    }

    if (Caster.Life < Caster.MaxLife ||
        !_target.IsAllyTo(Caster.Owner))
    {
      _target.TakeDamage(Caster, LifeDrainedPerSecond * Interval, ranged: true, damageType: damagetype.Magic);
      Caster.Life += Math.Min(LifeDrainedPerSecond * Interval, _target.Life);
    }

    if (Caster.Mana < Caster.MaxMana ||
        !_target.IsAllyTo(Caster.Owner))
    {
      var manaDrained = Math.Min(ManaDrainedPerSecond * Interval, _target.Mana);
      Caster.Mana += manaDrained;
      _target.Mana -= manaDrained;
    }
  }

  /// <inheritdoc />
  protected override void OnDispose()
  {
    if (_lightning != null)
    {
      _lightning.Active = false;
    }
  }
}
