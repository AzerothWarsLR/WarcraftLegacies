using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Dalaran;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Shared steps for moving Quel'thalas to a Sunfury base beside Tempest Keep.</summary>
public static class SunfuryRelocation
{
  /// <summary>Where the new town hall goes.</summary>
  public const float BaseX = 2752;

  /// <inheritdoc cref="BaseX"/>
  public const float BaseY = -22912;

  private static Dictionary<int, int> LordaeronEquivalents => UnitEquivalents.Pair(
    QuelthalasObjectInfo.GetAllObjectLimits(), LordaeronObjectInfo.GetAllObjectLimits());

  private static Dictionary<int, int> DalaranEquivalents => UnitEquivalents.Pair(
    QuelthalasObjectInfo.GetAllObjectLimits(), DalaranObjectInfo.GetAllObjectLimits(), new Dictionary<int, int>
    {
      { UNIT_N0A2_CONSORTIUM_QUELTHALAS_SIEGE, UNIT_H067_MANAFORGE_DALARAN_SPECIALIST }
    });

  private static Dictionary<int, int> ArmyEquivalents => UnitEquivalents.Pair(
    QuelthalasObjectInfo.GetAllObjectLimits(), SunfuryObjectInfo.GetAllObjectLimits(), new Dictionary<int, int>
    {
      { UNIT_HMPR_PRIEST_QUELTHALAS, UNIT_H0CH_ASTROMANCER_SUNFURY },
      { UNIT_HSOR_SORCERESS_QUELTHALAS, UNIT_H0CG_FLAMEKEEPER_SUNFURY },
      { UNIT_N048_BLOOD_MAGE_QUELTHALAS, UNIT_N0E3_WARLOCK_SUNFURY },
      { UNIT_HSPT_SPELLBREAKER_QUELTHALAS, UNIT_H0CE_BLOOD_KNIGHT_SQUIRE_SUNFURY },
      { UNIT_U00J_ARCANE_WAGON_QUELTHALAS, UNIT_U02W_ENERGY_WAGON_SUNFURY }
    });

  private static Dictionary<int, int> BloodElvesArmyEquivalents => UnitEquivalents.Pair(
    QuelthalasObjectInfo.GetAllObjectLimits(), BloodElvesObjectInfo.GetAllObjectLimits(), new Dictionary<int, int>
    {
      { UNIT_HHES_SWORDSMAN_QUELTHALAS, UNIT_H0DB_CENTURION_BLOODELVES },
      { UNIT_NHEA_RANGER_QUELTHALAS, UNIT_H0DC_BOWMAN_BLOODELVES },
      { UNIT_HMPR_PRIEST_QUELTHALAS, UNIT_H0DD_ASTROMANCER_BLOODELVES },
      { UNIT_HSOR_SORCERESS_QUELTHALAS, UNIT_H0DE_FLAMEKEEPER_BLOODELVES },
      { UNIT_N063_MAGUS_QUELTHALAS, UNIT_H0DE_FLAMEKEEPER_BLOODELVES },
      { UNIT_N048_BLOOD_MAGE_QUELTHALAS, UNIT_H0DM_BLOOD_MAGE_BLOODELVES },
      { UNIT_N02F_WARLOCK_QUELTHALAS, UNIT_H0DM_BLOOD_MAGE_BLOODELVES },
      { UNIT_HSPT_SPELLBREAKER_QUELTHALAS, UNIT_H0DK_SPELLBREAKER_BLOODELVES },
      { UNIT_HDHW_DRAGONHAWK_RIDER_QUELTHALAS, UNIT_H0DL_DRAGONHAWK_RIDER_BLOODELVES },
      { UNIT_E008_BALLISTA_QUELTHALAS, UNIT_H0DG_SCORPION_BLOODELVES },
      { UNIT_N00A_FARSTRIDER_QUELTHALAS_ELITE, UNIT_H0DH_BLOODWARDER_BLOODELVES },
      { UNIT_E024_ARCANE_ANNIHILATOR_QUELTHALAS, UNIT_E01B_ARCANE_ANNIHILATOR_SUNFURY },
      { UNIT_U00J_ARCANE_WAGON_QUELTHALAS, UNIT_H0DN_ARCANE_WAGON_BLOODELVES },
      { UNIT_H04F_ARCHMAGE_QUELTHALAS, UnitEquivalents.Keep }
    });

  /// <summary>Brings <paramref name="whichPlayer"/>'s army to the new base as Sunfury units.</summary>
  public static void RelocateArmy(player whichPlayer) =>
    PathBase.RelocateArmy(whichPlayer, ArmyEquivalents, BaseX, BaseY + 800);

  /// <summary>Brings <paramref name="whichPlayer"/>'s army to the new base as Blood Elf units.</summary>
  public static void RelocateBloodElvesArmy(player whichPlayer) =>
    PathBase.RelocateArmy(whichPlayer, BloodElvesArmyEquivalents, BaseX, BaseY + 800);

  /// <summary>Lordaeron if it's still in the game, otherwise Dalaran, otherwise nobody, with the buildings each turns Quel'thalas buildings into.</summary>
  private static player GetHomelandHeir(out Dictionary<int, int>? equivalents)
  {
    if (FactionManager.TryGetFactionByType<LordaeronFaction>(out var lordaeron) && IsStillInGame(lordaeron))
    {
      equivalents = LordaeronEquivalents;
      return lordaeron.Player!;
    }

    if (FactionManager.TryGetFactionByType<DalaranFaction>(out var dalaran) && IsStillInGame(dalaran))
    {
      equivalents = DalaranEquivalents;
      return dalaran.Player!;
    }

    equivalents = null;
    return player.NeutralPassive;
  }

  private static bool IsStillInGame(Faction faction) =>
    faction.Player != null && faction.ScoreStatus == ScoreStatus.Undefeated;

  /// <summary>Hands <paramref name="whichPlayer"/>'s Quel'thalas structures to its old allies.</summary>
  public static void LeaveHomeland(player whichPlayer)
  {
    var heir = GetHomelandHeir(out var equivalents);
    PathBase.HandOverStructures(whichPlayer, heir, equivalents);
  }

  /// <summary>Creates the new base beside Tempest Keep, guarded by Sunfury soldiers.</summary>
  public static void BuildBase(player whichPlayer) =>
    BuildBase(whichPlayer, UNIT_N09S_CENTURION_SUNFURY, UNIT_H0CF_BOWMAN_SUNFURY);

  /// <summary>Creates the new base beside Tempest Keep, guarded by <paramref name="soldierType"/> and <paramref name="archerType"/>.</summary>
  public static void BuildBase(player whichPlayer, int soldierType, int archerType)
  {
    PathBase.CreateStructure(whichPlayer, UNIT_H02P_HOLDING_SUNFURY_T1, BaseX, BaseY);
    PathBase.CreateStructure(whichPlayer, UNIT_H0C9_TRAINING_QUARTER_SUNFURY_BARRACKS, BaseX + 512, BaseY + 192);
    PathBase.CreateStructure(whichPlayer, UNIT_H0C6_ALTAR_OF_BLOOD_SUNFURY_ALTAR, BaseX - 512, BaseY + 192);
    PathBase.CreateUnits(whichPlayer, UNIT_N0E2_TECHNICIAN_SUNFURY_WORKER, 5, BaseX + 200, BaseY + 200);
    PathBase.CreateUnits(whichPlayer, soldierType, 3, BaseX, BaseY + 500);
    PathBase.CreateUnits(whichPlayer, archerType, 3, BaseX + 200, BaseY + 500);

    PathBase.CreateStructure(whichPlayer, UNIT_N05X_TEMPEST_KEEP_QUELTHALAS_OTHER, 4480, -21696);
    PathBase.CreateStructure(whichPlayer, UNIT_H0CA_ANCIENT_POOL_SUNFURY_SPECIALIST, 4192, -21344);
    PathBase.CreateStructure(whichPlayer, UNIT_H0CI_ARTIFICER_S_COURT_SUNFURY_SIEGE, 4064, -22048);
  }
}
