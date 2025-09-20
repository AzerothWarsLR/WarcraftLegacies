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
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerSpellEffect, OnSpellCast, GetPlayerId(whichPlayer));

  public override void OnRemove(player whichPlayer) =>
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerSpellEffect, OnSpellCast, GetPlayerId(whichPlayer));

  private static void OnSpellCast()
  {
    var castingUnit = GetTriggerUnit();
    if (castingUnit == null)
    {
      return;
    }

    var abilityId = GetSpellAbilityId();
    var abilityLevel = GetUnitAbilityLevel(castingUnit, abilityId);
    var manaCost = BlzGetUnitAbilityManaCost(castingUnit, abilityId, abilityLevel - 1);
    var damageAmount = manaCost * 0.2f;

    SetUnitState(castingUnit, UNIT_STATE_LIFE, GetUnitState(castingUnit, UNIT_STATE_LIFE) - damageAmount);
    SetUnitState(castingUnit, UNIT_STATE_LIFE, GetUnitState(castingUnit, UNIT_STATE_LIFE) - damageAmount);

    if (UnitAlive(castingUnit))
    {
      return;
    }

    var x = GetUnitX(castingUnit);
    var y = GetUnitY(castingUnit);
    var wretched = CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE), UNIT_N05K_WRETCHED_CORRUPTED_SUNWELL, x, y, 0);
    wretched.SetTimedLife(120.0f);
    UnitAddType(wretched, UNIT_TYPE_SUMMONED);
  }
}
