using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using MacroTools.Utils;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Spells;

/// <summary>Whenever the unit casts a spell, shadow bolts strike nearby enemies.</summary>
public sealed class SoulEcho : UnitTrait, IEffectOnSpellEffect
{
  public required int AbilityTypeId { get; init; }
  public required int TargetCount { get; init; }
  public required float Radius { get; init; }
  public required LeveledAbilityField<float> Damage { get; init; }
  public required string MissilePath { get; init; }
  public required string ImpactEffectPath { get; init; }

  /// <inheritdoc />
  public void OnSpellEffect()
  {
    var caster = @event.Unit;
    var level = caster.GetAbilityLevel(AbilityTypeId);
    if (level == 0)
    {
      return;
    }

    var damage = Damage.GetValue(level);
    var boltsLeft = TargetCount;
    foreach (var unit in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (boltsLeft == 0)
      {
        break;
      }

      if (!CastFilters.IsTargetEnemyAndAliveUnits(caster, unit) || unit.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      boltsLeft--;
      MissileSystem.Add(new SoulEchoMissile(caster, unit, damage, ImpactEffectPath)
      {
        EffectString = MissilePath
      });
    }
  }
}

/// <summary>A shadow bolt fired by <see cref="SoulEcho"/>.</summary>
public sealed class SoulEchoMissile : HomingMissile
{
  private readonly unit _caster;
  private readonly unit _victim;
  private readonly float _damage;
  private readonly string _impactEffectPath;

  public SoulEchoMissile(unit caster, unit target, float damage, string impactEffectPath) :
    base(caster.Owner, caster.X, caster.Y, target)
  {
    _caster = caster;
    _victim = target;
    _damage = damage;
    _impactEffectPath = impactEffectPath;
    Speed = 900;
    CasterLaunchZ = 60;
    TargetImpactZ = 50;
    Active = true;
  }

  public override void OnImpact()
  {
    if (!CastFilters.IsTargetEnemyAndAliveUnits(_caster, _victim))
    {
      return;
    }

    effect.Create(_impactEffectPath, _victim, "chest").Dispose();
    _caster.DealDamage(_victim, _damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
  }
}
