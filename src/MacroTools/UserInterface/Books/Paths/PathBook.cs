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
  private const int DisplayGroupCount = 5;

  private readonly List<FactionPath> _watchedPaths = new();
  private readonly List<FactionPath> _seenPaths = new();
  private Faction? _trackedFaction;
  private player _owner = null!;
  private LauncherGlow? _glow;

  private PathBook() : base(0.37f, 0.44f, 0.02f, 0.015f, 8)
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
    if (_glow == null)
    {
      _glow = new LauncherGlow("PathBookLauncherGlow", LauncherButton);
    }

    if (_owner != player.LocalPlayer)
    {
      return;
    }

    if (!Visible)
    {
      LauncherButton.Visible = _watchedPaths.Count > 0;
    }

    _glow.Visible = LauncherButton.Visible && HasUnseenPath();
  }

  private bool HasUnseenPath()
  {
    foreach (var path in _watchedPaths)
    {
      if (path.State == PathState.Available && !_seenPaths.Contains(path))
      {
        return true;
      }
    }

    return false;
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
        _trackedFaction.PathRemoved -= OnFactionAddPath;
      }

      _trackedFaction = value;

      if (_trackedFaction != null)
      {
        _trackedFaction.PathAdded += OnFactionAddPath;
        _trackedFaction.PathRemoved += OnFactionAddPath;
      }

      ReRender();
    }
  }

  private void OnPlayerChangedFaction(PlayerFactionChangeEventArgs args)
  {
    TrackedFaction = args.Player.GetPlayerData().Faction;
  }

  private void OnFactionAddPath(FactionPath path) => ReRender();

  /// <inheritdoc />
  protected override void PopulatePages()
  {
    foreach (var path in _watchedPaths)
    {
      path.StateChanged -= OnPathStateChanged;
      path.Updated -= OnPathChanged;
    }

    _watchedPaths.Clear();

    if (_trackedFaction != null)
    {
      var paths = _trackedFaction.GetAllPaths();
      AddTakenPathsNewestFirst(paths);
      for (var group = 1; group < DisplayGroupCount; group++)
      {
        foreach (var path in paths)
        {
          if (GetDisplayGroup(path.State) == group)
          {
            AddPath(path);
          }
        }
      }
    }

    RefreshNavigationButtonVisiblity();
    RefreshLauncher();
  }

  private void AddTakenPathsNewestFirst(IReadOnlyList<FactionPath> paths)
  {
    var added = new List<FactionPath>();
    while (true)
    {
      FactionPath? newest = null;
      foreach (var path in paths)
      {
        if (path.State == PathState.Taken && !added.Contains(path) && (newest == null || path.TakenOrder > newest.TakenOrder))
        {
          newest = path;
        }
      }

      if (newest == null)
      {
        return;
      }

      added.Add(newest);
      AddPath(newest);
    }
  }

  private void AddPath(FactionPath path)
  {
    GetFirstAvailablePage().AddItem(path);
    _watchedPaths.Add(path);
    path.StateChanged += OnPathStateChanged;
    path.Updated += OnPathChanged;
  }

  private void OnPathStateChanged(FactionPath path)
  {
    if (path.State == PathState.Locked)
    {
      _seenPaths.Remove(path);
    }

    ReRender();
  }

  /// <inheritdoc />
  protected override void OnOpened()
  {
    foreach (var path in _watchedPaths)
    {
      if (path.State == PathState.Available && !_seenPaths.Contains(path))
      {
        _seenPaths.Add(path);
      }
    }

    RefreshLauncher();
  }

  /// <summary>
  /// Where a path with this state sits in the book: taken paths first, then ones that can still be taken, then ones
  /// that are gone. A path that is committing stays where it was until it is actually taken.
  /// </summary>
  private static int GetDisplayGroup(PathState state) => state switch
  {
    PathState.Taken => 0,
    PathState.Available or PathState.Committing => 1,
    PathState.Locked => 2,
    PathState.Declined => 3,
    _ => 4
  };

  private void OnPathChanged(FactionPath path) => RefreshLauncher();

  private string GetLauncherText()
  {
    var title = Loc.Get("Paths");
    var expiringIn = float.MaxValue;
    foreach (var path in _watchedPaths)
    {
      if (path.State == PathState.Committing)
      {
        return $"{title} |cffffcc00{CardText.FormatTime(path.CommitTimeRemaining)}|r";
      }

      if (path.State == PathState.Available && path.OfferDuration > 0 && path.OfferTimeRemaining < expiringIn)
      {
        expiringIn = path.OfferTimeRemaining;
      }
    }

    if (expiringIn < float.MaxValue)
    {
      return $"{title} |cffff3030{CardText.FormatTime(expiringIn)}|r";
    }

    return HasUnseenPath() ? $"{title} |cff00ff00(!)|r" : title;
  }
}
