namespace MacroTools.GameModes;

/// <summary>A game mode that players can vote on. Once one is chosen, it determines the game's basic settings.</summary>
public interface IGameMode
{
  /// <summary>A user-friendly name that players will see.</summary>
  public string Name { get; }

  /// <summary>A short user-friendly description of what this gamemode is, shown under its vote button.</summary>
  public string Description { get; }

  /// <summary>Fired when this <see cref="IGameMode"/> is successfully voted on.</summary>
  public void OnChoose();

  /// <summary>
  /// Total votes for this gamemode are offset by the specified amount.
  /// <remarks>Set this to a negative value for gamemodes that should require a larger proportion of players to
  /// vote for in order to pass.</remarks>
  /// </summary>
  public int VoteOffset { get; }

  /// <summary>An icon shown above this gamemode's vote button.</summary>
  public string IconPath { get; }

  /// <summary>
  /// If true, every faction already starts with its capitals unlocked in this gamemode, so Hard difficulty and the
  /// early game option aren't offered.
  /// </summary>
  public bool SkipsEarlyGame { get; }

  /// <summary>Whether players vote on diplomacy, or this gamemode decides it.</summary>
  public DiplomacyRule Diplomacy { get; }
}
