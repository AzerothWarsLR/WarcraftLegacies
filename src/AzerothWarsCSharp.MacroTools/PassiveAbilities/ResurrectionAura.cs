using AzerothWarsCSharp.MacroTools.Buffs;
using AzerothWarsCSharp.MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.PassiveAbilities
{
  public sealed class ResurrectionAura : PassiveAbility
  {
    public float ResurrectionChance { get; init; } = 0.35f;
    
    public ResurrectionAura(int unitTypeId) : base(unitTypeId)
    {
    }

    public override void OnCreated()
    {
      var aura = new ResurrectionAuraCaster(GetTriggerUnit(), ResurrectionChance);
      AuraSystem.Add(aura);
    }
  }
}