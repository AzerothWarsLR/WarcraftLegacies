using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Instances;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Setup;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WCSharp.Effects;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Shared.Powers;

public sealed class Immortality : Power
{
  private const string ProtectedColor = "|cff00ff00";
  private const string UnprotectedColor = "|cff808080";

  private readonly int _healChancePercentage;
  private readonly int _healAmountPercentage;
  private readonly List<WorldTreeProtection> _worldTreeProtections;
  private readonly Dictionary<Objective, WorldTreeProtection> _protectionsByObjective = new();
  private readonly HashSet<unit> _savedUnits = new();

  public string Effect { get; init; } = "";

  public Immortality(int healChancePercentage, int healAmountPercentage, List<WorldTreeProtection> worldTreeProtections)
  {
    _healChancePercentage = healChancePercentage;
    _healAmountPercentage = healAmountPercentage;
    Name = Loc.Get("Immortality");
    _worldTreeProtections = worldTreeProtections;
    RefreshDescription();
  }

  public override void OnAdd(player whichPlayer)
  {
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakesDamage, OnDamage, whichPlayer.Id);
  }

  public override void OnAdd(Faction whichFaction)
  {
    foreach (var worldTreeProtection in _worldTreeProtections)
    {
      var objective = new ObjectiveControlCapital(worldTreeProtection.WorldTree, false)
      {
        EligibleFactions = new List<Faction> { whichFaction }
      };
      _protectionsByObjective.Add(objective, worldTreeProtection);
      objective.OnAdd(whichFaction);
      objective.ProgressChanged += OnObjectiveProgressChanged;
    }

    RefreshDescription();
  }

  public override void OnRemove(player whichPlayer)
  {
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerTakesDamage, OnDamage, whichPlayer.Id);
  }

  public override void OnRemove(Faction whichFaction)
  {
    foreach (var objective in _protectionsByObjective.Keys)
    {
      objective.ProgressChanged -= OnObjectiveProgressChanged;
    }

    _protectionsByObjective.Clear();
  }

  private void OnDamage()
  {
    var damagedUnit = @event.Unit;
    if (!(@event.Damage >= damagedUnit.Life) || _savedUnits.Contains(damagedUnit) ||
        !(GetRandomInt(0, 100) < _healChancePercentage) || damagedUnit.IsUnitType(unittype.Structure) ||
        damagedUnit.IsUnitType(unittype.Mechanical) || !IsProtected(damagedUnit.GetPosition()))
    {
      return;
    }

    _savedUnits.Add(damagedUnit);
    @event.Damage = 0;
    damagedUnit.Life = (int)(damagedUnit.MaxLife * ((float)_healAmountPercentage / 100));
    EffectSystem.Add(effect.Create(Effect, damagedUnit, "origin"), 1);
  }

  private bool IsProtected(Point position)
  {
    if (InstanceSystem.GetPointInstance(position) != null)
    {
      return false;
    }

    if (ControlsAllWorldTrees())
    {
      return true;
    }

    return _protectionsByObjective.Any(x =>
      x.Key.Progress == QuestProgress.Complete && x.Value.Regions.Any(region => region.Contains(position.X, position.Y)));
  }

  private bool ControlsAllWorldTrees() =>
    _protectionsByObjective.Count > 0 && _protectionsByObjective.Keys.All(x => x.Progress == QuestProgress.Complete);

  private bool Controls(WorldTreeProtection worldTreeProtection) =>
    _protectionsByObjective.Any(x => x.Value == worldTreeProtection && x.Key.Progress == QuestProgress.Complete);

  private void OnObjectiveProgressChanged(Objective _) => RefreshDescription();

  private void RefreshDescription()
  {
    var regions = string.Join(", ", _worldTreeProtections.Select(x =>
      (Controls(x) ? ProtectedColor : UnprotectedColor) + Loc.Get(x.RegionName) + "|r"));

    Description = Loc.Format(
                    "Each unit has a {chance}% chance to survive death once, restoring {amount}% of its hit points.",
                    ("{chance}", _healChancePercentage.ToString()),
                    ("{amount}", _healAmountPercentage.ToString()))
                  + "|n" + Loc.Get("Works where your team holds the World Tree:")
                  + "|n" + regions;
  }
}
