using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Spells;

public sealed class SpeedBurst : Spell
{
  public required float SpeedBonus { get; init; }

  public required float Duration { get; init; }

  public SpeedBurst(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    SetUnitMoveSpeed(caster, GetUnitDefaultMoveSpeed(caster) * (1 + SpeedBonus));
    var restoreTimer = timer.Create();
    restoreTimer.Start(Duration, false, () =>
    {
      SetUnitMoveSpeed(caster, GetUnitDefaultMoveSpeed(caster));
      restoreTimer.Dispose();
    });
  }
}
