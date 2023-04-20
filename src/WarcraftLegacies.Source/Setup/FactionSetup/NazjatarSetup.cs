using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Mechanics.Frostwolf;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class NazjatarSetup
  {
    public static Faction? Nazjatar { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Nazjatar = new Faction(FactionNames.Nazjatar, PLAYER_COLOR_PURPLE, "|c00540081",
        "ReplaceableTextures\\CommandButtons\\BTNNzothIcon.blp")
      {
        ControlPointDefenderUnitTypeId = Constants.UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF,
      };

      Nazjatar.ModObjectLimit(Constants.UNIT_OGRE_GREAT_HALL_FROSTWOLF_T1, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OSTR_STRONGHOLD_FROSTWOLF_T2, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OFRT_FORTRESS_FROSTWOLF_T3, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OALT_ALTAR_OF_STORMS_FROSTWOLF_ALTAR, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OBAR_WAR_CAMP_FROSTWOLF_BARRACKS, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OFOR_WAR_MILL_FROSTWOLF_RESEARCH, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OTTO_TAUREN_TOTEM_FROSTWOLF_SPECIALIST, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OSLD_SPIRIT_LODGE_FROSTWOLF_MAGIC, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OTRB_BURROW_FROSTWOLF_FARM, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OWTW_WATCH_TOWER_FROSTWOLF_TOWER, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_O002_IMPROVED_WATCH_TOWER_FROSTWOLF_TOWER_2, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OVLN_VOODOO_LOUNGE_FROSTWOLF_SHOP, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OSHY_HORDE_PIER_FROSTWOLF_SHIPYARD, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_OOSC_PACK_KODO_FROSTWOLF, Faction.UNLIMITED);

      Nazjatar.ModObjectLimit(FourCC("opeo"), Faction.UNLIMITED); //Peon
      Nazjatar.ModObjectLimit(FourCC("ogru"), Faction.UNLIMITED); //Grunt
      Nazjatar.ModObjectLimit(FourCC("otau"), Faction.UNLIMITED); //Tauren
      Nazjatar.ModObjectLimit(FourCC("ohun"), Faction.UNLIMITED); //Troll Headhunter
      Nazjatar.ModObjectLimit(FourCC("ocat"), 6); //Catapult
      Nazjatar.ModObjectLimit(FourCC("otbr"), 12); //Troll Batrider
      Nazjatar.ModObjectLimit(FourCC("odoc"), Faction.UNLIMITED); //Troll Witch Doctor
      Nazjatar.ModObjectLimit(FourCC("oshm"), Faction.UNLIMITED); //Shaman
      Nazjatar.ModObjectLimit(FourCC("ospw"), Faction.UNLIMITED); //Spirit Walker
      Nazjatar.ModObjectLimit(FourCC("o00A"), 6); //Far Seer
      Nazjatar.ModObjectLimit(FourCC("obot"), Faction.UNLIMITED); //Transport Ship

      //Ship
      Nazjatar.ModObjectLimit(FourCC("obot"), Faction.UNLIMITED); //Transport Ship
      Nazjatar.ModObjectLimit(FourCC("h0AS"), Faction.UNLIMITED); //Scout
      Nazjatar.ModObjectLimit(FourCC("h0AP"), Faction.UNLIMITED); //Frigate
      Nazjatar.ModObjectLimit(FourCC("h0B2"), Faction.UNLIMITED); //Fireship
      Nazjatar.ModObjectLimit(FourCC("h0AY"), Faction.UNLIMITED); //Galley
      Nazjatar.ModObjectLimit(FourCC("h0B5"), Faction.UNLIMITED); //Boarding
      Nazjatar.ModObjectLimit(FourCC("h0BC"), Faction.UNLIMITED); //Juggernaut
      Nazjatar.ModObjectLimit(FourCC("h0AO"), 6); //Bombard

      Nazjatar.ModObjectLimit(FourCC("Othr"), 1); //Thrall
      Nazjatar.ModObjectLimit(FourCC("Ocbh"), 1); //Cairne
      Nazjatar.ModObjectLimit(FourCC("Orkn"), 1); //Voljin
      Nazjatar.ModObjectLimit(FourCC("Orex"), 1); //Rexxar

      
      FactionManager.Register(Nazjatar);
    }
  }
}