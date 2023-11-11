using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Buffs
{
  public sealed class DelayedRecallBuff : PassiveBuff
  {
    /// <summary>
    /// The units that should be moved when the buff is disposed off.
    /// </summary>
    private List<unit> UnitsToMove { get;}
    
    /// <summary>
    /// The point of the casting unit when first cast.
    /// </summary>
    private Point TargetPosition { get; }
    
    /// <summary>The percentage of units to lose when the caster dies (rounded down)</summary>
    public float DeathPenalty { get; init; }
    
    /// <summary>
    /// The effect that is created when the buff is applied.
    /// </summary>
    private new effect? Effect { get; set; }

    /// <inheritdoc />
    public DelayedRecallBuff(unit caster, unit target, List<unit> unitsToMove) : base(caster, target)
    {
      UnitsToMove = unitsToMove;
      TargetPosition =  new Point(GetUnitX(caster), GetUnitY(caster));
    }
    
    /// <inheritdoc />
    public override void OnApply()
    {
      foreach (var unit in UnitsToMove) 
        unit.Show(false).SetInvulnerable(true);

      Effect = AddSpecialEffect(@"Abilities\Spells\Undead\Darksummoning\DarkSummonTarget.mdl", TargetPosition.X,
        TargetPosition.Y);
    }

    /// <inheritdoc />
    public override void OnDispose()
    {
      DestroyEffect(Effect);
      if (Math.Floor(Duration) > 0)
      {
        var amountToMove = (int)Math.Floor(UnitsToMove.Count * DeathPenalty);
        foreach (var unit in UnitsToMove.Take(UnitsToMove.Count - amountToMove)) 
          unit.Kill();
      }
      
      foreach (var unit in UnitsToMove) 
        unit.Show(true)
          .SetPosition(TargetPosition)
          .SetInvulnerable(false);
    }
  }
}