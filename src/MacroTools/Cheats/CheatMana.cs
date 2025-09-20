using System.Collections.Generic;
using MacroTools.CommandSystem;
using WCSharp.Events;

namespace MacroTools.Cheats;

public sealed class CheatMana : Command
{
  /// <inheritdoc />
  public override string CommandText => "mana";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "When activated, causes your units to fully restore mana whenever they cast a spell.";

  private static readonly List<player> _playersWithCheat = new();

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var toggle = parameters[0];

    switch (toggle)
    {
      case "on":
        SetCheatActive(cheater, true);
        return "Infinite mana activated.";
      case "off":
        SetCheatActive(cheater, false);
        return "Infinite mana deactivated.";
      default:
        return "You must specify \"on\" or \"off\" as the first parameter.";
    }
  }

  /// <inheritdoc />
  public override void OnRegister() =>
    PlayerUnitEvents.Register(UnitTypeEvent.SpellEndCast, Spell);

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

  private static void Spell()
  {
    if (_playersWithCheat.Contains(GetTriggerPlayer()))
    {
      SetUnitState(GetTriggerUnit(), UNIT_STATE_MANA, GetUnitState(GetTriggerUnit(), UNIT_STATE_MAX_MANA));
    }
  }
}
