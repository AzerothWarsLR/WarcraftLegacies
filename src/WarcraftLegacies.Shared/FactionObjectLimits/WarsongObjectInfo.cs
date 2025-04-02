using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits
{
    public static class WarsongObjectInfo
    {
        private const int Unlimited = 200;

        public static IEnumerable<ObjectInfo> GetAllObjectLimits()
        {
            yield return new(UNIT_O00C_GREAT_HALL_WARSONG_T1, Unlimited, UnitCategory.TownHall);
            yield return new(UNIT_O02R_STRONGHOLD_WARSONG_T2, Unlimited);
            yield return new(UNIT_O02S_FORTRESS_WARSONG_T3, Unlimited);
            yield return new(UNIT_O020_ALTAR_OF_CONQUERORS_WARSONG_ALTAR, Unlimited, UnitCategory.Altar);
            yield return new(UNIT_O01S_WAR_CAMP_WARSONG_BARRACKS, Unlimited, UnitCategory.Barracks);
            yield return new(UNIT_O009_REFINERY_WARSONG_RESEARCH, Unlimited, UnitCategory.Research);  
            yield return new(UNIT_O05G_SIEGE_WORKSHOP_WARSONG_SIEGE, Unlimited, UnitCategory.Siege);
            yield return new(UNIT_O02Q_BEASTIARY_WARSONG_SPECIALIST, Unlimited, UnitCategory.Specialist);
            yield return new(UNIT_O028_BURROW_WARSONG_FARM, Unlimited, UnitCategory.Farm);
            yield return new(UNIT_N03E_IRON_KEEP_WARSONG_TOWER, Unlimited, UnitCategory.Tower);
            yield return new(UNIT_N0AL_IMPROVED_IRON_KEEP_WARSONG_TOWER_2, Unlimited, UnitCategory.Tower2);
            yield return new (UNIT_NBT2_IMPROVED_BOULDER_TOWER, Unlimited, UnitCategory.Tower3);
            yield return new(UNIT_O02T_SHIPYARD_WARSONG_SHIPYARD, Unlimited, UnitCategory.Shipyard);
            yield return new(UNIT_O01T_TREASURE_HOARD_WARSONG_SHOP, Unlimited, UnitCategory.Shop);
            yield return new(UNIT_NTT2_TAUREN_TENT_FROSTWOLF_OTHER, Unlimited, UnitCategory.SpecailFarm1);
            yield return new(UNIT_H004_TROLL_HUT_FROSTWOLF_FARM, Unlimited, UnitCategory.SpecailFarm2);
            yield return new(UNIT_O006_SPIRE_WARSONG_MAGIC, Unlimited, UnitCategory.Magic);
            yield return new(UNIT_O04L_PEON_WARSONG_WORKER, Unlimited, UnitCategory.Worker);
            yield return new(UNIT_O02M_WARSONG_GRUNT_WARSONG, Unlimited, UnitCategory.MeleeBasic);
            yield return new(UNIT_ORAI_RAIDER_WARSONG, Unlimited, UnitCategory.MeleeAdvanced);
            yield return new(UNIT_N07A_OGRE_WARRIOR_WARSONG, Unlimited, UnitCategory.MeleeSpecial);
            yield return new(UNIT_N06Z_FLIGHT_PATH_FROSTWOLF_WARSONG, 1, UnitCategory.Teleport);
            yield return new(UNIT_NOGN_WARLOCK_WARSONG, Unlimited, UnitCategory.CasterBasic);
            yield return new(UNIT_N08E_SHADOWPRIEST_WARSONG, Unlimited, UnitCategory.CasterSupport);
            yield return new(UNIT_N08O_OGRE_MAGI_WARSONG, Unlimited, UnitCategory.CasterAdvanced);
            yield return new(UNIT_OTBK_AXE_THROWER_WARSONG, Unlimited, UnitCategory.RangedBasic);
            yield return new(UNIT_O00I_WAR_MACHINE_WARSONG, Unlimited, UnitCategory.SiegeBasic);
            yield return new(UNIT_OKOD_KODO_BEAST_WARSONG, Unlimited, UnitCategory.SiegeAdvanced);
            yield return new(UNIT_E01M_AZERITE_SIEGE_ENGINE_WARSONG, Unlimited, UnitCategory.SiegeSpecial);
            yield return new(UNIT_O00G_BLADEMASTER_WARSONG, 6);
            yield return new(UNIT_N03F_KOR_KRON_ELITE_WARSONG_ELITE, 6, UnitCategory.Elite);
            yield return new(UNIT_OWYV_WIND_RIDER_WARSONG, 8, UnitCategory.FlyingBasic);
            yield return new("obot", Unlimited); //Transport Ship
            yield return new("h0AS", Unlimited); //Scout
            yield return new("h0AP", Unlimited); //Frigate
            yield return new("h0B2", Unlimited); //Fireship
            yield return new("h0AY", Unlimited); //Galley
            yield return new("h0B5", Unlimited); //Boarding
            yield return new("h0BC", Unlimited); //Juggernaut
            yield return new("h0AO", 6); //Bombard
            yield return new("Ogrh", 1); //Grom
            yield return new("Obla", 1); //Varok
            yield return new("O06L", 1); //Garrosh
            yield return new(UNIT_NSJS_BREWMASTER_WARSONG, 1);
            yield return new("n0CN", 1); //Gibbs
            yield return new(UNIT_OPGH_CORRUPTOR_OF_THE_WARSONG_CLAN_WARSONG_BLOODPACT,
                1); //Blood Pact Grom   Fixes Perma Death Grom Blood Pact bug
            yield return new(UPGRADE_R00J_OGRE_MAGRI_MASTER_TRAINING_WARSONG, Unlimited);
            yield return new("Robs", Unlimited); //Berserker Strength
            yield return new("Rotr", Unlimited); //Troll Regeneration
            yield return new("R01J", Unlimited); //Ensnare
            yield return new("R02I", Unlimited); //Ogre Magi Adept Training
            yield return new("R03Q", Unlimited); //Warlock Adept Training
            yield return new("Rorb", Unlimited); //Reinforced Defenses
            yield return new("Rosp", Unlimited); //Spiked Barricades
            yield return new("R016", Unlimited); //Warlords
            yield return new("R019", Unlimited); //Improved Shockwave
            yield return new(UPGRADE_R00D_MASS_BLOODLUST_FROSTWOLF, Unlimited);
            yield return new(UPGRADE_ROVS_ENVENOMED_SPEARS_WARSONG, Unlimited);
            yield return new(UPGRADE_R09N_FLIGHT_PATH_WARSONG, 1);
            yield return new(UPGRADE_R09O_DRINK_THE_BLOOD_OF_MANNOROTH, 1);
            yield return new(UPGRADE_R09P_REVERT_BLOODPACT, 1);
        }
    }
}