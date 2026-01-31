using MacroTools.LegendSystem;
using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>
///   Completes when a unit casts a specific spell.
/// </summary>
public sealed class ObjectiveLegendCastSpellOnUnit : Objective
{
  private readonly LegendaryHero _caster;
  private readonly int _spellId;
  private readonly unit _target;

  /// <summary>
  ///   Completes when a specific Legend casts a specific spell on a specific unit.
  /// </summary>
  /// <param name="caster">Who needs to cast the spell.</param>
  /// <param name="spellId">The spell that needs to be casted for completion.</param>
  /// <param name="target">Whom the spell needs to be cast on.</param>
  public ObjectiveLegendCastSpellOnUnit(LegendaryHero caster, int spellId, unit target)
  {
    _caster = caster;
    _spellId = spellId;
    _target = target;
    PlayerUnitEvents.Register(SpellEvent.Effect, OnCast, spellId);
    Description = $"{caster.Name} has casted {GetObjectName(spellId)} on {target.Name}";
  }

  private void OnCast()
  {
    if (@event.Unit == _caster.Unit && @event.SpellTargetUnit == _target && @event.SpellAbilityId == _spellId)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
