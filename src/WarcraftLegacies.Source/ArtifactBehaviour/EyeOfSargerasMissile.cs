using MacroTools.Extensions;
using WCSharp.Effects;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.ArtifactBehaviour;

/// <summary>
/// Carries the Eye of Sargeras into the target's inventory.
/// </summary>
public sealed class EyeOfSargerasMissile : BasicMissile
{
  private readonly item _eyeOfSargeras;
  private bool _impacted;
  private const string ImpactEffectPath = @"Abilities\Spells\Undead\DarkRitual\DarkRitualTarget.mdl";

  /// <summary>
  /// Initializes a new instance of the <see cref="EyeOfSargerasMissile"/> class.
  /// </summary>
  public EyeOfSargerasMissile(unit caster, unit target, item eyeOfSargeras) : base(caster, target)
  {
    EffectString = @"Abilities\Spells\Undead\OrbOfDeath\AnnihilationMissile.mdl";
    EffectScale = 1.5f;
    Arc = 0.3f;
    Speed = 700;
    _eyeOfSargeras = eyeOfSargeras;
    _eyeOfSargeras.SetPosition(20229f, 24244);
    CollisionRadius = 100;
    Active = true;
    CasterLaunchZ = 50;
    TargetImpactZ = 50;
  }

  /// <inheritdoc />
  public override void OnImpact()
  {
    if (!Target.Alive)
    {
      return;
    }

    Target.AddAbility(ABILITY_A01Y_INVENTORY_DUMMY_DROP_ARTIFACT);
    Target.AddItemSafe(_eyeOfSargeras);
    _impacted = true;

    var impactEffect = effect.Create(ImpactEffectPath, Target.X, Target.Y);
    impactEffect.Scale = 2;
    EffectSystem.Add(impactEffect, 1);

    var eyeEffect = effect.Create(@"Doodads\Cinematic\EyeOfSargeras\EyeOfSargeras.mdl", Target, "overhead");
    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(Target, unitevent.Death);
    deathTrigger.AddAction(() =>
    {
      eyeEffect.Dispose();
      @event.Trigger.Dispose();
    });
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    if (_impacted)
    {
      return;
    }

    _eyeOfSargeras.SetPosition(MissileX, MissileY);
    var impactEffect = effect.Create(ImpactEffectPath, MissileX, MissileY);
    impactEffect.Scale = 2;
    EffectSystem.Add(impactEffect, 1);
  }
}
