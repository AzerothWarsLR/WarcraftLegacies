using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Powers
{
  /// <summary>
  /// Causes dying units to spawn a new unit at a predefined location.
  /// </summary>
  public sealed class Windforging : Power
  {
    private readonly float _chance;
    private readonly Point _returnPoint;
    private readonly Rectangle _noReturnRect;
    private readonly int _unitTypeId;

    /// <summary>
    /// The condition that units need to pass to be eligible.
    /// </summary>
    public Func<unit, bool> EligibilityCondition { get; init; } = _ => true;

    /// <summary>
    /// Initializes a new instance of the <see cref="Windforging"/> class.
    /// </summary>
    /// <param name="chance">The chance that dying units have to respawn.</param>
    /// <param name="returnPoint">Where the spawned units appear.</param>
    /// <param name="returnPointName">A user-friendly name for where the spawned units appear.</param>
    /// <param name="noReturnRect">Units that die within this area are not considered for the power.</param>
    /// <param name="unitTypeId">What sort of unit is spawned.</param>
    public Windforging(int unitTypeId, float chance, Point returnPoint, string returnPointName, Rectangle noReturnRect)
    {
      _unitTypeId = unitTypeId;
      _chance = chance;
      _returnPoint = returnPoint;
      _noReturnRect = noReturnRect;
      Description = $"Your non-Resistant units have a {chance * 100}% chance to be transfigured into as a {GetObjectName(_unitTypeId)} in {returnPointName} upon death.";
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
      CreateUnit(dyingUnit.OwningPlayer(), _unitTypeId, _returnPoint.X, _returnPoint.Y, 0);
    }
  }
}