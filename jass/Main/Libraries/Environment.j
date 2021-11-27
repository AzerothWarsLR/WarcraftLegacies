library Environment initializer OnInit

  globals
    constant integer MAX_PLAYERS = 28
    private unit PosUnit
  endglobals
  
  native UnitAlive takes unit id returns boolean
  native GetUnitGoldCost takes integer unitid returns integer
  native GetUnitWoodCost takes integer unitid returns integer

  //Player(21) is used as a hostile computer player in this map. Use this to check if a player is neutral hostile or this pseudo-player.
  function IsPlayerNeutralHostile takes player whichPlayer returns boolean
    if whichPlayer == Player(21) or whichPlayer == Player(PLAYER_NEUTRAL_AGGRESSIVE) then
      return true
    endif
    return false
  endfunction

  function GetPositionZ takes real x, real y returns real
    call SetUnitX(PosUnit,x)
    call SetUnitY(PosUnit,y)
    return BlzGetUnitZ(PosUnit)
  endfunction
  
  function IsUnitInRect takes unit u, rect r returns boolean
    return GetUnitX(u) > GetRectMinX(r)-32 and GetUnitX(u) < GetRectMaxX(r)+32 and GetUnitY(u) > GetRectMinY(r)-32 and GetUnitY(u) < GetRectMaxY(r)+32
  endfunction 

  private function OnInit takes nothing returns nothing
    set PosUnit = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), 'u00X', 0, 0, 0)
  endfunction

endlibrary