using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Spells;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Provides additional functionality to the Tome of Retraining ability.
/// <remarks>For this to make sense, the base ability must be based off Tome of Retraining.</remarks>
/// </summary>
public sealed class TomeOfRetrainingEx : Spell
{
  /// <summary>
  /// Abilities in this list should not be refundable, so they are re-added to the hero after Tome of Retraining takes effect.
  /// </summary>
  public List<int> UnrefundableAbilityTypeIds { get; init; } = new();

  /// <inheritdoc />
  public TomeOfRetrainingEx(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    foreach (var x in caster.GetUnitAbilities())
    {
      if (x.HeroAbility && UnrefundableAbilityTypeIds.Contains(x.Id))
      {
        var abilityTypeId = x.Id;
        var level = caster.GetAbilityLevel(abilityTypeId);
        Delay.Add(() => //Wait long enough for the Tome of Retraining to have taken effect
        {
          caster.AddAbility(abilityTypeId);
          caster.SetAbilityLevel(abilityTypeId, level);
          caster.SkillPoints -= level;
        });
      }
    }
  }
}
