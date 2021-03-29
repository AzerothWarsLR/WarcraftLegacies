using AzerothWarsCSharp.Source.Libraries;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.GameLogic
{
  /// <summary>
  /// When a Control Point is reduced to 0% hitpoints, it is fully healed
  /// and its ownership is transferred to the owner of the killer.
  /// </summary>
  public static class ControlPointCapture
  {
    private static void OnControlPointDamaged()
    {
      var attackedUnit = GetTriggerUnit();
      if (GetUnitState(attackedUnit, UNIT_STATE_LIFE) - GetEventDamage() < 0)
      {
        BlzSetEventDamage(0);
        SetUnitOwner(attackedUnit, GetOwningPlayer(GetEventDamageSource()), true);
        SetUnitState(attackedUnit, UNIT_STATE_LIFE, GetUnitState(attackedUnit, UNIT_STATE_MAX_LIFE));
      }
    }

    private static void OnControlPointCreated(object sender, ControlPointEventArgs e)
    {
      RegisterControlPoint(e.ControlPoint);
    }

    private static void OnControlPointDestroyed(object sender, ControlPointEventArgs e)
    {
      UnregisterControlPoint(e.ControlPoint);
    }

    private static void RegisterControlPoint(ControlPoint controlPoint)
    {
      var newTrigger = CreateTrigger();
      TriggerRegisterUnitEvent(newTrigger, controlPoint.Unit, EVENT_UNIT_DAMAGED);
      TriggerAddAction(newTrigger, OnControlPointDamaged);
      _damageTriggers[controlPoint] = newTrigger;
    }

    private static void UnregisterControlPoint(ControlPoint controlPoint)
    {
      DestroyTrigger(_damageTriggers[controlPoint]);
      _damageTriggers[controlPoint] = null;
    }

    public static void Initialize()
    {
      foreach (var controlPoint in ControlPoint.All)
      {
        RegisterControlPoint(controlPoint);
      }
      ControlPoint.Created += OnControlPointCreated;
      ControlPoint.Destroyed += OnControlPointDestroyed;
    }

    private static Dictionary<ControlPoint, trigger> _damageTriggers = new();
  }
}
