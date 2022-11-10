using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace MacroTools.Mechanics.DemonGates
{
  /// <summary>
  /// Causes the unit type to periodically spawn units.
  /// </summary>
  public sealed class DemonGateType : PassiveAbility
  {
    private readonly int _demonUnitTypeId;
    private readonly float _spawnInterval;
    private readonly int _spawnCount;
    private readonly int _toggleBuffId;

    /// <summary>
    /// Initializes a new instance of the <see cref="DemonGateType"/> class.
    /// </summary>
    /// <param name="gateUnitTypeId"><inheritdoc /></param>
    /// <param name="demonUnitTypeId">The unit to spawn.</param>
    /// <param name="spawnInterval">How often to spawn the unit.</param>
    /// <param name="spawnCount">How many of the unit to spawn each time.</param>
    /// <param name="toggleBuffId">Demon Gates only function when they have a buff with this ID active.</param>
    public DemonGateType(int gateUnitTypeId, int demonUnitTypeId, float spawnInterval, int spawnCount, int toggleBuffId) : base(gateUnitTypeId)
    {
      _demonUnitTypeId = demonUnitTypeId;
      _spawnInterval = spawnInterval;
      _spawnCount = spawnCount;
      _toggleBuffId = toggleBuffId;
    }
    
    /// <inheritdoc />
    public override void OnUpgrade()
    {
      ApplyBuff(GetTriggerUnit());
    }
    
    /// <inheritdoc />
    public override void OnCreated(unit createdUnit)
    {
      ApplyBuff(createdUnit);
    }
    
    private void ApplyBuff(unit whichUnit)
    {
      var buff = new DemonGateBuff(whichUnit, _demonUnitTypeId, _spawnInterval, _spawnCount, _toggleBuffId)
      {
        SpawnEffectPath = "Abilities\\Spells\\Demon\\DarkPortal\\DarkPortalTarget.mdl",
        SpawnLimit = 12,
        Duration = float.MaxValue
      };
      BuffSystem.Add(buff, StackBehaviour.Stack);
    }
  }
}