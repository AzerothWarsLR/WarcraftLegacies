using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Buffs;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// Corrupts a building, granting it hit extra hit points and
  /// causing it to grant the caster income for as long as it exists.
  /// </summary>
  public sealed class CorruptBuildingSpell : Spell
  {
    private readonly int _bonusGoldIncome;
    private readonly int _bonusLumberIncome;
    private readonly int _bonusHealth;

    /// <summary>
    /// Initializes an instance of the <see cref="CorruptBuildingSpell"/> class.
    /// </summary>
    /// <param name="id"><inheritdoc /></param>
    /// <param name="bonusGoldIncome">The casting player gets this much extra gold income as long as the corrupted building is alive.</param>
    /// <param name="bonusLumberIncome">The casting player gets this much extra lumber income as long as the corrupted building is alive.</param>
    /// <param name="bonusHealth">The corrupted building gets this much extra hit points.</param>
    public CorruptBuildingSpell(int id, int bonusGoldIncome, int bonusLumberIncome, int bonusHealth) : base(id)
    {
      _bonusGoldIncome = bonusGoldIncome;
      _bonusLumberIncome = bonusLumberIncome;
      _bonusHealth = bonusHealth;
    }
    
    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      SetUnitState(target, UNIT_STATE_LIFE, GetUnitState(target, UNIT_STATE_MAX_LIFE));
      var buff = new CorruptBuildingBuff(caster, target, _bonusGoldIncome, _bonusLumberIncome, _bonusHealth)
      {
        Duration = float.MaxValue
      };
      BuffSystem.Add(buff, StackBehaviour.Stack);
    }
  }
}