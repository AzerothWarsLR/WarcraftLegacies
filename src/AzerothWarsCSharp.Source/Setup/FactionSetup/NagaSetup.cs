using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class NagaSetup
  {
    public static Faction FactionNaga { get; private set; }
    
    public static void Setup()
    {
      FactionNaga = new Faction("Illidan", PLAYER_COLOR_VIOLET, "|cffff00ff",
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

      FactionNaga.ModObjectLimit(FourCC("nntt"), Faction.UNLIMITED); //Pillar of Waves
      FactionNaga.ModObjectLimit(FourCC("n04T"), Faction.UNLIMITED); //Monument of Currents
      FactionNaga.ModObjectLimit(FourCC("n055"), Faction.UNLIMITED); //Temple of Tides
      FactionNaga.ModObjectLimit(FourCC("nnad"), Faction.UNLIMITED); //Altar of the Depths
      FactionNaga.ModObjectLimit(FourCC("nnsg"), Faction.UNLIMITED); //Spawning Grounds
      FactionNaga.ModObjectLimit(FourCC("h06S"), Faction.UNLIMITED); //Coral Forge
      FactionNaga.ModObjectLimit(FourCC("n0A3"), Faction.UNLIMITED); //Royal Pyramid
      FactionNaga.ModObjectLimit(FourCC("nnsa"), Faction.UNLIMITED); //Temple of Azshara
      FactionNaga.ModObjectLimit(FourCC("nnfm"), Faction.UNLIMITED); //Coral Beds
      FactionNaga.ModObjectLimit(FourCC("nntg"), Faction.UNLIMITED); //Tidal Guardian
      FactionNaga.ModObjectLimit(FourCC("n005"), Faction.UNLIMITED); //Improved Tidal Guardian
      FactionNaga.ModObjectLimit(FourCC("nmrb"), Faction.UNLIMITED); //Deep Sea Vault

      FactionNaga.ModObjectLimit(FourCC("nmpe"), Faction.UNLIMITED); //Mur)gul Slave
      FactionNaga.ModObjectLimit(FourCC("nmyr"), Faction.UNLIMITED); //Myrmidon
      FactionNaga.ModObjectLimit(FourCC("nsnp"), Faction.UNLIMITED); //Snap Dragon
      FactionNaga.ModObjectLimit(FourCC("nnsw"), Faction.UNLIMITED); //Siren
      FactionNaga.ModObjectLimit(FourCC("nmsc"), Faction.UNLIMITED); //Shadowcaster
      FactionNaga.ModObjectLimit(FourCC("nnsu"), 6); //Summoner
      FactionNaga.ModObjectLimit(FourCC("nnrg"), 6); //Royal Guard
      FactionNaga.ModObjectLimit(FourCC("nhyc"), 8); //Dragon Turtle
      FactionNaga.ModObjectLimit(FourCC("nwgs"), 8); //Couatl
      FactionNaga.ModObjectLimit(FourCC("e00Y"), 4); //Scylla

      FactionNaga.ModObjectLimit(FourCC("Hvsh"), 1); //Vashj
      FactionNaga.ModObjectLimit(FourCC("U00S"), 1); //Najentus
      FactionNaga.ModObjectLimit(FourCC("Naka"), 1); //Akama
      FactionNaga.ModObjectLimit(FourCC("E015"), 1); //Akama
      FactionNaga.ModObjectLimit(FourCC("Eevi"), 1); //Illidan

      FactionNaga.ModObjectLimit(FourCC("R062"), Faction.UNLIMITED); //Redemption path
      FactionNaga.ModObjectLimit(FourCC("R063"), Faction.UNLIMITED); //Exile Path
      FactionNaga.ModObjectLimit(FourCC("R065"), Faction.UNLIMITED); //Madness Path

      FactionManager.Register(FactionNaga);
    }
  }
}