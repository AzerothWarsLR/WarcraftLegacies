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

namespace WarcraftLegacies.Source.Powers
{
  public sealed class CorruptedSunwell : Power
  {
    private readonly List<Objective> _objectives = new();
    private readonly Capital _sunwell;
    private bool _isActive;
    private bool _wasScourgeControl;
    private readonly List<player> _playersWithPower = new();

    private bool IsActive
    {
      get => _isActive || _wasScourgeControl;
      set
      {
        _isActive = value;
        if (_isActive)
        {
          _wasScourgeControl = true;
        }
        var prefix = IsActive ? "" : "|cffc0c0c0";
        Description = $"{prefix}Your units are damaged for 20% of the mana they spend on spells. Units that die from this effect are reanimated as hostile Wretched. Activated once the Scourge takes control of the Sunwell.";
        var researchLevel = _isActive ? 1 : 0;
        foreach (var player in _playersWithPower)
          player.GetFaction()?.SetObjectLevel(ResearchId, researchLevel);
      }
    }

    public int ResearchId { get; init; }

    public CorruptedSunwell(Capital sunwell)
    {
      Name = "Corrupted Sunwell";
      _sunwell = sunwell;
    }

    /// <inheritdoc />
    public override void OnAdd(player whichPlayer)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerSpellEffect, OnSpellCast, GetPlayerId(whichPlayer));
      _playersWithPower.Add(whichPlayer);
    }

    /// <inheritdoc />
    public override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
      AddObjective(new ObjectiveControlCapital(_sunwell, false)
      {
        EligibleFactions = new List<Faction> { whichFaction }
      });
      RefreshIsActive(whichFaction);
    }

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer)
    {
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerSpellEffect, OnSpellCast, GetPlayerId(whichPlayer));
      _playersWithPower.Remove(whichPlayer);
    }

    /// <inheritdoc />
    public override void OnRemove(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
      whichFaction.SetObjectLevel(ResearchId, 0);

      foreach (var objective in _objectives)
        RemoveObjective(objective);

      _objectives.Clear();
    }

    private void OnSpellCast()
    {
      if (!IsActive)
        return;

      var castingUnit = GetTriggerUnit();
      if (castingUnit == null)
        return;

      var abilityId = GetSpellAbilityId();
      var abilityLevel = GetUnitAbilityLevel(castingUnit, abilityId);
      var manaCost = BlzGetUnitAbilityManaCost(castingUnit, abilityId, abilityLevel - 1);
      var damageAmount = manaCost * 0.2f;

      SetUnitState(castingUnit, UNIT_STATE_LIFE, GetUnitState(castingUnit, UNIT_STATE_LIFE) - damageAmount);

      if (GetUnitState(castingUnit, UNIT_STATE_LIFE) <= 0)
      {
        // Reanimate as hostile Wretched if unit dies from this effect
        var x = GetUnitX(castingUnit);
        var y = GetUnitY(castingUnit);
        CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE), UNIT_NZOM_ZOMBIE_SCOURGE, x, y, 0);
      }
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

    private void OnObjectiveProgressChanged(object? sender, Objective objective)
    {
      RefreshIsActive(null);
    }

    private void RefreshIsActive(Faction? whichFaction)
    {
      if (whichFaction != null && whichFaction.Name == "Scourge")
      {
        _wasScourgeControl = true;
      }

      IsActive = _wasScourgeControl;
    }
  }
}
