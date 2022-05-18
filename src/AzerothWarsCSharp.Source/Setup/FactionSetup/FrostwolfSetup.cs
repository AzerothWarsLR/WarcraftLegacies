using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class FrostwolfSetup
  {
    public static Faction FACTION_FROSTWOLF { get; private set; }


    public static void Setup()
    {
      Faction f;
      FACTION_FROSTWOLF = new Faction("Frostwolf", PLAYER_COLOR_RED, "|c00ff0303",
        "ReplaceableTextures\\CommandButtons\\BTNThrall.blp");
      f = FACTION_FROSTWOLF;
      f.Team = TeamSetup.Horde;
      f.UndefeatedResearch = FourCC("R05V");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      f.ModObjectLimit(FourCC("ogre"), Faction.UNLIMITED); //Great Hall
      f.ModObjectLimit(FourCC("ostr"), Faction.UNLIMITED); //Stronghold
      f.ModObjectLimit(FourCC("ofrt"), Faction.UNLIMITED); //Fortress
      f.ModObjectLimit(FourCC("oalt"), Faction.UNLIMITED); //Altar of Storms
      f.ModObjectLimit(FourCC("obar"), Faction.UNLIMITED); //Barracks
      f.ModObjectLimit(FourCC("ofor"), Faction.UNLIMITED); //War Mill
      f.ModObjectLimit(FourCC("otto"), Faction.UNLIMITED); //Tauren Totem
      f.ModObjectLimit(FourCC("osld"), Faction.UNLIMITED); //Spirit Lodge
      f.ModObjectLimit(FourCC("otrb"), Faction.UNLIMITED); //Orc Burrow
      f.ModObjectLimit(FourCC("owtw"), Faction.UNLIMITED); //Watch Tower
      f.ModObjectLimit(FourCC("o002"), Faction.UNLIMITED); //Improved Watch Tower
      f.ModObjectLimit(FourCC("ovln"), Faction.UNLIMITED); //Voodoo Lounge
      f.ModObjectLimit(FourCC("oshy"), Faction.UNLIMITED); //Shipyard

      f.ModObjectLimit(FourCC("opeo"), Faction.UNLIMITED); //Peon
      f.ModObjectLimit(FourCC("ogru"), Faction.UNLIMITED); //Grunt
      f.ModObjectLimit(FourCC("otau"), Faction.UNLIMITED); //Tauren
      f.ModObjectLimit(FourCC("ohun"), Faction.UNLIMITED); //Troll Headhunter
      f.ModObjectLimit(FourCC("ocat"), 6); //Catapult
      f.ModObjectLimit(FourCC("otbr"), 12); //Troll Batrider
      f.ModObjectLimit(FourCC("odoc"), Faction.UNLIMITED); //Troll Witch Doctor
      f.ModObjectLimit(FourCC("oshm"), Faction.UNLIMITED); //Shaman
      f.ModObjectLimit(FourCC("ospw"), Faction.UNLIMITED); //Spirit Walker
      f.ModObjectLimit(FourCC("o00A"), 6); //Far Seer
      f.ModObjectLimit(FourCC("obot"), 12); //Transport Ship
      f.ModObjectLimit(FourCC("odes"), 12); //Orc Frigate
      f.ModObjectLimit(FourCC("oosc"), Faction.UNLIMITED); //Pack Kodo
      f.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught

      f.ModObjectLimit(FourCC("h00C"), 1); //Drek)thar
      f.ModObjectLimit(FourCC("Othr"), 1); //Thrall
      f.ModObjectLimit(FourCC("Ocbh"), 1); //Cairne
      f.ModObjectLimit(FourCC("Orkn"), 1); //Voljin
      f.ModObjectLimit(FourCC("Orex"), 1); //Rexxar

      f.ModObjectLimit(FourCC("Rows"), Faction.UNLIMITED); //Improved Pulverize
      f.ModObjectLimit(FourCC("Rost"), Faction.UNLIMITED); //Shaman Adept Training
      f.ModObjectLimit(FourCC("Rowd"), Faction.UNLIMITED); //Witch Doctor Adept Training
      f.ModObjectLimit(FourCC("Rowt"), Faction.UNLIMITED); //Spirit Walker Adept Training
      f.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED); //Spiritual Infusion
      f.ModObjectLimit(FourCC("Rolf"), Faction.UNLIMITED); //Liquid Fire
      f.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      f.ModObjectLimit(FourCC("Rorb"), Faction.UNLIMITED); //reinforced Defenses
      f.ModObjectLimit(FourCC("R00H"), Faction.UNLIMITED); //Animal Companion
      f.ModObjectLimit(FourCC("R00R"), Faction.UNLIMITED); //Improved Chain Lightning
      f.ModObjectLimit(FourCC("R00W"), Faction.UNLIMITED); //Toughened Hides
      f.ModObjectLimit(FourCC("R01Z"), Faction.UNLIMITED); //Battle Stations
      f.SetObjectLevel(FourCC("R01Z"), 1); //Battle Stations

      FactionManager.Register(FACTION_FROSTWOLF);
    }
  }
}