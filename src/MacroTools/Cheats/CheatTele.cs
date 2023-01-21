using System;
using System.Collections.Generic;
using MacroTools.CommandSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatTele : Command
  {
    /// <inheritdoc />
    public override string CommandText => "tele";
    
    /// <inheritdoc />
    public override int ParameterCount => 1;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    private static readonly Dictionary<player, bool> TeleToggle = new();

    private static void Patrol()
    {
      if (GetIssuedOrderId() == 851990 && TeleToggle[GetTriggerPlayer()])
      {
        SetUnitX(GetTriggerUnit(), GetOrderPointX());
        SetUnitY(GetTriggerUnit(), GetOrderPointY());
      }
    }

    /// <inheritdoc />
    public override string Description => "When activated, causes your units to teleport whenever you order them to patrol.";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (Enum.TryParse<Toggle>(parameters[0], out var toggle))
        return "You must specify \"on\" or \"off\" as the first parameter.";

      switch (toggle)
      {
        case Toggle.On:
          TeleToggle[cheater] = true;
          return "Teleport activated. Use patrol to move instantly.";
        case Toggle.Off:
          TeleToggle[cheater] = false;
          return "Teleport deactivated. Patrol works normally.";
        default:
          throw new ArgumentOutOfRangeException($"{nameof(parameters)}");
      }
    }

    /// <inheritdoc />
    public override void OnRegister() => 
      PlayerUnitEvents.Register(UnitTypeEvent.ReceivesPointOrder, Patrol);
  }
}