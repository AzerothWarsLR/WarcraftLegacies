using System.Linq;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Factions.Dalaran.Spells.ManaBomb;

public sealed class ManaBombMissile : BasicMissile
{
  public float Damage { get; init; }

  public float Radius { get; init; }

  private bool _animated;

  public ManaBombMissile(unit caster, float targetX, float targetY) : base(caster, targetX, targetY)
  {
  }

  public override void OnPeriodic()
  {
    if (!_animated && Effect != null)
    {
      Effect.PlayAnimation(animtype.Stand);
      _animated = true;
    }
  }

  public override void OnImpact()
  {
    var x = MissileX;
    var y = MissileY;

    var explosionEffect = effect.Create(@"Abilities\Spells\Human\ManaFlare\ManaFlareTarget.mdl", x, y);
    EffectSystem.Add(explosionEffect);

    foreach (var target in GlobalGroup.EnumUnitsInRange(x, y, Radius)
               .Where(u => CastFilters.IsTargetEnemyAndAlive(Caster, u)))
    {
      Caster.DealDamage(target, Damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    }
  }
}
