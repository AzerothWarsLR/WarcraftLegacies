using MacroTools.Buffs;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;

namespace MacroTools.PassiveAbilities;

public sealed class SpellResistanceAura : PassiveAbility, IEffectOnCreated
{
  public SpellResistanceAura(int unitTypeId) : base(unitTypeId)
  {
  }

  public void OnCreated(unit createdUnit)
  {
    var aura = new SpellResistanceAuraCaster(createdUnit);
    AuraSystem.Add(aura);
  }
}
