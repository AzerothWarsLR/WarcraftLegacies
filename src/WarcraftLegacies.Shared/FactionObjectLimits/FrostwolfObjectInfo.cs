using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class FrostwolfObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_OGRE_GREAT_HALL_FROSTWOLF_T1, Unlimited, UnitCategory.TownHall);
    yield return new(UNIT_OSTR_STRONGHOLD_FROSTWOLF_T2, Unlimited);
    yield return new(UNIT_OFRT_FORTRESS_FROSTWOLF_T3, Unlimited);
    yield return new(UNIT_OALT_ALTAR_OF_STORMS_FROSTWOLF_ALTAR, Unlimited, UnitCategory.Altar);
    yield return new(UNIT_OBAR_WAR_CAMP_FROSTWOLF_BARRACKS, Unlimited, UnitCategory.Barracks);
    yield return new(UNIT_OFOR_WAR_MILL_FROSTWOLF_RESEARCH, Unlimited, UnitCategory.Research);
    yield return new(UNIT_OTTO_TAUREN_TOTEM_FROSTWOLF_SIEGE, Unlimited, UnitCategory.Siege);
    yield return new(UNIT_OSLD_SPIRIT_LODGE_FROSTWOLF_MAGIC, Unlimited, UnitCategory.Magic);
    yield return new(UNIT_OTRB_BURROW_FROSTWOLF_FARM, Unlimited, UnitCategory.Farm);
    yield return new(UNIT_OWTW_WATCH_TOWER_FROSTWOLF_TOWER, Unlimited, UnitCategory.Tower);
    yield return new(UNIT_O002_IMPROVED_WATCH_TOWER_FROSTWOLF_TOWER_2, Unlimited, UnitCategory.Tower2);
    yield return new(UNIT_NBT2_IMPROVED_BOULDER_TOWER, Unlimited, UnitCategory.Tower3);
    yield return new(UNIT_OVLN_VOODOO_LOUNGE_FROSTWOLF_SHOP, Unlimited, UnitCategory.Shop);
    yield return new(UNIT_OSHY_HORDE_PIER_FROSTWOLF_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(UNIT_OOSC_PACK_KODO_FROSTWOLF, Unlimited);
    yield return new(UNIT_OBEA_BEASTIARY_FROSTWOLF_SPECIALIST, Unlimited, UnitCategory.Specialist);
    yield return new(UNIT_N06Z_FLIGHT_PATH_FROSTWOLF_WARSONG, 1, UnitCategory.Teleport);
    yield return new(UNIT_OPEO_PEON_FROSTWOLF_WARSONG_WORKER, Unlimited, UnitCategory.Worker);
    yield return new(UNIT_NTT2_TAUREN_TENT_FROSTWOLF_OTHER, Unlimited, UnitCategory.SpecailFarm1);
    yield return new(UNIT_H004_TROLL_HUT_FROSTWOLF_FARM, Unlimited, UnitCategory.SpecailFarm2);
    yield return new(UNIT_OGRU_GRUNT_FROSTWOLF, Unlimited, UnitCategory.MeleeBasic);
    yield return new(UNIT_OTAU_TAUREN_FROSTWOLF, Unlimited, UnitCategory.MeleeAdvanced);
    yield return new(UNIT_OHUN_HEADHUNTER_FROSTWOLF, Unlimited, UnitCategory.RangedBasic);
    yield return new(UNIT_OCAT_CATAPULT_FROSTWOLF, 6, UnitCategory.SiegeBasic);
    yield return new(UNIT_OTBR_BATRIDER_FROSTWOLF, 12, UnitCategory.FlyingBasic);
    yield return new(UNIT_ODOC_WITCH_DOCTOR_FROSTWOLF, Unlimited, UnitCategory.CasterSupport);
    yield return new(UNIT_OSHM_SHAMAN_FROSTWOLF, Unlimited, UnitCategory.CasterBasic);
    yield return new(UNIT_OSPW_SPIRIT_WALKER_FROSTWOLF, Unlimited, UnitCategory.CasterAdvanced);
    yield return new(UNIT_O00A_FAR_SEER_FROSTWOLF_ELITE, 6, UnitCategory.Elite);
    yield return new(UNIT_O06T_TAUREN_GLADIATOR_FROSTWOLF, 6);
    yield return new(UNIT_H0CN_PACKLEADER_FROSTWOLF, 4);
    yield return new(UNIT_H0CO_MAMMOTH_WRANGLER_FROSTWOLF, 2);
    yield return new(UNIT_N049_WANDERER_FROSTWOLF, 4);
    yield return new("obot", Unlimited); //Transport Ship
    yield return new("h0AS", Unlimited); //Scout
    yield return new("h0AP", Unlimited); //Frigate
    yield return new("h0B2", Unlimited); //Fireship
    yield return new("h0AY", Unlimited); //Galley
    yield return new("h0B5", Unlimited); //Boarding
    yield return new("h0BC", Unlimited); //Juggernaut
    yield return new("h0AO", 6); //Bombard
    yield return new("h00C", 1); //Drek)thar
    yield return new("Othr", 1); //Thrall
    yield return new("Ocbh", 1); //Cairne
    yield return new("Orkn", 1); //Voljin
    yield return new("Orex", 1); //Rexxar
    yield return new("Rows", Unlimited); //Improved Pulverize
    yield return new("Rost", Unlimited); //Shaman Adept Training
    yield return new("Rowd", Unlimited); //Witch Doctor Adept Training
    yield return new("Rowt", Unlimited); //Spirit Walker Adept Training
    yield return new("Rolf", Unlimited); //Liquid Fire
    yield return new("Rosp", Unlimited); //Spiked Barricades
    yield return new("Rorb", Unlimited); //reinforced Defenses
    yield return new("R00H", Unlimited); //Animal Companion
    yield return new("R00R", Unlimited); //Improved Chain Lightning
    yield return new("R00W", Unlimited); //Toughened Hides
    yield return new("R01Z", Unlimited); //Battle Stations
    yield return new(UPGRADE_R09N_FLIGHT_PATH_WARSONG, 1);
  }
}
