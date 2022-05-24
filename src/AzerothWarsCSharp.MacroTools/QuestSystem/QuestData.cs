using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem
{
  public abstract class QuestData
  {
    private readonly List<Objective> _questItems = new();

    private QuestProgress _progress = QuestProgress.Incomplete;

    protected QuestData(string title, string desc, string icon)
    {
      Quest = CreateQuest();
      Description = desc;
      Title = title;
      QuestSetTitle(Quest, title);
      QuestSetIconPath(Quest, icon);
      QuestSetRequired(Quest, false);
      QuestSetEnabled(Quest, false);
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
    protected virtual string RewardDescription => "DEFAULTCOMPLETIONDESCRIPTION";

    /// <summary>
    ///   Describes to the player what will happen when the quest is failed.
    ///   Describes mechanics, not flavour.
    /// </summary>
    protected virtual string PenaltyDescription => "DEFAULTFAILUREDESCRIPTION";

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
      if (!string.IsNullOrEmpty(FailurePopup))
        QuestSetDescription(Quest,
          Description + "\n|cffffcc00On completion:|r " + RewardDescription +
          "\n|cffffcc00On failure:|r " + PenaltyDescription);
      else
        QuestSetDescription(Quest,
          Description + "\n|cffffcc00On completion:|r " + RewardDescription);
    }

    /// <summary>
    ///   Register a <see cref="Faction" /> as being able to complete this <see cref="QuestData" />.
    /// </summary>
    internal void Add(Faction faction)
    {
      if (ResearchId != 0)
        faction.ModObjectLimit(ResearchId, 1);
      OnAdd(faction);
      foreach (var questItem in _questItems)
        questItem.OnAdd();
      RefreshDescription();
    }

    internal void ApplyFactionProgress(Faction whichFaction, QuestProgress progress, QuestProgress formerProgress)
    {
      if (progress == QuestProgress.Complete)
      {
        QuestSetCompleted(Quest, true);
        QuestSetFailed(Quest, false);
        QuestSetDiscovered(Quest, true);
        DisplayCompleted(whichFaction);
        if (Global) DisplayCompletedGlobal(whichFaction);

        if (ResearchId != 0) SetPlayerTechResearched(whichFaction.Player, ResearchId, 1);

        OnComplete(whichFaction);
      }
      else if (progress == QuestProgress.Failed)
      {
        QuestSetCompleted(Quest, false);
        QuestSetFailed(Quest, true);
        QuestSetDiscovered(Quest, true);
        DisplayFailed(whichFaction);

        OnFail(whichFaction);
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
        foreach (var questItem in _questItems)
        {
          if (GetLocalPlayer() == whichFaction.Player) questItem.HideLocal();

          questItem.HideSync();
        }
      else
        foreach (var questItem in _questItems)
        {
          if (GetLocalPlayer() == whichFaction.Player) questItem.ShowLocal();

          questItem.ShowSync();
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
      foreach (var questItem in _questItems) questItem.ShowLocal();
    }

    /// <summary>
    ///   Enables the synchronous aspects of all child QuestItems.
    /// </summary>
    internal void ShowSync()
    {
      foreach (var questItem in _questItems) questItem.ShowSync();
    }

    /// <summary>
    ///   Disables the local aspects of all child QuestItems.
    /// </summary>
    internal void HideLocal()
    {
      QuestSetEnabled(Quest, false);
      foreach (var questItem in _questItems) questItem.HideLocal();
    }

    /// <summary>
    ///   Disables the synchronous aspects of all child QuestItems.
    /// </summary>
    internal void HideSync()
    {
      foreach (var questItem in _questItems) questItem.HideSync();
    }

    /// <summary>
    ///   Displays a warning message to everyone except the player that completed the <see cref="QuestData" />.
    /// </summary>
    private void DisplayCompletedGlobal(Faction faction)
    {
      var display = "";
      if (GetLocalPlayer() != faction.Player)
      {
        display = display + "\n|cffffcc00MAJOR EVENT - " + faction.PrefixCol + Title + "|r\n" +
                  CompletionPopup + "\n";
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        var localFaction = PlayerData.ByHandle(GetLocalPlayer()).Faction;
        StartSound(localFaction != null && localFaction.Team?.ContainsFaction(faction) == true
          ? SoundLibrary.Completed
          : SoundLibrary.Warning);
      }
    }

    private void DisplayFailed(Faction faction)
    {
      var display = "";
      if (GetLocalPlayer() == faction.Player)
      {
        if (!string.IsNullOrEmpty(FailurePopup))
          display = display + "\n|cffffcc00QUEST FAILED - " + Title + "|r\n" + FailurePopup + "\n";
        else
          display = display + "\n|cffffcc00QUEST FAILED - " + Title + "|r\n" + Description + "\n";

        foreach (var questItem in _questItems)
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
    }

    private void DisplayCompleted(Faction faction)
    {
      var display = "";
      if (GetLocalPlayer() == faction.Player)
      {
        display = display + "\n|cffffcc00QUEST COMPLETED - " + Title + "|r\n" + CompletionPopup + "\n";
        foreach (var questItem in _questItems)
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
        foreach (var questItem in _questItems)
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

    private void OnQuestItemProgressChanged(object? sender, Objective objective)
    {
      var allComplete = true;
      var anyFailed = false;
      var anyUndiscovered = false;

      foreach (var questItem in _questItems)
        if (questItem.Progress != QuestProgress.Complete)
        {
          allComplete = false;
          if (questItem.Progress == QuestProgress.Failed)
            anyFailed = true;
          else if (questItem.Progress == QuestProgress.Undiscovered) anyUndiscovered = true;
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

    public void AddQuestItem(Objective questItem)
    {
      _questItems.Add(questItem);
      if (questItem.ShowsInQuestLog)
      {
        questItem.QuestItem = QuestCreateItem(Quest);
        QuestItemSetDescription(questItem.QuestItem, questItem.Description);
      }

      questItem.ParentQuest = this;
      questItem.ProgressChanged += OnQuestItemProgressChanged;
    }
  }
}