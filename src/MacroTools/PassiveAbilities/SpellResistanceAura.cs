using MacroTools.Buffs;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;


namespace MacroTools.PassiveAbilities
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