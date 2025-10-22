using MacroTools.PassiveAbilitySystem;
using WarcraftLegacies.Source.Buffs;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.PassiveAbilities;

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
