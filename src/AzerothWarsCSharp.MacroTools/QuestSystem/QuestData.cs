using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.MacroTools.QuestSystem
{
  public abstract class QuestData
  {
    private readonly List<QuestItemData> _questItems = new();

    private Faction _holder;
    private bool _muted = true; //Doesn't display text when updated if true
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
    protected int ResearchId { get; set; }

    private quest Quest { get; }

    public bool ProgressLocked => _progress is QuestProgress.Complete or QuestProgress.Failed;

    public QuestProgress Progress
    {
      get => _progress;
      set
      {
        var formerProgress = _progress;
        _progress = value;
        if (value == QuestProgress.Complete)
        {
          QuestSetCompleted(Quest, true);
          QuestSetFailed(Quest, false);
          QuestSetDiscovered(Quest, true);
          if (!_muted)
          {
            DisplayCompleted();
            if (Global) DisplayCompletedGlobal();
          }

          if (ResearchId != 0) SetPlayerTechResearched(Holder.Player, ResearchId, 1);

          OnComplete();
        }
        else if (value == QuestProgress.Failed)
        {
          QuestSetCompleted(Quest, false);
          QuestSetFailed(Quest, true);
          QuestSetDiscovered(Quest, true);
          if (!_muted) DisplayFailed();

          OnFail();
        }
        else if (value == QuestProgress.Incomplete)
        {
          if (!_muted)
            if (formerProgress == QuestProgress.Undiscovered)
              DisplayDiscovered();

          QuestSetCompleted(Quest, false);
          QuestSetFailed(Quest, false);
          QuestSetDiscovered(Quest, true);
        }
        else if (value == QuestProgress.Undiscovered)
        {
          QuestSetCompleted(Quest, false);
          QuestSetFailed(Quest, false);
          QuestSetDiscovered(Quest, false);
        }

        //If the quest is incomplete, show its markers. Otherwise, hide them.
        if (Progress != QuestProgress.Incomplete)
          foreach (var questItem in _questItems)
          {
            if (GetLocalPlayer() == Holder.Player) questItem.HideLocal();

            questItem.HideSync();
          }
        else
          foreach (var questItem in _questItems)
          {
            if (GetLocalPlayer() == Holder.Player) questItem.ShowLocal();

            questItem.ShowSync();
          }

        ProgressChanged?.Invoke(this, this);
      }
    }

    /// <summary>
    ///   The Faction that can complete the quest.
    /// </summary>
    public Faction Holder
    {
      get => _holder;
      set
      {
        if (_holder != null)
        {
          BJDebugMsg("Attempted to Holder of quest " + Title + " to " + value.Name + " but it is already to " +
                     _holder.Name);
          return;
        }

        _holder = value;
        if (ResearchId != 0) Holder.ModObjectLimit(ResearchId, 1);

        OnAdd();
        if (FailurePopup != null)
          QuestSetDescription(Quest,
            Description + "\n|cffffcc00On completion:|r " + RewardDescription +
            "\n|cffffcc00On failure:|r " + PenaltyDescription);
        else
          QuestSetDescription(Quest,
            Description + "\n|cffffcc00On completion:|r " + RewardDescription);

        foreach (var questItem in _questItems) questItem.OnAdd();

        _muted = false;
      }
    }

    /// <summary>
    ///   Fired when the <see cref="QuestData" /> changes its progress.
    /// </summary>
    public event EventHandler<QuestData>? ProgressChanged;

    /// <summary>
    ///   Fired when the Quest is completed.
    /// </summary>
    protected virtual void OnComplete()
    {
    }

    /// <summary>
    ///   Fired when the Quest is failed.
    /// </summary>
    protected virtual void OnFail()
    {
    }

    /// <summary>
    ///   Fired when the <see cref="QuestData" /> is added to a <see cref="Faction" />.
    /// </summary>
    protected virtual void OnAdd()
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
    private void DisplayCompletedGlobal()
    {
      var display = "";
      if (GetLocalPlayer() != Holder.Player)
      {
        display = display + "\n|cffffcc00MAJOR EVENT - " + Holder.PrefixCol + Title + "|r\n" +
                  CompletionPopup + "\n";
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        StartSound(PlayerData.ByHandle(GetLocalPlayer()).Faction.Team.ContainsFaction(Holder)
          ? bj_questCompletedSound
          : bj_questWarningSound);
      }
    }

    private void DisplayUpdated()
    {
      var display = "";
      if (GetLocalPlayer() == Holder.Player)
      {
        display = display + "\n|cffffcc00QUEST UPDATED - " + Title + "|r\n" + Description + "\n";
        foreach (var questItem in _questItems)
          if (questItem.ShowsInQuestLog)
          {
            if (questItem.Progress == QuestProgress.Complete)
              display = display + " - |cff808080" + questItem.Description + " (Completed)|r\n";
            else
              display = display + " - " + questItem.Description + "\n";
          }

        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        StartSound(bj_questUpdatedSound);
      }
    }

    private void DisplayFailed()
    {
      var display = "";
      if (GetLocalPlayer() == Holder.Player)
      {
        if (FailurePopup != null)
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
        StartSound(bj_questFailedSound);
      }
    }

    private void DisplayCompleted()
    {
      var display = "";
      if (GetLocalPlayer() == Holder.Player)
      {
        display = display + "\n|cffffcc00QUEST COMPLETED - " + Title + "|r\n" + CompletionPopup + "\n";
        foreach (var questItem in _questItems)
          if (questItem.ShowsInQuestLog)
            display = display + " - |cff808080" + questItem.Description + " (Completed)|r\n";

        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        StartSound(bj_questCompletedSound);
      }
    }

    public void DisplayDiscovered()
    {
      var display = "";
      if (GetLocalPlayer() == Holder.Player)
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
        StartSound(bj_questDiscoveredSound);
      }
    }

    private void OnQuestItemProgressChanged(object? sender, QuestItemData questItemData)
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

    public void AddQuestItem(QuestItemData questItem)
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