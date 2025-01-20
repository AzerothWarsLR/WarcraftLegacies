using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  /// <summary>
  ///   Completes when a specific unit casts a specific spell.
  /// </summary>
  public sealed class ObjectiveCastSpellFromUnit : Objective
  {
    private readonly int _spellId;
    private readonly unit _caster;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveCastSpellFromUnit"/> class.
    /// </summary>
    /// <param name="spellId">The spell that needs to be casted for completion.</param>
    /// <param name="caster">The caster that must cast the spell.</param>
    public ObjectiveCastSpellFromUnit(int spellId, unit caster)
    {
      Description = $"Cast {GetObjectName(spellId)} from {caster.GetName()}";
      TargetWidget = caster;
      DisplaysPosition = true;
      _spellId = spellId;
      _caster = caster;
      Position = _caster.GetPosition();
    }

    /// <inheritdoc />
    public override void OnAdd(Faction faction)
    {
      PlayerUnitEvents.Register(UnitEvent.SpellEffect, () =>
      {
        if (GetSpellAbilityId() == _spellId && IsPlayerOnSameTeamAsAnyEligibleFaction(_caster.OwningPlayer()))
          Progress = QuestProgress.Complete;
      }, _caster);
    }
  }
}