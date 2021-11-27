library ControlPointSetup requires ControlPoint
  
  globals
    private constant integer    CP_BUFF_A = 'B025'
    private constant integer    CP_BUFF_B = 'B050'
    private constant integer    CP_BUFF_C = 'B051'
    private constant integer    CP_BUFF_D = 'B052'
    private constant integer    CP_BUFF_E = 'B053'
    private constant integer    CP_BUFF_F = 'B054'
    
    private constant real       CP_VALUE_A = 10
    private constant real       CP_VALUE_B = 15
    private constant real       CP_VALUE_C = 20
    private constant real       CP_VALUE_D = 25
    private constant real       CP_VALUE_E = 30
    private constant real       CP_VALUE_F = 50

    private integer array cpBuffs[6]
    private real array cpValues[6]
  endglobals

  private function InitializeCP takes nothing returns nothing
    local unit u = GetEnumUnit()
    local integer i = 0
    loop
    exitwhen i > 5
      if GetUnitAbilityLevel(GetEnumUnit(), cpBuffs[i]) > 0 then
        call ControlPoint.create(GetEnumUnit(), cpValues[i])
      endif
    set i = i + 1
    endloop   
  endfunction

  public function OnInit takes nothing returns nothing
    local group g          

    set cpBuffs[0] = CP_BUFF_A
    set cpBuffs[1] = CP_BUFF_B
    set cpBuffs[2] = CP_BUFF_C
    set cpBuffs[3] = CP_BUFF_D
    set cpBuffs[4] = CP_BUFF_E
    set cpBuffs[5] = CP_BUFF_F
    
    set cpValues[0] = CP_VALUE_A
    set cpValues[1] = CP_VALUE_B   
    set cpValues[2] = CP_VALUE_C   
    set cpValues[3] = CP_VALUE_D  
    set cpValues[4] = CP_VALUE_E      
    set cpValues[5] = CP_VALUE_F
    
    set g = CreateGroup()
    call GroupEnumUnitsInRect(g, bj_mapInitialPlayableArea, null)
    call ForGroup(g, function InitializeCP)    
  endfunction

endlibrary