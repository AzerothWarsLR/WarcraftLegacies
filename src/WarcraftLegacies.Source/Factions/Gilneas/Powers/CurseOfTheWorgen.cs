using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Gilneas.Powers;

/// <summary>At night Gilneas's worgen and wolves gain armor, attack speed and regeneration, more so while Gilneas stands alone.</summary>
public sealed class CurseOfTheWorgen : Power
{
  private const float Dawn = 6;
  private const float Dusk = 18;
  private const int AlliedLevel = 1;
  private const int AloneLevel = 2;
  private const int AloneLimitBonus = 2;

  private const string AlliedDescription =
    "At night, your worgen and wolves gain 2 armor, 15% attack speed and 2 health regeneration per second.";

  private const string AloneDescription =
    "Gilneas stands alone and can field 2 more of each limited unit. At night, your worgen and wolves gain 4 armor, 30% attack speed and 4 health regeneration per second.";

  private static readonly int[] _limitedUnits =
  {
    UNIT_O02J_WORGEN_GILNEAS,
    UNIT_O01V_GREYGUARD_GILNEAS,
    UNIT_O06P_WORGEN_SHAMAN_GILNEAS,
    UNIT_H04X_HARVEST_WITCH_GILNEAS,
    UNIT_O04U_CYCLONE_CANNON_GILNEAS
  };

  private static readonly int[] _nightAbilities =
  {
    ABILITY_A18Y_CURSE_OF_THE_WORGEN_ARMOR_DUMMY_GILNEAS,
    ABILITY_A18Z_CURSE_OF_THE_WORGEN_ATTACK_SPEED_DUMMY_GILNEAS,
    ABILITY_A190_CURSE_OF_THE_WORGEN_REGENERATION_DUMMY_GILNEAS
  };

  private static readonly List<int> _worgenTypes = new()
  {
    UNIT_O02J_WORGEN_GILNEAS,
    UNIT_O06P_WORGEN_SHAMAN_GILNEAS,
    UNIT_O01V_GREYGUARD_GILNEAS,
    UNIT_N06L_ARMORED_WOLF_GILNEAS,
    UNIT_E01E_ANCIENT_GUARDIAN_GILNEAS,
    UNIT_HPB2_GILNEAN_LORD_GILNEAS,
    UNIT_HHKL_KING_OF_GILNEAS_GILNEAS
  };

  private List<unit> _empowered = new();
  private Faction? _faction;
  private player? _owner;
  private timer? _refreshTimer;
  private bool _limitsRaised;

  public CurseOfTheWorgen()
  {
    Name = "Curse of the Worgen";
    IconName = "worgen";
    Description = AlliedDescription;
  }

  /// <inheritdoc />
  public override void OnAdd(Faction whichFaction) => _faction = whichFaction;

  /// <inheritdoc />
  public override void OnRemove(Faction whichFaction)
  {
    SetLimitsRaised(false);
    _faction = null;
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer)
  {
    _owner = whichPlayer;
    _refreshTimer = timer.Create();
    _refreshTimer.Start(1, true, Refresh);
    Refresh();
  }

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer)
  {
    if (_refreshTimer != null)
    {
      _refreshTimer.Dispose();
      _refreshTimer = null;
    }

    _owner = null;
    foreach (var worgen in _empowered)
    {
      RemoveNightAbilities(worgen);
    }

    _empowered.Clear();
  }

  private void Refresh()
  {
    var owner = _owner;
    if (owner == null)
    {
      return;
    }

    var curseLevel = GetCurseLevel(owner);
    var description = curseLevel == AloneLevel ? AloneDescription : AlliedDescription;
    if (Description != description)
    {
      Description = description;
    }

    SetLimitsRaised(curseLevel == AloneLevel);

    var level = IsNight() ? curseLevel : 0;
    var stillEmpowered = new List<unit>();
    if (level > 0)
    {
      foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(owner))
      {
        if (whichUnit.Alive && _worgenTypes.Contains(whichUnit.UnitType))
        {
          ApplyNightAbilities(whichUnit, level);
          stillEmpowered.Add(whichUnit);
        }
      }
    }

    foreach (var worgen in _empowered)
    {
      if (!stillEmpowered.Contains(worgen))
      {
        RemoveNightAbilities(worgen);
      }
    }

    _empowered = stillEmpowered;
  }

  private void SetLimitsRaised(bool raised)
  {
    var faction = _faction;
    if (faction == null || raised == _limitsRaised)
    {
      return;
    }

    _limitsRaised = raised;
    foreach (var unitTypeId in _limitedUnits)
    {
      faction.ModObjectLimit(unitTypeId, raised ? AloneLimitBonus : -AloneLimitBonus);
    }
  }

  private static int GetCurseLevel(player owner)
  {
    var team = owner.GetPlayerData().Team;
    return team == null || team.UndefeatedPlayerCount <= 1 ? AloneLevel : AlliedLevel;
  }

  private static void ApplyNightAbilities(unit worgen, int level)
  {
    foreach (var abilityId in _nightAbilities)
    {
      if (worgen.GetAbilityLevel(abilityId) == 0)
      {
        worgen.AddAbility(abilityId);
      }

      worgen.SetAbilityLevel(abilityId, level);
    }
  }

  private static void RemoveNightAbilities(unit worgen)
  {
    if (GetUnitTypeId(worgen) == 0)
    {
      return;
    }

    foreach (var abilityId in _nightAbilities)
    {
      worgen.RemoveAbility(abilityId);
    }
  }

  private static bool IsNight()
  {
    var timeOfDay = GetFloatGameState(GAME_STATE_TIME_OF_DAY);
    return timeOfDay >= Dusk || timeOfDay < Dawn;
  }
}
