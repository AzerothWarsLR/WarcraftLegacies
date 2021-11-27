library ForsakenSetup requires Faction, TeamSetup

  globals
    Faction FACTION_FORSAKEN
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_FORSAKEN = Faction.create("Cult", PLAYER_COLOR_LIGHT_BLUE, "|cff8080ff","ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp")
    set f = FACTION_FORSAKEN
    set f.Team = TEAM_LEGION
    set f.StartingGold = 0
    set f.StartingLumber = 100

    //Buildings
    call f.ModObjectLimit('h089', UNLIMITED)   //Necropolis   
    call f.ModObjectLimit('h08A', UNLIMITED)   //Halls of the Dead 
    call f.ModObjectLimit('h08B', UNLIMITED)   //Black Citadel 
    call f.ModObjectLimit('h08C', UNLIMITED)   //Ziggurat 
    call f.ModObjectLimit('h08D', UNLIMITED)   //Spirit Tower 
    call f.ModObjectLimit('h08E', UNLIMITED)   //Nerubian Tower 
    call f.ModObjectLimit('u010', UNLIMITED)   //Altar of Darkness 
    call f.ModObjectLimit('u011', UNLIMITED)   //Crypt 
    call f.ModObjectLimit('u01J', UNLIMITED)   //Graveyard 
    call f.ModObjectLimit('u016', UNLIMITED)   //Slaughterhouse 
    call f.ModObjectLimit('u01W', UNLIMITED)   //Royal Sepulcur
    call f.ModObjectLimit('u014', UNLIMITED)   //Temple of the Damned    
    call f.ModObjectLimit('u017', UNLIMITED)   //Tomb of Relics   
    call f.ModObjectLimit('u01A', UNLIMITED)   //Undead Shipyard
    call f.ModObjectLimit('h08F', UNLIMITED)   //Improved Spirit Tower
    
    //Units
    call f.ModObjectLimit('u01K', UNLIMITED)   //Acolyte
    call f.ModObjectLimit('h08O', UNLIMITED)   //Ghoul
    call f.ModObjectLimit('h08N', UNLIMITED)   //Abomination
    call f.ModObjectLimit('u01P', 6)           //Plague Catapult
    call f.ModObjectLimit('n07S', UNLIMITED)   //Deadeye
    call f.ModObjectLimit('uban', UNLIMITED)   //Banshee
    call f.ModObjectLimit('h08P', UNLIMITED)   //Sorceress
    call f.ModObjectLimit('u01R', UNLIMITED)   //Apothecary
    call f.ModObjectLimit('n07W', 12)   //Plague Construct
    call f.ModObjectLimit('u02G', 12) 	    //Undercity Guardian
    call f.ModObjectLimit('n07V', 6)           //Elder Banshee
    call f.ModObjectLimit('h009', 6)           //dread knight
    call f.ModObjectLimit('u01V', 2)           //Valyr
    call f.ModObjectLimit('ubot', 12)	    //Undead Transport Ship
    call f.ModObjectLimit('udes', 12) 	    //Undead Frigate
    call f.ModObjectLimit('uubs', 6)          //Undead Battleship

    call f.ModObjectLimit('H049', 1)        //Nathanos
    call f.ModObjectLimit('U01O', 1)        //Putress
    call f.ModObjectLimit('Uvar', 1)        //Varimathras
    call f.ModObjectLimit('Usyl', 1)        //Sylvanas
    
    //Upgrades
    call f.ModObjectLimit('Ruba', UNLIMITED)   //Banshee Adept Training
    call f.ModObjectLimit('R05C', UNLIMITED)   //Banshee Adept Training
    call f.ModObjectLimit('R051', UNLIMITED)   //Apotechary Training
    call f.ModObjectLimit('R02X', UNLIMITED)   // Open Scholomance
    call f.ModObjectLimit('R02A', UNLIMITED)   //Chaos Infusion
  endfunction
    
endlibrary