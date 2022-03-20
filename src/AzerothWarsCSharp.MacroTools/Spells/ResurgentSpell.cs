using AzerothWarsCSharp.MacroTools.Hazards;
using AzerothWarsCSharp.MacroTools.SpellSystem;

namespace AzerothWarsCSharp.MacroTools.Spells
{
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

    public override void OnCast(unit caster, widget target, float targetX, float targetY)
    {
      var hazard = new RecurrentSpellHazard(null, GetTriggerUnit(), GetSpellTargetX(), GetSpellTargetY(),
        _dummySpellOrder, GetUnitAbilityLevel(GetTriggerUnit(), Id), _dummySpellId)
      {
        Duration = Duration,
        Interval = Interval
      };
      HazardSystem.Add(hazard);
    }
  }
}