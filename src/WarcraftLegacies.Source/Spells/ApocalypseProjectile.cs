using MacroTools.Extensions;
using WCSharp.Missiles;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Spells
{
  public sealed class ApocalypseProjectile : BasicMissile
  {
    public float Damage { get; init; }

    public string EffectOnHitModel { get; init; } = "";
    
    public float EffectOnHitScale { get; init; }
    
    public int DummyAbilityId { get; init; }
    
    public int DummyAblilityOrderId { get; init; }

    /// <inheritdoc />
    public ApocalypseProjectile(player castingPlayer, float casterX, float casterY, float targetX, float targetY) :
      base(castingPlayer, casterX, casterY, targetX, targetY)
    {
    }

    /// <inheritdoc />
    public override void OnCollision(unit unit)
    {
      unit.TakeDamage(Caster, Damage, false, false, damageType: DAMAGE_TYPE_NORMAL);
    }
  }
}