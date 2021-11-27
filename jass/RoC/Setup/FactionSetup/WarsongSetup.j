library WarsongSetup requires Faction, TeamSetup
  globals
    Faction FACTION_WARSONG
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f

    set FACTION_WARSONG = Faction.create("Warsong", PLAYER_COLOR_ORANGE, "|c00ff8000","ReplaceableTextures\\CommandButtons\\BTNHellScream.blp")
    set f = FACTION_WARSONG
    set f.Team = TEAM_HORDE
    set f.UndefeatedResearch = 'R05W'
    set f.StartingGold = 150
    set f.StartingLumber = 500

    call f.ModObjectLimit('o00C', UNLIMITED)   //Great Hall
    call f.ModObjectLimit('o02R', UNLIMITED)   //Stronghold
    call f.ModObjectLimit('o02S', UNLIMITED)   //Fortress
    call f.ModObjectLimit('o020', UNLIMITED)   //Altar of Storms
    call f.ModObjectLimit('o01S', UNLIMITED)   //Barracks
    call f.ModObjectLimit('o009', UNLIMITED)   //War Mill
    call f.ModObjectLimit('o006', UNLIMITED)   //Ogre Barrack
    call f.ModObjectLimit('o02Q', UNLIMITED)   //Bestiary
    call f.ModObjectLimit('o028', UNLIMITED)   //Orc Burrow
    call f.ModObjectLimit('n03E', UNLIMITED)   //Watch Tower
    call f.ModObjectLimit('o01H', UNLIMITED)   //Troll Shrine
    call f.ModObjectLimit('n0AL', UNLIMITED)   //Improved Watch Tower
    call f.ModObjectLimit('o02T', UNLIMITED)   //Shipyard
    call f.ModObjectLimit('o01T', UNLIMITED)   //Goblin Hardware Shop

    call f.ModObjectLimit('o04L', UNLIMITED)   //Peon
    call f.ModObjectLimit('o02M', UNLIMITED)   //Grunt
    call f.ModObjectLimit('orai', UNLIMITED)   //Raider
    call f.ModObjectLimit('n08E', UNLIMITED)   //Hexbinder
    call f.ModObjectLimit('otbk', UNLIMITED)   //Troll Berseker
    call f.ModObjectLimit('nogn', UNLIMITED)   //Stonemaul Ogre Magi
    call f.ModObjectLimit('o00I', 6)           //Horde War Machine
    call f.ModObjectLimit('okod', 4)           //Kodo Beast
    call f.ModObjectLimit('obot', 12)   	    //Transport Ship
    call f.ModObjectLimit('odes', 12)  	     //Orc Frigate
    call f.ModObjectLimit('ojgn', 6)          //Juggernaught
    call f.ModObjectLimit('o00G', 6)           //Blademaster
    call f.ModObjectLimit('n03F', 6)           //Korkron elite
    call f.ModObjectLimit('owyv', 8)           //Wind Rider

    call f.ModObjectLimit('Ogrh', 1)           //Grom
    call f.ModObjectLimit('Obla', 1)           //Varok

    call f.ModObjectLimit('Robs', UNLIMITED)   //Berserker Strength
    call f.ModObjectLimit('Rotr', UNLIMITED)   //Troll Regeneration
    call f.ModObjectLimit('R023', UNLIMITED)   //Spiritual Infusion
    call f.ModObjectLimit('R01J', UNLIMITED)   //Ensnare
    call f.ModObjectLimit('R02I', UNLIMITED)   //Ogre Magi Adept Training
    call f.ModObjectLimit('R03Q', UNLIMITED)   //Warlock Adept Training
    call f.ModObjectLimit('Rorb', UNLIMITED)   //Reinforced Defenses
    call f.ModObjectLimit('Rosp', UNLIMITED)   //Spiked Barricades
    call f.ModObjectLimit('R016', UNLIMITED)   //Warlords
    call f.ModObjectLimit('R019', UNLIMITED)   //Improved Shockwave
    call f.ModObjectLimit('R01Z', UNLIMITED)   //Battle Stations
    call f.SetObjectLevel('R01Z', 1)                //Battle Stations
    call f.ModObjectLimit('R00D', UNLIMITED)   //For the Horde!
    call f.ModObjectLimit('Rovs', UNLIMITED)   //Envenomed Spears
    call f.ModObjectLimit('R017', UNLIMITED)   //Improved Ignore Pain
  endfunction

endlibrary