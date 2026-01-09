using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Buffs;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.UnitTypeTraits;

public sealed class ResurrectionAura : UnitTrait, IEffectOnCreated
{
  public float ResurrectionChance { get; init; } = 0.99f;

  public void OnCreated(unit createdUnit)
  {
    var aura = new ResurrectionAuraCaster(createdUnit, ResurrectionChance);
    AuraSystem.Add(aura);
  }
}
