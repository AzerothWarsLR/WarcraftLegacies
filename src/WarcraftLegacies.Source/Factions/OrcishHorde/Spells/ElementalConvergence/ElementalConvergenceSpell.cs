using MacroTools.Channels;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Spells.ElementalConvergence;

/// <summary>
/// Thrall channels earth, wind, and fire above himself. If left uninterrupted, the three elements converge
/// into one and streak toward the target point, exploding to damage and stun everything caught in the blast.
/// </summary>
public sealed class ElementalConvergenceSpell : Spell
{
  public float ChannelDuration { get; init; } = 3f;

  /// <summary>Indexed by ability level (index 0 = level 1).</summary>
  public required float[] DamageByLevel { get; init; }

  public float Radius { get; init; }

  public float MissileSpeed { get; init; }

  /// <summary>Ability used by the dummy caster to apply the stun.</summary>
  public required int StunAbilityId { get; init; }

  public ElementalConvergenceSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var channel = new ElementalConvergenceChannel(caster, Id)
    {
      Interval = 0.03f,
      GrowDuration = ChannelDuration,
      TargetX = targetPoint.X,
      TargetY = targetPoint.Y,
      Damage = DamageByLevel[level - 1],
      Radius = Radius,
      MissileSpeed = MissileSpeed,
      StunAbilityId = StunAbilityId,
      Level = level
    };
    ChannelManager.Add(channel);
  }
}
