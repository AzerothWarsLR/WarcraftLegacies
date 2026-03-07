using System;
using MacroTools.Wrappers;

namespace MacroTools.Legends;

/// <summary>
/// A unit bestowing invulnerability on a <see cref="Legend"/>.
/// </summary>
public sealed class Protector
{
  public Protector(unit unit)
  {
    var deathTrigger = new TriggerWrapper();
    deathTrigger.RegisterUnitEvent(unit, unitevent.Death);
    deathTrigger.AddAction(() =>
    {
      ProtectorDied?.Invoke(this);
    });
  }

  internal event Action<Protector>? ProtectorDied;
}
