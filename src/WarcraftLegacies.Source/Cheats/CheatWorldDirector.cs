using MacroTools.Commands;

namespace WarcraftLegacies.Source.Cheats;

public enum WorldDirectorCommandType
{
  Control,
  NextFaction,
  PreviousFaction,
  Factions,
  CurrentFaction,
  DirectorStatus
}

/// <summary>Exposes world director actions through concise top-level cheat commands.</summary>
public sealed class CheatWorldDirector : Command
{
  private readonly WorldDirectorCommandType _commandType;

  public CheatWorldDirector(WorldDirectorCommandType commandType)
  {
    _commandType = commandType;
  }

  public override string CommandText => _commandType switch
  {
    WorldDirectorCommandType.Control => "control",
    WorldDirectorCommandType.NextFaction => "nextfaction",
    WorldDirectorCommandType.PreviousFaction => "prevfaction",
    WorldDirectorCommandType.Factions => "factions",
    WorldDirectorCommandType.CurrentFaction => "currentfaction",
    WorldDirectorCommandType.DirectorStatus => "directorstatus",
    _ => throw new System.ArgumentOutOfRangeException(nameof(_commandType))
  };

  public override ExpectedParameterCount ExpectedParameterCount =>
    _commandType == WorldDirectorCommandType.Control ? new(1) : new(0);

  public override CommandType Type => CommandType.Cheat;

  public override string Description => _commandType switch
  {
    WorldDirectorCommandType.Control => "Possesses one playable faction without changing diplomacy.",
    WorldDirectorCommandType.NextFaction => "Possesses the next playable faction.",
    WorldDirectorCommandType.PreviousFaction => "Possesses the previous playable faction.",
    WorldDirectorCommandType.Factions => "Lists playable factions and their control keys.",
    WorldDirectorCommandType.CurrentFaction => "Displays the currently possessed faction.",
    WorldDirectorCommandType.DirectorStatus => "Displays world director and manual timeline status.",
    _ => throw new System.ArgumentOutOfRangeException(nameof(_commandType))
  };

  public override string Execute(player cheater, params string[] parameters) => _commandType switch
  {
    WorldDirectorCommandType.Control => WorldDirector.Control(cheater, parameters[0]),
    WorldDirectorCommandType.NextFaction => WorldDirector.Cycle(cheater, 1),
    WorldDirectorCommandType.PreviousFaction => WorldDirector.Cycle(cheater, -1),
    WorldDirectorCommandType.Factions => WorldDirector.ListFactions(),
    WorldDirectorCommandType.CurrentFaction => WorldDirector.GetStatus(cheater),
    WorldDirectorCommandType.DirectorStatus => WorldDirector.GetStatus(cheater),
    _ => throw new System.ArgumentOutOfRangeException(nameof(_commandType))
  };
}
