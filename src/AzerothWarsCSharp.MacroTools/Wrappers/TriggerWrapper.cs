using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Wrappers
{
  public class TriggerWrapper
  {
    public TriggerWrapper()
    {
      Trigger = CreateTrigger();
    }

    public trigger Trigger { get; }

    ~TriggerWrapper()
    {
      DestroyTrigger(Trigger);
    }
  }
}