using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;
using Environment = MacroTools.Libraries.Environment;

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

    private effect? _progressEffect;

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
      {
        ShowUnit(unit, false);
        SetUnitInvulnerable(unit, true);
      }

      Effect = AddSpecialEffect(@"Abilities\Spells\Undead\Darksummoning\DarkSummonTarget.mdl", TargetPosition.X,
        TargetPosition.Y);
      
      _progressEffect = AddSpecialEffect("war3mapImported\\Progressbar10sec.mdx", TargetPosition.X, TargetPosition.Y)
        .SetTimeScale(10 / Duration)
        .SetColor(Caster.OwningPlayer())
        .SetHeight(185f + Environment.GetPositionZ(TargetPosition));
    }

    /// <inheritdoc />
    public override void OnDispose()
    {
      Effect?.Destroy();
      _progressEffect?.Destroy();
      
      if (!UnitAlive(Caster))
      {
        var amountToKill = (int)(UnitsToMove.Count * DeathPenalty);
        foreach (var unit in UnitsToMove.Take(amountToKill)) 
          KillUnit(unit);
      }
      
      foreach (var unit in UnitsToMove)
      {
        ShowUnit(unit, true);
        unit.SetPosition(TargetPosition);
        SetUnitInvulnerable(unit, false);
      }
    }
  }
}