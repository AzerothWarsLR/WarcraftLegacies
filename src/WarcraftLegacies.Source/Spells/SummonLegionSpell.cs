using MacroTools.Channels;
using MacroTools.ChannelSystem;
using MacroTools.Extensions;
using MacroTools.Instances;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  public sealed class SummonLegionSpell : Spell
  {
    private readonly int _spellImmunityId;

    public float Duration { get; set; } = 180;

    /// <inheritdoc />
    public override void OnStartCast(unit caster, unit target, Point targetPoint)
    {
      if (InstanceSystem.GetPointInstance(caster.GetPosition()) == null)
        return;

      TimerStart(CreateTimer(), 1f, false, () =>
      {
        caster.IssueOrder("stop");
        DestroyTimer(GetExpiredTimer());
      });
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var channel = new SummonLegionChannel(caster, Id, _spellImmunityId)
      {
        Duration = Duration
      };
      ChannelManager.Add(channel);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SummonLegionSpell"/> class.
    /// </summary>
    /// <param name="id"><inheritdoc /></param>
    /// <param name="spellImmunityId">An ability ID that grants the caster Spell Immunity.</param>
    public SummonLegionSpell(int id, int spellImmunityId) : base(id)
    {
      _spellImmunityId = spellImmunityId;
    }
  }
}