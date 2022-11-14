using MacroTools.Extensions;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  /// Defines an <see cref="Objective"/> that completes when any hero of a certain level or higher enters a specific region.
  /// </summary>
  public sealed class ObjectiveHeroWithLevelReachRect : Objective
  {
    private readonly TriggerWrapper _entersRect = new();

    private readonly rect _targetRect;
    private readonly int _targetLevel;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveHeroWithLevelReachRect"/> class.
    /// </summary>
    /// <param name="targetLevel">Minimum required level to complete the objective</param>
    /// <param name="targetRect">Region that the unit has to enter in order to complete the objective</param>
    /// <param name="rectName">Display name of the region the unit has to enter. Used for flavor only.</param>
    public ObjectiveHeroWithLevelReachRect(int targetLevel, Rectangle targetRect, string rectName)
    {
      _targetRect = targetRect.Rect;
      _targetLevel = targetLevel;
      region target = RectToRegion(_targetRect);
      Description = $"Any level {targetLevel}+ hero reaches {rectName}";
      TriggerRegisterEnterRegion(_entersRect.Trigger, target, null);
      TriggerAddAction(_entersRect.Trigger, OnRegionEnter);
      PingPath = "MinimapQuestTurnIn";
      DisplaysPosition = true;
    }

    /// <summary>
    /// Name of the unit that entered the <see cref="_targetRect"/>
    /// </summary>
    public string EnteredRegionUnitName { get; private set; } = "an unknown hero.";
    
    /// <inheritdoc/>
    public override Point Position => new(GetRectCenterX(_targetRect), GetRectCenterY(_targetRect));

    private static region RectToRegion(rect whichRect)
    {
      region rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    private void OnRegionEnter()
    {
      var triggerUnit = GetTriggerUnit();
      if (UnitAlive(triggerUnit) && GetHeroLevel(triggerUnit) >= _targetLevel)
      {
        Progress = QuestProgress.Complete;
        EnteredRegionUnitName = triggerUnit.GetProperName();
      }
    }
  }
}