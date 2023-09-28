using System.Collections.Generic;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// When a of a given type unit dies, the caster remembers it, and can later summon copies of all of the units that died.
  /// </summary>
  public sealed class AncestralLegion : Spell
  {
    private static Dictionary<unit, AncestralLegionData> _ancestralLegionDataByUnit = new();
    
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
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var level = GetAbilityLevel(caster);
      var summonCap = SummonCap.Base + SummonCap.PerLevel * level;
      for (var i = 0; i < summonCap; i++)
      {
        var summonedTauren = CreateUnit(caster.OwningPlayer(), RememberableUnitTypeId, targetPoint.X, targetPoint.Y, caster.GetFacing())
          .SetColor(200, 165, 50, 150)
          .MultiplyBaseDamage(1 + DamageBonus.Base + DamageBonus.PerLevel * level, 0)
          .MultiplyMaxHitpoints(1 + HealthBonus.Base + HealthBonus.PerLevel * level);

        CreateTrigger()
          .RegisterUnitEvent(summonedTauren, EVENT_UNIT_DEATH)
          .AddAction(() =>
          {
            var triggerUnit = GetTriggerUnit();
            AddSpecialEffect(DeathEffect, GetUnitX(triggerUnit), GetUnitY(triggerUnit))
              .SetLifespan();
            
            GetTriggeringTrigger()
              .Destroy();
          });
        
        AddSpecialEffect(SummonEffect, targetPoint.X, targetPoint.Y)
          .SetLifespan();

        RegenerateTooltip(caster);
      }
    }

    /// <inheritdoc />
    public override void OnLearn(unit learner)
    {
      if (_ancestralLegionDataByUnit.ContainsKey(learner))
      {
        _ancestralLegionDataByUnit.Add(learner, new AncestralLegionData
        {
          BaseTooltips = new string[]
          {
            BlzGetAbilityExtendedTooltip(Id, 0),
            BlzGetAbilityExtendedTooltip(Id, 1),
            BlzGetAbilityExtendedTooltip(Id, 2)
          }
        });
      }
    }

    private void RegenerateTooltip(unit caster)
    {
      var ancestralLegionData = _ancestralLegionDataByUnit[caster];
      for (var i = 0; i < 3; i++)
        BlzSetAbilityExtendedTooltip(Id, $"{ancestralLegionData.BaseTooltips[i]}|n|n|cffDA9531Remembered Tauren:|r {ancestralLegionData.RememberedUnits}", i);
    }
    
    /// <inheritdoc />
    public AncestralLegion(int id) : base(id)
    {
    }

    private sealed class AncestralLegionData
    {
      /// <summary>
      /// The tooltips for Ancestral Legion at the start of the game.
      /// </summary>
      public string[] BaseTooltips { get; init; } = System.Array.Empty<string>();
      
      /// <summary>How many units the caster has remembered.</summary>
      public int RememberedUnits { get; set; }
    }
  }
}