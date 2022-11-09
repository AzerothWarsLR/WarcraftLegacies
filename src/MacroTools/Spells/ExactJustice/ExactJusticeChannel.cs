using System.Linq;
using MacroTools.ChannelSystem;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using MacroTools.Wrappers;
using WCSharp.Buffs;
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

    /// <summary>
    /// Settings for the visual effects created by the channel effect.
    /// </summary>
    public ExactJusticeEffectSettings EffectSettings { get; init; } = new();
    
    /// <summary>
    /// The maximum amount of damage that will be dealt at the end of the channel.
    /// If the channel ends early, less damage is dealt.
    /// </summary>
    public float MaximumDamage { get; init; }
    
    /// <summary>
    /// The radius in which units are affected.
    /// </summary>
    public float Radius { get; init; }

    private float _damage;
    private float _maximumDuration;
    private float _ringAlpha;
    private effect? _ringEffect;
    private effect? _sparkleEffect;
    private effect? _progressEffect;
    private ExactJusticeAura? _aura;

    /// <inheritdoc />
    public override void OnCreate()
    {
      var x = GetUnitX(Caster);
      var y = GetUnitY(Caster);
      
      _maximumDuration = Duration;
      _ringEffect = AddSpecialEffect(EffectSettings.RingPath, x, y)
        .SetTimeScale(0)
        .SetColor(235, 235, 50)
        .SetScale(EffectSettings.RingScale);

      _sparkleEffect = AddSpecialEffect(EffectSettings.SparklePath, x, y)
        .SetScale(EffectSettings.SparkleScale)
        .SetColor(255, 255, 0);

      _progressEffect = AddSpecialEffect(EffectSettings.ProgressBarPath, x, y)
        .SetTimeScale(1 / Duration)
        .SetColor(Player(4))
        .SetScale(EffectSettings.ProgressBarScale)
        .SetHeight(EffectSettings.ProgressBarHeight);

      _aura = new ExactJusticeAura(Caster)
      {
        Radius = Radius,
        Duration = float.MaxValue,
      };
      AuraSystem.Add(_aura);
    }

    /// <inheritdoc />
    protected override void OnPeriodic()
    {
      _damage += MaximumDamage / (_maximumDuration * Interval);
      if (!(_ringAlpha < EffectSettings.AlphaRing))
        return;
      _ringAlpha += EffectSettings.AlphaRing / (EffectSettings.AlphaFade * Interval);
      _ringEffect?.SetAlpha(R2I(_ringAlpha));
    }

    /// <inheritdoc />
    protected override void OnDispose()
    {
      AddSpecialEffect(EffectSettings.ExplodePath, GetUnitX(Caster), GetUnitY(Caster))
        .SetScale(EffectSettings.ExplodeScale)
        .SetLifespan();
      foreach (var unit in new GroupWrapper().EnumUnitsInRange(Caster.GetPosition(), Radius)
                 .EmptyToList()
                 .Where(target => CastFilters.IsTargetEnemyAndAlive(Caster, target)))
      {
        unit.TakeDamage(Caster, _damage, false, false, damageType: DAMAGE_TYPE_MAGIC);
      }
      _ringEffect?.Destroy();
      _sparkleEffect?.Destroy();
      _progressEffect?.Destroy();
      if (_aura != null) 
        _aura.Active = false;
    }
  }
}