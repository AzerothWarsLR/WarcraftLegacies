using System.Collections.Generic;
using MacroTools.Localization;
using MacroTools.UserInterface.Books.Core;
using MacroTools.WorldEvents;
using WCSharp.Shared.Data;

namespace MacroTools.UserInterface.Books.WorldEvents;

/// <summary>
/// Shows every <see cref="WorldEvent"/> in the game, what triggers it, and when it happened. Everyone sees the same thing.
/// </summary>
public sealed class EventBook : Book<WorldEvent, EventPage, EventCard, EventPageFactory, EventCardFactory>
{
  public EventBook() : base(0.75f, 0.42f, 0.015f, 0.02f, 6)
  {
    Title = Loc.Get("Events");
    LauncherParent = framehandle.Get("UpperButtonBarChatButton", 0);
    Position = new Point(0.4f, 0.34f);

    foreach (var worldEvent in GetEventsInOrder())
    {
      AddEvent(worldEvent);
    }

    foreach (var worldEvent in WorldEventManager.GetAll())
    {
      Watch(worldEvent);
    }

    WorldEventManager.EventRegistered += OnEventRegistered;
  }

  /// <summary>
  /// Updates the launcher button's text, and only shows it once there are events to look at.
  /// </summary>
  public void RefreshLauncher()
  {
    if (LauncherButton == null)
    {
      return;
    }

    LauncherButton.Text = GetLauncherText();
    if (!Visible)
    {
      LauncherButton.Visible = WorldEventManager.GetAll().Count > 0;
    }
  }

  /// <inheritdoc />
  protected override void PopulatePages()
  {
    foreach (var worldEvent in GetEventsInOrder())
    {
      AddEvent(worldEvent);
    }

    RefreshNavigationButtonVisiblity();
  }

  private void OnEventRegistered(WorldEvent worldEvent)
  {
    Watch(worldEvent);
    ReRender();
    RefreshLauncher();
  }

  private static List<WorldEvent> GetEventsInOrder()
  {
    var allEvents = WorldEventManager.GetAll();
    var ordered = new List<WorldEvent>(allEvents);
    ordered.Sort((a, b) =>
    {
      var byGroup = GetOrderGroup(a).CompareTo(GetOrderGroup(b));
      if (byGroup != 0)
      {
        return byGroup;
      }

      var byTurn = GetOrderTurn(a).CompareTo(GetOrderTurn(b));
      return byTurn != 0 ? byTurn : IndexOf(allEvents, a).CompareTo(IndexOf(allEvents, b));
    });
    return ordered;
  }

  private static int GetOrderGroup(WorldEvent worldEvent) => worldEvent.State switch
  {
    WorldEventState.Happened => 0,
    WorldEventState.Imminent => 1,
    WorldEventState.Upcoming => 2,
    _ => 3
  };

  private static int GetOrderTurn(WorldEvent worldEvent)
  {
    if (worldEvent.State == WorldEventState.Happened)
    {
      return worldEvent.HappenedOnTurn;
    }

    return worldEvent.EarliestTurn > 0 ? worldEvent.EarliestTurn : int.MaxValue;
  }

  private static int IndexOf(IReadOnlyList<WorldEvent> events, WorldEvent worldEvent)
  {
    for (var i = 0; i < events.Count; i++)
    {
      if (events[i] == worldEvent)
      {
        return i;
      }
    }

    return events.Count;
  }

  private void AddEvent(WorldEvent worldEvent) => GetFirstAvailablePage().AddItem(worldEvent);

  private void Watch(WorldEvent worldEvent)
  {
    worldEvent.StateChanged += OnEventStateChanged;
    worldEvent.Updated += OnEventChanged;
  }

  private void OnEventChanged(WorldEvent worldEvent) => RefreshLauncher();

  private void OnEventStateChanged(WorldEvent worldEvent)
  {
    ReRender();
    RefreshLauncher();
  }

  private static string GetLauncherText()
  {
    var title = Loc.Get("Events");
    var soonest = float.MaxValue;
    foreach (var worldEvent in WorldEventManager.GetAll())
    {
      if (worldEvent.State == WorldEventState.Imminent && worldEvent.WarningTimeRemaining < soonest)
      {
        soonest = worldEvent.WarningTimeRemaining;
      }
    }

    return soonest < float.MaxValue ? $"{title} |cffff8800{CardText.FormatTime(soonest)}|r" : title;
  }
}
