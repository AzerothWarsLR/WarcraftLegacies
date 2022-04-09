using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class CthunSetup
  {
    public static Faction FactionCthun { get; private set; }
    
    public static void Setup()
    {
      Faction f;
      FactionCthun = Faction.create("Ahn'qiraj", PLAYER_COLOR_WHEAT, "|cFFFFDF80",
        "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp");
      f = factionCthun;
      f.Team = TEAM_OLDGOD;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Units
      f.ModObjectLimit(FourCC("n071"), Faction.UNLIMITED); //Pillars of C'thunn
      f.ModObjectLimit(FourCC("o00R"), Faction.UNLIMITED); //Black Pyramid
      f.ModObjectLimit(FourCC("ushp"), Faction.UNLIMITED); //Undead Shipyard
      f.ModObjectLimit(FourCC("o00D"), Faction.UNLIMITED); //Ancient Tomb
      f.ModObjectLimit(FourCC("u01F"), Faction.UNLIMITED); //Altar of the Old Ones
      f.ModObjectLimit(FourCC("u01G"), Faction.UNLIMITED); //Spirit Hall
      f.ModObjectLimit(FourCC("u01H"), Faction.UNLIMITED); //Void Portal
      f.ModObjectLimit(FourCC("u01I"), Faction.UNLIMITED); //Chamber of Wonders
      f.ModObjectLimit(FourCC("u020"), Faction.UNLIMITED); //Monument
      f.ModObjectLimit(FourCC("u021"), Faction.UNLIMITED); //Temple
      f.ModObjectLimit(FourCC("u022"), Faction.UNLIMITED); //Nexus


      //Structures
      f.ModObjectLimit(FourCC("u019"), Faction.UNLIMITED); //Cultist
      f.ModObjectLimit(FourCC("h01K"), 12); //Silithid Overlord
      f.ModObjectLimit(FourCC("o02N"), 24); //Wasp
      f.ModObjectLimit(FourCC("h01N"), 8); //Corrupter
      f.ModObjectLimit(FourCC("o000"), 6); //Silithid Colossus
      f.ModObjectLimit(FourCC("o00L"), Faction.UNLIMITED); //Silithid Reaver
      f.ModObjectLimit(FourCC("n06I"), Faction.UNLIMITED); //Faceless One
      f.ModObjectLimit(FourCC("u013"), Faction.UNLIMITED); //Giant Scarab
      f.ModObjectLimit(FourCC("n05V"), Faction.UNLIMITED); //Faceless Shadow Weaver
      f.ModObjectLimit(FourCC("n060"), Faction.UNLIMITED); //Silithid Tunneler
      f.ModObjectLimit(FourCC("o001"), 6); //Tol)vir Statue

      f.ModObjectLimit(FourCC("U00Z"), 1); //Moam
      f.ModObjectLimit(FourCC("E005"), 1); //Skeram
      f.ModObjectLimit(FourCC("U02A"), 1); //Yorsahj

      //Upgrades
      f.ModObjectLimit(FourCC("Ruwb"), Faction.UNLIMITED); //Web
      f.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Void Infusion
      f.ModObjectLimit(FourCC("R07I"), Faction.UNLIMITED); //Shadow weaver training
      f.ModObjectLimit(FourCC("R07J"), Faction.UNLIMITED); //Shadow weaver training

      //Masteries
    }
  }
}