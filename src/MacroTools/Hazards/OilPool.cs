using System;
using MacroTools.Extensions;
using MacroTools.Powers;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Hazards
{
  /// <summary>
  /// A pool of oil that can be harvested for oil.
  /// </summary>
  public sealed class OilPool : Hazard
  {
    private readonly OilPower _oilPower;
    private readonly effect _effect;
    
    /// <inheritdoc />
    public override bool Active { get; set; }
    
    /// <summary>
    /// The amount of oil left in the pool.
    /// </summary>
    public int OilAmount { get; set; }
    
    /// <summary>
    /// Initializes a new instance of the OilPool class.
    /// </summary>
    /// <param name="position">Where the oil pool should be.</param>
    /// <param name="effectPath">A path to a model representing the oil pool.</param>
    /// <param name="oilPower">Where to put any oil harvested.</param>
    public OilPool(Point position, string effectPath, OilPower oilPower) : base(null, position.X, position.Y)
    {
      _oilPower = oilPower;
      _effect = AddSpecialEffect(effectPath, position.X, position.Y)
        .SetScale(5)
        .SetHeight(Libraries.Environment.GetPositionZ(position));
    }

    /// <inheritdoc />
    protected override void OnDispose() => _effect.Destroy();

    /// <summary>
    /// Harvest an amount of oil from the pool.
    /// </summary>
    public void Harvest(int oilHarvestedPerSecond)
    {
      var amountToHarvest = Math.Min(oilHarvestedPerSecond, OilAmount);
      OilAmount -= amountToHarvest;
      _oilPower.Amount += amountToHarvest;
      
      if (OilAmount <= 0) 
        Active = false;
    }
  }
}