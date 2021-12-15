using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public class MassAnySpell : Spell
  {
    public int DummyAbilityId { get; init; }
    public string DummyAbilityOrderString { get; init; }
    public float Radius { get; init; }
    public DummyCast.CastFilter CastFilter { get; init; }
    public SpellTargetType TargetType { get; init; } = SpellTargetType.None;

    public MassAnySpell(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, widget target, float targetX, float targetY)
    {
      var x = targetX;
      var y = targetY;
      if (TargetType == SpellTargetType.None)
      {
        x = GetUnitX(caster);
        y = GetUnitY(caster);
      }
      DummyCast.CastOnUnitsInRadius(caster, DummyAbilityId, DummyAbilityOrderString, GetAbilityLevel(caster),
        x, y, Radius, CastFilter);
    }
  }
}