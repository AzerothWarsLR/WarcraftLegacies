using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Mechanics.DemonGates
{
  /// <summary>
  /// Units with this buff will periodically spawn units from themselves.
  /// </summary>
  public sealed class DemonGateBuff : TickingBuff
  {
    /// <summary>
    /// The special effect that appears on created demons for a brief period.
    /// </summary>
    public string SpawnEffectPath { get; init; } = "";

    /// <summary>
    /// The number of demons from this portal that can exist simultaneously.
    /// </summary>
    public int SpawnLimit { get; init; } = 12;
    
    private Point SpawnPoint
    {
      get
      {
        if (FocalDemonGateBuff.Instance != null)
        {
          return FocalDemonGateBuff.Instance.SpawnPoint;
        }

        var targetPosition = Target.GetPosition();
        var offsetPosition =
          WCSharp.Shared.Util.PositionWithPolarOffset(targetPosition.X, targetPosition.Y, SpawnDistance, FacingOffset);
        return new Point(offsetPosition.x, offsetPosition.y);
      }
    }

    private Point RallyPoint => 
      FocalDemonGateBuff.Instance != null ? FocalDemonGateBuff.Instance.RallyPoint : Target.GetRallyPoint();

    private readonly int _demonUnitTypeId;
    private readonly float _spawnInterval;
    private readonly int _spawnCount;
    private readonly int _toggleBuffTypeId;
    private float _progress;
    private readonly List<unit> _spawnedDemons = new();

    private const float FacingOffset = -45f; //Demon gate model is spun around weirdly so this reverses that for code
    private const float SpawnDistance = 300f; //How far away from the gate to spawn units
    
    /// <summary>
    /// Initializesa  new instance of the <see cref="DemonGateBuff"/> class.
    /// </summary>
    /// <param name="caster"><inheritdoc /></param>
    /// <param name="demonUnitTypeId">The unit to spawn.</param>
    /// <param name="spawnInterval">How frequently to spawn the unit.</param>
    /// <param name="spawnCount">How many units to spawn.</param>
    /// <param name="toggleBuffTypeId">Units will not spawn if the buff target doesn't have a buff with this ID active.</param>
    public DemonGateBuff(unit caster, int demonUnitTypeId, float spawnInterval, int spawnCount, int toggleBuffTypeId) :
      base(caster, caster)
    {
      _demonUnitTypeId = demonUnitTypeId;
      _spawnInterval = spawnInterval;
      _spawnCount = spawnCount;
      _toggleBuffTypeId = toggleBuffTypeId;
      Interval = 1;
    }

    /// <inheritdoc />
    public override void OnApply() => Target.IssueOrder("setrally", Target.GetPosition());

    /// <inheritdoc />
    public override void OnTick()
    {
      _progress += Interval;
      Caster.SetMaximumMana((int)_progress);
      if (_progress >= _spawnInterval
          && Caster.OwningPlayer().GetFoodUsed() < Caster.OwningPlayer().GetFoodCap()
          && Caster.OwningPlayer().GetFoodUsed() < Caster.OwningPlayer().GetFoodCapCeiling()
          && GetUnitAbilityLevel(Caster, _toggleBuffTypeId) > 0
          && _spawnedDemons.Count < SpawnLimit)
      {
        SpawnDemon();
      }
    }

    private void SpawnDemon()
    {
      for (var i = 0; i < _spawnCount; i++)
      {
        _spawnedDemons.Add(CreateUnit(Target.OwningPlayer(), _demonUnitTypeId, SpawnPoint.X, SpawnPoint.Y,
          Target.GetFacing() + FacingOffset).IssueOrder("attack", RallyPoint));
      }
      AddSpecialEffect(SpawnEffectPath, SpawnPoint.X, SpawnPoint.Y).SetLifespan();
    }
  }
}