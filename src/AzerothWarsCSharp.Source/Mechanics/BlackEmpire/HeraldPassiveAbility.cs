using AzerothWarsCSharp.MacroTools.PassiveAbilitySystem;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public sealed class HeraldPassiveAbility : PassiveAbility
  {
    public HeraldPassiveAbility(int unitTypeId) : base(unitTypeId)
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