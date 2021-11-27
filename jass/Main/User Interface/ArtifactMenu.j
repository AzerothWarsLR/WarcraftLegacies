 library ArtifactMenu initializer OnInit requires Artifact, Persons, Faction

  globals
    private real        BACKDROP_WIDTH = 0.7
    private real        BACKDROP_HEIGHT = 0.37
    private real        Y_OFFSET_TOP = 0.025         //How much space to push the artifact representations in from the top
    private real        Y_OFFSET_BOT = 0.05         //How much space to push the artifact representations in from the bottom
    private real        BOTTOM_BUTTON_X_OFFSET = 0.02
    private real        BOTTOM_BUTTON_Y_OFFSET = 0.015
    private real        TOOLTIP_WIDTH = 0.25
    private real        TOOLTIP_HEIGHT = 0.1

    private integer     COLUMN_COUNT = 5
    private integer     ROW_COUNT = 3

    private real        BOX_WIDTH = 0.13
    private real        BOX_HEIGHT = 0.086

    framehandle ArtifactMenuLauncher
    framehandle ArtifactMenuBackdrop
    framehandle ArtifactMenuExit
  endglobals

  private function LoadToc takes string s returns nothing
    if not BlzLoadTOCFile(s) then
      call BJDebugMsg("Failed to Load TOC: "+s)
    endif	
  endfunction

  private struct ArtifactMenuPage
    static thistype array pageArray
    static integer array activePageId        //-1 means no page is active. Indexed per player
    integer id
    
    framehandle backdrop
    framehandle title
    framehandle pageNumber
    framehandle exitButton
    framehandle nextButton
    framehandle prevButton
    trigger nextTrigger = null
    trigger prevTrigger = null
    trigger exitTrigger = null

    static method exitButtonClick takes nothing returns nothing
      local integer pId = GetPlayerId(GetTriggerPlayer()) 
      if thistype.activePageId[pId] > -1 then
        if GetLocalPlayer() == GetTriggerPlayer() then
          call BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]].backdrop, false)
        endif
        set thistype.activePageId[pId] = -1
      endif
    endmethod

    static method nextButtonClick takes nothing returns nothing
      local integer pId = GetPlayerId(GetTriggerPlayer())
      if thistype.activePageId[pId]> -1 and thistype.pageArray[thistype.activePageId[pId] + 1] != 0 then
        if GetLocalPlayer() == GetTriggerPlayer() then
          call BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]].backdrop, false)
          call BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]+ 1].backdrop, true)
        endif
        set thistype.activePageId[pId]= thistype.activePageId[pId]+ 1
      endif
    endmethod

    static method prevButtonClick takes nothing returns nothing
      local integer pId = GetPlayerId(GetTriggerPlayer())
      if thistype.activePageId[pId]> -1 and thistype.pageArray[thistype.activePageId[pId] - 1] != 0 then
        if GetLocalPlayer() == GetTriggerPlayer() then
            call BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]].backdrop, false)
            call BlzFrameSetVisible(thistype.pageArray[thistype.activePageId[pId]- 1].backdrop, true)
        endif
      endif
      set thistype.activePageId[pId]= thistype.activePageId[pId]- 1
    endmethod

    method destroy takes nothing returns nothing
      call DestroyTrigger(this.nextTrigger)
      call DestroyTrigger(this.prevTrigger)
      call DestroyTrigger(this.exitTrigger)

      call BlzDestroyFrame(this.prevButton)
      call BlzDestroyFrame(this.nextButton)     
      call BlzDestroyFrame(this.exitButton)
      call BlzDestroyFrame(this.title)
      call BlzDestroyFrame(this.pageNumber)
      call BlzDestroyFrame(this.backdrop)

      call this.deallocate()  
    endmethod

    method destroyNextButton takes nothing returns nothing
      call BlzDestroyFrame(this.nextButton)
      set this.nextButton = null
    endmethod

    method destroyPrevButton takes nothing returns nothing
      call BlzDestroyFrame(this.prevButton)
      set this.prevButton = null
    endmethod

    method createNextButton takes nothing returns nothing
      set this.nextButton = BlzCreateFrame("ScriptDialogButton", this.backdrop, 0, 0)
      call BlzFrameSetPoint(this.nextButton, FRAMEPOINT_BOTTOMRIGHT, this.backdrop, FRAMEPOINT_BOTTOMRIGHT, -BOTTOM_BUTTON_X_OFFSET, BOTTOM_BUTTON_Y_OFFSET)
      call BlzFrameSetSize(this.nextButton, 0.09, 0.037)
      call BlzFrameSetText(this.nextButton, "Next")      

      set this.nextTrigger = CreateTrigger()
      call BlzTriggerRegisterFrameEvent(this.nextTrigger, this.nextButton, FRAMEEVENT_CONTROL_CLICK)
      call TriggerAddAction(this.nextTrigger, function thistype.nextButtonClick)      
    endmethod

    method createPrevButton takes nothing returns nothing
      set this.prevButton = BlzCreateFrame("ScriptDialogButton", this.backdrop, 0, 0)
      call BlzFrameSetPoint(this.prevButton, FRAMEPOINT_BOTTOMLEFT, this.backdrop, FRAMEPOINT_BOTTOMLEFT, BOTTOM_BUTTON_X_OFFSET, BOTTOM_BUTTON_Y_OFFSET)
      call BlzFrameSetSize(this.prevButton, 0.09, 0.037)
      call BlzFrameSetText(this.prevButton, "Previous")    
      
      set this.prevTrigger = CreateTrigger()
      call BlzTriggerRegisterFrameEvent(this.prevTrigger, this.prevButton, FRAMEEVENT_CONTROL_CLICK)
      call TriggerAddAction(this.prevTrigger, function thistype.prevButtonClick)                   
    endmethod

    static method create takes integer id returns ArtifactMenuPage
      local thistype this = thistype.allocate()

      //Allocate ID
      set thistype.pageArray[id] = this
      set this.id = id

      //Create the backdrop window on the main UI
      set this.backdrop = BlzCreateFrame("ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0, 0)
      call BlzFrameSetSize(this.backdrop, BACKDROP_WIDTH, BACKDROP_HEIGHT)
      call BlzFrameSetAbsPoint(this.backdrop, FRAMEPOINT_CENTER, 0.4, 0.38)
      call BlzFrameSetVisible(this.backdrop, false)

      //Create title for this page
      set this.title = BlzCreateFrame("ArtifactMenuTitle", this.backdrop, 0, 0)
      call BlzFrameSetPoint(this.title, FRAMEPOINT_CENTER, this.backdrop, FRAMEPOINT_TOP, 0.0, -0.025)
      call BlzFrameSetText(this.title, "Artifacts")   

      //Create page number for this page
      set this.pageNumber = BlzCreateFrame("ArtifactMenuTitle", this.backdrop, 0, 0)
      call BlzFrameSetPoint(this.pageNumber, FRAMEPOINT_CENTER, this.backdrop, FRAMEPOINT_TOPRIGHT, -0.05, -0.025)
      call BlzFrameSetText(this.pageNumber, "Page " + I2S(this.id+1))                      

      //Create exit button for this page
      set this.exitButton = BlzCreateFrame("ScriptDialogButton", this.backdrop, 0, 0)
      call BlzFrameSetPoint(this.exitButton, FRAMEPOINT_BOTTOM, this.backdrop, FRAMEPOINT_BOTTOM, 0.0, BOTTOM_BUTTON_Y_OFFSET)
      call BlzFrameSetSize(this.exitButton, 0.09, 0.037)
      call BlzFrameSetText(this.exitButton, "Exit")
      set this.exitTrigger = CreateTrigger()
      call BlzTriggerRegisterFrameEvent(this.exitTrigger, this.exitButton, FRAMEEVENT_CONTROL_CLICK)
      call TriggerAddAction(this.exitTrigger, function thistype.exitButtonClick)   

      //Add previous and next buttons
      if thistype.pageArray[this.id - 1] != 0 then
        call this.createPrevButton()
        call thistype.pageArray[this.id - 1].createNextButton()
      endif

      if thistype.pageArray[this.id + 1] != 0 then
        call this.createNextButton()
      endif

      return this
    endmethod

    static method onInit takes nothing returns nothing 
        local integer i = 0
        loop
        exitwhen i > MAX_PLAYERS
          set thistype.activePageId[i] = -1
          set i = i + 1
        endloop
    endmethod
  endstruct

  private struct ArtifactRepresentation
    static thistype array repsById
    static thistype array repsByArtifact         //Note that this is IDed by the actual struct ID of the supplied Artifact, NOT its internal item ID
    static Table repsByPingButton                //ArtifactRepresentations indexed by handle IDs of ping button frames
    Artifact whichArtifact
    integer id = 0
    integer x = 0
    integer y = 0
    integer z = 0   //Position referring to page placement
    integer artifactStatus  //Refer to Artifact.j for possible values
    framehandle box
    framehandle icon
    framehandle title
    framehandle text
    framehandle pingButton
    trigger pingTrigger
    ArtifactMenuPage parentPage = 0

    method setText takes string s returns nothing
      call BlzFrameSetText(this.text, s)   
    endmethod

    method setOwner takes Person p returns nothing
      if p != 0 then
        call this.setText("Owned by|n" + p.Faction.prefixCol + p.Faction.Name + "|r")   
      endif    
    endmethod        

    method setArtifactStatus takes integer i returns nothing
      if i == ARTIFACT_STATUS_UNIT then
        call BlzFrameSetVisible(this.text, true)
        call BlzFrameSetVisible(this.pingButton, false)
      elseif i == ARTIFACT_STATUS_GROUND then
        call BlzFrameSetVisible(this.text, false)
        call BlzFrameSetVisible(this.pingButton, true)
      elseif i == ARTIFACT_STATUS_SPECIAL then
        call BlzFrameSetVisible(this.text, false)
        call BlzFrameSetVisible(this.pingButton, true)
      elseif i == ARTIFACT_STATUS_HIDDEN then  
        call BlzFrameSetVisible(this.text, true)
        call BlzFrameSetVisible(this.pingButton, false)  
      endif
    endmethod

    method destroy takes nothing returns nothing
      call BlzDestroyFrame(this.text)
      call BlzDestroyFrame(this.pingButton)
      call BlzDestroyFrame(this.icon)
      call BlzDestroyFrame(this.title)
      call BlzDestroyFrame(this.box)
      set thistype.repsByPingButton[GetHandleId(this.pingButton)] = 0

      call DestroyTrigger(this.pingTrigger)

      call this.deallocate()
    endmethod

    static method pingButtonClick takes nothing returns nothing
      local ArtifactRepresentation whichArtifactRep = thistype.repsByPingButton[GetHandleId(BlzGetTriggerFrame())]

      if GetLocalPlayer() == GetTriggerPlayer() then
        call whichArtifactRep.whichArtifact.ping(GetTriggerPlayer())
      endif
    endmethod

    static method create takes Artifact whichArtifact returns ArtifactRepresentation
      local thistype this = thistype.allocate()
      local integer i = 0
      local integer idMod = 0 //Used in xyz calculation
      local real boxSpacingX = (BACKDROP_WIDTH - BOX_WIDTH*COLUMN_COUNT)/(COLUMN_COUNT+1)                                 //How much horizontal space to leave between every box
      local real boxSpacingY = (BACKDROP_HEIGHT - Y_OFFSET_TOP - Y_OFFSET_BOT - BOX_HEIGHT*ROW_COUNT) / (ROW_COUNT+1)     //How much vertical space to leave between every box

      set this.whichArtifact = whichArtifact

      loop
      exitwhen thistype.repsById[i] == 0
        set i = i + 1
      endloop
      set thistype.repsById[i] = this
      set thistype.repsByArtifact[whichArtifact] = this
      set this.id = i

      //Determine x, y and z positions based on id
      set this.z = this.id / (COLUMN_COUNT * ROW_COUNT)
      set idMod = this.id - (this.z * COLUMN_COUNT * ROW_COUNT)
      set this.y = idMod / COLUMN_COUNT
      set this.x = ModuloInteger(this.id, COLUMN_COUNT)

      //Determine which page to place on based on z value, and create it if it does not exist
      if ArtifactMenuPage.pageArray[this.z] == 0 then
        set this.parentPage = ArtifactMenuPage.create(this.z)
      else
        set this.parentPage = ArtifactMenuPage.pageArray[this.id]
      endif

      //Create black box encompassing the representation
      set this.box = BlzCreateFrame("ArtifactItemBox", ArtifactMenuPage.pageArray[this.z].backdrop, 0, 0)
      call BlzFrameSetSize(this.box, BOX_WIDTH, BOX_HEIGHT)
      call BlzFrameSetPoint(this.box, FRAMEPOINT_TOPLEFT, ArtifactMenuPage.pageArray[this.z].backdrop, FRAMEPOINT_TOPLEFT, BOX_WIDTH * this.x + boxSpacingX * (this.x + 1), -(Y_OFFSET_TOP + (BOX_HEIGHT * this.y + boxSpacingY * (this.y + 1))))

      //Create icon in the box
      set this.icon = BlzCreateFrameByType("BACKDROP", "ArtifactIcon", this.box, "", 0)
      call BlzFrameSetSize(this.icon, 0.04, 0.04)
      call BlzFrameSetPoint(this.icon, FRAMEPOINT_LEFT, this.box, FRAMEPOINT_LEFT, 0.015, -0.0090)        
      call BlzFrameSetTexture(this.icon, BlzGetItemIconPath(whichArtifact.item), 0, true)             

      //Create title of artifact at top of box
      set this.title = BlzCreateFrame("ArtifactItemTitle", this.box, 0, 0)
      call BlzFrameSetText(this.title, GetItemName(whichArtifact.item))
      call BlzFrameSetPoint(this.title, FRAMEPOINT_CENTER, this.box, FRAMEPOINT_CENTER, 0.0, 0.0255)   
      call BlzFrameSetSize(this.title, BOX_WIDTH - 0.04, 0.0)  

      //Create description text of artifact
      set this.text = BlzCreateFrame("ArtifactItemOwnerText", this.box, 0, 0)
      call BlzFrameSetPoint(this.text, FRAMEPOINT_TOPLEFT, this.icon, FRAMEPOINT_TOPRIGHT, 0.007, 0)   
      call BlzFrameSetPoint(this.text, FRAMEPOINT_BOTTOMLEFT, this.icon, FRAMEPOINT_BOTTOMRIGHT, 0.007, 0)    
      call BlzFrameSetPoint(this.text, FRAMEPOINT_RIGHT, this.box, FRAMEPOINT_RIGHT, -0.007, 0)  

      //Create ping button of artifact
      set this.pingButton = BlzCreateFrame("ScriptDialogButton", this.box, 0, 0)
      call BlzFrameSetSize(this.pingButton, 0.062, 0.027)
      call BlzFrameSetPoint(this.pingButton, FRAMEPOINT_LEFT, this.box, FRAMEPOINT_LEFT, 0.057, -0.0090)   
      call BlzFrameSetText(this.pingButton, "Ping")    
      call BlzFrameSetVisible(this.pingButton, false)    
      set this.pingTrigger = CreateTrigger()
      call BlzTriggerRegisterFrameEvent(this.pingTrigger, this.pingButton, FRAMEEVENT_CONTROL_CLICK)
      call TriggerAddAction(this.pingTrigger, function thistype.pingButtonClick)  
      set thistype.repsByPingButton[GetHandleId(this.pingButton)] = this                               

      return this  
    endmethod

    static method onInit takes nothing returns nothing
      set thistype.repsByPingButton = Table.create()
    endmethod          

  endstruct

  private function ArtifactLauncherClick takes nothing returns nothing
    local integer pId = 0
    set pId = GetPlayerId(GetTriggerPlayer())
    if ArtifactMenuPage.activePageId[pId]> -1 then
      call ArtifactMenuPage.exitButtonClick()            
    else
      if GetLocalPlayer() == GetTriggerPlayer() then
        call BlzFrameSetVisible(ArtifactMenuPage.pageArray[0].backdrop, true)
      endif
      set ArtifactMenuPage.activePageId[pId]= 0
    endif
    call BlzFrameSetEnable(ArtifactMenuLauncher, false)
    call BlzFrameSetEnable(ArtifactMenuLauncher, true)
  endfunction

  private function CreateArtifactLauncher takes nothing returns nothing
    local trigger trig = null
    local framehandle artifactMenuTitle = null

    //Create the launcher button on the main UI
    set ArtifactMenuLauncher = BlzCreateFrame("ScriptDialogButton", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI,0), 0, 0)
    call BlzFrameSetSize(ArtifactMenuLauncher, 0.20, 0.025)
    call BlzFrameSetAbsPoint(ArtifactMenuLauncher, FRAMEPOINT_CENTER, 0.0, 0.56)
    call BlzFrameSetText(ArtifactMenuLauncher, "Artifacts")
    set trig = CreateTrigger()
    call BlzTriggerRegisterFrameEvent(trig, ArtifactMenuLauncher, FRAMEEVENT_CONTROL_CLICK)
    call TriggerAddAction(trig, function ArtifactLauncherClick)
  endfunction

  private function OnArtifactOwnerChanged takes nothing returns nothing
    call ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setOwner(GetTriggerArtifact().owningPerson)
  endfunction

  private function OnArtifactCreated takes nothing returns nothing
    call ArtifactRepresentation.create(GetTriggerArtifact())
    call ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setArtifactStatus(GetTriggerArtifact().status)
  endfunction

  private function OnArtifactDestroyed takes nothing returns nothing
    call ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].destroy()
  endfunction

  private function OnArtifactStatusChanged takes nothing returns nothing
    call ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setArtifactStatus(GetTriggerArtifact().status)            
  endfunction

  private function OnArtifactFactionChanged takes nothing returns nothing
    call ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setOwner(GetTriggerArtifact().owningPerson)
  endfunction

  private function OnArtifactCarrierOwnerChanged takes nothing returns nothing
    call ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setOwner(GetTriggerArtifact().owningPerson)
  endfunction

  private function OnArtifactDescriptionChanged takes nothing returns nothing
    call ArtifactRepresentation.repsByArtifact[GetTriggerArtifact()].setText(GetTriggerArtifact().description)
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = null
    local integer i = 0
    call LoadToc("war3mapImported\\ArtifactSystem.toc")
    call LoadToc("ui\\framedef\\framedef.toc")

    call CreateArtifactLauncher()
    call ArtifactMenuPage.create(0)
    
    //Create trigger to notice an artifact being created
    set trig = CreateTrigger()
    call OnArtifactCreate.register(trig)
    call TriggerAddCondition(trig, Condition(function OnArtifactCreated))

    //Create trigger to notice an artifact having its owner changed
    set trig = CreateTrigger()
    call OnArtifactOwnerChange.register(trig)
    call TriggerAddCondition(trig, Condition(function OnArtifactOwnerChanged))

    //Create trigger to notice an artifact being destroyed
    set trig = CreateTrigger()
    call OnArtifactDestroy.register(trig)
    call TriggerAddCondition(trig, Condition(function OnArtifactDestroyed))

    //Create trigger to notice an artifact having its status changed
    set trig = CreateTrigger()
    call OnArtifactStatusChange.register(trig)
    call TriggerAddCondition(trig, Condition(function OnArtifactStatusChanged))

    //Create trigger to notice an artifact having its owner's faction change
    set trig = CreateTrigger()
    call OnArtifactFactionChange.register(trig)
    call TriggerAddCondition(trig, Condition(function OnArtifactFactionChanged))    

    //Create trigger to notice an artifact having its carriers owner change
    set trig = CreateTrigger()
    call OnArtifactCarrierOwnerChange.register(trig)
    call TriggerAddCondition(trig, Condition(function OnArtifactCarrierOwnerChanged))  

    //Create trigger to notice an artifact having its description changed
    set trig = CreateTrigger()
    call OnArtifactDescriptionChange.register(trig)
    call TriggerAddCondition(trig, Condition(function OnArtifactDescriptionChanged))      
  endfunction

endlibrary