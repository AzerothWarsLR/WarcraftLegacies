using AzerothWarsCSharp.MacroTools.Hazards;
using AzerothWarsCSharp.MacroTools.SpellSystem;

using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  /// <summary>
  /// Repeatedly casts a spell at the target location.
  /// </summary>
  public sealed class ResurgentSpell : Spell
  {
    public ResurgentSpell(int id, int dummySpellId, string dummySpellOrder) : base(id)
    {
      _dummySpellId = dummySpellId;
      _dummySpellOrder = dummySpellOrder;
    }

    private readonly int _dummySpellId;

    private readonly string _dummySpellOrder;

    public float Duration { get; init; }

    public float Interval { get; init; }

    public override void OnCast(unit caster, unit target, float targetX, float targetY)
    {
      var hazard = new RecurrentSpellHazard(GetTriggerUnit(), GetSpellTargetX(), GetSpellTargetY(),
        _dummySpellOrder, GetUnitAbilityLevel(GetTriggerUnit(), Id), _dummySpellId)
      {
        Duration = Duration,
        Interval = Interval
      };
      HazardSystem.Add(hazard);
    }
  }
}