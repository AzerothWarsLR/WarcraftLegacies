using System;
using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.GameLogic.GrandAlliance;

/// <summary>Units near a capital held by anyone with this Power regenerate health and mana.</summary>
public sealed class StrengthInUnity : Power
{
  private const float Interval = 1;
  private const string LifeEffect = @"Abilities\Spells\Items\HealingSalve\HealingSalveTarget.mdl";
  private const string ManaEffect = @"Abilities\Spells\Items\ClarityPotion\ClarityTarget.mdl";

  private readonly float _radius;
  private readonly float _lifePerSecond;
  private readonly float _manaPerSecond;
  private readonly List<player> _players = new();
  private readonly List<unit> _auraCapitals = new();
  private readonly Dictionary<unit, effect> _lifeEffects = new();
  private readonly Dictionary<unit, effect> _manaEffects = new();
  private timer? _timer;

  /// <param name="radius">How close to a capital units must be.</param>
  /// <param name="lifePerSecond">The fraction of maximum health regained each second.</param>
  /// <param name="manaPerSecond">The fraction of maximum mana regained each second.</param>
  public StrengthInUnity(float radius, float lifePerSecond, float manaPerSecond)
  {
    _radius = radius;
    _lifePerSecond = lifePerSecond;
    _manaPerSecond = manaPerSecond;
    Description = Loc.Format(
      "Wherever the Alliance's banners fly, its soldiers find rest. Your units near any capital held by the Grand Alliance regenerate {life}% of their maximum health and {mana}% of their maximum mana every second.",
      ("{life}", ((int)(lifePerSecond * 100 + 0.5f)).ToString()),
      ("{mana}", ((int)(manaPerSecond * 100 + 0.5f)).ToString()));
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer)
  {
    _players.Add(whichPlayer);
    if (_timer == null)
    {
      _timer = timer.Create();
      _timer.Start(Interval, true, Regenerate);
    }
  }

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer)
  {
    _players.Remove(whichPlayer);
    if (_players.Count == 0 && _timer != null)
    {
      _timer.Dispose();
      _timer = null;
      Regenerate();
    }
  }

  private void Regenerate()
  {
    var regenerated = new List<unit>();
    var healing = new List<unit>();
    var restoring = new List<unit>();
    foreach (var capital in CapitalManager.GetAll())
    {
      try
      {
        RegenerateAround(capital, regenerated, healing, restoring);
      }
      catch (Exception ex)
      {
        var capitalUnit = capital.Unit;
        var capitalName = capitalUnit != null ? capitalUnit.Name : "a capital";
        Logger.LogError($"{Name} failed near {capitalName}: {ex.Message}");
      }
    }

    RefreshEffects(_lifeEffects, healing, LifeEffect);
    RefreshEffects(_manaEffects, restoring, ManaEffect);
  }

  private void RegenerateAround(Capital capital, List<unit> regenerated, List<unit> healing, List<unit> restoring)
  {
    var capitalUnit = capital.Unit;
    if (capitalUnit == null)
    {
      return;
    }

    var isAllianceCapital = capitalUnit.Alive && _players.Contains(capitalUnit.Owner);
    RefreshAura(capitalUnit, isAllianceCapital);
    if (!isAllianceCapital)
    {
      return;
    }

    foreach (var whichUnit in GlobalGroup.EnumUnitsInRange(capitalUnit.X, capitalUnit.Y, _radius))
    {
      if (whichUnit.Alive && !whichUnit.IsUnitType(unittype.Structure) && _players.Contains(whichUnit.Owner) &&
          !regenerated.Contains(whichUnit))
      {
        regenerated.Add(whichUnit);
        RegenerateUnit(whichUnit, healing, restoring);
      }
    }
  }

  private void RegenerateUnit(unit whichUnit, List<unit> healing, List<unit> restoring)
  {
    if (whichUnit.Life < whichUnit.MaxLife)
    {
      whichUnit.Life += whichUnit.MaxLife * _lifePerSecond * Interval;
      healing.Add(whichUnit);
    }

    if (whichUnit.MaxMana > 0 && whichUnit.Mana < whichUnit.MaxMana)
    {
      whichUnit.Mana += whichUnit.MaxMana * _manaPerSecond * Interval;
      restoring.Add(whichUnit);
    }
  }

  /// <summary>Keeps a looping effect on every unit in <paramref name="regenerating"/>, and removes it from any unit that has stopped.</summary>
  private static void RefreshEffects(Dictionary<unit, effect> effects, List<unit> regenerating, string model)
  {
    foreach (var whichUnit in regenerating)
    {
      if (!effects.ContainsKey(whichUnit))
      {
        effects[whichUnit] = AddSpecialEffectTarget(model, whichUnit, "origin");
      }
    }

    foreach (var whichUnit in new List<unit>(effects.Keys))
    {
      if (!regenerating.Contains(whichUnit))
      {
        effects[whichUnit].Dispose();
        effects.Remove(whichUnit);
      }
    }
  }

  /// <summary>Gives a Grand Alliance capital the aura that marks nearby units with the buff, and takes it from any other.</summary>
  private void RefreshAura(unit capitalUnit, bool isAllianceCapital)
  {
    var hasAura = _auraCapitals.Contains(capitalUnit);
    if (isAllianceCapital && !hasAura)
    {
      _auraCapitals.Add(capitalUnit);
      capitalUnit.AddAbility(ABILITY_A16W_STRENGTH_IN_UNITY_GRAND_ALLIANCE);
    }
    else if (!isAllianceCapital && hasAura)
    {
      _auraCapitals.Remove(capitalUnit);
      capitalUnit.RemoveAbility(ABILITY_A16W_STRENGTH_IN_UNITY_GRAND_ALLIANCE);
    }
  }
}
