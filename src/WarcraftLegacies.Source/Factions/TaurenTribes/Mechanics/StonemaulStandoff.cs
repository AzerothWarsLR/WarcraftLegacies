using System.Linq;
using MacroTools.Extensions;
using MacroTools.Legends;
using MacroTools.Utils;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics;

public sealed class StonemaulStandoff
{
  private const float TickInterval = 2f;
  private const float RexxarSpawnOffset = 150f;
  private const float NearbyHelpRange = 900f;
  private const float KorgallLowestLifeFraction = 0.5f;

  private static readonly int[] _lockedCommands = { FourCC("Amov"), FourCC("Aatk") };

  private readonly unit _korgall;
  private readonly unit _rexxar;
  private readonly timer _tickTimer;
  private bool _active = true;
  private bool _issuingOwnOrder;

  public StonemaulStandoff(player taurenPlayer, LegendaryHero rexxar, unit korgall)
  {
    _korgall = korgall;
    rexxar.ForceCreate(taurenPlayer, new(korgall.X + RexxarSpawnOffset, korgall.Y), 180);
    _rexxar = rexxar.Unit!;

    foreach (var command in _lockedCommands)
    {
      _rexxar.HideAbility(command, true);
    }

    PlayerUnitEvents.Register(UnitEvent.IsDamaged, OnRexxarDamaged, _rexxar);
    PlayerUnitEvents.Register(UnitEvent.Damaging, OnRexxarDealsDamage, _rexxar);
    PlayerUnitEvents.Register(UnitEvent.ReceivesOrder, OnRexxarOrdered, _rexxar);
    PlayerUnitEvents.Register(UnitEvent.ReceivesPointOrder, OnRexxarOrdered, _rexxar);
    PlayerUnitEvents.Register(UnitEvent.ReceivesTargetOrder, OnRexxarOrdered, _rexxar);

    _tickTimer = timer.Create();
    _tickTimer.Start(TickInterval, true, Tick);
    Tick();
  }

  public void End()
  {
    if (!_active)
    {
      return;
    }

    _active = false;
    _tickTimer.Dispose();
    foreach (var command in _lockedCommands)
    {
      _rexxar.HideAbility(command, false);
    }

    _rexxar.IssueOrder(ORDER_STOP);
  }

  private void Tick()
  {
    if (!_active || !_rexxar.Alive)
    {
      return;
    }

    AttackKorgall();
    if (_korgall.Alive && !IsHelpNearby())
    {
      _korgall.IssueOrder(ORDER_ATTACK, _rexxar);
    }
  }

  private void AttackKorgall()
  {
    _issuingOwnOrder = true;
    if (_korgall.Alive)
    {
      _rexxar.IssueOrder(ORDER_ATTACK, _korgall);
    }
    else
    {
      _rexxar.IssueOrder(ORDER_HOLD_POSITION);
    }

    _issuingOwnOrder = false;
  }

  private void OnRexxarOrdered()
  {
    if (!_active || _issuingOwnOrder)
    {
      return;
    }

    var reorderTimer = timer.Create();
    reorderTimer.Start(0, false, () =>
    {
      reorderTimer.Dispose();
      if (_active && _rexxar.Alive)
      {
        AttackKorgall();
      }
    });
  }

  private void OnRexxarDamaged()
  {
    if (_active)
    {
      @event.Damage = 0;
    }
  }

  private void OnRexxarDealsDamage()
  {
    if (!_active || @event.DamageTarget != _korgall)
    {
      return;
    }

    var lowestLife = _korgall.MaxLife * KorgallLowestLifeFraction;
    var allowedDamage = _korgall.Life - lowestLife;
    if (@event.Damage > allowedDamage)
    {
      @event.Damage = allowedDamage > 0 ? allowedDamage : 0;
    }
  }

  private bool IsHelpNearby()
  {
    var rexxarOwner = _rexxar.Owner;
    return GlobalGroup
      .EnumUnitsInRange(_korgall.GetPosition(), NearbyHelpRange)
      .Any(nearbyUnit => nearbyUnit != _rexxar && nearbyUnit.Alive && nearbyUnit.IsAllyTo(rexxarOwner));
  }
}
