library GilneasSetup requires Faction, TeamSetup

  globals
    Faction FACTION_GILNEAS
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_GILNEAS = Faction.create("Gilneas", PLAYER_COLOR_COAL, "|cff808080", "ReplaceableTextures\\CommandButtons\\BTNGreymane.blp")
    set f = FACTION_GILNEAS
    set f.Team = TEAM_ALLIANCE
    set f.StartingGold = 150
    set f.StartingLumber = 200

    //Structures
    call f.ModObjectLimit('h01R', UNLIMITED)   //Town Hall
    call f.ModObjectLimit('h023', UNLIMITED)   //Keep
    call f.ModObjectLimit('h02C', UNLIMITED)   //Castle
    call f.ModObjectLimit('h02F', UNLIMITED)   //Farm
    call f.ModObjectLimit('h02X', UNLIMITED)   //Altar
    call f.ModObjectLimit('h039', UNLIMITED)   //Scout Tower
    call f.ModObjectLimit('h03A', UNLIMITED)   //Guard Tower
    call f.ModObjectLimit('h03B', UNLIMITED)   //Cannon Tower
    call f.ModObjectLimit('h03D', UNLIMITED)   //Temple of the cursed
    call f.ModObjectLimit('h03E', UNLIMITED)   //Training Hall
    call f.ModObjectLimit('n008', UNLIMITED)   //Marketplace
    call f.ModObjectLimit('h03H', UNLIMITED)   //Shipyard
    call f.ModObjectLimit('h03O', UNLIMITED)   //Blacksmith
    call f.ModObjectLimit('h03Q', UNLIMITED)   //Garrison
    call f.ModObjectLimit('h052', UNLIMITED)   //Improved Guard Tower
    call f.ModObjectLimit('h04N', UNLIMITED)   //Improved Cannon Tower
    
    //Units
    call f.ModObjectLimit('hpea', UNLIMITED)   //Peasant
    call f.ModObjectLimit('hbot', 12)   //Alliance Transport Ship
    call f.ModObjectLimit('hdes', 12)   //Alliance Frigate
    call f.ModObjectLimit('hbsh', 6)          //Alliance Battle Ship
    call f.ModObjectLimit('n06K', UNLIMITED)   //Wildsoul
    call f.ModObjectLimit('h04M', UNLIMITED)   //Cleric
    call f.ModObjectLimit('h04E', UNLIMITED)   //Protector
    call f.ModObjectLimit('n06L', UNLIMITED)   //Armored Wolf
    call f.ModObjectLimit('o01V', 6)           //Greyguard
    call f.ModObjectLimit('n029', 12)          //Sea Giant
    call f.ModObjectLimit('h03L', UNLIMITED)   //Shotgunner
    call f.ModObjectLimit('nsgt', UNLIMITED)   //Spider
    call f.ModObjectLimit('n067', UNLIMITED)   //Spider
    call f.ModObjectLimit('o04U', 6)           //Mangonel
    call f.ModObjectLimit('n06Z', 6)           //Gunship
    call f.ModObjectLimit('n06Q', 12)          //Royal Guard

    call f.ModObjectLimit('E01E', 1)          //Goldrinn

    //Upgrades
    call f.ModObjectLimit('R04O', UNLIMITED)   //Cleric Training
    call f.ModObjectLimit('R04P', UNLIMITED)   //Scythe Training
    call f.ModObjectLimit('R00K', UNLIMITED)   //Power Infusion
  endfunction
    
endlibrary