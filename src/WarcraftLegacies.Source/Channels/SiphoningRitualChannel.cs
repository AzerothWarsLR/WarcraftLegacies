using System;
using MacroTools.Channels;
using MacroTools.Extensions;
using MacroTools.Libraries;
using WCSharp.Lightnings;

namespace WarcraftLegacies.Source.Channels;

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
      Duration = float.MaxValue
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
