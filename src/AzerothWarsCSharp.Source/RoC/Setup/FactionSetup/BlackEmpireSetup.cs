public class BlackEmpireSetup{

    
        Faction FACTION_BLACKEMPIRE
    

    public static void OnInit( ){
     Faction f;
     FACTION_BLACKEMPIRE = Faction.create("Black Empire", PLAYER_COLOR_TURQUOISE, "|cff008080","ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp");
     f = FACTION_BLACKEMPIRE;
     f.Team = TEAM_OLDGOD;
     f.StartingGold = 150;
     f.StartingLumber = 500;

            //Units
            f.ModObjectLimit(FourCC(h06U), UNLIMITED)   ;//Siphoning Crystal
            f.ModObjectLimit(FourCC(h09E), UNLIMITED)   ;//Madness Pool
            f.ModObjectLimit(FourCC(n0B2), UNLIMITED)   ;//Ominous Vault
            f.ModObjectLimit(FourCC(n0AV), UNLIMITED)   ;//Altar of madness
            f.ModObjectLimit(FourCC(n0AT), UNLIMITED)   ;//Cathedral of madness
            f.ModObjectLimit(FourCC(n0AW), UNLIMITED)   ;//Creation hive
            f.ModObjectLimit(FourCC(n0B3), UNLIMITED)   ;//Library of forbidden knowledge
            f.ModObjectLimit(FourCC(n0AX), UNLIMITED)   ;//prison of the unspeakable
            f.ModObjectLimit(FourCC(n0AU), UNLIMITED)   ;//pulsating portal
            f.ModObjectLimit(FourCC(n0AR), UNLIMITED)   ;//twisted halls
            f.ModObjectLimit(FourCC(n0AS), UNLIMITED)   ;//whispering chambers
            f.ModObjectLimit(FourCC(n0AY), UNLIMITED)   ;//acid spitter
            f.ModObjectLimit(FourCC(n0AZ), UNLIMITED)   ;//sleepeless watcher
            f.ModObjectLimit(FourCC(n0B1), UNLIMITED)   ;//Improved Spitter
            f.ModObjectLimit(FourCC(n0B0), UNLIMITED)   ;//Improved Watcher



            //Structures
            f.ModObjectLimit(FourCC(n0B5), UNLIMITED)   ;//Cultist
            f.ModObjectLimit(FourCC(o04Z), 12)          ;//Flying horror
            f.ModObjectLimit(FourCC(n0AH), 4)          ;//Deformed Chimera
            f.ModObjectLimit(FourCC(n0B4), 6)           ;//Reaper
            f.ModObjectLimit(FourCC(o01G), UNLIMITED)   ;//Macemen
            f.ModObjectLimit(FourCC(o04V), UNLIMITED)   ;//Huntsman
            f.ModObjectLimit(FourCC(u029), 12)           ;//Stygian Reavver
            f.ModObjectLimit(FourCC(n077), UNLIMITED)   ;//Sorcerer
            f.ModObjectLimit(FourCC(o04Y), UNLIMITED)   ;//Fateweaver
            f.ModObjectLimit(FourCC(h09F), UNLIMITED)           ;//Gladiator
            f.ModObjectLimit(FourCC(u02F), 2)           ;//Forgotten one

            f.ModObjectLimit(FourCC(E01D), 1)           ;//Volazj
            f.ModObjectLimit(FourCC(U02B), 1)           ;//Soggoth
            f.ModObjectLimit(FourCC(U00P), 1)           ;//Zakajz

            f.ModObjectLimit(FourCC(u02E), 1)           ;//Heralds

            //Upgrades
            f.ModObjectLimit(FourCC(R02A), UNLIMITED)   ;//Void Infusion
            f.ModObjectLimit(FourCC(R07N), UNLIMITED)   ;//Sorcerer Training
            f.ModObjectLimit(FourCC(R07O), UNLIMITED)   ;//Fateweaver Training

            //Masteries

    }

}
