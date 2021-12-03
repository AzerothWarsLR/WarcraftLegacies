using System;
using System.Collections.Generic;
using System.ComponentModel;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public class Quest
  {
    public string Name { get; private init; }
    public string Icon { get; private init; }
    public string Flavour { get; private init; }
    public Faction? ParentFaction { get; internal set; }

    private QuestProgress _progress;
    public QuestProgress Progress
    {
      get => _progress;
      set
      {
        _progress = value;
        switch (_progress)
        {
          case QuestProgress.Incomplete:
            QuestSetCompleted(_quest, false);
            QuestSetFailed(_quest, false);
            QuestSetDiscovered(_quest, true);
            break;
          case QuestProgress.Failed:
            QuestSetCompleted(_quest, false);
            QuestSetFailed(_quest, true);
            QuestSetDiscovered(_quest, true);
            break;
          case QuestProgress.Complete:
            QuestSetCompleted(_quest, true);
            QuestSetFailed(_quest, false);
            QuestSetDiscovered(_quest, true);
            break;
          case QuestProgress.Undiscovered:
            QuestSetCompleted(_quest, false);
            QuestSetFailed(_quest, false);
            QuestSetDiscovered(_quest, false);
            break;
          default:
            throw new InvalidEnumArgumentException();
        }
      }
    }

    private readonly Dictionary<QuestObjective, questitem> _questItemsByObjective = new();
    private readonly quest _quest;

    /// <summary>
    /// Makes this Quest visible to the specified player.
    /// It will appear in their Quest (F9) menu.
    /// </summary>
    /// <param name="player"></param>
    internal void Render(player player)
    {
      if (GetLocalPlayer() == player)
      {
        QuestSetEnabled(_quest, true);
      }
      foreach (var objective in _questItemsByObjective.Keys)
      {
        objective.Render();
      }
    }

    public void AddObjective(QuestObjective objective)
    {
      var questItem = QuestCreateItem(_quest);
      _questItemsByObjective.Add(objective, questItem);
      QuestItemSetDescription(questItem, objective.Description);
      objective.ParentQuest = this;
      objective.ProgressChanged += OnObjectiveProgressChanged;
    }
    
    public Quest(string name, string icon, string flavour)
    {
      Name = name;
      Icon = icon;
      Flavour = flavour;
      _quest = CreateQuest();
      QuestSetTitle(_quest, name);
      QuestSetIconPath(_quest, $@"ReplaceableTextures\CommandButtons\BTN{icon}.blp");
      QuestSetRequired(_quest, false);
      QuestSetEnabled(_quest, false);
      QuestSetDescription(_quest, flavour);
    }
    
    private void RecalculateProgress()
    {
      var allComplete = true;
      var anyFailed = false;
      var anyUndiscovered = false;
      foreach (var objective in _questItemsByObjective.Keys)
      {
        var objectiveProgress = objective.Progress;
        switch (objectiveProgress)
        {
          case QuestProgress.Failed:
            anyFailed = true;
            allComplete = false;
            break;
          case QuestProgress.Undiscovered:
            anyUndiscovered = true;
            allComplete = false;
            break;
          case QuestProgress.Incomplete:
            allComplete = false;
            break;
          case QuestProgress.Complete:
            break;
          default:
            throw new InvalidEnumArgumentException();
        }
      }
      //If anything is undiscovered, the quest is undiscovered
      if (anyUndiscovered)
      {
        Progress = QuestProgress.Undiscovered;
      }
      //If everything is complete, the quest is completed
      else if (allComplete)
      {
        Progress = QuestProgress.Complete;
      }
      //If anything is failed, the quest is failed
      else if (anyFailed)
      {
        Progress = QuestProgress.Failed;
      }
      else
      {
        Progress = QuestProgress.Incomplete;
      }
    }
    
    private void OnObjectiveProgressChanged(object? sender, QuestObjectiveEventArgs args)
    {
      var questItem = _questItemsByObjective[args.Objective];
      switch (args.Objective.Progress)
      {
        case QuestProgress.Incomplete:
          QuestItemSetCompleted(questItem, false);
          break;
        case QuestProgress.Failed:
          QuestItemSetCompleted(questItem, false);
          break;
        case QuestProgress.Complete:
          QuestItemSetCompleted(questItem, true);
          break;
        case QuestProgress.Undiscovered:
          QuestItemSetCompleted(questItem, false);
          break;
        default:
          throw new InvalidEnumArgumentException();
      }
      Console.WriteLine("Quest responded to event");
      RecalculateProgress();
    }
    
    ~Quest()
    {
      DestroyQuest(_quest);
    }
  }
}