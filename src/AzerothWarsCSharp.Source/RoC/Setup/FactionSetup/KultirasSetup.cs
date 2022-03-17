using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup.FactionSetup
{
  public class KultirasSetup{

  
    Faction FACTION_KULTIRAS
  

    public static void OnInit( ){
      Faction f;

      FACTION_KULTIRAS = Faction.create("KulFourCC(tiras", PLAYER_COLOR_EMERALD, "|cff00781e", "ReplaceableTextures\\CommandButtons\\BTNProudmoore.blp");
      f = FACTION_KULTIRAS;
      f.Team = TEAM_ALLIANCE;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC(h062), UNLIMITED)   ;//Town Hall
      f.ModObjectLimit(FourCC(h064), UNLIMITED)   ;//Keep
      f.ModObjectLimit(FourCC(h06I), UNLIMITED)   ;//Castle
      f.ModObjectLimit(FourCC(h07N), UNLIMITED)   ;//Farm
      f.ModObjectLimit(FourCC(h07M), UNLIMITED)   ;//Altar
      f.ModObjectLimit(FourCC(h07R), UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC(h07S), UNLIMITED)   ;//Guard Tower
      f.ModObjectLimit(FourCC(h07T), UNLIMITED)   ;//Improved Guard Tower
      f.ModObjectLimit(FourCC(h04U), UNLIMITED)   ;//Cannon Tower
      f.ModObjectLimit(FourCC(h07V), UNLIMITED)   ;//Improved Cannon Tower
      f.ModObjectLimit(FourCC(h07O), UNLIMITED)   ;//Blacksmith
      f.ModObjectLimit(FourCC(h07Q), UNLIMITED)   ;//Arcane Sanctum
      f.ModObjectLimit(FourCC(n07H), UNLIMITED)   ;//Marketplace
      f.ModObjectLimit(FourCC(h07W), UNLIMITED)   ;//Shipyard
      f.ModObjectLimit(FourCC(h06R), UNLIMITED)   ;//Garrison
      f.ModObjectLimit(FourCC(h07P), UNLIMITED)   ;//Workshop
      f.ModObjectLimit(FourCC(h093), UNLIMITED)   ;//Workshop

      //Units
      f.ModObjectLimit(FourCC(h01E), UNLIMITED)   ;//Deckhand
      f.ModObjectLimit(FourCC(hbot), 12)   ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC(hdes), 12)   ;//Alliance Frigate
      f.ModObjectLimit(FourCC(h04J), 5)           ;//Warship
      f.ModObjectLimit(FourCC(e007), UNLIMITED)   ;//Thornspeaker
      f.ModObjectLimit(FourCC(n09A), 12)   ;//Ember Cleric
      f.ModObjectLimit(FourCC(n09B), 8)          ;//Witch Hunter
      f.ModObjectLimit(FourCC(h092), 4)          ;//Order Inquisitor
      f.ModObjectLimit(FourCC(h05K), UNLIMITED)   ;//Tidesage
      f.ModObjectLimit(FourCC(h041), UNLIMITED)   ;//Marine
      f.ModObjectLimit(FourCC(e00B), UNLIMITED)   ;//Thornspeaker Bear
      f.ModObjectLimit(FourCC(n009), 12)          ;//Revenant of the Tides
      f.ModObjectLimit(FourCC(n07G), 6)           ;//muskateer
      f.ModObjectLimit(FourCC(n029), 12)          ;//Sea Giant
      f.ModObjectLimit(FourCC(h06J), UNLIMITED)   ;//Sniper
      f.ModObjectLimit(FourCC(o01A), 6)           ;//Cannon Team
      f.ModObjectLimit(FourCC(h04O), 12)          ;//Bomber
      f.ModObjectLimit(FourCC(h04W), 3)           ;//Siege Tank
      f.ModObjectLimit(FourCC(h0A0), 8)           ;//Fusillier

      //Upgrades
      f.ModObjectLimit(FourCC(R001), UNLIMITED)   ;//Rising Tides
      f.ModObjectLimit(FourCC(R000), UNLIMITED)   ;//Tidesage Adept Training
      f.ModObjectLimit(FourCC(R01O), UNLIMITED)   ;//Crushing Wave
      f.ModObjectLimit(FourCC(R01T), UNLIMITED)   ;//Cluster Rockets
      f.ModObjectLimit(FourCC(R01U), UNLIMITED)   ;//Improved Barrage
      f.ModObjectLimit(FourCC(R05G), UNLIMITED)   ;//Thornspeaker Training
      f.ModObjectLimit(FourCC(Rhlh), UNLIMITED)   ;//Improved Lumber Harvesting
      f.ModObjectLimit(FourCC(Rhac), UNLIMITED)   ;//Improved Masonry
      f.ModObjectLimit(FourCC(R08B), UNLIMITED)   ;//Long Rifles

      //Heroes
      f.ModObjectLimit(FourCC(Hapm), 1)           ;//Admiral
      f.ModObjectLimit(FourCC(H05L), 1)           ;//Lady Ashvane
      f.ModObjectLimit(FourCC(E016), 1)           ;//Lucille

    }

  }
}
