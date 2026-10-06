using MacroTools.Channels;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Druids.Spells.LivingWall;

public sealed class LivingWallSpell : Spell
{
  public float ChannelDuration { get; init; } = 20f;

  public required int TreeUnitTypeId { get; init; }

  public LivingWallSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var channel = new LivingWallChannel(caster, Id)
    {
      Interval = 0.03f,
      ChannelDuration = ChannelDuration,
      TargetX = targetPoint.X,
      TargetY = targetPoint.Y,
      TreeUnitTypeId = TreeUnitTypeId
    };
    ChannelManager.Add(channel);
  }
}
