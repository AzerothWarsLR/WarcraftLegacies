using MacroTools.Localization;
using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>
/// An <see cref="Objective"/> that starts completed and fails when the specified unit dies.
/// </summary>
public sealed class ObjectiveUnitAlive : Objective
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveUnitAlive"/> class.
  /// </summary>
  /// <param name="whichUnit">The unit that must stay alive for this objective to be completed.</param>
  public ObjectiveUnitAlive(unit whichUnit)
  {
    SetDescription(
      whichUnit.IsUnitType(unittype.Structure) ? "{target} is intact" : "{target} is alive",
      ("{target}", Loc.Get(whichUnit.Name)));
    Progress = QuestProgress.Complete;
    PlayerUnitEvents.Register(UnitEvent.Dies, () =>
    {
      Progress = QuestProgress.Failed;
    }, whichUnit);
  }
}
