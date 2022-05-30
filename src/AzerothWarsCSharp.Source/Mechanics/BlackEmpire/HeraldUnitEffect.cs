using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public sealed class HeraldUnitEffect : UnitEffect
  {
    public HeraldUnitEffect(int unitTypeId) : base(unitTypeId)
    {
    }

    public override void OnCreated()
    {
      var buff = new HeraldBuff(GetTriggerUnit(), GetTriggerUnit())
      {
        Duration = float.MaxValue
      };
      BuffSystem.Add(buff);
    }
  }
}