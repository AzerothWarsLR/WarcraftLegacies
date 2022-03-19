using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup.FactionSetup
{
  public class CthunSetup{

    
    Faction FACTION_CTHUN
    

    public static void Setup( ){
      Faction f;
      FACTION_CTHUN = Faction.create("Ahn'qiraj", PLAYER_COLOR_WHEAT, "|cFFFFDF80","ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp");
      f = FACTION_CTHUN;
      f.Team = TEAM_OLDGOD;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Units
      f.ModObjectLimit(FourCC(n071), UNLIMITED)   ;//Pillars of C'thunn
      f.ModObjectLimit(FourCC(o00R), UNLIMITED)   ;//Black Pyramid
      f.ModObjectLimit(FourCC(ushp), UNLIMITED)   ;//Undead Shipyard
      f.ModObjectLimit(FourCC(o00D), UNLIMITED)   ;//Ancient Tomb
      f.ModObjectLimit(FourCC(u01F), UNLIMITED)   ;//Altar of the Old Ones
      f.ModObjectLimit(FourCC(u01G), UNLIMITED)   ;//Spirit Hall
      f.ModObjectLimit(FourCC(u01H), UNLIMITED)   ;//Void Portal
      f.ModObjectLimit(FourCC(u01I), UNLIMITED)   ;//Chamber of Wonders
      f.ModObjectLimit(FourCC(u020), UNLIMITED)   ;//Monument
      f.ModObjectLimit(FourCC(u021), UNLIMITED)   ;//Temple
      f.ModObjectLimit(FourCC(u022), UNLIMITED)   ;//Nexus



      //Structures
      f.ModObjectLimit(FourCC(u019), UNLIMITED)   ;//Cultist
      f.ModObjectLimit(FourCC(h01K), 12)          ;//Silithid Overlord
      f.ModObjectLimit(FourCC(o02N), 24)          ;//Wasp
      f.ModObjectLimit(FourCC(h01N), 8)          ;//Corrupter
      f.ModObjectLimit(FourCC(o000), 6)           ;//Silithid Colossus
      f.ModObjectLimit(FourCC(o00L), UNLIMITED)   ;//Silithid Reaver
      f.ModObjectLimit(FourCC(n06I), UNLIMITED)   ;//Faceless One
      f.ModObjectLimit(FourCC(u013), UNLIMITED)   ;//Giant Scarab
      f.ModObjectLimit(FourCC(n05V), UNLIMITED)   ;//Faceless Shadow Weaver
      f.ModObjectLimit(FourCC(n060), UNLIMITED)   ;//Silithid Tunneler
      f.ModObjectLimit(FourCC(o001), 6)           ;//Tol)vir Statue

      f.ModObjectLimit(FourCC(U00Z), 1)           ;//Moam
      f.ModObjectLimit(FourCC(E005), 1)           ;//Skeram
      f.ModObjectLimit(FourCC(U02A), 1)           ;//Yorsahj

      //Upgrades
      f.ModObjectLimit(FourCC(Ruwb), UNLIMITED)   ;//Web
      f.ModObjectLimit(FourCC(R02A), UNLIMITED)   ;//Void Infusion
      f.ModObjectLimit(FourCC(R07I), UNLIMITED)   ;//Shadow weaver training
      f.ModObjectLimit(FourCC(R07J), UNLIMITED)   ;//Shadow weaver training

      //Masteries

    }

  }
}
