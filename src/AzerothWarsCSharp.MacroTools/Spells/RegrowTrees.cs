using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public sealed class RegrowTrees : Spell
  {
    public RegrowTrees(int id) : base(id)
    {
    }

    public float Radius { get; init; }

    public override void OnCast(unit caster, unit target, float targetX, float targetY)
    {
      GeneralHelpers.EnumDestructablesInCircle(Radius, new Point(GetUnitX(caster), GetUnitY(caster)),
        () => { DestructableRestoreLife(GetEnumDestructable(), GetDestructableMaxLife(GetEnumDestructable()), true); });
    }
  }
}