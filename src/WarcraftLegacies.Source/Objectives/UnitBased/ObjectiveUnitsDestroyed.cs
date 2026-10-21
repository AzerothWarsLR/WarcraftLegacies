using System.Collections.Generic;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>Completed once enough of a group of units have been destroyed.</summary>
public sealed class ObjectiveUnitsDestroyed : Objective
{
  private readonly int _count;
  private readonly List<unit> _units;

  public ObjectiveUnitsDestroyed(int count, string description, List<unit> units)
  {
    _count = count;
    _units = units;
    SetDescription(description);
    foreach (var target in _units)
    {
      var deathTrigger = trigger.Create();
      deathTrigger.RegisterUnitEvent(target, unitevent.Death);
      deathTrigger.AddAction(Refresh);
    }

    Refresh();
  }

  private void Refresh()
  {
    var destroyed = 0;
    foreach (var target in _units)
    {
      if (!target.Alive)
      {
        destroyed++;
      }
    }

    if (destroyed >= _count)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
