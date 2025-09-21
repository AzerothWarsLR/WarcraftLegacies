using System.Collections.Generic;
using MacroTools.CommandSystem;
using WCSharp.Events;

namespace MacroTools.Cheats;

/// <summary>
/// Allows the cheater to finish reasearches and building construction instantly.
/// </summary>
public sealed class CheatBuild : Command
{

  private static readonly List<player> _playersWithCheat = new();

  /// <inheritdoc />
  public override string CommandText => "build";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "When activated, reasearches and building construction finishes instantly.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    if (parameters[0] == "on")
    {
      SetCheatActive(cheater, true);
      return "Instant build activated.";
    }

    else if (parameters[0] == "off")
    {
      SetCheatActive(cheater, false);
      return "Instant build deactivated.";
    }
    return $"The paramater {parameters[0]} did not equal 'on' or 'off'.";
  }

  /// <inheritdoc />
  public override void OnRegister()
  {
    PlayerUnitEvents.Register(UnitTypeEvent.ReceivesOrder, Build);
  }

  private static void Build()
  {
    if (@event.IssuedOrderId == 851976 && IsCheatActive(@event.Player))
    {
      @event.Unit.SetUpgradeProgress(100);
      @event.Unit.SetConstructionProgress(100);
    }
  }

  private static bool IsCheatActive(player whichPlayer)
  {
    return _playersWithCheat.Contains(whichPlayer);
  }

  private static void SetCheatActive(player whichPlayer, bool isActive)
  {
    if (isActive && !_playersWithCheat.Contains(whichPlayer))
    {
      _playersWithCheat.Add(whichPlayer);
      return;
    }

    if (!isActive && _playersWithCheat.Contains(whichPlayer))
    {
      _playersWithCheat.Remove(whichPlayer);
    }
  }
}
