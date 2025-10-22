using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Buffs;

/// <summary>
/// Summons a unit for the target when the buff is acquired.
/// The buff is removed when the summon dies, and the unit dies when the buff is removed.
/// </summary>
public sealed class AnimalCompanionCaster : PassiveBuff
{
  private readonly int _summonUnitTypeId;
  private unit? _summonedUnit;
  private AnimalCompanionTarget? _targetBuff;

  public string SpecialEffect { get; init; } = @"Abilities\Spells\Orc\FeralSpirit\feralspiritdone.mdl";

  public override StackResult OnStack(Buff newStack)
  {
    return StackResult.Stack;
  }

  public override void OnApply()
  {
    _summonedUnit = unit.Create(Caster.Owner, _summonUnitTypeId, Caster.X, Caster.Y, Caster.Facing);
    _summonedUnit.AddType(unittype.Summoned);
    var animalCompanionTarget = new AnimalCompanionTarget(@event.DamageSource, _summonedUnit, this)
    {
      SpecialEffect = SpecialEffect
    };
    effect.Create(SpecialEffect, _summonedUnit.X, _summonedUnit.Y);
    _targetBuff = animalCompanionTarget;
    _targetBuff.Duration = Duration;
    BuffSystem.Add(animalCompanionTarget);
  }

  public override void OnDispose()
  {
    _summonedUnit.Kill();
    if (_targetBuff != null)
    {
      _targetBuff.Active = false;
    }

    base.OnDispose();
  }

  public AnimalCompanionCaster(unit caster, unit target, int summonUnitTypeId) : base(caster, target)
  {
    _summonUnitTypeId = summonUnitTypeId;
  }
}
