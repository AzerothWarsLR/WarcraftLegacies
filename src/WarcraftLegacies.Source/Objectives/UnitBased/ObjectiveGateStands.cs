using MacroTools.Localization;
using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>
/// An <see cref="Objective"/> that starts completed and fails when a gate of any of the given types is destroyed.
/// </summary>
public sealed class ObjectiveGateStands : Objective
{
  /// <param name="gateName">The gate's name, as shown in the quest log.</param>
  /// <param name="gateTypeIds">The unit types the standing gate can take, such as its open and closed forms.</param>
  public ObjectiveGateStands(string gateName, params int[] gateTypeIds)
  {
    SetDescription("{target} is intact", ("{target}", Loc.Get(gateName)));
    Progress = QuestProgress.Complete;
    foreach (var gateTypeId in gateTypeIds)
    {
      PlayerUnitEvents.Register(UnitTypeEvent.Dies, () => Progress = QuestProgress.Failed, gateTypeId);
    }
  }
}
