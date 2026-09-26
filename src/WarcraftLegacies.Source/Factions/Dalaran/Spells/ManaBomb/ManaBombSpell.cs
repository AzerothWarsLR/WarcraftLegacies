using MacroTools.Channels;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Dalaran.Spells.ManaBomb;

public sealed class ManaBombSpell : Spell
{
  public float GrowDuration { get; init; } = 3f;

  public required float[] DamageByLevel { get; init; }

  public float Radius { get; init; }

  public float MissileSpeed { get; init; }

  public ManaBombSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var channel = new ManaBombChannel(caster, Id)
    {
      Interval = 0.03f,
      GrowDuration = GrowDuration,
      TargetX = targetPoint.X,
      TargetY = targetPoint.Y,
      Damage = DamageByLevel[level - 1],
      Radius = Radius,
      MissileSpeed = MissileSpeed
    };
    ChannelManager.Add(channel);
  }
}
