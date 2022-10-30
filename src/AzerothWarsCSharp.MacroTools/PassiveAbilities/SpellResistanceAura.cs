using AzerothWarsCSharp.MacroTools.Buffs;
using AzerothWarsCSharp.MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.PassiveAbilities
{
  public sealed class SpellResistanceAura : PassiveAbility
  {
    public SpellResistanceAura(int unitTypeId) : base(unitTypeId)
    {
    }

    public override void OnCreated(unit createdUnit)
    {
      var aura = new SpellResistanceAuraCaster(createdUnit);
      AuraSystem.Add(aura);
    }
  }
}