using System;

namespace MacroTools.Wrappers;

public sealed class TriggerWrapper : IDisposable
{
  public TriggerWrapper()
  {
    Trigger = trigger.Create();
  }

  public trigger Trigger { get; }

  /// <inheritdoc />
  public void Dispose() => Trigger.Dispose();

  public void RegisterUnitEvent(unit whichUnit, unitevent whichEvent)
  {
    Trigger.RegisterUnitEvent(whichUnit, whichEvent);
  }

  public void RegisterFrameEvent(framehandle frame, frameeventtype frameeventtype)
  {
    Trigger.RegisterFrameEvent(frame, frameeventtype);
  }

  public void AddAction(Action actionFunc)
  {
    Trigger.AddAction(actionFunc);
  }
}
