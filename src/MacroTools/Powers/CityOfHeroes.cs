using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Setup;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.Powers
{
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
        $"{eligibleUnitPlural} you train have a {chance * 100}% to become demiheroes, increasing their hit points, mana, and damage by {(statMultiplier-1)*100}%, changing their attack and armor types to Hero, and granting them the ability to use items.";
    }
    
    /// <inheritdoc />
    public override void OnAdd(player whichPlayer) => 
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerFinishesTraining, OnTrainUnit, GetPlayerId(whichPlayer));

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer) =>
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerFinishesTraining, OnTrainUnit, GetPlayerId(whichPlayer));

    private void Heroize(unit whichUnit)
    {
      if (whichUnit.IsType(UNIT_TYPE_HERO) || whichUnit.IsType(UNIT_TYPE_PEON) || !Filter(whichUnit))
        return;

      AddSpecialEffect(@"Abilities\Spells\Other\Levelup\Levelupcaster.mdx", GetUnitX(whichUnit), GetUnitY(whichUnit))
        .SetLifespan(1);
      whichUnit
        .MultiplyBaseDamage(_statMultiplier, 0)
        .MultiplyBaseDamage(_statMultiplier, 1)
        .MultiplyMaxHitpoints(_statMultiplier)
        .MultiplyMaxMana(_statMultiplier)
        .RemoveAbility(FourCC("Aihn"))
        .AddAbility(HeroGlowAbilityTypeId)
        .AddAbility(FourCC("AInv"))
        .SetArmorType(5);

      if (whichUnit.GetAttackType() != 3)
        whichUnit.SetAttackType(6);
    }

    private void OnTrainUnit()
    {
      if (_chance < GetRandomReal(0, 1)) return;
      Heroize(GetTrainedUnit());
    }
  }
}