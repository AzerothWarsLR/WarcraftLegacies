using System;
using MacroTools.Wrappers;
using static War3Api.Common;

namespace MacroTools.Mechanics
{
  public sealed class Waygate
  {
    private readonly TriggerWrapper _constructTrigger = new();
    private readonly TriggerWrapper _deathTrigger = new();

    private readonly unit _unit;

    private bool _isConstructed;

    public Waygate(unit whichUnit)
    {
      _unit = whichUnit;
      _constructTrigger.RegisterUnitEvent(_unit, EVENT_UNIT_CONSTRUCT_FINISH);
      _constructTrigger.AddAction(OnConstructed);
      _deathTrigger.RegisterUnitEvent(_unit, EVENT_UNIT_DEATH);
      _deathTrigger.AddAction(OnDeath);
    }

    public Waygate? Sister { get; set; }
    public event EventHandler<Waygate>? Died;

    private void OnDeath()
    {
      Disconnect();
      Sister?.Disconnect();
      Died?.Invoke(this, this);
    }

    private void OnConstructed()
    {
      _isConstructed = true;
      if (Sister?._isConstructed != true) return;
      Connect(Sister);
      Sister.Connect(this);
    }

    private void Disconnect()
    {
      WaygateActivate(_unit, false);
    }

    private void Connect(Waygate otherWaygate)
    {
      WaygateSetDestination(_unit, GetUnitX(otherWaygate._unit), GetUnitY(otherWaygate._unit));
      WaygateActivate(_unit, true);
    }
  }
}