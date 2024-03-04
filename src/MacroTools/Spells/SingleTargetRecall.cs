using MacroTools.SpellSystem;
using WCSharp.Shared.Data;


namespace MacroTools.Spells
{
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
      SetUnitPosition(target, GetUnitX(caster), GetUnitY(caster));
    }
  }
}