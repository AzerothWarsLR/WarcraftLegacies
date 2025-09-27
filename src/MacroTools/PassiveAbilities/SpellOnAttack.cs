using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.PassiveAbilitySystem;
using static MacroTools.Libraries.UnitEventSystem;

namespace MacroTools.PassiveAbilities;

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
  /// The cooldown in seconds for the effect.
  /// </summary>
  public float Cooldown { get; init; } = 0f;

  /// <summary>
  /// The player must have this research for the ability to take effect.
  /// </summary>
  public int RequiredResearch { get; init; }

  // Tracks cooldown timers for each target
  private readonly Dictionary<unit, timer> _targetCooldowns = new();

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
    // Ensure this is a normal attack
    if (!@event.IsAttack)
    {
      return;
    }

    var caster = @event.DamageSource;
    var target = @event.Unit;

    // Check research requirement
    if (RequiredResearch != 0 &&
        caster.Owner.GetTechResearched(RequiredResearch, false) == 0)
    {
      return;
    }

    // Check if target is on cooldown
    if (Cooldown > 0 && _targetCooldowns.ContainsKey(target))
    {
      return;
    }

    // Random chance check
    if (GetRandomReal(0, 1) >= ProcChance)
    {
      return;
    }

    // Trigger the effect
    DoSpellOnTarget(caster, target);

    // Start cooldown timer
    if (Cooldown > 0)
    {
      StartCooldownTimer(target);
    }
  }

  private void StartCooldownTimer(unit target)
  {
    timer timer = timer.Create();
    _targetCooldowns[target] = timer;

    // Set timer expiration action
    timer.Start(Cooldown, false, () =>
    {
      _targetCooldowns.Remove(target);
      timer.Dispose();
    });

    // Register unit death event to clean up timer when unit dies
    RegisterDeathEvent(target, () =>
    {
      if (_targetCooldowns.TryGetValue(target, out var activeTimer))
      {
        activeTimer.Pause();
        activeTimer.Dispose();
        _targetCooldowns.Remove(target);
      }
    });
  }

  private void DoSpellOnTarget(unit caster, unit target) =>
      DummyCasterManager.GetGlobalDummyCaster().CastUnit(
          caster, DummyAbilityId, DummyOrderId,
          caster.GetAbilityLevel(AbilityTypeId),
          target, DummyCastOriginType.Caster);
}
