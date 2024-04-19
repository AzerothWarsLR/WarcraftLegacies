using System;
using MacroTools.Extensions;
using WarcraftLegacies.Source.PassiveAbilities.Vengeance;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.PassiveAbilities.DefensiveCocoon
{
  /// <summary>
  /// The unit becomes an immobile cocoon, reducing their maximum hit points and fully healing them.
  /// If the cocoon survives for long enough, it revives.
  /// Otherwise, it dies.
  /// </summary>
  public sealed class DefensiveCocoonBuff : PassiveBuff
  {
    private ReversionInfo? _reversionInfo;

    /// <summary>
    /// How many maximum hit points the cocoon should have.
    /// </summary>
    public required int MaximumHitPoints { private get; init; }
    
    /// <summary>
    /// The effect when the vengeance form is exited ans the hero is revived.
    /// </summary>
    public required string ReviveEffect { private get; init; }
    
    /// <summary>
    /// The unit type ID of the vengeance form.
    /// </summary>
    public required int AlternateFormId { private get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="VengeanceBuff"/> class.
    /// </summary>
    public DefensiveCocoonBuff(unit caster, unit target) : base(caster, target)
    {
    }
    
    /// <inheritdoc />
    public override void OnApply()
    {
      Console.WriteLine("added");
      BlzSetUnitSkin(Target, AlternateFormId);

      _reversionInfo = new ReversionInfo
      {
        HitPointsRemoved = Target.GetMaximumHitPoints() - MaximumHitPoints,
        UnitTypeId = BlzGetUnitSkin(Target)
      };
      
      Target
        .SetMaximumHitpoints(MaximumHitPoints)
        .SetLifePercent(100)
        .SetTimedLife(Duration + 1);
    }

    /// <inheritdoc />
    public override void OnDispose()
    {
      Caster
        .SetMaximumHitpoints(_reversionInfo!.HitPointsRemoved)
        .SetSkin(_reversionInfo.UnitTypeId)
        .SetTimedLife(0);
      
      if (UnitAlive(Target)) 
        Revive();
    }

    private void Revive()
    {
      Target.SetMaximumHitpoints(Target.GetMaximumHitPoints() + _reversionInfo!.HitPointsRemoved);
      
      AddSpecialEffect(ReviveEffect, GetUnitX(Target), GetUnitY(Target))
        .SetLifespan();
    }

    /// <summary>
    /// Information about the unit from before it was transformed into a cocoon, so that it can be cleanly reverted.
    /// </summary>
    private sealed class ReversionInfo
    {
      public required int HitPointsRemoved { get; init; }
      
      public required int UnitTypeId { get; init; }
    }
  }
}