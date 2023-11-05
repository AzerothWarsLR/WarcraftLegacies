using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  /// <summary>
  /// /// Completed when an enemy of an eligible Faction moves a unit into the specified <see cref="Rectangle"/>.
  /// </summary>
  public sealed class ObjectiveAnyEnemyUnitInRects : Objective, IHasCompletingUnit
  {
    private readonly IEnumerable<Rectangle> _targetRects;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveAnyEnemyUnitInRects"/> class.
    /// </summary>
    /// <param name="targetRects">Where the player has to move a unit.</param>
    /// <param name="rectName">A user-friendly name for the area.</param>
    public ObjectiveAnyEnemyUnitInRects(IEnumerable<Rectangle> targetRects, string rectName)
    {
      var rectangles = targetRects as Rectangle[] ?? targetRects.ToArray();
      _targetRects = rectangles;
      Description = $"Enemy unit has entered {rectName}";
      DisplaysPosition = false;
      PingPath = "MinimapQuestTurnIn";
      CreateTrigger()
        .RegisterEnterRegions(_targetRects)
        .AddAction(() =>
        {
          var triggerUnit = GetTriggerUnit();
          if (!IsUnitValid(triggerUnit)) 
            return;
          CompletingUnit = triggerUnit;
          Progress = QuestProgress.Complete;
        });
      CreateTrigger()
        .RegisterLeaveRegions(_targetRects)
        .AddAction(() =>
        {
          if (!IsValidUnitInRects()) 
            Progress = QuestProgress.Incomplete;
        });
    }

    /// <inheritdoc />
    public unit? CompletingUnit { get; private set; }

    /// <inheritdoc />
    public string CompletingUnitName => CompletingUnit != null ? CompletingUnit.GetProperName() : "an unknown hero";

    private bool IsUnitValid(unit whichUnit)
    {
      return !IsUnitAlly(whichUnit,EligibleFactions[0].Player) && whichUnit.IsAlive() &&
             whichUnit.OwningPlayer() != Player(PLAYER_NEUTRAL_AGGRESSIVE) &&
             whichUnit.OwningPlayer() != Player(PLAYER_NEUTRAL_PASSIVE);
    }
      

    private bool IsValidUnitInRects()
    {
      return _targetRects.Select(targetRect => CreateGroup().EnumUnitsInRect(targetRect).EmptyToList().Any(IsUnitValid)).Any(any => any);
    } 
    
    /// <inheritdoc />
    internal override void OnAdd(Faction whichFaction)
    {
      Progress = IsValidUnitInRects() ? QuestProgress.Complete : QuestProgress.Incomplete;
    }
  }
}