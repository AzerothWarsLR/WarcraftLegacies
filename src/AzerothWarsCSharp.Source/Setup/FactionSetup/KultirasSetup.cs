using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class KultirasSetup
  {
    public static Faction FACTION_KULTIRAS { get; private set; }

    public static void Setup()
    {
      FACTION_KULTIRAS =
        new Faction(
          "Kul'tiras", PLAYER_COLOR_EMERALD, " | cff00781e", "ReplaceableTextures\\CommandButtons\\BTNProudmoore.blp")
          {
            StartingGold = 150,
            StartingLumber = 500,
            IntroText = @"You are playing as the hardy island |cff008000Kingdom of Kul'tiras|r.

You start in the Balor islands, but you must move quickly to gain control your capital and the Gold Mines on Kul'tiras island. 

The Zandalari Trolls mounting an attack from the South so be ready, the fight will be bloody.

Once you have conquered the Zandalari Empire, set sail to help your allies."
          };

      //Structures
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h062"), Faction.UNLIMITED); //Town Hall
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h064"), Faction.UNLIMITED); //Keep
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h06I"), Faction.UNLIMITED); //Castle
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h07N"), Faction.UNLIMITED); //Farm
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h07M"), Faction.UNLIMITED); //Altar
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h07R"), Faction.UNLIMITED); //Scout Tower
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h07S"), Faction.UNLIMITED); //Guard Tower
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h07T"), Faction.UNLIMITED); //Improved Guard Tower
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h04U"), Faction.UNLIMITED); //Cannon Tower
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h07V"), Faction.UNLIMITED); //Improved Cannon Tower
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h07O"), Faction.UNLIMITED); //Blacksmith
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h07Q"), Faction.UNLIMITED); //Arcane Sanctum
      FACTION_KULTIRAS.ModObjectLimit(FourCC("n07H"), Faction.UNLIMITED); //Marketplace
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h07W"), Faction.UNLIMITED); //Shipyard
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h06R"), Faction.UNLIMITED); //Garrison
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h07P"), Faction.UNLIMITED); //Workshop
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h093"), Faction.UNLIMITED); //Workshop

      //Units
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h01E"), Faction.UNLIMITED); //Deckhand
      FACTION_KULTIRAS.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      FACTION_KULTIRAS.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h04J"), 5); //Warship
      FACTION_KULTIRAS.ModObjectLimit(FourCC("e007"), Faction.UNLIMITED); //Thornspeaker
      FACTION_KULTIRAS.ModObjectLimit(FourCC("n09A"), 12); //Ember Cleric
      FACTION_KULTIRAS.ModObjectLimit(FourCC("n09B"), 8); //Witch Hunter
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h092"), 4); //Order Inquisitor
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h05K"), Faction.UNLIMITED); //Tidesage
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h041"), Faction.UNLIMITED); //Marine
      FACTION_KULTIRAS.ModObjectLimit(FourCC("e00B"), Faction.UNLIMITED); //Thornspeaker Bear
      FACTION_KULTIRAS.ModObjectLimit(FourCC("n009"), 12); //Revenant of the Tides
      FACTION_KULTIRAS.ModObjectLimit(FourCC("n07G"), 6); //muskateer
      FACTION_KULTIRAS.ModObjectLimit(FourCC("n029"), 12); //Sea Giant
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h06J"), Faction.UNLIMITED); //Sniper
      FACTION_KULTIRAS.ModObjectLimit(FourCC("o01A"), 6); //Cannon Team
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h04O"), 12); //Bomber
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h04W"), 3); //Siege Tank
      FACTION_KULTIRAS.ModObjectLimit(FourCC("h0A0"), 8); //Fusillier

      //Upgrades
      FACTION_KULTIRAS.ModObjectLimit(FourCC("R001"), Faction.UNLIMITED); //Rising Tides
      FACTION_KULTIRAS.ModObjectLimit(FourCC("R000"), Faction.UNLIMITED); //Tidesage Adept Training
      FACTION_KULTIRAS.ModObjectLimit(FourCC("R01O"), Faction.UNLIMITED); //Crushing Wave
      FACTION_KULTIRAS.ModObjectLimit(FourCC("R01T"), Faction.UNLIMITED); //Cluster Rockets
      FACTION_KULTIRAS.ModObjectLimit(FourCC("R01U"), Faction.UNLIMITED); //Improved Barrage
      FACTION_KULTIRAS.ModObjectLimit(FourCC("R05G"), Faction.UNLIMITED); //Thornspeaker Training
      FACTION_KULTIRAS.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      FACTION_KULTIRAS.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      FACTION_KULTIRAS.ModObjectLimit(FourCC("R08B"), Faction.UNLIMITED); //Long Rifles

      //Heroes
      FACTION_KULTIRAS.ModObjectLimit(FourCC("Hapm"), 1); //Admiral
      FACTION_KULTIRAS.ModObjectLimit(FourCC("H05L"), 1); //Lady Ashvane
      FACTION_KULTIRAS.ModObjectLimit(FourCC("E016"), 1); //Lucille

      FactionManager.Register(FACTION_KULTIRAS);
    }
  }
}