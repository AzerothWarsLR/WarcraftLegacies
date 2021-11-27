library QuelthalasSetup requires Faction, TeamSetup

  globals
    Faction FACTION_QUELTHALAS
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    set FACTION_QUELTHALAS = Faction.create("Quel'thalas", PLAYER_COLOR_CYAN, "|C0000FFFF","ReplaceableTextures\\CommandButtons\\BTNSylvanusWindrunner.blp")
    set f = FACTION_QUELTHALAS
    set f.Team = TEAM_ALLIANCE
    set f.UndefeatedResearch = 'R05U'
    set f.StartingGold = 150
    set f.StartingLumber = 500
 
    //Structures
    call f.ModObjectLimit('h033', UNLIMITED)   //Steading
    call f.ModObjectLimit('h03S', UNLIMITED)   //Mansion
    call f.ModObjectLimit('h03T', UNLIMITED)   //Palace
    call f.ModObjectLimit('h01H', UNLIMITED)   //Altar of Prowess
    call f.ModObjectLimit('h02Y', UNLIMITED)   //Artisan's Hall
    call f.ModObjectLimit('h034', UNLIMITED)   //Arcane Sanctum (Quel'thalas)
    call f.ModObjectLimit('h073', UNLIMITED)   //Scout Tower
    call f.ModObjectLimit('h074', UNLIMITED)   //Arcane Tower
    call f.ModObjectLimit('h075', UNLIMITED)   //Arcane Tower (Improved)
    call f.ModObjectLimit('negt', UNLIMITED)   //High Elven Guard Tower
    call f.ModObjectLimit('n003', UNLIMITED)   //High Elven Guard Tower (Improved)
    call f.ModObjectLimit('h04V', UNLIMITED)   //Arcane Vault (Elven)
    call f.ModObjectLimit('nheb', UNLIMITED)   //Cantonment
    call f.ModObjectLimit('n0A2', UNLIMITED)   //Consortium
    call f.ModObjectLimit('h03J', UNLIMITED)   //Academy
    call f.ModObjectLimit('h077', UNLIMITED)   //Alliance Shipyard
    call f.ModObjectLimit('nefm', UNLIMITED)   //Residence
    
    //Units
    call f.ModObjectLimit('nbee', UNLIMITED)   //Elven Worker
    call f.ModObjectLimit('hbot', 12)   	    //Alliance Transport Ship
    call f.ModObjectLimit('hdes', 12)  	    //Alliance Frigate
    call f.ModObjectLimit('hbsh', 6)          //Alliance Battle Ship 
    call f.ModObjectLimit('hhes', UNLIMITED)   //Elven Warrior
    call f.ModObjectLimit('hmpr', UNLIMITED)   //Priest
    call f.ModObjectLimit('hsor', UNLIMITED)   //Sorceress
    call f.ModObjectLimit('hdhw', 6)           //Dragonhawk Rider
    call f.ModObjectLimit('nhea', UNLIMITED)   //Archer
    call f.ModObjectLimit('e008', 6)           //Elven Ballista
    call f.ModObjectLimit('n00A', 6)           //Farstrider
    call f.ModObjectLimit('n063', 12)          //Magus 
    call f.ModObjectLimit('hspt', UNLIMITED)   //Spell Breaker    
    call f.ModObjectLimit('u00J', 2)           //Arcane Wagon

    //Demi-heroes
    call f.ModObjectLimit('n075', 1)           //Vareesa 
    call f.ModObjectLimit('Hvwd', 1)           //Sylvanas
    call f.ModObjectLimit('H00Q', 1)           //Anasterian
    call f.ModObjectLimit('H098', 1)           //Pathaleone
    call f.ModObjectLimit('H04F', 1)           //Rommath
    call f.ModObjectLimit('H02E', 1)           //Lorthemar

    //Upgrades
    call f.ModObjectLimit('R01S', UNLIMITED)   //Aimed Shot
    call f.ModObjectLimit('R00G', UNLIMITED)   //Feint
    call f.ModObjectLimit('R01R', UNLIMITED)   //Improved Bows
    call f.ModObjectLimit('R029', UNLIMITED)   //Magus Adept Training
    call f.ModObjectLimit('R00K', UNLIMITED)   //Power Infusion
    call f.ModObjectLimit('Rhcd', UNLIMITED)   //Cloud
    call f.ModObjectLimit('Rhss', UNLIMITED)   //Control Magic
    call f.ModObjectLimit('Rhlh', UNLIMITED)   //Improved Lumber Harvesting
    call f.ModObjectLimit('Rhac', UNLIMITED)   //Improved Masonry
    call f.ModObjectLimit('Rhse', UNLIMITED)   //Magic Sentry
    call f.ModObjectLimit('Rhpt', UNLIMITED)   //Priest Adept Training
    call f.ModObjectLimit('Rhst', UNLIMITED)   //Sorceress Adept Training
    
    //Masteries
    call f.ModObjectLimit('R01A', UNLIMITED)   //Arcane Empowerment
    call f.ModObjectLimit('R00T', UNLIMITED)   //Archery Mastery
    call f.ModObjectLimit('R00H', UNLIMITED)   //Blood Elf Mastery
    
    //Paths
    call f.ModObjectLimit('R046', UNLIMITED)   //Quel'thelas Full Mobilization
    call f.ModObjectLimit('R04U', UNLIMITED)   //Solo Path
  endfunction
    
endlibrary