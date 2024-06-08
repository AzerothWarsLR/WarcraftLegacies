using System.Collections.Generic;
using MacroTools.Libraries;
using WCSharp.Buffs;
using static War3Api.Common;


namespace MacroTools.Buffs
{
  /// <summary>
  ///   Surrounds the buff holder with tentacles.
  /// </summary>
  public sealed class HideousAppendagesBuff : TickingBuff
  {
    private readonly List<unit> _tentacles = new();

    public HideousAppendagesBuff(unit caster, unit target) : base(caster, target)
    {
      Interval = 0.01f;
    }

    public int TentacleUnitTypeId { get; init; } = FourCC("hfoo");
    public int TentacleCount { get; init; } = 6;

    /// <summary>
    ///   How far away from the buff holder to position the tentacles.
    /// </summary>
    public float RadiusOffset { get; init; } = 700;

    public override void OnDispose()
    {
      foreach (var tentacle in _tentacles) KillUnit(tentacle);
    }

    public override void OnApply()
    {
      SpawnTentacles();
      RepositionTentacles();
    }

    private void SpawnTentacles()
    {
      for (var i = 0; i < TentacleCount; i++)
      {
        var newTentacle = CreateUnit(GetOwningPlayer(Target), TentacleUnitTypeId, GetUnitX(Target), GetUnitY(Target),
          0);
        SetUnitAnimation(newTentacle, "birth");
        SetUnitAnimation(newTentacle, "stand");
        SetUnitVertexColor(newTentacle, 255, 255, 255, 255);
        UnitAddAbility(newTentacle, FourCC("Aloc"));
        SetUnitPathing(newTentacle, false);
        _tentacles.Add(newTentacle);
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

    public override void OnTick()
    {
      RepositionTentacles();
    }
  }
}