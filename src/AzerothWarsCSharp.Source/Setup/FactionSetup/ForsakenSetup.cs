using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class ForsakenSetup
  {
    public static Faction FACTION_FORSAKEN { get; private set; }


    public static void Setup()
    {
      FACTION_FORSAKEN = new Faction("Cult", PLAYER_COLOR_LIGHT_BLUE, "|cff8080ff",
        "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp")
      {
        StartingGold = 0,
        StartingLumber = 100,
        IntroText = @"You are playing as the insidious Cult of the Damned.

        Your first objective is to use your three Cultists of the Damned to corrupt buildings in Lordaeron. These corrupted buildings will provide income for you until the plague is unleashed.

        You are enslaved to the Scourge and Burning Legion, but you can break free from their shackles.

        To do so, march North to Quel'thalas and capture the Sunwell. This will unlock Sylvanas, allowing you to reform as the Forsaken and declare independence from the Lich King."
      };

      //Buildings
      FACTION_FORSAKEN.ModObjectLimit(FourCC("h089"), Faction.UNLIMITED); //Necropolis
      FACTION_FORSAKEN.ModObjectLimit(FourCC("h08A"), Faction.UNLIMITED); //Halls of the Dead
      FACTION_FORSAKEN.ModObjectLimit(FourCC("h08B"), Faction.UNLIMITED); //Black Citadel
      FACTION_FORSAKEN.ModObjectLimit(FourCC("h08C"), Faction.UNLIMITED); //Ziggurat
      FACTION_FORSAKEN.ModObjectLimit(FourCC("h08D"), Faction.UNLIMITED); //Spirit Tower
      FACTION_FORSAKEN.ModObjectLimit(FourCC("h08E"), Faction.UNLIMITED); //Nerubian Tower
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u010"), Faction.UNLIMITED); //Altar of Darkness
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u011"), Faction.UNLIMITED); //Crypt
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u01J"), Faction.UNLIMITED); //Graveyard
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u016"), Faction.UNLIMITED); //Slaughterhouse
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u01W"), Faction.UNLIMITED); //Royal Sepulcur
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u014"), Faction.UNLIMITED); //Temple of the Damned
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u017"), Faction.UNLIMITED); //Tomb of Relics
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u01A"), Faction.UNLIMITED); //Undead Shipyard
      FACTION_FORSAKEN.ModObjectLimit(FourCC("h08F"), Faction.UNLIMITED); //Improved Spirit Tower

      //Units
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u01K"), Faction.UNLIMITED); //Acolyte
      FACTION_FORSAKEN.ModObjectLimit(FourCC("h08O"), Faction.UNLIMITED); //Ghoul
      FACTION_FORSAKEN.ModObjectLimit(FourCC("h08N"), Faction.UNLIMITED); //Abomination
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u01P"), 6); //Plague Catapult
      FACTION_FORSAKEN.ModObjectLimit(FourCC("n07S"), Faction.UNLIMITED); //Deadeye
      FACTION_FORSAKEN.ModObjectLimit(FourCC("h08P"), Faction.UNLIMITED); //Sorceress
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u01R"), Faction.UNLIMITED); //Apothecary

      FACTION_FORSAKEN.ModObjectLimit(FourCC("u02G"), 12); //Undercity Guardian
      FACTION_FORSAKEN.ModObjectLimit(FourCC("n07V"), 6); //Elder Banshee
      FACTION_FORSAKEN.ModObjectLimit(FourCC("o05H"), 8); //PlagueFlyer
      FACTION_FORSAKEN.ModObjectLimit(FourCC("n0BY"), 6); //dread knight
      FACTION_FORSAKEN.ModObjectLimit(FourCC("u01V"), 2); //Valyr
      FACTION_FORSAKEN.ModObjectLimit(FourCC("ubot"), 12); //Undead Transport Ship
      FACTION_FORSAKEN.ModObjectLimit(FourCC("udes"), 12); //Undead Frigate
      FACTION_FORSAKEN.ModObjectLimit(FourCC("uubs"), 6); //Undead Battleship

      FACTION_FORSAKEN.ModObjectLimit(FourCC("U01O"), 1); //Putress
      FACTION_FORSAKEN.ModObjectLimit(FourCC("Usyl"), 1); //Sylvanas
      FACTION_FORSAKEN.ModObjectLimit(FourCC("U02I"), 1); //Farenell

      //Upgrades
      FACTION_FORSAKEN.ModObjectLimit(FourCC("Ruba"), Faction.UNLIMITED); //Banshee Adept Training
      FACTION_FORSAKEN.ModObjectLimit(FourCC("R05C"), Faction.UNLIMITED); //Banshee Adept Training
      FACTION_FORSAKEN.ModObjectLimit(FourCC("R051"), Faction.UNLIMITED); //Apotechary Training
      FACTION_FORSAKEN.ModObjectLimit(FourCC("R02X"), Faction.UNLIMITED); // Open Scholomance
      FACTION_FORSAKEN.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Chaos Infusion

      FactionManager.Register(FACTION_FORSAKEN);
    }
  }
}