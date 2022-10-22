using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Gates
{
  /// <summary>
  /// When registered to the <see cref="GateService"/>, <see cref="Gate"/>s play their open animation when opened
  /// and become their destroyed version when destroyed.
  /// </summary>
  public sealed class GateService
  {
    private readonly int _openAbilityId;
    private readonly int _closeAbilityId;

    public GateService(int openAbilityId, int closeAbilityId)
    {
      _openAbilityId = openAbilityId;
      _closeAbilityId = closeAbilityId;
    }

    private void RegisterDeathEvent(Gate gate)
    {
      foreach (var unitTypeId in new[] { gate.ClosedId, gate.DeadId, gate.OpenedId })
      {
        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDies,
          () =>
          {
            var dyingGate = GetTriggerUnit();
            var dyingGatePos = new Point(GetUnitX(dyingGate), GetUnitY(dyingGate));
            var dyingGateFacing = GetUnitFacing(dyingGate);
            RemoveUnit(dyingGate);
            CreateUnit(GetOwningPlayer(GetKillingUnit()), gate.DeadId, dyingGatePos.X, dyingGatePos.Y, dyingGateFacing);
          }, unitTypeId);
      }
    }

    private void RegisterCastEvent(Gate gate)
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.SpellEffect,
        () =>
        {
          var triggerUnit = GetTriggerUnit();
          if (GetUnitTypeId(triggerUnit) == gate.ClosedId)
          {
            SetUnitAnimation(triggerUnit, "death alternate");
          }
        }, _openAbilityId);
    }

    /// <summary>
    /// Registers a <see cref="Gate"/>.
    /// </summary>
    public void RegisterGate(Gate gate)
    {
      RegisterCastEvent(gate);
      RegisterDeathEvent(gate);
      foreach (var openedGate in new GroupWrapper().EnumUnitsOfType(gate.OpenedId).EmptyToList())
      {
        SetUnitAnimation(openedGate, "death alternate");
      }
    }
  }
}