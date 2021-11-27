library NagaSetup requires Faction, TeamSetup
  globals
    Faction FACTION_NAGA
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f

    set FACTION_NAGA = Faction.create("Illidan", PLAYER_COLOR_VIOLET, "|cffff00ff","ReplaceableTextures\\CommandButtons\\BTNEvilIllidan.blp")
    set f = FACTION_NAGA
    set f.Team = TEAM_NAGA
    set f.UndefeatedResearch = 'R02L'
    set f.StartingGold = 0
    set f.StartingLumber = 500

    call f.ModObjectLimit('nntt', UNLIMITED)   //Pillar of Waves
    call f.ModObjectLimit('n04T', UNLIMITED)   //Monument of Currents
    call f.ModObjectLimit('n055', UNLIMITED)   //Temple of Tides
    call f.ModObjectLimit('nnad', UNLIMITED)   //Altar of the Depths
    call f.ModObjectLimit('nnsg', UNLIMITED)   //Spawning Grounds
    call f.ModObjectLimit('h06S', UNLIMITED)   //Coral Forge
    call f.ModObjectLimit('n0A3', UNLIMITED)   //Royal Pyramid
    call f.ModObjectLimit('nnsa', UNLIMITED)   //Temple of Azshara
    call f.ModObjectLimit('nnfm', UNLIMITED)   //Coral Beds
    call f.ModObjectLimit('nntg', UNLIMITED)   //Tidal Guardian
    call f.ModObjectLimit('n005', UNLIMITED)   //Improved Tidal Guardian
    call f.ModObjectLimit('nmrb', UNLIMITED)   //Deep Sea Vault

    call f.ModObjectLimit('nmpe', UNLIMITED)   //Mur'gul Slave
    call f.ModObjectLimit('nmyr', UNLIMITED)   //Myrmidon
    call f.ModObjectLimit('nsnp', UNLIMITED)   //Snap Dragon
    call f.ModObjectLimit('nnsw', UNLIMITED)   //Siren
    call f.ModObjectLimit('nmsc', UNLIMITED)   //Shadowcaster
    call f.ModObjectLimit('nnsu', 6)           //Summoner
    call f.ModObjectLimit('nnrg', 6)           //Royal Guard
    call f.ModObjectLimit('nhyc', 8)           //Dragon Turtle
    call f.ModObjectLimit('nwgs', 8)   	    //Couatl
    call f.ModObjectLimit('e00Y', 4)  	    //Scylla

    call f.ModObjectLimit('Hvsh', 1)  	    //Vashj
    call f.ModObjectLimit('U00S', 1)  	    //Najentus
    call f.ModObjectLimit('Naka', 1)  	    //Akama
    call f.ModObjectLimit('E015', 1)  	    //Akama

    call f.ModObjectLimit('R062', UNLIMITED)   //Redemption path
    call f.ModObjectLimit('R063', UNLIMITED)   //Exile Path
    call f.ModObjectLimit('R065', UNLIMITED)   //Madness Path

  endfunction

endlibrary