using WCSharp.Buffs;
using WCSharp.Effects;
using WCSharp.Shared.Data;


namespace MacroTools.Buffs
{
  public sealed class DarkConversionBuff : PassiveBuff
  {
    /// <summary>
    /// The unit type to transform the target into.
    /// </summary>
    public int TransformUnitTypeId { get; init; } = FourCC("hfoo");

    /// <summary>
    /// The effect that appears when the unit transforms.
    /// </summary>
    public string TransformEffect { get; init; } = @"Abilities\Spells\Demon\DarkConversion\ZombifyTarget.mdl";

    /// <summary>
    /// The ability that gets given to the unit when it finishes transforming.
    /// </summary>
    public int DiseaseCloudAbilityId { get; init; }

    /// <summary>
    /// The player that should own the unit after it has been converted.
    /// </summary>
    private player ZombieOwningPlayer { get; }

    private effect? _sleepEffect;
    
    public DarkConversionBuff(player caster, unit target) : base(target, target)
    {
      ZombieOwningPlayer = caster;
    }

    public override StackResult OnStack(Buff newStack)
    {
      return StackResult.Stack;
    }
    
    public override void OnApply()
    {
      PauseUnit(Target, true);
      _sleepEffect = AddSpecialEffectTarget(@"Abilities\Spells\Undead\Sleep\SleepTarget.mdl", Target, "overhead");
    }

    public override void OnDispose()
    {
      EffectSystem.Add(AddSpecialEffect(TransformEffect, GetUnitX(Target), GetUnitY(Target)), 2);
      var oldUnitPosition = new Point(GetUnitX(Target), GetUnitY(Target));
      KillUnit(Target);
      RemoveUnit(Target);
      var zombie = CreateUnit(TargetPlayer, TransformUnitTypeId, oldUnitPosition.X, oldUnitPosition.Y, 0);
      UnitAddAbility(zombie, DiseaseCloudAbilityId);
      SetUnitOwner(zombie, ZombieOwningPlayer, true);
      DestroyEffect(_sleepEffect);
    }
  }
}