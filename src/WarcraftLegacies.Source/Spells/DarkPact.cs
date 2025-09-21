using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Kills a target unit and gives its hitpoints to the caster.
/// </summary>
public sealed class DarkPact : Spell
{
  public DarkPact(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    caster.Life = caster.Life + target.Life;
    target.Kill();
  }
}
