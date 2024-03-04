using MacroTools.Extensions;
using MacroTools.QuestSystem;
using WCSharp.Events;


namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  /// <summary>
  ///   Completes when a specific unit casts a specific spell.
  /// </summary>
  public sealed class ObjectiveCastSpellFromUnit : Objective
  {
    private readonly unit _caster;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveCastSpellFromUnit"/> class.
    /// </summary>
    /// <param name="spellId">The spell that needs to be casted for completion.</param>
    /// <param name="caster">The caster that must cast the spell.</param>
    public ObjectiveCastSpellFromUnit(int spellId, unit caster)
    {
      PlayerUnitEvents.Register(UnitEvent.SpellEffect, () =>
      {
        if (GetSpellAbilityId() == spellId)
          Progress = QuestProgress.Complete;
      }, caster);
      Description = $"Cast {GetObjectName(spellId)} from {caster.Name}";
      TargetWidget = caster;
      DisplaysPosition = true;
      _caster = caster;
      Position = _caster.GetPosition();
    }
  }
}