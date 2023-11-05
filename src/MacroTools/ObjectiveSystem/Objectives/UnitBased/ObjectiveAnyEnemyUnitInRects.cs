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
  /// Completed when an eligible player moves a unit into the specified <see cref="Rectangle"/>.
  /// </summary>
  public sealed class ObjectiveAnyEnemyUnitInRects : Objective, IHasCompletingUnit
  {
    private readonly bool _heroOnly;
    private readonly IEnumerable<Rectangle> _targetRects;
    private readonly Faction? _faction;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveAnyEnemyUnitInRects"/> class.
    /// </summary>
    /// <param name="targetRects">Where the player has to move a unit.</param>
    /// <param name="faction"></param>
    /// <param name="rectName">A user-friendly name for the area.</param>
    /// <param name="heroOnly">If true, can only be completed with a hero.</param>
    public ObjectiveAnyEnemyUnitInRects(IEnumerable<Rectangle> targetRects, Faction? faction, string rectName, bool heroOnly)
    {
      var rectangles = targetRects as Rectangle[] ?? targetRects.ToArray();
      _targetRects = rectangles;
      Description = heroOnly ? $"Enemy hero has entered {rectName}" : $"Enemy unit has entered {rectName}";
      _heroOnly = heroOnly;
      _faction = faction;
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
      return !IsUnitAlly(whichUnit,_faction?.Player) && whichUnit.IsAlive() &&
             (IsUnitType(whichUnit, UNIT_TYPE_HERO) || !_heroOnly) &&
             whichUnit.OwningPlayer() != Player(PLAYER_NEUTRAL_AGGRESSIVE) &&
             whichUnit.OwningPlayer() != Player(PLAYER_NEUTRAL_PASSIVE);
    }
      

    private bool IsValidUnitInRects()
    {
      return _targetRects.Select(targetRect => CreateGroup().EnumUnitsInRect(targetRect).EmptyToList().Any(IsUnitValid)).Any(any => any);
    } 

    internal override void OnAdd(Faction whichFaction)
    {
      Progress = IsValidUnitInRects() ? QuestProgress.Complete : QuestProgress.Incomplete;
    }
  }
}