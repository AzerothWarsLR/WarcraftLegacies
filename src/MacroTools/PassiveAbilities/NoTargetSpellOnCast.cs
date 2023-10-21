using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using System.Collections.Generic;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// When the unit deals damage, it has a chance to cast a dummy spell without a target.
  /// </summary>
  public sealed class NoTargetSpellOnCast : PassiveAbility
  {
    /// <summary>
    /// The unit type ID which has this <see cref="PassiveAbility"/> should also have an ability with this ID.
    /// </summary>
    public int _AbilityTypeId { get; }
    
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
    /// Initializes a new instance of the <see cref="NoTargetSpellOnAttack"/> class.
    /// </summary>
    /// <param name="unitTypeId"><inheritdoc /></param>
    /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
    public NoTargetSpellOnCast(int unitTypeId, int abilityTypeId) : base(unitTypeId)
    {
      _AbilityTypeId = abilityTypeId;
    }

    public List<int> AbilityWhitelist { get; init; } = new();

    /// <inheritdoc />
    public override void OnSpellEffect()
    {
      var caster = GetTriggerUnit();
      var abilityLevel = GetUnitAbilityLevel(caster, _AbilityTypeId);
      if (abilityLevel == 0 || !AbilityWhitelist.Contains(GetSpellAbilityId()))
        return;
      if (GetRandomReal(0, 1) < ProcChance)
      {
        DoSpellNoTarget(caster);
      }
    }

    private void DoSpellNoTarget(unit caster) => DummyCast.DummyCastNoTarget(caster, DummyAbilityId,
      DummyOrderId, GetUnitAbilityLevel(caster, _AbilityTypeId));
  }
}