using MacroTools.Extensions;
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
    private static readonly int[] HeroXpTable = { 100, 120, 160, 220, 300 };
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
    public required float Duration { get; init; } 
    public int OriginalHeroLevel { get; init; }   
    public bool IsOriginalUnitHero { get; init; } 

    public DefensiveCocoonBuff(unit caster, unit target) : base(caster, target)
    {
    }
    
    public override void OnApply()
    {
      Target
        .SetLifePercent(100)
        .PauseEx(true)
        .Show(false);
      
      _egg = CreateUnit(Target.OwningPlayer(), EggId, GetUnitX(Target), GetUnitY(Target), 0)
        .SetTimedLife(Duration + 1)
        .SetMaximumHitpoints(MaximumHitPoints)
        .SetLifePercent(100)
        .SetArmor((int)BlzGetUnitArmor(Target))
        .SetName($"Cocoon ({Target.GetProperName()})");
      
      AddSpecialEffect(ReviveEffect, GetUnitX(Target), GetUnitY(Target))
        .SetScale(2)
        .SetLifespan();

      _deathTrigger = CreateTrigger()
        .RegisterUnitEvent(_egg, EVENT_UNIT_DEATH)
        .AddAction(() => Target.Kill());
    }

    public override void OnDispose()
    {
      _deathTrigger?.Destroy();
      Target
        .Show(true)
        .PauseEx(false);
      
      if (UnitAlive(_egg)) 
        Revive();
      else
      {
        if (IsOriginalUnitHero)
        {
          var killingUnit = GetKillingUnit();
          if (killingUnit != null)
          {
            var experienceGained = CalculateExperience(killingUnit);
            if (IsUnitType(killingUnit, UNIT_TYPE_HERO))
            {
              SetHeroXP(killingUnit, GetHeroXP(killingUnit) + experienceGained, true);
            }
          }
        }
        
        Target
          .Kill()
          .SetPosition(_egg!.GetPosition());
      }
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

    private int CalculateExperience(unit killer)
    {
      if (IsUnitType(killer, UNIT_TYPE_HERO))
      {
        var index = OriginalHeroLevel - 1;
        if (index < HeroXpTable.Length)
        {
          return HeroXpTable[index];
        }
        return HeroXpTable[^1];
      }
      
      return 5 + (OriginalHeroLevel * 5);
    }
  }
}