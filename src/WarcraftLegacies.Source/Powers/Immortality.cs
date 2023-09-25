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
    private readonly float _healChance;
    private readonly float _healAmountPercentage;
    private bool _active;
    private readonly List<Objective> _objectives = new();
    private readonly List<Capital> _worldTrees;

    /// <summary>The effect that appears when a unit is healed.</summary>
    public string Effect { get; init; } = "";
    
    public Immortality(float healChance, float healAmountPercentage, List<Capital> worldTrees)
    {
      _healChance = healChance;
      _healAmountPercentage = healAmountPercentage;
      Name = "Immortality";
      Description = $"When a unit you control would take lethal damage, it has a {healChance*100}% chance to instead restore hit points until it has {healAmountPercentage*100}% of its maximum hit points. Only active while your team controls a World Tree.";
      _worldTrees = worldTrees;
    }

    /// <inheritdoc />
    public override void OnAdd(player whichPlayer)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakesDamage, OnDamage, GetPlayerId(whichPlayer));
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
    }

    private void OnDamage()
    {
      var damagedUnit = GetTriggerUnit();
      if (!_active || !(GetEventDamage() >= damagedUnit.GetHitPoints()) || !(GetRandomReal(0, 1) < _healChance)) 
        return;
      
      BlzSetEventDamage(0);
      damagedUnit.SetCurrentHitpoints((int)(damagedUnit.GetMaximumHitPoints() * _healAmountPercentage));
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
    
    private void OnObjectiveProgressChanged(object? sender, Objective objective) =>
      _active = _objectives.Any(x => x.Progress == QuestProgress.Complete);
  }
}