using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Paths;
using MacroTools.UserInterface.Books.Core;
using WCSharp.Shared.Data;

namespace MacroTools.UserInterface.Books.Paths;

/// <summary>
/// Shows all the <see cref="FactionPath"/>s a particular player can take, and lets them accept or decline them.
/// </summary>
public sealed class PathBook : Book<FactionPath, PathPage, PathCard, PathPageFactory, PathCardFactory>
{
  private readonly List<FactionPath> _watchedPaths = new();
  private Faction? _trackedFaction;
  private player _owner = null!;

  private PathBook() : base(0.37f, 0.44f, 0.02f, 0.015f, 4)
  {
  }

  public static PathBook Create(player whichPlayer)
  {
    var playerData = whichPlayer.GetPlayerData();

    var book = new PathBook
    {
      Title = Loc.Get("Paths"),
      LauncherParent = framehandle.Get("UpperButtonBarAlliesButton", 0),
      Position = new Point(0.4f, 0.34f)
    };
    book._owner = whichPlayer;
    book.TrackedFaction = playerData.Faction;

    playerData.ChangedFaction += book.OnPlayerChangedFaction;

    return book;
  }

  /// <summary>
  /// Updates the launcher button's text, and only shows it when the player has paths to look at.
  /// </summary>
  public void RefreshLauncher()
  {
    if (LauncherButton == null)
    {
      return;
    }

    LauncherButton.Text = GetLauncherText();
    if (_owner == player.LocalPlayer && !Visible)
    {
      LauncherButton.Visible = _watchedPaths.Count > 0;
    }
  }

  private Faction? TrackedFaction
  {
    set
    {
      if (_trackedFaction == value)
      {
        return;
      }

      if (_trackedFaction != null)
      {
        _trackedFaction.PathAdded -= OnFactionAddPath;
      }

      _trackedFaction = value;

      if (_trackedFaction != null)
      {
        _trackedFaction.PathAdded += OnFactionAddPath;
      }

      ReRender();
    }
  }

  private void OnPlayerChangedFaction(PlayerFactionChangeEventArgs args)
  {
    TrackedFaction = args.Player.GetPlayerData().Faction;
  }

  private void OnFactionAddPath(FactionPath path)
  {
    AddPath(path);
    RefreshNavigationButtonVisiblity();
    RefreshLauncher();
  }

  /// <inheritdoc />
  protected override void PopulatePages()
  {
    foreach (var path in _watchedPaths)
    {
      path.StateChanged -= OnPathChanged;
      path.Updated -= OnPathChanged;
    }

    _watchedPaths.Clear();

    if (_trackedFaction != null)
    {
      foreach (var path in _trackedFaction.GetAllPaths())
      {
        AddPath(path);
      }
    }

    RefreshNavigationButtonVisiblity();
    RefreshLauncher();
  }

  private void AddPath(FactionPath path)
  {
    GetFirstAvailablePage().AddItem(path);
    _watchedPaths.Add(path);
    path.StateChanged += OnPathChanged;
    path.Updated += OnPathChanged;
  }

  private void OnPathChanged(FactionPath path) => RefreshLauncher();

  private string GetLauncherText()
  {
    var title = Loc.Get("Paths");
    var anyAvailable = false;
    foreach (var path in _watchedPaths)
    {
      if (path.State == PathState.Committing)
      {
        return $"{title} |cffffcc00{PathCard.FormatTime(path.CommitTimeRemaining)}|r";
      }

      if (path.State == PathState.Available)
      {
        anyAvailable = true;
      }
    }

    return anyAvailable ? $"{title} |cff00ff00(!)|r" : title;
  }
}
