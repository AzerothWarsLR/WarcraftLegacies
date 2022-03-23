using System;
using System.Collections.Generic;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  public class Team
  {
    private static Dictionary<string, Team> teamsByName;
    private static thistype[] teamsByIndex;
    private static readonly int teamCount = 0;
    private static readonly thistype triggerTeam = 0;
    private Set factions;

    private Set invitees; //Factions invited to join this Team

    public static event EventHandler<Team> TeamCreate;
    
    public static event EventHandler<Team> TeamSizeChange;

    public static event EventHandler<Team> TeamScoreStatusChanged;
    
    private string victoryMusic;

    public ScoreStatus ScoreStatus { get; } = ScoreStatus.Undefeated;
    
    public string VictoryMusic { get; init; }

    private CapitalCount()
    {
      var total = 0;
      var i = 0;
      Legend loopLegend;
      while (true)
      {
        if (i == Legend.Count) break;
        loopLegend = Legend.ByIndex(i);
        if (loopLegend != 0 && loopLegend.Unit != null && loopLegend.OwningFaction.Team == this &&
            loopLegend.IsCapital && UnitAlive(loopLegend.Unit)) total = total + 1;
        i = i + 1;
      }

      return total;
    }

    private ControlPointCount()
    {
      var total = 0;
      var i = 0;
      while (true)
      {
        if (i == this.FactionCount) break;
        if (GetFactionByIndex(i).Person != 0) total = total + GetFactionByIndex(i).Person.ControlPointCount;
        i = i + 1;
      }

      return total;
    }

    private FactionCount()
    {
      ;.factions.size;
    }

    private Count()
    {
      ;
      type.teamCount;
    }

    public Team(string name)
    {
      Name = name;
      factions = Set.create("factions in " + name);
      invitees = Set.create("invitees of " + name);

      if (thistype.teamsByName[StringCase(name, false)] == 0)
      {
        thistype.teamsByName[StringCase(name, false)] = this;
      }
      else
      {
        BJDebugMsg("Error: created team that already exists with name " + name);
        return 0;
      }

      thistype.teamsByIndex[teamCount] = this;
      thistype.teamCount = thistype.teamCount + 1;

      thistype.triggerTeam = this;
      TeamCreate.fire();
    }

    public string Name { get; }

    //Only includes filled Factions
    public int PlayerCount
    {
      get
      {
        var i = 0;
        var total = 0;
        Faction loopFaction;
        while (true)
        {
          if (i == factions.size) break;

          loopFaction = factions[i];
          if (loopFaction.Person != 0 && loopFaction.ScoreStatus != SCORESTATUS_DEFEATED) total = total + 1;

          i = i + 1;
        }

        return total;
      }
    }

    public static IEnumerable<Team> GetAllTeams()
    {
    }

    public static Team Register(Team team)
    {
      throw new NotImplementedException();
    }

    public static bool TeamWithNameExists(string teamName)
    {
      return teamsByName.ContainsKey(teamName);
    }

    public static Team GetTeamByName(string teamName)
    {
      return teamsByName[teamName];
    }

    public IEnumerable<Faction> GetAllFactions()
    {
      foreach (var faction in factions) yield return faction;
    }

    void operator VictoryMusic=(string whichMusic ) {
      victoryMusic = whichMusic;
    }

    string operator

    integer operator

    integer operator

    integer operator

    integer operator

    private Faction GetFactionByIndex(int index)
    {
      ;.factions[index];
    }

    public void RemoveFaction(Faction faction)
    {
      var i = 0;
      if (!factions.contains(faction))
        BJDebugMsg("Attempted to remove non-present faction " + faction.Name + " from team " + Name);
      factions.remove(faction);
      //Make all present factions ally the new faction and visa-versa
      if (faction.Person != 0) UnallyPlayer(faction.Player);
      //
      thistype.triggerTeam = this;
      OnTeamSizeChange.fire();
    }

    public void AddFaction(Faction faction)
    {
      var i = 0;
      if (factions.contains(faction))
        BJDebugMsg("Attempted to add already present faction " + faction.Name + " to team " + Name);
      factions.add(faction);
      //Make all present factions ally the new faction and visa-versa
      if (faction.Person != 0) AllyPlayer(faction.Player);
      //
      thistype.triggerTeam = this;
      OnTeamSizeChange.fire();
    }

    public void AllyPlayer(player whichPlayer)
    {
      var i = 0;
      while (true)
      {
        if (i == this.FactionCount) break;
        SetPlayerAllianceStateBJ(whichPlayer, GetFactionByIndex(i).Player, bj_ALLIANCE_ALLIED_VISION);
        SetPlayerAllianceStateBJ(GetFactionByIndex(i).Player, whichPlayer, bj_ALLIANCE_ALLIED_VISION);
        i = i + 1;
      }

      thistype.triggerTeam = this;
    }

    public void UnallyPlayer(player whichPlayer)
    {
      var i = 0;
      while (true)
      {
        if (i == this.FactionCount) break;
        SetPlayerAllianceStateBJ(whichPlayer, GetFactionByIndex(i).Player, bj_ALLIANCE_UNALLIED);
        SetPlayerAllianceStateBJ(GetFactionByIndex(i).Player, whichPlayer, bj_ALLIANCE_UNALLIED);
        i = i + 1;
      }

      thistype.triggerTeam = this;
    }

    //Revokes an invite sent to a player
    public void Uninvite(Faction whichFaction)
    {
      if (invitees.contains(whichFaction))
      {
        DisplayText(whichFaction.prefixCol + whichFaction.name + "|r is no longer invited to join the " + Name + ".");
        DisplayTextToPlayer(whichFaction.Player, 0, 0, "You are no longer invited to join the " + Name + ".");
        invitees.remove(whichFaction);
      }
    }

    //Sends an invite to this team to a player, which they can choose to accept at a later date
    public void Invite(Faction whichFaction)
    {
      if (!factions.contains(whichFaction) && !invitees.contains(whichFaction) && whichFaction.CanBeInvited == true)
      {
        if (GetLocalPlayer() == whichFaction.Player || factions.contains(Person.ByHandle(GetLocalPlayer())))
          StartSound(gg_snd_ArrangedTeamInvitation);
        DisplayText(whichFaction.prefixCol + whichFaction.name + "|r has been invited to join the " + Name + ".");
        DisplayTextToPlayer(whichFaction.Player, 0, 0,
          "You have been invited to join the " + Name + ". Type -join " + Name + " to accept.");
        invitees.add(whichFaction);
      }
    }

    public void DisplayText(string text)
    {
      var i = 0;
      while (true)
      {
        if (i == factions.size) break;
        DisplayTextToPlayer(Faction(factions[i]).Player, 0, 0, text);
        i = i + 1;
      }
    }

    public force CreateForceFromPlayers()
    {
      var i = 0;
      force newForce = CreateForce();
      Faction loopFaction;
      while (true)
      {
        if (i == factions.size) break;
        loopFaction = factions[i];
        if (loopFaction.Person != 0 && loopFaction.ScoreStatus != SCORESTATUS_DEFEATED)
          ForceAddPlayer(newForce, Faction(factions[i]).Player);
        i = i + 1;
      }

      return newForce;
    }

    public bool IsFactionInvited(Faction whichFaction)
    {
      ;.invitees.contains(whichFaction);
    }

    private bool ContainsPlayer(player whichPlayer)
    {
      var i = 0;
      while (true)
      {
        if (i == factions.size) break;
        if (Faction(factions[i]).Player == whichPlayer) return true;
        i = i + 1;
      }

      return false;
    }

    public bool ContainsFaction(Faction faction)
    {
      ;.factions.contains(faction);
    }

    static integer operator

    private static thistype ByName(string name)
    {
      ;
      type.teamsByName[name];
    }

    private static thistype ByIndex(int index)
    {
      ;
      type.teamsByIndex[index];
    }

    private static void onInit()
    {
      thistype.teamsByName = StringTable.create();
    }


    private static Team GetTriggerTeam()
    {
      return triggerTeam;
    }

    public static void Setup()
    {
      TeamCreate = Event.create();
      OnTeamSizeChange = Event.create();
      TeamScoreStatusChanged = Event.create();
    }
  }
}