using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  /// <summary>
  /// Responsible for setting up and containing the Dragonmaw faction.
  /// </summary>
  public static class DragonmawSetup
  {
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

      Dragonmaw.ModObjectLimit('o039', UNLIMITED); //Great Hall
      Dragonmaw.ModObjectLimit('o03A', UNLIMITED); //Stronghold
      Dragonmaw.ModObjectLimit('o03B', UNLIMITED); //Fortress
      Dragonmaw.ModObjectLimit('o03C', UNLIMITED); //Altar of Storms
      Dragonmaw.ModObjectLimit('o03D', UNLIMITED); //Barracks
      Dragonmaw.ModObjectLimit('o03J', UNLIMITED); //War Mill
      Dragonmaw.ModObjectLimit('o03E', UNLIMITED); //Spirit Lodge
      Dragonmaw.ModObjectLimit('o05J', UNLIMITED); //Bestiary
      Dragonmaw.ModObjectLimit('o03I', UNLIMITED); //Shipyard
      Dragonmaw.ModObjectLimit('o03G', UNLIMITED); //Watch Tower
      Dragonmaw.ModObjectLimit('o03H', UNLIMITED); //Improved Watch Tower
      Dragonmaw.ModObjectLimit('u00Y', UNLIMITED); //Shop
      Dragonmaw.ModObjectLimit('o03K', UNLIMITED); //Burrow

      Dragonmaw.ModObjectLimit('n0CP', 2); //Black Drake
      Dragonmaw.ModObjectLimit('o05M', 8); //WindRider
      Dragonmaw.ModObjectLimit('n07X', UNLIMITED); //Fel Orc Warlock
      Dragonmaw.ModObjectLimit('o05K', UNLIMITED); //Fel Orc Grunt
      Dragonmaw.ModObjectLimit('o05P', UNLIMITED); //Fel Orc Peon
      Dragonmaw.ModObjectLimit('n0CQ', UNLIMITED); //Fel Orc Peon
      Dragonmaw.ModObjectLimit('o04I', 6); //Executioner
      Dragonmaw.ModObjectLimit('o04K', 6); //Demolisher
      Dragonmaw.ModObjectLimit('n09O', 6); //DK
      Dragonmaw.ModObjectLimit('u01T', UNLIMITED); //Necrolyte
      Dragonmaw.ModObjectLimit('o05L', UNLIMITED); //Phase Grenadier
      Dragonmaw.ModObjectLimit('obot', 12); //Transport Ship
      Dragonmaw.ModObjectLimit('odes', 12); //Orc Frigate
      Dragonmaw.ModObjectLimit('ojgn', 6); //Juggernaught

      Dragonmaw.ModObjectLimit('O01Q', 1); //Nekrosh
      Dragonmaw.ModObjectLimit('O00Y', 1); //Zuluhead
      
      Dragonmaw.ModObjectLimit('R023', UNLIMITED); //Spiritual Infusion
      Dragonmaw.ModObjectLimit('Rosp', UNLIMITED); //Spiked Barricades
      Dragonmaw.ModObjectLimit('R06X', UNLIMITED); //Magic Training
      Dragonmaw.ModObjectLimit('R06Z', UNLIMITED); //Herald Training
    }
  }
}