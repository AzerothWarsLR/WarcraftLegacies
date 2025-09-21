using WCSharp.Buffs;
using WCSharp.Events;

namespace WarcraftLegacies.Source.PassiveAbilities.Vengeance;

/// <summary>
/// The unit becomes a Spirit of Vengeance when this is applied, healing for an amount and gaining bonus damage.
/// If the unit attacks some number of times before the buff expires, it revives.
/// Otherwise, it dies.
/// </summary>
public sealed class VengeanceBuff : PassiveBuff
{
  /// <summary>
  /// Initializes a new instance of the <see cref="VengeanceBuff"/> class.
  /// </summary>
  public VengeanceBuff(unit caster, unit target) : base(caster, target)
  {
  }

  /// <summary>
  /// How much to heal the caster whey exit the vengeance form.
  /// </summary>
  public float Heal { private get; init; }

  /// <summary>
  /// How much extra damage the vengeance form has.
  /// </summary>
  public int BonusDamage { private get; init; }

  /// <summary>
  /// The effect when the vengeance form is exited ans the hero is revived.
  /// </summary>
  public string? ReviveEffect { private get; init; }

  /// <summary>
  /// How many hits the hero needs to make to revive out of the vengeance form.
  /// </summary>
  public int HitsReviveThreshold { private get; init; }

  /// <summary>
  /// The unit type ID of the vengeance form.
  /// </summary>
  public int AlternateFormId { private get; init; }

  /// <summary>
  ///   The unit type ID of the unit before it was transformed.
  /// </summary>
  private int OriginalFormId { get; set; }

  /// <summary>
  ///   How many times this unit has struck any other unit since gaining Vengeance.
  /// </summary>
  private int HitsDone { get; set; }

  private void OnInflictsDamage()
  {
    var isAttackerAlliedToVictim = @event.DamageSource.Owner.GetAlliance(@event.Unit.Owner, alliancetype.Passive);
    if (!@event.IsAttack || isAttackerAlliedToVictim)
    {
      return;
    }

    HitsDone++;
    if (HitsDone >= HitsReviveThreshold)
    {
      Active = false;
    }
  }

  /// <inheritdoc />
  public override void OnApply()
  {
    OriginalFormId = Target.UnitType;
    Target.Skin = AlternateFormId;
    effect.Create(ReviveEffect, Target.X, Target.Y).Dispose();
    Target.Life = Heal;
    Target.AttackBaseDamage1 = Target.AttackBaseDamage1 + BonusDamage;
    PlayerUnitEvents.Register(UnitTypeEvent.Damaging, OnInflictsDamage, OriginalFormId);
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    Target.AttackBaseDamage1 = Target.AttackBaseDamage1 - BonusDamage;
    Caster.Skin = OriginalFormId;
    PlayerUnitEvents.Unregister(UnitTypeEvent.Damaging, OnInflictsDamage, OriginalFormId);
    if (HitsDone >= HitsReviveThreshold)
    {
      effect.Create(ReviveEffect, Caster.X, Caster.Y).Dispose();
    }
    else
    {
      Caster.Kill();
    }
  }
}
