using System.Linq;
using MacroTools.ChannelSystem;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.ExactJustice
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
      _ringEffect = AddSpecialEffect(EffectSettings.RingPath, x, y);
      BlzSetSpecialEffectAlpha(_ringEffect, 0);
      BlzSetSpecialEffectTimeScale(_ringEffect, 0);
      BlzSetSpecialEffectColor(_ringEffect, 235, 235, 50);
      BlzSetSpecialEffectScale(_ringEffect, EffectSettings.RingScale);

      _sparkleEffect = AddSpecialEffect(EffectSettings.SparklePath, x, y);
      BlzSetSpecialEffectScale(_sparkleEffect, EffectSettings.SparkleScale);
      BlzSetSpecialEffectColor(_sparkleEffect, 255, 255, 0);

      _progressEffect = AddSpecialEffect(EffectSettings.ProgressBarPath, x, y);
      BlzSetSpecialEffectTimeScale(_progressEffect, 1 / Duration);
      BlzSetSpecialEffectColorByPlayer(_progressEffect, Player(4));
      BlzSetSpecialEffectScale(_progressEffect, EffectSettings.ProgressBarScale);
      BlzSetSpecialEffectHeight(_progressEffect, EffectSettings.ProgressBarHeight);

      _aura = new ExactJusticeAura(Caster)
      {
        Radius = Radius,
        Active = true,
        Duration = 1.1f,
        SearchInterval = 1
      };
      AuraSystem.Add(_aura);
    }

    /// <inheritdoc />
    protected override void OnPeriodic()
    {
      if (_damage < MaximumDamage) 
        _damage += MaximumDamage / (_maximumDuration / Interval);
      if (!(_ringAlpha < EffectSettings.AlphaRing))
        return;

      _ringAlpha += EffectSettings.AlphaRing / (_maximumDuration / Interval);
      if (_ringEffect != null) 
        BlzSetSpecialEffectAlpha(_ringEffect, R2I(_ringAlpha));
    }

    /// <inheritdoc />
    protected override void OnDispose()
    {
      var explodeEffect = AddSpecialEffect(EffectSettings.ExplodePath, GetUnitX(Caster), GetUnitY(Caster));
      BlzSetSpecialEffectScale(explodeEffect, EffectSettings.ExplodeScale);
      EffectSystem.Add(explodeEffect);
      foreach (var unit in GlobalGroup.EnumUnitsInRange(Caster.GetPosition(), Radius)
                 .Where(target => CastFilters.IsTargetEnemyAndAlive(Caster, target)))
      {
        unit.TakeDamage(Caster, _damage, false, false, damageType: DAMAGE_TYPE_MAGIC);
      }
      
      //The below effects have no death animations so they have//to be moved off the map as they are destroyed.
      var dummyRemovalPoint = new Point(-100000, -100000);
      if (_sparkleEffect != null) 
        BlzSetSpecialEffectPosition(_sparkleEffect, dummyRemovalPoint.X, dummyRemovalPoint.Y, 0);

      if (_sparkleEffect != null) 
        DestroyEffect(_sparkleEffect);

      if (_progressEffect != null) 
        BlzSetSpecialEffectPosition(_progressEffect, dummyRemovalPoint.X, dummyRemovalPoint.Y, 0);

      if (_progressEffect != null) 
        DestroyEffect(_progressEffect);

      if (_ringEffect != null) 
        BlzSetSpecialEffectTimeScale(_ringEffect, 1);

      if (_ringEffect != null) 
        DestroyEffect(_ringEffect);

      if (_aura != null) 
        _aura.Active = false;
    }
  }
}