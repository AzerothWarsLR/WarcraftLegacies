library Income initializer OnInit requires Persons

  //**CONFIG**
  globals
    public constant real PERIOD = 1.           //Note that changing this will not change the amount of gold players receive over time
  endglobals
  //**ENDCONFIG

  private function AddPersonIncome takes Person whichPerson returns nothing
    local real goldPerSecond = whichPerson.Faction.Income * PERIOD / 60
    local Faction personFaction = whichPerson.Faction

    if whichPerson == 0 then
      call BJDebugMsg("ERROR: Person of 0 given to function AddPersonIncome")
    endif

    call whichPerson.addGold(goldPerSecond)
  endfunction

  private function IncomeTimer takes nothing returns nothing
    local integer i = 0
    local Person loopPerson
    loop
    exitwhen i > MAX_PLAYERS
      set loopPerson = Person.ById(i)
      if loopPerson != 0 then
        call AddPersonIncome(loopPerson)
      endif
      set i = i + 1
    endloop
  endfunction

  private function OnInit takes nothing returns nothing
    local timer incomeTimer = CreateTimer()
    call TimerStart(incomeTimer, PERIOD, true, function IncomeTimer)
  endfunction    

endlibrary