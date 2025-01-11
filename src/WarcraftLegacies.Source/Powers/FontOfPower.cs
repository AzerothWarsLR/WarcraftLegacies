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
  public sealed class FontOfPower : Power
  {
    private readonly List<Objective> _objectives = new();
    private readonly List<Capital> _fontsOfPower;
    private bool _isActive;
    private readonly List<player> _playersWithPower = new();

    private bool IsActive
    {
      get => _isActive;
      set
      {
        _isActive = value;
        var prefix = IsActive ? "" : "|cffc0c0c0";
        Description = $"{prefix}All units deal 10% extra damage and regain 15% of the mana cost of abilities. Only active while your team controls a Font of Power.";
        var researchLevel = _isActive ? 1 : 0;
        foreach (var player in _playersWithPower)
          SetPlayerTechResearched(player, ResearchId, researchLevel);
      }
    }

    /// <summary>The effect that appears when an ability is cast.</summary>
    public string Effect { get; init; } = "";

    /// <summary>Active when the <see cref="Power"/> is active, inactive otherwise.</summary>
    public int ResearchId { get; init; }

    public FontOfPower(List<Capital> fontsOfPower)
    {
      Name = "Font of Power";
      _fontsOfPower = fontsOfPower;
    }

    /// <inheritdoc />
    public override void OnAdd(player whichPlayer)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, GetPlayerId(whichPlayer));
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerCastsSpell, OnSpellCast, GetPlayerId(whichPlayer));
      _playersWithPower.Add(whichPlayer);
    }

    /// <inheritdoc />
    public override void OnAdd(Faction whichFaction)
    {
      foreach (var fontOfPower in _fontsOfPower)
        AddObjective(new ObjectiveControlCapital(fontOfPower, false)
        {
          EligibleFactions = new List<Faction> { whichFaction }
        });
      RefreshIsActive();
    }

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer)
    {
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, GetPlayerId(whichPlayer));
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerCastsSpell, OnSpellCast, GetPlayerId(whichPlayer));
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
      if (!IsActive) 
        return;

      var damagedUnit = GetEventDamageSource();
      var extraDamage = (float)(GetEventDamage() * 0.1);
      UnitDamageTarget(damagedUnit, GetTriggerUnit(), extraDamage, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC,
        WEAPON_TYPE_WHOKNOWS);
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
      var manaCost = BlzGetUnitAbilityManaCost(castingUnit, abilityId, abilityLevel);
      var manaRefund = (float)(manaCost * 0.15);
      SetUnitState(castingUnit, UNIT_STATE_MANA, GetUnitState(castingUnit, UNIT_STATE_MANA) + manaRefund);
      AddSpecialEffectTarget(Effect, castingUnit, "origin")
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

    private void OnObjectiveProgressChanged(object? sender, Objective objective) => RefreshIsActive();

    private void RefreshIsActive()
    {
      var wasActive = _isActive;
      IsActive = _objectives.Any(x => x.Progress == QuestProgress.Complete);

      if (wasActive && !IsActive)
      {
        // Font of Power deactivated
      }
      else if (!wasActive && IsActive)
      {
        var completedObjective = _objectives.FirstOrDefault(x => x.Progress == QuestProgress.Complete);
        if (completedObjective != null)
        {
          // Font of Power activated
        }
      }
    }
  }
}
