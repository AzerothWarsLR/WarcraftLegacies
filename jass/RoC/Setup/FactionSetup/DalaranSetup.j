library DalaranSetup requires Faction, TeamSetup

  globals
    Faction FACTION_DALARAN
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_DALARAN = Faction.create("Dalaran", PLAYER_COLOR_PINK, "|c00e55bb0","ReplaceableTextures\\CommandButtons\\BTNJaina.blp")
    set f = FACTION_DALARAN 
    set f.UndefeatedResearch = 'R05N'
    set f.Team = TEAM_ALLIANCE
    set f.StartingGold = 150
    set f.StartingLumber = 500
    
    //Structures
    call f.ModObjectLimit('h065', UNLIMITED)   //Refuge
    call f.ModObjectLimit('h066', UNLIMITED)   //Conclave
    call f.ModObjectLimit('h068', UNLIMITED)   //Observatory
    call f.ModObjectLimit('h063', UNLIMITED)   //Granary
    call f.ModObjectLimit('h044', UNLIMITED)   //Altar of Knowledge
    call f.ModObjectLimit('h069', UNLIMITED)   //Barracks
    call f.ModObjectLimit('h02N', UNLIMITED)   //Trade Quarters
    call f.ModObjectLimit('h036', UNLIMITED)   //Arcane Sanctuary
    call f.ModObjectLimit('h078', UNLIMITED)   //Scout Tower
    call f.ModObjectLimit('h079', UNLIMITED)   //Arcane Tower
    call f.ModObjectLimit('h07A', UNLIMITED)   //Arcane Tower (Improved)
    call f.ModObjectLimit('hvlt', UNLIMITED)   //Arcane Vault
    call f.ModObjectLimit('h076', UNLIMITED)   //Alliance Shipyard
    call f.ModObjectLimit('ndgt', UNLIMITED)   //Dalaran Tower
    call f.ModObjectLimit('n004', UNLIMITED)   //Dalaran Tower (Improved)
    call f.ModObjectLimit('h067', UNLIMITED)   //Laboratory
    call f.ModObjectLimit('n0AO', 2)           //Way Gate

    //Units
    call f.ModObjectLimit('h022', UNLIMITED)   //Shaper
    call f.ModObjectLimit('hbot', 12)  	    //Alliance Transport Ship
    call f.ModObjectLimit('hdes', 12)  	    //Alliance Frigate
    call f.ModObjectLimit('hbsh', 6)          //Alliance Battle Ship
    call f.ModObjectLimit('nhym', UNLIMITED)   //Hydromancer
    call f.ModObjectLimit('h032', UNLIMITED)   //Battlemage
    call f.ModObjectLimit('h02D', UNLIMITED)   //Geomancer
    call f.ModObjectLimit('h01I', UNLIMITED)   //Arcanist
    call f.ModObjectLimit('n007', 6)           //Kirin Tor
    call f.ModObjectLimit('n096', 6)           //Earth Golem
    call f.ModObjectLimit('n03E', UNLIMITED)   //Pyromancer
    call f.ModObjectLimit('n0AK', UNLIMITED)   //Sludge Flinger
    call f.ModObjectLimit('o02U', 6)           //Crystal Artillery


    //Demi-heroes
    call f.ModObjectLimit('njks', 1)           //Jailor Kassan
    call f.ModObjectLimit('Hjai', 1)           //jaina
    call f.ModObjectLimit('Hant', 1)           //antonidas

    //Upgrades
    call f.ModObjectLimit('R01I', UNLIMITED)   //Arcanist Adept Training
    call f.ModObjectLimit('R01V', UNLIMITED)   //Geomancer Adept Training
    call f.ModObjectLimit('R00E', UNLIMITED)   //Hydromancer Adept Training
    call f.ModObjectLimit('R01L', UNLIMITED)   //Magic Sentry
    call f.ModObjectLimit('R00K', UNLIMITED)   //Power Infusion
    call f.ModObjectLimit('R00D', UNLIMITED)   //Pyromancer Adept Training
    call f.ModObjectLimit('Rhac', UNLIMITED)   //Improved Masonry
    call f.ModObjectLimit('R06J', UNLIMITED)   //Improved Ooze
    call f.ModObjectLimit('R061', UNLIMITED)   //Improved Forked Lightning
    call f.ModObjectLimit('R06O', UNLIMITED)   //Improved Phase Blade
    call f.ModObjectLimit('R00J', UNLIMITED)   //Combat Tomes
  endfunction
    
endlibrary