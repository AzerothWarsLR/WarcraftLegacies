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
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Powers
{
  public sealed class FontOfPower : Power
  {
    private readonly List<Objective> _objectives = new();
    private readonly List<Capital> _fontsOfPower;
    private bool _isActive;
    private readonly List<player> _playersWithPower = new();

    /// <summary>Active when the <see cref="Power"/> is active, inactive otherwise.</summary>
    public required int ResearchId { get; init; }
    
    /// <summary>How much mana to refund per mana cost spend on spells.</summary>
    public required float ManaRefundPercentage { get; init; }
    
    /// <summary>How much additional damage is dealt per point of damage.</summary>
    public required float BonusDamagePercentage { get; init; }
    
    private bool IsActive
    {
      get => _isActive;
      set
      {
        _isActive = value;
        var prefix = IsActive ? "" : "|cffc0c0c0";
        Description = $"{prefix}All units deal {(int)(BonusDamagePercentage*100)}% extra damage and regain {(int)(ManaRefundPercentage*100)}% of the mana cost of abilities. Only active while your team controls the Sunwell, the Well of Eternity, Black Temple, or Nordrassil.";
        var researchLevel = _isActive ? 1 : 0;
        foreach (var player in _playersWithPower)
          player.GetFaction()?.SetObjectLevel(ResearchId, researchLevel);
      }
    }

    public FontOfPower(List<Capital> fontsOfPower)
    {
      _fontsOfPower = fontsOfPower;
    }

    /// <inheritdoc />
    public override void OnAdd(player whichPlayer)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, GetPlayerId(whichPlayer));
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerSpellEffect, RefundMana, GetPlayerId(whichPlayer));
      _playersWithPower.Add(whichPlayer);
    }

    /// <inheritdoc />
    public override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
      foreach (var fontOfPower in _fontsOfPower)
        AddObjective(new ObjectiveControlCapital(fontOfPower, false)
        {
          EligibleFactions = new List<Faction> { whichFaction }
        }, whichFaction);
      RefreshIsActive();
    }

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer)
    {
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, GetPlayerId(whichPlayer));
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerSpellEffect, RefundMana, GetPlayerId(whichPlayer));
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

    /// <summary>
    /// Gets all fonts that currently count for the activeness of this Power.
    /// </summary>
    public IEnumerable<Capital> GetActiveFonts() =>
      _fontsOfPower.Where(x => x.OwningPlayer != null && UnitAlive(x.Unit) && _playersWithPower.Contains(x.OwningPlayer));

    private void OnDamage()
    {
      if (!IsActive) 
        return;

      BlzSetEventDamage(GetEventDamage() * 1.1f);
    }

    private void RefundMana()
    {
      if (!IsActive) 
        return;

      var caster = GetTriggerUnit();
      if (caster == null) 
        return;

      var abilityId = GetSpellAbilityId();
      var abilityLevel = GetUnitAbilityLevel(caster, abilityId);
      var manaCost = BlzGetUnitAbilityManaCost(caster, abilityId, abilityLevel - 1);

      if (manaCost <= 0)
        return;

      var manaRefund = manaCost * 0.15f;
      var currentMana = GetUnitState(caster, UNIT_STATE_MANA);
      if (GetUnitState(caster, UNIT_STATE_MANA) + manaRefund > GetUnitState(caster, UNIT_STATE_MAX_MANA))
      {
        //WC3's spell event triggers before mana cost is subtracted, so if the caster is already near maximum mana,
        //we need to defer the refund until later.
        Delay.Add(() =>
        {
          SetUnitState(caster, UNIT_STATE_MANA, GetUnitState(caster, UNIT_STATE_MANA) + manaRefund);
          GetExpiredTimer().Destroy();
        });
      }
      else
      {
        //If the caster is not near maximum mana, do it the simple way, performant way.
        SetUnitState(caster, UNIT_STATE_MANA, currentMana + manaRefund);
      }
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
