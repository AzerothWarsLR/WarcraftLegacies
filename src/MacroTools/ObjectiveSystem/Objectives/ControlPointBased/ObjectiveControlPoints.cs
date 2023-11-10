using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using System.Collections.Generic;

namespace MacroTools.ObjectiveSystem.Objectives.ControlPointBased
{
  /// <summary>
  /// Completes when all specficied control points are controlled by the same team
  /// </summary>
  public sealed class ObjectiveControlPoints : Objective
  {
    private readonly List<ControlPoint> _controlPoints;
    private readonly string _rectName;
    private int _controlPointCount;

    private int ControlPointCount
    {
      get => _controlPointCount;
      set
      {
        _controlPointCount = value;
        Description = $"Your team controls {ControlPointCount} / {_controlPoints.Count} CPs {_rectName}";
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveControlPoints"/> class.
    /// </summary>
    /// <param name="controlPoints">The control points that have to be owned by the same team.</param>
    /// <param name="rectName">The name of the rectangle shown in the description of the quest.</param>
    public ObjectiveControlPoints(List<ControlPoint> controlPoints, string rectName)
    {
      _controlPoints = controlPoints;
      _rectName = rectName;
      ControlPointCount = 0;
      foreach (var controlPoint in controlPoints)
      {
        controlPoint.ChangedOwner += OnTargetChangeOwner;
        controlPoint.Owner.GetPlayerData().PlayerJoinedTeam += OnFactionTeamJoin;
        controlPoint.Owner.GetPlayerData().PlayerLeftTeam += OnFactionTeamLeave;
        if (IsPlayerOnSameTeamAsAnyEligibleFaction(controlPoint.Unit.OwningPlayer()))
          ControlPointCount++;
      }
    }

    internal override void OnAdd(Faction whichFaction)
    {
      foreach (var controlPoint in _controlPoints)
      {
        if (IsPlayerOnSameTeamAsAnyEligibleFaction(controlPoint.Unit.OwningPlayer()))
          ControlPointCount++;
      }

      CheckObjectiveProgress();
    }

    private void OnTargetChangeOwner(object? sender, ControlPointOwnerChangeEventArgs args)
    {
      var controlPoint = args.ControlPoint;
      if (_controlPoints.Contains(controlPoint))
      {
        if (!IsPlayerOnSameTeamAsAnyEligibleFaction(args.FormerOwner) &&
            IsPlayerOnSameTeamAsAnyEligibleFaction(controlPoint.Owner))
          ControlPointCount++;
        else if (IsPlayerOnSameTeamAsAnyEligibleFaction(args.FormerOwner) &&
                 !IsPlayerOnSameTeamAsAnyEligibleFaction(controlPoint.Owner))
          ControlPointCount--;
      }

      CheckObjectiveProgress();
    }

    private void OnFactionTeamJoin(object? sender, PlayerChangeTeamEventArgs args)
    {
      foreach (var controlPoint in _controlPoints)
      {
        if (controlPoint.Unit.OwningPlayer() == args.Player)
          ControlPointCount++;
      }

      CheckObjectiveProgress();
    }

    private void OnFactionTeamLeave(object? sender, PlayerChangeTeamEventArgs args)
    {
      foreach (var controlPoint in _controlPoints)
      {
        if (controlPoint.Unit.OwningPlayer() == args.Player)
          ControlPointCount--;
      }

      CheckObjectiveProgress();
    }

    private void CheckObjectiveProgress() => Progress =
      ControlPointCount == _controlPoints.Count ? QuestProgress.Complete : QuestProgress.Incomplete;
  }
}