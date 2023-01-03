using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
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
        StartingGold = 150,
        StartingLumber = 500,
        ControlPointDefenderUnitTypeId = Constants.UNIT_N0BB_CONTROL_POINT_DEFENDER_ILLIDARI_TOWER,
        IntroText = @"You are playing as the traitor Illidan|r|r.

Your first order of business is to contact your forces in the Broken Isles. This will enable you to open a second front versus Kul'tiras.

Be careful though, your isolated Naga will have a difficult time versus the full strenght of the Kul'tiran, avoid direct confrontation while creeping the Islands

Support the Fel Horde with your main force pushing out of the Dark Portal."
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
      Illidari.ModObjectLimit(FourCC("n08W"), Faction.UNLIMITED); //Deep Sea Vault

      Illidari.ModObjectLimit(FourCC("nmpe"), Faction.UNLIMITED); //Murgul Slave
      Illidari.ModObjectLimit(FourCC("nmyr"), Faction.UNLIMITED); //Myrmidon
      Illidari.ModObjectLimit(FourCC("nsnp"), Faction.UNLIMITED); //Snap Dragon
      Illidari.ModObjectLimit(FourCC("nnsw"), Faction.UNLIMITED); //Siren
      Illidari.ModObjectLimit(FourCC("nmsc"), Faction.UNLIMITED); //Shadowcaster
      Illidari.ModObjectLimit(FourCC("nnsu"), 6); //Summoner
      Illidari.ModObjectLimit(FourCC("nnrg"), 6); //Royal Guard
      Illidari.ModObjectLimit(FourCC("nhyc"), 8); //Dragon Turtle
      Illidari.ModObjectLimit(FourCC("nwgs"), 8); //Couatl
      Illidari.ModObjectLimit(FourCC("e00Y"), 4); //Scylla
      Illidari.ModObjectLimit(FourCC("h0AC"), 6); //Sea Witch
      Illidari.ModObjectLimit(FourCC("ndrn"), Faction.UNLIMITED); //AshtongueMelee
      Illidari.ModObjectLimit(FourCC("ndrs"), 6); //Ashtonguecaster

      Illidari.ModObjectLimit(FourCC("Hvsh"), 1); //Vashj
      Illidari.ModObjectLimit(FourCC("U00S"), 1); //Najentus
      Illidari.ModObjectLimit(FourCC("Naka"), 1); //Akama
      Illidari.ModObjectLimit(FourCC("Eevi"), 1); //Illidan

      Illidari.ModObjectLimit(FourCC("R062"), Faction.UNLIMITED); //Redemption path
      Illidari.ModObjectLimit(FourCC("R063"), Faction.UNLIMITED); //Exile Path
      Illidari.ModObjectLimit(FourCC("R065"), Faction.UNLIMITED); //Madness Path

      Illidari.ModObjectLimit(FourCC("Rnsw"), Faction.UNLIMITED); //Siren Adept Training
      Illidari.ModObjectLimit(FourCC("R02V"), Faction.UNLIMITED); //Shadowcaster Adept Training

      FactionManager.Register(Illidari);
    }
  }
}