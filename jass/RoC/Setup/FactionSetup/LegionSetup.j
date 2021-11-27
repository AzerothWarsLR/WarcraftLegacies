library LegionSetup requires Faction, TeamSetup

  globals
    Faction FACTION_LEGION
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_LEGION = Faction.create("Legion", PLAYER_COLOR_PEANUT, "|CFFBF8F4F","ReplaceableTextures\\CommandButtons\\BTNKiljaedin.blp")
    set f = FACTION_LEGION
    set f.UndefeatedResearch = 'R04T'
    set f.Team = TEAM_LEGION
    set f.StartingGold = 150
    set f.StartingLumber = 500
    //Structures
    call f.ModObjectLimit('u00H', UNLIMITED)   //Legion Defensive Pylon
    call f.ModObjectLimit('u00I', UNLIMITED)   //Improved Defensive Pylon
    call f.ModObjectLimit('u00F', UNLIMITED)   //Dormant Spire
    call f.ModObjectLimit('u00C', UNLIMITED)   //Legion Bastion
    call f.ModObjectLimit('u00N', UNLIMITED)   //Burning Citadel
    call f.ModObjectLimit('u00U', UNLIMITED)   //Hell Palace
    call f.ModObjectLimit('n040', UNLIMITED)   //Armory
    call f.ModObjectLimit('u009', UNLIMITED)   //Undead Shipyard
    call f.ModObjectLimit('u00E', UNLIMITED)   //Generator
    call f.ModObjectLimit('u01N', UNLIMITED)   //Burning Altar
    call f.ModObjectLimit('u015', UNLIMITED)   //Unholy Reliquary
    call f.ModObjectLimit('u006', UNLIMITED)   //Void Summoning Spire
    call f.ModObjectLimit('ndmg', UNLIMITED)   //Demon Gate
    call f.ModObjectLimit('n04N', UNLIMITED)   //Infernal Machine Factory
    call f.ModObjectLimit('n04Q', UNLIMITED)   //Nether Pit
  
    //Units
    call f.ModObjectLimit('u00D', UNLIMITED)   //Legion Herald
    call f.ModObjectLimit('u007', 6)           //Dreadlord
    call f.ModObjectLimit('n04P', UNLIMITED)   //Warlock
    call f.ModObjectLimit('ninc', UNLIMITED)   //Burning archer
    call f.ModObjectLimit('n04K', UNLIMITED)   //Succubus
    call f.ModObjectLimit('n04J', UNLIMITED)   //Felstalker
    call f.ModObjectLimit('ubot', 12) 	        //Undead Transport SHip
    call f.ModObjectLimit('udes', 12) 	        //Undead Frigate
    call f.ModObjectLimit('uubs', 6)          //Undead Battleship         
    call f.ModObjectLimit('n04O', 6)           //Doomguard
    call f.ModObjectLimit('n04L', 6)           //Infernal Juggernaut
    call f.ModObjectLimit('ninf', 12)          //Infernal
    call f.ModObjectLimit('n04H', UNLIMITED)   //Fel Guard
    call f.ModObjectLimit('n04U', 4)           //Dragon
    call f.ModObjectLimit('n03L', 4)           //Barge

    call f.ModObjectLimit('n05R', 1)           //Felguard
    call f.ModObjectLimit('n06H', 1)           //Pit Fiend
    call f.ModObjectLimit('n07B', 1)           //Queen
    call f.ModObjectLimit('n07D', 1)           //Maiden
    call f.ModObjectLimit('n07o', 1)           //Terror
    call f.ModObjectLimit('n07N', 1)           //Lord

    //Researches
    call f.ModObjectLimit('R02C', UNLIMITED)   //Acute Sensors
    call f.ModObjectLimit('R02A', UNLIMITED)   //Chaos Infusion
    call f.ModObjectLimit('R028', UNLIMITED)   //Shadow Priest Adept Training
    call f.ModObjectLimit('R027', UNLIMITED)   //Warlock Adept Training
    call f.ModObjectLimit('R01Y', UNLIMITED)   //Astral Walk
    call f.ModObjectLimit('R04G', UNLIMITED)   //Improved Carrion Swarm
    call f.ModObjectLimit('R03Z', UNLIMITED)   //War Plating
    call f.ModObjectLimit('R040', UNLIMITED)   //Flying horrors
    
    //Heroes
    call f.ModObjectLimit('U00L', 1)           //Anetheron
    call f.ModObjectLimit('Umal', 1)           //Mal'ganis
    call f.ModObjectLimit('Utic', 1)           //Tichondrius

  endfunction
    
endlibrary