using System;

namespace AzerothWarsCSharp.MacroTools.QuestObjectives
{
  public class QuestObjectiveControlLegend : QuestObjective
  {
    private readonly bool _canFail;

    private void OnLegendChangedOwner(object sender, LegendChangedOwnerEventArgs args)
    {
      if (ParentFaction != null && args.Legend.OwningPlayer == ParentFaction.Player)
      {
        Console.WriteLine("b");
        Progress = QuestProgress.Complete;
      }
      else if (_canFail)
      {
        Console.WriteLine("c");
        Progress = QuestProgress.Failed;
      }
      else
      {
        Console.WriteLine("d");
        Progress = QuestProgress.Incomplete;
      }
    }
    
    public QuestObjectiveControlLegend(Legend target, bool canFail = false)
    {
      _canFail = canFail;
      target.ChangedOwner += OnLegendChangedOwner;
      Description = $"Your team controls {target.Name}";
    }
  }
}