using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Source.Buffs;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.UnitTypeTraits;

public sealed class ResurrectionAura : UnitTypeTrait, IEffectOnCreated
{
  public float ResurrectionChance { get; init; } = 0.99f;

  public ResurrectionAura(int unitTypeId) : base(unitTypeId)
  {
  }

  public void OnCreated(unit createdUnit)
  {
    var aura = new ResurrectionAuraCaster(createdUnit, ResurrectionChance);
    AuraSystem.Add(aura);
  }
}
