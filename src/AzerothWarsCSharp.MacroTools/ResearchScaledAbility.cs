using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  /// <summary>
  /// Provides an easy way to force a research's level to always be equal to that of another.
  /// </summary>
  public static class ResearchScaledAbility
  {
    /// <summary>
    /// Once registered, the child research will always have its level set to the same level as the parent research
    /// when the parent research is researched.
    /// </summary>
    public static void Register(int parentResearch, int childResearch)
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, () =>
      {
        var triggerFaction = GetTriggerPlayer().GetFaction();
        triggerFaction?.SetObjectLevel(childResearch, triggerFaction.GetObjectLevel(parentResearch));
      }, parentResearch);
    }
  }
}