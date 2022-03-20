using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.MacroTools.QuestSystem
{
  public abstract class QuestData
  {
    public const int QUEST_PROGRESS_UNDISCOVERED = 0;
    public const int QUEST_PROGRESS_INCOMPLETE = 1;
    public const int QUEST_PROGRESS_COMPLETE = 2;
    public const int QUEST_PROGRESS_FAILED = 3;

    public event EventHandler<QuestData> QuestProgressChanged;

    private readonly string _title;
    private readonly string _description;
    private int _progress = QUEST_PROGRESS_INCOMPLETE;
    private Faction _holder;
    private readonly quest _quest;
    private bool _muted = true; //Doesn't display text when updated if true
    private int _researchId;
    private readonly List<QuestItemData> _questItems = new();

    public string Title => _title;

    public bool Global { get; init; }

    /// <summary>
    /// Describes to the player what will happen when the quest is completed.
    /// </summary>
    protected abstract string CompletionDescription { get; }

    /// <summary>
    /// Describes to the player what will happen when the quest is failed.
    /// </summary>
    protected string FailureDescription => "DEFAULTFAILUREDESCRIPTION";

    /// <summary>
    /// Displayed to the player when the quest is completed.
    /// </summary>
    protected abstract string CompletionPopup { get; }

    /// <summary>
    /// Displayed to the player when the quest is failed.
    /// </summary>
    public string FailurePopup => null;

    /// <summary>
    /// Describes the background and flavour of this quest.
    /// </summary>
    public string Description => _description;

    /// <summary>
    /// The research given to the faction when it completes its quest.
    /// </summary>
    public int ResearchId
    {
      get => _researchId;
      set => _researchId = value;
    }

    public quest Quest => _quest;

    public bool ProgressLocked => _progress is QUEST_PROGRESS_COMPLETE or QUEST_PROGRESS_FAILED;

    /// <summary>
    /// Fired when the Quest is completed.
    /// </summary>
    protected virtual void OnComplete()
    {
      
    }

    /// <summary>
    /// Fired when the Quest is failed.
    /// </summary>
    protected virtual void OnFail()
    {
      
    }

    public int Progress
    {
      get => _progress;
      set
      {
        var formerProgress = _progress;
        _progress = value;
        switch (value)
        {
          case QUEST_PROGRESS_COMPLETE:
          {
            QuestSetCompleted(_quest, true);
            QuestSetFailed(_quest, false);
            QuestSetDiscovered(_quest, true);
            if (!_muted)
            {
              DisplayCompleted();
              if (Global)
              {
                DisplayCompletedGlobal();
              }
            }

            if (_researchId != 0)
            {
              SetPlayerTechResearched(Holder.Player, _researchId, 1);
            }

            OnComplete();
            break;
          }
          case QUEST_PROGRESS_FAILED:
          {
            QuestSetCompleted(_quest, false);
            QuestSetFailed(_quest, true);
            QuestSetDiscovered(_quest, true);
            if (!_muted)
            {
              DisplayFailed();
            }

            OnFail();
            break;
          }
          case QUEST_PROGRESS_INCOMPLETE:
          {
            if (!_muted)
            {
              if (formerProgress == QUEST_PROGRESS_UNDISCOVERED)
              {
                DisplayDiscovered();
              }
            }

            QuestSetCompleted(_quest, false);
            QuestSetFailed(_quest, false);
            QuestSetDiscovered(_quest, true);
            break;
          }
          case QUEST_PROGRESS_UNDISCOVERED:
            QuestSetCompleted(_quest, false);
            QuestSetFailed(_quest, false);
            QuestSetDiscovered(_quest, false);
            break;
        }

        //If the quest is incomplete, show its markers. Otherwise, hide them.
        if (Progress != QUEST_PROGRESS_INCOMPLETE)
        {
          foreach (var questItem in _questItems)
          {
            if (GetLocalPlayer() == Holder.Player)
            {
              questItem.HideLocal();
            }

            questItem.HideSync();
          }
        }
        else
        {
          foreach (var questItem in _questItems)
          {
            if (GetLocalPlayer() == Holder.Player)
            {
              questItem.ShowLocal();
            }

            questItem.ShowSync();
          }
        }

        QuestProgressChanged?.Invoke(this, this);
      }
    }

    /// <summary>
    /// The Faction that can complete the quest.
    /// </summary>
    public Faction Holder
    {
      get => _holder;
      set
      {
        if (_holder != null)
        {
          BJDebugMsg("Attempted to Holder of quest " + _title + " to " + value.Name + " but it is already to " +
                     _holder.Name);
          return;
        }

        _holder = value;
        if (_researchId != 0)
        {
          Holder.ModObjectLimit(_researchId, 1);
        }

        OnAdd();
        if (FailurePopup != null)
        {
          QuestSetDescription(_quest,
            _description + "\n|cffffcc00On completion:|r " + CompletionDescription +
            "\n|cffffcc00On failure:|r " + FailureDescription);
        }
        else
        {
          QuestSetDescription(_quest,
            _description + "\n|cffffcc00On completion:|r " + CompletionDescription);
        }

        foreach (var questItem in _questItems)
        {
          questItem.OnAdd();
        }

        _muted = false;
      }
    }

    protected Action OnAdd { get; init; }

    /// <summary>
    /// Enables the local aspects of all child QuestItems.
    /// </summary>
    public void ShowLocal()
    {
      QuestSetEnabled(_quest, true);
      foreach (var questItem in _questItems)
      {
        questItem.ShowLocal();
      }
    }

    /// <summary>
    /// Enables the synchronous aspects of all child QuestItems.
    /// </summary>
    public void ShowSync()
    {
      foreach (var questItem in _questItems)
      {
        questItem.ShowSync();
      }
    }

    /// <summary>
    /// Disables the local aspects of all child QuestItems.
    /// </summary>
    public void HideLocal()
    {
      QuestSetEnabled(_quest, false);
      foreach (var questItem in _questItems)
      {
        questItem.HideLocal();
      }
    }

    /// <summary>
    /// Disables the synchronous aspects of all child QuestItems.
    /// </summary>
    public void HideSync()
    {
      foreach (var questItem in _questItems)
      {
        questItem.HideSync();
      }
    }

    //Display a warning message to everyone EXCEPT the player that completed the quest
    private void DisplayCompletedGlobal()
    {
      var display = "";
      if (GetLocalPlayer() != Holder.Player)
      {
        display = display + "\n|cffffcc00MAJOR EVENT - " + Holder.PrefixCol + Title + "|r\n" +
                  CompletionPopup + "\n";
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        StartSound(Person.ByHandle(GetLocalPlayer()).Faction.Team.ContainsFaction(Holder)
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
        {
          if (questItem.ShowsInQuestLog)
          {
            if (questItem.Progress == QUEST_PROGRESS_COMPLETE)
            {
              display = display + " - |cff808080" + questItem.Description + " (Completed)|r\n";
            }
            else
            {
              display = display + " - " + questItem.Description + "\n";
            }
          }
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
        {
          display = display + "\n|cffffcc00QUEST FAILED - " + Title + "|r\n" + FailurePopup + "\n";
        }
        else
        {
          display = display + "\n|cffffcc00QUEST FAILED - " + Title + "|r\n" + Description + "\n";
        }

        foreach (var questItem in _questItems)
        {
          if (questItem.ShowsInQuestLog)
          {
            display = questItem.Progress switch
            {
              QUEST_PROGRESS_COMPLETE => display + " - |cff808080" + questItem.Description + " (Completed)|r\n",
              QUEST_PROGRESS_FAILED => display + " - |cffCD5C5C" + questItem.Description + " (Failed)|r\n",
              _ => display + " - " + questItem.Description + "\n"
            };
          }
        }

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
        {
          if (questItem.ShowsInQuestLog)
          {
            display = display + " - |cff808080" + questItem.Description + " (Completed)|r\n";
          }
        }

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
        {
          if (questItem.ShowsInQuestLog)
          {
            if (questItem.Progress == QUEST_PROGRESS_COMPLETE)
            {
              display = display + " - |cff808080" + questItem.Description + " (Completed)|r\n";
            }
            else
            {
              display = display + " - " + questItem.Description + "\n";
            }
          }
        }

        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        StartSound(bj_questDiscoveredSound);
      }
    }

    private void OnQuestItemProgressChanged()
    {
      var allComplete = true;
      var anyFailed = false;
      var anyUndiscovered = false;

      foreach (var questItem in _questItems)
      {
        if (questItem.Progress != QUEST_PROGRESS_COMPLETE)
        {
          allComplete = false;
          switch (questItem.Progress)
          {
            case QUEST_PROGRESS_FAILED:
              anyFailed = true;
              break;
            case QUEST_PROGRESS_UNDISCOVERED:
              anyUndiscovered = true;
              break;
          }
        }
      }

      //If anything is undiscovered, the quest is undiscovered
      if (anyUndiscovered && Progress != QUEST_PROGRESS_UNDISCOVERED)
      {
        Progress = QUEST_PROGRESS_UNDISCOVERED;
        //If everything is complete, the quest is completed
      }
      else if (allComplete && Progress != QUEST_PROGRESS_COMPLETE)
      {
        Progress = QUEST_PROGRESS_COMPLETE;
        //If anything is failed, the quest is failed
      }
      else if (anyFailed && Progress != QUEST_PROGRESS_FAILED)
      {
        Progress = QUEST_PROGRESS_FAILED;
      }
      else
      {
        Progress = QUEST_PROGRESS_INCOMPLETE;
      }
    }

    public QuestItemData AddQuestItem(QuestItemData value)
    {
      _questItems.Add(value);
      if (value.ShowsInQuestLog)
      {
        value.QuestItem = QuestCreateItem(_quest);
        QuestItemSetDescription(value.QuestItem, value.Description);
      }

      value.ParentQuest = this;
      return value;
    }

    private static void OnAnyQuestItemProgressChanged(object sender, QuestItemData e)
    {
      e.ParentQuest.OnQuestItemProgressChanged();
    }

    public QuestData(string title, string desc, string icon)
    {
      _quest = CreateQuest();
      _description = desc;
      _title = title;
      QuestSetTitle(_quest, title);
      QuestSetIconPath(_quest, icon);
      QuestSetRequired(_quest, false);
      QuestSetEnabled(_quest, false);
    }

    public static void Setup()
    {
      QuestItemData.ProgressChanged += OnAnyQuestItemProgressChanged;
    }
  }
}