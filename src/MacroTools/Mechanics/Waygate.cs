using System;
using MacroTools.Wrappers;

namespace MacroTools.Mechanics;

public sealed class Waygate
{
  private readonly TriggerWrapper _constructTrigger = new();
  private readonly TriggerWrapper _deathTrigger = new();

  private readonly unit _unit;

  private bool _isConstructed;

  public Waygate(unit whichUnit)
  {
    _unit = whichUnit;
    _constructTrigger.RegisterUnitEvent(_unit, unitevent.ConstructFinish);
    _constructTrigger.AddAction(OnConstructed);
    _deathTrigger.RegisterUnitEvent(_unit, unitevent.Death);
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
    if (Sister?._isConstructed != true)
    {
      return;
    }

    Connect(Sister);
    Sister.Connect(this);
  }

  private void Disconnect()
  {
    _unit.WaygateActive = false;
  }

  private void Connect(Waygate otherWaygate)
  {
    _unit.SetWaygateDestination(otherWaygate._unit.X, otherWaygate._unit.Y);
    _unit.WaygateActive = true;
  }
}
