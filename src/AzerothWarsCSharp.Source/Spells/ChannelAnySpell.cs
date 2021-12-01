using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Spells
{
  public class ChannelAnySpell : Spell
  {
    public int DummyAbilityId { get; init; }
    public string DummyAbilityOrderString { get; init; }
    public int Duration { get; init; }

    public ChannelAnySpell(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, widget target, float targetX, float targetY)
    {
      DummyCast.ChannelOnPoint(caster, DummyAbilityId, DummyAbilityOrderString, GetAbilityLevel(caster), targetX, targetY, Duration);
    }
  }
}