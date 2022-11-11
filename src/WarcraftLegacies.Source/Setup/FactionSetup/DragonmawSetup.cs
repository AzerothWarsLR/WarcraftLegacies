using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  /// <summary>
  /// Responsible for setting up and containing the Dragonmaw faction.
  /// </summary>
  public static class DragonmawSetup
  {
    /// <summary>
    /// Orc clan obsessed with dragons.
    /// </summary>
    public static Faction? Dragonmaw { get; private set; }

    /// <summary>
    /// up the Dragonmaw faction.
    /// </summary>
    public static void Setup()
    {
      Dragonmaw = new Faction("Dragonmaw", PLAYER_COLOR_YELLOW, "|C00FFFC01",
        "ReplaceableTextures\\CommandButtons\\BTNNecroMagus.blp")
      {
        StartingGold = 150,
        StartingLumber = 350
      };

      Dragonmaw.ModObjectLimit(FourCC("o039"), Faction.UNLIMITED); //Great Hall
      Dragonmaw.ModObjectLimit(FourCC("o03A"), Faction.UNLIMITED); //Stronghold
      Dragonmaw.ModObjectLimit(FourCC("o03B"), Faction.UNLIMITED); //Fortress
      Dragonmaw.ModObjectLimit(FourCC("o03C"), Faction.UNLIMITED); //Altar of Storms
      Dragonmaw.ModObjectLimit(FourCC("o03D"), Faction.UNLIMITED); //Barracks
      Dragonmaw.ModObjectLimit(FourCC("o03J"), Faction.UNLIMITED); //War Mill
      Dragonmaw.ModObjectLimit(FourCC("o03E"), Faction.UNLIMITED); //Spirit Lodge
      Dragonmaw.ModObjectLimit(FourCC("o05J"), Faction.UNLIMITED); //Bestiary
      Dragonmaw.ModObjectLimit(FourCC("o03I"), Faction.UNLIMITED); //Shipyard
      Dragonmaw.ModObjectLimit(FourCC("o03G"), Faction.UNLIMITED); //Watch Tower
      Dragonmaw.ModObjectLimit(FourCC("o03H"), Faction.UNLIMITED); //Improved Watch Tower
      Dragonmaw.ModObjectLimit(FourCC("u00Y"), Faction.UNLIMITED); //Shop
      Dragonmaw.ModObjectLimit(FourCC("o03K"), Faction.UNLIMITED); //Burrow

      Dragonmaw.ModObjectLimit(FourCC("n0CP"), 2); //Black Drake
      Dragonmaw.ModObjectLimit(FourCC("o05M"), 8); //WindRider
      Dragonmaw.ModObjectLimit(FourCC("n07X"), Faction.UNLIMITED); //Fel Orc Warlock
      Dragonmaw.ModObjectLimit(FourCC("o05K"), Faction.UNLIMITED); //Fel Orc Grunt
      Dragonmaw.ModObjectLimit(FourCC("o05P"), Faction.UNLIMITED); //Fel Orc Peon
      Dragonmaw.ModObjectLimit(FourCC("n0CQ"), Faction.UNLIMITED); //Fel Orc Peon
      Dragonmaw.ModObjectLimit(FourCC("o04I"), 6); //Executioner
      Dragonmaw.ModObjectLimit(FourCC("o04K"), 6); //Demolisher
      Dragonmaw.ModObjectLimit(FourCC("n09O"), 6); //DK
      Dragonmaw.ModObjectLimit(FourCC("u01T"), Faction.UNLIMITED); //Necrolyte
      Dragonmaw.ModObjectLimit(FourCC("o05L"), Faction.UNLIMITED); //Phase Grenadier
      Dragonmaw.ModObjectLimit(FourCC("obot"), 12); //Transport Ship
      Dragonmaw.ModObjectLimit(FourCC("odes"), 12); //Orc Frigate
      Dragonmaw.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught

      Dragonmaw.ModObjectLimit(FourCC("O01Q"), 1); //Nekrosh
      Dragonmaw.ModObjectLimit(FourCC("O00Y"), 1); //Zuluhead

      Dragonmaw.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED); //Spiritual Infusion
      Dragonmaw.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      Dragonmaw.ModObjectLimit(FourCC("R06X"), Faction.UNLIMITED); //Magic Training
      Dragonmaw.ModObjectLimit(FourCC("R06Z"), Faction.UNLIMITED); //Herald Training
    }
  }
}