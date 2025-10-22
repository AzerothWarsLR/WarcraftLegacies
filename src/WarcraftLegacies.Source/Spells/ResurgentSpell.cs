using System;
using MacroTools.Hazards;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Repeatedly casts a spell at the target location.
/// </summary>
public sealed class ResurgentSpell : Spell
{
  public ResurgentSpell(int id, int dummySpellId, int dummySpellOrderId) : base(id)
  {
    _dummySpellId = dummySpellId;
    _dummySpellOrderId = dummySpellOrderId;
  }

  private readonly int _dummySpellId;

  private readonly int _dummySpellOrderId;

  public float Duration { get; init; }

  public float Interval { get; init; }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    try
    {
      var hazard = new RecurrentSpellHazard(@event.Unit, @event.SpellTargetX, @event.SpellTargetY,
        _dummySpellOrderId, @event.Unit.GetAbilityLevel(Id), _dummySpellId)
      {
        Duration = Duration,
        Interval = Interval
      };
      HazardSystem.Add(hazard);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to cast spell {nameof(RecurrentSpellHazard)}: {ex}");
    }
  }
}
