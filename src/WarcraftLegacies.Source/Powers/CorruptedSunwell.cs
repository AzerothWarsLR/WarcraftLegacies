using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Setup;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Powers;

public sealed class CorruptedSunwell : Power
{
  /// <summary>
  /// Initializes a new instance of the <see cref="CorruptedSunwell"/> class.
  /// </summary>
  /// <param name="damage">The amount of damage taken per mana the player's units spend on abilities.</param>
  public CorruptedSunwell(float damage)
  {
    Name = "Corrupted Sunwell";
    Description =
      $"Your units are damaged for {damage * 100}% of the mana they spend on spells. Units that die from this effect are reanimated as hostile Wretched.";
    IconName = "OrbOfDarkness";
  }

  public override void OnAdd(player whichPlayer) =>
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerSpellEffect, OnSpellCast, whichPlayer.Id);

  public override void OnRemove(player whichPlayer) =>
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerSpellEffect, OnSpellCast, whichPlayer.Id);

  private static void OnSpellCast()
  {
    var castingUnit = @event.Unit;
    if (castingUnit == null)
    {
      return;
    }

    var abilityId = @event.SpellAbilityId;
    var abilityLevel = castingUnit.GetAbilityLevel(abilityId);
    var manaCost = castingUnit.GetAbilityManaCost(abilityId, abilityLevel - 1);
    var damageAmount = manaCost * 0.2f;

    castingUnit.Life = castingUnit.Life - damageAmount;
    castingUnit.Life = castingUnit.Life - damageAmount;

    if (castingUnit.Alive)
    {
      return;
    }

    var x = castingUnit.X;
    var y = castingUnit.Y;
    var wretched = unit.Create(player.NeutralAggressive, UNIT_N05K_WRETCHED_CORRUPTED_SUNWELL, x, y, 0);
    wretched.SetTimedLife(120.0f);
    wretched.AddType(unittype.Summoned);
  }
}
