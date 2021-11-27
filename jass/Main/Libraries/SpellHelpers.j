
library SpellHelpers
    globals
        group TempGroup = CreateGroup()
    endglobals
    
  function StartUnitAbilityCooldownFull takes unit whichUnit, integer abilCode returns nothing
    local real fullCooldown = BlzGetUnitAbilityCooldown(whichUnit, abilCode, 0)
    call BlzStartUnitAbilityCooldown(whichUnit, abilCode, fullCooldown)
  endfunction

    function IsUnitAlive takes unit u returns boolean
         return not IsUnitType(u, UNIT_TYPE_DEAD) and GetUnitTypeId(u) != 0
    endfunction    

    function IsUnitCorpse takes unit u returns boolean
        return IsUnitType(u, UNIT_TYPE_DEAD) and not IsUnitType(u,UNIT_TYPE_MECHANICAL) and not IsUnitType(u,UNIT_TYPE_HERO) and not IsUnitType(u,UNIT_TYPE_ANCIENT) and not IsUnitType(u,UNIT_TYPE_SUMMONED) and not IsUnitType(u,UNIT_TYPE_STRUCTURE)
    endfunction

    function UnitHeal takes unit caster, unit target, real amount returns nothing
        call SetUnitState(target, UNIT_STATE_LIFE, GetUnitState(target,UNIT_STATE_LIFE)+amount)
    endfunction   

    function UnitRestoreMana takes unit cast, unit target, real amount returns nothing
        call SetUnitState(target, UNIT_STATE_MANA, GetUnitState(target,UNIT_STATE_MANA)+amount)
    endfunction    
    
    function UnitReduceMana takes unit cast, unit target, real amount returns nothing
        call SetUnitState(target, UNIT_STATE_MANA, GetUnitState(target,UNIT_STATE_MANA)-amount)
    endfunction       
    
    function UnitTeleport takes unit u, real x,real y returns nothing
        call SetUnitX(u, x)
        call SetUnitY(u, y)
    endfunction  
    
    function UnitReanimate takes unit caster, unit u, real duration returns nothing
        local real x = GetUnitX(u)
        local real y = GetUnitY(u)
        local integer unitType = GetUnitTypeId(u)
        local real facing = GetUnitFacing(u)
        local unit newUnit
        call RemoveUnit(u)
        call DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Undead\\AnimateDead\\AnimateDeadTarget.mdl", x, y))
        set newUnit = CreateUnit(GetOwningPlayer(caster), unitType, x, y, facing)
        call UnitApplyTimedLife(newUnit, 'BUan', duration)
        call SetUnitVertexColor(newUnit, 200, 100, 200, 255)
        call SetUnitUseFood(newUnit, false)
        call UnitAddType(newUnit, UNIT_TYPE_UNDEAD)
        call UnitAddType(newUnit, UNIT_TYPE_SUMMONED)
    endfunction
    
    function CreateSummon takes player id, integer unitid, real x, real y, real face, real duration returns unit
        local unit u
        
        set u = CreateUnit(id, unitid, x, y, face)
        call UnitApplyTimedLife(u, 'BTLF', duration)
        call SetUnitUseFood(u, false)
        call UnitAddType(u, UNIT_TYPE_SUMMONED)
        
        return u
    endfunction
    
    function ScaleUnitBaseDamage takes unit u, real scale, integer weaponIndex returns nothing
        call BlzSetUnitBaseDamage(u, R2I(I2R(BlzGetUnitBaseDamage(u, weaponIndex)) * scale), weaponIndex)    
    endfunction
    
    function ScaleUnitMaxHP takes unit u, real scale returns nothing
        local real percHP = GetUnitLifePercent(u)
        call BlzSetUnitMaxHP(u, R2I(I2R(BlzGetUnitMaxHP(u)) * scale)) 
        call SetUnitLifePercentBJ(u, percHP)
    endfunction    
    
endlibrary


