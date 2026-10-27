using System.Collections.Generic;
using System.Linq;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Shared;
using MacroTools.Utils;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Dalaran;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Shared steps for moving Quel'thalas to a Sunfury base beside Tempest Keep.</summary>
public static class SunfuryRelocation
{
  /// <summary>Where the new town hall goes.</summary>
  public const float BaseX = 2752;

  /// <inheritdoc cref="BaseX"/>
  public const float BaseY = -22912;

  private static readonly Point[] _armySpots =
  {
    new(2500, -21550),
    new(2700, -22600)
  };

  private const float ArmySpotClearRadius = 900;

  private static readonly List<unit> _outposts = new();

  private const float TempestSpireSize = 128;

  private static readonly Point[] _tempestSpireSpots =
  {
    new(3858, -21426),
    new(3816, -21891)
  };

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
      { UNIT_N00A_FARSTRIDER_QUELTHALAS_ELITE, UNIT_H0DH_SUNBLADE_MAGISTER_BLOODELVES },
      { UNIT_E024_ARCANE_ANNIHILATOR_QUELTHALAS, UNIT_E01B_ARCANE_ANNIHILATOR_SUNFURY },
      { UNIT_U00J_ARCANE_WAGON_QUELTHALAS, UNIT_H0DN_ARCANE_WAGON_BLOODELVES },
      { UNIT_H04F_ARCHMAGE_QUELTHALAS, UnitEquivalents.Keep }
    });

  /// <summary>Brings <paramref name="whichPlayer"/>'s army to the new base as Sunfury units.</summary>
  public static void RelocateArmy(player whichPlayer)
  {
    ClearArmySpots();
    PathBase.RelocateArmy(whichPlayer, ArmyEquivalents, _armySpots);
  }

  /// <summary>Brings <paramref name="whichPlayer"/>'s army to the new base as Blood Elf units.</summary>
  public static void RelocateBloodElvesArmy(player whichPlayer)
  {
    ClearArmySpots();
    PathBase.RelocateArmy(whichPlayer, BloodElvesArmyEquivalents, _armySpots);
  }

  /// <summary>Removes any creeps still standing where the army arrives.</summary>
  private static void ClearArmySpots()
  {
    foreach (var spot in _armySpots)
    {
      foreach (var creep in GlobalGroup.EnumUnitsInRange(spot.X, spot.Y, ArmySpotClearRadius))
      {
        if (creep.Owner == player.NeutralAggressive && creep.Alive && !creep.IsUnitType(unittype.Structure) &&
            creep.IsRemovable())
        {
          creep.DropAllItems();
          creep.Dispose();
        }
      }
    }
  }

  /// <summary>Hides the Sunfury outposts at Tempest Keep, Area 52 and Upper Netherstorm so a path can hand them out later.</summary>
  public static void HideOutposts()
  {
    _outposts.AddRange(Regions.TempestKeep.PrepareUnitsForRescue(RescuePreparationMode.HideAll));
    _outposts.AddRange(Regions.Area52Unlock.PrepareUnitsForRescue(RescuePreparationMode.HideAll));
    _outposts.AddRange(Regions.UpperNetherstorm.PrepareUnitsForRescue(RescuePreparationMode.HideAll));
  }

  /// <summary>Gives <paramref name="whichPlayer"/> the outposts hidden by <see cref="HideOutposts"/>.</summary>
  public static void GiveOutposts(player whichPlayer)
  {
    ClearOutpostArea(whichPlayer, Regions.Area52Unlock);
    ClearOutpostArea(whichPlayer, Regions.UpperNetherstorm);
    whichPlayer.RescueGroup(_outposts);
    _outposts.Clear();
    ControlPointManager.Instance.GetFromUnitType(UNIT_N07Q_AREA_52).Unit.SetOwner(whichPlayer);
    ControlPointManager.Instance.GetFromUnitType(UNIT_N0CW_FARAHLON).Unit.SetOwner(whichPlayer);
    var netherstorm = ControlPointManager.Instance.GetFromUnitType(UNIT_N02O_NETHERSTORM);
    if (netherstorm.Owner == player.NeutralPassive)
    {
      netherstorm.Unit.SetOwner(player.NeutralAggressive);
    }

    FortifyTempestKeep(whichPlayer);
  }

  /// <summary>Makes <paramref name="whichPlayer"/>'s Tempest Keep a capital guarded by two Tempest Spires.</summary>
  private static void FortifyTempestKeep(player whichPlayer)
  {
    var tempestKeep = GlobalGroup.EnumUnitsOfPlayer(whichPlayer)
      .FirstOrDefault(x => x.Alive && x.UnitType == UNIT_N05X_TEMPEST_KEEP_QUELTHALAS_OTHER);
    if (tempestKeep == null)
    {
      return;
    }

    var capital = new Capital
    {
      Unit = tempestKeep,
      Capturable = true
    };
    CapitalManager.Register(capital);
    foreach (var spot in _tempestSpireSpots)
    {
      var spire = CreateStructureForced(whichPlayer, UNIT_H0DO_TEMPEST_SPIRE_BLOODELVES, spot.X, spot.Y, 270, TempestSpireSize);
      if (spire != null)
      {
        capital.AddProtector(spire);
      }
    }
  }

  /// <summary>Removes creeps from <paramref name="area"/>, and removes and refunds other players' structures there.</summary>
  private static void ClearOutpostArea(player whichPlayer, Rectangle area)
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsInRect(area))
    {
      if (!whichUnit.Alive || !whichUnit.IsRemovable())
      {
        continue;
      }

      var owner = whichUnit.Owner;
      var isStructure = whichUnit.IsUnitType(unittype.Structure);
      if (owner == player.NeutralAggressive && !isStructure)
      {
        whichUnit.DropAllItems();
        whichUnit.Dispose();
      }
      else if (isStructure && owner != whichPlayer && owner != player.NeutralPassive && owner != player.NeutralAggressive)
      {
        owner.Gold += whichUnit.GoldCost;
        whichUnit.Dispose();
      }
    }
  }

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

  /// <summary>Creates the new <paramref name="hallType"/>, barracks and altar, guarded by <paramref name="soldierType"/> and <paramref name="archerType"/>.</summary>
  public static void BuildTownBase(player whichPlayer, int hallType, int soldierType, int archerType)
  {
    PathBase.CreateStructure(whichPlayer, hallType, BaseX, BaseY);
    PathBase.CreateStructure(whichPlayer, UNIT_H0C9_TRAINING_QUARTER_SUNFURY_BARRACKS, BaseX + 512, BaseY + 192);
    PathBase.CreateStructure(whichPlayer, UNIT_H0C6_ALTAR_OF_BLOOD_SUNFURY_ALTAR, BaseX - 512, BaseY + 192);
    PathBase.CreateUnits(whichPlayer, UNIT_N0E2_TECHNICIAN_SUNFURY_WORKER, 5, BaseX + 200, BaseY + 200);
    PathBase.CreateUnits(whichPlayer, soldierType, 3, BaseX, BaseY + 500);
    PathBase.CreateUnits(whichPlayer, archerType, 3, BaseX + 200, BaseY + 500);
  }
}
