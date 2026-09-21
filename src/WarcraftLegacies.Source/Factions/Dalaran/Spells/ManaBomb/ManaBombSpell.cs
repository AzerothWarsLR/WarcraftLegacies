using MacroTools.Channels;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Dalaran.Spells.ManaBomb;

/// <summary>
/// Antonidas gathers a ball of raw arcane energy above his own head. If left uninterrupted, it grows to full
/// size and launches at the target point for full damage. If he's interrupted before then, the ball launches
/// anyway, just at whatever size it had reached, dealing reduced damage in proportion.
/// </summary>
public sealed class ManaBombSpell : Spell
{
  public float GrowDuration { get; init; } = 3f;

  /// <summary>Indexed by ability level (index 0 = level 1).</summary>
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
