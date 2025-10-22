using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Setup;
using WCSharp.Effects;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Powers;

/// <summary>
/// Causes dying units to rematerialize at a specific location.
/// </summary>
public sealed class Rematerialization : Power
{
  private readonly float _chance;
  private readonly Point _returnPoint;
  private readonly Rectangle _noReturnRect;

  /// <summary>
  /// The condition that units need to pass to be eligible for rematerialization.
  /// </summary>
  public Func<unit, bool> EligibilityCondition { get; init; } = _ => true;

  /// <summary>
  /// Initializes a new instance of the <see cref="Rematerialization"/> class.
  /// </summary>
  /// <param name="chance">The chance that dying units have to rematerialize.</param>
  /// <param name="returnPoint">Where rematerialized units appear.</param>
  /// <param name="returnPointName">A user-friendly name for where rematerialized units appear.</param>
  /// <param name="noReturnRect">Units that die within this area are not rematerialized.</param>
  public Rematerialization(float chance, Point returnPoint, string returnPointName, Rectangle noReturnRect)
  {
    _chance = chance;
    _returnPoint = returnPoint;
    _noReturnRect = noReturnRect;
    Description = $"Your non-Resistant units have a {chance * 100}% chance to rematerialize in {returnPointName} upon death.";
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer) =>
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnUnitDeath, whichPlayer.Id);

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer) =>
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerUnitDies, OnUnitDeath, whichPlayer.Id);

  private void OnUnitDeath()
  {
    var dyingUnit = @event.Unit;
    if (GetRandomReal(0, 1) > _chance
        || !EligibilityCondition(dyingUnit)
        || _noReturnRect.Contains(dyingUnit.GetPosition())
        || dyingUnit.IsUnitType(unittype.Resistant)
        || dyingUnit.IsUnitType(unittype.Hero)
        || dyingUnit.IsUnitType(unittype.Mechanical)
        || dyingUnit.IsIllusion
        || dyingUnit.IsUnitType(unittype.Summoned))
    {
      return;
    }

    EffectSystem.Add(effect.Create(@"Abilities\Spells\Items\AIil\AIilTarget.mdl", _returnPoint.X, _returnPoint.Y));
    unit.Create(dyingUnit.Owner, dyingUnit.UnitType, _returnPoint.X, _returnPoint.Y, 0);
  }
}
