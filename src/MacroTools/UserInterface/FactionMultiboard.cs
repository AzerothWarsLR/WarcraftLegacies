using System.Collections.Generic;
using System.Linq;
using MacroTools.ControlPoints;
using MacroTools.Exceptions;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using WCSharp.Shared;

namespace MacroTools.UserInterface;

/// <summary>
///   Displays the name, color, <see cref="Team" />, <see cref="ControlPoint" /> count, and income of all
///   <see cref="Faction" />s in the game.
/// </summary>
public sealed class FactionMultiboard
{
  private const int ColumnCount = 3;
  private static readonly string _title = Loc.Get("Scoreboard");
  private const int ColumnFaction = 0;
  private const int ColumnCp = 1;
  private const int ColumnIncome = 2;
  private const int ColumnTeam = 0;
  private const string HeaderColor = "|cffffcc00";
  private const string SubTeamColor = "|cffbbbbbb";

  private const float WidthFaction = 0.1f;
  private const float WidthCp = 0.02f;
  private const float WidthIncome = 0.022f;
  private const float WidthTeam = WidthFaction + WidthCp + WidthIncome;

  private static bool _initialized;

  private readonly Dictionary<Faction, int> _rowsByFaction = new();
  private readonly Dictionary<Team, int> _rowsByTeam = new();
  private readonly Dictionary<Bloc, int> _rowsByBloc = new();
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
    timer.Start(2, false, () =>
    {
      Instance = new FactionMultiboard(ColumnCount, 3, _title);
      @event.ExpiredTimer.Dispose();
    });

    PlayerData.FactionChange += _ => Instance?.Render();
    FactionManager.AnyFactionNameChanged += OnFactionAnyFactionNameChanged;
    FactionManager.FactionRegistered += RegisterFaction;

    foreach (var player in Util.EnumeratePlayers())
    {
      var playerData = player.GetPlayerData();
      playerData.IncomeChanged += OnPlayerIncomeChanged;
      playerData.PlayerJoinedTeam += _ => Instance?.Render();
      playerData.PlayerLeftTeam += _ => Instance?.Render();
    }

    TeamChanges.OnAnyTeamChanged(() => Instance?.Render());
    TeamHandicaps.OnChanged(() => Instance?.Render());

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
      // "BIG" stands in for a figure the column has no room for, so it is a word a player reads and is looked up.
      var incomeText = income <= 999
        ? $"{incomePrefix}{income}"
        : incomePrefix + Loc.Get("BIG");

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
    var teamName = team.LocalizedName;
    if (team.Bloc != null)
    {
      SetHeaderText(row, $"  {SubTeamColor}{teamName}|r");
      return;
    }

    var sizeText = GetSizeText(team);
    if (!TeamChanges.HasCapacityRules)
    {
      SetHeaderText(row, $"---{teamName}{SubString("-----------------------------------------", 0, 19 - StringLength(teamName))}");
      return;
    }

    SetHeaderText(row, $"{HeaderColor}{teamName}{sizeText}|r");
  }

  private void UpdateBlocRow(Bloc bloc)
  {
    var row = _rowsByBloc[bloc];
    var sizeText = bloc.Teams.Count > 0 ? GetSizeText(bloc.Teams[0]) : "";
    SetHeaderText(row, $"{HeaderColor}{bloc.LocalizedName}{sizeText}|r");
  }

  private void SetHeaderText(int row, string text)
  {
    var mbi = _multiboard.GetItem(row, ColumnTeam);
    mbi.SetText(text);
    mbi.SetWidth(WidthTeam);
    mbi.SetVisibility(true, false);
    _multiboard.GetItem(row, ColumnCp).SetVisibility(false, false);
    _multiboard.GetItem(row, ColumnIncome).SetVisibility(false, false);
  }

  private static string GetSizeText(Team team)
  {
    var capacity = TeamChanges.Capacity(team);
    if (!TeamChanges.HasCapacityRules)
    {
      return "";
    }

    return capacity == int.MaxValue ? $" {TeamChanges.GetSize(team)}" : $" {TeamChanges.GetSize(team)}/{capacity}";
  }

  private static string GetHandicapText(Team team)
  {
    var handicap = TeamHandicaps.GetHandicap(team);
    return handicap > 0
      ? $"  |cff00ff00{Loc.Format("Handicap +{percent}%", ("{percent}", R2I(handicap * 100 + 0.5f).ToString()))}|r"
      : "";
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
    _rowsByBloc.Clear();
    var row = 0;
    _multiboard.Dispose();
    _multiboard = multiboard.Create();
    _multiboard.Columns = ColumnCount;
    _multiboard.Rows = 3;
    _multiboard.Title = _title;
    _multiboard.IsDisplayed = true;
    _multiboard.Rows = 40;
    UpdateHeaderRow();
    row += 1;
    foreach (var team in FactionManager.GetAllTeams())
    {
      if (team.Bloc == null)
      {
        row = RenderTeam(team, row);
        continue;
      }

      if (_rowsByBloc.ContainsKey(team.Bloc) || team.Bloc.Teams.All(x => x.UndefeatedPlayerCount <= 0))
      {
        continue;
      }

      _rowsByBloc[team.Bloc] = row;
      UpdateBlocRow(team.Bloc);
      row += 1;
      row = team.Bloc.ShowsTeams ? RenderBlocTeams(team.Bloc, row) : RenderBlocAsOne(team.Bloc, row);
    }
    _multiboard.Rows = row;
  }

  private int RenderBlocTeams(Bloc bloc, int row)
  {
    foreach (var blocTeam in bloc.Teams)
    {
      row = RenderTeam(blocTeam, row);
    }

    return row;
  }

  /// <summary>Lists every faction in the bloc under its header, with one shared handicap row.</summary>
  private int RenderBlocAsOne(Bloc bloc, int row)
  {
    foreach (var blocTeam in bloc.Teams)
    {
      if (blocTeam.UndefeatedPlayerCount <= 0)
      {
        continue;
      }

      row = RenderHandicap(blocTeam, row);
      break;
    }

    foreach (var blocTeam in bloc.Teams)
    {
      row = RenderFactions(blocTeam, row);
    }

    return row;
  }

  private int RenderTeam(Team team, int row)
  {
    if (team.UndefeatedPlayerCount <= 0)
    {
      return row;
    }

    _rowsByTeam[team] = row;
    UpdateTeamRow(team);
    row += 1;
    row = RenderHandicap(team, row);
    return RenderFactions(team, row);
  }

  private int RenderHandicap(Team team, int row)
  {
    var handicapText = GetHandicapText(team);
    if (handicapText != "")
    {
      SetHeaderText(row, handicapText);
      row += 1;
    }

    return row;
  }

  private int RenderFactions(Team team, int row)
  {
    foreach (var faction in team.GetAllFactions())
    {
      if (faction.Player != null && faction.ScoreStatus != ScoreStatus.Defeated)
      {
        _rowsByFaction[faction] = row;
        UpdateFactionRow(faction);
        row += 1;
      }
    }

    return row;
  }

  private static void RegisterFaction(Faction faction)
  {
    faction.StatusChanged += _ => Instance?.Render();
    faction.IconChanged += OnFactionIconChanged;
  }

  private static void OnFactionAnyFactionNameChanged(Faction faction)
  {
    Instance?.UpdateFactionRow(faction);
  }

  private static void OnPlayerIncomeChanged(PlayerData player)
  {
    var faction = player.Faction;
    if (faction != null)
    {
      Instance?.UpdateFactionRow(faction);
    }
  }

  private static void OnFactionIconChanged(Faction args)
  {
    Instance?.UpdateFactionRow(args);
  }
}
