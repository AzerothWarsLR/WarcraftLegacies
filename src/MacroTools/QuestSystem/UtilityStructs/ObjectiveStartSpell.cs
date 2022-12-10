using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  ///   Completes when a unit starts casting a specific spell.
  /// </summary>
  public sealed class ObjectiveStartSpell : Objective
  {
    private readonly bool _holderOnly;
    private readonly Legend? _requiredLegend;

    /// <summary>
    ///   Completes when a unit casts a specific spell.
    /// </summary>
    /// <param name="spellId">The spell that needs to be casted for completion.</param>
    /// <param name="holderOnly">If true, the quest holder must cast the spell themselves.</param>
    /// <param name="requiredLegend">The <see cref="Legend"/> that must cast the spell. If null, anyone can cast the spell.</param>
    public ObjectiveStartSpell(int spellId, bool holderOnly, Legend? requiredLegend = null)
    {
      PlayerUnitEvents.Register(UnitTypeEvent.SpellCast, OnCast, spellId);
      if (holderOnly)
        Description = "Start casting " + GetObjectName(spellId);
      else
        Description = "Anyone starts casting " + GetObjectName(spellId);

      _holderOnly = holderOnly;
      _requiredLegend = requiredLegend;
    }

    /// <summary>
    ///   The unit that was used to complete the quest.
    /// </summary>
    public unit? Caster { get; private set; }

    private void OnCast()
    {
      if (Progress != QuestProgress.Complete &&
          (_requiredLegend == null || Legend.GetFromUnit(GetTriggerUnit()) == _requiredLegend) &&
          (!_holderOnly || EligibleFactions.Contains(GetOwningPlayer(GetTriggerUnit()))))
      {
        Caster = GetTriggerUnit();
        Progress = QuestProgress.Complete;
      }
    }
  }
}