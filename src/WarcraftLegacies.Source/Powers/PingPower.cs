using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Powers
{
  /// <summary>
  /// Pings the specified <see cref="LegendaryHero"/> on the map
  /// </summary>
  public class PingPower : Power
  {
    private readonly LegendaryHero _arthas;
    private timer _pingTimer;
    private int _pingTime;
    private int _pingInterval;
    private bool _pingPeriodically;

    /// <param name="heroToPing">The pinged hero</param>
    /// <param name="name">Name of the power</param>
    /// <param name="pingTime">The duration of the ping</param>
    /// <param name="pingInterval">The interval at which the ping occurs</param>
    /// <param name="pingPeriodically">If true repeats the ping, eles only pings once</param>
    public PingPower(LegendaryHero heroToPing,string name, int pingTime, int pingInterval, bool pingPeriodically)
    {
      _pingTime = pingTime;
      _pingInterval = pingInterval;
      _arthas = heroToPing;
      _pingPeriodically = pingPeriodically;
      _pingTimer = CreateTimer();
      Name = name;
      Description = $"Ping {heroToPing.Name} on the map every {pingInterval / 60} turns for {pingTime} seconds.";
    }

    ///<inheritdoc/>
    public override void OnAdd(player whichPlayer)
    {
      _pingTimer.Start(_pingInterval, _pingPeriodically, PingArthas);
    }

    ///<inheritdoc/>
    public override void OnRemove(player whichPlayer)
    {
      _pingTimer.Destroy();
    }

    private void PingArthas()
    {
      if (_arthas.Unit != null)
      {
        PingMinimap(_arthas.Unit.GetPosition().X, _arthas.Unit.GetPosition().Y, _pingTime);
      }
    }
  }
}
