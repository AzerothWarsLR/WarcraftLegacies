using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class CthunSetup
  {
    public static Faction FactionCthun { get; private set; }
    
    public static void Setup()
    {
      FactionCthun = new Faction("Ahn'qiraj", PLAYER_COLOR_WHEAT, "|cFFFFDF80",
        "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp")
      {
        Team = TeamSetup.TeamOldgod,
        StartingGold = 150,
        StartingLumber = 500
      };

      //Units
      FactionCthun.ModObjectLimit(FourCC("n071"), Faction.UNLIMITED); //Pillars of C'thunn
      FactionCthun.ModObjectLimit(FourCC("o00R"), Faction.UNLIMITED); //Black Pyramid
      FactionCthun.ModObjectLimit(FourCC("ushp"), Faction.UNLIMITED); //Undead Shipyard
      FactionCthun.ModObjectLimit(FourCC("o00D"), Faction.UNLIMITED); //Ancient Tomb
      FactionCthun.ModObjectLimit(FourCC("u01F"), Faction.UNLIMITED); //Altar of the Old Ones
      FactionCthun.ModObjectLimit(FourCC("u01G"), Faction.UNLIMITED); //Spirit Hall
      FactionCthun.ModObjectLimit(FourCC("u01H"), Faction.UNLIMITED); //Void Portal
      FactionCthun.ModObjectLimit(FourCC("u01I"), Faction.UNLIMITED); //Chamber of Wonders
      FactionCthun.ModObjectLimit(FourCC("u020"), Faction.UNLIMITED); //Monument
      FactionCthun.ModObjectLimit(FourCC("u021"), Faction.UNLIMITED); //Temple
      FactionCthun.ModObjectLimit(FourCC("u022"), Faction.UNLIMITED); //Nexus


      //Structures
      FactionCthun.ModObjectLimit(FourCC("u019"), Faction.UNLIMITED); //Cultist
      FactionCthun.ModObjectLimit(FourCC("h01K"), 12); //Silithid Overlord
      FactionCthun.ModObjectLimit(FourCC("o02N"), 24); //Wasp
      FactionCthun.ModObjectLimit(FourCC("h01N"), 8); //Corrupter
      FactionCthun.ModObjectLimit(FourCC("o000"), 6); //Silithid Colossus
      FactionCthun.ModObjectLimit(FourCC("o00L"), Faction.UNLIMITED); //Silithid Reaver
      FactionCthun.ModObjectLimit(FourCC("n06I"), Faction.UNLIMITED); //Faceless One
      FactionCthun.ModObjectLimit(FourCC("u013"), Faction.UNLIMITED); //Giant Scarab
      FactionCthun.ModObjectLimit(FourCC("n05V"), Faction.UNLIMITED); //Faceless Shadow Weaver
      FactionCthun.ModObjectLimit(FourCC("n060"), Faction.UNLIMITED); //Silithid Tunneler
      FactionCthun.ModObjectLimit(FourCC("o001"), 6); //Tol)vir Statue

      FactionCthun.ModObjectLimit(FourCC("U00Z"), 1); //Moam
      FactionCthun.ModObjectLimit(FourCC("E005"), 1); //Skeram
      FactionCthun.ModObjectLimit(FourCC("U02A"), 1); //Yorsahj

      //Upgrades
      FactionCthun.ModObjectLimit(FourCC("Ruwb"), Faction.UNLIMITED); //Web
      FactionCthun.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Void Infusion
      FactionCthun.ModObjectLimit(FourCC("R07I"), Faction.UNLIMITED); //Shadow weaver training
      FactionCthun.ModObjectLimit(FourCC("R07J"), Faction.UNLIMITED); //Shadow weaver training

      //Masteries
    }
  }
}