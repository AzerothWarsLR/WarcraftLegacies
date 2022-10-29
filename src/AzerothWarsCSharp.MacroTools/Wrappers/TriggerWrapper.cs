using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Wrappers
{
  public sealed class TriggerWrapper : IDisposable
  {
    public TriggerWrapper()
    {
      Trigger = CreateTrigger();
    }

    public trigger Trigger { get; }

    public void Dispose()
    {
      DestroyTrigger(Trigger);
    }

    /// <summary>
    /// Causes the <see cref="trigger"/> to be fired when any player executes the specified chat command.
    /// </summary>
    public void RegisterPlayerChatEvent(player whichPlayer, string chatMessageToDetect, bool exactMatchOnly)
    {
      TriggerRegisterPlayerChatEvent(Trigger, whichPlayer, chatMessageToDetect, exactMatchOnly);
    }
    
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

    ~TriggerWrapper()
    {
      DestroyTrigger(Trigger);
    }
  }
}