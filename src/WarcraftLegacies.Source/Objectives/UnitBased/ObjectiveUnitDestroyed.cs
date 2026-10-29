using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>Completed when a specific unit dies. Unlike <see cref="ObjectiveUnitIsDead"/>, changing owner doesn't count.</summary>
public sealed class ObjectiveUnitDestroyed : Objective
{
  public ObjectiveUnitDestroyed(unit target)
  {
    Target = target;
    TargetWidget = target;
    SetDescription("Destroy {target}", ("{target}", Loc.Get(target.GetProperName())));
    DisplaysPosition = true;
    Position = new(target.X, target.Y);
    PlayerUnitEvents.Register(UnitEvent.Dies, () => Progress = QuestProgress.Complete, target);
  }

  public unit Target { get; }

  /// <inheritdoc />
  public override void OnAdd(Faction faction)
  {
    if (!Target.Alive)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
