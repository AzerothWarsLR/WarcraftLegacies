using WCSharp.Buffs;

namespace MacroTools.Buffs
{
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
      _summonedUnit = CreateUnit(GetOwningPlayer(Caster), _summonUnitTypeId, GetUnitX(Caster), GetUnitY(Caster), GetUnitFacing(Caster));
      UnitAddType(_summonedUnit, UNIT_TYPE_SUMMONED);
      var animalCompanionTarget = new AnimalCompanionTarget(GetEventDamageSource(), _summonedUnit, this)
      {
        SpecialEffect = SpecialEffect
      };
      AddSpecialEffect(SpecialEffect, GetUnitX(_summonedUnit), GetUnitY(_summonedUnit));
      _targetBuff = animalCompanionTarget;
      _targetBuff.Duration = Duration;
      BuffSystem.Add(animalCompanionTarget);
    }

    public override void OnDispose()
    {
      KillUnit(_summonedUnit);
      if (_targetBuff != null) _targetBuff.Active = false;
      base.OnDispose();
    }
    
    public AnimalCompanionCaster(unit caster, unit target, int summonUnitTypeId) : base(caster, target)
    {
      _summonUnitTypeId = summonUnitTypeId;
    }
  }
}