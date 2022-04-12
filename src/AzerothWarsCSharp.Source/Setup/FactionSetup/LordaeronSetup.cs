using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class LordaeronSetup
  {
    public static Faction FactionLordaeron { get; private set; }

    public static void Setup()
    {
      FactionLordaeron = new Faction("Lordaeron", PLAYER_COLOR_BLUE, "|c000042ff",
        "ReplaceableTextures\\CommandButtons\\BTNArthas.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        UndefeatedResearch = FourCC("R05M"),
        Team = TeamSetup.TeamAlliance
      };

      //Structures
      FactionLordaeron.ModObjectLimit(FourCC("htow"), Faction.UNLIMITED); //Town Hall
      FactionLordaeron.ModObjectLimit(FourCC("hkee"), Faction.UNLIMITED); //Keep
      FactionLordaeron.ModObjectLimit(FourCC("hcas"), Faction.UNLIMITED); //Castle
      FactionLordaeron.ModObjectLimit(FourCC("hhou"), Faction.UNLIMITED); //Farm
      FactionLordaeron.ModObjectLimit(FourCC("halt"), Faction.UNLIMITED); //Altar of Kings
      FactionLordaeron.ModObjectLimit(FourCC("hbar"), Faction.UNLIMITED); //Barracks
      FactionLordaeron.ModObjectLimit(FourCC("hbla"), Faction.UNLIMITED); //Blacksmith
      FactionLordaeron.ModObjectLimit(FourCC("h035"), Faction.UNLIMITED); //Chapel
      FactionLordaeron.ModObjectLimit(FourCC("hwtw"), Faction.UNLIMITED); //Scout Tower
      FactionLordaeron.ModObjectLimit(FourCC("hgtw"), Faction.UNLIMITED); //Guard Tower
      FactionLordaeron.ModObjectLimit(FourCC("h006"), Faction.UNLIMITED); //Guard Tower (Improved)
      FactionLordaeron.ModObjectLimit(FourCC("hctw"), Faction.UNLIMITED); //Cannon Tower
      FactionLordaeron.ModObjectLimit(FourCC("h007"), Faction.UNLIMITED); //Cannon Tower (Improved)
      FactionLordaeron.ModObjectLimit(FourCC("hshy"), Faction.UNLIMITED); //Alliance Shipyard
      FactionLordaeron.ModObjectLimit(FourCC("nmrk"), Faction.UNLIMITED); //Marketplace
      FactionLordaeron.ModObjectLimit(FourCC("h06C"), Faction.UNLIMITED); //Aviary
      FactionLordaeron.ModObjectLimit(FourCC("h094"), Faction.UNLIMITED); //Siege Camp

      //Units
      FactionLordaeron.ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED); //Peasant
      FactionLordaeron.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      FactionLordaeron.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      FactionLordaeron.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      FactionLordaeron.ModObjectLimit(FourCC("hfoo"), Faction.UNLIMITED); //Footman
      FactionLordaeron.ModObjectLimit(FourCC("hkni"), Faction.UNLIMITED); //Knight
      FactionLordaeron.ModObjectLimit(FourCC("nchp"), Faction.UNLIMITED); //Cleric
      FactionLordaeron.ModObjectLimit(FourCC("h00F"), 6); //Paladin
      FactionLordaeron.ModObjectLimit(FourCC("nwe2"), 6); //Thunder Eagle
      FactionLordaeron.ModObjectLimit(FourCC("h01C"), Faction.UNLIMITED); //Longbowman
      FactionLordaeron.ModObjectLimit(FourCC("n03K"), Faction.UNLIMITED); //Chaplain
      FactionLordaeron.ModObjectLimit(FourCC("hcth"), Faction.UNLIMITED); //Silver Hand Squire
      FactionLordaeron.ModObjectLimit(FourCC("h02Q"), 6); //Pegasus Knight
      FactionLordaeron.ModObjectLimit(FourCC("e017"), 8); //Scorpion
      FactionLordaeron.ModObjectLimit(FourCC("o02F"), 6); //Mangonel
      FactionLordaeron.ModObjectLimit(FourCC("h09Y"), 2); //Throne Guard

      //Demis
      FactionLordaeron.ModObjectLimit(FourCC("h012"), 1); //Falric

      FactionLordaeron.ModObjectLimit(FourCC("Hart"), 1); //Arthas
      FactionLordaeron.ModObjectLimit(FourCC("Huth"), 1); //Uther
      FactionLordaeron.ModObjectLimit(FourCC("H01J"), 1); //Mograine

      FactionLordaeron.ModObjectLimit(FourCC("Harf"), 1); //Arthas

      //Upgrades
      FactionLordaeron.ModObjectLimit(FourCC("R02E"), Faction.UNLIMITED); //Chaplain Adept Training
      FactionLordaeron.ModObjectLimit(FourCC("R00I"), Faction.UNLIMITED); //Light)s Praise Initiate Training
      FactionLordaeron.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion
      FactionLordaeron.ModObjectLimit(FourCC("Rhse"), Faction.UNLIMITED); //Magic Sentry
      FactionLordaeron.ModObjectLimit(FourCC("Rhan"), Faction.UNLIMITED); //Animal War Training
      FactionLordaeron.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      FactionLordaeron.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      FactionLordaeron.ModObjectLimit(FourCC("R04D"), Faction.UNLIMITED); //Exorcism
      FactionLordaeron.ModObjectLimit(FourCC("R01P"), Faction.UNLIMITED); //Ensnare
      FactionLordaeron.ModObjectLimit(FourCC("R06Q"), Faction.UNLIMITED); //Paladin Adept Training
      FactionLordaeron.ModObjectLimit(FourCC("R04A"), Faction.UNLIMITED); //Rapid Fire
      FactionLordaeron.ModObjectLimit(FourCC("R00B"), Faction.UNLIMITED); //Veteran Footmen
      FactionLordaeron.ModObjectLimit(FourCC("R01Q"), Faction.UNLIMITED); //Pegasus Taming

      FactionLordaeron.ModObjectLimit(FourCC("R08E"), Faction.UNLIMITED); //Garithos Crusade
      FactionLordaeron.ModObjectLimit(FourCC("R08F"), Faction.UNLIMITED); //Mind Control
    }
  }
}