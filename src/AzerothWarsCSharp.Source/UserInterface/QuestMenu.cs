using AzerothWarsCSharp.Source.Libraries;
using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public static class QuestMenu
  {
    private static void OnObjectiveDestroyed(object sender, ObjectiveEventArgs e)
    {
      UnregisterObjective(e.Objective);
    }

    private static void OnObjectiveCreated(object sender, ObjectiveEventArgs e)
    {
      RegisterObjective(e.Objective);
    }

    private static void OnObjectiveFactionChanged(object sender, ObjectiveEventArgs e)
    {

    }

    private static void OnObjectiveProgressChanged(object sender, ObjectiveEventArgs e)
    {

    }

    private static void UnregisterObjective(Objective objective)
    {
      objective.ProgressChanged -= OnObjectiveProgressChanged;
      objective.FactionChanged -= OnObjectiveFactionChanged;
      objective.Destroyed -= OnObjectiveDestroyed;
    }

    private static void RegisterObjective(Objective objective)
    {
      objective.ProgressChanged += OnObjectiveProgressChanged;
      objective.FactionChanged += OnObjectiveFactionChanged;
      objective.Destroyed += OnObjectiveDestroyed;
    }

    public static void Initialize()
    {
      foreach (var objective in Objective.All)
      {
        RegisterObjective(objective);
      }
      Objective.Created += OnObjectiveCreated;
    }

    private static readonly Dictionary<QuestEx, quest> _blzQuestsByQuestEx = new();
    private static readonly Dictionary<Objective, questitem> _blzQuestitemsByLogSubEntry = new();
  }
}