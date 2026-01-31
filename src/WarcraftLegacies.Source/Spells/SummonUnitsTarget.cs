using System;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class SummonUnitsTarget : Spell
{
  public int SummonUnitTypeId { get; init; } = FourCC("hfoo");
  public int SummonCount { get; init; } = 1;
  public float Duration { get; init; } = 60;
  public float Radius { get; init; } = 150;
  public float AngleOffset { get; init; } = 45;
  public string Effect { get; init; } = "";

  public SummonUnitsTarget(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    try
    {
      var targetX = target.X;
      var targetY = target.Y;
      var angle = AngleOffset;
      for (var i = 0; i < SummonCount; i++)
      {
        angle += 360f / SummonCount;
        var summonX = MathEx.GetPolarOffsetX(targetX, Radius, angle);
        var summonY = MathEx.GetPolarOffsetY(targetY, Radius, angle);
        var summonFacing = MathEx.GetAngleBetweenPoints(summonX, summonY, targetX, targetY);
        var summonedUnit = unit.Create(caster.Owner, SummonUnitTypeId, summonX, summonY, summonFacing);
        summonedUnit.ApplyTimedLife(0, Duration);
        summonedUnit.SetAnimation("birth");
        summonedUnit.QueueAnimation("stand");
        effect.Create(Effect, summonX, summonY).Dispose();
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to cast {nameof(SummonUnits)}: {ex}");
    }
  }
}
