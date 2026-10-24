using System;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Paths;

namespace WarcraftLegacies.Source.GameLogic.HyjalPact;

/// <summary>A faction's vote on the Pact of Hyjal.</summary>
public sealed class PactVotePath : FactionPath
{
  private readonly Action<Faction, bool> _onVote;

  public PactVotePath(string proposerName, float duration, Action<Faction, bool> onVote)
  {
    _onVote = onVote;
    Name = "Vote: The Pact of Hyjal";
    IconName = "TreeOfEternity";
    Description = Loc.Format("{proposer} calls on the Horde, the night elves and Theramore to set aside their wars and make a stand against the Burning Legion at Mount Hyjal. The pact forms if most agree, and silence counts as refusal.",
      ("{proposer}", proposerName));
    DeclineDescription = "Let others make their peace. You will face the Legion your own way, beside your own allies.";
    OfferDuration = duration;
    CommitDuration = 0;
    IsVote = true;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _onVote(faction, true);

  /// <inheritdoc />
  protected override void OnDeclined(Faction faction) => _onVote(faction, false);
}
