using AzerothWarsCSharp.MacroTools.Channels;
using AzerothWarsCSharp.MacroTools.ChannelSystem;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public sealed class SummonLegionSpell : Spell
  {
    private readonly int _spellImmunityId;

    public float Duration { get; set; } = 180;

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var channel = new SummonLegionChannel(caster, Id, _spellImmunityId)
      {
        Duration = Duration
      };
      ChannelManager.Add(channel);
    }

    public SummonLegionSpell(int id, int spellImmunityId) : base(id)
    {
      _spellImmunityId = spellImmunityId;
    }
  }
}