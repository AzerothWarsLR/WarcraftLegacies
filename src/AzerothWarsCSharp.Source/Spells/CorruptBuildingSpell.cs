using AzerothWarsCSharp.MacroTools.SpellSystem;
using AzerothWarsCSharp.Source.Buffs;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Spells
{
  /// <summary>
  /// Corrupts a building, granting it hit extra hit points and
  /// causing it to grant the caster income for as long as it exists.
  /// </summary>
  public sealed class CorruptBuildingSpell : Spell
  {
    private readonly int _bonusIncome;
    private readonly int _bonusHealth;

    /// <summary>
    /// Initializes an instance of the <see cref="CorruptBuildingSpell"/> class.
    /// </summary>
    /// <param name="id"><inheritdoc /></param>
    /// <param name="bonusIncome">The casting player gets this much extra income as long as the corrupted building is alive.</param>
    /// <param name="bonusHealth">The corrupted building gets this much extra hit points.</param>
    public CorruptBuildingSpell(int id, int bonusIncome, int bonusHealth) : base(id)
    {
      _bonusIncome = bonusIncome;
      _bonusHealth = bonusHealth;
    }
    
    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, float targetX, float targetY)
    {
      SetUnitState(target, UNIT_STATE_LIFE, GetUnitState(target, UNIT_STATE_MAX_LIFE));
      var buff = new CorruptBuildingBuff(caster, target, _bonusIncome, _bonusHealth)
      {
        Duration = float.MaxValue
      };
      BuffSystem.Add(buff, StackBehaviour.Stack);
    }
  }
}