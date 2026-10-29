using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Setup;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Powers;

/// <summary>Dark Iron units fighting on their home ground gain armor and damage, more so while the Dark Iron stand alone.</summary>
public sealed class BloodOfTheMountain : Power
{
  private const int AlliedLevel = 1;
  private const int AloneLevel = 2;
  private const float DamageBonusPerLevel = 0.1f;
  private const int AloneLimitBonus = 2;

  private const string AlliedDescription =
    "Your units fighting in Khaz Modan, the Wetlands, Grim Batol or Blackrock Mountain gain 2 armor and deal 10% more damage.";

  private const string AloneDescription =
    "The Dark Iron stand alone and can field 2 more of each limited unit. Your units fighting in Khaz Modan, the Wetlands, Grim Batol or Blackrock Mountain gain 4 armor and deal 20% more damage.";

  private static readonly int[] _limitedUnits =
  {
    UNIT_H0EA_MORTAR_TEAM_DARKIRON,
    UNIT_H0EF_EARTHBORER_DARKIRON,
    UNIT_H0E6_FIRE_WYRM_DARKIRON,
    UNIT_H0EB_DARK_IRON_THANE_DARKIRON_ELITE
  };

  private readonly Rectangle[] _homeland;
  private List<unit> _empowered = new();
  private Faction? _faction;
  private player? _owner;
  private timer? _refreshTimer;
  private bool _limitsRaised;

  public BloodOfTheMountain()
  {
    Name = "Blood of the Mountain";
    IconName = "DarkIronForge";
    Description = AlliedDescription;
    _homeland = new[]
    {
      Regions.IronforgeAmbient,
      Regions.DunmoroghAmbient1,
      Regions.DunmoroghAmbient2,
      Regions.DunmoroghAmbient3,
      Regions.LochModanAmbient,
      Regions.WetlandAmbient1,
      Regions.WetlandAmbient2,
      Regions.GrimBatolAmbient1,
      Regions.GrimBatolAmbient2,
      Regions.BurningSteppesAmbient,
      Regions.BlackrockUnlock,
      Regions.Shadowforge_City
    };
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
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealingDamage, OnDealingDamage, whichPlayer.Id);
    _refreshTimer = timer.Create();
    _refreshTimer.Start(1, true, Refresh);
    Refresh();
  }

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer)
  {
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealingDamage, OnDealingDamage, whichPlayer.Id);
    if (_refreshTimer != null)
    {
      _refreshTimer.Dispose();
      _refreshTimer = null;
    }

    _owner = null;
    foreach (var empowered in _empowered)
    {
      RemoveBlessing(empowered);
    }

    _empowered.Clear();
  }

  private static void OnDealingDamage()
  {
    var source = @event.DamageSource;
    if (source == null)
    {
      return;
    }

    var level = source.GetAbilityLevel(ABILITY_A1A7_BLOOD_OF_THE_MOUNTAIN_ARMOR_DUMMY_DARKIRON);
    if (level > 0)
    {
      @event.Damage *= 1 + DamageBonusPerLevel * level;
    }
  }

  private void Refresh()
  {
    var owner = _owner;
    if (owner == null)
    {
      return;
    }

    var level = GetBlessingLevel(owner);
    var description = level == AloneLevel ? AloneDescription : AlliedDescription;
    if (Description != description)
    {
      Description = description;
    }

    SetLimitsRaised(level == AloneLevel);

    var stillEmpowered = new List<unit>();
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(owner))
    {
      if (whichUnit.Alive && !whichUnit.IsUnitType(unittype.Structure) && IsInHomeland(whichUnit))
      {
        ApplyBlessing(whichUnit, level);
        stillEmpowered.Add(whichUnit);
      }
    }

    foreach (var empowered in _empowered)
    {
      if (!stillEmpowered.Contains(empowered))
      {
        RemoveBlessing(empowered);
      }
    }

    _empowered = stillEmpowered;
  }

  private bool IsInHomeland(unit whichUnit)
  {
    var x = whichUnit.X;
    var y = whichUnit.Y;
    foreach (var region in _homeland)
    {
      if (region.Contains(x, y))
      {
        return true;
      }
    }

    return false;
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

  private static int GetBlessingLevel(player owner)
  {
    var team = owner.GetPlayerData().Team;
    return team == null || team.UndefeatedPlayerCount <= 1 ? AloneLevel : AlliedLevel;
  }

  private static void ApplyBlessing(unit whichUnit, int level)
  {
    if (whichUnit.GetAbilityLevel(ABILITY_A1A7_BLOOD_OF_THE_MOUNTAIN_ARMOR_DUMMY_DARKIRON) == 0)
    {
      whichUnit.AddAbility(ABILITY_A1A7_BLOOD_OF_THE_MOUNTAIN_ARMOR_DUMMY_DARKIRON);
    }

    whichUnit.SetAbilityLevel(ABILITY_A1A7_BLOOD_OF_THE_MOUNTAIN_ARMOR_DUMMY_DARKIRON, level);
  }

  private static void RemoveBlessing(unit whichUnit)
  {
    if (GetUnitTypeId(whichUnit) == 0)
    {
      return;
    }

    whichUnit.RemoveAbility(ABILITY_A1A7_BLOOD_OF_THE_MOUNTAIN_ARMOR_DUMMY_DARKIRON);
  }
}
