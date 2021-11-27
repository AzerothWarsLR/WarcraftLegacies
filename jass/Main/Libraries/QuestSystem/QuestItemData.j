library QuestItemData

  struct QuestItemData
    private QuestData parentQuest
    private QuestItemData parentQuestItem
    private integer progress = QUEST_PROGRESS_INCOMPLETE
    private string description = ""
    private questitem questItem
    private minimapicon minimapIcon = null
    private effect mapEffect = null //The visual effect that appears on the map, usually a Circle of Power
    private string mapEffectPath = null

    private static Event progressChanged
    private static thistype triggerQuestItemData = 0

    static method operator TriggerQuestItemData takes nothing returns thistype
      return thistype.triggerQuestItemData
    endmethod

    static method operator ProgressChanged takes nothing returns Event
      return thistype.progressChanged
    endmethod

    method operator MapEffectPath takes nothing returns string
      return this.mapEffectPath
    endmethod

    method operator MapEffectPath= takes string value returns nothing
      set this.mapEffectPath = value
    endmethod

    method operator ParentQuestItem= takes QuestItemData value returns nothing
      set this.parentQuestItem = value
    endmethod

    method operator ParentQuest takes nothing returns QuestData
      return this.parentQuest
    endmethod

    method operator ParentQuest= takes QuestData value returns nothing
      set this.parentQuest = value
    endmethod

    method operator QuestItem takes nothing returns questitem
      return this.questItem
    endmethod

    method operator QuestItem= takes questitem value returns nothing
      set this.questItem = value
    endmethod

    //Whether or not this can be seen as a bullet point in the quest log
    stub method operator ShowsInQuestLog takes nothing returns boolean
      return true
    endmethod

    stub method operator X takes nothing returns real
      return 0.
    endmethod

    stub method operator Y takes nothing returns real
      return 0.
    endmethod

    method operator Holder takes nothing returns Faction
      if this.parentQuest != 0 then
        return this.parentQuest.Holder
      elseif this.parentQuestItem != 0 then
        return this.parentQuestItem.Holder
      else
        //call BJDebugMsg("ERROR: " + this.Description + I2S(this) + " has no holder")
        return 0
      endif
    endmethod

    method operator ProgressLocked takes nothing returns boolean
      if this.parentQuest != 0 then
        return this.parentQuest.ProgressLocked
      elseif this.parentQuestItem != 0 then
        return this.parentQuestItem.ProgressLocked
      else
        //call BJDebugMsg("ERROR: " + this.Description + I2S(this) + " has no holder")
        return true
      endif
    endmethod

    stub method operator Progress takes nothing returns integer
      return this.progress
    endmethod

    method operator Progress= takes integer value returns nothing
      if this.ProgressLocked or this.progress == value then
        return
      endif
      set this.progress = value
      if this.ShowsInQuestLog then
        if value == QUEST_PROGRESS_INCOMPLETE then
          call QuestItemSetCompleted(this.questItem, false)
          if GetLocalPlayer() == this.Holder.Player then
            call this.Show()
          endif
        elseif value == QUEST_PROGRESS_COMPLETE then
          call QuestItemSetCompleted(this.questItem, true)
          if GetLocalPlayer() == this.Holder.Player then
            call this.Hide()
          endif
        elseif value == QUEST_PROGRESS_UNDISCOVERED then
          call QuestItemSetCompleted(this.questItem, false)
        elseif value == QUEST_PROGRESS_FAILED then
          call QuestItemSetCompleted(this.questItem, false)
        endif
      endif
      set thistype.triggerQuestItemData = this
      call thistype.progressChanged.fire()
    endmethod

    stub method operator Description takes nothing returns string
      return this.description
    endmethod

    stub method operator Description= takes string value returns nothing
      set this.description = value
      if this.questItem != null then
        call QuestItemSetDescription(this.questItem, this.description)
      endif
    endmethod

    stub method operator PingPath takes nothing returns string
      return "MinimapQuestObjectivePrimary" 
    endmethod

    //Run when added to a Quest
    stub method OnAdd takes nothing returns nothing

    endmethod

    method Show takes nothing returns nothing
      local integer i = 0
      if this.Progress == QUEST_PROGRESS_INCOMPLETE and this.ParentQuest.Progress == QUEST_PROGRESS_INCOMPLETE then
        if this.minimapIcon == null and this.X != 0 and this.Y != 0 then
          set this.minimapIcon = CreateMinimapIcon(this.X, this.Y, 255, 255, 0, SkinManagerGetLocalPath(this.PingPath), FOG_OF_WAR_MASKED)
        elseif this.minimapIcon != null then
          call SetMinimapIconVisible(this.minimapIcon, true)
        endif

        if this.mapEffectPath != null and this.mapEffect == null then
          set this.mapEffect = AddSpecialEffect(this.mapEffectPath, this.X, this.Y)
          call BlzSetSpecialEffectColorByPlayer(this.mapEffect, this.Holder.Player)
        endif
      endif
    endmethod

    method Hide takes nothing returns nothing
      local integer i = 0
      if this.minimapIcon != null then
        call SetMinimapIconVisible(this.minimapIcon, false)
      endif
      if this.mapEffect != null then
        call DestroyEffect(this.mapEffect)
        set this.mapEffect = null
      endif
    endmethod

    private method destroy takes nothing returns nothing

    endmethod

    static method create takes nothing returns thistype
      local thistype this = thistype.allocate()
      return this
    endmethod

    private static method onInit takes nothing returns nothing
      set thistype.progressChanged = Event.create()
    endmethod
  endstruct

endlibrary