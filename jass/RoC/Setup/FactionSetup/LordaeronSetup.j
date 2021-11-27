library LordaeronSetup requires Faction, TeamSetup, UnitTypesLordaeron

  globals
    Faction FACTION_LORDAERON
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    set FACTION_LORDAERON = Faction.create("Lordaeron", PLAYER_COLOR_BLUE, "|c000042ff","ReplaceableTextures\\CommandButtons\\BTNArthas.blp")
    set f = FACTION_LORDAERON
    set f.Team = TEAM_ALLIANCE
    set f.UndefeatedResearch = 'R05M'
    set f.StartingGold = 150
    set f.StartingLumber = 500

    //Structures
    call f.ModObjectLimit('htow', UNLIMITED)   //Town Hall
    call f.ModObjectLimit('hkee', UNLIMITED)   //Keep
    call f.ModObjectLimit('hcas', UNLIMITED)   //Castle
    call f.ModObjectLimit('hhou', UNLIMITED)   //Farm
    call f.ModObjectLimit('halt', UNLIMITED)   //Altar of Kings
    call f.ModObjectLimit('hbar', UNLIMITED)   //Barracks
    call f.ModObjectLimit('hbla', UNLIMITED)   //Blacksmith
    call f.ModObjectLimit('h035', UNLIMITED)   //Chapel
    call f.ModObjectLimit('hwtw', UNLIMITED)   //Scout Tower
    call f.ModObjectLimit('hgtw', UNLIMITED)   //Guard Tower
    call f.ModObjectLimit('h006', UNLIMITED)   //Guard Tower (Improved)
    call f.ModObjectLimit('hctw', UNLIMITED)   //Cannon Tower
    call f.ModObjectLimit('h007', UNLIMITED)   //Cannon Tower (Improved)
    call f.ModObjectLimit('hshy', UNLIMITED)   //Alliance Shipyard
    call f.ModObjectLimit('nmrk', UNLIMITED)   //Marketplace 
    call f.ModObjectLimit('h06C', UNLIMITED)   //Aviary         
    call f.ModObjectLimit('h094', UNLIMITED)   //Siege Camp   

    //Units
    call f.ModObjectLimit('hpea', UNLIMITED)   //Peasant
    call f.ModObjectLimit('hbot', 12) 	    //Alliance Transport Ship
    call f.ModObjectLimit('hdes', 12) 	    //Alliance Frigate
    call f.ModObjectLimit('hbsh', 6)          //Alliance Battle Ship
    call f.ModObjectLimit('hfoo', UNLIMITED)   //Footman
    call f.ModObjectLimit('hkni', UNLIMITED)   //Knight
    call f.ModObjectLimit('nchp', UNLIMITED)   //Cleric
    call f.ModObjectLimit('h00F', 6)           //Paladin 
    call f.ModObjectLimit('nwe2', 6)           //Thunder Eagle
    call f.ModObjectLimit('h01C', UNLIMITED)   //Longbowman
    call f.ModObjectLimit('n03K', UNLIMITED)   //Chaplain
    call f.ModObjectLimit('hcth', UNLIMITED)   //Silver Hand Squire
    call f.ModObjectLimit('h02Q', 6)           //Pegasus Knight
    call f.ModObjectLimit('e017', 8)           //Scorpion
    call f.ModObjectLimit('o02F', 6)           //Mangonel

    //Demis
    call f.ModObjectLimit('h012', 1)           //Falric

    call f.ModObjectLimit('Hart', 1)           //Arthas
    call f.ModObjectLimit('Huth', 1)           //Uther


    //Upgrades
    call f.ModObjectLimit('R02E', UNLIMITED)   //Chaplain Adept Training
    call f.ModObjectLimit('R00I', UNLIMITED)   //Light's Praise Initiate Training
    call f.ModObjectLimit('R00K', UNLIMITED)   //Power Infusion
    call f.ModObjectLimit('Rhse', UNLIMITED)   //Magic Sentry
    call f.ModObjectLimit('Rhan', UNLIMITED)   //Animal War Training
    call f.ModObjectLimit('Rhlh', UNLIMITED)   //Improved Lumber Harvesting
    call f.ModObjectLimit('Rhac', UNLIMITED)   //Improved Masonry
    call f.ModObjectLimit('R04D', UNLIMITED)   //Exorcism
    call f.ModObjectLimit('R01P', UNLIMITED)   //Ensnare
    call f.ModObjectLimit('R06Q', UNLIMITED)   //Paladin Adept Training
    call f.ModObjectLimit('R04A', UNLIMITED)   //Rapid Fire
    call f.ModObjectLimit('R00B', UNLIMITED)   //Veteran Footmen
    call f.ModObjectLimit('R01Q', UNLIMITED)   //Pegasus Taming
  endfunction
    
endlibrary