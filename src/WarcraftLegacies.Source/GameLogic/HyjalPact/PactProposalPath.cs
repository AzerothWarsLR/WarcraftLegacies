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
    Description = "Archimonde has come, and no single people can stand against him. Call on the Horde, the night elves and Theramore to set aside their wars and make a stand at Mount Hyjal. They have 3 minutes to answer, and the pact forms if most agree, your own voice among them.";
    CommitDuration = 0;
    IsVote = true;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _onProposed(faction);
}
