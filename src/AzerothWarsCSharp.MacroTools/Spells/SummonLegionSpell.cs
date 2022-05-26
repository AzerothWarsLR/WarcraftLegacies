using AzerothWarsCSharp.MacroTools.Channels;
using AzerothWarsCSharp.MacroTools.ChannelSystem;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public sealed class SummonLegionSpell : Spell
  {
    private readonly int _spellImmunityId;

    public override void OnCast(unit caster, unit target, float targetX, float targetY)
    {
      var channel = new SummonLegionChannel(caster, Id, _spellImmunityId);
      ChannelManager.Add(channel);
    }

    public SummonLegionSpell(int id, int spellImmunityId) : base(id)
    {
      _spellImmunityId = spellImmunityId;
    }
  }
}