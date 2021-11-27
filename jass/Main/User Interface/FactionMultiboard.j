library FactionMultiboard requires ControlPoint, Faction, Team

  globals
    private constant integer COLUMN_COUNT   = 3
    private constant string  TITLE          = "Scoreboard"
    private constant integer HEADER_SIZE    = 1
    
    constant integer COLUMN_FACTION = 0
    constant integer COLUMN_CP      = 1
    constant integer COLUMN_INCOME  = 2
    constant integer COLUMN_TEAM    = 0
    
    constant real    WIDTH_FACTION  = 0.08
    constant real    WIDTH_CP       = 0.02
    constant real    WIDTH_INCOME   = 0.02
    constant real    WIDTH_TEAM     = WIDTH_FACTION + WIDTH_CP + WIDTH_INCOME
  endglobals

  struct FactionMultiboard
    private static thistype instance
    private multiboard multiboard
    private integer array rowsByFaction[20]
    private integer array rowsByTeam[20]

    public static method operator Instance takes nothing returns thistype
      return thistype.instance
    endmethod

    //Run when a detail about a Faction has changed
    method UpdateFactionRow takes Faction faction returns nothing
      local integer row = rowsByFaction[faction]
      local multiboarditem factionMbi = MultiboardGetItem(this.multiboard, row, COLUMN_FACTION)
      local multiboarditem cpMbi = MultiboardGetItem(this.multiboard, row, COLUMN_CP)
      local multiboarditem incomeMbi = MultiboardGetItem(this.multiboard, row, COLUMN_INCOME)
      call MultiboardSetItemValue(factionMbi, faction.prefixCol + faction.Name)
      call MultiboardSetItemIcon(factionMbi, faction.icon)
      call MultiboardSetItemValue(cpMbi, faction.ControlPointCountAsString)
      call MultiboardSetItemValue(incomeMbi, I2S(R2I(faction.Income)))
      call MultiboardSetItemWidth(factionMbi, WIDTH_FACTION)
      call MultiboardSetItemWidth(cpMbi, WIDTH_CP)
      call MultiboardSetItemWidth(incomeMbi, WIDTH_INCOME)
      call MultiboardSetItemStyle(factionMbi, true, true)
      call MultiboardSetItemStyle(cpMbi, true, false)
      call MultiboardSetItemStyle(incomeMbi, true, false)
      set factionMbi = null
      set cpMbi = null
      set incomeMbi = null
    endmethod

    //Run when a detail about a Team has changed
    method UpdateTeamRow takes Team team returns nothing
      local integer row = rowsByTeam[team]
      local multiboarditem mbi = MultiboardGetItem(this.multiboard, row, COLUMN_TEAM)
      call MultiboardSetItemValue(mbi, "-----" + team.Name + SubString("-----------------------------------------", 0, 19-StringLength(team.Name)))
      call MultiboardSetItemWidth(mbi, WIDTH_TEAM)
      call MultiboardSetItemStyle(mbi, true, false)
      call MultiboardSetItemStyle(MultiboardGetItem(this.multiboard, row, COLUMN_CP), false, false)
      call MultiboardSetItemStyle(MultiboardGetItem(this.multiboard, row, COLUMN_INCOME), false, false)
      set mbi = null
    endmethod

    method UpdateHeaderRow takes nothing returns nothing
      local multiboarditem factionMbi = MultiboardGetItem(this.multiboard, 0, COLUMN_FACTION)
      local multiboarditem cpMbi = MultiboardGetItem(this.multiboard, 0, COLUMN_CP)
      local multiboarditem incomeMbi = MultiboardGetItem(this.multiboard, 0, COLUMN_INCOME)
      call MultiboardSetItemStyle(factionMbi, false, false)
      call MultiboardSetItemStyle(cpMbi, false, true)
      call MultiboardSetItemStyle(incomeMbi, false, true)
      call MultiboardSetItemIcon(cpMbi, "ReplaceableTextures\\CommandButtons\\BTNCOP.blp")
      call MultiboardSetItemIcon(incomeMbi, "ReplaceableTextures\\CommandButtons\\BTNMGexchange.blp")
      call MultiboardSetItemWidth(factionMbi, WIDTH_FACTION)
      call MultiboardSetItemWidth(cpMbi, WIDTH_CP)
      call MultiboardSetItemWidth(incomeMbi, WIDTH_INCOME)
      set factionMbi = null
      set cpMbi = null
      set incomeMbi = null
    endmethod

    //Run when the number of Teams or Factions have changed, or a Faction has changed its Team
    method Render takes nothing returns nothing
      local integer i = 0
      local integer j = 0
      local integer row = 0
      local Faction loopFaction = 0
      local Team loopTeam = 0
      call DestroyMultiboard(this.multiboard)
      set this.multiboard = CreateMultiboardBJ(COLUMN_COUNT, 3, TITLE)
      call MultiboardSetRowCount(this.multiboard, 30)
      call UpdateHeaderRow()
      set row = row + 1
      loop
        exitwhen i == Team.Count
        set loopTeam = Team.ByIndex(i)
        if loopTeam.PlayerCount > 0 and loopTeam.ScoreStatus != SCORESTATUS_DEFEATED then
          set this.rowsByTeam[loopTeam] = row
          call UpdateTeamRow(loopTeam)
          set row = row + 1
          set j = 0
          loop
          exitwhen j == loopTeam.FactionCount
            set loopFaction = loopTeam.GetFactionByIndex(j)
            if loopFaction.Person != 0 and loopFaction.ScoreStatus != SCORESTATUS_DEFEATED then
              set this.rowsByFaction[loopFaction] = row
              call UpdateFactionRow(loopFaction)
              set row = row + 1
            endif
            set j = j + 1
          endloop
        endif
        set i = i + 1
      endloop
      call MultiboardSetRowCount(this.multiboard, row)
    endmethod

    private static method RenderInstance takes nothing returns nothing
      call thistype.Instance.Render()
    endmethod

    private static method create takes integer columnCount, integer rowCount, string title returns thistype
      local thistype this = thistype.allocate()
      set this.multiboard = CreateMultiboardBJ(columnCount, 3, title)
      call this.Render()
      return this
    endmethod

    private static method ControlPointOwnerChanged takes nothing returns nothing
      if Person.ByHandle(GetTriggerControlPoint().owner).Faction != 0 then
        call Instance.UpdateFactionRow(Person.ByHandle(GetTriggerControlPoint().owner).Faction)
      endif
    endmethod

    private static method OnFactionNameChanged takes nothing returns nothing
      call Instance.UpdateFactionRow(GetTriggerFaction())
    endmethod

    private static method onInit takes nothing returns nothing
      local trigger trig
      call TriggerSleepAction(1)
      set thistype.instance = thistype.create(COLUMN_COUNT, 3, TITLE)

      set trig = CreateTrigger()
      call OnPersonFactionChange.register(trig)
      call OnFactionTeamJoin.register(trig)
      call OnFactionTeamLeave.register(trig)
      call TeamScoreStatusChanged.register(trig)
      call FactionScoreStatusChanged.register(trig)
      call TriggerAddAction(trig, function thistype.RenderInstance)

      set trig = CreateTrigger()
      call FactionNameChanged.register(trig)
      call FactionIconChanged.register(trig)
      call TriggerAddAction(trig, function thistype.OnFactionNameChanged)

      set trig = CreateTrigger()
      call OnControlPointLoss.register(trig)
      call OnControlPointOwnerChange.register(trig)
      call TriggerAddAction(trig, function thistype.ControlPointOwnerChanged)
    endmethod

  endstruct

endlibrary