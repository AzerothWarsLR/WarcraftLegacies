using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.LegendBased
{
  /// <summary>
  /// Do not gain control of a particular <see cref="Legend"/>.
  /// </summary>
  public sealed class ObjectiveDontControlLegend : Objective
  {
    private readonly Legend _target;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveDontControlLegend"/> class.
    /// </summary>
    public ObjectiveDontControlLegend(LegendaryHero target)
    {
      _target = target;
      Description = $"You don't control {target.Name}";
      if (target.Unit != null) 
        TargetWidget = target.Unit;

      DisplaysPosition = GetOwningPlayer(target.Unit) == Player(PLAYER_NEUTRAL_AGGRESSIVE);
      target.ChangedOwner += OnTargetChangeOwner;
      Position = new(GetUnitX(_target.Unit), GetUnitY(_target.Unit));
    }

    internal override void OnAdd(Faction whichFaction)
    {
      if (_target.Unit != null && IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.OwningPlayer()))
        Progress = QuestProgress.Failed;
      else
        Progress = QuestProgress.Complete;
    }

    private void OnTargetChangeOwner(object? sender, LegendChangeOwnerEventArgs legendChangeOwnerEventArgs)
    {
      if (_target.Unit != null && IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.OwningPlayer()))
        Progress = QuestProgress.Failed;
    }
  }
}