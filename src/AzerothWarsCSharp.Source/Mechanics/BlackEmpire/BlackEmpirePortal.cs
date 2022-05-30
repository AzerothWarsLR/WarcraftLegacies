using System;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public sealed class BlackEmpirePortal
  {
    private readonly unit _exteriorWaygate;
    private readonly destructable _interiorPortal;
    private readonly unit _interiorWaygate;
    private ControlPoint _nearbyControlPoint; //This Control Point is the closest one to the exterior Waygate
    private BlackEmpirePortalState _state = BlackEmpirePortalState.Closed;

    public BlackEmpirePortal(unit interiorWaygate, destructable interiorPortal, Point interiorDestination,
      unit exteriorWaygate, string name, ControlPoint nearbyControlPoint)
    {
      _interiorWaygate = interiorWaygate;
      _interiorPortal = interiorPortal;
      _exteriorWaygate = exteriorWaygate;
      Name = name;
      _nearbyControlPoint = nearbyControlPoint;
      _interiorWaygate.SetWaygateDestination(_exteriorWaygate.GetPosition());
      _exteriorWaygate.SetWaygateDestination(interiorDestination);
      FogModifierStart(CreateFogModifierRadius(BlackEmpireSetup.FactionBlackempire.Player, FOG_OF_WAR_VISIBLE,
        GetUnitX(exteriorWaygate), GetUnitY(exteriorWaygate), 700, true, true));
    }

    public string Name { get; }

    public BlackEmpirePortalState State
    {
      get => _state;
      set
      {
        _state = value;
        switch (value)
        {
          case BlackEmpirePortalState.Closed:
            WaygateActivate(_interiorWaygate, false);
            WaygateActivate(_exteriorWaygate, false);
            SetDestructableAnimation(_interiorPortal, "death");
            SetUnitAnimation(_exteriorWaygate, "death");
            SetUnitVertexColor(_interiorWaygate, 255, 50, 50, 255);
            break;
          case BlackEmpirePortalState.ExitOnly:
            WaygateActivate(_interiorWaygate, true);
            WaygateActivate(_exteriorWaygate, false);
            SetDestructableAnimation(_interiorPortal, "birth");
            SetUnitAnimation(_exteriorWaygate, "death");
            SetUnitVertexColor(_interiorWaygate, 150, 150, 255, 230);
            break;
          case BlackEmpirePortalState.Open:
            WaygateActivate(_interiorWaygate, true);
            WaygateActivate(_exteriorWaygate, true);
            SetDestructableAnimation(_interiorPortal, "birth");
            SetUnitAnimation(_exteriorWaygate, "birth");
            SetUnitVertexColor(_interiorWaygate, 255, 255, 255, 255);
            break;
          default:
            throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
      }
    }
  }
}