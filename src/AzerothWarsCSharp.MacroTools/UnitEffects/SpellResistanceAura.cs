using AzerothWarsCSharp.MacroTools.Buffs;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.UnitEffects
{
  public sealed class SpellResistanceAura : UnitEffect
  {
    public SpellResistanceAura(int unitTypeId) : base(unitTypeId)
    {
    }

    public override void OnCreated()
    {
      var aura = new SpellResistanceAuraCaster(GetTriggerUnit());
      AuraSystem.Add(aura);
    }
  }
}