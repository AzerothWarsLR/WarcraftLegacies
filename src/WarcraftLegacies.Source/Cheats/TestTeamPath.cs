using MacroTools.Factions;
using MacroTools.Paths;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// A throwaway <see cref="FactionPath"/> used to try out team changes. Moves the faction to another team, or onto a
/// team of its own.
/// </summary>
public sealed class TestTeamPath : FactionPath
{
  private readonly Team? _destination;

  public TestTeamPath(Team? destination) => _destination = destination;

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => _destination;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
  }
}
