library IncompatibleResearchSet initializer OnInit requires PlayerUnitEventFilterManager
    
  //An IncompatibleResearchSet is a list of Researchs which are mutually exclusive with each other
  //This means that if one of these Researchs is started, the other 2 are disabled
  //and only re-enabled if the first research is cancelled
  
  globals
    private constant integer BIG_NUMBER = 5000  //This is here to disable and enable techs via addition and subtraction
  endglobals
  
  struct IncompatibleResearchSet
    private static IncompatibleResearchSet array setList
    private static integer setCount = 0

    private integer array researches[10]
    private integer researchCount
    
    method add takes integer researchId returns nothing
      set this.researches[researchCount] = researchId
      set this.researchCount = this.researchCount + 1
    endmethod

    method disableResearches takes nothing returns nothing
      local integer i = 0
      local Person p = Person.ByHandle(GetTriggerPlayer())
      loop
      exitwhen this.researches[i] == 0
        if this.researches[i] != GetResearched() then
          call p.ModObjectLimit(this.researches[i], -BIG_NUMBER)
        endif
        set i = i + 1
      endloop
    endmethod
    
    method enableResearches takes nothing returns nothing
      local integer i = 0
      local Person p = Person.ByHandle(GetTriggerPlayer())
      loop
      exitwhen this.researches[i] == 0
        if this.researches[i] != GetResearched() then
          call p.ModObjectLimit(this.researches[i], BIG_NUMBER)
        endif
        set i = i + 1
      endloop        
    endmethod

    //Flag is true for START, and false for CANCEL
    static method doResearch takes boolean flag returns nothing
      local integer i = 0
      local integer j = 0
      local integer research = GetResearched()
      loop
      exitwhen thistype.setList[i] == 0
        set j = 0
        loop
        exitwhen thistype.setList[i].researches[j] == 0
          if thistype.setList[i].researches[j] == research then
            if flag == true then
              call thistype.setList[i].disableResearches()
            else
              call thistype.setList[i].enableResearches()
            endif
          endif
          set j = j + 1
        endloop
        set i = i + 1
      endloop
    endmethod
    
    static method create takes nothing returns IncompatibleResearchSet
      local IncompatibleResearchSet this = IncompatibleResearchSet.allocate()
      set thistype.setList[thistype.setCount] = this
      set thistype.setCount = thistype.setCount + 1   
      return this                
    endmethod           
  endstruct

  private function ResearchStart takes nothing returns nothing
    call IncompatibleResearchSet.doResearch(true)
  endfunction
  
  private function ResearchCancel takes nothing returns nothing
    call IncompatibleResearchSet.doResearch(false)
  endfunction    

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_START, function ResearchStart) //TODO: use filtered events
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_CANCEL, function ResearchCancel) //TODO: use filtered events
  endfunction        
    
endlibrary