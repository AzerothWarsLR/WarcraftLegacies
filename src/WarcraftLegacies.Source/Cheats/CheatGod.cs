using System;
using System.Collections.Generic;
using MacroTools.Commands;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Gives the cheater god like power (0 damage taken, 100x damage dealt).
/// </summary>
public sealed class CheatGod : Command
{
  private static readonly List<player> _playersWithCheat = new();

  /// <inheritdoc />
  public override string CommandText => "god";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "When activated, your units deal 100x damage and take 0x damage.";

  static CheatGod()
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, Damage);
  }

  private static bool IsCheatActive(player whichPlayer)
  {
    return _playersWithCheat.Contains(whichPlayer);
  }

  private static void SetCheatActive(player whichPlayer, bool isActive)
  {
    switch (isActive)
    {
      case true when !_playersWithCheat.Contains(whichPlayer):
        _playersWithCheat.Add(whichPlayer);
        return;
      case false when _playersWithCheat.Contains(whichPlayer):
        _playersWithCheat.Remove(whichPlayer);
        break;
    }
  }

  private static void Damage()
  {
    try
    {
      if (IsCheatActive(@event.Player))
      {
        @event.Damage = 0;
      }
      else if (IsCheatActive(@event.DamageSource.Owner))
      {
        @event.Damage *= 100;
      }
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
