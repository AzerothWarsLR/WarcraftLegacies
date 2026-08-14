using System;

namespace MacroTools.UserInterface.Voting;

public sealed class VoteOption
{
  public required string Name { get; init; }

  public string? Description { get; init; }

  public int VoteOffset { get; init; }

  public required Action OnChosen { get; init; }
}
