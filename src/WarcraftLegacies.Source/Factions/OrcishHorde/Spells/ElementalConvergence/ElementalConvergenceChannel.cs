using MacroTools.Channels;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Spells.ElementalConvergence;

/// <summary>
/// Handles the channel phase of <see cref="ElementalConvergenceSpell"/>: growing the three elemental orbs above
/// the caster, then either launching them at the target point (success) or dispersing them (interrupted).
/// </summary>
public sealed class ElementalConvergenceChannel : Channel
{
  private const string EarthModel = @"war3mapImported\Yellow Ball.mdl";
  private const string WindModel = @"war3mapImported\Blue Ball.mdl";
  private const string FireModel = @"war3mapImported\Red Ball.mdl";
  private const float OrbHeight = 250f;
  private const float OrbRadius = 130f;
  private const float OrbPeriod = 5f;
  private const float MinScale = 0.55f;
  private const float OrbMaxScale = 1.7f;
  private const float MissileScale = 2.2f;

  public float GrowDuration { get; init; }

  public float TargetX { get; init; }

  public float TargetY { get; init; }

  public float Damage { get; init; }

  public float Radius { get; init; }

  public float MissileSpeed { get; init; }

  public int StunAbilityId { get; init; }

  public int Level { get; init; }

  private ElementalConvergenceOrb? _earthOrb;
  private ElementalConvergenceOrb? _windOrb;
  private ElementalConvergenceOrb? _fireOrb;
  private float _elapsed;

  public ElementalConvergenceChannel(unit caster, int spellId) : base(caster, spellId)
  {
  }

  public override void OnCreate()
  {
    Duration = GrowDuration;

    _earthOrb = CreateOrb(EarthModel, 0f, 255, 210, 40);
    _windOrb = CreateOrb(WindModel, 120f, 60, 140, 255);
    _fireOrb = CreateOrb(FireModel, 240f, 255, 50, 50);
  }

  protected override void OnPeriodic()
  {
    _elapsed += Interval;
    var progress = _elapsed / GrowDuration;
    if (progress > 1f)
    {
      progress = 1f;
    }

    var scale = MinScale + (OrbMaxScale - MinScale) * progress;
    SetOrbScale(_earthOrb, scale);
    SetOrbScale(_windOrb, scale);
    SetOrbScale(_fireOrb, scale);
  }

  protected override void OnDispose()
  {
    RemoveOrb(ref _earthOrb);
    RemoveOrb(ref _windOrb);
    RemoveOrb(ref _fireOrb);

    if (Duration > 0)
    {
      return;
    }

    var casterX = Caster.X;
    var casterY = Caster.Y;
    var impactState = new ElementalConvergenceImpactState();

    LaunchMissile(EarthModel, casterX, casterY, -70f, 255, 210, 40, impactState);
    LaunchMissile(WindModel, casterX, casterY, 70f, 60, 140, 255, impactState);
    LaunchMissile(FireModel, casterX, casterY, 0f, 255, 50, 50, impactState);
  }

  private ElementalConvergenceOrb CreateOrb(string model, float startingAngle, int red, int green, int blue)
  {
    var orb = new ElementalConvergenceOrb(Caster)
    {
      EffectString = model,
      EffectScale = MinScale,
      EffectRed = red,
      EffectGreen = green,
      EffectBlue = blue,
      Range = OrbRadius,
      OrbitalPeriod = OrbPeriod,
      OrbitalAngle = startingAngle,
      TargetImpactZ = OrbHeight
    };
    MissileSystem.Add(orb);
    return orb;
  }

  private static void SetOrbScale(ElementalConvergenceOrb? orb, float scale)
  {
    if (orb != null)
    {
      orb.EffectScale = scale;
    }
  }

  private static void RemoveOrb(ref ElementalConvergenceOrb? orb)
  {
    if (orb == null)
    {
      return;
    }

    orb.Active = false;
    orb = null;
  }

  private void LaunchMissile(string model, float casterX, float casterY, float lateralOffset, int red, int green,
    int blue, ElementalConvergenceImpactState impactState)
  {
    var missile = new ElementalConvergenceMissile(Caster, TargetX, TargetY, lateralOffset, impactState)
    {
      EffectString = model,
      EffectScale = MissileScale,
      EffectRed = red,
      EffectGreen = green,
      EffectBlue = blue,
      Speed = MissileSpeed,
      CollisionRadius = 0,
      Damage = Damage,
      Radius = Radius,
      StunAbilityId = StunAbilityId,
      Level = Level
    };
    MissileSystem.Add(missile);
  }
}
