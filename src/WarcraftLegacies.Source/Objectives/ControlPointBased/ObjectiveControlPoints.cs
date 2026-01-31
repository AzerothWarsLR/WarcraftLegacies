using System.Collections.Generic;
using System.Linq;
using MacroTools.ControlPointSystem;
using MacroTools.FactionSystem;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.ControlPointBased;

/// <summary>
/// Completes when all specficied control points are controlled by the same team
/// </summary>
public sealed class ObjectiveControlPoints : Objective
{
  private readonly Dictionary<ControlPoint, bool> _progressByControlPoint;
  private readonly string _rectName;
  private int _controlPointCount;

  private int ControlPointCount
  {
    get => _controlPointCount;
    set
    {
      _controlPointCount = value;
      Description = $"You control all CPs {_rectName} ({ControlPointCount}/{_progressByControlPoint.Count})";
      CheckObjectiveProgress();
    }
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveControlPoints"/> class.
  /// </summary>
  /// <param name="controlPoints">The control points that have to be owned by the same team.</param>
  /// <param name="rectName">The name of the rectangle shown in the description of the quest.</param>
  public ObjectiveControlPoints(IEnumerable<ControlPoint> controlPoints, string rectName)
  {
    _progressByControlPoint = controlPoints.ToDictionary(key => key, _ => false);
    _rectName = rectName;
  }

  /// <inheritdoc/>
  public override void OnAdd(Faction whichFaction)
  {
    ControlPointCount = 0;
    foreach (var controlPoint in _progressByControlPoint.Keys.ToArray())
    {
      controlPoint.OwnerAllianceChanged += OnTargetOwnerAllianceChanged;
      SetControlPointProgress(controlPoint, IsPlayerOnSameTeamAsAnyEligibleFaction(controlPoint.Unit.Owner));
    }
  }

  private void OnTargetOwnerAllianceChanged(object? sender, ControlPoint controlPoint)
  {
    SetControlPointProgress(controlPoint, IsPlayerOnSameTeamAsAnyEligibleFaction(controlPoint.Owner));
  }

  private void SetControlPointProgress(ControlPoint controlPoint, bool newProgress)
  {
    var currentProgress = _progressByControlPoint[controlPoint];
    if (currentProgress == newProgress)
    {
      return;
    }

    _progressByControlPoint[controlPoint] = newProgress;
    if (newProgress)
    {
      ControlPointCount++;
    }
    else
    {
      ControlPointCount--;
    }
  }

  private void CheckObjectiveProgress() => Progress =
    ControlPointCount == _progressByControlPoint.Count ? QuestProgress.Complete : QuestProgress.Incomplete;
}
