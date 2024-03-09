using MacroTools.Extensions;
using WCSharp.Effects;
using WCSharp.Missiles;


namespace WarcraftLegacies.Source.ArtifactBehaviour
{
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
      _eyeOfSargeras = SetItemPosition(eyeOfSargeras, 20229f, 24244);
      CollisionRadius = 100;
      Active = true;
      CasterLaunchZ = 50;
      TargetImpactZ = 50;
    }

    /// <inheritdoc />
    public override void OnImpact()
    {
      if (!UnitAlive(Target)) 
        return;
      
      Target
        .AddAbility(Constants.ABILITY_A01Y_INVENTORY_DUMMY_DROP_ARTIFACT)
        .AddItemSafe(_eyeOfSargeras);
      _impacted = true;

      var impactEffect = AddSpecialEffect(ImpactEffectPath, GetUnitX(Target), GetUnitY(Target));
      impactEffect.SetTimeScale(2);
      EffectSystem.Add(impactEffect, 1);
      
      var eyeEffect = AddSpecialEffectTarget(@"Doodads\Cinematic\EyeOfSargeras\EyeOfSargeras.mdl", Target, "overhead");
      CreateTrigger()
        .RegisterUnitEvent(Target, EVENT_UNIT_DEATH)
        .AddAction(() =>
        {
          eyeEffect.Dispose();
          DestroyTrigger(GetTriggeringTrigger());
        });
    }

    /// <inheritdoc />
    public override void OnDispose()
    {
      if (_impacted) 
        return;
      
      SetItemPosition(_eyeOfSargeras, MissileX, MissileY);
      var missileExplosionEffect = AddSpecialEffect(ImpactEffectPath, MissileX, MissileY);
      missileExplosionEffect.SetTimeScale(2);
      EffectSystem.Add(missileExplosionEffect, 1);
    }
  }
}