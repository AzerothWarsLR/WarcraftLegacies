library Test requires Environment, Table

  globals
    private constant string COMMAND = "-test "
  endglobals

  struct Test
    private static StringTable byName
    private string name

    private stub method Run takes nothing returns nothing

    endmethod

    method Assert takes boolean bool, string errormsg returns nothing
      if not bool then
        call BJDebugMsg("Test" + this.name + " failed. " + errormsg)
      endif
    endmethod

    static method ExecuteTestCommand takes nothing returns nothing
      local string enteredString = GetEventPlayerChatString()
      local string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString))
      if not AreCheatsActive then
        return
      endif
      call Test(thistype.byName[parameter]).Run()
    endmethod

    static method create takes string name returns thistype
      local thistype this = thistype.allocate()
      local trigger trig
      local integer i = 0
      set this.name = name

      set trig = CreateTrigger()
      loop
      exitwhen i > MAX_PLAYERS
        call TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND + this.name, false )
        set i = i + 1
      endloop   
      call TriggerAddCondition( trig, Condition(function thistype.ExecuteTestCommand) )
      set thistype.byName[name] = this

      return this
    endmethod

    private static method onInit takes nothing returns nothing
      set thistype.byName = StringTable.create()
    endmethod
  endstruct

endlibrary