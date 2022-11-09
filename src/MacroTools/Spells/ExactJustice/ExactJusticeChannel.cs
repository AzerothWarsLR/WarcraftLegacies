using MacroTools.ChannelSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Spells.ExactJustice
{
  /// <summary>
  /// Provides the channeling effect for <see cref="ExactJusticeSpell"/>.
  /// </summary>
  public sealed class ExactJusticeChannel : Channel
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ExactJusticeChannel"/> class.
    /// </summary>
    /// <param name="caster"><inheritdoc /></param>
    /// <param name="spellId"><inheritdoc /></param>
    public ExactJusticeChannel(unit caster, int spellId) : base(caster, spellId)
    {
    }

    /// <inheritdoc />
    public override bool Active { get; set; } = true;
    
    /// <inheritdoc />
    protected override void OnDispose()
    {
      AddSpecialEffect(EffectSettings.ExplodePath, GetUnitX(Caster), GetUnitY(Caster))
        .SetScale(EffectSettings.ExplodeScale)
        .SetLifespan();
      
    }
    
    /// <summary>
    /// Settings for the visual effects created by the channel effect.
    /// </summary>
    public ExactJusticeEffectSettings EffectSettings { get; init; } = new();
  }
}