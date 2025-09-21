using System.Collections.Generic;
using MacroTools.CommandSystem;
using WCSharp.Events;

namespace MacroTools.Cheats;

public sealed class CheatTele : Command
{
  /// <inheritdoc />
  public override string CommandText => "tele";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  private static readonly Dictionary<player, bool> _teleToggle = new();

  private static void Patrol()
  {
    if (@event.IssuedOrderId == 851990 && _teleToggle[@event.Player])
    {
      @event.Unit.X = @event.OrderPointX;
      @event.Unit.Y = @event.OrderPointY;
    }
  }

  /// <inheritdoc />
  public override string Description => "When activated, causes your units to teleport whenever you order them to patrol.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var toggle = parameters[0];

    switch (toggle)
    {
      case "on":
        _teleToggle[cheater] = true;
        return "Teleport activated. Use patrol to move instantly.";
      case "off":
        _teleToggle[cheater] = false;
        return "Teleport deactivated. Patrol works normally.";
      default:
        return "You must specify \"on\" or \"off\" as the first parameter.";
    }
  }

  /// <inheritdoc />
  public override void OnRegister() =>
    PlayerUnitEvents.Register(UnitTypeEvent.ReceivesPointOrder, Patrol);
}
