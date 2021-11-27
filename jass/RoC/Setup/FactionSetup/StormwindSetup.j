library StormwindSetup requires Faction, TeamSetup, UnitTypesStormwind

  globals
    Faction FACTION_STORMWIND
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_STORMWIND = Faction.create("Stormwind", PLAYER_COLOR_AQUA, "|CFF106246","ReplaceableTextures\\CommandButtons\\BTNKnight.blp")
    set f = FACTION_STORMWIND
    set f.Team = TEAM_ALLIANCE
    set f.UndefeatedResearch = 'R060'
    set f.StartingGold = 150
    set f.StartingLumber = 500

    //Structures
    call f.ModObjectLimit('h06K', UNLIMITED)   //Town Hall
    call f.ModObjectLimit('h06M', UNLIMITED)   //Keep
    call f.ModObjectLimit('h06N', UNLIMITED)   //Castle
    call f.ModObjectLimit('h072', UNLIMITED)   //Farm
    call f.ModObjectLimit('h06T', UNLIMITED)   //Altar of Kings
    call f.ModObjectLimit('h06E', UNLIMITED)   //Barracks
    call f.ModObjectLimit('h06F', UNLIMITED)   //Blacksmith
    call f.ModObjectLimit('h06A', UNLIMITED)   //Workshop (Stormwind)
    call f.ModObjectLimit('hars', UNLIMITED)   //Arcane Sanctum
    call f.ModObjectLimit('h06V', UNLIMITED)   //Scout Tower
    call f.ModObjectLimit('h06W', UNLIMITED)   //Guard Tower
    call f.ModObjectLimit('h070', UNLIMITED)   //Guard Tower (Improved)
    call f.ModObjectLimit('h06X', UNLIMITED)   //Cannon Tower
    call f.ModObjectLimit('h071', UNLIMITED)   //Cannon Tower (Improved)
    call f.ModObjectLimit('n07T', UNLIMITED)   //Marketplace
    call f.ModObjectLimit('h06D', UNLIMITED)   //Alliance Shipyard
    call f.ModObjectLimit('h06Y', UNLIMITED)   //Arcane Tower
    call f.ModObjectLimit('h06Z', UNLIMITED)   //Arcane Tower (Improved)   
    call f.ModObjectLimit('h024', UNLIMITED)   //Light House         

    //Units
    call f.ModObjectLimit('hpea', UNLIMITED)   //Peasant
    call f.ModObjectLimit('h02O', UNLIMITED)   //Militia
    call f.ModObjectLimit('h03K', 12)          //Marshal
    call f.ModObjectLimit('h03Z', 12)          //Marshal
    call f.ModObjectLimit('h00A', UNLIMITED)   //Spearman
    call f.ModObjectLimit('h01B', UNLIMITED)   //Outriders
    call f.ModObjectLimit('h05F', 6)           //Stormwind Champion
    call f.ModObjectLimit('n05L', 6)           //Conjurer
    call f.ModObjectLimit('h00J', UNLIMITED)   //Clergyman
    call f.ModObjectLimit('n06N', 6)           //Gyrobomber
    call f.ModObjectLimit('n093', UNLIMITED)   //Chaplain
    call f.ModObjectLimit('hbot', 12)   	      //Alliance Transport Ship
    call f.ModObjectLimit('hdes', 12)   	      //Alliance Frigate
    call f.ModObjectLimit('hbsh', 6)          //Alliance Battle Ship
    call f.ModObjectLimit('h060', 3)           //Arathor Flagship



    call f.ModObjectLimit('H00R', 1)           //Varian
    call f.ModObjectLimit('H017', 1)           //Bolvar

    //Researches
    call f.ModObjectLimit('R02E', UNLIMITED)   //Chaplain Adept Training
    call f.ModObjectLimit('R005', UNLIMITED)   //Clergyman Adept Training
    call f.ModObjectLimit('R00K', UNLIMITED)   //Power Infusion
    call f.ModObjectLimit('R02B', UNLIMITED)   //Steel Plating
    call f.ModObjectLimit('Rhan', UNLIMITED)   //Animal War Training
    call f.ModObjectLimit('Rhlh', UNLIMITED)   //Improved Lumber Harvesting
    call f.ModObjectLimit('Rhac', UNLIMITED)   //Improved Masonry
    call f.ModObjectLimit('Rhse', UNLIMITED)   //Magic Sentry
    call f.ModObjectLimit('R014', UNLIMITED)   //Deeprun Tram
    
    //Tier researches
    call f.ModObjectLimit('R02S', UNLIMITED)   //Cathedral of Light
    call f.ModObjectLimit('R02U', UNLIMITED)   //SI:7 Headquarters            
    call f.ModObjectLimit('R02K', UNLIMITED)   //Wizard's Sanctum
    call f.ModObjectLimit('R02V', UNLIMITED)   //Champion's Hall
    call f.ModObjectLimit('R038', UNLIMITED)   //Enforcer Training
    call f.ModObjectLimit('R03E', UNLIMITED)   //Saboteur Training
    call f.ModObjectLimit('R02Y', UNLIMITED)   //Battle Tactics
    call f.ModObjectLimit('R03D', UNLIMITED)   //Veteran Guard
    call f.ModObjectLimit('R02W', UNLIMITED)   //Sanctuary of Light
    call f.ModObjectLimit('R03A', UNLIMITED)   //Focus In The Light
    call f.ModObjectLimit('R03T', UNLIMITED)   //Electric Strike Ritual
    call f.ModObjectLimit('R03U', UNLIMITED)   //Solar Flare Ritual
  endfunction
    
endlibrary