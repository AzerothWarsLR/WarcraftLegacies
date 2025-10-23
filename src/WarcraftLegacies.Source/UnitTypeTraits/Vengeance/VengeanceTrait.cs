using MacroTools.UnitTypeTraits;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.UnitTypeTraits.Vengeance;

/// <summary>
/// When the ability holder takes lethal damage, they transform into a Spirit of Vengeance.
/// If they attack enough times while a Spirit, they revive with some health.
/// Otherwise, they die.
/// </summary>
public sealed class VengeanceTrait : UnitTypeTrait, IEffectOnDamaged
{
  private readonly int _abilityTypeId;

  /// <summary>
  /// How much extra damage the vengeance form has.
  /// </summary>
  public int BonusDamageBase { private get; init; }

  /// <summary>
  /// How much damage each level of the ability adds to the vengeance form.
  /// </summary>
  public int BonusDamageLevel { private get; init; }

  /// <summary>
  /// The amount of healing granted when exiting the vengeance form.
  /// </summary>
  public float HealBase { private get; init; }

  /// <summary>
  /// How much extra healing each level of the ability adds to exiting the vengeance form.
  /// </summary>
  public float HealLevel { private get; init; }

  /// <summary>
  /// How long the vengeance form lasts.
  /// </summary>
  public float Duration { private get; init; }

  /// <summary>
  /// A unit type ID with the model of the vengeance form.
  /// </summary>
  public int AlternateFormId { private get; init; }

  /// <summary>
  /// The number of hits the hero needs to make in the vengeance form to revive.
  /// </summary>
  public int HitsReviveThreshold { private get; init; }

  /// <summary>
  /// The visual effect that occurs
  /// </summary>
  public string? ReviveEffect { private get; init; }

  /// <inheritdoc />
  public void OnDamaged()
  {
    var damaged = @event.Unit;
    var abilityLevel = damaged.GetAbilityLevel(_abilityTypeId);
    if (abilityLevel == 0 || damaged.Skin == AlternateFormId ||
        !(@event.Damage >= damaged.Life) || !(damaged.Mana >=
                                                                           damaged.GetAbilityManaCost(_abilityTypeId, abilityLevel)))
    {
      return;
    }

    @event.Damage = 0;
    var vengeanceBuff = new VengeanceBuff(damaged, damaged)
    {
      BonusDamage = BonusDamageBase + BonusDamageLevel * abilityLevel,
      Heal = HealBase + HealLevel * abilityLevel,
      Duration = Duration,
      AlternateFormId = AlternateFormId,
      HitsReviveThreshold = HitsReviveThreshold,
      ReviveEffect = ReviveEffect
    };
    BuffSystem.Add(vengeanceBuff);
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="VengeanceTrait"/> class.
  /// </summary>
  /// <param name="abilityTypeId">The ability whose level is used to determine the magnitude of the effect.</param>
  public VengeanceTrait(int abilityTypeId)
  {
    _abilityTypeId = abilityTypeId;
  }
}
