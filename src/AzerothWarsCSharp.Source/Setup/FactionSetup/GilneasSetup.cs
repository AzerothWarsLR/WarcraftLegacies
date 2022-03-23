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
      f.ModObjectLimit(FourCC("h01R"), UNLIMITED)   ;//Town Hall
      f.ModObjectLimit(FourCC("h023"), UNLIMITED)   ;//Keep
      f.ModObjectLimit(FourCC("h02C"), UNLIMITED)   ;//Castle
      f.ModObjectLimit(FourCC("h02F"), UNLIMITED)   ;//Farm
      f.ModObjectLimit(FourCC("h02X"), UNLIMITED)   ;//Altar
      f.ModObjectLimit(FourCC("h039"), UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC("h03A"), UNLIMITED)   ;//Guard Tower
      f.ModObjectLimit(FourCC("h03B"), UNLIMITED)   ;//Cannon Tower
      f.ModObjectLimit(FourCC("h03D"), UNLIMITED)   ;//Temple of the cursed
      f.ModObjectLimit(FourCC("h03E"), UNLIMITED)   ;//Training Hall
      f.ModObjectLimit(FourCC("n008"), UNLIMITED)   ;//Marketplace
      f.ModObjectLimit(FourCC("h03H"), UNLIMITED)   ;//Shipyard
      f.ModObjectLimit(FourCC("h03O"), UNLIMITED)   ;//Blacksmith
      f.ModObjectLimit(FourCC("h03Q"), UNLIMITED)   ;//Garrison
      f.ModObjectLimit(FourCC("h052"), UNLIMITED)   ;//Improved Guard Tower
      f.ModObjectLimit(FourCC("h04N"), UNLIMITED)   ;//Improved Cannon Tower

      //Units
      f.ModObjectLimit(FourCC("hpea"), UNLIMITED)   ;//Peasant
      f.ModObjectLimit(FourCC("hbot"), 12)   ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC("hdes"), 12)   ;//Alliance Frigate
      f.ModObjectLimit(FourCC("hbsh"), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC("n06K"), UNLIMITED)   ;//Wildsoul
      f.ModObjectLimit(FourCC("h04M"), UNLIMITED)   ;//Cleric
      f.ModObjectLimit(FourCC("h04E"), UNLIMITED)   ;//Protector
      f.ModObjectLimit(FourCC("n06L"), UNLIMITED)   ;//Armored Wolf
      f.ModObjectLimit(FourCC("o01V"), 6)           ;//Greyguard
      f.ModObjectLimit(FourCC("n029"), 12)          ;//Sea Giant
      f.ModObjectLimit(FourCC("h03L"), UNLIMITED)   ;//Shotgunner
      f.ModObjectLimit(FourCC("nsgt"), UNLIMITED)   ;//Spider
      f.ModObjectLimit(FourCC("n067"), UNLIMITED)   ;//Spider
      f.ModObjectLimit(FourCC("o04U"), 6)           ;//Mangonel
      f.ModObjectLimit(FourCC("n06Z"), 6)           ;//Gunship
      f.ModObjectLimit(FourCC("n06Q"), 12)          ;//Royal Guard

      f.ModObjectLimit(FourCC("E01E"), 1)          ;//Goldrinn
      f.ModObjectLimit(FourCC("Ewar"), 1)          ;//Tess
      f.ModObjectLimit(FourCC("Hhkl"), 1)          ;//Genn
      f.ModObjectLimit(FourCC("Hpb2"), 1)          ;//Darius

      //Upgrades
      f.ModObjectLimit(FourCC("R04O"), UNLIMITED)   ;//Cleric Training
      f.ModObjectLimit(FourCC("R04P"), UNLIMITED)   ;//Scythe Training
      f.ModObjectLimit(FourCC("R00K"), UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC("Rhlh"), UNLIMITED)   ;//Improved Lumber Harvesting
      f.ModObjectLimit(FourCC("Rhac"), UNLIMITED)   ;//Improved Masonry
    }

  }
}
