library DemonGroupMenu initializer OnInit requires DemonGroup, Event, UnitType, UnitTypeConfig, DemonPortal

    globals
        framehandle LegionBarBackdrop = null
        framehandle LegionMana = null
        framehandle LegionManaText = null

        private constant real LEGION_BAR_WIDTH = 0.354
        private constant real LEGION_BAR_HEIGHT = 0.035

        private constant real TOOLTIP_WIDTH = 0.25
        private constant real TOOLTIP_HEIGHT = 0.055

        private constant real LEGION_BAR_X_OFFSET = -0.07
        private constant real LEGION_BAR_Y_OFFSET = -0.12

        private constant integer LEGION_BAR_DEMON_COUNT = 13      //How many demon icons to display on the Legion bar at most
        private constant real    LEGION_BAR_INSET = 0.003         //The amount of border space to leave around the series icons on the each side
        private constant integer LEGION_BAR_ARRAY_BUFFER = LEGION_BAR_DEMON_COUNT+1

        private constant real DEMON_ICON_WIDTH = (LEGION_BAR_WIDTH - LEGION_BAR_INSET*2)/LEGION_BAR_DEMON_COUNT
        private constant real DEMON_ICON_HEIGHT = LEGION_BAR_HEIGHT - LEGION_BAR_INSET*2      

        private constant string TOOLTIP_COLOR = "|cffffcc00"  

        private constant integer WARP_COST_BIG_THRESHOLD = 30  //Above this cost, Demon icons will display red text
    endglobals

    private function LoadToc takes string s returns nothing
        if  not BlzLoadTOCFile(s) then
            call BJDebugMsg("Failed to Load TOC: "+s)
        endif	
    endfunction

    private struct DemonIcon
        readonly static integer iconCount = 0
        readonly static Table demonIconsByDemonGroup  //All demon icons as indexed by the struct ID of a particular DemonGroup
        readonly static Table demonIconsByFrameId
        readonly static thistype array demonIconsByIndex[LEGION_BAR_ARRAY_BUFFER]   //All demon icons in order of their position in the queue

        private integer index = 0
        private integer frameId = 0
        private framehandle buttonFrame = null
        private framehandle countFrame = null
        private framehandle countBackdropFrame = null
        private framehandle tooltipBackdropFrame = null
        private framehandle tooltipTextFrame = null
        private trigger buttonTrigger
        private DemonGroup whichDemonGroup = 0      //Which DemonGroup this icon box is reprsenting

        method moveToFront takes nothing returns nothing
            local integer i = this.index - 1
            local integer tempIndex = this.index
            if this.index != 0 then
                //Move front to placeholder spot
                call thistype.demonIconsByIndex[0].setIndex(LEGION_BAR_ARRAY_BUFFER)
                //Move this to front
                call this.setIndex(0)
                //Move everything ahead of this back by 1
                loop
                exitwhen i == 0
                    call thistype.demonIconsByIndex[i].setIndex(thistype.demonIconsByIndex[i].index + 1)
                    set i = i - 1
                endloop
                //Move the old first place back to the next unoccupied position
                call thistype.demonIconsByIndex[LEGION_BAR_ARRAY_BUFFER].setIndex(1)
            endif
        endmethod

        //Moves the frame according to its current index
        private method redraw takes nothing returns nothing
            call BlzFrameSetPoint(this.buttonFrame, FRAMEPOINT_LEFT, LegionBarBackdrop, FRAMEPOINT_LEFT, LEGION_BAR_INSET + DEMON_ICON_WIDTH * this.index, 0)
        endmethod

        method setIndex takes integer newIndex returns nothing
            if this.index != newIndex then
                set thistype.demonIconsByIndex[this.index] = 0
            else
                call BJDebugMsg("ERROR: attempted to set DemonIcon to index " + I2S(newIndex) + " but it is already at this index")
            endif

            if thistype.demonIconsByIndex[newIndex] == 0 then
                set thistype.demonIconsByIndex[newIndex] = this
            else
                call BJDebugMsg("ERROR: attempted to set DemonIcon at index " + I2S(this.index) +" to already occupied index " + I2S(newIndex))
            endif

            set this.index = newIndex

            //Communicate the front of the queue back to DemonGroup
            if this.index == 0 then
                call this.whichDemonGroup.setFirst()
            endif

            call this.redraw()
        endmethod

        method destroy takes nothing returns nothing
            local integer i = 0
            //Remove from tables
            set thistype.demonIconsByDemonGroup[this.whichDemonGroup] = 0
            set thistype.demonIconsByIndex[this.index] = 0
            set thistype.demonIconsByFrameId[this.frameId] = 0
            set thistype.iconCount = thistype.iconCount - 1

            //Move all indexes up in the queue and reposition them
            set i = this.index + 1
            loop
            exitwhen thistype.demonIconsByIndex[i] == 0
                call thistype.demonIconsByIndex[i].setIndex(thistype.demonIconsByIndex[i].index - 1)
                set i = i + 1
            endloop

            //Cleanup
            call DestroyTrigger(this.buttonTrigger)
            call BlzDestroyFrame(this.buttonFrame)
            set this.buttonFrame = null
            set this.countFrame = null
            set this.tooltipBackdropFrame = null
            set this.tooltipTextFrame = null
            call this.deallocate()
        endmethod

        method updateTooltip takes nothing returns nothing
            local DemonType tempDemonType = this.whichDemonGroup.whichDemonType

            if tempDemonType.warpType == WARP_TYPE_NORMAL then
                call BlzFrameSetText(this.tooltipTextFrame, TOOLTIP_COLOR+"Warp Type:|r Normal|n" + TOOLTIP_COLOR + "Warp Cost: |r" + I2S(R2I(tempDemonType.warpCost)) + "|nThis unit is Warped directly beside the summoning portal.")
            elseif tempDemonType.warpType == WARP_TYPE_DIMENSIONAL then
                call BlzFrameSetText(this.tooltipTextFrame, TOOLTIP_COLOR+"Warp Type:|r Dimensional|n" + TOOLTIP_COLOR + "Warp Cost: |r" + I2S(R2I(tempDemonType.warpCost)) + "|nThis unit can be Warped at a range of up to " + I2S(R2I(tempDemonType.warpRange)) + ".")
            elseif tempDemonType.warpType == WARP_TYPE_METEOR then
                call BlzFrameSetText(this.tooltipTextFrame, TOOLTIP_COLOR+"Warp Type:|r Meteor|n" + TOOLTIP_COLOR + "Warp Cost: |r" + I2S(R2I(tempDemonType.warpCost)) + "|nThis unit can be Warped at a range of up to " + I2S(R2I(tempDemonType.warpRange)) + ", falling from the sky as a colossal meteor that deals " + I2S(R2I(tempDemonType.warpDamage)) + " damage upon impact.")
            endif
        endmethod

        method updateSize takes nothing returns nothing
            local DemonGroup triggerDemonGroup = GetTriggerDemonGroup()

            if triggerDemonGroup.getSize() == 0 then
                call this.destroy()
            else
                call this.setCount(triggerDemonGroup.getSize())
            endif
        endmethod

        static method buttonClick takes nothing returns nothing
            local thistype tempDemonIcon = thistype.demonIconsByFrameId[GetHandleId(BlzGetTriggerFrame())]
            if tempDemonIcon != 0 then
                call BlzFrameSetEnable(tempDemonIcon.buttonFrame, false)
                call BlzFrameSetEnable(tempDemonIcon.buttonFrame, true)
                call tempDemonIcon.moveToFront()
            else
                call BJDebugMsg("ERROR: Attempted to click nonexistent button with frame handle id " + I2S(GetHandleId(BlzGetTriggerFrame())))
            endif
        endmethod

        private method setCount takes integer count returns nothing
            if this.whichDemonGroup.whichDemonType.warpCost >= WARP_COST_BIG_THRESHOLD then
                call BlzFrameSetText(this.countFrame, "|cffFF9A00" + I2S(count))
            else
                call BlzFrameSetText(this.countFrame, I2S(count))
            endif
        endmethod

        static method create takes DemonGroup whichDemonGroup returns thistype
            local thistype this = thistype.allocate()

            //Create button frame
            set this.buttonFrame = BlzCreateFrame("Demon", LegionBarBackdrop, 0, this)
            call BlzFrameSetSize(this.buttonFrame, DEMON_ICON_WIDTH, DEMON_ICON_HEIGHT)

            //Icon frame
            call BlzFrameSetTexture(BlzGetFrameByName("DemonBackdrop", this), whichDemonGroup.iconPath, 0, true)
            call BlzFrameSetTexture(BlzGetFrameByName("DemonPushedBackdrop", this), whichDemonGroup.iconPath, 0, true)
            call BlzFrameSetTexture(BlzGetFrameByName("DemonDisabledBackdrop", this), whichDemonGroup.iconPath, 0, true)
            call BlzFrameSetTexture(BlzGetFrameByName("DemonDisabledPushedBackdrop", this), whichDemonGroup.iconPath, 0, true)

            //Count backdrop frame
            set this.countBackdropFrame = BlzGetFrameByName("DemonCountBackdrop", this)
            call BlzFrameSetPoint(this.countBackdropFrame, FRAMEPOINT_BOTTOMRIGHT, this.buttonFrame, FRAMEPOINT_BOTTOMRIGHT, 0, 0)
            call BlzFrameSetSize(this.countBackdropFrame, DEMON_ICON_WIDTH/2, DEMON_ICON_HEIGHT/2)
            call BlzFrameSetEnable(this.countBackdropFrame, false)

            //Count frame
            set this.countFrame = BlzGetFrameByName("LegionDemonCountText", this)
            call BlzFrameSetAllPoints(this.countFrame, this.countBackdropFrame)
            call BlzFrameSetText(this.countFrame, "0")   
            call BlzFrameSetEnable(this.countFrame, false)    

            //Tooltip backdrop
            set this.tooltipBackdropFrame = BlzGetFrameByName("DemonDescriptionBackdrop", this)
            call BlzFrameSetPoint(this.tooltipBackdropFrame, FRAMEPOINT_BOTTOM, LegionBarBackdrop, FRAMEPOINT_TOP, 0, 0.003)
            call BlzFrameSetSize(this.tooltipBackdropFrame, TOOLTIP_WIDTH, TOOLTIP_HEIGHT)
            call BlzFrameSetTooltip(this.buttonFrame, this.tooltipBackdropFrame)

            //Tooltip text
            set this.tooltipTextFrame = BlzGetFrameByName("DemonDescriptionText", this)
            call BlzFrameSetPoint(this.tooltipTextFrame, FRAMEPOINT_CENTER, this.tooltipBackdropFrame, FRAMEPOINT_CENTER, 0.0, 0.0)
            call BlzFrameSetText(this.tooltipTextFrame, "0")  
            call BlzFrameSetSize(this.tooltipTextFrame, TOOLTIP_WIDTH - 0.01, TOOLTIP_HEIGHT - 0.01)
            call BlzFrameSetEnable(this.tooltipTextFrame, false)   

            //Increment count
            set this.index = thistype.iconCount
            set thistype.iconCount = thistype.iconCount + 1
            set this.frameId = GetHandleId(this.buttonFrame)

            //Save newly created icon to tables
            set this.whichDemonGroup = whichDemonGroup
            set thistype.demonIconsByDemonGroup[whichDemonGroup] = this
            set thistype.demonIconsByIndex[this.index] = this
            set thistype.demonIconsByFrameId[this.frameId] = this 


            call this.updateTooltip()

            //If this is the first, communicate that to DemonGroup
            if this.index == 0 then
                call this.whichDemonGroup.setFirst()
            endif            

            //Add trigger for button press
            set this.buttonTrigger = CreateTrigger()
            call BlzTriggerRegisterFrameEvent(this.buttonTrigger, this.buttonFrame, FRAMEEVENT_CONTROL_CLICK)
            call TriggerAddAction(this.buttonTrigger, function thistype.buttonClick)           

            //Set image frame
            call this.redraw()            

            return this
        endmethod

        static method onInit takes nothing returns nothing
            set thistype.demonIconsByDemonGroup = Table.create()
            set thistype.demonIconsByFrameId = Table.create()
        endmethod
    endstruct

    private function CreateLegionBar takes nothing returns nothing
        local framehandle gameFrame = BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0)

        set LegionBarBackdrop = BlzCreateFrame("LegionBarBackdrop", gameFrame, 0, 0)
        call BlzFrameSetPoint(LegionBarBackdrop, FRAMEPOINT_CENTER, gameFrame, FRAMEPOINT_CENTER, LEGION_BAR_X_OFFSET, LEGION_BAR_Y_OFFSET)
        call BlzFrameSetSize(LegionBarBackdrop, LEGION_BAR_WIDTH, LEGION_BAR_HEIGHT)
        call BlzFrameSetVisible(LegionBarBackdrop, false)

        set LegionMana = BlzCreateSimpleFrame("MyBarEx", LegionBarBackdrop, GetHandleId(LegionBarBackdrop))
        call BlzFrameSetVisible(LegionMana, false)
        call BlzFrameSetPoint(LegionMana, FRAMEPOINT_TOP, LegionBarBackdrop, FRAMEPOINT_BOTTOM, 0.05, -0.004)
        call BlzFrameSetSize(LegionMana, LEGION_BAR_WIDTH*0.65, LEGION_BAR_HEIGHT*0.4)

        set LegionManaText = BlzGetFrameByName("MyBarExText", GetHandleId(LegionBarBackdrop))
        call BlzFrameSetText(LegionManaText, "Portal Energy")
    endfunction

    private function OnDemonGroupSizeChanged takes nothing returns nothing
        local DemonIcon tempDemonIcon = DemonIcon.demonIconsByDemonGroup[GetTriggerDemonGroup()]
        if tempDemonIcon == 0 then
            set tempDemonIcon = DemonIcon.create(GetTriggerDemonGroup())
            set DemonIcon.demonIconsByDemonGroup[GetTriggerDemonGroup()] = tempDemonIcon
        endif
        call tempDemonIcon.updateSize()
    endfunction

    private function OnDemonTypeStatChanged takes nothing returns nothing
        local DemonIcon tempDemonIcon = DemonIcon.demonIconsByDemonGroup[DemonGroup.demonGroupsByDemonType[GetTriggerDemonType()]]
        call tempDemonIcon.updateTooltip()
    endfunction

    private function OnDemonManaChanged takes nothing returns nothing
      call BlzFrameSetText( LegionManaText, I2S(R2I(DemonPortal.mana)) + "/" + I2S(R2I(DemonPortal.manaMax)) + " (+" + I2S(R2I(DemonPortal.manaRegen))+"/s)" )
      call BlzFrameSetMinMaxValue(LegionMana, 0, DemonPortal.manaMax)
      call BlzFrameSetValue(LegionMana, DemonPortal.mana)
    endfunction

    private function OnInit takes nothing returns nothing
      local trigger trig = CreateTrigger()
      local framehandle tempFrame= null
      call LoadToc("war3mapImported\\LegionSystem.toc")
      call CreateLegionBar()

      //Create trigger to notice a DemonGroup having its size changed
      set trig = CreateTrigger()
      call OnDemonGroupSizeChange.register(trig)
      call TriggerAddCondition(trig, Condition(function OnDemonGroupSizeChanged)) 

      //Create trigger to notice a DemonType changing in a way that is meaningful to the tooltip
      set trig = CreateTrigger()
      call OnDemonTypeWarpRangeChange.register(trig)
      call OnDemonTypeWarpCostChange.register(trig)
      call OnDemonTypeWarpDamageChange.register(trig)
      call OnDemonTypeWarpTypeChange.register(trig)        
      call TriggerAddCondition(trig, Condition(function OnDemonTypeStatChanged))   

      set trig = CreateTrigger()
      call DemonPortal.onManaChange.register(trig)
      call TriggerAddCondition(trig, Condition(function OnDemonManaChanged)) 
    endfunction

endlibrary