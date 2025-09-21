using System.Collections.Generic;
using MacroTools.CommandSystem;
using WCSharp.Events;

namespace MacroTools.Cheats;

public sealed class CheatNocd : Command
{
  /// <inheritdoc />
  public override string CommandText => "nocd";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override string Description => "When activated, your units reset all cooldowns after they cast a spell.";

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  private static readonly List<player> _playersWithCheat = new();

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

  private static void Spell()
  {
    if (IsCheatActive(@event.Player))
    {
      @event.Unit.EndAbilityCooldown(@event.SpellAbilityId);
    }
  }

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var toggle = parameters[0];

    switch (toggle)
    {
      case "on":
        SetCheatActive(cheater, true);
        return "No cooldowns activated.";
      case "off":
        SetCheatActive(cheater, false);
        return "No cooldowns deactivated.";
      default:
        return "You must specify \"on\" or \"off\" as the first parameter.";
    }
  }

  /// <inheritdoc />
  public override void OnRegister() =>
    PlayerUnitEvents.Register(UnitTypeEvent.SpellEndCast, Spell);
}
