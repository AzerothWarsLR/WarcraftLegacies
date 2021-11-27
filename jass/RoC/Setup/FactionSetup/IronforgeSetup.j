library IronforgeSetup requires Faction, TeamSetup

  globals
    Faction FACTION_IRONFORGE
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_IRONFORGE = Faction.create("Ironforge", PLAYER_COLOR_YELLOW, "|C00FFFC01","ReplaceableTextures\\CommandButtons\\BTNHeroMountainKing.blp")
    set f = FACTION_IRONFORGE
    set f.Team = TEAM_ALLIANCE
    set f.UndefeatedResearch = 'R05T'
    set f.StartingGold = 150
    set f.StartingLumber = 500

    //Structures
    call f.ModObjectLimit('h07E', UNLIMITED)   //Town Hall
    call f.ModObjectLimit('h07F', UNLIMITED)   //Keep
    call f.ModObjectLimit('h07G', UNLIMITED)   //Castle
    call f.ModObjectLimit('h02P', UNLIMITED)   //Farm  (Dwarven)
    call f.ModObjectLimit('h01S', UNLIMITED)   //Tavern
    call f.ModObjectLimit('h07B', UNLIMITED)   //Altar of Kings
    call f.ModObjectLimit('h07C', UNLIMITED)   //Barracks
    call f.ModObjectLimit('hlum', UNLIMITED)   //Lumber Mill
    call f.ModObjectLimit('h048', UNLIMITED)   //Blacksmith (Dwarven)
    call f.ModObjectLimit('h042', UNLIMITED)   //Machine Factory
    call f.ModObjectLimit('harm', UNLIMITED)   //Workshop
    call f.ModObjectLimit('hgra', UNLIMITED)   //Gryphon Aviary
    call f.ModObjectLimit('h07H', UNLIMITED)   //Scout Tower
    call f.ModObjectLimit('h07J', UNLIMITED)   //Cannon Tower
    call f.ModObjectLimit('h07K', UNLIMITED)   //Cannon Tower (Improved)
    call f.ModObjectLimit('h07D', UNLIMITED)   //Alliance Shipyard
    call f.ModObjectLimit('n07U', UNLIMITED)   //Marketplace
    call f.ModObjectLimit('h00B', 4)           //Dwarven Keep Tower
    call f.ModObjectLimit('h07I', UNLIMITED)   //Guard Tower
    call f.ModObjectLimit('h07L', UNLIMITED)   //Guard Tower (Improved)
    
    //Units
    call f.ModObjectLimit('h019', UNLIMITED)   //Dwarven Worker
    call f.ModObjectLimit('hbot', 12)   	    //Alliance Transport Ship
    call f.ModObjectLimit('hdes', 12) 	    //Alliance Frigate
    call f.ModObjectLimit('hbsh', 6)          //Alliance Battle Ship
    call f.ModObjectLimit('hrif', UNLIMITED)   //Rifleman
    call f.ModObjectLimit('hmtm', 9)           //Mortar Team
    call f.ModObjectLimit('hgyr', 12)          //Flying Machine
    call f.ModObjectLimit('hgry', 6)           //Gryphon Rider        
    call f.ModObjectLimit('h018', UNLIMITED)   //Dwarven Warrior
    call f.ModObjectLimit('h01L', 6)           //Thane
    call f.ModObjectLimit('h037', UNLIMITED)   //Engineer
    call f.ModObjectLimit('n02D', UNLIMITED)   //War Golem
    call f.ModObjectLimit('h01P', 3)           //Steam Tank
    call f.ModObjectLimit('n00C', UNLIMITED)   //Rune Priest

    call f.ModObjectLimit('h01M', 1)           //Baelgun
    call f.ModObjectLimit('H00S', 1)           //Magni
    call f.ModObjectLimit('Hmbr', 1)           //Muradin

    //Upgrades
    call f.ModObjectLimit('R03H', UNLIMITED)   //Engineering Adept Training
    call f.ModObjectLimit('R00K', UNLIMITED)   //Power Infusion
    call f.ModObjectLimit('R00F', UNLIMITED)   //Mithril Armor
    call f.ModObjectLimit('Rhfl', UNLIMITED)   //Flare
    call f.ModObjectLimit('Rhfs', UNLIMITED)   //Dragmentation Shards
    call f.ModObjectLimit('Rhlh', UNLIMITED)   //Improved Lumber Harvesting
    call f.ModObjectLimit('Rhac', UNLIMITED)   //Improved Masonry
    call f.ModObjectLimit('Rhri', UNLIMITED)   //Long Rifles
    call f.ModObjectLimit('Rhhb', UNLIMITED)   //Storm Hammers
    call f.ModObjectLimit('R063', UNLIMITED)   //Thunder Ale
    call f.ModObjectLimit('Rhme', UNLIMITED)   //Copper Forged Weaponry
    call f.ModObjectLimit('Rhar', UNLIMITED)   //Copper Armor Plating
    call f.ModObjectLimit('R014', UNLIMITED)   //Deeprun Tram
    call f.ModObjectLimit('R00V', UNLIMITED)   //Rune Priest Adept Training
    call f.ModObjectLimit('R00Z', UNLIMITED)   //Armor Penetration Rounds
    call f.ModObjectLimit('R010', UNLIMITED)   //Improved Spell Resistance
    call f.ModObjectLimit('R00T', UNLIMITED)   //Overclock 
    call f.ModObjectLimit('R00N', UNLIMITED)   //Improved Swig
  endfunction
    
endlibrary