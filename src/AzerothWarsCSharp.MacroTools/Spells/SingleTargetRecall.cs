using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  /// <summary>
  /// Teleports the target to the caster.
  /// </summary>
  public sealed class SingleTargetRecall : Spell
  {
    public SingleTargetRecall(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, float targetX, float targetY)
    {
      SetUnitPosition(target, GetUnitX(caster), GetUnitY(caster));
    }
  }
}