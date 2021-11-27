library GoblinSetup requires Faction, TeamSetup

  globals
    Faction FACTION_GOBLIN
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    set FACTION_GOBLIN = Faction.create("Bilgewater", PLAYER_COLOR_LIGHT_GRAY, "|cff808080","ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp")
    set f = FACTION_GOBLIN
    set f.Team = TEAM_HORDE
    set f.StartingGold = 150
    set f.StartingLumber = 500

    call f.ModObjectLimit('o03L', UNLIMITED)   //Great Hall
    call f.ModObjectLimit('o03M', UNLIMITED)   //Stronghold
    call f.ModObjectLimit('o03N', UNLIMITED)   //Fortress
    call f.ModObjectLimit('o03O', UNLIMITED)   //Altar of Storms
    call f.ModObjectLimit('o03P', UNLIMITED)   //Barracks
    call f.ModObjectLimit('o03Q', UNLIMITED)   //War Mill
    call f.ModObjectLimit('o03S', UNLIMITED)   //Tauren Totem
    call f.ModObjectLimit('o01M', UNLIMITED)   //Spirit Lodge
    call f.ModObjectLimit('o03T', UNLIMITED)   //Orc Burrow
    call f.ModObjectLimit('o03U', UNLIMITED)   //Watch Tower
    call f.ModObjectLimit('o03W', UNLIMITED)   //Improved Watch Tower
    call f.ModObjectLimit('o03X', UNLIMITED)   //Voodoo Lounge
    call f.ModObjectLimit('o03V', UNLIMITED)   //Shipyard
    call f.ModObjectLimit('n0AQ', 6)           //Oil Platform
    call f.ModObjectLimit('h011', 1)           //Artillery

    call f.ModObjectLimit('o02I', UNLIMITED)   //Peon
    call f.ModObjectLimit('n099', UNLIMITED)   //Ogre
    call f.ModObjectLimit('h08X', 8)           //sapper
    call f.ModObjectLimit('h08Y', UNLIMITED)          //Gunner
    call f.ModObjectLimit('odoc', UNLIMITED)   //GOBLIN Witch Doctor
    call f.ModObjectLimit('o04P', UNLIMITED)   //Mage
    call f.ModObjectLimit('o04O', UNLIMITED)   //Alch
    call f.ModObjectLimit('o04Q', 6)           //Tinker
    call f.ModObjectLimit('obot', 12)  	    //Transport Ship
    call f.ModObjectLimit('odes', 12)  	    //Orc Frigate
    call f.ModObjectLimit('ojgn', 6)          //Juggernaught
    call f.ModObjectLimit('n062', 12)          //Shredder
    call f.ModObjectLimit('h08Z', 5)           //Tank
    call f.ModObjectLimit('h091', 6)           //Zep
    call f.ModObjectLimit('nzep', 16)           //Trading Zeppelin
    call f.ModObjectLimit('o04S', 10)           //Trader
    call f.ModObjectLimit('u028', 2)           //Fuel Tanker

    call f.ModObjectLimit('O04N', 1)           //Jastor
    call f.ModObjectLimit('Ntin', 1)           //Gazlowee
    call f.ModObjectLimit('Nalc', 1)           //Noggenfogger

    call f.ModObjectLimit('R07L', UNLIMITED)   //Wizard Training
    call f.ModObjectLimit('R07M', UNLIMITED)   //Alchemist Training

  endfunction
    
endlibrary