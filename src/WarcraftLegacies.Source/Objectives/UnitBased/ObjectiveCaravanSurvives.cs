using System.Collections.Generic;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>
/// An <see cref="Objective"/> that starts completed and fails once every unit in the tracked group has died.
/// </summary>
public sealed class ObjectiveCaravanSurvives : Objective
{
  private int _aliveCount;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveCaravanSurvives"/> class.
  /// </summary>
  /// <param name="caravanUnits">The units that must not all die.</param>
  public ObjectiveCaravanSurvives(List<unit> caravanUnits)
  {
    SetDescription("The pack kodos survive the march");
    ShowsInPopups = false;
    Progress = QuestProgress.Complete;
    _aliveCount = caravanUnits.Count;

    foreach (var kodo in caravanUnits)
    {
      PlayerUnitEventsHelper.RegisterDiesOrChangesOwnerOnce(() =>
      {
        _aliveCount--;
        if (_aliveCount <= 0)
        {
          Progress = QuestProgress.Failed;
        }
      }, kodo);
    }
  }
}
