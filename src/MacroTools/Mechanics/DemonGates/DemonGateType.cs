using MacroTools.UnitTypeTraits;
using WCSharp.Buffs;

namespace MacroTools.Mechanics.DemonGates;

/// <summary>
/// Causes the unit type to periodically spawn units.
/// </summary>
public sealed class DemonGateType : UnitTypeTrait, IEffectOnUpgrade, IEffectOnCreated
{
  private readonly int _demonUnitTypeId;
  private readonly float _spawnInterval;
  private readonly int _spawnCount;
  private readonly int _spawnLimit;

  /// <summary>
  /// Initializes a new instance of the <see cref="DemonGateType"/> class.
  /// </summary>
  /// <param name="gateUnitTypeId"><inheritdoc /></param>
  /// <param name="demonUnitTypeId">The unit to spawn.</param>
  /// <param name="spawnInterval">How often to spawn the unit.</param>
  /// <param name="spawnCount">How many of the unit to spawn each time.</param>
  /// <param name="spawnLimit">The maximum number of units that will be spawned per gate.</param>
  public DemonGateType(int gateUnitTypeId, int demonUnitTypeId, float spawnInterval, int spawnCount, int spawnLimit) : base(gateUnitTypeId)
  {
    _demonUnitTypeId = demonUnitTypeId;
    _spawnInterval = spawnInterval;
    _spawnCount = spawnCount;
    _spawnLimit = spawnLimit;
  }

  /// <inheritdoc />
  public void OnUpgrade()
  {
    ApplyBuff(@event.Unit);
  }

  /// <inheritdoc />
  public void OnCreated(unit createdUnit)
  {
    ApplyBuff(createdUnit);
  }

  private void ApplyBuff(unit whichUnit)
  {
    var buff = new DemonGateBuff(whichUnit, _demonUnitTypeId, _spawnInterval, _spawnCount)
    {
      SpawnEffectPath = "Abilities\\Spells\\Demon\\DarkPortal\\DarkPortalTarget.mdl",
      SpawnLimit = _spawnLimit,
      Duration = float.MaxValue
    };
    BuffSystem.Add(buff, StackBehaviour.Stack);
  }
}
