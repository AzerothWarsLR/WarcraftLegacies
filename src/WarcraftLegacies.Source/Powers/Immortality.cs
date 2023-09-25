using System.Collections.Generic;
using System.Linq;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Powers
{
  public sealed class Immortality : Power
  {
    private readonly int _healChancePercentage;
    private readonly int _healAmountPercentage;
    private bool _active;
    private readonly List<Objective> _objectives = new();
    private readonly List<Capital> _worldTrees;

    /// <summary>The effect that appears when a unit is healed.</summary>
    public string Effect { get; init; } = "";
    
    /// <summary>Active when the <see cref="Power"/> is active, inactive otherwise.</summary>
    public int ResearchId { get; init; }
    
    public Immortality(int healChancePercentage, int healAmountPercentage, List<Capital> worldTrees)
    {
      _healChancePercentage = healChancePercentage;
      _healAmountPercentage = healAmountPercentage;
      Name = "Immortality";
      Description = GenerateDescription();
      _worldTrees = worldTrees;
    }

    private string GenerateDescription()
    {
      var prefix = _active ? "" : "|cffc0c0c0";
      return $"{prefix}When a unit you control would take lethal damage, it has a {_healChancePercentage}% chance to instead restore hit points until it has {_healAmountPercentage}% of its maximum. Only active while your team controls a World Tree.";
    }

    /// <inheritdoc />
    public override void OnAdd(player whichPlayer)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakesDamage, OnDamage, GetPlayerId(whichPlayer));
      CheckIfActive();
      foreach (var worldTree in _worldTrees)
        AddObjective(new ObjectiveControlCapital(worldTree, false)
        {
          //Todo: this is too circular. Powers only apply to players, but Objectives apply to factions, so... Not good?
          EligibleFactions = new List<Faction>{ whichPlayer.GetFaction()! }
        });
    }

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer)
    {
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerTakesDamage, OnDamage, GetPlayerId(whichPlayer));
      foreach (var objective in _objectives)
        RemoveObjective(objective);
      
      _objectives.Clear();
    }

    private void OnDamage()
    {
      var damagedUnit = GetTriggerUnit();
      if (!_active || !(GetEventDamage() >= damagedUnit.GetHitPoints()) ||
          !(GetRandomInt(0, 100) < _healChancePercentage) || IsUnitType(damagedUnit, UNIT_TYPE_STRUCTURE) ||
          IsUnitType(damagedUnit, UNIT_TYPE_MECHANICAL)) 
        return;
      
      BlzSetEventDamage(0);
      damagedUnit.SetCurrentHitpoints((int)(damagedUnit.GetMaximumHitPoints() * ((float)_healAmountPercentage / 100)));
      AddSpecialEffectTarget(Effect, damagedUnit, "origin")
        .SetLifespan(1);
    }
    
    private void AddObjective(Objective objective)
    {
      _objectives.Add(objective);
      objective.ProgressChanged += OnObjectiveProgressChanged;
    }

    private void RemoveObjective(Objective objective)
    {
      _objectives.Remove(objective);
      objective.ProgressChanged -= OnObjectiveProgressChanged;
    }
    
    private void OnObjectiveProgressChanged(object? sender, Objective objective) => CheckIfActive();

    private void CheckIfActive()
    {
      _active = _objectives.Any(x => x.Progress == QuestProgress.Complete);
      Description = GenerateDescription();
    }
  }
}