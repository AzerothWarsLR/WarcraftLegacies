using MacroTools.UnitTraits;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.UnitTypeTraits.DefensiveCocoon;

/// <summary>
/// When the ability holder takes lethal damage, they transform into a Spirit of Vengeance.
/// If they attack enough times while a Spirit, they revive with some health.
/// Otherwise, they die.
/// </summary>
public sealed class DefensiveCocoonTrait : UnitTrait, IEffectOnDamaged
{
  private readonly int _abilityTypeId;

  /// <summary>
  /// If set, this needs to be researched for the ability to work.
  /// </summary>
  public required int RequiredResearch { get; init; }

  /// <summary>
  /// The amount of health the cocoon has, as a percentage of the ability wielders maximum hit points.
  /// </summary>
  public required float MaximumHealthPercentage { private get; init; }

  /// <summary>
  /// How long the cocoon lasts.
  /// </summary>
  public required float Duration { private get; init; }

  /// <summary>
  /// A unit type ID with the model of the cocoon.
  /// </summary>
  public required int EggId { private get; init; }

  /// <summary>
  /// The visual effect that occurs.
  /// </summary>
  public required string ReviveEffect { private get; init; }

  /// <summary>
  /// Initializes a new instance of the <see cref="DefensiveCocoonTrait"/> class.
  /// </summary>
  /// <param name="abilityTypeId">The ability whose level is used to determine the magnitude of the effect.</param>
  public DefensiveCocoonTrait(int abilityTypeId)
  {
    _abilityTypeId = abilityTypeId;
  }

  /// <inheritdoc />
  public void OnDamaged()
  {
    var damaged = @event.Unit;
    var abilityLevel = damaged.GetAbilityLevel(_abilityTypeId);
    if (!ShouldBecomeEgg(abilityLevel, damaged))
    {
      return;
    }

    @event.Damage = 0;

    var vengeanceBuff = new DefensiveCocoonBuff(damaged, damaged)
    {
      Duration = Duration,
      EggId = EggId,
      ReviveEffect = ReviveEffect,
      MaximumHitPoints = (int)(damaged.MaxLife * MaximumHealthPercentage)
    };
    BuffSystem.Add(vengeanceBuff);
  }


  private bool ShouldBecomeEgg(int abilityLevel, unit target) =>
    target.Owner.GetTechResearched(RequiredResearch, false) > 0 &&
    abilityLevel != 0 &&
    target.Skin != EggId &&
    @event.Damage >= target.Life &&
    !target.IsIllusion;
}
