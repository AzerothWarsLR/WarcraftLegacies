using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;

namespace AzerothWarsCSharp.Source.Main.Libraries.MacroTools
{
  public class Faction
  {
    Event OnFactionCreate = 0;
    private Event OnFactionTeamLeave;
    private Event OnFactionTeamJoin;
    private Event OnFactionGameLeave;
    private Event FactionNameChanged;
    private Event FactionIconChanged;
    private Event FactionScoreStatusChanged;

    const int UNLIMITED = 200; //This is used in Persons and Faction for effectively unlimited unit production
    const int HERO_COST = 100; //For refunding

    private const float
      REFUND_PERCENT = 100; //How much gold and lumber is refunded from units that get refunded on leave

    private const float XP_TRANSFER_PERCENT = 100; //How much experience is transferred from heroes that leave the game)

    readonly static StringTable factionsByName;
    readonly static thistype triggerFaction = 0;
    readonly static thistype triggerFactionPrevTeam = 0;

    readonly string name;
    readonly string prefixCol;
    readonly string icon;
    private int scoreStatus;

    private Person person = 0; //One-to-one relationship
    private Team team = 0; //The team this Faction is in
    readonly int xp; //Stored by DistributeUnits and given out again by DistributeResources
    private int storedExperience; //Actual hero experience being held by this Faction outside of its heroes

    private int defeatedResearch; //This upgrade is researched for all players only if this Faction slot is defeated
    private int undefeatedResearch; //This upgrade is researched for all players only if this Faction is undefeated


    readonly int[] objectList[100]; //An index for objectLimits
    readonly int objectCount;

    private Table objectLevels;
    private int[] objectLevelList[100];
    private int objectLevelCount;
    
    private int questCount;
    private QuestData[] quests[100];

    private int[] unitTypeByCategory[100];

    public int StartingGold = 0;
    public int StartingLumber = 0;

    public playercolor PlayerColor { get; init; }
    
    public int GetObjectLimit(int whichObject)
    {
      return this.objectLimits[whichObject];
    }

    integer operator StoredExperience()
    {
      ;.storedExperience;
    }

    void operator StoredExperience=(int value ) {
      storedExperience = value;
    }

    integer operator ObjectLimitCount()
    {
      ;.objectCount;
    }

    float operator Gold()
    {
      return I2R(GetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD));
    }

    void operator Gold=(float value ) {
      SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD, R2I(value));
    }

    float operator Lumber()
    {
      return I2R(GetPlayerState(Player, PLAYER_STATE_RESOURCE_LUMBER));
    }

    void operator Lumber=(float value ) {
      SetPlayerState(Player, PLAYER_STATE_RESOURCE_LUMBER, R2I(value));
    }

    public Team Team
    {
      get { return team; }
    }

    private stub void OnTeamChange()
    {
    }


    public int ScoreStatus
    {
      get { return scoreStatus; }
      set
      {
        var i = 0;
        //Change defeated/undefeated researches
        if (value == SCORESTATUS_DEFEATED)
        {
          while (true)
          {
            if (i == MAX_PLAYERS)
            {
              break;
            }

            SetPlayerTechResearched(Player(i), defeatedResearch, 1);
            SetPlayerTechResearched(Player(i), undefeatedResearch, 0);
            i = i + 1;
          }
        }

        //Remove player from game if necessary
        if (value == SCORESTATUS_DEFEATED && Player != null)
        {
          RemovePlayer(Player, PLAYER_GAME_RESULT_DEFEAT);
          SetPlayerState(Player, PLAYER_STATE_OBSERVER, 1);
          Leave();
          // call CreateFogModifierRectBJ( true, this.Player, FOG_OF_WAR_VISIBLE, GetPlayableMapRect() )
        }
        else if (value == SCORESTATUS_VICTORIOUS && Player != null)
        {
          RemovePlayer(Player, PLAYER_GAME_RESULT_VICTORY);
        }

        scoreStatus = value;
        thistype.triggerFaction = this;
        FactionScoreStatusChanged.fire();
      }
    }

    void operator Team=(Team team ) {
      if (team != 0)
      {
        thistype.triggerFaction = this;
        team.RemoveFaction(this);
        triggerFactionPrevTeam = team;
        team = 0;
        OnFactionTeamLeave.fire();
      }

      if (team != 0)
      {
        team.AddFaction(this);
        team = team;
        thistype.triggerFaction = this;
        OnFactionTeamJoin.fire();
      }

      OnTeamChange();
    }

    stub string operator ControlPointCountAsString()
    {
      return I2S(this.Person.ControlPointCount);
    }

    public int Income => this.person.ControlPointValue;

    public string ColoredName => prefixCol + name + "|r";

    public string PrefixCol => prefixCol;

    public string Name
    {
      get { return name; }
    }

    void operator Name=(string value ) {
      thistype.factionsByName[name] = 0;
      name = value;
      thistype.triggerFaction = this;
      thistype.factionsByName[StringCase(value, false)] = this;
      FactionNameChanged.fire();
    }

    string operator Icon()
    {
      ;.icon;
    }

    void operator Icon=(string value ) {
      icon = value;
      thistype.triggerFaction = this;
      FactionIconChanged.fire();
    }

    public player Player => person.Player;

    stub void OnPersonChange()
    {
    }

    void operator Person=(Person value ) {
      if (Player != null)
      {
        Team.UnallyPlayer(Player);
        HideAllQuests();
        UnapplyObjects();
      }

      person = value;
      //Maintan referential integrity
      if (value == 0)
      {
        return;
      }

      if (value.Faction != this)
      {
        value.Faction = this;
      }

      Team.AllyPlayer(value.Player);
      ApplyObjects();
      ShowAllQuests();
    }

    public QuestData StartingQuest { get; set; }

    stub boolean operator CanBeInvited()
    {
      return true;
    }

    //Adds this Faction)s object limits and levels to its active Person
    private void ApplyObjects()
    {
      Person person = this.Person;
      var i = 0;
      //Limits
      while (true)
      {
        if (i == objectCount)
        {
          break;
        }

        this.Person.ModObjectLimit(objectList[i], this.objectLimits[objectList[i]]);
        i = i + 1;
      }

      //Levels
      i = 0;
      while (true)
      {
        if (i == objectLevelCount)
        {
          break;
        }

        this.Person.SetObjectLevel(objectLevelList[i], objectLevels[objectLevelList[i]]);
        i = i + 1;
      }
    }

    //Removes this Faction)s object limits and levels from its active Person
    private void UnapplyObjects()
    {
      Person person = this.person;
      var i = 0;
      //Limits
      while (true)
      {
        if (i == objectCount)
        {
          break;
        }

        this.Person.ModObjectLimit(objectList[i], -this.objectLimits[objectList[i]]);
        i = i + 1;
      }

      //Levels
      i = 0;
      while (true)
      {
        if (i == objectLevelCount)
        {
          break;
        }

        this.Person.SetObjectLevel(objectLevelList[i], 0);
        i = i + 1;
      }

      i = 0;
    }

    stub void Unally()
    {
      string newTeamName = Name + " Pact";
      Team newTeam = 0;

      if (Team.PlayerCount > 1)
      {
        newTeam = Team.teamsByName[newTeamName];
        if (newTeam == 0)
        {
          newTeam = Team.create(newTeamName);
        }

        Team = newTeam;
      }
    }

    integer GetUnitTypeByCategory(int unitCategory)
    {
      ;.unitTypeByCategory[unitCategory];
    }

    //Shows all of the Faction)s quest, rendering them in the quest log,
    //showing them on the minimap, and showing them on the map.
    void ShowAllQuests()
    {
      var i = 0;
      while (true)
      {
        if (i == questCount)
        {
          break;
        }

        if (GetLocalPlayer() == Player)
        {
          quests[i].ShowLocal();
        }

        quests[i].ShowSync();
        i = i + 1;
      }
    }

    //Hides all of the Faction)s quests.
    void HideAllQuests()
    {
      var i = 0;
      while (true)
      {
        if (i == questCount)
        {
          break;
        }

        if (GetLocalPlayer() == Player)
        {
          quests[i].HideLocal();
        }

        quests[i].HideSync();
        i = i + 1;
      }
    }

    QuestData AddQuest(QuestData questData)
    {
      questData.Holder = this;
      quests[questCount] = questData;
      questCount = questCount + 1;
      if (GetLocalPlayer() == Player)
      {
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
      if (!objectLevels.exists(object))
      {
        objectLevelList[objectLevelCount] = object;
        objectLevelCount = objectLevelCount + 1;
      }

      objectLevels[object] = level;
      if (this.Person != 0)
      {
        this.Person.SetObjectLevel(object, level);
      }

      this.OnSetObjectLevel(object, level);
    }

    public void ModObjectLimit(int id, int limit)
    {
      Person affectedPerson = 0;

      if (this.objectLimits.exists(id))
      {
        this.objectLimits[id] = this.objectLimits[id] + limit;
      }
      else
      {
        this.objectLimits[id] = limit;
        objectList[objectCount] = id;
        objectCount = objectCount + 1;
      }

      //If a Person has this Faction, adjust their techtree as well
      if (this.Person != 0)
      {
        this.Person.ModObjectLimit(id, limit);
      }

      if (this.objectLimits[id] == 0)
      {
        this.objectLimits.flush(id);
      }

      //Index the unit type to a unit category if possible and necessary
      if (UnitType.ById(id) != 0)
      {
        unitTypeByCategory[UnitType.ById(id).UnitCategory] = id;
      }
    }

    integer operator UndefeatedResearch()
    {
      ;.undefeatedResearch;
    }

    void operator UndefeatedResearch=(int research ) {
      var i = 0;
      if (undefeatedResearch == 0)
      {
        undefeatedResearch = research;
        while (true)
        {
          if (i > MAX_PLAYERS)
          {
            break;
          }

          SetPlayerTechResearched(Player(i), undefeatedResearch, 1);
          i = i + 1;
        }
      }
      else
      {
        BJDebugMsg("ERROR: attempted to undefeated research for faction " + name + " but one is already set");
      }
    }

    integer operator DefeatedResearch()
    {
      ;.defeatedResearch;
    }

    void operator DefeatedResearch=(int research ) {
      var i = 0;
      if (defeatedResearch == 0)
      {
        defeatedResearch = research;
        while (true)
        {
          if (i > MAX_PLAYERS)
          {
            break;
          }

          SetPlayerTechResearched(Player(i), defeatedResearch, 0);
          i = i + 1;
        }
      }
      else
      {
        BJDebugMsg("ERROR: attempted to defeated research for faction " + name + " but one is already set");
      }
    }

    //Any time the player loses the game. E.g. Frozen Throne loss, Kil)jaeden loss
    public void Obliterate()
    {
      group tempGroup = CreateGroup();
      unit u = null;
      UnitType tempUnitType = 0;

      //Take away resources
      SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD, 0);
      SetPlayerState(Player, PLAYER_STATE_RESOURCE_LUMBER, 0);

      //Give all units to Neutral Victim
      GroupEnumUnitsOfPlayer(tempGroup, Player, null);
      while (true)
      {
        u = FirstOfGroup(tempGroup);
        if (u == null)
        {
          break;
        }

        tempUnitType = UnitType.ByHandle(u);
        if (!UnitAlive(u))
        {
          RemoveUnit(u);
        }

        if (!tempUnitType.Meta)
        {
          SetUnitOwner(u, Player(bj_PLAYER_NEUTRAL_VICTIM), false);
        }

        GroupRemoveUnit(tempGroup, u);
      }

      //Cleanup
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void distributeExperience()
    {
      var i = 0;
      group tempGroup = CreateGroup();
      unit u = null;
      var heroCount = 0;

      while (true)
      {
        if (i == team.FactionCount)
        {
          break;
        }

        if (team.GetFactionByIndex(i).Person != 0)
        {
          GroupEnumUnitsOfPlayer(tempGroup, team.GetFactionByIndex(i).Player, IsUnitHeroEnum);
          heroCount = BlzGroupGetSize(tempGroup);
          while (true)
          {
            u = FirstOfGroup(tempGroup);
            if (u == null)
            {
              break;
            }

            AddHeroXP(u, R2I((xp / (team.PlayerCount - 1) / heroCount) * XP_TRANSFER_PERCENT), true);
            GroupRemoveUnit(tempGroup, u);
          }
        }

        i = i + 1;
      }

      xp = 0;

      //Cleanup
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void distributeResources()
    {
      var i = 0;
      Faction loopFaction;
      while (true)
      {
        if (i == team.FactionCount)
        {
          break;
        }

        loopFaction = team.GetFactionByIndex(i);
        if (loopFaction.Person != 0)
        {
          loopFaction.Gold = loopFaction.Gold + this.Gold / team.PlayerCount - 1;
          loopFaction.Lumber = loopFaction.Lumber + this.Lumber / team.PlayerCount - 1;
        }

        i = i + 1;
      }

      this.Gold = 0;
      this.Lumber = 0;
    }

    private void distributeUnits()
    {
      group g = CreateGroup();
      unit u = null;
      UnitType loopUnitType = 0;
      force eligiblePlayers = Team.CreateForceFromPlayers();

      ForceRemovePlayer(eligiblePlayers, Player);
      GroupEnumUnitsOfPlayer(g, Player, null);

      while (true)
      {
        u = FirstOfGroup(g);
        loopUnitType = UnitType.ByHandle(u);
        if (u == null)
        {
          break;
        }

        //Refund gold and experience of heroes
        if (IsUnitType(u, UNIT_TYPE_HERO))
        {
          this.Person.addGold(HERO_COST);
          xp = xp + GetHeroXP(u);
          //Subtract hero)s starting XP from refunded XP
          if (Legend.ByHandle(u) != 0)
          {
            xp = xp - Legend.ByHandle(u).StartingXP;
          }

          UnitDropAllItems(u);
          RemoveUnit(u);
          //Refund gold and lumber of refundable units
        }
        else if (UnitType.ByHandle(u).Refund == true)
        {
          this.Gold = this.Gold + loopUnitType.GoldCost * REFUND_PERCENT;
          this.Lumber = this.Lumber + loopUnitType.LumberCost * REFUND_PERCENT;
          UnitDropAllItems(u);
          RemoveUnit(u);
          //Transfer the ownership of everything else
        }
        else if (UnitType.ByHandle(u).Meta == false)
        {
          if (Team.PlayerCount > 1)
          {
            SetUnitOwner(u, ForcePickRandomPlayer(eligiblePlayers), false);
          }
          else
          {
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

    stub void OnPreLeave()
    {
    }

    stub void OnLeave()
    {
    }

    //This should get used any time a player exits the game without being defeated; IE they left, went afk, became an observer, or triggered an event that causes this
    private void Leave()
    {
      OnPreLeave();
      if (team.PlayerCount > 1 && team.ScoreStatus == SCORESTATUS_NORMAL && GetGameTime() > 60)
      {
        distributeUnits();
        distributeResources();
        distributeExperience();
      }
      else
      {
        Obliterate();
      }

      thistype.triggerFaction = this;
      OnFactionGameLeave.fire();
      OnLeave();
    }

    static thistype ByHandle(player whichPlayer)
    {
      return Person.ByHandle(whichPlayer).Faction;
    }

    static thistype ByName(string s)
    {
      ;
      type.factionsByName[s];
    }

    Faction(string name, playercolor playCol, string prefixCol, string icon)
    {
      this.name = name;
      this.playCol = playCol;
      this.prefixCol = prefixCol;
      this.icon = icon;
      this.objectLimits = Table.create();
      objectLevels = Table.create();
      scoreStatus = SCORESTATUS_NORMAL;

      if (!factionsByName.exists(StringCase(name, false)))
      {
        factionsByName[StringCase(name, false)] = this;
      }
      else
      {
        BJDebugMsg("Error: created faction that already exists with name " + name);
      }

      thistype.triggerFaction = this;
      OnFactionCreate.fire();

      ;
      ;
    }

    private static void OnAnyResearch()
    {
      Faction faction = ByHandle(GetTriggerPlayer());
      if (faction != 0)
      {
        faction.SetObjectLevel(GetResearched(), GetPlayerTechCount(GetTriggerPlayer(), GetResearched(), false));
      }
    }

    private static void onInit()
    {
      trigger trig = CreateTrigger();

      factionsByName = StringTable.create();
      OnFactionTeamLeave = Event.create();
      OnFactionTeamJoin = Event.create();
      OnFactionGameLeave = Event.create();
      FactionScoreStatusChanged = Event.create();
      FactionNameChanged = Event.create();
      FactionIconChanged = Event.create();

      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_FINISH, thistype.OnAnyResearch); //TODO: use filtered events
    }


    static Faction GetTriggerFaction()
    {
      return triggerFaction;
    }

    static Team GetTriggerFactionPrevTeam()
    {
      return triggerFactionPrevTeam;
    }

    public static void Setup()
    {
      OnFactionCreate = Event.create();
    }
  }
}