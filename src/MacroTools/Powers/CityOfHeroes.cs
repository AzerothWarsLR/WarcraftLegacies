using MacroTools.Extensions;
using MacroTools.FactionSystem;
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

    /// <summary>
    /// An ability ID that bestows a hero glow.
    /// </summary>
    public int HeroGlowAbilityTypeId { get; init; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="CityOfHeroes"/> class.
    /// </summary>
    /// <param name="chance">The chance that trained units have to become demiheroes.</param>
    public CityOfHeroes(float chance)
    {
      _chance = chance;
      Description =
        $"Units you train have a {chance * 100}% to become demiheroes, increasing their hit points, mana, and damage by 25%, and granting them the ability to use items.";
    }
    
    /// <inheritdoc />
    public override void OnAdd(player whichPlayer)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerFinishesTraining, OnTrainUnit, GetPlayerId(whichPlayer));
    }

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer)
    {
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerFinishesTraining, GetPlayerId(whichPlayer));
    }

    private void Heroize(unit whichUnit)
    {
      if (whichUnit.IsType(UNIT_TYPE_HERO))
        return;

      AddSpecialEffect(@"Abilities\Spells\Other\Levelup\Levelupcaster.mdx", GetUnitX(whichUnit), GetUnitY(whichUnit))
        .SetLifespan(1);
      whichUnit
        .MultiplyBaseDamage(1.25f, 0)
        .MultiplyBaseDamage(1.50f, 1)
        .MultiplyMaxHitpoints(1.25f)
        .MultiplyMaxMana(1.25f)
        .AddAbility(HeroGlowAbilityTypeId)
        .AddAbility(FourCC("Alnv"));
    }

    private void OnTrainUnit()
    {
      if (!(_chance > GetRandomReal(0, 1))) return;
      Heroize(GetTrainedUnit());
    }
  }
}