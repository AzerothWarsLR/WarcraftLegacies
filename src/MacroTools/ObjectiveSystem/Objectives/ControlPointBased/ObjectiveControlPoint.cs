using System.Linq;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.Utils;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.ControlPointBased
{
  public sealed class ObjectiveControlPoint : Objective
  {
    private readonly ControlPoint _target;
    private int _maxKillCount;
    private int _currentKillCount;
    
    private int CurrentKillCount
    {
      get => _currentKillCount;
      set
      {
        _currentKillCount = value;
        Description = $"You control {_target.Name} and all nearby creeps are dead ({_currentKillCount}/{_maxKillCount})";
        RefreshProgress();
      }
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ObjectiveControlPoint"/>.
    /// </summary>
    /// <param name="controlPointUnitType">The unit type of the <see cref="ControlPoint"/> that needs to be captured.</param>
    /// <param name="range">The area in which creeps need to be killed to complete the objective.</param>
    public ObjectiveControlPoint(int controlPointUnitType, float range = 700)
    {
      _target = ControlPointManager.Instance.GetFromUnitType(controlPointUnitType);
      TargetWidget = _target.Unit;
      DisplaysPosition = true;
      Position = _target.Unit.GetPosition();

      if (range > 0)
      {
        RegisterKillTriggers(range);
        CurrentKillCount = 0;
      }
      else
        Description = $"You control {_target.Name}";
    }

    public override void OnAdd(Faction whichFaction)
    {
      Progress = IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.OwningPlayer())
        ? QuestProgress.Complete
        : QuestProgress.Incomplete;
      
      _target.OwnerAllianceChanged += (_, _) => RefreshProgress();
    }

    private void RefreshProgress()
    {
      if (_currentKillCount == _maxKillCount && IsPlayerOnSameTeamAsAnyEligibleFaction(_target.Unit.OwningPlayer())) 
        Progress = QuestProgress.Complete;
    }

    private void RegisterKillTriggers(float range)
    {
      var unitsNearby = GlobalGroup
        .EnumUnitsInRange(_target.Unit.GetPosition(), range)
          .Where(x => x.OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE) && !IsUnitType(x, UNIT_TYPE_ANCIENT) &&
           !IsUnitType(x, UNIT_TYPE_SAPPER) && !IsUnitType(x, UNIT_TYPE_STRUCTURE)); 

      foreach (var unit in unitsNearby)
      {
        _maxKillCount++;
        var killTrigger = CreateTrigger();
        TriggerRegisterUnitEvent(killTrigger, unit, EVENT_UNIT_DEATH);
        TriggerAddAction(killTrigger, () =>
        {
          CurrentKillCount++;
          DestroyTrigger(GetTriggeringTrigger());
        });
      }
    }
  }
}