using AzerothWarsCSharp.MacroTools.Buffs;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Buffs;

namespace AzerothWarsCSharp.MacroTools.UnitEffects
{
  public sealed class ResurrectionAura : UnitEffect
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