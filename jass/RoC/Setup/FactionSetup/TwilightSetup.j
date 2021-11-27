library TwilightSetup requires Faction, TeamSetup

  globals
    Faction FACTION_TWILIGHT
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_TWILIGHT = Faction.create("Twilight", PLAYER_COLOR_LAVENDER, "|cff9178a8","ReplaceableTextures\\CommandButtons\\BTNChogall.blp")
    set f = FACTION_TWILIGHT
    set f.Team = TEAM_OLDGOD
    set f.StartingGold = 0
    set f.StartingLumber = 0

    call f.ModObjectLimit('o039', UNLIMITED)   //Great Hall
    call f.ModObjectLimit('o03A', UNLIMITED)   //Stronghold
    call f.ModObjectLimit('o03B', UNLIMITED)   //Fortress
    call f.ModObjectLimit('o03C', UNLIMITED)   //Altar of Storms
    call f.ModObjectLimit('o03D', UNLIMITED)   //Barracks
    call f.ModObjectLimit('o03J', UNLIMITED)   //War Mill
    call f.ModObjectLimit('o03E', UNLIMITED)   //Spirit Lodge
    call f.ModObjectLimit('o03F', UNLIMITED)   //Bestiary
    call f.ModObjectLimit('o03I', UNLIMITED)   //Shipyard
    call f.ModObjectLimit('o03G', UNLIMITED)   //Watch Tower
    call f.ModObjectLimit('o03H', UNLIMITED)   //Improved Watch Tower
    call f.ModObjectLimit('u00Y', UNLIMITED)   //Shop
    call f.ModObjectLimit('o03K', UNLIMITED)   //Burrow

    call f.ModObjectLimit('n051', 4)           //Black Drake
    call f.ModObjectLimit('o04J', 8)           //WindRider
    call f.ModObjectLimit('n07X', UNLIMITED)   //Fel Orc Warlock
    call f.ModObjectLimit('o01H', UNLIMITED)   //Fel Orc Grunt
    call f.ModObjectLimit('o04B', UNLIMITED)   //Fel Orc Peon
    call f.ModObjectLimit('n083', UNLIMITED)   //Horde Cavarly
    call f.ModObjectLimit('o04I', 6)           //Executioner
    call f.ModObjectLimit('o04K', 6)           //Demolisher
    call f.ModObjectLimit('n09O', 6)           //DK
    call f.ModObjectLimit('u01T', UNLIMITED)   //Necrolyte
    call f.ModObjectLimit('n087', UNLIMITED)   //Phase Grenadier
    call f.ModObjectLimit('obot', 12)  	    //Transport Ship
    call f.ModObjectLimit('odes', 12)  	    //Orc Frigate
    call f.ModObjectLimit('ojgn', 6)          //Juggernaught

    call f.ModObjectLimit('O01P', 1)           //Chogall
    call f.ModObjectLimit('H08Q', 1)           //Azil
    call f.ModObjectLimit('U01S', 1)           //Feludius
    call f.ModObjectLimit('O04H', 1)           //ignacius


    call f.ModObjectLimit('R023', UNLIMITED)   //Spiritual Infusion
    call f.ModObjectLimit('Rosp', UNLIMITED)   //Spiked Barricades
    call f.ModObjectLimit('R06X', UNLIMITED)   //Magic Training
    call f.ModObjectLimit('R06Z', UNLIMITED)   //Herald Training



  endfunction
    
endlibrary