using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class NagaSetup
  {
    public static Faction FactionNaga { get; private set; }


    public static void Setup()
    {
      Faction f;

      FactionNaga = new Faction("Illidan", PLAYER_COLOR_VIOLET, "|cffff00ff",
        "ReplaceableTextures\\CommandButtons\\BTNEvilIllidan.blp");
      f = FactionNaga;
      f.Team = TeamSetup.Naga;
      f.UndefeatedResearch = FourCC("R02L");
      f.StartingGold = 0;
      f.StartingLumber = 2500;

      f.ModObjectLimit(FourCC("nntt"), Faction.UNLIMITED); //Pillar of Waves
      f.ModObjectLimit(FourCC("n04T"), Faction.UNLIMITED); //Monument of Currents
      f.ModObjectLimit(FourCC("n055"), Faction.UNLIMITED); //Temple of Tides
      f.ModObjectLimit(FourCC("nnad"), Faction.UNLIMITED); //Altar of the Depths
      f.ModObjectLimit(FourCC("nnsg"), Faction.UNLIMITED); //Spawning Grounds
      f.ModObjectLimit(FourCC("h06S"), Faction.UNLIMITED); //Coral Forge
      f.ModObjectLimit(FourCC("n0A3"), Faction.UNLIMITED); //Royal Pyramid
      f.ModObjectLimit(FourCC("nnsa"), Faction.UNLIMITED); //Temple of Azshara
      f.ModObjectLimit(FourCC("nnfm"), Faction.UNLIMITED); //Coral Beds
      f.ModObjectLimit(FourCC("nntg"), Faction.UNLIMITED); //Tidal Guardian
      f.ModObjectLimit(FourCC("n005"), Faction.UNLIMITED); //Improved Tidal Guardian
      f.ModObjectLimit(FourCC("nmrb"), Faction.UNLIMITED); //Deep Sea Vault

      f.ModObjectLimit(FourCC("nmpe"), Faction.UNLIMITED); //Mur)gul Slave
      f.ModObjectLimit(FourCC("nmyr"), Faction.UNLIMITED); //Myrmidon
      f.ModObjectLimit(FourCC("nsnp"), Faction.UNLIMITED); //Snap Dragon
      f.ModObjectLimit(FourCC("nnsw"), Faction.UNLIMITED); //Siren
      f.ModObjectLimit(FourCC("nmsc"), Faction.UNLIMITED); //Shadowcaster
      f.ModObjectLimit(FourCC("nnsu"), 6); //Summoner
      f.ModObjectLimit(FourCC("nnrg"), 6); //Royal Guard
      f.ModObjectLimit(FourCC("nhyc"), 8); //Dragon Turtle
      f.ModObjectLimit(FourCC("nwgs"), 8); //Couatl
      f.ModObjectLimit(FourCC("e00Y"), 4); //Scylla

      f.ModObjectLimit(FourCC("Hvsh"), 1); //Vashj
      f.ModObjectLimit(FourCC("U00S"), 1); //Najentus
      f.ModObjectLimit(FourCC("Naka"), 1); //Akama
      f.ModObjectLimit(FourCC("E015"), 1); //Akama
      f.ModObjectLimit(FourCC("Eevi"), 1); //Illidan

      f.ModObjectLimit(FourCC("R062"), Faction.UNLIMITED); //Redemption path
      f.ModObjectLimit(FourCC("R063"), Faction.UNLIMITED); //Exile Path
      f.ModObjectLimit(FourCC("R065"), Faction.UNLIMITED); //Madness Path

      FactionManager.Register(FactionNaga);
    }
  }
}