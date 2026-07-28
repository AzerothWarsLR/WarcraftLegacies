namespace MacroTools.UserInterface.Voting;

/// <summary>
/// A single player's vote for one option within one <see cref="VoteGroup"/>, broadcast to all clients.
/// </summary>
/// <remarks>
/// Several <see cref="VoteGroup"/>s can be active at once (e.g. multiple categories on one page), and
/// <c>SyncSystem.Subscribe</c> dispatches by static type, so every group shares this one message shape and
/// filters incoming messages by <see cref="GroupId"/> instead of each having its own message type.
/// </remarks>
internal sealed class VoteSyncMessage
{
  /// <summary>
  /// Identifies which <see cref="VoteGroup"/> this vote belongs to.
  /// </summary>
  public int GroupId { get; set; }

  /// <summary>
  /// The player slot that cast this vote.
  /// </summary>
  public int PlayerId { get; set; }

  /// <summary>
  /// The index, within the <see cref="VoteGroup"/>'s options, that was voted for.
  /// </summary>
  public int OptionIndex { get; set; }
}
