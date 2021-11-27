library ObserverSlots requires Persons

  function MakeObserver takes player p returns nothing
    call ForceAddPlayer(Observers, p)
    call CreateFogModifierRectBJ( true, p, FOG_OF_WAR_VISIBLE, GetPlayableMapRect() ) 
    call SetPlayerState(p, PLAYER_STATE_OBSERVER, 1)
  endfunction

endlibrary