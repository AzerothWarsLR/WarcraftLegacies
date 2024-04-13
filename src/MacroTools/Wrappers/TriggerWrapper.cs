using System;
using static War3Api.Common;

namespace MacroTools.Wrappers
{
  public sealed class TriggerWrapper : IDisposable
  {
    public TriggerWrapper()
    {
      Trigger = CreateTrigger();
    }

    public trigger Trigger { get; }

    /// <inheritdoc />
    public void Dispose() => DestroyTrigger(Trigger);

    public void RegisterUnitEvent(unit whichUnit, unitevent whichEvent)
    {
      TriggerRegisterUnitEvent(Trigger, whichUnit, whichEvent);
    }

    public void RegisterFrameEvent(framehandle frame, frameeventtype frameeventtype)
    {
      BlzTriggerRegisterFrameEvent(Trigger, frame, frameeventtype);
    }

    public void AddAction(Action actionFunc)
    {
      TriggerAddAction(Trigger, actionFunc);
    }
  }
}