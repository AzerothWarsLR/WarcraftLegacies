using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class IllidanSetup
  {
    public static Faction? Illidan { get; private set; }
    
    public static void Setup()
    {
      Illidan = new Faction("Illidan's Forces", PLAYER_COLOR_VIOLET, "|cffff00ff",
        "ReplaceableTextures\\CommandButtons\\BTNEvilIllidan.blp")
      {
        UndefeatedResearch = FourCC("R02L"),
        StartingGold = 0,
        StartingLumber = 2500,
        CinematicMusic = @"war3mapImported\Illidancinematic3.mp3",
        IntroText = @"You are playing as the banished Empire of Nazjatar|r|r.

You start weak in the middle of the map.

Take control of the deap sea before moving on to raiding coastal settlements and islands all around you, slowly gaining ressources along the way.

Once you have collected enough, you can rebuild the great Nazjatar empire and start conquering the world."
      };

      Illidan.ModObjectLimit(FourCC("e01P"), Faction.UNLIMITED); //Coral of Life
      Illidan.ModObjectLimit(FourCC("e01Q"), Faction.UNLIMITED); //Coral of Ages
      Illidan.ModObjectLimit(FourCC("e01R"), Faction.UNLIMITED); //Coral of Eternity
      Illidan.ModObjectLimit(FourCC("e01S"), Faction.UNLIMITED); //Altar of the Depths
      Illidan.ModObjectLimit(FourCC("e01T"), Faction.UNLIMITED); //Coral Of War
      Illidan.ModObjectLimit(FourCC("e01U"), Faction.UNLIMITED); //Coral of Lore
      Illidan.ModObjectLimit(FourCC("e01V"), Faction.UNLIMITED); //Coral of Wind
      Illidan.ModObjectLimit(FourCC("h0AD"), Faction.UNLIMITED); //Coral Forge
      Illidan.ModObjectLimit(FourCC("n0CU"), Faction.UNLIMITED); //Deep Sea Vault
      Illidan.ModObjectLimit(FourCC("n09I"), Faction.UNLIMITED); //Coral Beds
      Illidan.ModObjectLimit(FourCC("n0D4"), Faction.UNLIMITED); //Improved Tidal Guardian
      Illidan.ModObjectLimit(FourCC("n0D5"), Faction.UNLIMITED); //Tidal Guardian

      Illidan.ModObjectLimit(FourCC("nmpe"), Faction.UNLIMITED); //Mur)gul Slave
      Illidan.ModObjectLimit(FourCC("nmyr"), Faction.UNLIMITED); //Myrmidon
      Illidan.ModObjectLimit(FourCC("nsnp"), Faction.UNLIMITED); //Snap Dragon
      Illidan.ModObjectLimit(FourCC("nnsw"), Faction.UNLIMITED); //Siren
      Illidan.ModObjectLimit(FourCC("nmsc"), Faction.UNLIMITED); //Shadowcaster
      Illidan.ModObjectLimit(FourCC("nnsu"), 6); //Summoner
      Illidan.ModObjectLimit(FourCC("nnrg"), 6); //Royal Guard
      Illidan.ModObjectLimit(FourCC("nhyc"), 8); //Dragon Turtle
      Illidan.ModObjectLimit(FourCC("nwgs"), 8); //Couatl
      Illidan.ModObjectLimit(FourCC("e00Y"), 4); //Scylla

      Illidan.ModObjectLimit(FourCC("Hvsh"), 1); //Vashj
      Illidan.ModObjectLimit(FourCC("U00S"), 1); //Najentus
      Illidan.ModObjectLimit(FourCC("Naka"), 1); //Akama
      Illidan.ModObjectLimit(FourCC("E015"), 1); //Akama
      Illidan.ModObjectLimit(FourCC("Eevi"), 1); //Illidan

      Illidan.ModObjectLimit(FourCC("R062"), Faction.UNLIMITED); //Redemption path
      Illidan.ModObjectLimit(FourCC("R063"), Faction.UNLIMITED); //Exile Path
      Illidan.ModObjectLimit(FourCC("R065"), Faction.UNLIMITED); //Madness Path

      FactionManager.Register(Illidan);
    }
  }
}