using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// When cast, the caster becomes vulnerable.
/// </summary>
public sealed class MakeCasterVulnerable : Spell
{
  /// <inheritdoc />
  public MakeCasterVulnerable(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnStartCast(unit caster, unit target, Point targetPoint)
  {
    SetUnitInvulnerable(caster, false);
  }
}
