using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.UserInterface
{
  /// <summary>
  ///   Displays the name, color, <see cref="Team" />, <see cref="ControlPoint" /> count, and income of all
  ///   <see cref="Faction" />s in the game.
  /// </summary>
  public sealed class FactionMultiboard
  {
    private const int COLUMN_COUNT = 3;
    private const string TITLE = "Scoreboard";

    private const int COLUMN_FACTION = 0;
    private const int COLUMN_CP = 1;
    private const int COLUMN_INCOME = 2;
    private const int COLUMN_TEAM = 0;

    private const float WIDTH_FACTION = 0.08f;
    private const float WIDTH_CP = 0.02f;
    private const float WIDTH_INCOME = 0.02f;
    private const float WIDTH_TEAM = WIDTH_FACTION + WIDTH_CP + WIDTH_INCOME;
    private readonly Dictionary<Faction, int> _rowsByFaction = new();
    private readonly Dictionary<Team, int> _rowsByTeam = new();

    private multiboard _multiboard;

    private FactionMultiboard(int columnCount, int rowCount, string title)
    {
      _multiboard = CreateMultiboard();
      MultiboardSetRowCount(_multiboard, rowCount);
      MultiboardSetColumnCount(_multiboard, columnCount);
      MultiboardSetTitleText(_multiboard, title);
      MultiboardDisplay(_multiboard, true);
      Render();
    }

    private static FactionMultiboard? Instance { get; set; }

    //Run when a detail about a Faction has changed
    private void UpdateFactionRow(Faction faction)
    {
      var row = _rowsByFaction[faction];
      multiboarditem factionMbi = MultiboardGetItem(_multiboard, row, COLUMN_FACTION);
      multiboarditem cpMbi = MultiboardGetItem(_multiboard, row, COLUMN_CP);
      multiboarditem incomeMbi = MultiboardGetItem(_multiboard, row, COLUMN_INCOME);
      MultiboardSetItemValue(factionMbi, faction.ColoredName);
      MultiboardSetItemIcon(factionMbi, faction.Icon);
      MultiboardSetItemValue(cpMbi, faction.Player?.GetControlPointCount().ToString());
      var income = R2I(faction.Player?.GetTotalIncome() ?? 0);
      var incomePrefix = faction.Player?.GetBonusIncome() > 0 ? "|cffffcc00" : "";
      MultiboardSetItemValue(incomeMbi, $"{incomePrefix}{I2S(income)}");
      MultiboardSetItemWidth(factionMbi, WIDTH_FACTION);
      MultiboardSetItemWidth(cpMbi, WIDTH_CP);
      MultiboardSetItemWidth(incomeMbi, WIDTH_INCOME);
      MultiboardSetItemStyle(factionMbi, true, true);
      MultiboardSetItemStyle(cpMbi, true, false);
      MultiboardSetItemStyle(incomeMbi, true, false);
    }

    //Run when a detail about a Team has changed
    private void UpdateTeamRow(Team team)
    {
      var row = _rowsByTeam[team];
      multiboarditem mbi = MultiboardGetItem(_multiboard, row, COLUMN_TEAM);
      MultiboardSetItemValue(mbi,
        "-----" + team.Name + SubString("-----------------------------------------", 0, 19 - StringLength(team.Name)));
      MultiboardSetItemWidth(mbi, WIDTH_TEAM);
      MultiboardSetItemStyle(mbi, true, false);
      MultiboardSetItemStyle(MultiboardGetItem(_multiboard, row, COLUMN_CP), false, false);
      MultiboardSetItemStyle(MultiboardGetItem(_multiboard, row, COLUMN_INCOME), false, false);
    }

    private void UpdateHeaderRow()
    {
      multiboarditem factionMbi = MultiboardGetItem(_multiboard, 0, COLUMN_FACTION);
      multiboarditem cpMbi = MultiboardGetItem(_multiboard, 0, COLUMN_CP);
      multiboarditem incomeMbi = MultiboardGetItem(_multiboard, 0, COLUMN_INCOME);
      MultiboardSetItemStyle(factionMbi, false, false);
      MultiboardSetItemStyle(cpMbi, false, true);
      MultiboardSetItemStyle(incomeMbi, false, true);
      MultiboardSetItemIcon(cpMbi, "ReplaceableTextures\\CommandButtons\\BTNCOP.blp");
      MultiboardSetItemIcon(incomeMbi, "ReplaceableTextures\\CommandButtons\\BTNMGexchange.blp");
      MultiboardSetItemWidth(factionMbi, WIDTH_FACTION);
      MultiboardSetItemWidth(cpMbi, WIDTH_CP);
      MultiboardSetItemWidth(incomeMbi, WIDTH_INCOME);
    }

    //Run when the number of Teams or Factions have changed, or a Faction has changed its Team
    private void Render()
    {
      var row = 0;
      DestroyMultiboard(_multiboard);
      _multiboard = CreateMultiboard();
      MultiboardSetColumnCount(_multiboard, COLUMN_COUNT);
      MultiboardSetRowCount(_multiboard, 3);
      MultiboardSetTitleText(_multiboard, TITLE);
      MultiboardDisplay(_multiboard, true);
      MultiboardSetRowCount(_multiboard, 30);
      UpdateHeaderRow();
      row += 1;
      foreach (var team in FactionManager.GetAllTeams())
        if (team.PlayerCount > 0)
        {
          _rowsByTeam[team] = row;
          UpdateTeamRow(team);
          row += 1;
          foreach (var faction in team.GetAllFactions())
            if (faction.Player != null && faction.ScoreStatus != ScoreStatus.Defeated)
            {
              _rowsByFaction[faction] = row;
              UpdateFactionRow(faction);
              row += 1;
            }
        }

      MultiboardSetRowCount(_multiboard, row);
    }

    private static void RenderInstance()
    {
      Instance?.Render();
    }

    private static void OnFactionAnyFactionNameChanged(object? sender, Faction faction)
    {
      Instance?.UpdateFactionRow(faction);
    }

    private static void OnPersonFactionChange(object? sender, PlayerFactionChangeEventArgs playerFactionChangeEventArgs)
    {
      RenderInstance();
    }

    private static void OnFactionTeamJoin(object? sender, Faction faction)
    {
      RenderInstance();
    }

    private static void OnFactionTeamLeft(object? sender, FactionChangeTeamEventArgs factionChangeTeamEventArgs)
    {
      RenderInstance();
    }

    private static void OnFactionStatusChanged(object? sender, Faction faction)
    {
      RenderInstance();
    }

    public static void Setup()
    {
      var timer = CreateTimer();
      TimerStart(timer, 2, false, () => { Instance = new FactionMultiboard(COLUMN_COUNT, 3, TITLE); }
      );

      PlayerData.FactionChange += OnPersonFactionChange;
      Faction.TeamJoin += OnFactionTeamJoin;
      Faction.TeamLeft += OnFactionTeamLeft;
      Faction.StatusChanged += OnFactionStatusChanged;

      FactionManager.AnyFactionNameChanged += OnFactionAnyFactionNameChanged;
      Faction.IconChanged += OnFactionIconChanged;

      foreach (var player in GeneralHelpers.GetAllPlayers())
      {
        player.GetPlayerData().IncomeChanged += OnPlayerIncomeChanged;
      }
    }

    private static void OnPlayerIncomeChanged(object? sender, PlayerData player)
    {
      var faction = player.Faction;
      if (faction != null)
        Instance?.UpdateFactionRow(faction);
    }

    private static void OnFactionIconChanged(object? sender, Faction args)
    {
      Instance?.UpdateFactionRow(args);
    }
  }
}