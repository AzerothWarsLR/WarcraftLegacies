using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  /// Completed when an eligible player moves a unit into the specified <see cref="Rectangle"/>.
  /// </summary>
  public sealed class ObjectiveAnyUnitInRect : Objective
  {
    private readonly bool _heroOnly;
    private readonly rect _targetRect;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveAnyUnitInRect"/> class.
    /// </summary>
    /// <param name="targetRect">Where the player has to move a unit.</param>
    /// <param name="rectName">A user-friendly name for the area.</param>
    /// <param name="heroOnly">If true, can only be completed with a hero.</param>
    public ObjectiveAnyUnitInRect(Rectangle targetRect, string rectName, bool heroOnly)
    {
      _targetRect = targetRect.Rect;
      Description = heroOnly ? $"You have a hero at {rectName}" : $"You have a unit at {rectName}";
      _heroOnly = heroOnly;
      DisplaysPosition = true;
      PingPath = "MinimapQuestTurnIn";

      CreateTrigger()
        .RegisterEnterRegion(targetRect)
        .AddAction(() =>
        {
          var triggerUnit = GetTriggerUnit();
          if (IsValidUnitInRect())
          {
            TriggerUnit = triggerUnit;
            Progress = QuestProgress.Complete;
          }
          else
          {
            Progress = QuestProgress.Incomplete;
          }
        });
      CreateTrigger()
        .RegisterLeaveRegion(targetRect)
        .AddAction(() =>
        {
          if (!IsValidUnitInRect()) 
            Progress = QuestProgress.Incomplete;
        });
    }

    /// <inheritdoc />
    public override Point Position => new(GetRectCenterX(_targetRect), GetRectCenterY(_targetRect));

    /// <summary>
    ///   The <see cref="unit" /> that completed this objective.
    /// </summary>
    public unit? TriggerUnit { get; private set; }

    private bool IsValidUnitInRect()
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(_targetRect).EmptyToList())
        if (EligibleFactions.Contains(unit.OwningPlayer()) && unit.IsAlive() &&
            (IsUnitType(unit, UNIT_TYPE_HERO) || !_heroOnly))
          return true;
      return false;
    }

    internal override void OnAdd(Faction whichFaction)
    {
      Progress = IsValidUnitInRect() ? QuestProgress.Complete : QuestProgress.Incomplete;
    }
  }
}