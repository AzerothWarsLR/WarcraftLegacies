using MacroTools.Spells;
using WCSharp.Api.Enums;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Spells;

public sealed class PiercingFrenzy : Spell
{
  public required float Duration { get; init; }

  public PiercingFrenzy(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var originalAttackType1 = caster.AttackAttackType1;
    var originalAttackType2 = caster.AttackAttackType2;
    caster.AttackAttackType1 = AttackType.Pierce;
    caster.AttackAttackType2 = AttackType.Pierce;

    var restoreTimer = timer.Create();
    restoreTimer.Start(Duration, false, () =>
    {
      caster.AttackAttackType1 = originalAttackType1;
      caster.AttackAttackType2 = originalAttackType2;
      restoreTimer.Dispose();
    });
  }
}
