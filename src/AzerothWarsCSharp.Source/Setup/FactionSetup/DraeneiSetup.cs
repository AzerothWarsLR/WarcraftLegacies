
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class DraeneiSetup{
    public static Faction Draenei { get; private set; }
    
    public static void Setup( ){
      Faction f;

      DraeneiSetup.Draenei = Faction.create("The Exodar", PLAYER_COLOR_NAVY, "|cff000080","ReplaceableTextures\\CommandButtons\\BTNBOSSVelen.blp");
      f = DraeneiSetup.Draenei;
      f.Team = TEAM_NIGHT_ELVES;
      f.UndefeatedResearch = FourCC("R06E");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      f.ModObjectLimit(FourCC("o02P"), Faction.UNLIMITED)   ;//Crystal Hall
      f.ModObjectLimit(FourCC("o050"), Faction.UNLIMITED)   ;//Metropolis
      f.ModObjectLimit(FourCC("o051"), Faction.UNLIMITED)   ;//Divine Citadel
      f.ModObjectLimit(FourCC("o058"), Faction.UNLIMITED)   ;//Altar of Light
      f.ModObjectLimit(FourCC("o052"), Faction.UNLIMITED)   ;//Ceremonial Altar
      f.ModObjectLimit(FourCC("o053"), Faction.UNLIMITED)   ;//Smithery
      f.ModObjectLimit(FourCC("o054"), Faction.UNLIMITED)   ;//Astral Sanctum
      f.ModObjectLimit(FourCC("o055"), Faction.UNLIMITED)   ;//Crystal Spire
      f.ModObjectLimit(FourCC("o056"), Faction.UNLIMITED)   ;//Arcane Well
      f.ModObjectLimit(FourCC("o057"), Faction.UNLIMITED)   ;//Vaults of Relic
      f.ModObjectLimit(FourCC("u00U"), Faction.UNLIMITED)   ;//Crystal Protector
      f.ModObjectLimit(FourCC("u01Q"), Faction.UNLIMITED)   ;//Crystal Protector improved
      f.ModObjectLimit(FourCC("o059"), Faction.UNLIMITED)   ;//Improved Ancient Protector

      f.ModObjectLimit(FourCC("o05A"), Faction.UNLIMITED)   ;//Wisp
      f.ModObjectLimit(FourCC("o05B"), Faction.UNLIMITED)   ;//Defender
      f.ModObjectLimit(FourCC("h09T"), Faction.UNLIMITED)   ;//Rangari
      f.ModObjectLimit(FourCC("e01K"), 3)           ;//Polybolos
      f.ModObjectLimit(FourCC("o05D"), Faction.UNLIMITED)   ;//Elementalist
      f.ModObjectLimit(FourCC("o05C"), Faction.UNLIMITED)   ;//Luminarch
      f.ModObjectLimit(FourCC("h09R"), 6)           ;//Vindicator
      f.ModObjectLimit(FourCC("nmdr"), Faction.UNLIMITED)   ;//Elekk
      f.ModObjectLimit(FourCC("h09U"), 4)           ;//Elekk Knight
      f.ModObjectLimit(FourCC("u02H"), 6)           ;//Nether Ray

      f.ModObjectLimit(FourCC("etrs"), 12)   	    ;//Night Elf Transport Ship
      f.ModObjectLimit(FourCC("edes"), 12) 	      ;//Night Elf Frigate
      f.ModObjectLimit(FourCC("ebsh"), 6)          ;//Night Elf Battleship

      f.ModObjectLimit(FourCC("H09S"), 1)           ;//Maraad
      f.ModObjectLimit(FourCC("E01I"), 1)           ;//Velen
      f.ModObjectLimit(FourCC("E01J"), 1)           ;//Nobundo

      f.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED)   ;//Spiritual Infusion
      f.ModObjectLimit(FourCC("R078"), Faction.UNLIMITED)   ;//Elementalist training
      f.ModObjectLimit(FourCC("R07C"), Faction.UNLIMITED)   ;//Luminarch training

    }

  }
}
