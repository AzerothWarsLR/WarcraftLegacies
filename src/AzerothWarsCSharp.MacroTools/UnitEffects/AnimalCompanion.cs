using AzerothWarsCSharp.MacroTools.Buffs;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Buffs;

namespace AzerothWarsCSharp.MacroTools.UnitEffects
{
  /// <summary>
  ///   The ability holder summons a unit whenever it attacks, up to one unit alive at a time.
  /// </summary>
  public sealed class AnimalCompanion : UnitEffect
  {
    private readonly int _summonUnitTypeId;

    public AnimalCompanion(int unitTypeId, int summonUnitTypeId) : base(unitTypeId)
    {
      _summonUnitTypeId = summonUnitTypeId;
    }

    public float Duration { get; init; } = 30;

    /// <summary>
    ///   Appears at the location of the summoned unit when it is summoned.
    /// </summary>
    public string SpecialEffect { get; init; } = @"Abilities\Spells\Orc\FeralSpirit\feralspiritdone.mdl";

    public override void OnDealsDamage()
    {
      var animalCompanionBuff =
        new AnimalCompanionCaster(GetEventDamageSource(), GetEventDamageSource(), _summonUnitTypeId)
        {
          Duration = Duration,
          SpecialEffect = SpecialEffect
        };
      BuffSystem.Add(animalCompanionBuff, StackBehaviour.Stack);
    }
  }
}