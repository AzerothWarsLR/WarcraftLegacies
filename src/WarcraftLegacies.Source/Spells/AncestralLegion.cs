using System;
using System.Collections.Generic;
using MacroTools.Data;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Effects;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// When a of a given type unit dies, the caster remembers it, and can later summon copies of all of the units that died.
/// </summary>
public sealed class AncestralLegion : Spell
{
  private static readonly Dictionary<unit, AncestralLegionData> _ancestralLegionDataByUnit = new();

  /// <summary>How long summoned units survive.</summary>
  public float Duration { get; init; }

  /// <summary>Summoned units have their hit points increased by this percentage.</summary>
  public LeveledAbilityField<float> HealthBonus { get; init; } = new();

  /// <summary>Summoned units have their damage increased by this percentage.</summary>
  public LeveledAbilityField<float> DamageBonus { get; init; } = new();

  /// <summary>The maximum number of Tauren that can be summoned.</summary>
  public LeveledAbilityField<int> SummonCap { get; init; } = new();

  /// <summary>The chance for a unit to be remembered on death.</summary>
  public float RememberChance { get; init; }

  /// <summary>Only units of this unit type ID will be remembered.</summary>
  public int RememberableUnitTypeId { get; init; }

  /// <summary>The effect to show when the spell is cast.</summary>
  public string SummonEffect { get; init; } = "";

  /// <summary>Summoned units will create this effect when they die.</summary>
  public string DeathEffect { get; init; } = "";

  /// <inheritdoc />
  public AncestralLegion(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var summonCap = SummonCap.Base + SummonCap.PerLevel * level;
    var ancestralLegionData = _ancestralLegionDataByUnit[caster];
    var availableTauren = ancestralLegionData.RememberedUnits;
    var taurenToSummon = Math.Min(summonCap, availableTauren);
    for (var i = 0; i < taurenToSummon; i++)
    {
      var summonedTauren = unit.Create(caster.Owner, RememberableUnitTypeId, targetPoint.X, targetPoint.Y, caster.Facing);
      summonedTauren.SetVertexColor(200, 165, 50, 150);

      summonedTauren.MultiplyBaseDamage(1 + DamageBonus.Base + DamageBonus.PerLevel * level, 0);
      summonedTauren.MultiplyMaxHitpoints(1 + HealthBonus.Base + HealthBonus.PerLevel * level);
      summonedTauren.SetTimedLife(Duration);
      summonedTauren.Name = "Ancestor";
      summonedTauren.AddType(unittype.Summoned);

      var deathTrigger = trigger.Create();
      deathTrigger.RegisterUnitEvent(summonedTauren, unitevent.Death);
      deathTrigger.AddAction(() =>
      {
        EffectSystem.Add(effect.Create(DeathEffect, summonedTauren.X, summonedTauren.Y), 1);

        summonedTauren.Dispose();

        @event.Trigger.Dispose();
      });

      EffectSystem.Add(effect.Create(SummonEffect, targetPoint.X, targetPoint.Y));
    }
    ancestralLegionData.RememberedUnits -= taurenToSummon;
    RegenerateTooltip(caster);
  }

  /// <inheritdoc />
  public override void OnLearn(unit learner)
  {
    if (_ancestralLegionDataByUnit.ContainsKey(learner))
    {
      return;
    }

    var newAncestralLegionData = new AncestralLegionData
    {
      BaseTooltips = new string[]
      {
        BlzGetAbilityExtendedTooltip(Id, 0),
        BlzGetAbilityExtendedTooltip(Id, 1),
        BlzGetAbilityExtendedTooltip(Id, 2)
      }
    };
    _ancestralLegionDataByUnit.Add(learner, newAncestralLegionData);

    RegisterRememberUnitsOnDeathTrigger(learner, newAncestralLegionData);
  }

  private void RegisterRememberUnitsOnDeathTrigger(unit learner, AncestralLegionData ancestralLegionData)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.Dies, () =>
    {
      if (!UnitIsRememberable(@event.Unit))
      {
        return;
      }

      ancestralLegionData.RememberedUnits++;
      RegenerateTooltip(learner);
    }, RememberableUnitTypeId);
  }

  private bool UnitIsRememberable(unit getTriggerUnit) =>
    !getTriggerUnit.IsUnitType(unittype.Summoned) && GetRandomReal(0, 1) < RememberChance;

  private void RegenerateTooltip(unit caster)
  {
    var ancestralLegionData = _ancestralLegionDataByUnit[caster];
    for (var i = 0; i < 3; i++)
    {
      BlzSetAbilityExtendedTooltip(Id, $"{ancestralLegionData.BaseTooltips[i]}|n|n|cffDA9531Remembered Tauren:|r {ancestralLegionData.RememberedUnits}", i);
    }
  }

  private sealed class AncestralLegionData
  {
    /// <summary>
    /// The tooltips for Ancestral Legion at the start of the game.
    /// </summary>
    public string[] BaseTooltips { get; init; } = Array.Empty<string>();

    /// <summary>How many units the caster has remembered.</summary>
    public int RememberedUnits { get; set; }
  }
}
