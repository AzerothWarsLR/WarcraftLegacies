using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Shared.Spells;

public sealed class CooldownReset : Spell
{
  public CooldownReset(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    caster.ResetCooldowns();
  }
}
