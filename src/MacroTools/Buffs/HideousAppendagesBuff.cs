using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Libraries;
using WCSharp.Buffs;
using WCSharp.Events;

namespace MacroTools.Buffs
{
  /// <summary>
  ///   Surrounds the buff holder with tentacles.
  /// </summary>
  public sealed class HideousAppendagesBuff : PassiveBuff
  {
    private readonly List<unit> _tentacles = new();

    public HideousAppendagesBuff(unit caster, unit target) : base(caster, target)
    {
    }

    public int TentacleUnitTypeId { get; init; } = FourCC("hfoo");
    public int TentacleCount { get; init; } = 6;

    /// <summary>
    ///   How far away from the buff holder to position the tentacles.
    /// </summary>
    public float RadiusOffset { get; init; } = 700;

    public override void OnDispose()
    {
      foreach (var tentacle in _tentacles) 
        KillUnit(tentacle);
      
      PlayerUnitEvents.Unregister(UnitEvent.ChangesOwner, OnOwnershipChanged, Target);
    }

    public override void OnApply()
    {
      SpawnTentacles();
      RepositionTentacles();
      PlayerUnitEvents.Register(UnitEvent.ChangesOwner, OnOwnershipChanged, Target);
    }

    private void OnOwnershipChanged()
    {
      foreach (var tentacle in _tentacles) 
        SetUnitOwner(tentacle, Target.OwningPlayer(), true);
    }

    private void SpawnTentacles()
    {
      for (var i = 0; i < TentacleCount; i++)
      {
        var tentacle = CreateUnit(GetOwningPlayer(Target), TentacleUnitTypeId, GetUnitX(Target), GetUnitY(Target),
          0);
        SetUnitAnimation(tentacle, "birth");
        QueueUnitAnimation(tentacle, "stand");
        SetUnitVertexColor(tentacle, 255, 255, 255, 255);
        UnitAddAbility(tentacle, FourCC("Aloc"));
        SetUnitInvulnerable(tentacle, true);
        SetUnitPathing(tentacle, false);
        _tentacles.Add(tentacle);
      }
    }
    
    private void RepositionTentacles()
    {
      var i = 0;
      foreach (var tentacle in _tentacles)
      {
        var offsetAngle = MathEx.Pi * 2 / TentacleCount * i;
        var offsetX = GetUnitX(Target) + RadiusOffset * Cos(offsetAngle);
        var offsetY = GetUnitY(Target) + RadiusOffset * Sin(offsetAngle);
        SetUnitPosition(tentacle, offsetX, offsetY);
        i++;
      }
    }
  }
}