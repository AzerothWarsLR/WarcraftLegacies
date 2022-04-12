using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class IronforgeSetup{
    public static Faction FACTION_IRONFORGE { get; private set; }
  

    public static void Setup( ){
      Faction f;

      FACTION_IRONFORGE = new Faction("Ironforge", PLAYER_COLOR_YELLOW, "|C00FFFC01","ReplaceableTextures\\CommandButtons\\BTNHeroMountainKing.blp");
      f = FACTION_IRONFORGE;
      f.Team = TeamSetup.TeamAlliance;
      f.UndefeatedResearch = FourCC("R05T");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC("h07E"), Faction.UNLIMITED)   ;//Town Hall
      f.ModObjectLimit(FourCC("h07F"), Faction.UNLIMITED)   ;//Keep
      f.ModObjectLimit(FourCC("h07G"), Faction.UNLIMITED)   ;//Castle
      f.ModObjectLimit(FourCC("h02P"), Faction.UNLIMITED)   ;//Farm  (Dwarven)
      f.ModObjectLimit(FourCC("h01S"), Faction.UNLIMITED)   ;//Tavern
      f.ModObjectLimit(FourCC("h07B"), Faction.UNLIMITED)   ;//Altar of Kings
      f.ModObjectLimit(FourCC("h07C"), Faction.UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC("hlum"), Faction.UNLIMITED)   ;//Lumber Mill
      f.ModObjectLimit(FourCC("h048"), Faction.UNLIMITED)   ;//Blacksmith (Dwarven)
      f.ModObjectLimit(FourCC("h042"), Faction.UNLIMITED)   ;//Machine Factory
      f.ModObjectLimit(FourCC("harm"), Faction.UNLIMITED)   ;//Workshop
      f.ModObjectLimit(FourCC("hgra"), Faction.UNLIMITED)   ;//Gryphon Aviary
      f.ModObjectLimit(FourCC("h07H"), Faction.UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC("h07J"), Faction.UNLIMITED)   ;//Cannon Tower
      f.ModObjectLimit(FourCC("h07K"), Faction.UNLIMITED)   ;//Cannon Tower (Improved)
      f.ModObjectLimit(FourCC("h07D"), Faction.UNLIMITED)   ;//Alliance Shipyard
      f.ModObjectLimit(FourCC("n07U"), Faction.UNLIMITED)   ;//Marketplace
      f.ModObjectLimit(FourCC("h00B"), 4)           ;//Dwarven Keep Tower
      f.ModObjectLimit(FourCC("h07I"), Faction.UNLIMITED)   ;//Guard Tower
      f.ModObjectLimit(FourCC("h07L"), Faction.UNLIMITED)   ;//Guard Tower (Improved)

      //Units
      f.ModObjectLimit(FourCC("h019"), Faction.UNLIMITED)   ;//Dwarven Worker
      f.ModObjectLimit(FourCC("hbot"), 12)   	    ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC("hdes"), 12) 	    ;//Alliance Frigate
      f.ModObjectLimit(FourCC("hbsh"), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC("hrif"), Faction.UNLIMITED)   ;//Rifleman
      f.ModObjectLimit(FourCC("hmtm"), 9)           ;//Mortar Team
      f.ModObjectLimit(FourCC("hgyr"), 12)          ;//Flying Machine
      f.ModObjectLimit(FourCC("hgry"), 6)           ;//Gryphon Rider
      f.ModObjectLimit(FourCC("h018"), Faction.UNLIMITED)   ;//Dwarven Warrior
      f.ModObjectLimit(FourCC("h01L"), 6)           ;//Thane
      f.ModObjectLimit(FourCC("h037"), Faction.UNLIMITED)   ;//Engineer
      f.ModObjectLimit(FourCC("n02D"), Faction.UNLIMITED)   ;//War Golem
      f.ModObjectLimit(FourCC("h01P"), 3)           ;//Steam Tank
      f.ModObjectLimit(FourCC("n00C"), Faction.UNLIMITED)   ;//Rune Priest

      f.ModObjectLimit(FourCC("h01M"), 1)           ;//Baelgun
      f.ModObjectLimit(FourCC("H00S"), 1)           ;//Magni
      f.ModObjectLimit(FourCC("Hmbr"), 1)           ;//Muradin

      //Upgrades
      f.ModObjectLimit(FourCC("R03H"), Faction.UNLIMITED)   ;//Engineering Adept Training
      f.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC("R00F"), Faction.UNLIMITED)   ;//Mithril Armor
      f.ModObjectLimit(FourCC("Rhfl"), Faction.UNLIMITED)   ;//Flare
      f.ModObjectLimit(FourCC("Rhfs"), Faction.UNLIMITED)   ;//Dragmentation Shards
      f.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED)   ;//Improved Lumber Harvesting
      f.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED)   ;//Improved Masonry
      f.ModObjectLimit(FourCC("Rhri"), Faction.UNLIMITED)   ;//Long Rifles
      f.ModObjectLimit(FourCC("Rhhb"), Faction.UNLIMITED)   ;//Storm Hammers
      f.ModObjectLimit(FourCC("R063"), Faction.UNLIMITED)   ;//Thunder Ale
      f.ModObjectLimit(FourCC("Rhme"), Faction.UNLIMITED)   ;//Copper Forged Weaponry
      f.ModObjectLimit(FourCC("Rhar"), Faction.UNLIMITED)   ;//Copper Armor Plating
      f.ModObjectLimit(FourCC("R014"), Faction.UNLIMITED)   ;//Deeprun Tram
      f.ModObjectLimit(FourCC("R00V"), Faction.UNLIMITED)   ;//Rune Priest Adept Training
      f.ModObjectLimit(FourCC("R00Z"), Faction.UNLIMITED)   ;//Armor Penetration Rounds
      f.ModObjectLimit(FourCC("R010"), Faction.UNLIMITED)   ;//Improved Spell Resistance
      f.ModObjectLimit(FourCC("R00T"), Faction.UNLIMITED)   ;//Overclock
      f.ModObjectLimit(FourCC("R00N"), Faction.UNLIMITED)   ;//Improved Swig
      f.ModObjectLimit(FourCC("R08K"), Faction.UNLIMITED)   ;//Titanforge Artifact
    }

  }
}
