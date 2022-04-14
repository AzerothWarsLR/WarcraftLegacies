using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class KultirasSetup
  {
    public static Faction FACTION_KULTIRAS { get; private set; }

    public static void Setup()
    {
      Faction f;

      FACTION_KULTIRAS =
        new Faction(
          "Kul'tiras", PLAYER_COLOR_EMERALD, " | cff00781e", "ReplaceableTextures\\CommandButtons\\BTNProudmoore.blp");
      f = FACTION_KULTIRAS;
      f.Team = TeamSetup.TeamAlliance;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC("h062"), Faction.UNLIMITED); //Town Hall
      f.ModObjectLimit(FourCC("h064"), Faction.UNLIMITED); //Keep
      f.ModObjectLimit(FourCC("h06I"), Faction.UNLIMITED); //Castle
      f.ModObjectLimit(FourCC("h07N"), Faction.UNLIMITED); //Farm
      f.ModObjectLimit(FourCC("h07M"), Faction.UNLIMITED); //Altar
      f.ModObjectLimit(FourCC("h07R"), Faction.UNLIMITED); //Scout Tower
      f.ModObjectLimit(FourCC("h07S"), Faction.UNLIMITED); //Guard Tower
      f.ModObjectLimit(FourCC("h07T"), Faction.UNLIMITED); //Improved Guard Tower
      f.ModObjectLimit(FourCC("h04U"), Faction.UNLIMITED); //Cannon Tower
      f.ModObjectLimit(FourCC("h07V"), Faction.UNLIMITED); //Improved Cannon Tower
      f.ModObjectLimit(FourCC("h07O"), Faction.UNLIMITED); //Blacksmith
      f.ModObjectLimit(FourCC("h07Q"), Faction.UNLIMITED); //Arcane Sanctum
      f.ModObjectLimit(FourCC("n07H"), Faction.UNLIMITED); //Marketplace
      f.ModObjectLimit(FourCC("h07W"), Faction.UNLIMITED); //Shipyard
      f.ModObjectLimit(FourCC("h06R"), Faction.UNLIMITED); //Garrison
      f.ModObjectLimit(FourCC("h07P"), Faction.UNLIMITED); //Workshop
      f.ModObjectLimit(FourCC("h093"), Faction.UNLIMITED); //Workshop

      //Units
      f.ModObjectLimit(FourCC("h01E"), Faction.UNLIMITED); //Deckhand
      f.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      f.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      f.ModObjectLimit(FourCC("h04J"), 5); //Warship
      f.ModObjectLimit(FourCC("e007"), Faction.UNLIMITED); //Thornspeaker
      f.ModObjectLimit(FourCC("n09A"), 12); //Ember Cleric
      f.ModObjectLimit(FourCC("n09B"), 8); //Witch Hunter
      f.ModObjectLimit(FourCC("h092"), 4); //Order Inquisitor
      f.ModObjectLimit(FourCC("h05K"), Faction.UNLIMITED); //Tidesage
      f.ModObjectLimit(FourCC("h041"), Faction.UNLIMITED); //Marine
      f.ModObjectLimit(FourCC("e00B"), Faction.UNLIMITED); //Thornspeaker Bear
      f.ModObjectLimit(FourCC("n009"), 12); //Revenant of the Tides
      f.ModObjectLimit(FourCC("n07G"), 6); //muskateer
      f.ModObjectLimit(FourCC("n029"), 12); //Sea Giant
      f.ModObjectLimit(FourCC("h06J"), Faction.UNLIMITED); //Sniper
      f.ModObjectLimit(FourCC("o01A"), 6); //Cannon Team
      f.ModObjectLimit(FourCC("h04O"), 12); //Bomber
      f.ModObjectLimit(FourCC("h04W"), 3); //Siege Tank
      f.ModObjectLimit(FourCC("h0A0"), 8); //Fusillier

      //Upgrades
      f.ModObjectLimit(FourCC("R001"), Faction.UNLIMITED); //Rising Tides
      f.ModObjectLimit(FourCC("R000"), Faction.UNLIMITED); //Tidesage Adept Training
      f.ModObjectLimit(FourCC("R01O"), Faction.UNLIMITED); //Crushing Wave
      f.ModObjectLimit(FourCC("R01T"), Faction.UNLIMITED); //Cluster Rockets
      f.ModObjectLimit(FourCC("R01U"), Faction.UNLIMITED); //Improved Barrage
      f.ModObjectLimit(FourCC("R05G"), Faction.UNLIMITED); //Thornspeaker Training
      f.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      f.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      f.ModObjectLimit(FourCC("R08B"), Faction.UNLIMITED); //Long Rifles

      //Heroes
      f.ModObjectLimit(FourCC("Hapm"), 1); //Admiral
      f.ModObjectLimit(FourCC("H05L"), 1); //Lady Ashvane
      f.ModObjectLimit(FourCC("E016"), 1); //Lucille

      FactionManager.Register(FACTION_KULTIRAS);
    }
  }
}