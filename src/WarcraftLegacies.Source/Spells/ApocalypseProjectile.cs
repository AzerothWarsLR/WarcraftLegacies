using MacroTools.DummyCasters;
using MacroTools.Extensions;
using WCSharp.Missiles;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Spells
{
  public sealed class ApocalypseProjectile : BasicMissile
  {
    private readonly GlobalDummyCaster _dummyCaster;
    
    public float Damage { get; init; }

    public string EffectOnHitModel { get; init; } = "";
    
    public float EffectOnHitScale { get; init; }
    
    public int DummyAbilityId { get; init; }
    
    public int DummyAbilityOrderId { get; init; }
    
    public int DummyAbilityLevel { get; init; }

    /// <inheritdoc />
    public ApocalypseProjectile(player castingPlayer, float casterX, float casterY, float targetX, float targetY) :
      base(castingPlayer, casterX, casterY, targetX, targetY)
    {
      _dummyCaster = DummyCasterManager.GetGlobalDummyCaster();
    }

    /// <inheritdoc />
    public override void OnCollision(unit unit)
    {
      unit.TakeDamage(Caster, Damage, false, false, damageType: DAMAGE_TYPE_NORMAL);
      
      _dummyCaster.CastUnit(Caster, DummyAbilityId, DummyAbilityOrderId, DummyAbilityLevel, unit,
        DummyCastOriginType.Target);
      
      AddSpecialEffect(EffectOnHitModel, GetUnitX(unit), GetUnitY(unit))
        .SetScale(EffectOnHitScale)
        .SetLifespan();
    }
  }
}