using System.Collections.Generic;
using MacroTools.Libraries;
using WCSharp.Buffs;
using WCSharp.Events;

namespace MacroTools.Buffs;

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
    {
      tentacle.Kill();
    }

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
    {
      tentacle.SetOwner(Target.Owner);
    }
  }

  private void SpawnTentacles()
  {
    for (var i = 0; i < TentacleCount; i++)
    {
      var tentacle = unit.Create(Target.Owner, TentacleUnitTypeId, Target.X, Target.Y, 0);
      tentacle.SetAnimation("birth");
      tentacle.QueueAnimation("stand");
      tentacle.SetVertexColor(255, 255, 255);
      tentacle.AddAbility(FourCC("Aloc"));
      tentacle.IsInvulnerable = true;
      tentacle.SetPathing(false);
      _tentacles.Add(tentacle);
    }
  }

  private void RepositionTentacles()
  {
    var i = 0;
    foreach (var tentacle in _tentacles)
    {
      var offsetAngle = MathEx.Pi * 2 / TentacleCount * i;
      var offsetX = Target.X + RadiusOffset * Cos(offsetAngle);
      var offsetY = Target.Y + RadiusOffset * Sin(offsetAngle);
      tentacle.SetPosition(offsetX, offsetY);
      i++;
    }
  }
}
