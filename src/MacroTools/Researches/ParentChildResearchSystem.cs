using MacroTools.Extensions;
using WCSharp.Events;

namespace MacroTools.Researches;

/// <summary>
/// Provides an easy way to force a research's level to always be equal to that of another.
/// </summary>
public static class ParentChildResearchSystem
{
  /// <summary>
  /// Once registered, the child research will always have its level set to the same level as the parent research
  /// when the parent research is researched.
  /// </summary>
  public static void Register(int parentResearch, int childResearch)
  {
    PlayerUnitEvents.Register(ResearchEvent.IsFinished, () =>
    {
      var triggerFaction = @event.Player.GetPlayerData().Faction;
      triggerFaction?.ModObjectLimit(childResearch, 1);
      triggerFaction?.SetObjectLevel(childResearch, triggerFaction.GetObjectLevel(parentResearch));
    }, parentResearch);
  }
}
