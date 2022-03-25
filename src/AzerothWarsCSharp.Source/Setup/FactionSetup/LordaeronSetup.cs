using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class LordaeronSetup{
    public static Faction FactionLordaeron { get; private set; }
    
    public static void Setup( ){
      Faction f;
      FactionLordaeron = Faction.create("Lordaeron", PLAYER_COLOR_BLUE, "|c000042ff","ReplaceableTextures\\CommandButtons\\BTNArthas.blp");
      f = FactionLordaeron;
      f.Team = TEAM_ALLIANCE;
      f.UndefeatedResearch = FourCC("R05M");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC("htow"), Faction.UNLIMITED)   ;//Town Hall
      f.ModObjectLimit(FourCC("hkee"), Faction.UNLIMITED)   ;//Keep
      f.ModObjectLimit(FourCC("hcas"), Faction.UNLIMITED)   ;//Castle
      f.ModObjectLimit(FourCC("hhou"), Faction.UNLIMITED)   ;//Farm
      f.ModObjectLimit(FourCC("halt"), Faction.UNLIMITED)   ;//Altar of Kings
      f.ModObjectLimit(FourCC("hbar"), Faction.UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC("hbla"), Faction.UNLIMITED)   ;//Blacksmith
      f.ModObjectLimit(FourCC("h035"), Faction.UNLIMITED)   ;//Chapel
      f.ModObjectLimit(FourCC("hwtw"), Faction.UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC("hgtw"), Faction.UNLIMITED)   ;//Guard Tower
      f.ModObjectLimit(FourCC("h006"), Faction.UNLIMITED)   ;//Guard Tower (Improved)
      f.ModObjectLimit(FourCC("hctw"), Faction.UNLIMITED)   ;//Cannon Tower
      f.ModObjectLimit(FourCC("h007"), Faction.UNLIMITED)   ;//Cannon Tower (Improved)
      f.ModObjectLimit(FourCC("hshy"), Faction.UNLIMITED)   ;//Alliance Shipyard
      f.ModObjectLimit(FourCC("nmrk"), Faction.UNLIMITED)   ;//Marketplace
      f.ModObjectLimit(FourCC("h06C"), Faction.UNLIMITED)   ;//Aviary
      f.ModObjectLimit(FourCC("h094"), Faction.UNLIMITED)   ;//Siege Camp

      //Units
      f.ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED)   ;//Peasant
      f.ModObjectLimit(FourCC("hbot"), 12) 	    ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC("hdes"), 12) 	    ;//Alliance Frigate
      f.ModObjectLimit(FourCC("hbsh"), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC("hfoo"), Faction.UNLIMITED)   ;//Footman
      f.ModObjectLimit(FourCC("hkni"), Faction.UNLIMITED)   ;//Knight
      f.ModObjectLimit(FourCC("nchp"), Faction.UNLIMITED)   ;//Cleric
      f.ModObjectLimit(FourCC("h00F"), 6)           ;//Paladin
      f.ModObjectLimit(FourCC("nwe2"), 6)           ;//Thunder Eagle
      f.ModObjectLimit(FourCC("h01C"), Faction.UNLIMITED)   ;//Longbowman
      f.ModObjectLimit(FourCC("n03K"), Faction.UNLIMITED)   ;//Chaplain
      f.ModObjectLimit(FourCC("hcth"), Faction.UNLIMITED)   ;//Silver Hand Squire
      f.ModObjectLimit(FourCC("h02Q"), 6)           ;//Pegasus Knight
      f.ModObjectLimit(FourCC("e017"), 8)           ;//Scorpion
      f.ModObjectLimit(FourCC("o02F"), 6)           ;//Mangonel
      f.ModObjectLimit(FourCC("h09Y"), 2)           ;//Throne Guard

      //Demis
      f.ModObjectLimit(FourCC("h012"), 1)           ;//Falric

      f.ModObjectLimit(FourCC("Hart"), 1)           ;//Arthas
      f.ModObjectLimit(FourCC("Huth"), 1)           ;//Uther
      f.ModObjectLimit(FourCC("H01J"), 1)           ;//Mograine

      f.ModObjectLimit(FourCC("Harf"), 1)           ;//Arthas

      //Upgrades
      f.ModObjectLimit(FourCC("R02E"), Faction.UNLIMITED)   ;//Chaplain Adept Training
      f.ModObjectLimit(FourCC("R00I"), Faction.UNLIMITED)   ;//Light)s Praise Initiate Training
      f.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC("Rhse"), Faction.UNLIMITED)   ;//Magic Sentry
      f.ModObjectLimit(FourCC("Rhan"), Faction.UNLIMITED)   ;//Animal War Training
      f.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED)   ;//Improved Lumber Harvesting
      f.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED)   ;//Improved Masonry
      f.ModObjectLimit(FourCC("R04D"), Faction.UNLIMITED)   ;//Exorcism
      f.ModObjectLimit(FourCC("R01P"), Faction.UNLIMITED)   ;//Ensnare
      f.ModObjectLimit(FourCC("R06Q"), Faction.UNLIMITED)   ;//Paladin Adept Training
      f.ModObjectLimit(FourCC("R04A"), Faction.UNLIMITED)   ;//Rapid Fire
      f.ModObjectLimit(FourCC("R00B"), Faction.UNLIMITED)   ;//Veteran Footmen
      f.ModObjectLimit(FourCC("R01Q"), Faction.UNLIMITED)   ;//Pegasus Taming

      f.ModObjectLimit(FourCC("R08E"), Faction.UNLIMITED)   ;//Garithos Crusade
      f.ModObjectLimit(FourCC("R08F"), Faction.UNLIMITED)   ;//Mind Control
    }

  }
}
