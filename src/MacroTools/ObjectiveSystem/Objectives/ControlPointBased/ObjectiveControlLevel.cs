using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.ControlPointBased
{
  /// <summary>
  /// Completed when a <see cref="ControlPoint"/> has a certain <see cref="ControlPoint.ControlLevel"/>.
  /// </summary>
  public sealed class ObjectiveControlLevel : Objective
  {
    private readonly ControlPointSystem.ControlPoint _target;
    private readonly int _requiredLevel;
    
    /// <inheritdoc/>
    public override Point Position => new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveControlLevel"/> class.
    /// </summary>
    /// <param name="target">The <see cref="ControlPoint"/> that must reach the specified level.</param>
    /// <param name="requiredLevel">The level the <see cref="ControlPoint"/> must reach.</param>
    public ObjectiveControlLevel(ControlPointSystem.ControlPoint target, int requiredLevel)
    {
      _target = target;
      _requiredLevel = requiredLevel;
      target.ChangedOwner += (_, _) => Refresh();
      target.Owner.GetPlayerData().PlayerJoinedTeam += (_, _) => Refresh();
      _target.ControlLevelChanged += (_, _) => Refresh();
      TargetWidget = target.Unit;
      DisplaysPosition = true;
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
    
    private void RefreshDescription() => Description =
      IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Owner)
        ? $"{_target.Name} is Control Level {_requiredLevel} or higher ({_target.ControlLevel}/{_requiredLevel})"
        : $"{_target.Name} is Control Level {_requiredLevel} or higher";

    private void RefreshProgress()
    {
      Progress = _target.ControlLevel >= _requiredLevel && IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Owner)
        ? QuestProgress.Complete 
        : QuestProgress.Incomplete;
    }
  }
}