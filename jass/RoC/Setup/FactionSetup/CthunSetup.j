library CthunSetup requires Faction, TeamSetup

    globals
        Faction FACTION_CTHUN
    endglobals

    public function OnInit takes nothing returns nothing
     local Faction f   
     set FACTION_CTHUN = Faction.create("Ahn'qiraj", PLAYER_COLOR_WHEAT, "|cFFFFDF80","ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp")
     set f = FACTION_CTHUN
     set f.Team = TEAM_OLDGOD
     set f.StartingGold = 150
     set f.StartingLumber = 500

            //Units
            call f.ModObjectLimit('n071', UNLIMITED)   //Pillars of C'thun
            call f.ModObjectLimit('o00R', UNLIMITED)   //Black Pyramid
            call f.ModObjectLimit('ushp', UNLIMITED)   //Undead Shipyard
            call f.ModObjectLimit('o00D', UNLIMITED)   //Ancient Tomb
            call f.ModObjectLimit('u01F', UNLIMITED)   //Altar of the Old Ones
            call f.ModObjectLimit('u01G', UNLIMITED)   //Spirit Hall
            call f.ModObjectLimit('u01H', UNLIMITED)   //Void Portal
            call f.ModObjectLimit('u01I', UNLIMITED)   //Chamber of Wonders
            call f.ModObjectLimit('u020', UNLIMITED)   //Monument
            call f.ModObjectLimit('u021', UNLIMITED)   //Temple
            call f.ModObjectLimit('u022', UNLIMITED)   //Nexus

            

            //Structures
            call f.ModObjectLimit('u019', UNLIMITED)   //Cultist        
            call f.ModObjectLimit('h01K', 12)          //Silithid Overlord
            call f.ModObjectLimit('o02N', 24)          //Wasp
            call f.ModObjectLimit('h01N', 8)          //Corrupter
            call f.ModObjectLimit('o000', 6)           //Silithid Colossus
            call f.ModObjectLimit('o00L', UNLIMITED)   //Silithid Reaver
            call f.ModObjectLimit('n06I', UNLIMITED)   //Faceless One
            call f.ModObjectLimit('u013', UNLIMITED)   //Giant Scarab
            call f.ModObjectLimit('n05V', UNLIMITED)   //Faceless Shadow Weaver
            call f.ModObjectLimit('n060', UNLIMITED)   //Silithid Tunneler
            call f.ModObjectLimit('o001', 6)           //Tol'vir Statue

            call f.ModObjectLimit('U00Z', 1)           //Moam
            call f.ModObjectLimit('E005', 1)           //Skeram

            //Upgrades
            call f.ModObjectLimit('Ruwb', UNLIMITED)   //Web
            call f.ModObjectLimit('R02A', UNLIMITED)   //Void Infusion
            call f.ModObjectLimit('R07I', UNLIMITED)   //Shadow weaver training
            call f.ModObjectLimit('R07J', UNLIMITED)   //Shadow weaver training

            //Masteries

    endfunction
    
endlibrary