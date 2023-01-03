using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.ResearchSystems
{
  /// <summary>
  /// Responsible for registering <see cref="Research"/>es.
  /// </summary>
  public static class ResearchManager
  {
    /// <summary>
    /// Registers a <see cref="Research"/>, allowing its effects to take place when researched.
    /// </summary>
    public static void Register(Research research)
    {
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, () =>
      {
        research.OnResearch(GetTriggerPlayer());
      }, research.ResearchTypeId);
    }
  }
}