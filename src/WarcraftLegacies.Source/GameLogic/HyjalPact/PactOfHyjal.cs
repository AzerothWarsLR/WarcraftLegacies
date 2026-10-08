using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Sounds;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Theramore;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.GameLogic.HyjalPact;

/// <summary>
/// The Horde, the Night Elves and Theramore set aside their wars to stand against the Burning Legion at Mount Hyjal.
/// <para>Once Theramore exists and Archimonde has been summoned, any of them can propose the pact, which starts a vote.
/// If a majority agrees, everyone who voted for it moves onto a new Pact of Hyjal team. A failed vote can be proposed
/// again after a cooldown.</para>
/// </summary>
public sealed class PactOfHyjal : WorldEvent
{
  private const float VoteDuration = 180;
  private const float RetryCooldown = 300;

  private readonly ObjectiveTriggered _theramoreFounded;
  private readonly ObjectiveTriggered _archimondeSummoned;
  private readonly ObjectiveTriggered _votePassed;
  private readonly Dictionary<Faction, PactProposalPath> _proposals = new();
  private readonly Dictionary<Faction, PactVotePath> _ballots = new();
  private readonly List<Faction> _voters = new();
  private readonly List<Faction> _votedFor = new();
  private readonly List<Faction> _votedAgainst = new();
  private readonly Dictionary<player, Team> _originalTeams = new();
  private bool _voting;
  private bool _onCooldown;
  private timer? _timer;

  /// <summary>Whether a vote on the pact is running.</summary>
  public bool IsVoting => _voting;

  /// <summary>The team the pact's members are on once it has formed.</summary>
  public Team? PactTeam { get; private set; }

  public PactOfHyjal(LegionFaction legion, QuestData summonArchimonde)
  {
    Name = "The Pact of Hyjal";
    IconName = "TreeOfEternity";
    Description = "The Horde, the Night Elves and Theramore set aside their wars and stand together against the Burning Legion. Those who agree join the Pact of Hyjal's team until Archimonde falls.";

    _theramoreFounded = new ObjectiveTriggered("Theramore has been founded");
    _archimondeSummoned = new ObjectiveTriggered("The Legion has summoned Archimonde");
    _votePassed = new ObjectiveTriggered("A majority of the Horde, the Night Elves and Theramore vote for the pact");
    AddRequirement(_theramoreFounded);
    AddRequirement(_archimondeSummoned);
    AddRequirement(_votePassed);

    foreach (var faction in FactionManager.GetAllFactions())
    {
      OnFactionRegistered(faction);
    }

    FactionManager.FactionRegistered += OnFactionRegistered;
    legion.QuestProgressChanged += args =>
    {
      if (args.Quest == summonArchimonde && args.Quest.Progress == QuestProgress.Complete)
      {
        OnPrerequisiteMet(_archimondeSummoned);
      }
    };
    TeamChanges.OnAnyTeamChanged(RefreshProposals);
  }

  /// <summary>Meets the requirements for proposing the pact straight away. Meant for testing.</summary>
  public void ForcePrerequisites()
  {
    OnPrerequisiteMet(_theramoreFounded);
    OnPrerequisiteMet(_archimondeSummoned);
  }

  /// <summary>Makes every faction that hasn't voted yet vote for the pact. Meant for testing.</summary>
  public void ForceVotesFor()
  {
    foreach (var voter in new List<Faction>(_voters))
    {
      Vote(voter, true);
    }
  }

  /// <inheritdoc />
  protected override void OnHappened()
  {
    var pactTeam = new Team("Pact of Hyjal");
    FactionManager.Register(pactTeam);
    PactTeam = pactTeam;
    TeamHandicaps.SetStartingSize(pactTeam, 0);
    RoleplayFronts.AddTeamRivalry((teamA, teamB) =>
      (teamA == pactTeam && ContainsLegion(teamB)) || (teamB == pactTeam && ContainsLegion(teamA)));
    var capacity = TeamChanges.Capacity;
    TeamChanges.Capacity = team => team == pactTeam ? int.MaxValue : capacity(team);

    var memberNames = new List<string>();
    foreach (var member in _votedFor)
    {
      var memberPlayer = member.Player;
      var memberTeam = memberPlayer?.GetPlayerData().Team;
      if (memberPlayer == null || memberTeam == null)
      {
        continue;
      }

      _originalTeams[memberPlayer] = memberTeam;
      TeamChanges.Move(memberPlayer, pactTeam);
      memberNames.Add(member.ColoredName);
    }

    Outcome = Loc.Format("{members} joined the Pact of Hyjal.", ("{members}", string.Join(", ", memberNames)));
  }

  private static bool ContainsLegion(Team team)
  {
    foreach (var faction in team.GetAllFactions())
    {
      if (faction is LegionFaction)
      {
        return true;
      }
    }

    return false;
  }

  private void OnFactionRegistered(Faction faction)
  {
    if (faction is TheramoreFaction)
    {
      OnPrerequisiteMet(_theramoreFounded);
    }
  }

  private void OnPrerequisiteMet(ObjectiveTriggered prerequisite)
  {
    if (prerequisite.Progress != QuestProgress.Complete)
    {
      prerequisite.Trigger();
    }

    RefreshProposals();
  }

  private bool CanBeProposed() =>
    State == WorldEventState.Upcoming && !_voting && !_onCooldown &&
    _theramoreFounded.Progress == QuestProgress.Complete && _archimondeSummoned.Progress == QuestProgress.Complete;

  /// <summary>
  /// The factions that get a say: everyone on the Horde and Night Elf teams, and Theramore.
  /// </summary>
  private static List<Faction> GetEligibleFactions()
  {
    var eligible = new List<Faction>();
    foreach (var faction in FactionManager.GetAllFactions())
    {
      var factionPlayer = faction.Player;
      if (factionPlayer == null || faction.ScoreStatus == ScoreStatus.Defeated)
      {
        continue;
      }

      var team = factionPlayer.GetPlayerData().Team;
      if (team == TeamSetup.Horde || team == TeamSetup.NightElves || faction is TheramoreFaction)
      {
        eligible.Add(faction);
      }
    }

    return eligible;
  }

  /// <summary>Gives every eligible faction a way to propose the pact, and takes it away from everyone else.</summary>
  private void RefreshProposals()
  {
    var eligible = CanBeProposed() ? GetEligibleFactions() : new List<Faction>();
    foreach (var faction in new List<Faction>(_proposals.Keys))
    {
      if (!eligible.Contains(faction))
      {
        faction.RemovePath(_proposals[faction]);
        _proposals.Remove(faction);
      }
    }

    foreach (var faction in eligible)
    {
      if (!_proposals.ContainsKey(faction))
      {
        var proposal = new PactProposalPath(StartVote);
        _proposals[faction] = proposal;
        faction.AddPath(proposal);
      }
    }
  }

  private void StartVote(Faction proposer)
  {
    if (!CanBeProposed())
    {
      return;
    }

    _voting = true;
    RefreshProposals();
    _voters.Clear();
    _votedFor.Clear();
    _votedAgainst.Clear();
    _voters.AddRange(GetEligibleFactions());
    if (!_voters.Contains(proposer))
    {
      _voters.Add(proposer);
    }

    Instigator = proposer.ColoredName;
    var message = Loc.Format("{proposer} proposes the Pact of Hyjal. Everyone on the Horde and Night Elf teams, and Theramore, has 3 minutes to vote in the Paths menu.",
      ("{proposer}", proposer.ColoredName));
    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo($"\n|cffffcc00{Loc.Get("PACT PROPOSED")}|r - {message}");
    }

    SoundLibrary.Discovered.Start();
    foreach (var voter in _voters)
    {
      if (voter == proposer)
      {
        continue;
      }

      var ballot = new PactVotePath(proposer.ColoredName, VoteDuration, Vote);
      _ballots[voter] = ballot;
      voter.AddPath(ballot);
    }

    Vote(proposer, true);
    if (_voting)
    {
      _timer = timer.Create();
      _timer.Start(VoteDuration, false, EndVote);
    }
  }

  private void Vote(Faction voter, bool inFavour)
  {
    if (!_voting || !_voters.Contains(voter) || _votedFor.Contains(voter) || _votedAgainst.Contains(voter))
    {
      return;
    }

    if (inFavour)
    {
      _votedFor.Add(voter);
    }
    else
    {
      _votedAgainst.Add(voter);
    }

    var tally = Loc.Format("{voter} votes {choice} the Pact of Hyjal ({for} for, {against} against, {waiting} still to vote).",
      ("{voter}", voter.ColoredName), ("{choice}", Loc.Get(inFavour ? "for" : "against")),
      ("{for}", _votedFor.Count.ToString()), ("{against}", _votedAgainst.Count.ToString()),
      ("{waiting}", (_voters.Count - _votedFor.Count - _votedAgainst.Count).ToString()));
    foreach (var faction in _voters)
    {
      faction.Player?.DisplayTextTo(tally);
    }

    if (_votedFor.Count + _votedAgainst.Count >= _voters.Count)
    {
      EndVote();
    }
  }

  private void EndVote()
  {
    if (!_voting)
    {
      return;
    }

    _voting = false;
    if (_timer != null)
    {
      _timer.Dispose();
      _timer = null;
    }

    foreach (var ballot in _ballots)
    {
      ballot.Key.RemovePath(ballot.Value);
    }

    _ballots.Clear();
    if (_votedFor.Count * 2 > _voters.Count)
    {
      _votePassed.Trigger();
      return;
    }

    var message = Loc.Format("The Pact of Hyjal was voted down ({for} for, out of {voters}). It can be proposed again in 5 minutes.",
      ("{for}", _votedFor.Count.ToString()), ("{voters}", _voters.Count.ToString()));
    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo($"\n|cffff0000{Loc.Get("PACT REJECTED")}|r - {message}");
    }

    Instigator = null;
    _onCooldown = true;
    _timer = timer.Create();
    _timer.Start(RetryCooldown, false, () =>
    {
      _onCooldown = false;
      if (_timer != null)
      {
        _timer.Dispose();
        _timer = null;
      }

      RefreshProposals();
    });
  }
}
