using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Powers
{
  /// <summary>
  /// Pings the specified <see cref="LegendaryHero"/> on the map.
  /// </summary>
  public sealed class PingPower : Power
  {
    private readonly LegendaryHero _targetHero;
    private readonly timer _coodownTimer;
    private readonly int _pingTime;
    private readonly int _cooldown;
    private trigger? _loadTrigger;
    private trigger? _unloadTrigger;
    private trigger? _transportKilledTrigger;
    private unit? _transportContainingHero;
    
    /// <param name="heroToPing">The <see cref="LegendaryHero"/> to ping.</param>
    /// <param name="name">Name of the power.</param>
    /// <param name="pingTime">How long the ping should remain on the minimap.</param>
    /// <param name="cooldown">The cooldown of the power in seconds.</param>
    public PingPower(LegendaryHero heroToPing, string name, int pingTime, int cooldown)
    {
      Usable = true;
      _pingTime = pingTime;
      _cooldown = cooldown;
      _targetHero = heroToPing;
      _coodownTimer = CreateTimer();
      Name = name;
      IconName = "HelmofDomination";
      Description = $"Ping {heroToPing.Name} on the map {pingTime} for seconds.";
    }

    ///<inheritdoc/>
    public override void OnAdd(player whichPlayer)
    {
      if (_targetHero.Unit == null)
        return;

      _loadTrigger = CreateLoadTrigger(_targetHero.Unit);
    }

    ///<inheritdoc/>
    public override void OnRemove(player whichPlayer)
    {
      _coodownTimer.Destroy();
      _loadTrigger?.Destroy();
      _unloadTrigger?.Destroy();
      _transportKilledTrigger?.Destroy();
    }

    ///<inheritdoc/>
    public override void OnUse(player whichPlayer)
    {
      if (OnCooldown)
        return;

      if (_targetHero.Unit == null || !_targetHero.Unit.IsAlive()) return;
      OnCooldown = true;
      _coodownTimer.Start(_cooldown, false, () => { OnCooldown = false; });

      var pingTarget = _transportContainingHero ?? _targetHero.Unit;
      if (pingTarget == null)
        return;

      if (GetLocalPlayer() == whichPlayer)
        PingMinimap(pingTarget.GetPosition().X, pingTarget.GetPosition().Y, _pingTime);
    }
    
    private trigger CreateLoadTrigger(unit target)
    {
      return CreateTrigger()
        .RegisterUnitEvent(target, EVENT_UNIT_LOADED)
        .AddAction(() =>
        {
          _unloadTrigger?.Destroy();
          _transportKilledTrigger?.Destroy();
          
          _transportContainingHero = GetTransportUnit();
          _unloadTrigger = CreateUnloadTrigger(_transportContainingHero);
          _transportKilledTrigger = CreateTransportDestroyedTrigger(_transportContainingHero);
        });
    }

    private trigger CreateUnloadTrigger(unit transport)
    {
      return CreateTrigger()
        .RegisterUnitEvent(transport, EVENT_UNIT_ISSUED_TARGET_ORDER)
        .RegisterUnitEvent(transport, EVENT_UNIT_ISSUED_POINT_ORDER)

        .AddAction(() =>
        {
          if (WasTargetHeroUnloaded()) 
            ClearTransportData();
        });
    }
    
    private trigger CreateTransportDestroyedTrigger(unit transport) =>
      CreateTrigger()
        .RegisterUnitEvent(transport, EVENT_UNIT_DEATH)
        .AddAction(ClearTransportData);
    
    private bool WasTargetHeroUnloaded()
    {
      var issuedOrderName = OrderId2String(GetIssuedOrderId());
      return issuedOrderName == "unloadall" ||
             (issuedOrderName == "unload" && GetOrderTargetUnit() == _targetHero.Unit);
    }
    
    private void ClearTransportData()
    {
      _transportContainingHero = null;
      _unloadTrigger?.Destroy();
      _transportKilledTrigger?.Destroy();
    }
  }
}
