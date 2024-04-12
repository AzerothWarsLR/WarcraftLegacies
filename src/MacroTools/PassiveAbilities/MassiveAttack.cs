using MacroTools.DummyCasters;
using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// When the unit deals damage, it casts Shockwave on the target.
  /// The Shockwave deals damage based on the caster's average attack damage.
  /// </summary>
  public sealed class MassiveAttack : PassiveAbility, IAppliesEffectOnDamage
  {
    /// <summary>
    /// The unit type ID which has this <see cref="PassiveAbility"/> should also have an ability with this ID.
    /// </summary>
    public int AbilityTypeId { get; }

    /// <summary>
    /// The dummy spell to cast on attack.
    /// </summary>
    public int DummyAbilityId { get; init; }

    /// <summary>
    /// An order ID that can be used to cast the specified dummy ability.
    /// </summary>
    public int DummyOrderId { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpellOnAttack"/> class.
    /// </summary>
    /// <param name="unitTypeId"><inheritdoc /></param>
    /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
    public MassiveAttack(int unitTypeId, int abilityTypeId) : base(unitTypeId)
    {
      AbilityTypeId = abilityTypeId;
    }

    /// <inheritdoc />
    public void OnDealsDamage()
    {
      if (!BlzGetEventIsAttack())
        return;

      var caster = GetEventDamageSource();
      var target = GetTriggerUnit();

      DoSpellOnTarget(caster, target);
    }

    private void DoSpellOnTarget(unit caster, unit target)
    {
      var damage = caster.GetAverageDamage(1);
      
      DummyCasterManager
        .GetGlobalDummyCaster()
        .CastUnit(caster,
          DummyAbilityId,
          DummyOrderId,
          1,
          target,
          DummyCastOriginType.Caster,
          PreCastFunc);
      return;

      void PreCastFunc(unit dummyCaster)
      {
        var ability = BlzGetUnitAbility(dummyCaster, AbilityTypeId);
        BlzSetAbilityRealLevelField(ability, ABILITY_RLF_DAMAGE_UCS1, 0, 100000);
        BlzSetAbilityRealLevelField(ability, ABILITY_RLF_DAMAGE_UCS1, 1, 100000);
      }
    }
  }
}