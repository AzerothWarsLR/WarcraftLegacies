using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.OrcishHorde;

/// <summary>The Orcish Horde after drinking the blood of Mannoroth, bound to the Burning Legion.</summary>
public sealed class ChaosOrcsFaction : Faction
{
  private static readonly Dictionary<int, int> _chaosEquivalents = new()
  {
    { UNIT_OPEO_PEON_ORCISH_HORDE_WORKER, UNIT_O00E_CHAOS_PEON_WARSONG_BLOODPACT },
    { UNIT_OGRU_GRUNT_ORCISH_HORDE, UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG },
    { UNIT_ORAI_RAIDER_ORCISH_HORDE, UNIT_O00S_CHAOS_RAIDER_WARSONG },
    { UNIT_OSHM_SHAMAN_ORCISH_HORDE, UNIT_O100_FEL_WARLOCK_WARSONG_BLOODPACT }
  };

  private static readonly HashSet<int> _leftBehind = new()
  {
    UNIT_OTHR_WARCHIEF_OF_THE_HORDE_ORCISH_HORDE,
    UNIT_ORKN_CHIEFTAIN_OF_THE_DARKSPEAR_TRIBE_ORCISH_HORDE
  };

  private static readonly HashSet<int> _chaosOnly = new()
  {
    UNIT_VSWS_HIGH_OVERLORD_OF_THE_KOR_KRON_WARSONG,
    UNIT_NMAN_MANNOROTH_THE_DESTROYER_WARSONG_BLOODPACT,
    UPGRADE_R09O_DRINK_THE_BLOOD_OF_MANNOROTH
  };

  /// <summary>Creates the Chaos Orcs with whatever <paramref name="orcs"/> can currently build, train and research.</summary>
  public ChaosOrcsFaction(Faction orcs)
    : base("Chaos Orcs", playercolor.Red, @"ReplaceableTextures\CommandButtons\BTNChaosGrom.blp")
  {
    TraditionalTeam = TeamSetup.Legion;
    ControlPointDefenderUnitTypeId = UNIT_N0AA_CONTROL_POINT_DEFENDER_FEL;
    CinematicMusic = "DarkAgents";
    FoodMaximum = orcs.FoodMaximum;
    Nicknames = new List<string>
    {
      "chaos",
      "co"
    };

    var orcObjectInfo = OrcishHordeObjectInfo.GetAllObjectLimits()
      .Where(x => !_leftBehind.Contains(x.ObjectTypeId))
      .ToList();
    ProcessObjectInfo(orcObjectInfo.Select(ToChaosEquivalent));
    foreach (var objectInfo in orcObjectInfo)
    {
      SetObjectLimit(GetChaosEquivalent(objectInfo.ObjectTypeId), orcs.GetObjectLimit(objectInfo.ObjectTypeId));
    }

    foreach (var (objectId, limit) in orcs.GetAllObjectLimits())
    {
      if (!_leftBehind.Contains(objectId))
      {
        SetObjectLimit(GetChaosEquivalent(objectId), limit);
      }
    }

    SetObjectLimit(UNIT_VSWS_HIGH_OVERLORD_OF_THE_KOR_KRON_WARSONG, 1);
    SetObjectLimit(UNIT_NMAN_MANNOROTH_THE_DESTROYER_WARSONG_BLOODPACT, 1);
    SetObjectLimit(UPGRADE_R09O_DRINK_THE_BLOOD_OF_MANNOROTH, 1);
  }

  /// <summary>Gives <paramref name="orcs"/> anything the Chaos Orcs unlocked that the orcs don't already have.</summary>
  public void HandBackUnlocks(Faction orcs)
  {
    foreach (var (objectId, limit) in GetAllObjectLimits())
    {
      if (_chaosOnly.Contains(objectId))
      {
        continue;
      }

      var orcObjectId = GetOrcEquivalent(objectId);
      if (orcs.GetObjectLimit(orcObjectId) < limit)
      {
        orcs.SetObjectLimit(orcObjectId, limit);
      }
    }
  }

  private static int GetOrcEquivalent(int objectId)
  {
    foreach (var (orc, chaos) in _chaosEquivalents)
    {
      if (chaos == objectId)
      {
        return orc;
      }
    }

    return objectId;
  }

  private static int GetChaosEquivalent(int objectId) =>
    _chaosEquivalents.GetValueOrDefault(objectId, objectId);

  private static ObjectInfo ToChaosEquivalent(ObjectInfo objectInfo) =>
    new(GetChaosEquivalent(objectInfo.ObjectTypeId), objectInfo.Limit, objectInfo.Categories,
      objectInfo.LimitIncreaseHint);
}
