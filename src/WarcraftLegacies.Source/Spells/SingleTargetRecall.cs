using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Teleports the target to the caster.
/// </summary>
public sealed class SingleTargetRecall : Spell
{
  public SingleTargetRecall(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    target.SetPosition(caster.X, caster.Y);
  }
}
