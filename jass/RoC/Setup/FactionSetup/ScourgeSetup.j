library ScourgeSetup requires Faction, TeamSetup, UnitTypesScourge

  globals
    Faction FACTION_SCOURGE
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_SCOURGE = Faction.create("Scourge", PLAYER_COLOR_PURPLE, "|c00540081","ReplaceableTextures\\CommandButtons\\BTNRevenant.blp")
    set f = FACTION_SCOURGE
    set f.Team = TEAM_LEGION
    set f.UndefeatedResearch = 'R05K'
    set f.StartingGold = 150
    set f.StartingLumber = 500

    //Buildings
    call f.ModObjectLimit('unpl', UNLIMITED)   //Necropolis   
    call f.ModObjectLimit('unp1', UNLIMITED)   //Halls of the Dead 
    call f.ModObjectLimit('unp2', UNLIMITED)   //Black Citadel 
    call f.ModObjectLimit('uzig', UNLIMITED)   //Ziggurat 
    call f.ModObjectLimit('uzg1', UNLIMITED)   //Spirit Tower 
    call f.ModObjectLimit('uzg2', UNLIMITED)   //Nerubian Tower 
    call f.ModObjectLimit('uaod', UNLIMITED)   //Altar of Darkness 
    call f.ModObjectLimit('usep', UNLIMITED)   //Crypt 
    call f.ModObjectLimit('ugrv', UNLIMITED)   //Graveyard 
    call f.ModObjectLimit('uslh', UNLIMITED)   //Slaughterhouse 
    call f.ModObjectLimit('utod', UNLIMITED)   //Temple of the Damned 
    call f.ModObjectLimit('ubon', UNLIMITED)   //Boneyard      
    call f.ModObjectLimit('utom', UNLIMITED)   //Tomb of Relics   
    call f.ModObjectLimit('ushp', UNLIMITED)   //Undead Shipyard
    call f.ModObjectLimit('u002', UNLIMITED)   //Improved Spirit Tower
    call f.ModObjectLimit('u003', UNLIMITED)   //Improved Nerubian Tower
    
    //Units
    call f.ModObjectLimit('uaco', UNLIMITED)   //Acolyte
    call f.ModObjectLimit('ushd', UNLIMITED)   //Shade
    call f.ModObjectLimit('ugho', UNLIMITED)   //Ghoul
    call f.ModObjectLimit('uabo', UNLIMITED)   //Abomination
    call f.ModObjectLimit('umtw', 6)           //Meat Wagon
    call f.ModObjectLimit('ucry', UNLIMITED)   //Crypt Fiend
    call f.ModObjectLimit('ugar', 12)           //Gargoyle
    call f.ModObjectLimit('h02G', UNLIMITED)   //Vrykul Warrior
    call f.ModObjectLimit('h061', 12)           //Vrykul Champion
    call f.ModObjectLimit('h00P', 4)           //Mammoth rider
    call f.ModObjectLimit('uban', UNLIMITED)   //Banshee
    call f.ModObjectLimit('unec', UNLIMITED)   //Necromancer
    call f.ModObjectLimit('uobs', 4)           //Obsidian Statue
    call f.ModObjectLimit('ufro', 4)           //Frost Wyrm
    call f.ModObjectLimit('h00H', 6)           //Death Knight
    call f.ModObjectLimit('ubot', 12)	    //Undead Transport Ship
    call f.ModObjectLimit('udes', 12) 	    //Undead Frigate
    call f.ModObjectLimit('uubs', 6)          //Undead Battleship
    call f.ModObjectLimit('ubsp', 4)           //Destroyer
    call f.ModObjectLimit('nfgl', 2)           //Plague Titan

    //Demi-Heroes
    call f.ModObjectLimit('ubdd', 1)           //Sapphiron
    call f.ModObjectLimit('uswb', 1)           //Banshee
    call f.ModObjectLimit('Uanb', 1)           //Anubarak
    call f.ModObjectLimit('U001', 1)           //Keltuzad
    call f.ModObjectLimit('U00A', 1)           //Rivendare
    
    //Upgrades
    call f.ModObjectLimit('Ruba', UNLIMITED)   //Banshee Adept Training
    call f.ModObjectLimit('Rubu', UNLIMITED)   //Burrow
    call f.ModObjectLimit('Ruex', UNLIMITED)   //Exhume Corpses
    call f.ModObjectLimit('Rufb', UNLIMITED)   //Freezing Breath
    call f.ModObjectLimit('Rugf', UNLIMITED)   //Ghoul Frenzy
    call f.ModObjectLimit('Rune', UNLIMITED)   //Necromancer Adept Training
    call f.ModObjectLimit('Ruwb', UNLIMITED)   //Web
    call f.ModObjectLimit('R02A', UNLIMITED)   //Chaos Infusion
    call f.ModObjectLimit('R00Q', UNLIMITED)   //Chilling Aura
    call f.ModObjectLimit('R04V', UNLIMITED)   //Improved Hypothermic Breath
    call f.ModObjectLimit('R01X', UNLIMITED)   //Epidemic
    call f.ModObjectLimit('R01D', UNLIMITED)   //Piercing Screech
    call f.ModObjectLimit('R06N', UNLIMITED)   //Improved Orb of Annihilation
    call f.ModObjectLimit('Rusl', UNLIMITED)   //SkeletalMastery
    call f.ModObjectLimit('Rusm', UNLIMITED)   //SkeletalLongevity
  endfunction
    
endlibrary