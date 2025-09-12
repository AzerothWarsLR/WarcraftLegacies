using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using MacroTools.Setup;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Powers
{
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
          SetPlayerTechResearched(player, ResearchId, researchLevel);
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
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakesDamage, OnDamage, GetPlayerId(whichPlayer));
      _playersWithPower.Add(whichPlayer);
    }

    /// <inheritdoc />
    public override void OnAdd(Faction whichFaction)
    {
      foreach (var worldTree in _worldTrees)
        AddObjective(new ObjectiveControlCapital(worldTree, false)
        {
          EligibleFactions = new List<Faction>{ whichFaction }
        }, whichFaction);
      RefreshIsActive();
    }

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer)
    {
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerTakesDamage, OnDamage, GetPlayerId(whichPlayer));
      _playersWithPower.Remove(whichPlayer);
      SetPlayerTechResearched(whichPlayer, ResearchId, 0);
    }

    /// <inheritdoc />
    public override void OnRemove(Faction whichFaction)
    {
      foreach (var objective in _objectives)
        RemoveObjective(objective);
      
      _objectives.Clear();
    }

    private void OnDamage()
    {
      var damagedUnit = GetTriggerUnit();
      if (!IsActive || !(GetEventDamage() >= GetUnitState(damagedUnit, UNIT_STATE_LIFE)) ||
          !(GetRandomInt(0, 100) < _healChancePercentage) || IsUnitType(damagedUnit, UNIT_TYPE_STRUCTURE) ||
          IsUnitType(damagedUnit, UNIT_TYPE_MECHANICAL)) 
        return;
      
      BlzSetEventDamage(0);
      int value = (int)(BlzGetUnitMaxHP(damagedUnit) * ((float)_healAmountPercentage / 100));
      SetUnitState(damagedUnit, UNIT_STATE_LIFE, value);
      AddSpecialEffectTarget(Effect, damagedUnit, "origin")
        .SetLifespan(1);
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
}