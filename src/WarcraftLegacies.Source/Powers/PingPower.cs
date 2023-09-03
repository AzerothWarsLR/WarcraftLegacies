using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Powers
{
  /// <summary>
  /// Pings the specified <see cref="LegendaryHero"/> on the map
  /// </summary>
  public sealed class PingPower : Power
  {
    private readonly LegendaryHero _arthas;
    private timer _coodownTimer;
    private int _pingTime;
    private readonly int _cooldown;


    /// <param name="heroToPing">The pinged hero</param>
    /// <param name="name">Name of the power</param>
    /// <param name="pingTime">The duration of the ping</param>
    /// <param name="cooldown">The cooldown of the power in seconds</param>
    public PingPower(LegendaryHero heroToPing, string name, int pingTime, int cooldown)
    {
      Usable = true;
      _pingTime = pingTime;
      _cooldown = cooldown;
      _arthas = heroToPing;
      _coodownTimer = CreateTimer();
      Name = name;
      IconName = "HelmofDomination";
      Description = $"Ping {heroToPing.Name} on the map {pingTime} for seconds.\n{cooldown} seconds cooldown.";
    }

    ///<inheritdoc/>
    public override void OnAdd(player whichPlayer)
    {
      if (GetLocalPlayer() != whichPlayer)
        return;
      if (_arthas.Unit != null)
      {
        PingMinimap(_arthas.Unit.GetPosition().X, _arthas.Unit.GetPosition().Y, _pingTime);
      }
    }

    ///<inheritdoc/>
    public override void OnRemove(player whichPlayer)
    {
      _coodownTimer.Destroy();
    }

    ///<inheritdoc/>
     public override void OnUse(player whichPlayer)
    {
      if (OnCooldown)
        return;
      if (_arthas.Unit == null || !_arthas.Unit.IsAlive()) return;
      OnCooldown = true;
      _coodownTimer.Start(_cooldown, false, () =>
      {
        OnCooldown = false;
      });
      if (GetLocalPlayer() == whichPlayer)
        PingMinimap(_arthas.Unit.GetPosition().X, _arthas.Unit.GetPosition().Y, _pingTime);
    }
  }
}
