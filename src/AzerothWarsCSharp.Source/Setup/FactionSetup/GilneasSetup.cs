using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class GilneasSetup{

  
    Faction FACTION_GILNEAS
  

    public static void Setup( ){
      Faction f;

      FACTION_GILNEAS = Faction.create("Gilneas", PLAYER_COLOR_COAL, "|cff808080", "ReplaceableTextures\\CommandButtons\\BTNGreymane.blp");
      f = FACTION_GILNEAS;
      f.Team = TEAM_NIGHT_ELVES;
      f.StartingGold = 150;
      f.StartingLumber = 200;

      //Structures
      f.ModObjectLimit(FourCC("h01R"), Faction.UNLIMITED)   ;//Town Hall
      f.ModObjectLimit(FourCC("h023"), Faction.UNLIMITED)   ;//Keep
      f.ModObjectLimit(FourCC("h02C"), Faction.UNLIMITED)   ;//Castle
      f.ModObjectLimit(FourCC("h02F"), Faction.UNLIMITED)   ;//Farm
      f.ModObjectLimit(FourCC("h02X"), Faction.UNLIMITED)   ;//Altar
      f.ModObjectLimit(FourCC("h039"), Faction.UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC("h03A"), Faction.UNLIMITED)   ;//Guard Tower
      f.ModObjectLimit(FourCC("h03B"), Faction.UNLIMITED)   ;//Cannon Tower
      f.ModObjectLimit(FourCC("h03D"), Faction.UNLIMITED)   ;//Temple of the cursed
      f.ModObjectLimit(FourCC("h03E"), Faction.UNLIMITED)   ;//Training Hall
      f.ModObjectLimit(FourCC("n008"), Faction.UNLIMITED)   ;//Marketplace
      f.ModObjectLimit(FourCC("h03H"), Faction.UNLIMITED)   ;//Shipyard
      f.ModObjectLimit(FourCC("h03O"), Faction.UNLIMITED)   ;//Blacksmith
      f.ModObjectLimit(FourCC("h03Q"), Faction.UNLIMITED)   ;//Garrison
      f.ModObjectLimit(FourCC("h052"), Faction.UNLIMITED)   ;//Improved Guard Tower
      f.ModObjectLimit(FourCC("h04N"), Faction.UNLIMITED)   ;//Improved Cannon Tower

      //Units
      f.ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED)   ;//Peasant
      f.ModObjectLimit(FourCC("hbot"), 12)   ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC("hdes"), 12)   ;//Alliance Frigate
      f.ModObjectLimit(FourCC("hbsh"), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC("n06K"), Faction.UNLIMITED)   ;//Wildsoul
      f.ModObjectLimit(FourCC("h04M"), Faction.UNLIMITED)   ;//Cleric
      f.ModObjectLimit(FourCC("h04E"), Faction.UNLIMITED)   ;//Protector
      f.ModObjectLimit(FourCC("n06L"), Faction.UNLIMITED)   ;//Armored Wolf
      f.ModObjectLimit(FourCC("o01V"), 6)           ;//Greyguard
      f.ModObjectLimit(FourCC("n029"), 12)          ;//Sea Giant
      f.ModObjectLimit(FourCC("h03L"), Faction.UNLIMITED)   ;//Shotgunner
      f.ModObjectLimit(FourCC("nsgt"), Faction.UNLIMITED)   ;//Spider
      f.ModObjectLimit(FourCC("n067"), Faction.UNLIMITED)   ;//Spider
      f.ModObjectLimit(FourCC("o04U"), 6)           ;//Mangonel
      f.ModObjectLimit(FourCC("n06Z"), 6)           ;//Gunship
      f.ModObjectLimit(FourCC("n06Q"), 12)          ;//Royal Guard

      f.ModObjectLimit(FourCC("E01E"), 1)          ;//Goldrinn
      f.ModObjectLimit(FourCC("Ewar"), 1)          ;//Tess
      f.ModObjectLimit(FourCC("Hhkl"), 1)          ;//Genn
      f.ModObjectLimit(FourCC("Hpb2"), 1)          ;//Darius

      //Upgrades
      f.ModObjectLimit(FourCC("R04O"), Faction.UNLIMITED)   ;//Cleric Training
      f.ModObjectLimit(FourCC("R04P"), Faction.UNLIMITED)   ;//Scythe Training
      f.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED)   ;//Improved Lumber Harvesting
      f.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED)   ;//Improved Masonry
    }

  }
}
