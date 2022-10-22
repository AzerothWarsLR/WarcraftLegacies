using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class IllidariSetup
  {
    public static Faction? Illidari { get; private set; }
    
    public static void Setup()
    {
      Illidari = new Faction("Illidan", PLAYER_COLOR_VIOLET, "|cffff00ff",
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

      Illidari.ModObjectLimit(FourCC("nntt"), Faction.UNLIMITED); //Pillar of Waves
      Illidari.ModObjectLimit(FourCC("n04T"), Faction.UNLIMITED); //Monument of Currents
      Illidari.ModObjectLimit(FourCC("n055"), Faction.UNLIMITED); //Temple of Tides
      Illidari.ModObjectLimit(FourCC("nnad"), Faction.UNLIMITED); //Altar of the Depths
      Illidari.ModObjectLimit(FourCC("nnsg"), Faction.UNLIMITED); //Spawning Grounds
      Illidari.ModObjectLimit(FourCC("h06S"), Faction.UNLIMITED); //Coral Forge
      Illidari.ModObjectLimit(FourCC("n0A3"), Faction.UNLIMITED); //Royal Pyramid
      Illidari.ModObjectLimit(FourCC("nnsa"), Faction.UNLIMITED); //Temple of Azshara
      Illidari.ModObjectLimit(FourCC("nnfm"), Faction.UNLIMITED); //Coral Beds
      Illidari.ModObjectLimit(FourCC("nntg"), Faction.UNLIMITED); //Tidal Guardian
      Illidari.ModObjectLimit(FourCC("n005"), Faction.UNLIMITED); //Improved Tidal Guardian
      Illidari.ModObjectLimit(FourCC("nmrb"), Faction.UNLIMITED); //Deep Sea Vault

      Illidari.ModObjectLimit(FourCC("nmpe"), Faction.UNLIMITED); //Mur)gul Slave
      Illidari.ModObjectLimit(FourCC("nmyr"), Faction.UNLIMITED); //Myrmidon
      Illidari.ModObjectLimit(FourCC("nsnp"), Faction.UNLIMITED); //Snap Dragon
      Illidari.ModObjectLimit(FourCC("nnsw"), Faction.UNLIMITED); //Siren
      Illidari.ModObjectLimit(FourCC("nmsc"), Faction.UNLIMITED); //Shadowcaster
      Illidari.ModObjectLimit(FourCC("nnsu"), 6); //Summoner
      Illidari.ModObjectLimit(FourCC("nnrg"), 6); //Royal Guard
      Illidari.ModObjectLimit(FourCC("nhyc"), 8); //Dragon Turtle
      Illidari.ModObjectLimit(FourCC("nwgs"), 8); //Couatl
      Illidari.ModObjectLimit(FourCC("e00Y"), 4); //Scylla

      Illidari.ModObjectLimit(FourCC("Hvsh"), 1); //Vashj
      Illidari.ModObjectLimit(FourCC("U00S"), 1); //Najentus
      Illidari.ModObjectLimit(FourCC("Naka"), 1); //Akama
      Illidari.ModObjectLimit(FourCC("E015"), 1); //Akama
      Illidari.ModObjectLimit(FourCC("Eevi"), 1); //Illidan

      Illidari.ModObjectLimit(FourCC("R062"), Faction.UNLIMITED); //Redemption path
      Illidari.ModObjectLimit(FourCC("R063"), Faction.UNLIMITED); //Exile Path
      Illidari.ModObjectLimit(FourCC("R065"), Faction.UNLIMITED); //Madness Path

      FactionManager.Register(Illidari);
    }
  }
}