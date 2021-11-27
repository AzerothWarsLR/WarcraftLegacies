library QuestItemAcquireArtifact initializer OnInit requires QuestItemData, Artifact

  struct QuestItemAcquireArtifact extends QuestItemData
    private static integer count = 0
    private static thistype array byIndex
    private Artifact target

    private method OnAdd takes nothing returns nothing
      if this.target.owningPerson == this.Holder.Person then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      endif
    endmethod

    private method OnAcquired takes nothing returns nothing
      if this.target.owningPerson == this.Holder.Person then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      else
        set this.Progress = QUEST_PROGRESS_INCOMPLETE
      endif
    endmethod

    static method OnAnyArtifactAcquired takes nothing returns nothing
      local integer i = 0
      local thistype loopItem
      loop
        exitwhen i == thistype.count
        set loopItem = thistype.byIndex[i]
        if loopItem.target == GetTriggerArtifact() then
          call loopItem.OnAcquired()
        endif
        set i = i + 1
      endloop    
    endmethod

    static method create takes Artifact target returns thistype
      local thistype this = thistype.allocate()
      set this.Description = "Acquire " + GetItemName(target.item)
      set this.target = target
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod
  endstruct

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call OnArtifactOwnerChange.register(trig)
    call TriggerAddAction(trig, function QuestItemAcquireArtifact.OnAnyArtifactAcquired)
  endfunction

endlibrary