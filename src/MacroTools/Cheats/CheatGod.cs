using System;
using System.Collections.Generic;
using MacroTools.CommandSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed  class CheatGod : Command
  {
    private static readonly List<player> PlayersWithCheat = new();
    
    /// <inheritdoc />
    public override string CommandText => "god";

    /// <inheritdoc />
    public override int ParameterCount => 1;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    static CheatGod()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeIsDamaged, Damage);
    }

    private static bool IsCheatActive(player whichPlayer)
    {
      return PlayersWithCheat.Contains(whichPlayer);
    }

    private static void SetCheatActive(player whichPlayer, bool isActive)
    {
      switch (isActive)
      {
        case true when !PlayersWithCheat.Contains(whichPlayer):
          PlayersWithCheat.Add(whichPlayer);
          return;
        case false when PlayersWithCheat.Contains(whichPlayer):
          PlayersWithCheat.Remove(whichPlayer);
          break;
      }
    }

    private static void Damage()
    {
      try
      {
        if (IsCheatActive(GetTriggerPlayer()))
          BlzSetEventDamage(0);
        else if (IsCheatActive(GetOwningPlayer(GetEventDamageSource())))
          BlzSetEventDamage(GetEventDamage() * 100);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var parameter = parameters[0];
      switch (parameter)
      {
        case "on":
          SetCheatActive(cheater, true);
          return "God mod activated. Your units will deal 100x damage and take no damage.";
        case "off":
          SetCheatActive(cheater, false);
          return "God mode deactivated.";
        default:
          return "Invalid parameter used.";
      }
    }
  }
}