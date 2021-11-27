
library DruidsSetup requires Faction, TeamSetup

  globals
    Faction FACTION_DRUIDS
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_DRUIDS = Faction.create("Druids", PLAYER_COLOR_BROWN, "|c004e2a04","ReplaceableTextures\\CommandButtons\\BTNFurion.blp")
    set f = FACTION_DRUIDS
    set f.Team = TEAM_NIGHT_ELVES
    set f.UndefeatedResearch = 'R06E'
    set f.StartingGold = 150
    set f.StartingLumber = 500

    call f.ModObjectLimit('etol', UNLIMITED)   //Tree of Life  
    call f.ModObjectLimit('etoa', UNLIMITED)   //Tree of Ages
    call f.ModObjectLimit('etoe', UNLIMITED)   //Tree of Eternity  
    call f.ModObjectLimit('emow', UNLIMITED)   //Moon Well
    call f.ModObjectLimit('eate', UNLIMITED)   //Altar of Elders
    call f.ModObjectLimit('eaoe', UNLIMITED)   //Ancient of Lore
    call f.ModObjectLimit('eaow', UNLIMITED)   //Ancient of Wind
    call f.ModObjectLimit('eaom', UNLIMITED)   //Ancient of war
    call f.ModObjectLimit('etrp', UNLIMITED)   //Ancient Protector
    call f.ModObjectLimit('e010', UNLIMITED)   //Hunter's Hall
    call f.ModObjectLimit('e019', UNLIMITED)   //Ancient of Wonders  
    call f.ModObjectLimit('eshy', UNLIMITED)   //Night Elf Shipyard 
    call f.ModObjectLimit('e000', UNLIMITED)   //Improved Ancient Protector 

    call f.ModObjectLimit('ewsp', UNLIMITED)   //Wisp 
    call f.ModObjectLimit('edry', UNLIMITED)   //Dryad
    call f.ModObjectLimit('edot', UNLIMITED)   //Druid of the Talon 
    call f.ModObjectLimit('emtg', 12)          //Mountain Giant
    call f.ModObjectLimit('efdr', 6)           //Faerie Dragon 
    call f.ModObjectLimit('edoc', UNLIMITED)   //Druid of the Claw
    call f.ModObjectLimit('edcm', UNLIMITED)   //Druid of the Claw bear form
    call f.ModObjectLimit('e00N', 6)           //Keeper of the Grove
    call f.ModObjectLimit('n05H', UNLIMITED)   //Furbolg
    call f.ModObjectLimit('n065', 6)           //Green Dragon
    call f.ModObjectLimit('etrs', 12)   	    //Night Elf Transport Ship
    call f.ModObjectLimit('edes', 12) 	    //Night Elf Frigate
    call f.ModObjectLimit('ebsh', 6)          //Night Elf Battleship

    call f.ModObjectLimit('Ecen', 1)           //Cenarius
    call f.ModObjectLimit('E00K', 1)           //Fandral

    call f.ModObjectLimit('Redt', UNLIMITED)   //Druid of the Talon Adept Training
    call f.ModObjectLimit('Renb', UNLIMITED)   //Nature's Blessing
    call f.ModObjectLimit('Rers', UNLIMITED)   //Resistant Skin
    call f.ModObjectLimit('Reuv', UNLIMITED)   //Ultravision
    call f.ModObjectLimit('Rews', UNLIMITED)   //Well Spring
    call f.ModObjectLimit('R01H', UNLIMITED)   //Malorne's Power Infusion
    call f.ModObjectLimit('Redc', UNLIMITED)   //Druid of the Claw Adept Training
    call f.ModObjectLimit('R04E', UNLIMITED)   //Ysera's Gift
    call f.ModObjectLimit('R02G', UNLIMITED)   //Emerald Flames
    call f.ModObjectLimit('R05X', UNLIMITED)   //Blessing of Ursoc
    call f.ModObjectLimit('R002', UNLIMITED)   //Blackwald Enhancement
    call f.ModObjectLimit('R00A', UNLIMITED)   //Improved Thorns
    call f.ModObjectLimit('R02T', UNLIMITED)   //Improved Moonwells
    call f.ModObjectLimit('R033', UNLIMITED)   //Limber Timber
    call f.ModObjectLimit('R046', UNLIMITED)   //Grasping Vines
    call f.ModObjectLimit('R047', UNLIMITED)   //Crippling Poison
    call f.ModObjectLimit('R048', UNLIMITED)   //Deadly Poison
    call f.ModObjectLimit('R008', UNLIMITED)   //Improved Natures FuryR015
    call f.ModObjectLimit('R015', UNLIMITED)   //Improved Mana Flare

  endfunction
    
endlibrary