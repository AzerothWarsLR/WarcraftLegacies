using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Setup;
using WCSharp.Effects;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Powers;

/// <summary>
/// When the player's Control Points take damage, they summon some Treants.
/// </summary>
public sealed class ShaladrassilsBlessing : Power
{
  private readonly unit _shaladrassil;
  private readonly int _summonedUnitTypeId;
  private readonly float _duration;
  private readonly int _summonedUnitCount;
  private readonly int _manaCost;

  /// <summary>
  /// Initializes a new instance of the <see cref="ShaladrassilsBlessing"/> class.
  /// </summary>
  /// <param name="shaladrassil">The unit that has to spend mana for the Power to work.</param>
  /// <param name="summonedUnitTypeId">The unit that is summoned.</param>
  /// <param name="duration">How long the summoned units last.</param>
  /// <param name="summonedUnitCount">How many units are summoned.</param>
  /// <param name="manaCost">The cost applied to Shaladrassil when summoning units.</param>
  public ShaladrassilsBlessing(unit shaladrassil, int summonedUnitTypeId, float duration, int summonedUnitCount, int manaCost)
  {
    _shaladrassil = shaladrassil;
    _summonedUnitTypeId = summonedUnitTypeId;
    _duration = duration;
    _summonedUnitCount = summonedUnitCount;
    _manaCost = manaCost;
    Description =
      $"When an undamaged Control Point you control takes damage and you control {shaladrassil.Name}, consume {_manaCost} mana from {shaladrassil.Name} to summon {_summonedUnitCount} {GetObjectName(summonedUnitTypeId)}s to defend the Control Point for {_duration} seconds.";
    Name = $"{shaladrassil.Name}'s Blessing";
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer)
  {
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakesDamage, OnPlayerTakesDamage, whichPlayer.Id);
  }

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer)
  {
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerTakesDamage, OnPlayerTakesDamage, whichPlayer.Id);
  }

  private void OnPlayerTakesDamage()
  {
    var triggerUnit = @event.Unit;
    var triggerUnitOwner = triggerUnit.Owner;
    if (!triggerUnit.IsControlPoint()
        || _shaladrassil.Owner != triggerUnitOwner
        || !(_shaladrassil.Mana >= _manaCost)
        || triggerUnit.GetLifePercent() < 100)
    {
      return;
    }

    if (SummonTreants(triggerUnitOwner, triggerUnit.X, triggerUnit.Y))
    {
      _shaladrassil.Mana -= _manaCost;
    }
  }

  private bool SummonTreants(player owningPlayer, float x, float y)
  {
    if (pathingtype.Walkability.GetPathable(x, y))
    {
      return false;
    }

    for (var i = 0; i < _summonedUnitCount; i++)
    {
      var treant = unit.Create(owningPlayer, _summonedUnitTypeId, x, y);
      treant.SetTimedLife(_duration);
      treant.AddType(unittype.Summoned);
      treant.SetExploded(true);
      EffectSystem.Add(effect.Create(@"Objects\Spawnmodels\NightElf\EntBirthTarget\EntBirthTarget.mdl", treant.X, treant.Y));
    }

    return true;
  }
}
