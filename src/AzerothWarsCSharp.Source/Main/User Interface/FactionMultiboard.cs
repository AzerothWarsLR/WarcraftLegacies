public class FactionMultiboard{

  
    private const int COLUMN_COUNT   = 3;
    private const string  TITLE          = "Scoreboard";
    private const int HEADER_SIZE    = 1;

    const int COLUMN_FACTION = 0;
    const int COLUMN_CP      = 1;
    const int COLUMN_INCOME  = 2;
    const int COLUMN_TEAM    = 0;

    const float    WIDTH_FACTION  = 008;
    const float    WIDTH_CP       = 002;
    const float    WIDTH_INCOME   = 002;
    const float    WIDTH_TEAM     = WIDTH_FACTION + WIDTH_CP + WIDTH_INCOME;
  


    private static thistype instance;
    private multiboard multiboard;
    private int[] rowsByFaction[20];
    private int[] rowsByTeam[20];

    public static thistype operator Instance( ){
      ;type.instance;
    }

    //Run when a detail about a Faction has changed
    void UpdateFactionRow(Faction faction ){
      int row = rowsByFaction[faction];
      multiboarditem factionMbi = MultiboardGetItem(this.multiboard, row, COLUMN_FACTION);
      multiboarditem cpMbi = MultiboardGetItem(this.multiboard, row, COLUMN_CP);
      multiboarditem incomeMbi = MultiboardGetItem(this.multiboard, row, COLUMN_INCOME);
      MultiboardSetItemValue(factionMbi, faction.prefixCol + faction.Name);
      MultiboardSetItemIcon(factionMbi, faction.icon);
      MultiboardSetItemValue(cpMbi, faction.ControlPointCountAsString);
      MultiboardSetItemValue(incomeMbi, I2S(R2I(faction.Income)));
      MultiboardSetItemWidth(factionMbi, WIDTH_FACTION);
      MultiboardSetItemWidth(cpMbi, WIDTH_CP);
      MultiboardSetItemWidth(incomeMbi, WIDTH_INCOME);
      MultiboardSetItemStyle(factionMbi, true, true);
      MultiboardSetItemStyle(cpMbi, true, false);
      MultiboardSetItemStyle(incomeMbi, true, false);
      factionMbi = null;
      cpMbi = null;
      incomeMbi = null;
    }

    //Run when a detail about a Team has changed
    void UpdateTeamRow(Team team ){
      int row = rowsByTeam[team];
      multiboarditem mbi = MultiboardGetItem(this.multiboard, row, COLUMN_TEAM);
      MultiboardSetItemValue(mbi, "-----" + team.Name + SubString("-----------------------------------------", 0, 19-StringLength(team.Name)));
      MultiboardSetItemWidth(mbi, WIDTH_TEAM);
      MultiboardSetItemStyle(mbi, true, false);
      MultiboardSetItemStyle(MultiboardGetItem(this.multiboard, row, COLUMN_CP), false, false);
      MultiboardSetItemStyle(MultiboardGetItem(this.multiboard, row, COLUMN_INCOME), false, false);
      mbi = null;
    }

    void UpdateHeaderRow( ){
      multiboarditem factionMbi = MultiboardGetItem(this.multiboard, 0, COLUMN_FACTION);
      multiboarditem cpMbi = MultiboardGetItem(this.multiboard, 0, COLUMN_CP);
      multiboarditem incomeMbi = MultiboardGetItem(this.multiboard, 0, COLUMN_INCOME);
      MultiboardSetItemStyle(factionMbi, false, false);
      MultiboardSetItemStyle(cpMbi, false, true);
      MultiboardSetItemStyle(incomeMbi, false, true);
      MultiboardSetItemIcon(cpMbi, "ReplaceableTextures\\CommandButtons\\BTNCOP.blp");
      MultiboardSetItemIcon(incomeMbi, "ReplaceableTextures\\CommandButtons\\BTNMGexchange.blp");
      MultiboardSetItemWidth(factionMbi, WIDTH_FACTION);
      MultiboardSetItemWidth(cpMbi, WIDTH_CP);
      MultiboardSetItemWidth(incomeMbi, WIDTH_INCOME);
      factionMbi = null;
      cpMbi = null;
      incomeMbi = null;
    }

    //Run when the number of Teams or Factions have changed, or a Faction has changed its Team
    void Render( ){
      int i = 0;
      int j = 0;
      int row = 0;
      Faction loopFaction = 0;
      Team loopTeam = 0;
      DestroyMultiboard(this.multiboard);
      this.multiboard = CreateMultiboardBJ(COLUMN_COUNT, 3, TITLE);
      MultiboardSetRowCount(this.multiboard, 30);
      UpdateHeaderRow();
      row = row + 1;
      while(true){
        if ( i == Team.Count){ break; }
        loopTeam = Team.ByIndex(i);
        if (loopTeam.PlayerCount > 0 && loopTeam.ScoreStatus != SCORESTATUS_DEFEATED){
          this.rowsByTeam[loopTeam] = row;
          UpdateTeamRow(loopTeam);
          row = row + 1;
          j = 0;
          while(true){
          if ( j == loopTeam.FactionCount){ break; }
            loopFaction = loopTeam.GetFactionByIndex(j);
            if (loopFaction.Person != 0 && loopFaction.ScoreStatus != SCORESTATUS_DEFEATED){
              this.rowsByFaction[loopFaction] = row;
              UpdateFactionRow(loopFaction);
              row = row + 1;
            }
            j = j + 1;
          }
        }
        i = i + 1;
      }
      MultiboardSetRowCount(this.multiboard, row);
    }

    private static void RenderInstance( ){
      thistype.Instance.Render();
    }

    private  thistype (int columnCount, int rowCount, string title ){

      this.multiboard = CreateMultiboardBJ(columnCount, 3, title);
      this.Render();
      ;;
    }

    private static void ControlPointOwnerChanged( ){
      if (Person.ByHandle(GetTriggerControlPoint().owner).Faction != 0){
        Instance.UpdateFactionRow(Person.ByHandle(GetTriggerControlPoint().owner).Faction);
      }
    }

    private static void OnFactionNameChanged( ){
      Instance.UpdateFactionRow(GetTriggerFaction());
    }

    private static void onInit( ){
      trigger trig;
      TriggerSleepAction(1);
      thistype.instance = thistype.create(COLUMN_COUNT, 3, TITLE);

      trig = CreateTrigger();
      OnPersonFactionChange.register(trig);
      OnFactionTeamJoin.register(trig);
      OnFactionTeamLeave.register(trig);
      TeamScoreStatusChanged.register(trig);
      FactionScoreStatusChanged.register(trig);
      TriggerAddAction(trig,  thistype.RenderInstance);

      trig = CreateTrigger();
      FactionNameChanged.register(trig);
      FactionIconChanged.register(trig);
      TriggerAddAction(trig,  thistype.OnFactionNameChanged);

      trig = CreateTrigger();
      OnControlPointLoss.register(trig);
      OnControlPointOwnerChange.register(trig);
      TriggerAddAction(trig,  thistype.ControlPointOwnerChanged);
    }



}
