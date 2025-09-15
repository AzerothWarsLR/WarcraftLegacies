using MacroTools.PassiveAbilitySystem;
using MacroTools.Powers;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.FactionMechanics.Goblins
{
  /// <summary>
  /// Oil producers generate Oil for their owner's <see cref="OilPower"/>.
  /// </summary>
  public sealed class OilProducer : PassiveAbility, IEffectOnCreated
  {
    /// <summary>
    /// How much Oil the <see cref="OilProducer"/> produces per second.
    /// </summary>
    public int OilProducedPerSecond { get; init; }
    
    /// <inheritdoc />
    public OilProducer(int unitTypeId) : base(unitTypeId)
    {
    }

    /// <inheritdoc />
    public void OnCreated(unit createdUnit)
    {
      var oilBuff = new OilProducerBuff(createdUnit, OilProducedPerSecond);
      BuffSystem.Add(oilBuff);
    }
  }
}