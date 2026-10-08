using System;
using MacroTools.Factions;
using MacroTools.Paths;

namespace WarcraftLegacies.Source.GameLogic.HyjalPact;

/// <summary>
/// Lets a faction call a vote on the Pact of Hyjal.
/// </summary>
public sealed class PactProposalPath : FactionPath
{
  private readonly Action<Faction> _onProposed;

  public PactProposalPath(Action<Faction> onProposed)
  {
    _onProposed = onProposed;
    Name = "Propose the Pact of Hyjal";
    IconName = "TreeOfEternity";
    Description = "Call on the Horde, the Night Elves and Theramore to set aside their wars and stand together against the Burning Legion at Mount Hyjal. Starts a 3 minute vote, and the pact forms if a majority agrees. You vote for it by proposing it.";
    CommitDuration = 0;
    IsVote = true;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _onProposed(faction);
}
