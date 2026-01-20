using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Buffs;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.UnitTypeTraits;

public sealed class SpellResistanceAura : UnitTrait, IEffectOnCreated
{
  public void OnCreated(unit createdUnit)
  {
    var aura = new SpellResistanceAuraCaster(createdUnit);
    AuraSystem.Add(aura);
  }
}
