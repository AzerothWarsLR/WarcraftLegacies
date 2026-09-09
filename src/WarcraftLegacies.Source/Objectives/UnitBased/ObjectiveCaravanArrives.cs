using MacroTools.Localization;
using MacroTools.Quests;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>
/// Tracks the caravan's arrival at a waypoint. Progress is driven externally by
/// <see cref="Factions.TaurenTribes.Mechanics.LongMarchCaravan"/> once it actually reaches that waypoint.
/// </summary>
public sealed class ObjectiveCaravanArrives : Objective
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveCaravanArrives"/> class.
  /// </summary>
  /// <param name="targetRect">Where the caravan has to arrive.</param>
  /// <param name="rectName">A user-friendly name for the area.</param>
  public ObjectiveCaravanArrives(Rectangle targetRect, string rectName)
    : this(new Point(targetRect.Rect.CenterX, targetRect.Rect.CenterY), rectName)
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveCaravanArrives"/> class.
  /// </summary>
  /// <param name="targetPosition">Where the caravan has to arrive.</param>
  /// <param name="rectName">A user-friendly name for the area.</param>
  public ObjectiveCaravanArrives(Point targetPosition, string rectName)
  {
    SetDescription("The caravan reaches {rect}", ("{rect}", Loc.Get(rectName)));
    DisplaysPosition = true;
    PingPath = "MinimapQuestTurnIn";
    Position = targetPosition;
  }
}
