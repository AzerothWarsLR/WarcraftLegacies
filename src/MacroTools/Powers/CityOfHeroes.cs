using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Setup;
using WCSharp.Api.Enums;
using WCSharp.Effects;
using WCSharp.Events;

namespace MacroTools.Powers;

/// <summary>
/// The player's trained units have a chance to become demiheroes.
/// </summary>
public sealed class CityOfHeroes : Power
{
  private readonly float _chance;
  private readonly float _statMultiplier;

  /// <summary>
  /// An ability ID that bestows a hero glow.
  /// </summary>
  public int HeroGlowAbilityTypeId { get; init; }

  /// <summary>
  /// The filter that units must pass to be eligible to become demiheroes.
  /// </summary>
  public Func<unit, bool> Filter { get; init; } = _ => true;

  /// <summary>
  /// Initializes a new instance of the <see cref="CityOfHeroes"/> class.
  /// </summary>
  /// <param name="chance">The chance that trained units have to become demiheroes.</param>
  /// <param name="statMultiplier">The chance that trained units have to become demiheroes.</param>
  /// <param name="eligibleUnitPlural">The type of unit that this power affects, e.g. "units" or "Murlocs".</param>
  public CityOfHeroes(float chance, float statMultiplier, string eligibleUnitPlural)
  {
    _chance = chance;
    _statMultiplier = statMultiplier;
    Description =
      $"{eligibleUnitPlural} you train have a {chance * 100}% to become demiheroes, increasing their hit points, mana, and damage by {(statMultiplier - 1) * 100}%, changing their attack and armor types to Hero, and granting them the ability to use items.";
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer) =>
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerFinishesTraining, OnTrainUnit, whichPlayer.Id);

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer) =>
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerFinishesTraining, OnTrainUnit, whichPlayer.Id);

  private void Heroize(unit whichUnit)
  {
    if (whichUnit.IsUnitType(unittype.Hero) || whichUnit.IsUnitType(unittype.Peon) || !Filter(whichUnit))
    {
      return;
    }

    EffectSystem.Add(effect.Create(@"Abilities\Spells\Other\Levelup\Levelupcaster.mdx", whichUnit.X, whichUnit.Y), 1);

    whichUnit.MultiplyBaseDamage(_statMultiplier, 0);
    whichUnit.MultiplyBaseDamage(_statMultiplier, 1);
    whichUnit.MultiplyMaxHitpoints(_statMultiplier);
    whichUnit.MultiplyMaxMana(_statMultiplier);
    whichUnit.RemoveAbility(FourCC("Aihn"));
    whichUnit.AddAbility(HeroGlowAbilityTypeId);
    whichUnit.AddAbility(FourCC("AInv"));
    whichUnit.DefenseType = DefenseType.Hero;

    if (whichUnit.AttackAttackType1 != AttackType.Siege)
    {
      whichUnit.AttackAttackType1 = AttackType.Hero;
    }
  }

  private void OnTrainUnit()
  {
    if (_chance < GetRandomReal(0, 1))
    {
      return;
    }

    Heroize(@event.TrainedUnit);
  }
}
