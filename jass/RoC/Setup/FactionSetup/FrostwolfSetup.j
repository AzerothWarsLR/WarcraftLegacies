library FrostwolfSetup requires Faction, TeamSetup

  globals
    Faction FACTION_FROSTWOLF
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    set FACTION_FROSTWOLF = Faction.create("Frostwolf", PLAYER_COLOR_RED, "|c00ff0303","ReplaceableTextures\\CommandButtons\\BTNThrall.blp")
    set f = FACTION_FROSTWOLF
    set f.Team = TEAM_HORDE
    set f.UndefeatedResearch = 'R05V'
    set f.StartingGold = 150
    set f.StartingLumber = 500

    call f.ModObjectLimit('ogre', UNLIMITED)   //Great Hall
    call f.ModObjectLimit('ostr', UNLIMITED)   //Stronghold
    call f.ModObjectLimit('ofrt', UNLIMITED)   //Fortress
    call f.ModObjectLimit('oalt', UNLIMITED)   //Altar of Storms
    call f.ModObjectLimit('obar', UNLIMITED)   //Barracks
    call f.ModObjectLimit('ofor', UNLIMITED)   //War Mill
    call f.ModObjectLimit('otto', UNLIMITED)   //Tauren Totem
    call f.ModObjectLimit('osld', UNLIMITED)   //Spirit Lodge
    call f.ModObjectLimit('otrb', UNLIMITED)   //Orc Burrow
    call f.ModObjectLimit('owtw', UNLIMITED)   //Watch Tower
    call f.ModObjectLimit('o002', UNLIMITED)   //Improved Watch Tower
    call f.ModObjectLimit('ovln', UNLIMITED)   //Voodoo Lounge
    call f.ModObjectLimit('oshy', UNLIMITED)   //Shipyard

    call f.ModObjectLimit('opeo', UNLIMITED)   //Peon
    call f.ModObjectLimit('ogru', UNLIMITED)   //Grunt
    call f.ModObjectLimit('otau', UNLIMITED)   //Tauren
    call f.ModObjectLimit('ohun', UNLIMITED)   //Troll Headhunter
    call f.ModObjectLimit('ocat', 6)           //Catapult
    call f.ModObjectLimit('otbr', 12)          //Troll Batrider
    call f.ModObjectLimit('odoc', UNLIMITED)   //Troll Witch Doctor
    call f.ModObjectLimit('oshm', UNLIMITED)   //Shaman
    call f.ModObjectLimit('ospw', UNLIMITED)   //Spirit Walker
    call f.ModObjectLimit('o00A', 6)           //Far Seer
    call f.ModObjectLimit('obot', 12)  	    //Transport Ship
    call f.ModObjectLimit('odes', 12)  	    //Orc Frigate
    call f.ModObjectLimit('oosc', UNLIMITED)   //Pack Kodo
    call f.ModObjectLimit('ojgn', 6)          //Juggernaught

    call f.ModObjectLimit('h00C', 1)           //Drek'thar
    call f.ModObjectLimit('Othr', 1)           //Thrall
    call f.ModObjectLimit('Ocbh', 1)           //Cairne
    call f.ModObjectLimit('Orkn', 1)           //Voljin
    call f.ModObjectLimit('Orex', 1)           //Rexxar

    call f.ModObjectLimit('Rows', UNLIMITED)   //Improved Pulverize
    call f.ModObjectLimit('Rost', UNLIMITED)   //Shaman Adept Training
    call f.ModObjectLimit('Rowd', UNLIMITED)   //Witch Doctor Adept Training
    call f.ModObjectLimit('Rowt', UNLIMITED)   //Spirit Walker Adept Training
    call f.ModObjectLimit('R023', UNLIMITED)   //Spiritual Infusion
    call f.ModObjectLimit('Rolf', UNLIMITED)   //Liquid Fire
    call f.ModObjectLimit('Rosp', UNLIMITED)   //Spiked Barricades
    call f.ModObjectLimit('Rorb', UNLIMITED)   //reinforced Defenses
    call f.ModObjectLimit('R00H', UNLIMITED)   //Animal Companion
    call f.ModObjectLimit('R00R', UNLIMITED)   //Improved Chain Lightning
    call f.ModObjectLimit('R00W', UNLIMITED)   //Toughened Hides
    call f.ModObjectLimit('R01Z', UNLIMITED)   //Battle Stations
    call f.SetObjectLevel('R01Z', 1)                //Battle Stations
  endfunction
    
endlibrary