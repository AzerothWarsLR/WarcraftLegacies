using System;
using System.Collections.Generic;
using static War3Api.Common; 

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  public sealed class Team
  {
    private readonly List<Faction> _factions = new();
    private readonly List<Faction> _invitees = new();

    public Team(string name)
    {
      Name = name;
      TeamCreate?.Invoke(this, this);
    }

    public int ControlPointCount
    {
      get
      {
        var total = 0;
        foreach (var faction in _factions) 
          total += faction.Player.GetControlPointCount();

        return total;
      }
    }

    public string Name { get; }

    /// <summary>
    ///   Returns the number of real <see cref="player" />s within this <see cref="Team" />.
    /// </summary>
    public int PlayerCount
    {
      get
      {
        var total = 0;
        foreach (var faction in _factions)
          if (faction.Player != null)
            total++;

        return total;
      }
    }

    /// <summary>
    ///   Music that plays when this <see cref="Team" /> wins the game.
    /// </summary>
    public string VictoryMusic { get; init; }

    public static event EventHandler<Team>? TeamCreate;

    public static event EventHandler<Team>? TeamSizeChange;

    /// <summary>
    ///   Creates a <see cref="force" /> containing all <see cref="player" />s within this <see cref="Team" />.
    /// </summary>
    /// <returns></returns>
    public force CreateForceFromPlayers()
    {
      var newForce = CreateForce();
      foreach (var faction in _factions)
        if (faction.Player != null)
          ForceAddPlayer(newForce, faction.Player);
      return newForce;
    }

    public IEnumerable<Faction> GetAllFactions()
    {
      foreach (var faction in _factions) yield return faction;
    }

    public void RemoveFaction(Faction faction)
    {
      if (!_factions.Contains(faction))
        throw new Exception("Attempted to remove non-present faction " + faction.Name + " from team " + Name);
      _factions.Remove(faction);
      if (faction.Player != null)
        UnallyPlayer(faction.Player);
      TeamSizeChange?.Invoke(this, this);
    }

    public void AddFaction(Faction faction)
    {
      var i = 0;
      if (_factions.Contains(faction))
        throw new Exception("Attempted to add already present faction " + faction.Name + " to team " + Name);
      _factions.Add(faction);
      if (faction.Player != null)
        AllyPlayer(faction.Player);
      TeamSizeChange?.Invoke(this, this);
    }

    /// <summary>
    ///   Causes every <see cref="player" /> in the <see cref="Team" /> to ally the given player, and vise-versa.
    /// </summary>
    /// <param name="whichPlayer"></param>
    public void AllyPlayer(player whichPlayer)
    {
      foreach (var faction in _factions)
      {
        SetPlayerAllianceStateBJ(whichPlayer, faction.Player, bj_ALLIANCE_ALLIED_VISION);
        SetPlayerAllianceStateBJ(faction.Player, whichPlayer, bj_ALLIANCE_ALLIED_VISION);
      }
    }

    /// <summary>
    ///   Causes every <see cref="player" /> in the <see cref="Team" /> to unally the given player, and vise-versa.
    /// </summary>
    /// <param name="whichPlayer"></param>
    public void UnallyPlayer(player whichPlayer)
    {
      foreach (var faction in _factions)
      {
        SetPlayerAllianceStateBJ(whichPlayer, faction.Player, bj_ALLIANCE_UNALLIED);
        SetPlayerAllianceStateBJ(faction.Player, whichPlayer, bj_ALLIANCE_UNALLIED);
      }
    }

    /// <summary>
    ///   Revokes an invite sent to a player.
    /// </summary>
    public void Uninvite(Faction whichFaction)
    {
      if (_invitees.Contains(whichFaction))
      {
        DisplayText(whichFaction.ColoredName + "|r is no longer invited to join the " + Name + ".");
        DisplayTextToPlayer(whichFaction.Player, 0, 0, "You are no longer invited to join the " + Name + ".");
        _invitees.Remove(whichFaction);
      }
    }

    /// <summary>
    ///   Sends an invite to this team to a player, which they can choose to accept at a later date.
    /// </summary>
    public void Invite(Faction whichFaction)
    {
      if (!_factions.Contains(whichFaction) && !_invitees.Contains(whichFaction))
      {
        //if (GetLocalPlayer() == whichFaction.Player || ContainsPlayer(GetLocalPlayer()))
        //StartSound("Sound\Interface\ArrangedTeamInvitation.wav");
        DisplayText(whichFaction.ColoredName + "|r has been invited to join the " + Name + ".");
        DisplayTextToPlayer(whichFaction.Player, 0, 0,
          "You have been invited to join the " + Name + ". Type -join " + Name + " to accept.");
        _invitees.Add(whichFaction);
      }
    }

    /// <summary>
    ///   Displays the provided text to all <see cref="player" />s in the <see cref="Team" />.
    /// </summary>
    /// <param name="text"></param>
    public void DisplayText(string text)
    {
      foreach (var faction in _factions) DisplayTextToPlayer(faction.Player, 0, 0, text);
    }

    /// <summary>
    ///   Checks whether or not the given <see cref="Faction" /> has been invited to this <see cref="Team" />.
    /// </summary>
    public bool IsFactionInvited(Faction whichFaction)
    {
      return _invitees.Contains(whichFaction);
    }

    /// <summary>
    ///   Checks whether or not the given <see cref="player" /> is in this <see cref="Team" />.
    /// </summary>
    /// <param name="whichPlayer"></param>
    /// <returns></returns>
    public bool ContainsPlayer(player whichPlayer)
    {
      foreach (var faction in _factions)
        if (faction.Player != null && faction.Player == whichPlayer)
          return true;
      return false;
    }

    public bool ContainsFaction(Faction faction)
    {
      return _factions.Contains(faction);
    }
  }
}