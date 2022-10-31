using WarcraftLegacies.MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Mechanics.BlackEmpire
{
  public sealed class HeraldPassiveAbility : PassiveAbility
  {
    public HeraldPassiveAbility(int unitTypeId) : base(unitTypeId)
    {
    }

    public override void OnCreated(unit createdUnit)
    {
      var buff = new HeraldBuff(GetTriggerUnit(), GetTriggerUnit())
      {
        Duration = float.MaxValue
      };
      BuffSystem.Add(buff);
    }
  }
}