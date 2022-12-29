using MacroTools.ControlPointSystem;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives
{
  /// <summary>
  /// Completed when a <see cref="ControlPoint"/> has a certain <see cref="ControlPoint.ControlLevel"/>.
  /// </summary>
  public sealed class ObjectiveControlLevel : Objective
  {
    private readonly ControlPoint _target;
    private readonly int _requiredLevel;
    
    /// <inheritdoc/>
    public override Point Position => new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveControlLevel"/> class.
    /// </summary>
    /// <param name="target">The <see cref="ControlPoint"/> that must reach the specified level.</param>
    /// <param name="requiredLevel">The level the <see cref="ControlPoint"/> must reach.</param>
    public ObjectiveControlLevel(ControlPoint target, int requiredLevel)
    {
      _target = target;
      _requiredLevel = requiredLevel;
      target.ControlLevelChanged += (_, _) =>
      {
        RefreshDescription();
        Progress = target.ControlLevel >= requiredLevel ? QuestProgress.Complete : QuestProgress.Incomplete;
      };
      RefreshDescription();
    }
    
    internal override void OnAdd(Faction whichFaction)
    {
      Progress = _target.ControlLevel >= _requiredLevel
        ? QuestProgress.Complete
        : QuestProgress.Incomplete;
    }

    private void RefreshDescription() => Description =
      $"{_target.Name} is Control Level {_requiredLevel} or higher ({_target.ControlLevel}/{_requiredLevel})";
  }
}