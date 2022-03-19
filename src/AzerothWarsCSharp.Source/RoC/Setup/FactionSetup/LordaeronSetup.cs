using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup.FactionSetup
{
  public class LordaeronSetup{

  
    Faction FACTION_LORDAERON
  

    public static void Setup( ){
      Faction f;
      FACTION_LORDAERON = Faction.create("Lordaeron", PLAYER_COLOR_BLUE, "|c000042ff","ReplaceableTextures\\CommandButtons\\BTNArthas.blp");
      f = FACTION_LORDAERON;
      f.Team = TEAM_ALLIANCE;
      f.UndefeatedResearch = FourCC(R05M);
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC(htow), UNLIMITED)   ;//Town Hall
      f.ModObjectLimit(FourCC(hkee), UNLIMITED)   ;//Keep
      f.ModObjectLimit(FourCC(hcas), UNLIMITED)   ;//Castle
      f.ModObjectLimit(FourCC(hhou), UNLIMITED)   ;//Farm
      f.ModObjectLimit(FourCC(halt), UNLIMITED)   ;//Altar of Kings
      f.ModObjectLimit(FourCC(hbar), UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC(hbla), UNLIMITED)   ;//Blacksmith
      f.ModObjectLimit(FourCC(h035), UNLIMITED)   ;//Chapel
      f.ModObjectLimit(FourCC(hwtw), UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC(hgtw), UNLIMITED)   ;//Guard Tower
      f.ModObjectLimit(FourCC(h006), UNLIMITED)   ;//Guard Tower (Improved)
      f.ModObjectLimit(FourCC(hctw), UNLIMITED)   ;//Cannon Tower
      f.ModObjectLimit(FourCC(h007), UNLIMITED)   ;//Cannon Tower (Improved)
      f.ModObjectLimit(FourCC(hshy), UNLIMITED)   ;//Alliance Shipyard
      f.ModObjectLimit(FourCC(nmrk), UNLIMITED)   ;//Marketplace
      f.ModObjectLimit(FourCC(h06C), UNLIMITED)   ;//Aviary
      f.ModObjectLimit(FourCC(h094), UNLIMITED)   ;//Siege Camp

      //Units
      f.ModObjectLimit(FourCC(hpea), UNLIMITED)   ;//Peasant
      f.ModObjectLimit(FourCC(hbot), 12) 	    ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC(hdes), 12) 	    ;//Alliance Frigate
      f.ModObjectLimit(FourCC(hbsh), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC(hfoo), UNLIMITED)   ;//Footman
      f.ModObjectLimit(FourCC(hkni), UNLIMITED)   ;//Knight
      f.ModObjectLimit(FourCC(nchp), UNLIMITED)   ;//Cleric
      f.ModObjectLimit(FourCC(h00F), 6)           ;//Paladin
      f.ModObjectLimit(FourCC(nwe2), 6)           ;//Thunder Eagle
      f.ModObjectLimit(FourCC(h01C), UNLIMITED)   ;//Longbowman
      f.ModObjectLimit(FourCC(n03K), UNLIMITED)   ;//Chaplain
      f.ModObjectLimit(FourCC(hcth), UNLIMITED)   ;//Silver Hand Squire
      f.ModObjectLimit(FourCC(h02Q), 6)           ;//Pegasus Knight
      f.ModObjectLimit(FourCC(e017), 8)           ;//Scorpion
      f.ModObjectLimit(FourCC(o02F), 6)           ;//Mangonel
      f.ModObjectLimit(FourCC(h09Y), 2)           ;//Throne Guard

      //Demis
      f.ModObjectLimit(FourCC(h012), 1)           ;//Falric

      f.ModObjectLimit(FourCC(Hart), 1)           ;//Arthas
      f.ModObjectLimit(FourCC(Huth), 1)           ;//Uther
      f.ModObjectLimit(FourCC(H01J), 1)           ;//Mograine

      f.ModObjectLimit(FourCC(Harf), 1)           ;//Arthas

      //Upgrades
      f.ModObjectLimit(FourCC(R02E), UNLIMITED)   ;//Chaplain Adept Training
      f.ModObjectLimit(FourCC(R00I), UNLIMITED)   ;//Light)s Praise Initiate Training
      f.ModObjectLimit(FourCC(R00K), UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC(Rhse), UNLIMITED)   ;//Magic Sentry
      f.ModObjectLimit(FourCC(Rhan), UNLIMITED)   ;//Animal War Training
      f.ModObjectLimit(FourCC(Rhlh), UNLIMITED)   ;//Improved Lumber Harvesting
      f.ModObjectLimit(FourCC(Rhac), UNLIMITED)   ;//Improved Masonry
      f.ModObjectLimit(FourCC(R04D), UNLIMITED)   ;//Exorcism
      f.ModObjectLimit(FourCC(R01P), UNLIMITED)   ;//Ensnare
      f.ModObjectLimit(FourCC(R06Q), UNLIMITED)   ;//Paladin Adept Training
      f.ModObjectLimit(FourCC(R04A), UNLIMITED)   ;//Rapid Fire
      f.ModObjectLimit(FourCC(R00B), UNLIMITED)   ;//Veteran Footmen
      f.ModObjectLimit(FourCC(R01Q), UNLIMITED)   ;//Pegasus Taming

      f.ModObjectLimit(FourCC(R08E), UNLIMITED)   ;//Garithos Crusade
      f.ModObjectLimit(FourCC(R08F), UNLIMITED)   ;//Mind Control
    }

  }
}
