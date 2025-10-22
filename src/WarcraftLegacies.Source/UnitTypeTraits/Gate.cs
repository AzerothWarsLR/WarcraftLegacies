using MacroTools.Systems;
using MacroTools.UnitTypeTraits;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// Gates are buildings that can open and close.
/// </summary>
public sealed class Gate : UnitTypeTrait, IEffectOnUpgrade, IEffectOnDeath, IEffectOnSpellFinish, IEffectOnCancelUpgrade, IEffectOnCreated
{
  /// <summary>Gates will gain this many hit points, as a percentage of their maximum, per turn.</summary>
  public const float HitPointPercentagePerTurn = 0.05f;

  private readonly int _openedId;
  private readonly int _deadId;

  /// <summary>
  /// Constructs a new <see cref="Gate"/>.
  /// </summary>
  /// <param name="openedId">The unit type ID of the gate while open.</param>
  /// <param name="closedId">The unit type ID of the gate while closed.</param>
  /// <param name="deadId">The unit type ID of the gate while dead.</param>
  public Gate(int openedId, int closedId, int deadId) : base(new[] { openedId, closedId, deadId })
  {
    _openedId = openedId;
    _deadId = deadId;
  }

  /// <inheritdoc/>
  public void OnDeath()
  {
    var dyingGate = @event.Unit;
    var dyingGateFacing = dyingGate.Facing;
    dyingGate.Dispose();
    TurnBasedHitpointsManager.UnRegister(dyingGate);
    var deadGate = unit.Create(@event.KillingUnit.Owner, _deadId, dyingGate.X, dyingGate.Y, dyingGateFacing);
    deadGate.SetAnimation("death");
  }

  /// <inheritdoc/>
  public void OnSpellFinish()
  {
    if (@event.Unit.UnitType == _openedId)
    {
      @event.Unit.SetAnimation("death alternate");
    }
  }

  /// <inheritdoc/>
  public void OnCreated(unit createdUnit)
  {
    if (createdUnit.UnitType == _openedId)
    {
      createdUnit.SetAnimation("death alternate");
    }

    TurnBasedHitpointsManager.Register(createdUnit, HitPointPercentagePerTurn);
  }

  /// <inheritdoc />
  public void OnCancelUpgrade() =>
    @event.Unit.SetAnimation("death");

  /// <inheritdoc />
  public void OnUpgrade()
  {
    TurnBasedHitpointsManager.UnRegister(@event.Unit);
    TurnBasedHitpointsManager.Register(@event.Unit, HitPointPercentagePerTurn);
  }
}
