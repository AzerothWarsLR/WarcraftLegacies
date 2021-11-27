library KultirasSetup requires Faction, TeamSetup

  globals
    Faction FACTION_KULTIRAS
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_KULTIRAS = Faction.create("Kul'tiras", PLAYER_COLOR_EMERALD, "|cff00781e", "ReplaceableTextures\\CommandButtons\\BTNProudmoore.blp")
    set f = FACTION_KULTIRAS
    set f.Team = TEAM_ALLIANCE
    set f.StartingGold = 150
    set f.StartingLumber = 500

    //Structures
    call f.ModObjectLimit('h062', UNLIMITED)   //Town Hall
    call f.ModObjectLimit('h064', UNLIMITED)   //Keep
    call f.ModObjectLimit('h06I', UNLIMITED)   //Castle
    call f.ModObjectLimit('h07N', UNLIMITED)   //Farm
    call f.ModObjectLimit('h07M', UNLIMITED)   //Altar
    call f.ModObjectLimit('h07R', UNLIMITED)   //Scout Tower
    call f.ModObjectLimit('h07S', UNLIMITED)   //Guard Tower
    call f.ModObjectLimit('h07T', UNLIMITED)   //Improved Guard Tower
    call f.ModObjectLimit('h04U', UNLIMITED)   //Cannon Tower
    call f.ModObjectLimit('h07V', UNLIMITED)   //Improved Cannon Tower
    call f.ModObjectLimit('h07O', UNLIMITED)   //Blacksmith
    call f.ModObjectLimit('h07Q', UNLIMITED)   //Arcane Sanctum
    call f.ModObjectLimit('n07H', UNLIMITED)   //Marketplace
    call f.ModObjectLimit('h07W', UNLIMITED)   //Shipyard
    call f.ModObjectLimit('h06R', UNLIMITED)   //Garrison
    call f.ModObjectLimit('h07P', UNLIMITED)   //Workshop
    call f.ModObjectLimit('h093', UNLIMITED)   //Workshop
    
    //Units
    call f.ModObjectLimit('h01E', UNLIMITED)   //Deckhand
    call f.ModObjectLimit('hbot', 12)   //Alliance Transport Ship
    call f.ModObjectLimit('hdes', 12)   //Alliance Frigate
    call f.ModObjectLimit('h04J', 5)           //Warship
    call f.ModObjectLimit('e007', UNLIMITED)   //Thornspeaker
    call f.ModObjectLimit('n09A', 12)   //Ember Cleric
    call f.ModObjectLimit('n09B', 8)          //Witch Hunter
    call f.ModObjectLimit('h092', 4)          //Order Inquisitor
    call f.ModObjectLimit('h05K', UNLIMITED)   //Tidesage
    call f.ModObjectLimit('h041', UNLIMITED)   //Marine
    call f.ModObjectLimit('e00B', UNLIMITED)   //Thornspeaker Bear
    call f.ModObjectLimit('n009', 12)          //Revenant of the Tides
    call f.ModObjectLimit('n07G', 6)           //muskateer
    call f.ModObjectLimit('n029', 12)          //Sea Giant
    call f.ModObjectLimit('h06J', UNLIMITED)   //Sniper
    call f.ModObjectLimit('o01A', 6)           //Cannon Team
    call f.ModObjectLimit('h04O', 12)          //Bomber
    call f.ModObjectLimit('h04W', 3)           //Siege Tank

    //Upgrades
    call f.ModObjectLimit('R001', UNLIMITED)   //Rising Tides
    call f.ModObjectLimit('R000', UNLIMITED)   //Tidesage Adept Training
    call f.ModObjectLimit('R01O', UNLIMITED)   //Crushing Wave
    call f.ModObjectLimit('R01T', UNLIMITED)   //Cluster Rockets
    call f.ModObjectLimit('R01U', UNLIMITED)   //Improved Barrage
    call f.ModObjectLimit('R05G', UNLIMITED)   //Thornspeaker Training

    //Heroes
    call f.ModObjectLimit('Hapm', 1)           //Admiral
    call f.ModObjectLimit('H05L', 1)           //Lady Ashvane
    call f.ModObjectLimit('E016', 1)           //Lucille

  endfunction
    
endlibrary