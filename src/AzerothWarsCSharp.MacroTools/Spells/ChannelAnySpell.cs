using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public class ChannelAnySpell : Spell
  {
    public int DummyAbilityId { get; init; }
    public string DummyAbilityOrderString { get; init; }
    public int Duration { get; init; }

    public ChannelAnySpell(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      DummyCast.ChannelOnPoint(caster, DummyAbilityId, DummyAbilityOrderString, GetAbilityLevel(caster), targetPoint, Duration);
    }
  }
}