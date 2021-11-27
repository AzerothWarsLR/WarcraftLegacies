library BlackEmpireSetup requires Faction, TeamSetup

    globals
        Faction FACTION_BLACKEMPIRE
    endglobals

    public function OnInit takes nothing returns nothing
     local Faction f   
     set FACTION_BLACKEMPIRE = Faction.create("Black Empire", PLAYER_COLOR_TURQUOISE, "|cff008080","ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp")
     set f = FACTION_BLACKEMPIRE
     set f.Team = TEAM_OLDGOD
     set f.StartingGold = 150
     set f.StartingLumber = 500

            //Units
            call f.ModObjectLimit('h06U', UNLIMITED)   //Siphoning Crystal
            call f.ModObjectLimit('h09E', UNLIMITED)   //Madness Pool
            call f.ModObjectLimit('n0B2', UNLIMITED)   //Ominous Vault
            call f.ModObjectLimit('n0AV', UNLIMITED)   //Altar of madness
            call f.ModObjectLimit('n0AT', UNLIMITED)   //Cathedral of madness
            call f.ModObjectLimit('n0AW', UNLIMITED)   //Creation hive
            call f.ModObjectLimit('n0B3', UNLIMITED)   //Library of forbidden knowledge
            call f.ModObjectLimit('n0AX', UNLIMITED)   //prison of the unspeakable
            call f.ModObjectLimit('n0AU', UNLIMITED)   //pulsating portal
            call f.ModObjectLimit('n0AR', UNLIMITED)   //twisted halls
            call f.ModObjectLimit('n0AS', UNLIMITED)   //whispering chambers
            call f.ModObjectLimit('n0AY', UNLIMITED)   //acid spitter
            call f.ModObjectLimit('n0AZ', UNLIMITED)   //sleepeless watcher
            call f.ModObjectLimit('n0B1', UNLIMITED)   //Improved Spitter
            call f.ModObjectLimit('n0B0', UNLIMITED)   //Improved Watcher

            

            //Structures
            call f.ModObjectLimit('n0B5', UNLIMITED)   //Cultist        
            call f.ModObjectLimit('o04Z', 12)          //Flying horror
            call f.ModObjectLimit('n0AH', 4)          //Deformed Chimera
            call f.ModObjectLimit('n0B4', 6)           //Reaper
            call f.ModObjectLimit('o01G', UNLIMITED)   //Macemen
            call f.ModObjectLimit('o04V', UNLIMITED)   //Huntsman
            call f.ModObjectLimit('u029', 12)           //Stygian Reavver
            call f.ModObjectLimit('n077', UNLIMITED)   //Sorcerer
            call f.ModObjectLimit('o04Y', UNLIMITED)   //Fateweaver
            call f.ModObjectLimit('h09F', UNLIMITED)           //Gladiator
            call f.ModObjectLimit('u02F', 2)           //Forgotten one

            call f.ModObjectLimit('U02A', 1)           //R'khem
            call f.ModObjectLimit('E01D', 1)           //Volazj
            call f.ModObjectLimit('U02B', 1)           //Soggoth

            call f.ModObjectLimit('u02E', 1)           //Herald

            //Upgrades
            call f.ModObjectLimit('R02A', UNLIMITED)   //Void Infusion
            call f.ModObjectLimit('R07N', UNLIMITED)   //Sorcerer Training
            call f.ModObjectLimit('R07O', UNLIMITED)   //Fateweaver Training

            //Masteries

    endfunction
    
endlibrary