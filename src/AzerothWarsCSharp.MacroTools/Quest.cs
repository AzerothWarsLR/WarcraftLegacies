using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.MacroTools
{
  public class Quest
  {
    private readonly quest _quest;
    private readonly Dictionary<QuestObjective, questitem> _questItemsByObjective = new();
    private readonly List<QuestOutcome> _questOutcomes = new();

    private string _flavour = "DefaultFlavourText";
    private QuestProgress _progress;

    public Quest(string name, string icon)
    {
      Name = name;
      Icon = icon;
      _quest = CreateQuest();
      QuestSetTitle(_quest, name);
      QuestSetIconPath(_quest, $@"ReplaceableTextures\CommandButtons\BTN{icon}.blp");
      QuestSetRequired(_quest, false);
      QuestSetEnabled(_quest, false);
    }

    public string Name { get; }

    public string Icon { get; }

    public string Flavour
    {
      get => _flavour;
      set
      {
        _flavour = value;
        RecalculateDescription();
      }
    }

    public string CompletionFlavour { get; init; } = "DefaultCompletionFlavour";

    public string FailureFlavour { get; init; } = "DefaultFailureFlavour";

    public Faction? ParentFaction { get; internal set; }

    public QuestProgress Progress
    {
      get => _progress;
      private set
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
            DisplayFailed();
            break;
          case QuestProgress.Complete:
            QuestSetCompleted(_quest, true);
            QuestSetFailed(_quest, false);
            QuestSetDiscovered(_quest, true);
            DisplayCompleted();
            foreach (var outcome in _questOutcomes) outcome.Fire();
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

    /// <summary>
    ///   Notifies the quest holder that this quest was failed.
    /// </summary>
    private void DisplayFailed()
    {
      if (GetLocalPlayer() == ParentFaction?.Player)
      {
        var displayText = $"\n|cffffcc00QUEST FAILED - {Name}|r\n{FailureFlavour}\n";
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, displayText);
        StartSound(bj_questFailedSound);
      }
    }

    /// <summary>
    ///   Notifies the quest holder that this quest was completed.
    /// </summary>
    private void DisplayCompleted()
    {
      if (GetLocalPlayer() == ParentFaction?.Player)
      {
        var displayText = $"\n|cffffcc00QUEST COMPLETED - {Name}|r\n{CompletionFlavour}\n";
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, displayText);
        StartSound(bj_questCompletedSound);
      }
    }

    private void RecalculateDescription()
    {
      var stringBuilder = new StringBuilder(Flavour);
      stringBuilder.AppendLine("\n|cffffcc00On completion:|r ");
      foreach (var reward in _questOutcomes) stringBuilder.AppendLine($" - {reward.Description}");
      stringBuilder.AppendLine("\n|cffffcc00On failure:|r ");
      QuestSetDescription(_quest, stringBuilder.ToString());
    }

    /// <summary>
    ///   Makes this Quest visible to the specified player.
    ///   It will appear in their Quest (F9) menu.
    /// </summary>
    /// <param name="player"></param>
    internal void Render(player player)
    {
      if (GetLocalPlayer() == player) QuestSetEnabled(_quest, true);
      foreach (var objective in _questItemsByObjective.Keys) objective.Render();
    }

    public void AddOutcome(QuestOutcome outcome)
    {
      _questOutcomes.Add(outcome);
      outcome.ParentQuest = this;
      RecalculateDescription();
    }

    public void AddObjective(QuestObjective objective)
    {
      var questItem = QuestCreateItem(_quest);
      _questItemsByObjective.Add(objective, questItem);
      QuestItemSetDescription(questItem, objective.Description);
      objective.ParentQuest = this;
      objective.ProgressChanged += OnObjectiveProgressChanged;
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
        Progress = QuestProgress.Undiscovered;
      //If everything is complete, the quest is completed
      else if (allComplete)
        Progress = QuestProgress.Complete;
      //If anything is failed, the quest is failed
      else if (anyFailed)
        Progress = QuestProgress.Failed;
      else
        Progress = QuestProgress.Incomplete;
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