using System.Linq;
using MacroTools.Extensions;
using MacroTools.Hazards;
using MacroTools.Powers;
using WCSharp.Buffs;
using static War3Api.Common;

namespace MacroTools.Buffs
{
  /// <summary>
  /// Units with this buff harvest oil from <see cref="OilPool"/>s around them.
  /// </summary>
  public sealed class OilHarvesterBuff : TickingBuff
  {
    private readonly OilPower _oilPower;

    /// <summary>
    /// The radius in which this unit can harvest from <see cref="OilPool"/>s.
    /// </summary>
    public float Radius { get; init; }
    
    /// <summary>
    /// How much oil this buff harvests per second.
    /// </summary>
    public int OilHarvestedPerSecond { get; init; }
    
    /// <summary>
    /// Construct an <see cref="OilUserBuff"/>.
    /// </summary>
    /// <param name="target">The unit with the buff.</param>
    /// <param name="oilPower">The power providing oil to the unit with the buff.</param>
    public OilHarvesterBuff(unit target, OilPower oilPower) : base(target, target)
    {
      Duration = float.MaxValue;
      _oilPower = oilPower;
      Interval = 1f;
    }

    /// <inheritdoc />
    public override void OnTick()
    {
      var nearbyOilPools = _oilPower.GetAllOilPools()
        .Where(x =>
        {
          var harvesterPosition = Target.GetPosition();
          var oilPoolPosition = x.Position;
          return WCSharp.Shared.Util.DistanceBetweenPoints(harvesterPosition.X, harvesterPosition.Y, oilPoolPosition.X,
            oilPoolPosition.Y) < Radius;
        }).ToList();
      if (nearbyOilPools.Count == 0)
      {
        KillUnit(Target);
        return;
      }
      foreach (var oilPool in nearbyOilPools) 
        oilPool.Harvest(OilHarvestedPerSecond);
    }
  }
}