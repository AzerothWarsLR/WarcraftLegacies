using MacroTools.DummyCasters;
using MacroTools.PassiveAbilitySystem;


namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// When the unit deals damage, it has a chance to cast a dummy spell against that target.
  /// </summary>
  public sealed class SpellOnAttack : PassiveAbility, IAppliesEffectOnDamage
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
    /// The percentage chance that the effect will occur on attack.
    /// </summary>
    public float ProcChance { get; init; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="SpellOnAttack"/> class.
    /// </summary>
    /// <param name="unitTypeId"><inheritdoc /></param>
    /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
    public SpellOnAttack(int unitTypeId, int abilityTypeId) : base(unitTypeId)
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
      if (GetRandomReal(0, 1) < ProcChance)
      {
        DoSpellOnTarget(caster, target);
      }
    }
    
    private void DoSpellOnTarget(unit caster, unit target) => DummyCasterManager.GetGlobalDummyCaster().CastUnit(caster, DummyAbilityId,
      DummyOrderId, GetUnitAbilityLevel(caster, AbilityTypeId), target, DummyCastOriginType.Caster);
  }
}