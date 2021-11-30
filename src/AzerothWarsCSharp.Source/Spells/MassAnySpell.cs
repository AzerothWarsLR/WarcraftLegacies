using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Spells
{
  public class MassAnySpell : Spell
  {
    public int DummyAbilityId { get; init; }
    public string DummyAbilityOrderString { get; init; }
    public float Radius { get; init; }
    public DummyCast.CastFilter CastFilter { get; init; }

    public MassAnySpell(int id) : base(id)
    {
    }

    public override void OnCast(unit caster)
    {
      DummyCast.CastOnUnitsInRadius(caster, DummyAbilityId, DummyAbilityOrderString, GetAbilityLevel(caster),
        GetUnitX(caster), GetUnitY(caster), Radius, CastFilter);
    }
  }
}