using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class LegionObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_U00H_SOUL_TOWER_LEGION_TOWER, Unlimited); // Soultower
    yield return new(UNIT_U00I_IMPROVED_SOUL_TOWER_LEGION_TOWER, Unlimited); //Improved Soultower
    yield return new(UNIT_U00F_DORMANT_SPIRE_LEGION_T1, Unlimited); // Townhall T1
    yield return new(UNIT_U00C_LEGION_BASTION_LEGION_T2, Unlimited); // Townhall T2
    yield return new(UNIT_U00N_BURNING_CITADEL_LEGION_T3, Unlimited); // Townhall T3
    yield return new(UNIT_N040_SOUL_FORGE_LEGION_RESEARCH, Unlimited); // Blacksmith
    yield return new(UNIT_U009_SHIPYARD_LEGION_SHIPYARD, Unlimited, UnitCategory.Shipyard); //Shipyard
    yield return new(UNIT_U00E_SOUL_PRISON_LEGION_FARM, Unlimited); //Farm
    yield return new(UNIT_U01N_ALTAR_OF_DESTRUCTION_LEGION_ALTAR, Unlimited); // Altar
    yield return new(UNIT_U015_UNHOLY_RELIQUARY_LEGION_SHOP, Unlimited); //Shop
    yield return new(UNIT_U006_SUMMONING_CIRCLE_LEGION_MAGIC, 3, limitIncreaseHint: "completing certain Quests"); // Caster Building
    yield return new(UNIT_N04Q_NETHER_PIT_LEGION_BARRACKS, 3, limitIncreaseHint: "completing certain Quests"); // Barracks
    yield return new(UNIT_N04N_INFERNAL_SIEGEWORKS_LEGION_SPECIALIST, Unlimited); // Specialist
    yield return new(UNIT_NDMG_DEMON_GATE_LEGION_SIEGE, Unlimited); //Specialist 2


    yield return new(UNIT_U00D_LEGION_HERALD_LEGION_WORKER, Unlimited); // Worker
    yield return new(UNIT_U007_DREADLORD_LEGION_ELITE, 6); //Elite
    yield return new(UNIT_N04P_EREDAR_SUMMONER_LEGION, Unlimited); // Warlock Caster 1
    yield return new(UNIT_NINC_BURNING_ARCHER_LEGION, Unlimited); // Archer
    yield return new(UNIT_N04K_SUCCUBUS_LEGION, Unlimited); // Succubus Caster 2
    yield return new(UNIT_N04J_IMP_LEGION, Unlimited); //Imp summon?
    yield return new(UNIT_N0DO_DOOM_GUARD_LEGION, 12); // Doom Guard
    yield return new(UNIT_N04O_DOOM_LORD_LEGION, 6); // Doom Lord
    yield return new(UNIT_N04L_INFERNAL_JUGGERNAUT_LEGION, 6); // Infernal Juggernaut
    yield return new(UNIT_O04P_NATHREZIM_WARLOCK_LEGION, 6); // Nathrezim Warlock
    yield return new(UNIT_NINF_INFERNAL_LEGION, 6); // Infernal
    yield return new(UNIT_N04H_FEL_GUARD_LEGION, Unlimited); //Fel Guard
    yield return new(UNIT_N04U_NETHER_DRAGON_LEGION, 4); // Nether Dragon
    yield return new(UNIT_N03L_SKY_BARGE_LEGION, 4); // Sky Barge

    yield return new(UNIT_UMAL_THE_CUNNING_LEGION, 1); //Mal Ganis
    yield return new(UNIT_UTIC_THE_DARKENER_LEGION, 1); // Tichondrius
    yield return new(UNIT_U00L_ENVOY_OF_ARCHIMONDE_LEGION, 1); // Anetheron



    yield return new("ubot", Unlimited); //Undead Transport Ship
    yield return new("h0AT", Unlimited); //Scout
    yield return new("h0AW", Unlimited); //Frigate
    yield return new("h0AM", Unlimited); //Fireship
    yield return new("h0AZ", Unlimited); //Galley
    yield return new("h0AQ", Unlimited); //Boarding
    yield return new("h0BB", Unlimited); //Juggernaut
    yield return new("h0B9", 6); //Bombard

    yield return new("n05R", 1); //Felguard
    yield return new("n06H", 1); //Pit Fiend
    yield return new("n07B", 1); //Queen
    yield return new("n07D", 1); //Maiden
    yield return new("n07o", 1); //Terror
    yield return new("n07N", 1); //Lord
    yield return new("R02C", Unlimited); //Acute Sensors
    yield return new("R028", Unlimited); //Shadow Priest Adept Training
    yield return new("R042", Unlimited); //Nathrezim Adept Training
    yield return new("R027", Unlimited); //Warlock Adept Training
    yield return new("R04G", Unlimited); //Improved Carrion Swarm
    yield return new("R03Z", Unlimited); //War Plating
    yield return new(UPGRADE_R096_REMATERIALIZATION_LEGION, 1);
    yield return new(UPGRADE_R04R_FORTIFIED_HULLS_UNIVERSAL_UPGRADE, 1);
    yield return new(UPGRADE_R03L_IMPROVED_HEAL_FEL_HORDE, 1);
  }
}
