using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class FrostwolfSetup
  {
    public static Faction FACTION_FROSTWOLF { get; private set; }
    
    public static void Setup()
    {
      FACTION_FROSTWOLF = new Faction("Frostwolf", PLAYER_COLOR_RED, "|c00ff0303",
        "ReplaceableTextures\\CommandButtons\\BTNThrall.blp")
      {
        UndefeatedResearch = FourCC("R05V"),
        StartingGold = 150,
        StartingLumber = 500,
        CinematicMusic = "SadMystery",
        IntroText = @"You are playing as the honorable |cffff0000Frostwolf Clan|r.

You have been shipwrecked. Gather enough resources to sail South-West to Kalimdor. Until you reach Kalimdor, you will be unable to train any more peons or research new tech. 

Once you land, you will find a Tauren caravan with a Great Hall packed in it's inventory. 
Escort the kodo to Thunderbluff, where you will find a goldmine waiting for you."
      };

      FACTION_FROSTWOLF.ModObjectLimit(FourCC("ogre"), Faction.UNLIMITED); //Great Hall
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("ostr"), Faction.UNLIMITED); //Stronghold
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("ofrt"), Faction.UNLIMITED); //Fortress
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("oalt"), Faction.UNLIMITED); //Altar of Storms
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("obar"), Faction.UNLIMITED); //Barracks
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("ofor"), Faction.UNLIMITED); //War Mill
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("otto"), Faction.UNLIMITED); //Tauren Totem
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("osld"), Faction.UNLIMITED); //Spirit Lodge
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("otrb"), Faction.UNLIMITED); //Orc Burrow
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("owtw"), Faction.UNLIMITED); //Watch Tower
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("o002"), Faction.UNLIMITED); //Improved Watch Tower
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("ovln"), Faction.UNLIMITED); //Voodoo Lounge
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("oshy"), Faction.UNLIMITED); //Shipyard

      FACTION_FROSTWOLF.ModObjectLimit(FourCC("opeo"), Faction.UNLIMITED); //Peon
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("ogru"), Faction.UNLIMITED); //Grunt
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("otau"), Faction.UNLIMITED); //Tauren
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("ohun"), Faction.UNLIMITED); //Troll Headhunter
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("ocat"), 6); //Catapult
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("otbr"), 12); //Troll Batrider
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("odoc"), Faction.UNLIMITED); //Troll Witch Doctor
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("oshm"), Faction.UNLIMITED); //Shaman
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("ospw"), Faction.UNLIMITED); //Spirit Walker
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("o00A"), 6); //Far Seer
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("obot"), 12); //Transport Ship
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("odes"), 12); //Orc Frigate
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("oosc"), Faction.UNLIMITED); //Pack Kodo
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught

      FACTION_FROSTWOLF.ModObjectLimit(FourCC("h00C"), 1); //Drek)thar
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("Othr"), 1); //Thrall
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("Ocbh"), 1); //Cairne
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("Orkn"), 1); //Voljin
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("Orex"), 1); //Rexxar

      FACTION_FROSTWOLF.ModObjectLimit(FourCC("Rows"), Faction.UNLIMITED); //Improved Pulverize
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("Rost"), Faction.UNLIMITED); //Shaman Adept Training
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("Rowd"), Faction.UNLIMITED); //Witch Doctor Adept Training
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("Rowt"), Faction.UNLIMITED); //Spirit Walker Adept Training
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED); //Spiritual Infusion
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("Rolf"), Faction.UNLIMITED); //Liquid Fire
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("Rorb"), Faction.UNLIMITED); //reinforced Defenses
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("R00H"), Faction.UNLIMITED); //Animal Companion
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("R00R"), Faction.UNLIMITED); //Improved Chain Lightning
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("R00W"), Faction.UNLIMITED); //Toughened Hides
      FACTION_FROSTWOLF.ModObjectLimit(FourCC("R01Z"), Faction.UNLIMITED); //Battle Stations
      FACTION_FROSTWOLF.SetObjectLevel(FourCC("R01Z"), 1); //Battle Stations

      FACTION_FROSTWOLF.ModAbilityAvailability(Constants.ABILITY_A0PF_FEL_ENERGY_TEAL_FORTRESSES, -1);
      FACTION_FROSTWOLF.ModAbilityAvailability(Constants.ABILITY_ANTR_TROLL_REGENERATION_PINK_WITCH_DOCTOR_TROLL_HEADHUNTER_TROLL_BATRIDER_DARKSPEAR_WARLORD_TROLL_BERSERKER_ICON, -1);
      FACTION_FROSTWOLF.ModAbilityAvailability(Constants.ABILITY_A0M4_BATTLE_STATIONS_PINK_GREY_ORC_BURROW_BLOODPACT, -1);
      FACTION_FROSTWOLF.ModAbilityAvailability(Constants.ABILITY_ABTL_BATTLE_STATIONS_FROSTWOLF_WARSONG_BURROW, 1);
      
      FactionManager.Register(FACTION_FROSTWOLF);
    }
  }
}