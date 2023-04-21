using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Mechanics.Frostwolf;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class CthunSetup
  {
    public static Faction? Cthun { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Cthun = new Faction(FactionNames.Cthun, PLAYER_COLOR_WHEAT, "|cffaaa050",
        "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp")
      {
        ControlPointDefenderUnitTypeId = Constants.UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF,
        IntroText = @"You are playing as the honorable |cffff0000Frostwolf Clan|r.

You begin in the Salt Flats, separated from your ally, the Warsong Clan in the North.

Salvage the wrecked ships, establish a base and gather your troops to move inland and assist your ally against the Night Elf threat."

      };

      Cthun.ModObjectLimit(Constants.UNIT_OGRE_GREAT_HALL_FROSTWOLF_T1, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OSTR_STRONGHOLD_FROSTWOLF_T2, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OFRT_FORTRESS_FROSTWOLF_T3, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OALT_ALTAR_OF_STORMS_FROSTWOLF_ALTAR, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OBAR_WAR_CAMP_FROSTWOLF_BARRACKS, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OFOR_WAR_MILL_FROSTWOLF_RESEARCH, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OTTO_TAUREN_TOTEM_FROSTWOLF_SPECIALIST, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OSLD_SPIRIT_LODGE_FROSTWOLF_MAGIC, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OTRB_BURROW_FROSTWOLF_FARM, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OWTW_WATCH_TOWER_FROSTWOLF_TOWER, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_O002_IMPROVED_WATCH_TOWER_FROSTWOLF_TOWER_2, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OVLN_VOODOO_LOUNGE_FROSTWOLF_SHOP, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OSHY_HORDE_PIER_FROSTWOLF_SHIPYARD, Faction.UNLIMITED);
      Cthun.ModObjectLimit(Constants.UNIT_OOSC_PACK_KODO_FROSTWOLF, Faction.UNLIMITED);

      Cthun.ModObjectLimit(FourCC("opeo"), Faction.UNLIMITED); //Peon
      Cthun.ModObjectLimit(FourCC("ogru"), Faction.UNLIMITED); //Grunt
      Cthun.ModObjectLimit(FourCC("otau"), Faction.UNLIMITED); //Tauren
      Cthun.ModObjectLimit(FourCC("ohun"), Faction.UNLIMITED); //Troll Headhunter
      Cthun.ModObjectLimit(FourCC("ocat"), 6); //Catapult
      Cthun.ModObjectLimit(FourCC("otbr"), 12); //Troll Batrider
      Cthun.ModObjectLimit(FourCC("odoc"), Faction.UNLIMITED); //Troll Witch Doctor
      Cthun.ModObjectLimit(FourCC("oshm"), Faction.UNLIMITED); //Shaman
      Cthun.ModObjectLimit(FourCC("ospw"), Faction.UNLIMITED); //Spirit Walker
      Cthun.ModObjectLimit(FourCC("o00A"), 6); //Far Seer
      Cthun.ModObjectLimit(FourCC("obot"), Faction.UNLIMITED); //Transport Ship

      //Ship
      Cthun.ModObjectLimit(FourCC("obot"), Faction.UNLIMITED); //Transport Ship
      Cthun.ModObjectLimit(FourCC("h0AS"), Faction.UNLIMITED); //Scout
      Cthun.ModObjectLimit(FourCC("h0AP"), Faction.UNLIMITED); //Frigate
      Cthun.ModObjectLimit(FourCC("h0B2"), Faction.UNLIMITED); //Fireship
      Cthun.ModObjectLimit(FourCC("h0AY"), Faction.UNLIMITED); //Galley
      Cthun.ModObjectLimit(FourCC("h0B5"), Faction.UNLIMITED); //Boarding
      Cthun.ModObjectLimit(FourCC("h0BC"), Faction.UNLIMITED); //Juggernaut
      Cthun.ModObjectLimit(FourCC("h0AO"), 6); //Bombard

      Cthun.ModObjectLimit(FourCC("Othr"), 1); //Thrall
      Cthun.ModObjectLimit(FourCC("Ocbh"), 1); //Cairne
      Cthun.ModObjectLimit(FourCC("Orkn"), 1); //Voljin
      Cthun.ModObjectLimit(FourCC("Orex"), 1); //Rexxar

      
      FactionManager.Register(Cthun);
    }
  }
}