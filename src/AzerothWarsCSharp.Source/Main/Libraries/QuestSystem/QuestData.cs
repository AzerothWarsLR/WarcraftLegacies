public class QuestData{

  
    const int QUEST_PROGRESS_UNDISCOVERED = 0;
    const int QUEST_PROGRESS_INCOMPLETE = 1;
    const int QUEST_PROGRESS_COMPLETE = 2;
    const int QUEST_PROGRESS_FAILED = 3;

    Event QuestProgressChanged
  

  static QuestData GetTriggerQuest( ){
    return QuestData.triggerQuest;
  }


    private string title = "DEFAULTTITLE";
    private string description = "DEFAULTDESC";
    private int progress = QUEST_PROGRESS_INCOMPLETE;
    private Faction holder;
    private quest quest;
    private boolean muted = true ;//Doesn)t display text when updated if true
    private int researchId;

    private QuestItemData[] questItems[10];
    private int questItemCount = 0;

    readonly static thistype triggerQuest = 0;

    stub string operator Title( ){
      ;.title;
    }

    stub boolean operator Global( ){
      return false;
    }

    //Describes to the player what will happen when the quest is completed
    stub string operator CompletionDescription( ){
      return null;
    }

    //Describes to the player what will happen when the quest is failed
    stub string operator FailureDescription( ){
      return null;
    }

    //Displayed to the player when the quest is completed
    stub string operator CompletionPopup( ){
      return null;
    }

    //Displayed to the player when the quest is failed
    stub string operator FailurePopup( ){
      return null;
    }

    //Describes the background and flavour of this quest
    stub string operator Description( ){
      ;.description;
    }

    //The research given to the faction when it completes its quest
    integer operator ResearchId( ){
      ;.researchId;
    }

    void operator ResearchId=(int value ){
      this.researchId = value;
    }

    quest operator Quest( ){
      ;.quest;
    }

    boolean operator ProgressLocked( ){
      ;.progress == QUEST_PROGRESS_COMPLETE || this.progress == QUEST_PROGRESS_FAILED;
    }

    integer operator Progress( ){
      ;.progress;
    }

    void operator Progress=(int value ){
      int i = 0;
      int formerProgress = this.progress;
      this.progress = value;
      if (value == QUEST_PROGRESS_COMPLETE){
        QuestSetCompleted(this.quest, true);
        QuestSetFailed(this.quest, false);
        QuestSetDiscovered(this.quest, true);
        if (!this.muted){
          this.DisplayCompleted();
          if (this.Global){
            this.DisplayCompletedGlobal();
          }
        }
        if (this.researchId != 0){
          SetPlayerTechResearched(this.Holder.Player, this.researchId, 1);
        }
        OnComplete();
      }else if (value == QUEST_PROGRESS_FAILED){
        QuestSetCompleted(this.quest, false);
        QuestSetFailed(this.quest, true);
        QuestSetDiscovered(this.quest, true);
        if (!this.muted){
          this.DisplayFailed();
        }
        OnFail();
      }else if (value == QUEST_PROGRESS_INCOMPLETE){
        if (!this.muted){
          if (formerProgress == QUEST_PROGRESS_UNDISCOVERED){
            this.DisplayDiscovered();
          }
        }
        QuestSetCompleted(this.quest, false);
        QuestSetFailed(this.quest, false);
        QuestSetDiscovered(this.quest, true);
      }else if (value == QUEST_PROGRESS_UNDISCOVERED){
        QuestSetCompleted(this.quest, false);
        QuestSetFailed(this.quest, false);
        QuestSetDiscovered(this.quest, false);
      }

      //If the quest is incomplete, show its markers. Otherwise, hide them.
      if (this.Progress != QUEST_PROGRESS_INCOMPLETE){
        while(true){
          if ( i == this.questItemCount){ break; }
          if (GetLocalPlayer() == this.Holder.Player){
            questItems[i].HideLocal();
          }
          questItems[i].HideSync();
          i = i + 1;
        }
      }else {
        while(true){
          if ( i == this.questItemCount){ break; }
          if (GetLocalPlayer() == this.Holder.Player){
            questItems[i].ShowLocal();
          }
          questItems[i].ShowSync();
          i = i + 1;
        }
      }

      thistype.triggerQuest = this;
      QuestProgressChanged.fire();
    }

    //The faction that can complete this quest
    Faction operator Holder( ){
      ;.holder;
    }

    void operator Holder=(Faction value ){
      int i = 0;
      if (this.holder != 0){
        BJDebugMsg("Attempted to Holder of quest " + this.title + " to " + value.name + " but it is already to " + this.holder.name);
        return;
      }
      this.holder = value;
      if (this.researchId != 0){
        Holder.ModObjectLimit(this.researchId, 1);
      }
      this.OnAdd();
      if (this.FailurePopup != null){
        QuestSetDescription(this.quest, this.description + "\n|cffffcc00On completion:|r " + this.CompletionDescription + "\n|cffffcc00On failure:|r " + this.FailureDescription);
      }else {
        QuestSetDescription(this.quest, this.description + "\n|cffffcc00On completion:|r " + this.CompletionDescription);
      }
      while(true){
        if ( i == this.questItemCount){ break; }
        this.questItems[i].OnAdd();
        i = i + 1;
      }
      this.muted = false;
    }

    stub void OnAdd( ){

    }

    stub void OnComplete( ){

    }

    stub void OnFail( ){

    }

    //Enables the local aspects of all child QuestItems.
    void ShowLocal( ){
      int i = 0;
      QuestSetEnabled(this.quest, true);
      while(true){
        if ( i == this.questItemCount){ break; }
        questItems[i].ShowLocal();
        i = i + 1;
      }
    }

    //Enables the synchronous aspects of all child QuestItems.
    void ShowSync( ){
      int i = 0;
      while(true){
        if ( i == this.questItemCount){ break; }
        questItems[i].ShowSync();
        i = i + 1;
      }
    }

    //Disables the local aspects of all child QuestItems.
    void HideLocal( ){
      int i = 0;
      QuestSetEnabled(this.quest, false);
      while(true){
        if ( i == this.questItemCount){ break; }
        questItems[i].HideLocal();
        i = i + 1;
      }
    }

    //Disables the synchronous aspects of all child QuestItems.
    void HideSync( ){
      int i = 0;
      while(true){
        if ( i == this.questItemCount){ break; }
        questItems[i].HideSync();
        i = i + 1;
      }
    }

    //Display a warning message to everyone EXCEPT the player that completed the quest
    private void DisplayCompletedGlobal( ){
      string display = "";
      if (GetLocalPlayer() != this.Holder.Player){
        display = display + "\n|cffffcc00MAJOR EVENT - " + this.Holder.prefixCol + this.Title + "|r\n" + this.CompletionPopup + "\n";
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        if (Person.ByHandle(GetLocalPlayer()).Faction.Team.ContainsFaction(this.Holder)){
          StartSound(bj_questCompletedSound);
        }else {
          StartSound(bj_questWarningSound);
        }
      }
    }

    private void DisplayUpdated( ){
      int i = 0;
      QuestItemData tempQuestItemData;
      string display = "";
      if (GetLocalPlayer() == this.Holder.Player){
        display = display + "\n|cffffcc00QUEST UPDATED - " + this.Title + "|r\n" + this.Description + "\n";
        while(true){
          if ( i == this.questItemCount){ break; }
          tempQuestItemData = questItems[i];
          if (tempQuestItemData.ShowsInQuestLog){
            if (tempQuestItemData.Progress == QUEST_PROGRESS_COMPLETE){
              display = display + " - |cff808080" + tempQuestItemData.Description + " (Completed)|r\n";
            }else {
              display = display + " - " + tempQuestItemData.Description + "\n";
            }
          }
          i = i + 1;
        }
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        StartSound(bj_questUpdatedSound);
      }
    }

    private void DisplayFailed( ){
      int i = 0;
      QuestItemData tempQuestItemData;
      string display = "";
      if (GetLocalPlayer() == this.Holder.Player){
        if (this.FailurePopup != null){
          display = display + "\n|cffffcc00QUEST FAILED - " + this.Title + "|r\n" + this.FailurePopup + "\n";
        }else {
          display = display + "\n|cffffcc00QUEST FAILED - " + this.Title + "|r\n" + this.Description + "\n";
        }
        while(true){
          if ( i == this.questItemCount){ break; }
          tempQuestItemData = this.questItems[i];
          if (tempQuestItemData.ShowsInQuestLog){
            if (tempQuestItemData.Progress == QUEST_PROGRESS_COMPLETE){
              display = display + " - |cff808080" + tempQuestItemData.Description + " (Completed)|r\n";
            }else if (tempQuestItemData.Progress == QUEST_PROGRESS_FAILED){
              display = display + " - |cffCD5C5C" + tempQuestItemData.Description + " (Failed)|r\n";
            }else {
              display = display + " - " + tempQuestItemData.Description + "\n";
            }
          }
          i = i + 1;
        }
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        StartSound(bj_questFailedSound);
      }
    }

    private void DisplayCompleted( ){
      int i = 0;
      QuestItemData tempQuestItemData;
      string display = "";
      if (GetLocalPlayer() == this.Holder.Player){
        display = display + "\n|cffffcc00QUEST COMPLETED - " + this.Title + "|r\n" + this.CompletionPopup + "\n";
        while(true){
          if ( i == this.questItemCount){ break; }
          tempQuestItemData = this.questItems[i];
          if (tempQuestItemData.ShowsInQuestLog){
            display = display + " - |cff808080" + tempQuestItemData.Description + " (Completed)|r\n";
          }
          i = i + 1;
        }
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        StartSound(bj_questCompletedSound);
      }
    }

    void DisplayDiscovered( ){
      int i = 0;
      QuestItemData tempQuestItemData;
      string display = "";
      if (GetLocalPlayer() == this.Holder.Player){
        display = display + "\n|cffffcc00QUEST DISCOVERED - " + this.Title + "|r\n" + this.Description + "\n";
        while(true){
          if ( i == this.questItemCount){ break; }
          tempQuestItemData = questItems[i];
          if (tempQuestItemData.ShowsInQuestLog){
            if (tempQuestItemData.Progress == QUEST_PROGRESS_COMPLETE){
              display = display + " - |cff808080" + tempQuestItemData.Description + " (Completed)|r\n";
            }else {
              display = display + " - " + tempQuestItemData.Description + "\n";
            }
          }
          i = i + 1;
        }
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display);
        StartSound(bj_questDiscoveredSound);
      }
    }

    private void OnQuestItemProgressChanged( ){
      int i = 0;
      boolean allComplete = true;
      boolean anyFailed = false;
      boolean anyUndiscovered = false;
      QuestItemData loopQuestItem;
      while(true){
        if ( i == this.questItemCount){ break; }
        loopQuestItem = this.questItems[i];
        if (loopQuestItem.Progress != QUEST_PROGRESS_COMPLETE){
          allComplete = false;
          if (loopQuestItem.Progress == QUEST_PROGRESS_FAILED){
            anyFailed = true;
          }else if (loopQuestItem.Progress == QUEST_PROGRESS_UNDISCOVERED){
            anyUndiscovered = true;
          }
        }
        i = i + 1;
      }
      //If anything is undiscovered, the quest is undiscovered
      if (anyUndiscovered == true && this.Progress != QUEST_PROGRESS_UNDISCOVERED){
        this.Progress = QUEST_PROGRESS_UNDISCOVERED;
      //If everything is complete, the quest is completed
      }else if (allComplete == true && this.Progress != QUEST_PROGRESS_COMPLETE){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      //If anything is failed, the quest is failed
      }else if (anyFailed == true && this.Progress != QUEST_PROGRESS_FAILED){
        this.Progress = QUEST_PROGRESS_FAILED;
      }else {
        this.Progress = QUEST_PROGRESS_INCOMPLETE;
      }
    }

    QuestItemData AddQuestItem(QuestItemData value ){
      this.questItems[this.questItemCount] = value;
      this.questItemCount = this.questItemCount + 1;
      if (value.ShowsInQuestLog){
        value.QuestItem = QuestCreateItem(this.quest);
        QuestItemSetDescription(value.QuestItem, value.Description);
      }
      value.ParentQuest = this;
      return value;
    }

    private static void OnAnyQuestItemProgressChanged( ){
      if (QuestItemData.TriggerQuestItemData.ParentQuest != 0){
        QuestItemData.TriggerQuestItemData.ParentQuest.OnQuestItemProgressChanged();
      }
    }

    private void destroy( ){

    }

     thistype (string title, string desc, string icon ){

      this.quest = CreateQuest();
      this.description = desc;
      this.title = title;
      QuestSetTitle(this.quest, title);
      QuestSetIconPath(this.quest, icon);
      QuestSetRequired(this.quest, false);
      QuestSetEnabled(this.quest, false);
      ;;
    }

    private static void onInit( ){
      trigger trig = CreateTrigger();
      QuestItemData.ProgressChanged.register(trig);
      TriggerAddAction(trig,  thistype.OnAnyQuestItemProgressChanged);
    }


  private static void OnInit( ){
    QuestProgressChanged = Event.create();
  }

}
