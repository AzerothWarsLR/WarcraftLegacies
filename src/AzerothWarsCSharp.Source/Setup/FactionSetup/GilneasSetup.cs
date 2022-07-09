using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class GilneasSetup
  {
    public static Faction FACTION_GILNEAS { get; private set; }


    public static void Setup()
    {
      FACTION_GILNEAS = new Faction("Gilneas", PLAYER_COLOR_COAL, "|cff808080",
        "ReplaceableTextures\\CommandButtons\\BTNGreymane.blp")
      {
        StartingGold = 150,
        StartingLumber = 200,
        IntroText = @"You are playing as the accursed |cff646464Kingdom of Gilneas|r|r.

        You start isolated behind the Greymane Wall, the only way for an enemy to reach you is through the Greymane Gate or via the coast.

        You must raise an army and fight back against the feral wolves and worgen that have overrun  your Kingdom.

        Once you have reclaimed Gilneas, open Greymane's Gate and march North to assist Lordaeron and Dalaran with the plague, if it's not too late."
      };

      //Structures
      FACTION_GILNEAS.ModObjectLimit(FourCC("h01R"), Faction.UNLIMITED); //Town Hall
      FACTION_GILNEAS.ModObjectLimit(FourCC("h023"), Faction.UNLIMITED); //Keep
      FACTION_GILNEAS.ModObjectLimit(FourCC("h02C"), Faction.UNLIMITED); //Castle
      FACTION_GILNEAS.ModObjectLimit(FourCC("h02F"), Faction.UNLIMITED); //Farm
      FACTION_GILNEAS.ModObjectLimit(FourCC("h02X"), Faction.UNLIMITED); //Altar
      FACTION_GILNEAS.ModObjectLimit(FourCC("h039"), Faction.UNLIMITED); //Scout Tower
      FACTION_GILNEAS.ModObjectLimit(FourCC("h03A"), Faction.UNLIMITED); //Guard Tower
      FACTION_GILNEAS.ModObjectLimit(FourCC("h03B"), Faction.UNLIMITED); //Cannon Tower
      FACTION_GILNEAS.ModObjectLimit(FourCC("h03D"), Faction.UNLIMITED); //Temple of the cursed
      FACTION_GILNEAS.ModObjectLimit(FourCC("h03E"), Faction.UNLIMITED); //Training Hall
      FACTION_GILNEAS.ModObjectLimit(FourCC("n008"), Faction.UNLIMITED); //Marketplace
      FACTION_GILNEAS.ModObjectLimit(FourCC("h03H"), Faction.UNLIMITED); //Shipyard
      FACTION_GILNEAS.ModObjectLimit(FourCC("h03O"), Faction.UNLIMITED); //Blacksmith
      FACTION_GILNEAS.ModObjectLimit(FourCC("h03Q"), Faction.UNLIMITED); //Garrison
      FACTION_GILNEAS.ModObjectLimit(FourCC("h052"), Faction.UNLIMITED); //Improved Guard Tower
      FACTION_GILNEAS.ModObjectLimit(FourCC("h04N"), Faction.UNLIMITED); //Improved Cannon Tower

      //Units
      FACTION_GILNEAS.ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED); //Peasant
      FACTION_GILNEAS.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      FACTION_GILNEAS.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      FACTION_GILNEAS.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      FACTION_GILNEAS.ModObjectLimit(FourCC("n06K"), Faction.UNLIMITED); //Wildsoul
      FACTION_GILNEAS.ModObjectLimit(FourCC("h04M"), Faction.UNLIMITED); //Cleric
      FACTION_GILNEAS.ModObjectLimit(FourCC("h04E"), Faction.UNLIMITED); //Protector
      FACTION_GILNEAS.ModObjectLimit(FourCC("n06L"), Faction.UNLIMITED); //Armored Wolf
      FACTION_GILNEAS.ModObjectLimit(FourCC("o01V"), 6); //Greyguard
      FACTION_GILNEAS.ModObjectLimit(FourCC("n029"), 12); //Sea Giant
      FACTION_GILNEAS.ModObjectLimit(FourCC("h03L"), Faction.UNLIMITED); //Shotgunner
      FACTION_GILNEAS.ModObjectLimit(FourCC("nsgt"), Faction.UNLIMITED); //Spider
      FACTION_GILNEAS.ModObjectLimit(FourCC("n067"), Faction.UNLIMITED); //Spider
      FACTION_GILNEAS.ModObjectLimit(FourCC("o04U"), 6); //Mangonel
      FACTION_GILNEAS.ModObjectLimit(FourCC("n06Z"), 6); //Gunship
      FACTION_GILNEAS.ModObjectLimit(FourCC("n06Q"), 12); //Royal Guard

      FACTION_GILNEAS.ModObjectLimit(FourCC("E01E"), 1); //Goldrinn
      FACTION_GILNEAS.ModObjectLimit(FourCC("Ewar"), 1); //Tess
      FACTION_GILNEAS.ModObjectLimit(FourCC("Hhkl"), 1); //Genn
      FACTION_GILNEAS.ModObjectLimit(FourCC("Hpb2"), 1); //Darius

      //Upgrades
      FACTION_GILNEAS.ModObjectLimit(FourCC("R04O"), Faction.UNLIMITED); //Cleric Training
      FACTION_GILNEAS.ModObjectLimit(FourCC("R04P"), Faction.UNLIMITED); //Scythe Training
      FACTION_GILNEAS.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion
      FACTION_GILNEAS.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      FACTION_GILNEAS.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry

      FactionManager.Register(FACTION_GILNEAS);
    }
  }
}