using System;

namespace AzerothWarsCSharp.Source.Libraries.Wrappers
{
  public class TriggerWrapper
  {
    public TriggerWrapper()
    {
      Trigger = CreateTrigger();
    }

    public trigger Trigger { get; }

    public void RegisterFrameEvent(framehandle frame, frameeventtype frameeventtype)
    {
      BlzTriggerRegisterFrameEvent(Trigger, frame, frameeventtype);
    }

    public void AddAction(Action actionFunc)
    {
      TriggerAddAction(Trigger, actionFunc);
    }

    ~TriggerWrapper()
    {
      DestroyTrigger(Trigger);
    }
  }
}