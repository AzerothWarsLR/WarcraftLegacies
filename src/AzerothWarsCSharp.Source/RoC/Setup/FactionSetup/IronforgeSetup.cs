using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup.FactionSetup
{
  public class IronforgeSetup{

  
    Faction FACTION_IRONFORGE
  

    public static void Setup( ){
      Faction f;

      FACTION_IRONFORGE = Faction.create("Ironforge", PLAYER_COLOR_YELLOW, "|C00FFFC01","ReplaceableTextures\\CommandButtons\\BTNHeroMountainKing.blp");
      f = FACTION_IRONFORGE;
      f.Team = TEAM_ALLIANCE;
      f.UndefeatedResearch = FourCC(R05T);
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC(h07E), UNLIMITED)   ;//Town Hall
      f.ModObjectLimit(FourCC(h07F), UNLIMITED)   ;//Keep
      f.ModObjectLimit(FourCC(h07G), UNLIMITED)   ;//Castle
      f.ModObjectLimit(FourCC(h02P), UNLIMITED)   ;//Farm  (Dwarven)
      f.ModObjectLimit(FourCC(h01S), UNLIMITED)   ;//Tavern
      f.ModObjectLimit(FourCC(h07B), UNLIMITED)   ;//Altar of Kings
      f.ModObjectLimit(FourCC(h07C), UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC(hlum), UNLIMITED)   ;//Lumber Mill
      f.ModObjectLimit(FourCC(h048), UNLIMITED)   ;//Blacksmith (Dwarven)
      f.ModObjectLimit(FourCC(h042), UNLIMITED)   ;//Machine Factory
      f.ModObjectLimit(FourCC(harm), UNLIMITED)   ;//Workshop
      f.ModObjectLimit(FourCC(hgra), UNLIMITED)   ;//Gryphon Aviary
      f.ModObjectLimit(FourCC(h07H), UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC(h07J), UNLIMITED)   ;//Cannon Tower
      f.ModObjectLimit(FourCC(h07K), UNLIMITED)   ;//Cannon Tower (Improved)
      f.ModObjectLimit(FourCC(h07D), UNLIMITED)   ;//Alliance Shipyard
      f.ModObjectLimit(FourCC(n07U), UNLIMITED)   ;//Marketplace
      f.ModObjectLimit(FourCC(h00B), 4)           ;//Dwarven Keep Tower
      f.ModObjectLimit(FourCC(h07I), UNLIMITED)   ;//Guard Tower
      f.ModObjectLimit(FourCC(h07L), UNLIMITED)   ;//Guard Tower (Improved)

      //Units
      f.ModObjectLimit(FourCC(h019), UNLIMITED)   ;//Dwarven Worker
      f.ModObjectLimit(FourCC(hbot), 12)   	    ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC(hdes), 12) 	    ;//Alliance Frigate
      f.ModObjectLimit(FourCC(hbsh), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC(hrif), UNLIMITED)   ;//Rifleman
      f.ModObjectLimit(FourCC(hmtm), 9)           ;//Mortar Team
      f.ModObjectLimit(FourCC(hgyr), 12)          ;//Flying Machine
      f.ModObjectLimit(FourCC(hgry), 6)           ;//Gryphon Rider
      f.ModObjectLimit(FourCC(h018), UNLIMITED)   ;//Dwarven Warrior
      f.ModObjectLimit(FourCC(h01L), 6)           ;//Thane
      f.ModObjectLimit(FourCC(h037), UNLIMITED)   ;//Engineer
      f.ModObjectLimit(FourCC(n02D), UNLIMITED)   ;//War Golem
      f.ModObjectLimit(FourCC(h01P), 3)           ;//Steam Tank
      f.ModObjectLimit(FourCC(n00C), UNLIMITED)   ;//Rune Priest

      f.ModObjectLimit(FourCC(h01M), 1)           ;//Baelgun
      f.ModObjectLimit(FourCC(H00S), 1)           ;//Magni
      f.ModObjectLimit(FourCC(Hmbr), 1)           ;//Muradin

      //Upgrades
      f.ModObjectLimit(FourCC(R03H), UNLIMITED)   ;//Engineering Adept Training
      f.ModObjectLimit(FourCC(R00K), UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC(R00F), UNLIMITED)   ;//Mithril Armor
      f.ModObjectLimit(FourCC(Rhfl), UNLIMITED)   ;//Flare
      f.ModObjectLimit(FourCC(Rhfs), UNLIMITED)   ;//Dragmentation Shards
      f.ModObjectLimit(FourCC(Rhlh), UNLIMITED)   ;//Improved Lumber Harvesting
      f.ModObjectLimit(FourCC(Rhac), UNLIMITED)   ;//Improved Masonry
      f.ModObjectLimit(FourCC(Rhri), UNLIMITED)   ;//Long Rifles
      f.ModObjectLimit(FourCC(Rhhb), UNLIMITED)   ;//Storm Hammers
      f.ModObjectLimit(FourCC(R063), UNLIMITED)   ;//Thunder Ale
      f.ModObjectLimit(FourCC(Rhme), UNLIMITED)   ;//Copper Forged Weaponry
      f.ModObjectLimit(FourCC(Rhar), UNLIMITED)   ;//Copper Armor Plating
      f.ModObjectLimit(FourCC(R014), UNLIMITED)   ;//Deeprun Tram
      f.ModObjectLimit(FourCC(R00V), UNLIMITED)   ;//Rune Priest Adept Training
      f.ModObjectLimit(FourCC(R00Z), UNLIMITED)   ;//Armor Penetration Rounds
      f.ModObjectLimit(FourCC(R010), UNLIMITED)   ;//Improved Spell Resistance
      f.ModObjectLimit(FourCC(R00T), UNLIMITED)   ;//Overclock
      f.ModObjectLimit(FourCC(R00N), UNLIMITED)   ;//Improved Swig
      f.ModObjectLimit(FourCC(R08K), UNLIMITED)   ;//Titanforge Artifact
    }

  }
}
