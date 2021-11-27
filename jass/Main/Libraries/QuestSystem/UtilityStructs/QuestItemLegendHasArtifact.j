library QuestItemLegendHasArtifact initializer OnInit requires QuestItemData, Artifact, Legend

  struct QuestItemLegendHasArtifact extends QuestItemData
    private static integer count = 0
    private static thistype array byIndex
    private Artifact targetArtifact
    private Legend targetLegend

    private method OnAdd takes nothing returns nothing
      if this.targetArtifact.OwningUnit == this.targetLegend.Unit then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      endif
    endmethod

    private method OnAcquired takes nothing returns nothing
      if this.targetArtifact.OwningUnit == this.targetLegend.Unit then
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
        if loopItem.targetArtifact == GetTriggerArtifact() then
          call loopItem.OnAcquired()
        endif
        set i = i + 1
      endloop    
    endmethod

    static method create takes Legend targetLegend, Artifact targetArtifact returns thistype
      local thistype this = thistype.allocate()
      set this.Description = targetLegend.Name + " has " + GetItemName(targetArtifact.item)
      set this.targetLegend = targetLegend
      set this.targetArtifact = targetArtifact
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod
  endstruct

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call OnArtifactOwnerChange.register(trig)
    call TriggerAddAction(trig, function QuestItemLegendHasArtifact.OnAnyArtifactAcquired)
  endfunction

endlibrary