library Filters requires SpellHelpers
    globals
        player P = null
    endglobals
    
    function IsUnitHeroEnum takes nothing returns boolean
      return IsUnitType(GetFilterUnit(), UNIT_TYPE_HERO)
    endfunction

    function EnemyAliveFilter takes nothing returns boolean 
        local unit u = GetFilterUnit()
        local boolean b = (IsUnitEnemy(u,P) or GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) and IsUnitAlive(u)  and BlzIsUnitInvulnerable(u) == false
        return b
    endfunction 

    function UnitEnemyAliveFilter takes nothing returns boolean 
        local unit u = GetFilterUnit()
        local boolean b = (IsUnitEnemy(u,P) or GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) and IsUnitAlive(u)  and BlzIsUnitInvulnerable(u) == false and not IsUnitType(u, UNIT_TYPE_STRUCTURE)  and not IsUnitType(u, UNIT_TYPE_ANCIENT)
        return b
    endfunction 

    function AllyAliveFilter takes nothing returns boolean
        local unit u = GetFilterUnit()
        return (IsUnitAlly(u,P) or GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) and IsUnitAlive(u)  and BlzIsUnitInvulnerable(u) == false
    endfunction 
    
endlibrary

