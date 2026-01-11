using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Exceptions;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Shared;

namespace MacroTools.UserInterface;

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

  private const float WidthFaction = 0.09f;
  private const float WidthCp = 0.02f;
  private const float WidthIncome = 0.022f;
  private const float WidthTeam = WidthFaction + WidthCp + WidthIncome;

  private static bool _initialized;

  private readonly Dictionary<Faction, int> _rowsByFaction = new();
  private readonly Dictionary<Team, int> _rowsByTeam = new();
  private multiboard _multiboard;

  private FactionMultiboard(int columnCount, int rowCount, string title)
  {
    _multiboard = multiboard.Create();
    _multiboard.Rows = rowCount;
    _multiboard.Columns = columnCount;
    _multiboard.Title = title;
    _multiboard.IsDisplayed = true;
    Render();
  }

  private static FactionMultiboard? Instance { get; set; }

  /// <summary>
  /// Sets up the globally visible <see cref="FactionMultiboard"/>.
  /// </summary>
  public static void Setup()
  {
    if (_initialized)
    {
      throw new SystemAlreadyInitializedException(nameof(FactionMultiboard));
    }

    timer timer = timer.Create();
    timer.Start(2, false, () => { Instance = new FactionMultiboard(ColumnCount, 3, Title); });

    PlayerData.FactionChange += (_, _) => { Instance?.Render(); };
    FactionManager.AnyFactionNameChanged += OnFactionAnyFactionNameChanged;
    FactionManager.FactionRegistered += (_, faction) => { RegisterFaction(faction); };

    foreach (var player in Util.EnumeratePlayers())
    {
      var playerData = player.GetPlayerData();
      playerData.IncomeChanged += OnPlayerIncomeChanged;
      playerData.PlayerJoinedTeam += (_, _) => { Instance?.Render(); };
      playerData.PlayerLeftTeam += (_, _) => { Instance?.Render(); };
    }

    foreach (var faction in FactionManager.GetAllFactions())
    {
      RegisterFaction(faction);
    }

    _initialized = true;
  }

  private void UpdateFactionRow(Faction faction)
  {
    if (!_rowsByFaction.TryGetValue(faction, out var row))
    {
      return;
    }

    var factionMbi = _multiboard.GetItem(row, ColumnFaction);
    var cpMbi = _multiboard.GetItem(row, ColumnCp);
    var incomeMbi = _multiboard.GetItem(row, ColumnIncome);
    factionMbi.SetText(faction.ColoredName);
    factionMbi.SetIcon(faction.Icon);

    var player = faction.Player;
    if (player != null)
    {
      var playerData = player.GetPlayerData();

      cpMbi.SetText(playerData.ControlPoints.Count.ToString());

      var income = R2I(playerData.TotalIncome);
      var hasBonus = playerData.BonusIncome > 0;
      var incomePrefix = hasBonus ? "|cffffcc00" : "";
      var incomeText = income <= 999 ? $"{incomePrefix}{income}" : $"{incomePrefix}BIG";

      incomeMbi.SetText(incomeText);
    }
    else
    {
      cpMbi.SetText("");
      incomeMbi.SetText("");
    }

    factionMbi.SetWidth(WidthFaction);
    cpMbi.SetWidth(WidthCp);
    incomeMbi.SetWidth(WidthIncome);
    factionMbi.SetVisibility(true, true);
    cpMbi.SetVisibility(true, false);
    incomeMbi.SetVisibility(true, false);
  }

  private void UpdateTeamRow(Team team)
  {
    var row = _rowsByTeam[team];
    var mbi = _multiboard.GetItem(row, ColumnTeam);
    mbi.SetText($"---{team.Name}{SubString("-----------------------------------------", 0, 19 - StringLength(team.Name))}");
    mbi.SetWidth(WidthTeam);
    mbi.SetVisibility(true, false);
    _multiboard.GetItem(row, ColumnCp).SetVisibility(false, false);
    _multiboard.GetItem(row, ColumnIncome).SetVisibility(false, false);
  }

  private void UpdateHeaderRow()
  {
    var factionMbi = _multiboard.GetItem(0, ColumnFaction);
    var cpMbi = _multiboard.GetItem(0, ColumnCp);
    var incomeMbi = _multiboard.GetItem(0, ColumnIncome);
    factionMbi.SetVisibility(false, false);
    cpMbi.SetVisibility(false, true);
    incomeMbi.SetVisibility(false, true);
    cpMbi.SetIcon("ReplaceableTextures\\CommandButtons\\BTNCOP.blp");
    incomeMbi.SetIcon("ReplaceableTextures\\CommandButtons\\BTNMGexchange.blp");
    factionMbi.SetWidth(WidthFaction);
    cpMbi.SetWidth(WidthCp);
    incomeMbi.SetWidth(WidthIncome);
  }

  //Run when the number of Teams or Factions have changed, or a Faction has changed its Team
  private void Render()
  {
    _rowsByFaction.Clear();
    _rowsByTeam.Clear();
    var row = 0;
    _multiboard.Dispose();
    _multiboard = multiboard.Create();
    _multiboard.Columns = ColumnCount;
    _multiboard.Rows = 3;
    _multiboard.Title = Title;
    _multiboard.IsDisplayed = true;
    _multiboard.Rows = 30;
    UpdateHeaderRow();
    row += 1;
    foreach (var team in FactionManager.GetAllTeams())
    {
      if (team.UndefeatedPlayerCount <= 0)
      {
        continue;
      }

      _rowsByTeam[team] = row;
      UpdateTeamRow(team);
      row += 1;
      foreach (var faction in team.GetAllFactions())
      {
        if (faction.Player != null && faction.ScoreStatus != ScoreStatus.Defeated)
        {
          _rowsByFaction[faction] = row;
          UpdateFactionRow(faction);
          row += 1;
        }
      }
    }
    _multiboard.Rows = row;
  }

  private static void RegisterFaction(Faction faction)
  {
    faction.StatusChanged += (_, _) => { Instance?.Render(); };
    faction.IconChanged += OnFactionIconChanged;
  }

  private static void OnFactionAnyFactionNameChanged(object? sender, Faction faction)
  {
    Instance?.UpdateFactionRow(faction);
  }

  private static void OnPlayerIncomeChanged(object? sender, PlayerData player)
  {
    var faction = player.Faction;
    if (faction != null)
    {
      Instance?.UpdateFactionRow(faction);
    }
  }

  private static void OnFactionIconChanged(object? sender, Faction args)
  {
    Instance?.UpdateFactionRow(args);
  }
}
