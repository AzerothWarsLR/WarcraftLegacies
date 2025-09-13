using System;
using MacroTools.Libraries;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace MacroTools.Spells
{
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
        var targetX = GetUnitX(target);
        var targetY = GetUnitY(target);
        var angle = AngleOffset;
        for (var i = 0; i < SummonCount; i++)
        {
          angle += 360f / SummonCount;
          var summonX = MathEx.GetPolarOffsetX(targetX, Radius, angle);
          var summonY = MathEx.GetPolarOffsetY(targetY, Radius, angle);
          var summonFacing = MathEx.GetAngleBetweenPoints(summonX, summonY, targetX, targetY);
          var summonedUnit = CreateUnit(GetOwningPlayer(caster), SummonUnitTypeId, summonX, summonY, summonFacing);
          UnitApplyTimedLife(summonedUnit, 0, Duration);
          SetUnitAnimation(summonedUnit, "birth");
          QueueUnitAnimation(summonedUnit, "stand");
          DestroyEffect(AddSpecialEffect(Effect, summonX, summonY));
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to cast {nameof(SummonUnits)}: {ex}");
      }
    }
  }
}