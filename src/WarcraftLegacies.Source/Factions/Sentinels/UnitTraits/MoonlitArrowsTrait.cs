using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Sentinels.UnitTraits;

public sealed class MoonlitArrowsTrait : UnitTrait, IAppliesEffectOnDamage, IEffectOnCreated
{
  private const float Dawn = 6;
  private const float Dusk = 18;

  private readonly List<unit> _archers = new();
  private bool _wasNight;

  public required float BonusDamage { get; init; }

  public required string DayMissile { get; init; }

  public required string NightMissile { get; init; }

  public MoonlitArrowsTrait()
  {
    _wasNight = IsNight();
    timer.Create().Start(1, true, () =>
    {
      var isNight = IsNight();
      if (isNight == _wasNight)
      {
        return;
      }

      _wasNight = isNight;
      UpdateAllMissiles();
    });
  }

  public void OnCreated(unit createdUnit)
  {
    _archers.Add(createdUnit);
    UpdateMissile(createdUnit);
  }

  public void OnDealsDamage()
  {
    var archer = @event.DamageSource;
    var target = @event.Unit;
    if (!@event.IsAttack || !IsNight() || !target.Alive)
    {
      return;
    }

    target.TakeDamage(archer, BonusDamage, false, false, attacktype.Magic, damagetype.Magic);
  }

  private void UpdateAllMissiles()
  {
    _archers.RemoveAll(x => x == null || GetUnitTypeId(x) == 0);
    foreach (var archer in _archers)
    {
      UpdateMissile(archer);
    }
  }

  private void UpdateMissile(unit archer) =>
    BlzSetUnitWeaponStringField(archer, UNIT_WEAPON_SF_ATTACK_PROJECTILE_ART, 0, IsNight() ? NightMissile : DayMissile);

  private static bool IsNight()
  {
    var timeOfDay = GetFloatGameState(GAME_STATE_TIME_OF_DAY);
    return timeOfDay >= Dusk || timeOfDay < Dawn;
  }
}
