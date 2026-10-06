using MacroTools.Channels;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Factions.Dalaran.Spells.ArcaneCataclysm;

public sealed class ArcaneCataclysmChannel : Channel
{
  private const string BallModel = @"war3mapImported\BlueBall.mdx";
  private const float MinScale = 0.6f;
  private const float MaxScale = 3.5f;

  public float GrowDuration { get; init; }

  public float TargetX { get; init; }

  public float TargetY { get; init; }

  public float Damage { get; init; }

  public float Radius { get; init; }

  public float MissileSpeed { get; init; }

  private effect? _orbEffect;
  private float _elapsed;
  private float _scale = MinScale;

  public ArcaneCataclysmChannel(unit caster, int spellId) : base(caster, spellId)
  {
  }

  public override void OnCreate()
  {
    Duration = GrowDuration;

    _orbEffect = effect.Create(BallModel, Caster, "overhead");
    _orbEffect.Scale = MinScale;
  }

  protected override void OnPeriodic()
  {
    _elapsed += Interval;
    var progress = _elapsed / GrowDuration;
    if (progress > 1f)
    {
      progress = 1f;
    }

    _scale = MinScale + (MaxScale - MinScale) * progress;
    if (_orbEffect != null)
    {
      _orbEffect.Scale = _scale;
    }
  }

  protected override void OnDispose()
  {
    _orbEffect?.Dispose();
    _orbEffect = null;

    Caster.IssueOrder(ORDER_STOP);

    var progress = _elapsed / GrowDuration;
    if (progress > 1f)
    {
      progress = 1f;
    }

    var missile = new ArcaneCataclysmMissile(Caster, TargetX, TargetY)
    {
      EffectString = BallModel,
      EffectScale = _scale,
      Speed = MissileSpeed,
      CollisionRadius = 0,
      Damage = Damage * progress,
      Radius = Radius
    };
    MissileSystem.Add(missile);
  }
}
