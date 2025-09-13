using MacroTools.Buffs;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// Any unit with this effect increases its owner's income.
  /// </summary>
  public sealed class ProvidesIncome : PassiveAbility
  {
    private readonly int _income;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProvidesIncome"/> class.
    /// </summary>
    /// <param name="unitTypeId"><inheritdoc /></param>
    /// <param name="income">The amount of extra gold income the unit grants.</param>
    public ProvidesIncome(int unitTypeId, int income) : base(unitTypeId)
    {
      _income = income;
    }

    private void ApplyBuff()
    {
      var triggerUnit = GetTriggerUnit();
      var buff = new IncomeBuff(triggerUnit, triggerUnit, _income);
      BuffSystem.Add(buff, StackBehaviour.Stack);
    }

    /// <inheritdoc />
    public override void OnUpgrade()
    {
      ApplyBuff();
    }

    /// <inheritdoc />
    public override void OnConstruction()
    {
      ApplyBuff();
    }

    /// <inheritdoc />
    public override void OnCreated(unit createdUnit)
    {
      if (!IsUnitType(createdUnit, UNIT_TYPE_STRUCTURE)) 
        ApplyBuff();
    }
  }
}