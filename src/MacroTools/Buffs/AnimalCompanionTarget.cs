using WCSharp.Buffs;

namespace MacroTools.Buffs
{
  /// <summary>
  /// Causes the buff holder to die when the corresponding <see cref="AnimalCompanionCaster"/> buff is removed.
  /// </summary>
  public sealed class AnimalCompanionTarget : PassiveBuff
  {
    /// <summary>
    /// Appears when the caster dies for any reason.
    /// </summary>
    public string SpecialEffect { get; init; } = @"Abilities\Spells\Orc\FeralSpirit\feralspiritdone.mdl";
    
    private readonly AnimalCompanionCaster? _casterBuff;

    public override void OnDeath(bool killingBlow)
    {
      base.OnDeath(killingBlow);
      Active = false;
    }

    public override void OnDispose()
    {
      var tempEffect = AddSpecialEffect(SpecialEffect, GetUnitX(Target), GetUnitY(Target));
      DestroyEffect(tempEffect);
      KillUnit(Target);
      RemoveUnit(Target);
      base.OnDispose();
    }

    public override void OnApply()
    {
      UnitApplyTimedLife(Target, 0, Duration);
    }
    
    public AnimalCompanionTarget(unit caster, unit? target, AnimalCompanionCaster animalCompanionCasterBuff) : base(caster, target)
    {
      _casterBuff = animalCompanionCasterBuff;
    }
  }
}