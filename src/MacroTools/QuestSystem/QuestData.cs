using System;
using System.Collections.Generic;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.QuestSystem
{
  public abstract class QuestData
  {
    private readonly List<Objective> _objectives = new();

    private QuestProgress _progress = QuestProgress.Incomplete;

    protected QuestData(string title, string desc, string icon)
    {
      Quest = CreateQuest();
      Description = desc;
      Title = title;
      QuestSetTitle(Quest, title);
      QuestSetIconPath(Quest, icon);
      QuestSetEnabled(Quest, false);
      Required = false;
    }

    /// <summary>
    ///   If true, the quest appears on the left hand side of the F9 menu.
    ///   If false, it appears on the right hand side.
    /// </summary>
    protected bool Required
    {
      set => QuestSetRequired(Quest, value);
    }

    public string Title { get; }

    /// <summary>
    ///   If true, completing this quest will broadcast a message to every player.
    /// </summary>
    protected bool Global { get; init; }

    /// <summary>
    ///   Describes to the player what will happen when the quest is completed.
    ///   Describes mechanics, not flavour.
    /// </summary>
    protected virtual string RewardDescription => "";

    /// <summary>
    ///   Describes to the player what will happen when the quest is failed.
    ///   Describes mechanics, not flavour.
    /// </summary>
    protected virtual string PenaltyDescription => "";

    /// <summary>
    ///   Displayed to the player when the quest is completed.
    ///   Describes flavour, not mechanics.
    /// </summary>
    protected abstract string CompletionPopup { get; }

    /// <summary>
    ///   Displayed to the player when the quest is failed.
    ///   Describes flavour, not mechanics.
    /// </summary>
    protected virtual string FailurePopup => "null";

    /// <summary>
    ///   Describes the background and flavour of this quest.
    ///   Describes flavour, not mechanics.
    /// </summary>
    private string Description { get; }

    /// <summary>
    ///   The research given to the faction when it completes its quest.
    /// </summary>
    protected int ResearchId { get; init; }

    private quest Quest { get; }

    public bool ProgressLocked => _progress is QuestProgress.Complete or QuestProgress.Failed;

    public QuestProgress Progress
    {
      get => _progress;
      set
      {
        try
        {
          var formerProgress = _progress;
          _progress = value;
          ProgressChanged?.Invoke(this, new QuestProgressChangedEventArgs(this, formerProgress));
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex);
        }
      }
    }

    private void RefreshDescription()
    {
      if (!string.IsNullOrEmpty(PenaltyDescription))
        QuestSetDescription(Quest,
          Description + "\n|cffffcc00On completion:|r " + RewardDescription +
          "\n|cffffcc00On failure:|r " + PenaltyDescription);
      else
        QuestSetDescription(Quest,
          Description + "\n|cffffcc00On completion:|r " + RewardDescription);
    }

    private void Complete(Faction whichFaction)
    {
      QuestSetCompleted(Quest, true);
      QuestSetFailed(Quest, false);
      QuestSetDiscovered(Quest, true);
      DisplayCompleted(whichFaction);
      if (Global) DisplayCompletedGlobal(whichFaction.Player);

      if (ResearchId != 0) SetPlayerTechResearched(whichFaction.Player, ResearchId, 1);

      foreach (var objective in _objectives)
      {
        objective.ProgressLocked = true;
      }
      OnComplete(whichFaction);
    }

    private void Fail(Faction whichFaction)
    {
      QuestSetCompleted(Quest, false);
      QuestSetFailed(Quest, true);
      QuestSetDiscovered(Quest, true);
      DisplayFailed(whichFaction);
      OnFail(whichFaction);
      foreach (var objective in _objectives)
      {
        objective.ProgressLocked = true;
      }
    }

    /// <summary>
    ///   Register a <see cref="Faction" /> as being able to complete this <see cref="QuestData" />.
    /// </summary>
    internal void Add(Faction faction)
    {
      if (ResearchId != 0)
        faction.ModObjectLimit(ResearchId, 1);
      OnAdd(faction);
      foreach (var questItem in _objectives)
      {
        questItem.AddEligibleFaction(faction);
        questItem.OnAdd(faction);
      }

      RefreshDescription();
    }

    internal void ApplyFactionProgress(Faction whichFaction, QuestProgress progress, QuestProgress formerProgress)
    {
      if (progress == QuestProgress.Complete)
      {
        Complete(whichFaction);
      }
      else if (progress == QuestProgress.Failed)
      {
        Fail(whichFaction);
      }
      else if (progress == QuestProgress.Incomplete)
      {
        if (formerProgress == QuestProgress.Undiscovered)
          DisplayDiscovered(whichFaction);

        QuestSetCompleted(Quest, false);
        QuestSetFailed(Quest, false);
        QuestSetDiscovered(Quest, true);
      }
      else if (progress == QuestProgress.Undiscovered)
      {
        QuestSetCompleted(Quest, false);
        QuestSetFailed(Quest, false);
        QuestSetDiscovered(Quest, false);
      }

      //If the quest is incomplete, show its markers. Otherwise, hide them.
      if (Progress != QuestProgress.Incomplete)
        foreach (var questItem in _objectives)
        {
          if (GetLocalPlayer() == whichFaction.Player)
            questItem.HideLocal();

          questItem.HideSync();
        }
      else
        foreach (var questItem in _objectives)
        {
          if (GetLocalPlayer() == whichFaction.Player)
            questItem.ShowLocal(Progress);

          questItem.ShowSync(Progress);
        }
    }

    /// <summary>
    ///   Fired when the <see cref="QuestData" /> changes its progress.
    /// </summary>
    public event EventHandler<QuestProgressChangedEventArgs>? ProgressChanged;

    /// <summary>
    ///   Fired when the Quest is completed.
    /// </summary>
    protected virtual void OnComplete(Faction whichFaction)
    {
    }

    /// <summary>
    ///   Fired when the Quest is failed.
    /// </summary>
    protected virtual void OnFail(Faction whichFaction)
    {
    }

    /// <summary>
    ///   Fired when the <see cref="QuestData" /> is added to a <see cref="Faction" />.
    /// </summary>
    protected virtual void OnAdd(Faction whichFaction)
    {
    }

    /// <summary>
    ///   Enables the local aspects of all child QuestItems.
    /// </summary>
    internal void ShowLocal()
    {
      QuestSetEnabled(Quest, true);
      foreach (var questItem in _objectives) questItem.ShowLocal(Progress);
    }

    /// <summary>
    ///   Enables the synchronous aspects of all child QuestItems.
    /// </summary>
    internal void ShowSync()
    {
      foreach (var questItem in _objectives) questItem.ShowSync(Progress);
    }

    /// <summary>
    ///   Disables the local aspects of all child QuestItems.
    /// </summary>
    internal void HideLocal()
    {
      QuestSetEnabled(Quest, false);
      foreach (var questItem in _objectives) questItem.HideLocal();
    }

    /// <summary>
    ///   Disables the synchronous aspects of all child QuestItems.
    /// </summary>
    internal void HideSync()
    {
      foreach (var questItem in _objectives) questItem.HideSync();
    }

    /// <summary>
    ///   Displays a warning message to everyone except the player that completed the <see cref="QuestData" />.
    /// </summary>
    private void DisplayCompletedGlobal(player whichPlayer)
    {
      var display = "";
      if (GetLocalPlayer() == whichPlayer) return;
      display =
        $"{display}\n|cffffcc00MAJOR EVENT - {whichPlayer.GetFaction()?.PrefixCol}{Title}|r\n{CompletionPopup}\n";
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
      StartSound(GetLocalPlayer().GetTeam()?.Contains(whichPlayer) == true
        ? SoundLibrary.Completed
        : SoundLibrary.Warning);
    }

    private void DisplayFailed(Faction faction)
    {
      var display = "";
      if (GetLocalPlayer() != faction.Player) return;
      if (!string.IsNullOrEmpty(FailurePopup))
        display = display + "\n|cffffcc00QUEST FAILED - " + Title + "|r\n" + FailurePopup + "\n";
      else
        display = display + "\n|cffffcc00QUEST FAILED - " + Title + "|r\n" + Description + "\n";

      foreach (var questItem in _objectives)
        if (questItem.ShowsInQuestLog)
          display = questItem.Progress switch
          {
            QuestProgress.Complete => display + " - |cff808080" + questItem.Description + " (Completed)|r\n",
            QuestProgress.Failed => display + " - |cffCD5C5C" + questItem.Description + " (Failed)|r\n",
            _ => display + " - " + questItem.Description + "\n"
          };

      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
      StartSound(SoundLibrary.Failed);
    }

    private void DisplayCompleted(Faction faction)
    {
      var display = "";
      if (GetLocalPlayer() == faction.Player)
      {
        display = display + "\n|cffffcc00QUEST COMPLETED - " + Title + "|r\n" + CompletionPopup + "\n";
        foreach (var questItem in _objectives)
          if (questItem.ShowsInQuestLog)
            display = display + " - |cff808080" + questItem.Description + " (Completed)|r\n";

        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        StartSound(SoundLibrary.Completed);
      }
    }

    public void DisplayDiscovered(Faction faction)
    {
      var display = "";
      if (GetLocalPlayer() == faction.Player)
      {
        display = display + "\n|cffffcc00QUEST DISCOVERED - " + Title + "|r\n" + Description + "\n";
        foreach (var questItem in _objectives)
          if (questItem.ShowsInQuestLog)
          {
            if (questItem.Progress == QuestProgress.Complete)
              display = display + " - |cff808080" + questItem.Description + " (Completed)|r\n";
            else
              display = display + " - " + questItem.Description + "\n";
          }

        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        StartSound(SoundLibrary.Discovered);
      }
    }

    private void OnQuestItemProgressChanged(object? sender, Objective changedObjective)
    {
      var allComplete = true;
      var anyFailed = false;
      var anyUndiscovered = false;

      foreach (var objective in _objectives)
      {
        if (objective.Progress != QuestProgress.Complete)
        {
          allComplete = false;
          if (objective.Progress == QuestProgress.Failed)
            anyFailed = true;
          else if (objective.Progress == QuestProgress.Undiscovered) anyUndiscovered = true;
        }

        switch (objective.Progress)
        {
          case QuestProgress.Undiscovered:
            break;
          case QuestProgress.Incomplete:
            if (objective.EligibleFactions.Contains(GetLocalPlayer()))
              objective.ShowLocal(Progress);
            objective.ShowSync(Progress);
            break;
          case QuestProgress.Complete:
            if (objective.EligibleFactions.Contains(GetLocalPlayer()))
              objective.HideLocal();
            objective.HideSync();
            break;
          case QuestProgress.Failed:
            break;
          default:
            throw new ArgumentOutOfRangeException(nameof(objective));
        }
      }


      //If anything is undiscovered, the quest is undiscovered
      if (anyUndiscovered && Progress != QuestProgress.Undiscovered)
        Progress = QuestProgress.Undiscovered;
      //If everything is complete, the quest is completed
      else if (allComplete && Progress != QuestProgress.Complete)
        Progress = QuestProgress.Complete;
      //If anything is failed, the quest is failed
      else if (anyFailed && Progress != QuestProgress.Failed)
        Progress = QuestProgress.Failed;
      else
        Progress = QuestProgress.Incomplete;
    }

    public void AddObjective(Objective objective)
    {
      _objectives.Add(objective);
      if (objective.ShowsInQuestLog)
      {
        objective.QuestItem = QuestCreateItem(Quest);
        QuestItemSetDescription(objective.QuestItem, objective.Description);
      }

      objective.ProgressChanged += OnQuestItemProgressChanged;
    }
  }
}