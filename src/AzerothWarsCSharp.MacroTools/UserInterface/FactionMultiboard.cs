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
    private const int ColumnCount = 3;
    private const string Title = "Scoreboard";

    private const int ColumnFaction = 0;
    private const int ColumnCp = 1;
    private const int ColumnIncome = 2;
    private const int ColumnTeam = 0;

    private const float WidthFaction = 0.08f;
    private const float WidthCp = 0.02f;
    private const float WidthIncome = 0.02f;
    private const float WidthTeam = WidthFaction + WidthCp + WidthIncome;
    
    private static bool _initialized;
    
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

    /// <summary>
    /// Sets up the globally visible <see cref="FactionMultiboard"/>.
    /// </summary>
    public static void Setup()
    {
      if (_initialized) throw new SystemAlreadyInitializedException(nameof(FactionMultiboard));

      var timer = CreateTimer();
      TimerStart(timer, 2, false, () => { Instance = new FactionMultiboard(ColumnCount, 3, Title); }
      );

      PlayerData.FactionChange += OnPersonFactionChange;
      PlayerData.PlayerJoinedTeam += OnFactionTeamJoin;
      PlayerData.PlayerLeftTeam += OnFactionTeamLeft;
      Faction.StatusChanged += OnFactionStatusChanged;

      FactionManager.AnyFactionNameChanged += OnFactionAnyFactionNameChanged;
      Faction.IconChanged += OnFactionIconChanged;

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        player.GetPlayerData().IncomeChanged += OnPlayerIncomeChanged;

      _initialized = true;
    }

    //Run when a detail about a Faction has changed
    private void UpdateFactionRow(Faction faction)
    {
      var row = _rowsByFaction[faction];
      multiboarditem factionMbi = MultiboardGetItem(_multiboard, row, ColumnFaction);
      multiboarditem cpMbi = MultiboardGetItem(_multiboard, row, ColumnCp);
      multiboarditem incomeMbi = MultiboardGetItem(_multiboard, row, ColumnIncome);
      MultiboardSetItemValue(factionMbi, faction.ColoredName);
      MultiboardSetItemIcon(factionMbi, faction.Icon);
      MultiboardSetItemValue(cpMbi, faction.Player?.GetControlPointCount().ToString());
      var income = R2I(faction.Player?.GetTotalIncome() ?? 0);
      var incomePrefix = faction.Player?.GetBonusIncome() > 0 ? "|cffffcc00" : "";
      MultiboardSetItemValue(incomeMbi, $"{incomePrefix}{I2S(income)}");
      MultiboardSetItemWidth(factionMbi, WidthFaction);
      MultiboardSetItemWidth(cpMbi, WidthCp);
      MultiboardSetItemWidth(incomeMbi, WidthIncome);
      MultiboardSetItemStyle(factionMbi, true, true);
      MultiboardSetItemStyle(cpMbi, true, false);
      MultiboardSetItemStyle(incomeMbi, true, false);
    }

    //Run when a detail about a Team has changed
    private void UpdateTeamRow(Team team)
    {
      var row = _rowsByTeam[team];
      multiboarditem mbi = MultiboardGetItem(_multiboard, row, ColumnTeam);
      MultiboardSetItemValue(mbi,
        "-----" + team.Name + SubString("-----------------------------------------", 0, 19 - StringLength(team.Name)));
      MultiboardSetItemWidth(mbi, WidthTeam);
      MultiboardSetItemStyle(mbi, true, false);
      MultiboardSetItemStyle(MultiboardGetItem(_multiboard, row, ColumnCp), false, false);
      MultiboardSetItemStyle(MultiboardGetItem(_multiboard, row, ColumnIncome), false, false);
    }

    private void UpdateHeaderRow()
    {
      multiboarditem factionMbi = MultiboardGetItem(_multiboard, 0, ColumnFaction);
      multiboarditem cpMbi = MultiboardGetItem(_multiboard, 0, ColumnCp);
      multiboarditem incomeMbi = MultiboardGetItem(_multiboard, 0, ColumnIncome);
      MultiboardSetItemStyle(factionMbi, false, false);
      MultiboardSetItemStyle(cpMbi, false, true);
      MultiboardSetItemStyle(incomeMbi, false, true);
      MultiboardSetItemIcon(cpMbi, "ReplaceableTextures\\CommandButtons\\BTNCOP.blp");
      MultiboardSetItemIcon(incomeMbi, "ReplaceableTextures\\CommandButtons\\BTNMGexchange.blp");
      MultiboardSetItemWidth(factionMbi, WidthFaction);
      MultiboardSetItemWidth(cpMbi, WidthCp);
      MultiboardSetItemWidth(incomeMbi, WidthIncome);
    }

    //Run when the number of Teams or Factions have changed, or a Faction has changed its Team
    private void Render()
    {
      var row = 0;
      DestroyMultiboard(_multiboard);
      _multiboard = CreateMultiboard();
      MultiboardSetColumnCount(_multiboard, ColumnCount);
      MultiboardSetRowCount(_multiboard, 3);
      MultiboardSetTitleText(_multiboard, Title);
      MultiboardDisplay(_multiboard, true);
      MultiboardSetRowCount(_multiboard, 30);
      UpdateHeaderRow();
      row += 1;
      foreach (var team in FactionManager.GetAllTeams())
        if (team.Size > 0)
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

    private static void OnFactionTeamJoin(object? sender, Team team)
    {
      RenderInstance();
    }

    private static void OnFactionTeamLeft(object? sender, PlayerChangeTeamEventArgs playerChangeTeamEventArgs)
    {
      RenderInstance();
    }

    private static void OnFactionStatusChanged(object? sender, Faction faction)
    {
      RenderInstance();
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