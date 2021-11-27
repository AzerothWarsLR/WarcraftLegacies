library QuestItemLegendLevel requires QuestItemData, Legend

  struct QuestItemLegendLevel extends QuestItemData
    private Legend target = 0
    private integer level = 0
    private static integer count = 0
    private static thistype array byIndex

    static method create takes Legend target, integer level returns thistype
      local thistype this = thistype.allocate()
      set this.Description = target.Name + " is level " + I2S(level)
      set this.target = target
      set this.level = level
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod

    private method OnLevel takes nothing returns nothing
      if GetHeroLevel(this.target.Unit) >= this.level then
        set this.Progress = QUEST_PROGRESS_COMPLETE
      endif
    endmethod

    private static method OnAnyLevel takes nothing returns nothing
      local integer i = 0
      local thistype loopItem
      local Legend triggerLegend = Legend.ByHandle(GetTriggerUnit())
      loop
        exitwhen i == thistype.count
        set loopItem = thistype.byIndex[i]
        if loopItem.target == triggerLegend then
          call loopItem.OnLevel()
        endif
        set i = i + 1
      endloop
    endmethod

    private static method onInit takes nothing returns nothing
      call PlayerUnitEventAddAction(EVENT_PLAYER_HERO_LEVEL, function thistype.OnAnyLevel) //TODO: use filtered events
    endmethod
  endstruct

endlibrary