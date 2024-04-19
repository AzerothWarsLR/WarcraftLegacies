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
    private unit? _egg;
    private trigger? _deathTrigger;

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
    public required int EggId { private get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="VengeanceBuff"/> class.
    /// </summary>
    public DefensiveCocoonBuff(unit caster, unit target) : base(caster, target)
    {
    }
    
    /// <inheritdoc />
    public override void OnApply()
    {
      Target
        .SetLifePercent(100)
        .Show(false);
      
      _egg = CreateUnit(Target.OwningPlayer(), EggId, GetUnitX(Target), GetUnitY(Target), 0)
        .SetTimedLife(Duration + 1)
        .SetMaximumHitpoints(MaximumHitPoints)
        .SetLifePercent(100)
        .SetArmor((int)BlzGetUnitArmor(Target))
        .SetName($"Cocoon ({Target.GetProperName()})");

      Console.WriteLine();
      
      AddSpecialEffect(ReviveEffect, GetUnitX(Target), GetUnitY(Target))
        .SetScale(2)
        .SetLifespan();

      _deathTrigger = CreateTrigger()
        .RegisterUnitEvent(_egg, EVENT_UNIT_DEATH)
        .AddAction(() => Target.Kill());
    }

    /// <inheritdoc />
    public override void OnDispose()
    {
      _deathTrigger?.Destroy();
      Target.Show(true);
      
      if (UnitAlive(_egg)) 
        Revive();
      else
        Target.Kill();
    }

    private void Revive()
    {
      Target.SetCurrentHitpoints(_egg!.GetCurrentHitPoints());
      _egg!.Kill();
      Target.SetPosition(_egg!.GetPosition());
      
      AddSpecialEffect(ReviveEffect, GetUnitX(Target), GetUnitY(Target))
        .SetScale(2)
        .SetLifespan();
    }
  }
}