using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class CthunSetup
  {
    public static Faction? Cthun { get; private set; }

    public static void Setup()
    {
      Cthun = new Faction("Ahn'qiraj", PLAYER_COLOR_WHEAT, "|cFFFFDF80",
        "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        IntroText = @"You are playing as the Ancient|cffc6b232 Empire of Ahn'Qiraj|r.

C'thun calls out from the Titan's prison. You must gather your forces and unleash him.

Your surface goldmine will run out quickly, but there are many underground. Raise an army and swarm the tunnels beneath Ahn'Qiraj to capture them.

Once you have built up enough resources, unleash the wrath of the Old Gods on the world."
      };

      //Units
      Cthun.ModObjectLimit(FourCC("n071"), Faction.UNLIMITED); //Pillars of C'thunn
      Cthun.ModObjectLimit(FourCC("o00R"), Faction.UNLIMITED); //Black Pyramid
      Cthun.ModObjectLimit(FourCC("ushp"), Faction.UNLIMITED); //Undead Shipyard
      Cthun.ModObjectLimit(FourCC("o00D"), Faction.UNLIMITED); //Ancient Tomb
      Cthun.ModObjectLimit(FourCC("u01F"), Faction.UNLIMITED); //Altar of the Old Ones
      Cthun.ModObjectLimit(FourCC("u01G"), Faction.UNLIMITED); //Spirit Hall
      Cthun.ModObjectLimit(FourCC("u01H"), Faction.UNLIMITED); //Void Portal
      Cthun.ModObjectLimit(FourCC("u01I"), Faction.UNLIMITED); //Chamber of Wonders
      Cthun.ModObjectLimit(FourCC("u020"), Faction.UNLIMITED); //Monument
      Cthun.ModObjectLimit(FourCC("u021"), Faction.UNLIMITED); //Temple
      Cthun.ModObjectLimit(FourCC("u022"), Faction.UNLIMITED); //Nexus


      //Structures
      Cthun.ModObjectLimit(FourCC("u019"), Faction.UNLIMITED); //Cultist
      Cthun.ModObjectLimit(FourCC("h01K"), 12); //Silithid Overlord
      Cthun.ModObjectLimit(FourCC("o02N"), 24); //Wasp
      Cthun.ModObjectLimit(FourCC("h01N"), 8); //Corrupter
      Cthun.ModObjectLimit(FourCC("o000"), 6); //Silithid Colossus
      Cthun.ModObjectLimit(FourCC("o00L"), Faction.UNLIMITED); //Silithid Reaver
      Cthun.ModObjectLimit(FourCC("n06I"), Faction.UNLIMITED); //Faceless One
      Cthun.ModObjectLimit(FourCC("u013"), Faction.UNLIMITED); //Giant Scarab
      Cthun.ModObjectLimit(FourCC("n05V"), Faction.UNLIMITED); //Faceless Shadow Weaver
      Cthun.ModObjectLimit(FourCC("n060"), Faction.UNLIMITED); //Silithid Tunneler
      Cthun.ModObjectLimit(FourCC("o001"), 6); //Tol)vir Statue

      Cthun.ModObjectLimit(FourCC("U00Z"), 1); //Moam
      Cthun.ModObjectLimit(FourCC("E005"), 1); //Skeram
      Cthun.ModObjectLimit(FourCC("U02A"), 1); //Yorsahj

      //Upgrades
      Cthun.ModObjectLimit(FourCC("Ruwb"), Faction.UNLIMITED); //Web
      Cthun.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Void Infusion
      Cthun.ModObjectLimit(FourCC("R07I"), Faction.UNLIMITED); //Shadow weaver training
      Cthun.ModObjectLimit(FourCC("R07J"), Faction.UNLIMITED); //Shadow weaver training

      FactionManager.Register(Cthun);
    }
  }
}