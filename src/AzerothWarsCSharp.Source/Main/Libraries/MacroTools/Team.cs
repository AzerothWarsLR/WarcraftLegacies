public class Team{
  
    Event OnTeamCreate = 0;
    Event OnTeamSizeChange = 0;
    Event TeamScoreStatusChanged
  


    readonly static StringTable teamsByName;
    private static thistype[] teamsByIndex;
    private static int teamCount = 0;
    readonly static thistype triggerTeam = 0;

    private string name = null;
    private Set invitees ;//Factions invited to join this Team
    private Set factions;
    private int scoreStatus;
    private string victoryMusic;

    void operator VictoryMusic=(string whichMusic ){
      this.victoryMusic = whichMusic;
    }

    string operator VictoryMusic( ){
      ;.victoryMusic;
    }

    integer operator ScoreStatus( ){
      ;.scoreStatus;
    }

    integer operator CapitalCount( ){
      int total = 0;
      int i = 0;
      Legend loopLegend;
      while(true){
        if ( i == Legend.Count){ break; }
        loopLegend = Legend.ByIndex(i);
        if (loopLegend != 0 && loopLegend.Unit != null && loopLegend.OwningFaction.Team == this && loopLegend.IsCapital == true && UnitAlive(loopLegend.Unit)){
          total = total + 1;
        }
        i = i + 1;
      }
      return total;
    }

    integer operator ControlPointCount( ){
      int total = 0;
      int i = 0;
      while(true){
        if ( i == this.FactionCount){ break; }
        if (this.GetFactionByIndex(i).Person != 0){
          total = total + this.GetFactionByIndex(i).Person.ControlPointCount;
        }
        i = i + 1;
      }
      return total;
    }

    string operator Name( ){
      ;.name;
    }

    integer operator FactionCount( ){
      ;.factions.size;
    }

    //Only includes filled Factions
    integer operator PlayerCount( ){
      int i = 0;
      int total = 0;
      Faction loopFaction;
      while(true){
        if ( i == factions.size){ break; }
        loopFaction = factions[i];
        if (loopFaction.Person != 0 && loopFaction.ScoreStatus != SCORESTATUS_DEFEATED){
          total = total + 1;
        }
        i = i + 1;
      }
      return total;
    }

    Faction GetFactionByIndex(int index ){
      ;.factions[index];
    }

    void RemoveFaction(Faction faction ){
      int i = 0;
      if (!this.factions.contains(faction)){
        BJDebugMsg("Attempted to remove non-present faction " + faction.Name + " from team " + this.name);
      }
      this.factions.remove(faction);
      //Make all present factions ally the new faction and visa-versa
      if (faction.Person != 0){
        this.UnallyPlayer(faction.Player);
      }
      //
      thistype.triggerTeam = this;
      OnTeamSizeChange.fire();
    }

    void AddFaction(Faction faction ){
      int i = 0;
      if (this.factions.contains(faction)){
        BJDebugMsg("Attempted to add already present faction " + faction.Name + " to team " + this.name);
      }
      this.factions.add(faction);
      //Make all present factions ally the new faction and visa-versa
      if (faction.Person != 0){
        this.AllyPlayer(faction.Player);
      }
      //
      thistype.triggerTeam = this;
      OnTeamSizeChange.fire();
    }

    void AllyPlayer(player whichPlayer ){
      int i = 0;
      while(true){
        if ( i == this.FactionCount){ break; }
        SetPlayerAllianceStateBJ(whichPlayer, this.GetFactionByIndex(i).Player, bj_ALLIANCE_ALLIED_VISION);
        SetPlayerAllianceStateBJ(this.GetFactionByIndex(i).Player, whichPlayer, bj_ALLIANCE_ALLIED_VISION);
        i = i + 1;
      }
      thistype.triggerTeam = this;
    }

    void UnallyPlayer(player whichPlayer ){
      int i = 0;
      while(true){
        if ( i == this.FactionCount){ break; }
        SetPlayerAllianceStateBJ(whichPlayer, this.GetFactionByIndex(i).Player, bj_ALLIANCE_UNALLIED);
        SetPlayerAllianceStateBJ(this.GetFactionByIndex(i).Player, whichPlayer, bj_ALLIANCE_UNALLIED);
        i = i + 1;
      }
      thistype.triggerTeam = this;
    }

    //Revokes an invite sent to a player
    void Uninvite(Faction whichFaction ){
      if (this.invitees.contains(whichFaction)){
        this.DisplayText(whichFaction.prefixCol + whichFaction.name + "|r is no longer invited to join the " + this.name + ".");
        DisplayTextToPlayer(whichFaction.Player, 0, 0, "You are no longer invited to join the " + this.name + ".");
        this.invitees.remove(whichFaction);
      }
    }

    //Sends an invite to this team to a player, which they can choose to accept at a later date
    void Invite(Faction whichFaction ){
      if (!this.factions.contains(whichFaction) && !this.invitees.contains(whichFaction) && whichFaction.CanBeInvited == true){
        if (GetLocalPlayer() == whichFaction.Player || this.factions.contains(Person.ByHandle(GetLocalPlayer()))){
          StartSound(gg_snd_ArrangedTeamInvitation);
        }
        this.DisplayText(whichFaction.prefixCol + whichFaction.name + "|r has been invited to join the " + this.name + ".");
        DisplayTextToPlayer(whichFaction.Player, 0, 0, "You have been invited to join the " + this.name + ". Type -join " + this.name + " to accept.");
        this.invitees.add(whichFaction);
      }
    }

    void DisplayText(string text ){
      int i = 0;
      while(true){
      if ( i == factions.size){ break; }
        DisplayTextToPlayer(Faction(this.factions[i]).Player, 0, 0, text);
        i = i + 1;
      }
    }

    force CreateForceFromPlayers( ){
      int i = 0;
      force newForce = CreateForce();
      Faction loopFaction;
      while(true){
        if ( i == factions.size){ break; }
        loopFaction = factions[i];
        if (loopFaction.Person != 0 && loopFaction.ScoreStatus != SCORESTATUS_DEFEATED){
          ForceAddPlayer(newForce, Faction(factions[i]).Player);
        }
        i = i + 1;
      }
      return newForce;
    }

    boolean IsFactionInvited(Faction whichFaction ){
      ;.invitees.contains(whichFaction);
    }

    boolean ContainsPlayer(player whichPlayer ){
      int i = 0;
      while(true){
      if ( i == factions.size){ break; }
        if (Faction(this.factions[i]).Player == whichPlayer){
          return true;
        }
        i = i + 1;
      }
      return false;
    }

    boolean ContainsFaction(Faction faction ){
      ;.factions.contains(faction);
    }

    static integer operator Count( ){
      ;type.teamCount;
    }

    static thistype ByName(string name ){
      ;type.teamsByName[name];
    }

    static thistype ByIndex(int index ){
      ;type.teamsByIndex[index];
    }

     Team (string name ){


      this.name = name;
      this.factions = Set.create("factions in " + name);
      this.invitees = Set.create("invitees of " + name);

      if (thistype.teamsByName[StringCase(name, false)] == 0){
        thistype.teamsByName[StringCase(name, false)] = this;
      }else {
        BJDebugMsg("Error: created team that already exists with name " + name);
        return 0;
      }

      thistype.teamsByIndex[teamCount] = this;
      thistype.teamCount = thistype.teamCount + 1;

      thistype.triggerTeam = this;
      OnTeamCreate.fire();

      ;;
    }

    private static void onInit( ){
      thistype.teamsByName = StringTable.create();
    }


  static Team GetTriggerTeam( ){
    return Team.triggerTeam;
  }

  private static void OnInit( ){
    OnTeamCreate = Event.create();
    OnTeamSizeChange = Event.create();
    TeamScoreStatusChanged = Event.create();
  }

}
