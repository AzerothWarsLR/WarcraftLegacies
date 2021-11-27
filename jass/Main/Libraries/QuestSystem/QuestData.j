library QuestData initializer OnInit requires QuestItemData, Event

  globals
    constant integer QUEST_PROGRESS_UNDISCOVERED = 0
    constant integer QUEST_PROGRESS_INCOMPLETE = 1
    constant integer QUEST_PROGRESS_COMPLETE = 2
    constant integer QUEST_PROGRESS_FAILED = 3

    Event QuestProgressChanged
  endglobals

  function GetTriggerQuest takes nothing returns QuestData
    return QuestData.triggerQuest
  endfunction

  struct QuestData
    private string title = "DEFAULTTITLE"
    private string description = "DEFAULTDESC"
    private integer progress = QUEST_PROGRESS_INCOMPLETE
    private Faction holder
    private quest quest
    private boolean muted = true //Doesn't display text when updated if true
    private integer researchId

    private QuestItemData array questItems[10]
    private integer questItemCount = 0

    readonly static thistype triggerQuest = 0

    stub method operator Title takes nothing returns string
      return this.title
    endmethod

    stub method operator Global takes nothing returns boolean
      return false
    endmethod

    //Describes to the player what will happen when the quest is completed
    stub method operator CompletionDescription takes nothing returns string
      return null
    endmethod

    //Describes to the player what will happen when the quest is failed
    stub method operator FailureDescription takes nothing returns string
      return null
    endmethod

    //Displayed to the player when the quest is completed
    stub method operator CompletionPopup takes nothing returns string
      return null
    endmethod

    //Displayed to the player when the quest is failed
    stub method operator FailurePopup takes nothing returns string
      return null
    endmethod

    //Describes the background and flavour of this quest
    stub method operator Description takes nothing returns string
      return this.description
    endmethod

    //The research given to the faction when it completes its quest
    method operator ResearchId takes nothing returns integer
      return this.researchId
    endmethod

    method operator ResearchId= takes integer value returns nothing
      set this.researchId = value
    endmethod

    method operator Quest takes nothing returns quest
      return this.quest
    endmethod

    method operator ProgressLocked takes nothing returns boolean
      return this.progress == QUEST_PROGRESS_COMPLETE or this.progress == QUEST_PROGRESS_FAILED
    endmethod

    method operator Progress takes nothing returns integer
      return this.progress
    endmethod

    method operator Progress= takes integer value returns nothing
      local integer i = 0
      local integer formerProgress = this.progress
      set this.progress = value
      if value == QUEST_PROGRESS_COMPLETE then
        call QuestSetCompleted(this.quest, true)
        call QuestSetFailed(this.quest, false)
        call QuestSetDiscovered(this.quest, true)
        if not this.muted then
          call this.DisplayCompleted()
          if this.Global then
            call this.DisplayCompletedGlobal()
          endif
        endif
        if this.researchId != 0 then
          call SetPlayerTechResearched(this.Holder.Player, this.researchId, 1)
        endif
        call OnComplete()
      elseif value == QUEST_PROGRESS_FAILED then
        call QuestSetCompleted(this.quest, false)
        call QuestSetFailed(this.quest, true)
        call QuestSetDiscovered(this.quest, true)
        if not this.muted then
          call this.DisplayFailed()
        endif
        call OnFail()
      elseif value == QUEST_PROGRESS_INCOMPLETE then
        if not this.muted then
          if formerProgress == QUEST_PROGRESS_UNDISCOVERED then
            call this.DisplayDiscovered()
          endif
        endif
        call QuestSetCompleted(this.quest, false)
        call QuestSetFailed(this.quest, false)
        call QuestSetDiscovered(this.quest, true)
      elseif value == QUEST_PROGRESS_UNDISCOVERED then
        call QuestSetCompleted(this.quest, false)
        call QuestSetFailed(this.quest, false)
        call QuestSetDiscovered(this.quest, false)
      endif
      
      //If the quest is incomplete, show its markers. Otherwise, hide them.
      if GetLocalPlayer() == this.Holder.Player then
        if this.Progress != QUEST_PROGRESS_INCOMPLETE then
          loop
            exitwhen i == this.questItemCount
            call questItems[i].Hide()
            set i = i + 1
          endloop
        else 
          loop
            exitwhen i == this.questItemCount
            call questItems[i].Show()
            set i = i + 1
          endloop
        endif
      endif

      set thistype.triggerQuest = this
      call QuestProgressChanged.fire()
    endmethod

    //The faction that can complete this quest
    method operator Holder takes nothing returns Faction
      return this.holder
    endmethod

    method operator Holder= takes Faction value returns nothing
      local integer i = 0
      if this.holder != 0 then
        call BJDebugMsg("Attempted to set Holder of quest " + this.title + " to " + value.name + " but it is already set to " + this.holder.name)
        return
      endif
      set this.holder = value
      if this.researchId != 0 then
        call Holder.ModObjectLimit(this.researchId, 1)
      endif
      call this.OnAdd()
      if this.FailurePopup != null then
        call QuestSetDescription(this.quest, this.description + "\n|cffffcc00On completion:|r " + this.CompletionDescription + "\n|cffffcc00On failure:|r " + this.FailureDescription)
      else
        call QuestSetDescription(this.quest, this.description + "\n|cffffcc00On completion:|r " + this.CompletionDescription)
      endif
      loop
        exitwhen i == this.questItemCount
        call this.questItems[i].OnAdd()
        set i = i + 1
      endloop
      set this.muted = false
    endmethod

    stub method OnAdd takes nothing returns nothing
    
    endmethod

    stub method OnComplete takes nothing returns nothing

    endmethod

    stub method OnFail takes nothing returns nothing

    endmethod

    method Show takes nothing returns nothing
      local integer i = 0
      call QuestSetEnabled(this.quest, true)
      loop
        exitwhen i == this.questItemCount
        call questItems[i].Show()
        set i = i + 1
      endloop
    endmethod

    method Hide takes nothing returns nothing
      local integer i = 0
      call QuestSetEnabled(this.quest, false)
      loop
        exitwhen i == this.questItemCount
        call questItems[i].Hide()
        set i = i + 1
      endloop
    endmethod

    //Display a warning message to everyone EXCEPT the player that completed the quest
    private method DisplayCompletedGlobal takes nothing returns nothing
      local string display = ""
      if GetLocalPlayer() != this.Holder.Player then
        set display = display + "\n|cffffcc00MAJOR EVENT - " + this.Holder.prefixCol + this.Title + "|r\n" + this.CompletionPopup + "\n"
        call DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display)
        if Person.ByHandle(GetLocalPlayer()).Faction.Team.ContainsFaction(this.Holder) then
          call StartSound(bj_questCompletedSound)
        else
          call StartSound(bj_questWarningSound)
        endif
      endif
    endmethod

    private method DisplayUpdated takes nothing returns nothing
      local integer i = 0
      local QuestItemData tempQuestItemData
      local string display = ""
      if GetLocalPlayer() == this.Holder.Player then
        set display = display + "\n|cffffcc00QUEST UPDATED - " + this.Title + "|r\n" + this.Description + "\n"
        loop 
          exitwhen i == this.questItemCount
          set tempQuestItemData = questItems[i]
          if tempQuestItemData.ShowsInQuestLog then
            if tempQuestItemData.Progress == QUEST_PROGRESS_COMPLETE then
              set display = display + " - |cff808080" + tempQuestItemData.Description + " (Completed)|r\n"
            else
              set display = display + " - " + tempQuestItemData.Description + "\n"
            endif
          endif
          set i = i + 1
        endloop
        call DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display)
        call StartSound(bj_questUpdatedSound)
      endif
    endmethod

    private method DisplayFailed takes nothing returns nothing
      local integer i = 0
      local QuestItemData tempQuestItemData
      local string display = ""
      if GetLocalPlayer() == this.Holder.Player then
        if this.FailurePopup != null then
          set display = display + "\n|cffffcc00QUEST FAILED - " + this.Title + "|r\n" + this.FailurePopup + "\n"
        else
          set display = display + "\n|cffffcc00QUEST FAILED - " + this.Title + "|r\n" + this.Description + "\n"
        endif
        loop 
          exitwhen i == this.questItemCount
          set tempQuestItemData = this.questItems[i]
          if tempQuestItemData.ShowsInQuestLog then
            if tempQuestItemData.Progress == QUEST_PROGRESS_COMPLETE then
              set display = display + " - |cff808080" + tempQuestItemData.Description + " (Completed)|r\n"
            elseif tempQuestItemData.Progress == QUEST_PROGRESS_FAILED then
              set display = display + " - |cffCD5C5C" + tempQuestItemData.Description + " (Failed)|r\n"
            else
              set display = display + " - " + tempQuestItemData.Description + "\n"
            endif
          endif
          set i = i + 1
        endloop
        call DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display)
        call StartSound(bj_questFailedSound)
      endif
    endmethod

    private method DisplayCompleted takes nothing returns nothing
      local integer i = 0
      local QuestItemData tempQuestItemData
      local string display = ""
      if GetLocalPlayer() == this.Holder.Player then
        set display = display + "\n|cffffcc00QUEST COMPLETED - " + this.Title + "|r\n" + this.CompletionPopup + "\n"
        loop 
          exitwhen i == this.questItemCount
          set tempQuestItemData = this.questItems[i]
          if tempQuestItemData.ShowsInQuestLog then
            set display = display + " - |cff808080" + tempQuestItemData.Description + " (Completed)|r\n"
          endif
          set i = i + 1
        endloop
        call DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display)
        call StartSound(bj_questCompletedSound)
      endif
    endmethod

    method DisplayDiscovered takes nothing returns nothing
      local integer i = 0
      local QuestItemData tempQuestItemData
      local string display = ""
      if GetLocalPlayer() == this.Holder.Player then
        set display = display + "\n|cffffcc00QUEST DISCOVERED - " + this.Title + "|r\n" + this.Description + "\n"
        loop 
          exitwhen i == this.questItemCount
          set tempQuestItemData = questItems[i]
          if tempQuestItemData.ShowsInQuestLog then
            if tempQuestItemData.Progress == QUEST_PROGRESS_COMPLETE then
              set display = display + " - |cff808080" + tempQuestItemData.Description + " (Completed)|r\n"
            else
              set display = display + " - " + tempQuestItemData.Description + "\n"
            endif
          endif
          set i = i + 1
        endloop
        call DisplayTextToPlayer(GetLocalPlayer(), 0, 0, display)
        call StartSound(bj_questDiscoveredSound)
      endif
    endmethod

    private method OnQuestItemProgressChanged takes nothing returns nothing
      local integer i = 0
      local boolean allComplete = true
      local boolean anyFailed = false
      local boolean anyUndiscovered = false
      local QuestItemData loopQuestItem
      loop
        exitwhen i == this.questItemCount
        set loopQuestItem = this.questItems[i]
        if loopQuestItem.Progress != QUEST_PROGRESS_COMPLETE then
          set allComplete = false
          if loopQuestItem.Progress == QUEST_PROGRESS_FAILED then
            set anyFailed = true
          elseif loopQuestItem.Progress == QUEST_PROGRESS_UNDISCOVERED then
            set anyUndiscovered = true
          endif
        endif
        set i = i + 1
      endloop
      //If anything is undiscovered, the quest is undiscovered
      if anyUndiscovered == true and this.Progress != QUEST_PROGRESS_UNDISCOVERED then
        set this.Progress = QUEST_PROGRESS_UNDISCOVERED
      //If everything is complete, the quest is completed
      elseif allComplete == true and this.Progress != QUEST_PROGRESS_COMPLETE then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      //If anything is failed, the quest is failed
      elseif anyFailed == true and this.Progress != QUEST_PROGRESS_FAILED then
        set this.Progress = QUEST_PROGRESS_FAILED
      else
        set this.Progress = QUEST_PROGRESS_INCOMPLETE
      endif
    endmethod

    method AddQuestItem takes QuestItemData value returns QuestItemData
      set this.questItems[this.questItemCount] = value
      set this.questItemCount = this.questItemCount + 1
      if value.ShowsInQuestLog then
        set value.QuestItem = QuestCreateItem(this.quest)
        call QuestItemSetDescription(value.QuestItem, value.Description)
      endif
      set value.ParentQuest = this
      return value
    endmethod

    private static method OnAnyQuestItemProgressChanged takes nothing returns nothing
      if QuestItemData.TriggerQuestItemData.ParentQuest != 0 then
        call QuestItemData.TriggerQuestItemData.ParentQuest.OnQuestItemProgressChanged()
      endif
    endmethod

    private method destroy takes nothing returns nothing

    endmethod

    static method create takes string title, string desc, string icon returns thistype
      local thistype this = thistype.allocate()
      set this.quest = CreateQuest()
      set this.description = desc
      set this.title = title
      call QuestSetTitle(this.quest, title)
      call QuestSetIconPath(this.quest, icon)
      call QuestSetRequired(this.quest, false)
      call QuestSetEnabled(this.quest, false)
      return this
    endmethod

    private static method onInit takes nothing returns nothing
      local trigger trig = CreateTrigger()
      call QuestItemData.ProgressChanged.register(trig)
      call TriggerAddAction(trig, function thistype.OnAnyQuestItemProgressChanged)
    endmethod
  endstruct

  private function OnInit takes nothing returns nothing
    set QuestProgressChanged = Event.create()
  endfunction

endlibrary