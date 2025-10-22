using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Source.Buffs;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.UnitTypeTraits;

public sealed class SpellResistanceAura : UnitTypeTrait, IEffectOnCreated
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
