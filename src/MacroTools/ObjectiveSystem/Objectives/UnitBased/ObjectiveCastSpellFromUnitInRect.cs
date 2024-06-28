using MacroTools.Extensions;
using MacroTools.QuestSystem;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  /// <summary>
  ///   Completes when a specific unit casts a specific spell in the
  /// specified <see cref="Rectangle"/>.
  /// </summary>
  public sealed class ObjectiveCastSpellFromUnitInRect : Objective
  {
    private readonly unit _caster;
    private readonly string _areaName;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveCastSpellFromUnitInRect"/> class.
    /// </summary>
    /// <param name="spellId">The spell that needs to be casted for completion.</param>
    /// <param name="caster">The caster that must cast the spell.</param>
    public ObjectiveCastSpellFromUnitInRect(Rectangle targetRect, string areaName, int spellId, unit caster)
    {
      _areaName = areaName;
      PlayerUnitEvents.Register(UnitEvent.SpellEffect, () =>
      {
        if (!targetRect.Contains(GetTriggerUnit().GetPosition()))
          return;
        if (GetSpellAbilityId() == spellId)
          Progress = QuestProgress.Complete;
      }, caster);
      Description = $"Cast {GetObjectName(spellId)} from {caster.GetName()} {_areaName}";
      TargetWidget = caster;
      DisplaysPosition = true;
      _caster = caster;
      Position = _caster.GetPosition();
    }
  }
}