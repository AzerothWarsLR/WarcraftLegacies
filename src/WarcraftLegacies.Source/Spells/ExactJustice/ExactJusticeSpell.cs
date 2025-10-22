using MacroTools.ChannelSystem;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.ExactJustice;

/// <summary>
/// Start a <see cref="Channel"/> which renders friendly units invulnerable for a while, then deals damage at the end.
/// </summary>
public sealed class ExactJusticeSpell : Spell
{
  /// <summary>
  /// The maximum amount of damage dealt at the end of the spell.
  /// </summary>
  public float DamageBase { get; init; }

  /// <summary>
  /// Multiplied by the user's ability level and added to <see cref="DamageBase"/>.
  /// </summary>
  public float DamageLevel { get; init; }

  /// <summary>
  /// The area in which surrounding units are affected.
  /// </summary>
  public float Radius { get; init; }

  /// <summary>
  /// Settings for the visual effects created by the spell.
  /// </summary>
  public ExactJusticeEffectSettings EffectSettings { get; init; } = new();

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var channel = new ExactJusticeChannel(caster, Id)
    {
      EffectSettings = EffectSettings,
      Interval = 0.25f,
      Radius = Radius,
      MaximumDamage = DamageBase + DamageLevel * GetAbilityLevel(caster)
    };
    ChannelManager.Add(channel);
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="ExactJusticeSpell"/> class.
  /// </summary>
  /// <param name="id"><inheritdoc/></param>
  public ExactJusticeSpell(int id) : base(id)
  {
  }
}
