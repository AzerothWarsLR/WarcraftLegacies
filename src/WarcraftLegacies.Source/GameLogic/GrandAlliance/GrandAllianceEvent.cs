using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.GameLogic.GrandAlliance;

/// <summary>
/// Once one half of the Alliance is broken, the other half rallies to it. The North and South Alliance become the
/// Grand Alliance, sharing one handicap and a Power.
/// </summary>
public sealed class GrandAllianceEvent : WorldEvent
{
  private const float Radius = 1200;
  private const float LifePerSecond = 0.01f;
  private const float ManaPerSecond = 0.01f;

  private readonly ObjectiveTriggered _allianceBroken;
  private readonly TeamBreakWatch _northWatch;
  private readonly TeamBreakWatch _southWatch;
  private readonly StrengthInUnity _power = new(Radius, LifePerSecond, ManaPerSecond)
  {
    Name = "Strength in Unity",
    IconName = "GrandAlliance"
  };

  private readonly HashSet<Faction> _members = new();

  public GrandAllianceEvent()
  {
    Name = "The Grand Alliance";
    IconName = "GrandAlliance";
    Description = "The Alliance has been broken once, and it will not be broken again. The kingdoms of the north and south set aside their old quarrels and stand as one Grand Alliance, and wherever its banners still fly, its soldiers find shelter and strength.";
    WarningDuration = 60;

    _allianceBroken = new ObjectiveTriggered("The North or South Alliance is broken: one of its founding members has left it or been defeated");
    AddRequirement(_allianceBroken);
    _northWatch = new TeamBreakWatch(TeamSetup.NorthAlliance, _ => true, OnAllianceBroken);
    _southWatch = new TeamBreakWatch(TeamSetup.SouthAlliance, _ => true, OnAllianceBroken);
  }

  /// <inheritdoc />
  protected override void OnHappened()
  {
    var bloc = TeamSetup.NorthAlliance.Bloc;
    if (bloc == null)
    {
      return;
    }

    bloc.Rename("Grand Alliance");
    bloc.HideTeams();
    TeamHandicaps.Pool(bloc);
    TeamChanges.OnAnyTeamChanged(RefreshMembers);
    PlayerData.FactionChange += _ => RefreshMembers();
    FactionManager.FactionRegistered += _ => RefreshMembers();
    RefreshMembers();
  }

  private void OnAllianceBroken()
  {
    if (TeamSetup.NorthAlliance.UndefeatedPlayerCount > 0 && TeamSetup.SouthAlliance.UndefeatedPlayerCount > 0)
    {
      _allianceBroken.Trigger();
    }
  }

  /// <summary>Gives the Power to every faction in the Grand Alliance, and takes it from anyone who has left.</summary>
  private void RefreshMembers()
  {
    var bloc = TeamSetup.NorthAlliance.Bloc;
    foreach (var faction in FactionManager.GetAllFactions())
    {
      var factionPlayer = faction.Player;
      var isMember = bloc != null && factionPlayer != null && faction.ScoreStatus != ScoreStatus.Defeated &&
                     factionPlayer.GetPlayerData().Team?.Bloc == bloc;
      if (isMember && _members.Add(faction))
      {
        faction.AddPower(_power);
      }
      else if (!isMember && _members.Remove(faction))
      {
        faction.RemovePower(_power);
      }
    }
  }
}
