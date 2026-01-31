using System.Collections.Generic;
using System.Linq;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.Quests;
using MacroTools.Setup;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WCSharp.Effects;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Powers;

public sealed class Immortality : Power
{
  private readonly int _healChancePercentage;
  private readonly int _healAmountPercentage;
  private readonly List<Objective> _objectives = new();
  private readonly List<Capital> _worldTrees;
  private bool _isActive;
  private readonly List<player> _playersWithPower = new();

  private bool IsActive
  {
    get => _isActive;
    set
    {
      _isActive = value;
      var prefix = IsActive ? "" : "|cffc0c0c0";
      Description = $"{prefix}When a unit you control would take lethal damage, it has a {_healChancePercentage}% chance to instead be restored to {_healAmountPercentage}% of its maximum hit points. Only active while your team controls a World Tree.";
      var researchLevel = _isActive ? 1 : 0;
      foreach (var player in _playersWithPower)
      {
        player.SetTechResearched(ResearchId, researchLevel);
      }
    }
  }

  /// <summary>The effect that appears when a unit is healed.</summary>
  public string Effect { get; init; } = "";

  /// <summary>Active when the <see cref="Power"/> is active, inactive otherwise.</summary>
  public int ResearchId { get; init; }

  public Immortality(int healChancePercentage, int healAmountPercentage, List<Capital> worldTrees)
  {
    _healChancePercentage = healChancePercentage;
    _healAmountPercentage = healAmountPercentage;
    Name = "Immortality";
    _worldTrees = worldTrees;
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer)
  {
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakesDamage, OnDamage, whichPlayer.Id);
    _playersWithPower.Add(whichPlayer);
  }

  /// <inheritdoc />
  public override void OnAdd(Faction whichFaction)
  {
    foreach (var worldTree in _worldTrees)
    {
      AddObjective(new ObjectiveControlCapital(worldTree, false)
      {
        EligibleFactions = new List<Faction> { whichFaction }
      }, whichFaction);
    }

    RefreshIsActive();
  }

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer)
  {
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerTakesDamage, OnDamage, whichPlayer.Id);
    _playersWithPower.Remove(whichPlayer);
    whichPlayer.SetTechResearched(ResearchId, 0);
  }

  /// <inheritdoc />
  public override void OnRemove(Faction whichFaction)
  {
    foreach (var objective in _objectives)
    {
      RemoveObjective(objective);
    }

    _objectives.Clear();
  }

  private void OnDamage()
  {
    var damagedUnit = @event.Unit;
    if (!IsActive || !(@event.Damage >= damagedUnit.Life) ||
        !(GetRandomInt(0, 100) < _healChancePercentage) || damagedUnit.IsUnitType(unittype.Structure) ||
        damagedUnit.IsUnitType(unittype.Mechanical))
    {
      return;
    }

    @event.Damage = 0;
    damagedUnit.Life = (int)(damagedUnit.MaxLife * ((float)_healAmountPercentage / 100));
    EffectSystem.Add(effect.Create(Effect, damagedUnit, "origin"), 1);
  }

  private void AddObjective(Objective objective, Faction faction)
  {
    _objectives.Add(objective);
    objective.OnAdd(faction);
    objective.ProgressChanged += OnObjectiveProgressChanged;
  }

  private void RemoveObjective(Objective objective)
  {
    _objectives.Remove(objective);
    objective.ProgressChanged -= OnObjectiveProgressChanged;
  }

  private void OnObjectiveProgressChanged(object? sender, Objective objective) => RefreshIsActive();

  private void RefreshIsActive() => IsActive = _objectives.Any(x => x.Progress == QuestProgress.Complete);
}
