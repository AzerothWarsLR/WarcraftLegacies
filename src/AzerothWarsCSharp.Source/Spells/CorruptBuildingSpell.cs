using AzerothWarsCSharp.MacroTools.SpellSystem;
using AzerothWarsCSharp.Source.Buffs;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Spells
{
  public sealed class CorruptBuildingSpell : Spell
  {
    public CorruptBuildingSpell(int id) : base(id)
    {
    }

    public int BonusIncome { get; init; }

    public override void OnCast(unit caster, unit target, float targetX, float targetY)
    {
      var buff = new CorruptBuildingBuff(caster, target)
      {
        BonusIncome = BonusIncome,
        Duration = float.MaxValue
      };
      BuffSystem.Add(buff, StackBehaviour.Stack);
    }
  }
}