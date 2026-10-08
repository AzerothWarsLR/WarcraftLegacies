using System;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Paths;

namespace WarcraftLegacies.Source.GameLogic.HyjalPact;

/// <summary>
/// A faction's vote on the Pact of Hyjal. Accepting votes for it, declining votes against it, and letting it run out
/// counts as voting against it.
/// </summary>
public sealed class PactVotePath : FactionPath
{
  private readonly Action<Faction, bool> _onVote;

  public PactVotePath(string proposerName, float duration, Action<Faction, bool> onVote)
  {
    _onVote = onVote;
    Name = "Vote: The Pact of Hyjal";
    IconName = "TreeOfEternity";
    Description = Loc.Format("{proposer} calls on the Horde, the Night Elves and Theramore to set aside their wars and stand together against the Burning Legion. Accept to join the pact, which forms if a majority agrees. Not voting counts as voting against it.",
      ("{proposer}", proposerName));
    DeclineDescription = "Stay out of the pact. Your team and your wars stay as they are.";
    OfferDuration = duration;
    CommitDuration = 0;
    IsVote = true;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _onVote(faction, true);

  /// <inheritdoc />
  protected override void OnDeclined(Faction faction) => _onVote(faction, false);
}
