using WarcraftLegacies.MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class GilneasSetup
  {
    public static Faction? Gilneas { get; private set; }
    
    public static void Setup()
    {
      Gilneas = new Faction("Gilneas", PLAYER_COLOR_COAL, "|cff808080",
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
      Gilneas.ModObjectLimit(FourCC("h01R"), Faction.UNLIMITED); //Town Hall
      Gilneas.ModObjectLimit(FourCC("h023"), Faction.UNLIMITED); //Keep
      Gilneas.ModObjectLimit(FourCC("h02C"), Faction.UNLIMITED); //Castle
      Gilneas.ModObjectLimit(FourCC("h02F"), Faction.UNLIMITED); //Farm
      Gilneas.ModObjectLimit(FourCC("h02X"), Faction.UNLIMITED); //Altar
      Gilneas.ModObjectLimit(FourCC("h039"), Faction.UNLIMITED); //Scout Tower
      Gilneas.ModObjectLimit(FourCC("h03A"), Faction.UNLIMITED); //Guard Tower
      Gilneas.ModObjectLimit(FourCC("h03B"), Faction.UNLIMITED); //Cannon Tower
      Gilneas.ModObjectLimit(FourCC("h03D"), Faction.UNLIMITED); //Temple of the cursed
      Gilneas.ModObjectLimit(FourCC("h03E"), Faction.UNLIMITED); //Training Hall
      Gilneas.ModObjectLimit(FourCC("n008"), Faction.UNLIMITED); //Marketplace
      Gilneas.ModObjectLimit(FourCC("h03H"), Faction.UNLIMITED); //Shipyard
      Gilneas.ModObjectLimit(FourCC("h03O"), Faction.UNLIMITED); //Blacksmith
      Gilneas.ModObjectLimit(FourCC("h03Q"), Faction.UNLIMITED); //Garrison
      Gilneas.ModObjectLimit(FourCC("h052"), Faction.UNLIMITED); //Improved Guard Tower
      Gilneas.ModObjectLimit(FourCC("h04N"), Faction.UNLIMITED); //Improved Cannon Tower

      //Units
      Gilneas.ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED); //Peasant
      Gilneas.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      Gilneas.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      Gilneas.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      Gilneas.ModObjectLimit(FourCC("n06K"), Faction.UNLIMITED); //Wildsoul
      Gilneas.ModObjectLimit(FourCC("h04M"), Faction.UNLIMITED); //Cleric
      Gilneas.ModObjectLimit(FourCC("h04E"), Faction.UNLIMITED); //Protector
      Gilneas.ModObjectLimit(FourCC("n06L"), Faction.UNLIMITED); //Armored Wolf
      Gilneas.ModObjectLimit(FourCC("o01V"), 6); //Greyguard
      Gilneas.ModObjectLimit(FourCC("n029"), 12); //Sea Giant
      Gilneas.ModObjectLimit(FourCC("h03L"), Faction.UNLIMITED); //Shotgunner
      Gilneas.ModObjectLimit(FourCC("nsgt"), Faction.UNLIMITED); //Spider
      Gilneas.ModObjectLimit(FourCC("n067"), Faction.UNLIMITED); //Spider
      Gilneas.ModObjectLimit(FourCC("o04U"), 6); //Mangonel
      Gilneas.ModObjectLimit(FourCC("n06Z"), 6); //Gunship
      Gilneas.ModObjectLimit(FourCC("n06Q"), 12); //Royal Guard

      Gilneas.ModObjectLimit(FourCC("E01E"), 1); //Goldrinn
      Gilneas.ModObjectLimit(FourCC("Ewar"), 1); //Tess
      Gilneas.ModObjectLimit(FourCC("Hhkl"), 1); //Genn
      Gilneas.ModObjectLimit(FourCC("Hpb2"), 1); //Darius

      //Upgrades
      Gilneas.ModObjectLimit(FourCC("R04O"), Faction.UNLIMITED); //Cleric Training
      Gilneas.ModObjectLimit(FourCC("R04P"), Faction.UNLIMITED); //Scythe Training
      Gilneas.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion
      Gilneas.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      Gilneas.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry

      FactionManager.Register(Gilneas);
    }
  }
}