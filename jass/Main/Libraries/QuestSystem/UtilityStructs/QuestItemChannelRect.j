library QuestItemChannelRect requires QuestItemData, Legend, T32, AIDS, FilteredDeathEvents

  globals
    private constant string TARGET_EFFECT = "buildings\\other\\CircleOfPower\\CircleOfPower" //Make it so this renders in the world on the target location
    private constant string EFFECT = "Abilities\\Spells\\Other\\Drain\\ManaDrainCaster.mdl"
    private constant string PROGRESS_EFFECT = "war3mapImported\\Progressbar.mdx"
    private constant real PROGRESS_SCALE = 1.5
    private constant real PROGRESS_HEIGHT = 285.
  endglobals

  private function RectToRegion takes rect whichRect returns region
    local region rectRegion = CreateRegion()
    call RegionAddRect(rectRegion, whichRect)
    return rectRegion
  endfunction

  //The channel animation and duration tracker.
  private struct Channel
    private static thistype array byCaster
    private unit caster
    private real tick = 0.
    private real maxDuration = 0.
    private real elapsedDuration = 0.
    private effect sfxProgress = null
    private effect sfx = null
    private QuestItemChannelRect questItemChannelRect
    private timer channelingTimer
    private timerdialog channelingDialog

    private method destroy takes nothing returns nothing
      call BlzSetSpecialEffectPosition(this.sfxProgress, -100000, -100000, 0)    //Has no death animation so needs to be moved off the map
      call DestroyEffect(this.sfxProgress)
      call DestroyEffect(this.sfx)
      call DestroyTimer(channelingTimer)
      call DestroyTimerDialog (channelingDialog)

      set thistype.byCaster[GetUnitId(caster)] = 0
      call this.stopPeriodic()
      call this.deallocate()
    endmethod

    //Finished is true if the channel ended successfully, and false if it was interrupted.
    private method End takes boolean finished returns nothing
      call PauseUnit(caster, false)
      call SetUnitAnimation(caster, "spell")
      call QueueUnitAnimation(caster, "stand")
      call questItemChannelRect.OnChannelEnd(this, finished)
      call this.destroy()
    endmethod

    public static method OnAnyUnitDeath takes nothing returns nothing
      call thistype.byCaster[GetUnitId(GetTriggerUnit())].End(false)
    endmethod

    private method periodic takes nothing returns nothing    
      set this.tick = this.tick+1
      set this.elapsedDuration = this.elapsedDuration + 1./T32_FPS

      if this.elapsedDuration >= this.maxDuration then
        call this.End(true)
      endif
    endmethod

    implement T32x

    static method create takes unit caster, real duration, real facing, QuestItemChannelRect questItemChannelRect returns thistype
      local thistype this = thistype.allocate()
      set this.caster = caster
      set this.questItemChannelRect = questItemChannelRect
      set this.elapsedDuration = 0
      set this.maxDuration = duration

      call SetUnitX(caster, questItemChannelRect.X)
      call SetUnitY(caster, questItemChannelRect.Y)
      set this.sfxProgress = AddSpecialEffect(PROGRESS_EFFECT, GetUnitX(caster), GetUnitY(caster))
      call BlzSetSpecialEffectTimeScale(this.sfxProgress, 1./duration)
      call BlzSetSpecialEffectColorByPlayer(this.sfxProgress, GetOwningPlayer(caster))
      call BlzSetSpecialEffectScale(sfxProgress, PROGRESS_SCALE)
      call BlzSetSpecialEffectHeight(sfxProgress, PROGRESS_HEIGHT + GetPositionZ(questItemChannelRect.X, questItemChannelRect.Y))
      set this.sfx = AddSpecialEffect(EFFECT, GetUnitX(caster), GetUnitY(caster))
      call PauseUnit(caster, true)
      call SetUnitAnimation(caster, "channel")
      call BlzSetUnitFacingEx(caster, facing)

      if this.questItemChannelRect.ParentQuest.Global == true then
        set this.channelingTimer = CreateTimer()
        call TimerStart(this.channelingTimer, maxDuration, false, null)
        set this.channelingDialog = CreateTimerDialog(this.channelingTimer)
        call TimerDialogSetTitle(this.channelingDialog, this.questItemChannelRect.ParentQuest.Title)
        call TimerDialogDisplay(this.channelingDialog, true)
      endif


      set thistype.byCaster[GetUnitId(caster)] = this

      call this.startPeriodic()      
      return this
    endmethod
  endstruct

  //Bring a unit to a location, where they will channel for some period of time. When it's over, the QuestItem is completed.
  struct QuestItemChannelRect extends QuestItemData
    private region target
    private rect targetRect
    private real duration
    private Legend targetLegend
    private Channel channel = 0
    private real facing //Which way the unit faces while it is channeling
    private integer requiredUnitTypeId = 0

    private static trigger entersRectTrig = CreateTrigger()
    private static integer count = 0
    private static thistype array byIndex
    private static group tempGroup = CreateGroup()

    method operator X takes nothing returns real
      return GetRectCenterX(this.targetRect)
    endmethod

    method operator Y takes nothing returns real
      return GetRectCenterY(this.targetRect)
    endmethod

    //The Unit Type ID the entering unit must have to start channeling
    method operator RequiredUnitTypeId= takes integer value returns nothing
      set this.requiredUnitTypeId = value
    endmethod

    private method OnRegionEnter takes unit whichUnit returns nothing
      if GetOwningPlayer(whichUnit) == this.Holder.Player and UnitAlive(whichUnit) and Legend.ByHandle(GetTriggerUnit()) == this.targetLegend and this.channel == 0 and this.Progress == QUEST_PROGRESS_INCOMPLETE then
        if this.requiredUnitTypeId == 0 or this.requiredUnitTypeId == GetUnitTypeId(GetTriggerUnit()) then
          set this.channel = Channel.create(whichUnit, this.duration, this.facing, this)
        endif
      endif
    endmethod

    //Called by a Channel object to let the QuestItemChannelRect know it has ended.
    //Finished is true if the channel ended successfully, and false if it was interrupted.
    method OnChannelEnd takes Channel whichChannel, boolean finished returns nothing
      if whichChannel == this.channel then
        if finished then
          set this.Progress = QUEST_PROGRESS_COMPLETE
        endif
        set this.channel = 0
      endif
    endmethod

    private static method OnAnyRegionEnter takes nothing returns nothing
      local integer i = 0
      loop
        exitwhen i == thistype.count
        if GetTriggeringRegion() == thistype.byIndex[i].target then
          call thistype.byIndex[i].OnRegionEnter(GetEnteringUnit())
        endif
        set i = i + 1
      endloop
    endmethod

    static method create takes rect targetRect, string rectName, Legend whichLegend, real duration, real facing returns thistype
      local thistype this = thistype.allocate()
      local trigger trig = CreateTrigger()
      set this.target = RectToRegion(targetRect)
      set this.targetRect = targetRect
      set this.targetLegend = whichLegend
      set this.duration = duration
      set this.Description = "Have " + whichLegend.Name + " channel at " + rectName + " for " + I2S(R2I(duration)) + " seconds"
      set this.facing = facing
      call TriggerRegisterEnterRegion(thistype.entersRectTrig, this.target, null)
      call RegisterUnitTypeDiesAction(whichLegend.UnitType, function Channel.OnAnyUnitDeath) //This is very bizzare, but only the Channel struct needs to keep track of deaths, and it only needs to do so for valid Legends
      set this.MapEffectPath = TARGET_EFFECT
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1
      return this
    endmethod

    private static method onInit takes nothing returns nothing
      call TriggerAddAction(thistype.entersRectTrig, function thistype.OnAnyRegionEnter)
    endmethod

  endstruct

endlibrary