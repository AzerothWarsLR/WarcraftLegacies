using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.ControlPointBased
{
  /// <summary>
  /// Completed when a <see cref="ControlPoint"/> has a certain <see cref="ControlPoint.ControlLevel"/>.
  /// </summary>
  public sealed class ObjectiveControlLevel : Objective
  {
    private readonly ControlPoint _target;
    private readonly int _requiredLevel;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveControlLevel"/> class.
    /// </summary>
    /// <param name="target">The <see cref="ControlPoint"/> that must reach the specified level.</param>
    /// <param name="requiredLevel">The level the <see cref="ControlPoint"/> must reach.</param>
    public ObjectiveControlLevel(ControlPoint target, int requiredLevel)
    {
      _target = target;
      _requiredLevel = requiredLevel;
      target.ChangedOwner += (_, _) => Refresh();
      target.Owner.GetPlayerData().PlayerJoinedTeam += (_, _) => Refresh();
      _target.ControlLevelChanged += (_, _) => Refresh();
      TargetWidget = target.Unit;
      DisplaysPosition = true;
      Position = new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));
    }

    internal override void OnAdd(FactionSystem.Faction whichFaction)
    {
      RefreshDescription();
      RefreshProgress();
    }

    private void Refresh()
    {
      RefreshDescription();
      RefreshProgress();
    }

    private void RefreshDescription()
    {
      var isOnSameTeam = IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Owner);
      Description = isOnSameTeam is false or null
        ? $"{_target.Name} is Control Level {_requiredLevel} or higher"
        : $"{_target.Name} is Control Level {_requiredLevel} or higher ({(int)_target.ControlLevel}/{_requiredLevel})";
    }

    private void RefreshProgress()
    {
      var isOnSameTeam = IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Owner);
      if (isOnSameTeam == null)
      {
        Progress = QuestProgress.Incomplete;
      }
      else
      {
        Progress = _target.ControlLevel >= _requiredLevel && isOnSameTeam == true ? QuestProgress.Complete : QuestProgress.Incomplete;
      }
    }
  }
}