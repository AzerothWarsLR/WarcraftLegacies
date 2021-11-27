library TrollSetup requires Faction, TeamSetup

  globals
    Faction FACTION_TROLL
  endglobals

  public function OnInit takes nothing returns nothing
    local Faction f
    set FACTION_TROLL = Faction.create("Zandalar", PLAYER_COLOR_PEACH, "|cffff8c6c","ReplaceableTextures\\CommandButtons\\BTNHeadHunterBerserker.blp")
    set f = FACTION_TROLL
    set f.Team = TEAM_HORDE
    set f.StartingGold = 150
    set f.StartingLumber = 500

    call f.ModObjectLimit('o03R', UNLIMITED)   //Great Hall
    call f.ModObjectLimit('o03Y', UNLIMITED)   //Stronghold
    call f.ModObjectLimit('o03Z', UNLIMITED)   //Fortress
    call f.ModObjectLimit('o040', UNLIMITED)   //Altar of Storms
    call f.ModObjectLimit('o041', UNLIMITED)   //Barracks
    call f.ModObjectLimit('o042', UNLIMITED)   //War Mill
    call f.ModObjectLimit('o044', UNLIMITED)   //Tauren Totem
    call f.ModObjectLimit('o043', UNLIMITED)   //Spirit Lodge
    call f.ModObjectLimit('o045', UNLIMITED)   //Orc Burrow
    call f.ModObjectLimit('o046', UNLIMITED)   //Watch Tower
    call f.ModObjectLimit('o048', UNLIMITED)   //Improved Watch Tower
    call f.ModObjectLimit('o047', UNLIMITED)   //Voodoo Lounge
    call f.ModObjectLimit('o049', UNLIMITED)   //Shipyard
    call f.ModObjectLimit('o04X', UNLIMITED)   //Loa Shrine

    call f.ModObjectLimit('o04A', UNLIMITED)   //Peon
    call f.ModObjectLimit('h021', UNLIMITED)   //Grunt
    call f.ModObjectLimit('o04D', UNLIMITED)   //Troll Headhunter
    call f.ModObjectLimit('n09E', 2)           //Storm Wyrm
    call f.ModObjectLimit('e00Z', 8)           //Direhorn
    call f.ModObjectLimit('o04F', UNLIMITED)   //Troll Witch Doctor
    call f.ModObjectLimit('o04G', UNLIMITED)   //Haruspex
    call f.ModObjectLimit('o04E', 6)           //Boneseer
    call f.ModObjectLimit('h05D', UNLIMITED)   //Raptor Rider 
    call f.ModObjectLimit('o04W', 24)  	      //Golden Vessel
    call f.ModObjectLimit('ojgn', 6)          //Juggernaught
    call f.ModObjectLimit('o021', 12)          //Ravager
    call f.ModObjectLimit('nftk', 12)          //Warlord
    call f.ModObjectLimit('o02K', 6)          //Bear Rider

    call f.ModObjectLimit('O026', 1)           //Rasthakan
    call f.ModObjectLimit('O01J', 1)           //Zul

    call f.ModObjectLimit('Rers', UNLIMITED)   //Resistant Skin
    call f.ModObjectLimit('R00H', UNLIMITED)   //Animal Companion
    call f.ModObjectLimit('R070', UNLIMITED)   //Haruspex Training
    call f.ModObjectLimit('R071', UNLIMITED)   //Hex Training

  endfunction
    
endlibrary