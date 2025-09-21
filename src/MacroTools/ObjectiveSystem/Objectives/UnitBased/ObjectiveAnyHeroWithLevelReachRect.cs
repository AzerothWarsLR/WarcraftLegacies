using MacroTools.Extensions;
using MacroTools.QuestSystem;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased;

/// <summary>
/// Defines an <see cref="Objective"/> that completes when ANY hero of a certain level or higher enters a specific region.
/// </summary>
public sealed class ObjectiveAnyHeroWithLevelReachRect : Objective, IHasCompletingUnit
{
  private readonly TriggerWrapper _entersRect = new();

  private readonly rect _targetRect;
  private readonly int _targetLevel;

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveHeroWithLevelInRect"/> class.
  /// </summary>
  /// <param name="targetLevel">Minimum required level to complete the objective</param>
  /// <param name="targetRect">Region that the unit has to enter in order to complete the objective</param>
  /// <param name="rectName">Display name of the region the unit has to enter. Used for flavor only.</param>
  public ObjectiveAnyHeroWithLevelReachRect(int targetLevel, Rectangle targetRect, string rectName)
  {
    _targetRect = targetRect.Rect;
    _targetLevel = targetLevel;
    var target = RectToRegion(_targetRect);
    Description = $"Any level {targetLevel}+ hero reaches {rectName}";
    _entersRect.Trigger.RegisterEnterRegion(target, null);
    _entersRect.Trigger.AddAction(OnRegionEnter);
    PingPath = "MinimapQuestTurnIn";
    DisplaysPosition = true;
    Position = new(_targetRect.CenterX, _targetRect.CenterY);
  }

  /// <inheritdoc />
  public unit? CompletingUnit { get; private set; }

  /// <inheritdoc />
  public string CompletingUnitName => CompletingUnit != null ? CompletingUnit.GetProperName() : "an unknown hero";

  private static region RectToRegion(rect whichRect)
  {
    var rectRegion = region.Create();
    rectRegion.AddRect(whichRect);
    return rectRegion;
  }

  private void OnRegionEnter()
  {
    var triggerUnit = @event.Unit;
    if (!triggerUnit.Alive || triggerUnit.HeroLevel < _targetLevel)
    {
      return;
    }

    CompletingUnit = triggerUnit;
    Progress = QuestProgress.Complete;
  }
}
