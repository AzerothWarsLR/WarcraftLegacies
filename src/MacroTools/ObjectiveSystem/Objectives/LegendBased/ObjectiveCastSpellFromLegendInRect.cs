using MacroTools.Extensions;
using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  /// <summary>
  ///   Completes when a specific legend casts a specific spell in the
  /// specified <see cref="Rectangle"/>.
  /// </summary>
  public sealed class ObjectiveCastSpellFromLegendInRect : Objective
  {
    private readonly Legend _legendaryHero;
    private readonly string _areaName;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveCastSpellFromLegendInRect"/> class.
    /// </summary>
    /// <param name="spellId">The spell that needs to be casted for completion.</param>
    /// <param name="legendaryHero">The caster that must cast the spell.</param>
    public ObjectiveCastSpellFromLegendInRect(Rectangle targetRect, string areaName, int spellId, LegendaryHero legendaryHero)
    {
      _areaName = areaName;
      _legendaryHero = legendaryHero;

      PlayerUnitEvents.Register(UnitEvent.SpellEffect, () =>
      {
        if (!targetRect.Contains(GetTriggerUnit().GetPosition()))
          return;
        if (GetSpellAbilityId() == spellId)
          Progress = QuestProgress.Complete;
      }, _legendaryHero.Unit);
      Description = $"Cast {GetObjectName(spellId)} with {legendaryHero.Name} {_areaName}";
      TargetWidget = legendaryHero.Unit;
      DisplaysPosition = true;
      _legendaryHero.Unit = legendaryHero.Unit;
      Position = _legendaryHero.Unit.GetPosition();
    }
  }
}