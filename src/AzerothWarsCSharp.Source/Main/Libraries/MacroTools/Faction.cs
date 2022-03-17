public class Faction{

  
    Event OnFactionCreate = 0;
    Event OnFactionTeamLeave
    Event OnFactionTeamJoin
    Event OnFactionGameLeave
    Event FactionNameChanged
    Event FactionIconChanged
    Event FactionScoreStatusChanged

    const int UNLIMITED = 200    ;//This is used in Persons and Faction for effectively unlimited unit production
    const int HERO_COST = 100    ;//For refunding
    private const float REFUND_PERCENT = 100          ;//How much gold and lumber is refunded from units that get refunded on leave
    private const float XP_TRANSFER_PERCENT = 100     ;//How much experience is transferred from heroes that leave the game)
  


    readonly static StringTable factionsByName;
    readonly static thistype triggerFaction = 0;
    readonly static thistype triggerFactionPrevTeam = 0;

    readonly string name = null;
    readonly playercolor playCol = null;
    readonly string prefixCol = null;
    readonly string icon = null;
    private int scoreStatus;

    private Person person = 0 ;//One-to-one relationship
    private Team team = 0 ;//The team this Faction is in
    readonly int xp = 0 ;//Stored by DistributeUnits and given out again by DistributeResources
    private int storedExperience ;//Actual hero experience being held by this Faction outside of its heroes

    private int defeatedResearch = 0  ;//This upgrade is researched for all players only if this Faction slot is defeated
    private int undefeatedResearch = 0 ;//This upgrade is researched for all players only if this Faction is undefeated


    readonly int[] objectList[100] ;//An index for objectLimits
    readonly int objectCount = 0;

    private Table objectLevels;
    private int[] objectLevelList[100];
    private int objectLevelCount = 0;

    private QuestData startingQuest;
    private int questCount = 0;
    private QuestData[] quests[100];

    private int[] unitTypeByCategory[100];

    public int StartingGold = 0;
    public int StartingLumber = 0;

    integer operator StoredExperience( ){
      ;.storedExperience;
    }

    void operator StoredExperience=(int value ){
      this.storedExperience = value;
    }

    integer operator ObjectLimitCount( ){
      ;.objectCount;
    }

    float operator Gold( ){
      return I2R(GetPlayerState(this.Player, PLAYER_STATE_RESOURCE_GOLD));
    }

    void operator Gold=(float value ){
      SetPlayerState(this.Player, PLAYER_STATE_RESOURCE_GOLD, R2I(value));
    }

    float operator Lumber( ){
      return I2R(GetPlayerState(this.Player, PLAYER_STATE_RESOURCE_LUMBER));
    }

    void operator Lumber=(float value ){
      SetPlayerState(this.Player, PLAYER_STATE_RESOURCE_LUMBER, R2I(value));
    }

    Team operator Team( ){
      ;.team;
    }

    private stub void OnTeamChange( ){

    }

    integer operator ScoreStatus( ){
      return scoreStatus;
    }

    void operator ScoreStatus=(int value ){
      int i = 0;
      //Change defeated/undefeated researches
      if (value == SCORESTATUS_DEFEATED){
        while(true){
          if ( i == MAX_PLAYERS){ break; }
          SetPlayerTechResearched(Player(i), this.defeatedResearch, 1);
          SetPlayerTechResearched(Player(i), this.undefeatedResearch, 0);
          i = i + 1;
        }
      }
      //Remove player from game if necessary
      if (value == SCORESTATUS_DEFEATED && this.Player != null){
        RemovePlayer(this.Player, PLAYER_GAME_RESULT_DEFEAT);
        SetPlayerState(this.Player, PLAYER_STATE_OBSERVER, 1);
        this.Leave();
       // call CreateFogModifierRectBJ( true, this.Player, FOG_OF_WAR_VISIBLE, GetPlayableMapRect() )
      }else if (value == SCORESTATUS_VICTORIOUS && this.Player != null){
        RemovePlayer(this.Player, PLAYER_GAME_RESULT_VICTORY);
      }
      this.scoreStatus = value;
      thistype.triggerFaction = this;
      FactionScoreStatusChanged.fire();
    }

    void operator Team=(Team team ){
      if (this.team != 0){
        thistype.triggerFaction = this;
        this.team.RemoveFaction(this);
        this.triggerFactionPrevTeam = this.team;
        this.team = 0;
        OnFactionTeamLeave.fire();
      }

      if (team != 0){
        team.AddFaction(this);
        this.team = team;
        thistype.triggerFaction = this;
        OnFactionTeamJoin.fire();
      }
      OnTeamChange();
    }

    stub string operator ControlPointCountAsString( ){
      return I2S(this.Person.ControlPointCount);
    }

    stub float operator Income( ){
      ;.Person.ControlPointValue;
    }

    string operator ColoredName( ){
      ;.prefixCol + this.name + "|r";
    }

    string operator Name( ){
      ;.name;
    }

    void operator Name=(string value ){
      thistype.factionsByName[this.name] = 0;
      this.name = value;
      thistype.triggerFaction = this;
      thistype.factionsByName[StringCase(value,false)] = this;
      FactionNameChanged.fire();
    }

    string operator Icon( ){
      ;.icon;
    }

    void operator Icon=(string value ){
      this.icon = value;
      thistype.triggerFaction = this;
      FactionIconChanged.fire();
    }

    player operator Player( ){
      ;.Person.Player;
    }

    Person operator Person( ){
      ;.person;
    }

    stub void OnPersonChange( ){

    }

    void operator Person=(Person value ){
      if (this.Player != null){
        this.Team.UnallyPlayer(this.Player);
        HideAllQuests();
        this.UnapplyObjects();
      }
      this.person = value;
      //Maintan referential integrity
      if (value == 0){
        return;
      }
      if (value.Faction != this){
        value.Faction = this;
      }
      this.Team.AllyPlayer(value.Player);
      ApplyObjects();
      ShowAllQuests();
    }

    QuestData operator StartingQuest( ){
      return startingQuest;
    }

    void operator StartingQuest=(QuestData questData ){
      startingQuest = questData;
    }

    stub boolean operator CanBeInvited( ){
      return true;
    }

    //Adds this Faction)s object limits and levels to its active Person
    private void ApplyObjects( ){
      Person person = this.Person;
      int i = 0;
      //Limits
      while(true){
        if ( i == this.objectCount){ break; }
        this.Person.ModObjectLimit(this.objectList[i], this.objectLimits[this.objectList[i]]);
        i = i + 1;
      }
      //Levels
      i = 0;
      while(true){
      if ( i == this.objectLevelCount){ break; }
        this.Person.SetObjectLevel(this.objectLevelList[i], this.objectLevels[this.objectLevelList[i]]);
        i = i + 1;
      }
    }

    //Removes this Faction)s object limits and levels from its active Person
    private void UnapplyObjects( ){
      Person person = this.person;
      int i = 0;
      //Limits
      while(true){
      if ( i == this.objectCount){ break; }
        this.Person.ModObjectLimit(this.objectList[i], -this.objectLimits[this.objectList[i]]);
        i = i + 1;
      }
      //Levels
      i = 0;
      while(true){
      if ( i == this.objectLevelCount){ break; }
        this.Person.SetObjectLevel(this.objectLevelList[i], 0);
        i = i + 1;
      }
      i = 0;
    }

    stub void Unally( ){
      string newTeamName = this.Name + " Pact";
      Team newTeam = 0;

      if (this.Team.PlayerCount > 1){
        newTeam = Team.teamsByName[newTeamName];
        if (newTeam == 0){
          newTeam = Team.create(newTeamName);
        }
        this.Team = newTeam;
      }
    }

    integer GetUnitTypeByCategory(int unitCategory ){
      ;.unitTypeByCategory[unitCategory];
    }

    //Shows all of the Faction)s quest, rendering them in the quest log,
    //showing them on the minimap, and showing them on the map.
    void ShowAllQuests( ){
      int i = 0;
      while(true){
        if ( i == this.questCount){ break; }
        if (GetLocalPlayer() == this.Player){
          quests[i].ShowLocal();
        }
        quests[i].ShowSync();
        i = i + 1;
      }
    }

    //Hides all of the Faction)s quests.
    void HideAllQuests( ){
      int i = 0;
      while(true){
        if ( i == this.questCount){ break; }
        if (GetLocalPlayer() == this.Player){
          quests[i].HideLocal();
        }
        quests[i].HideSync();
        i = i + 1;
      }
    }

    QuestData AddQuest(QuestData questData ){
      questData.Holder = this;
      this.quests[this.questCount] = questData;
      this.questCount = this.questCount + 1;
      if (GetLocalPlayer() == this.Player){
        questData.ShowLocal();
      }
      questData.ShowSync();
      return questData;
    }

    integer GetObjectLevel(int object ){
      ;.objectLevels[object];
    }

    private stub void OnSetObjectLevel(int object, int level ){

    }

    void SetObjectLevel(int object, int level ){
      if (!this.objectLevels.exists(object)){
        this.objectLevelList[this.objectLevelCount] = object;
        this.objectLevelCount = this.objectLevelCount + 1;
      }
      this.objectLevels[object] = level;
      if (this.Person != 0){
        this.Person.SetObjectLevel(object, level);
      }
      this.OnSetObjectLevel(object, level);
    }

    void ModObjectLimit(int id, int limit ){
      Person affectedPerson = 0;

      if (this.objectLimits.exists(id)){
        this.objectLimits[id] = this.objectLimits[id] + limit;
      }else {
        this.objectLimits[id] = limit;
        this.objectList[this.objectCount] = id;
        this.objectCount = this.objectCount + 1;
      }

      //If a Person has this Faction, adjust their techtree as well
      if (this.Person != 0){
        this.Person.ModObjectLimit(id, limit);
      }

      if (this.objectLimits[id] == 0){
        this.objectLimits.flush(id);
      }

      //Index the unit type to a unit category if possible and necessary
      if (UnitType.ById(id) != 0){
        this.unitTypeByCategory[UnitType.ById(id).UnitCategory] = id;
      }
    }

    integer operator UndefeatedResearch( ){
      ;.undefeatedResearch;
    }

    void operator UndefeatedResearch=(int research ){
      int i = 0;
      if (this.undefeatedResearch == 0){
        this.undefeatedResearch = research;
        while(true){
        if ( i > MAX_PLAYERS){ break; }
          SetPlayerTechResearched(Player(i), this.undefeatedResearch, 1);
          i = i + 1;
        }
      }else {
        BJDebugMsg("ERROR: attempted to undefeated research for faction " + this.name + " but one is already set");
      }
    }

    integer operator DefeatedResearch( ){
      ;.defeatedResearch;
    }

    void operator DefeatedResearch=(int research ){
      int i = 0;
      if (this.defeatedResearch == 0){
        this.defeatedResearch = research;
        while(true){
        if ( i > MAX_PLAYERS){ break; }
          SetPlayerTechResearched(Player(i), this.defeatedResearch, 0);
          i = i + 1;
        }
      }else {
        BJDebugMsg("ERROR: attempted to defeated research for faction " + this.name + " but one is already set");
      }
    }

    //Any time the player loses the game. E.g. Frozen Throne loss, Kil)jaeden loss
    void obliterate( ){
      group tempGroup = CreateGroup();
      unit u = null;
      UnitType tempUnitType = 0;

      //Take away resources
      SetPlayerState(this.Player, PLAYER_STATE_RESOURCE_GOLD, 0);
      SetPlayerState(this.Player, PLAYER_STATE_RESOURCE_LUMBER, 0);

      //Give all units to Neutral Victim
      GroupEnumUnitsOfPlayer(tempGroup, this.Player, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        tempUnitType = UnitType.ByHandle(u);
        if (!UnitAlive(u)){
          RemoveUnit(u);
        }
        if (!tempUnitType.Meta){
          SetUnitOwner(u, Player(bj_PLAYER_NEUTRAL_VICTIM), false);
        }
        GroupRemoveUnit(tempGroup, u);
      }

      //Cleanup
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void distributeExperience( ){
      int i = 0;
      group tempGroup = CreateGroup();
      unit u = null;
      int heroCount = 0;

      while(true){
        if ( i == this.team.FactionCount){ break; }
        if (this.team.GetFactionByIndex(i).Person != 0){
          GroupEnumUnitsOfPlayer(tempGroup, this.team.GetFactionByIndex(i).Player,  IsUnitHeroEnum);
          heroCount = BlzGroupGetSize(tempGroup);
          while(true){
            u = FirstOfGroup(tempGroup);
            if ( u == null){ break; }
            AddHeroXP(u, R2I((this.xp / (this.team.PlayerCount-1) / heroCount) * XP_TRANSFER_PERCENT), true);
            GroupRemoveUnit(tempGroup, u);
          }
        }
        i = i + 1;
      }
      this.xp = 0;

      //Cleanup
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void distributeResources( ){
      int i = 0;
      Faction loopFaction;
      while(true){
        if ( i == this.team.FactionCount){ break; }
        loopFaction = this.team.GetFactionByIndex(i);
        if (loopFaction.Person != 0){
          loopFaction.Gold = loopFaction.Gold + this.Gold / this.team.PlayerCount-1;
          loopFaction.Lumber = loopFaction.Lumber + this.Lumber / this.team.PlayerCount-1;
        }
        i = i + 1;
      }
      this.Gold = 0;
      this.Lumber = 0;
    }

    private void distributeUnits( ){
      group g = CreateGroup();
      unit u = null;
      UnitType loopUnitType = 0;
      force eligiblePlayers = this.Team.CreateForceFromPlayers();

      ForceRemovePlayer(eligiblePlayers, this.Player);
      GroupEnumUnitsOfPlayer(g, this.Player, null);

      while(true){
        u = FirstOfGroup(g);
        loopUnitType = UnitType.ByHandle(u);
        if ( u == null){ break; }
        //Refund gold and experience of heroes
        if (IsUnitType(u, UNIT_TYPE_HERO) == true){
          this.Person.addGold(HERO_COST);
          this.xp = this.xp + GetHeroXP(u);
          //Subtract hero)s starting XP from refunded XP
          if (Legend.ByHandle(u) != 0){
            this.xp = this.xp - Legend.ByHandle(u).StartingXP;
          }
          UnitDropAllItems(u);
          RemoveUnit(u);
        //Refund gold and lumber of refundable units
        }else if (UnitType.ByHandle(u).Refund == true){
          this.Gold = this.Gold + loopUnitType.GoldCost * REFUND_PERCENT;
          this.Lumber = this.Lumber + loopUnitType.LumberCost * REFUND_PERCENT;
          UnitDropAllItems(u);
          RemoveUnit(u);
        //Transfer the ownership of everything else
        }else if (UnitType.ByHandle(u).Meta == false){
          if (this.Team.PlayerCount > 1){
            SetUnitOwner(u, ForcePickRandomPlayer(eligiblePlayers), false);
          }else {
            SetUnitOwner(u, Player(bj_PLAYER_NEUTRAL_VICTIM), false);
          }
        }
        GroupRemoveUnit(g, u);
      }

      //Cleanup
      DestroyForce(eligiblePlayers);
      DestroyGroup(g);
      eligiblePlayers = null;
      g = null;
    }

    stub void OnPreLeave( ){

    }

    stub void OnLeave( ){

    }

    //This should get used any time a player exits the game without being defeated; IE they left, went afk, became an observer, or triggered an event that causes this
    private void Leave( ){
      OnPreLeave();
    if (team.PlayerCount > 1 && team.ScoreStatus == SCORESTATUS_NORMAL && GetGameTime() > 60){
      distributeUnits();
      distributeResources();
      distributeExperience();
     }else {
      obliterate();
    }
    thistype.triggerFaction = this;
    OnFactionGameLeave.fire();
    OnLeave();
    }

    static thistype ByHandle(player whichPlayer ){
      return Person.ByHandle(whichPlayer).Faction;
    }

    static thistype ByName(string s ){
      ;type.factionsByName[s];
    }

     Faction (string name, playercolor playCol, string prefixCol, string icon ){


      this.name = name;
      this.playCol = playCol;
      this.prefixCol = prefixCol;
      this.icon = icon;
      this.objectLimits = Table.create();
      this.objectLevels = Table.create();
      this.scoreStatus = SCORESTATUS_NORMAL;

      if (!factionsByName.exists(StringCase(name,false))){
        factionsByName[StringCase(name,false)] = this;
      }else {
        BJDebugMsg("Error: created faction that already exists with name " + name);
      }

      thistype.triggerFaction = this;
      OnFactionCreate.fire();

      ;;
    }

    private static void OnAnyResearch( ){
      Faction faction = Faction.ByHandle(GetTriggerPlayer());
      if (faction != 0){
        faction.SetObjectLevel(GetResearched(), GetPlayerTechCount(GetTriggerPlayer(), GetResearched(), false));
      }
    }

    private static void onInit( ){
      trigger trig = CreateTrigger();

      Faction.factionsByName = StringTable.create();
      OnFactionTeamLeave = Event.create();
      OnFactionTeamJoin = Event.create();
      OnFactionGameLeave = Event.create();
      FactionScoreStatusChanged = Event.create();
      FactionNameChanged = Event.create();
      FactionIconChanged = Event.create();

      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_FINISH,  thistype.OnAnyResearch) ;//TODO: use filtered events
    }


  static Faction GetTriggerFaction( ){
    return Faction.triggerFaction;
  }

  static Team GetTriggerFactionPrevTeam( ){
    return Faction.triggerFactionPrevTeam;
  }

  private static void OnInit( ){
    OnFactionCreate = Event.create();
  }

}
