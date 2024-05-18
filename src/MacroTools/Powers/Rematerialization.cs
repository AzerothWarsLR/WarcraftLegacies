using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Powers
{
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
      Description = $"Your non-Resistant units a {chance*100}% chance to rematerialize in {returnPointName} upon death.";
    }
    
    /// <inheritdoc />
    public override void OnAdd(player whichPlayer) => 
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnUnitDeath, GetPlayerId(whichPlayer));

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer) => 
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerUnitDies, OnUnitDeath, GetPlayerId(whichPlayer));

    private void OnUnitDeath()
    {
      var dyingUnit = GetTriggerUnit();
      if (GetRandomReal(0, 1) > _chance 
          || !EligibilityCondition(dyingUnit) 
          || _noReturnRect.Contains(dyingUnit.GetPosition())
          || dyingUnit.IsType(UNIT_TYPE_RESISTANT)
          || dyingUnit.IsType(UNIT_TYPE_HERO) 
          || dyingUnit.IsType(UNIT_TYPE_MECHANICAL) 
          || dyingUnit.IsIllusion() 
          || dyingUnit.IsType(UNIT_TYPE_SUMMONED))

        return;
      AddSpecialEffect(@"Abilities\Spells\Items\AIil\AIilTarget.mdl", _returnPoint.X, _returnPoint.Y)
        .SetLifespan();
      CreateUnit(dyingUnit.OwningPlayer(), dyingUnit.GetTypeId(), _returnPoint.X, _returnPoint.Y, 0);
    }
  }
}