library FelHordeSetup requires Faction, TeamSetup

  globals
    Faction FACTION_FEL_HORDE
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_FEL_HORDE = Faction.create("Fel Horde", PLAYER_COLOR_GREEN, "|c0020c000","ReplaceableTextures\\CommandButtons\\BTNPitLord.blp")
    set f = FACTION_FEL_HORDE
    set f.Team = TEAM_LEGION
    set f.UndefeatedResearch = 'R05L'
    set f.StartingGold = 300
    set f.StartingLumber = 600

    call f.ModObjectLimit('o02Y', UNLIMITED)   //Great Hall
    call f.ModObjectLimit('o02Z', UNLIMITED)   //Stronghold
    call f.ModObjectLimit('o030', UNLIMITED)   //Fortress
    call f.ModObjectLimit('o02V', UNLIMITED)   //Altar of Storms
    call f.ModObjectLimit('o02W', UNLIMITED)   //Barracks
    call f.ModObjectLimit('o031', UNLIMITED)   //War Mill
    call f.ModObjectLimit('o033', UNLIMITED)   //Spirit Lodge
    call f.ModObjectLimit('o02X', UNLIMITED)   //Bestiary
    call f.ModObjectLimit('o032', UNLIMITED)   //Shipyard
    call f.ModObjectLimit('o034', UNLIMITED)   //Watch Tower
    call f.ModObjectLimit('o035', UNLIMITED)   //Improved Watch Tower
    call f.ModObjectLimit('u00Q', UNLIMITED)   //Hellforge
    call f.ModObjectLimit('n0AM', UNLIMITED)   //Boulder Tower
    call f.ModObjectLimit('n0AN', UNLIMITED)   //Advanced Boulder Tower
    call f.ModObjectLimit('ocbw', UNLIMITED)   //Burrow
    call f.ModObjectLimit('n0AP', UNLIMITED)   //Focal Demon Gate

    call f.ModObjectLimit('nbdk', 6)           //Black Drake
    call f.ModObjectLimit('odkt', 6)           //Eredar Warlock
    call f.ModObjectLimit('nchw', UNLIMITED)   //Fel Orc Warlock
    call f.ModObjectLimit('nchg', UNLIMITED)   //Fel Orc Grunt
    call f.ModObjectLimit('nchr', UNLIMITED)   //Fel Orc Raider
    call f.ModObjectLimit('ncpn', UNLIMITED)   //Fel Orc Peon
    call f.ModObjectLimit('owar', UNLIMITED)   //Horde Cavarly
    call f.ModObjectLimit('o01L', 6)           //Executioner
    call f.ModObjectLimit('o01O', 8)           //Demolisher
    call f.ModObjectLimit('u018', 10)          //Eye of Grillok
    call f.ModObjectLimit('u00V', UNLIMITED)   //Necrolyte
    call f.ModObjectLimit('n057', -UNLIMITED)  //Nether Dragon Hatchling
    call f.ModObjectLimit('n058', UNLIMITED)   //Troll Axethrowers
    call f.ModObjectLimit('obot', 12)  	    //Transport Ship
    call f.ModObjectLimit('odes', 12)  	    //Orc Frigate
    call f.ModObjectLimit('ojgn', 6)          //Juggernaught

    call f.ModObjectLimit('n05T', 1)           //Kazzak 
    call f.ModObjectLimit('n064', 1)           //Voone 
    call f.ModObjectLimit('n08A', 1)           //neltharaktu
    call f.ModObjectLimit('Nmag', 1)           //Magtheridon
    call f.ModObjectLimit('N03D', 1)           //Kargath
    call f.ModObjectLimit('Nbbc', 1)           //Rend
    call f.ModObjectLimit('U02D', 1)           //Teron

    call f.ModObjectLimit('Robf', UNLIMITED)   //Demonic Flux
    call f.ModObjectLimit('R066', UNLIMITED)   //Burning Oil
    call f.ModObjectLimit('R00O', UNLIMITED)   //Ensnare
    call f.ModObjectLimit('Rorb', UNLIMITED)   //Reinforced Defenses
    call f.ModObjectLimit('Rosp', UNLIMITED)   //Spiked Barricades
    call f.ModObjectLimit('R023', UNLIMITED)   //Spiritual Infusion
    call f.ModObjectLimit('R000', -UNLIMITED)  //Skeletal Perserverance
    call f.ModObjectLimit('R024', UNLIMITED)   //Necrolyte adept Training
    call f.ModObjectLimit('R00M', UNLIMITED)   //Warlock Adept Training
    call f.ModObjectLimit('R03I', UNLIMITED)   //Eredar Warlock Adept Training
    call f.ModObjectLimit('R00Y', UNLIMITED)   //Improved Self-Bloodlust
    call f.ModObjectLimit('R03L', UNLIMITED)   //Improved Shadow Infusion
    call f.ModObjectLimit('R036', UNLIMITED)   //Incinerate
    call f.ModObjectLimit('R02L', UNLIMITED)   //Bloodcraze  
    call f.ModObjectLimit('R03O', UNLIMITED)   //Bloodcraze 
    call f.ModObjectLimit('R034', UNLIMITED)   //Enhanced Breath 
    call f.ModObjectLimit('R035', UNLIMITED)   //Improved Firebolt
    call f.ModObjectLimit('R01Z', UNLIMITED)   //Battle Stations
    call f.SetObjectLevel('R01Z', 1)                //Battle Stations


    call f.ModObjectLimit('n05R', 1)           //Felguard
    call f.ModObjectLimit('n06H', 1)           //Pit Fiend
    call f.ModObjectLimit('n07B', 1)           //Queen
    call f.ModObjectLimit('n07D', 1)           //Maiden
    call f.ModObjectLimit('n07o', 1)           //Terror
    call f.ModObjectLimit('n07N', 1)           //Lord


  endfunction
    
endlibrary