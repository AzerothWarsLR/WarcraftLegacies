library SentinelsSetup requires Faction, TeamSetup

  globals
    Faction FACTION_SENTINELS
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    
    set FACTION_SENTINELS = Faction.create("Sentinels", PLAYER_COLOR_MINT, "|CFFBFFF80","ReplaceableTextures\\CommandButtons\\BTNPriestessOfTheMoon.blp")
    set f = FACTION_SENTINELS
    set f.Team = TEAM_NIGHT_ELVES
    set f.UndefeatedResearch = 'R05Y'
    set f.StartingGold = 150
    set f.StartingLumber = 500

    call f.ModObjectLimit('e00V', UNLIMITED)   //Temple of Elune
    call f.ModObjectLimit('e00R', UNLIMITED)   //Altar of Watchers 
    call f.ModObjectLimit('e00L', UNLIMITED)   //War Academy
    call f.ModObjectLimit('edob', UNLIMITED)   //Hunter's Hall
    call f.ModObjectLimit('eden', UNLIMITED)   //Ancient of Wonders
    call f.ModObjectLimit('e011', UNLIMITED)   //Night Elf Shipyard
    call f.ModObjectLimit('h03N', UNLIMITED)   //Enchanged Runestone
    call f.ModObjectLimit('h03M', UNLIMITED)   //Runestone
    call f.ModObjectLimit('n06O', UNLIMITED)   //Sentinel Embassy
    call f.ModObjectLimit('n06P', UNLIMITED)   //Sentinel Enclave
    call f.ModObjectLimit('n06J', UNLIMITED)   //Sentinel Outpost
    call f.ModObjectLimit('n06M', UNLIMITED)   //Residence 
    call f.ModObjectLimit('edos', UNLIMITED)   //Roost 
    call f.ModObjectLimit('e00T', UNLIMITED)   //Bastion

    call f.ModObjectLimit('ewsp', UNLIMITED)   //Wisp 
    call f.ModObjectLimit('e006', UNLIMITED)   //Priestess
    call f.ModObjectLimit('n06C', UNLIMITED)   //Trapper
    call f.ModObjectLimit('h04L', 6)           //Priestess of the Moon
    call f.ModObjectLimit('earc', UNLIMITED)   //Archer
    call f.ModObjectLimit('esen', UNLIMITED)   //Huntress
    call f.ModObjectLimit('h08V', UNLIMITED)   //Nightsaber Knight
    call f.ModObjectLimit('ebal', 8)           //Glaive Thrower
    call f.ModObjectLimit('ehpr', 6)           //Hippogryph Rider
    call f.ModObjectLimit('n034', 12)           //Guild Ranger
    call f.ModObjectLimit('nwat', UNLIMITED)   //Nightblade  
    call f.ModObjectLimit('etrs', 12)   	    //Night Elf Transport Ship
    call f.ModObjectLimit('edes', 12)  	    //Night Elf Frigate
    call f.ModObjectLimit('ebsh', 6)          //Night Elf Battleship
    call f.ModObjectLimit('nnmg', 12)          //Redeemed Highborne 

    call f.ModObjectLimit('e009', 1)           //Naisha
    call f.ModObjectLimit('Etyr', 1)           //Tyrande
    call f.ModObjectLimit('E002', 1)           //Shandris
    call f.ModObjectLimit('Ewrd', 1)           //Maiev
    call f.ModObjectLimit('O02E', 1)           //Jarod

    call f.ModObjectLimit('R00S', UNLIMITED)   //Priestess Adept Training
    call f.ModObjectLimit('R064', UNLIMITED)   //Sentinel Fortifications
    call f.ModObjectLimit('R01W', UNLIMITED)   //Trapper Adept Training  
    call f.ModObjectLimit('R026', UNLIMITED)   //Elune's Power Infusion
    call f.ModObjectLimit('Reib', UNLIMITED)   //Improved Bows
    call f.ModObjectLimit('Reuv', UNLIMITED)   //Ultravision
    call f.ModObjectLimit('Remg', UNLIMITED)   //Upgraded Moon Glaive
    call f.ModObjectLimit('Roen', UNLIMITED)   //Ensnare
    call f.ModObjectLimit('R04E', UNLIMITED)   //Ysera's Gift (World Tree upgrade)
    call f.ModObjectLimit('R002', UNLIMITED)   //Blackwald Enhancement
    call f.ModObjectLimit('R03J', UNLIMITED)   //Wind Walk
    call f.ModObjectLimit('R013', UNLIMITED)   //Elune's Blessing
  endfunction
    
endlibrary