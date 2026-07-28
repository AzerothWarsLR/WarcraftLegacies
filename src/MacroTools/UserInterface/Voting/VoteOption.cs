using System;

namespace MacroTools.UserInterface.Voting;

/// <summary>
/// A single choice within a <see cref="VoteGroup"/>.
/// </summary>
public sealed class VoteOption
{
  /// <summary>
  /// The text shown on this option's button.
  /// </summary>
  public required string Name { get; init; }

  /// <summary>
  /// Total votes for this option are offset by the specified amount.
  /// <remarks>Set this to a negative value for options that should require a larger proportion of players to
  /// vote for in order to pass.</remarks>
  /// </summary>
  public int VoteOffset { get; init; }

  /// <summary>
  /// Fired when this option wins its <see cref="VoteGroup"/>.
  /// </summary>
  public required Action OnChosen { get; init; }
}
