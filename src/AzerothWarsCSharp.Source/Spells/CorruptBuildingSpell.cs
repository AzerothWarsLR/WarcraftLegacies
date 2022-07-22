using AzerothWarsCSharp.MacroTools.SpellSystem;
using AzerothWarsCSharp.Source.Buffs;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Spells
{
  public sealed class CorruptBuildingSpell : Spell
  {
    private readonly int _bonusIncome;
    private readonly int _bonusHealth;

    public CorruptBuildingSpell(int id, int bonusIncome, int bonusHealth) : base(id)
    {
      _bonusIncome = bonusIncome;
      _bonusHealth = bonusHealth;
    }
    
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