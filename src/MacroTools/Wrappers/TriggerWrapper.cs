using System;


namespace MacroTools.Wrappers
{
  public sealed class TriggerWrapper : IDisposable
  {
    public trigger Trigger { get; } = CreateTrigger();

    /// <inheritdoc />
    public void Dispose() => DestroyTrigger(Trigger);

    public void RegisterUnitEvent(unit whichUnit, unitevent whichEvent)
    {
      TriggerRegisterUnitEvent(Trigger, whichUnit, whichEvent);
    }

    public void AddAction(Action actionFunc)
    {
      TriggerAddAction(Trigger, actionFunc);
    }
  }
}