using System.Linq;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
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
    /// <param name="killNearbyCreeps">If true, all creeps near the point need to be killed as well.</param>
    public ObjectiveControlPoint(int controlPointUnitType, bool killNearbyCreeps = true)
    {
      _target = ControlPointManager.Instance.GetFromUnitType(controlPointUnitType);
      TargetWidget = _target.Unit;
      DisplaysPosition = true;
      Position = _target.Unit.GetPosition();

      if (killNearbyCreeps)
      {
        RegisterKillTriggers();
        CurrentKillCount = 0;
      }
      else
        Description = $"You control {_target.Name}";
    }

    internal override void OnAdd(Faction whichFaction)
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
    
    private void RegisterKillTriggers()
    {
      var unitsNearby = CreateGroup()
        .EnumUnitsInRange(_target.Unit.GetPosition(), 700)
        .EmptyToList()
        .Where(x => x.OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE) && !x.IsType(UNIT_TYPE_ANCIENT) &&
                    !x.IsType(UNIT_TYPE_SAPPER));
      
      foreach (var unit in unitsNearby)
      {
        _maxKillCount++;
        CreateTrigger()
          .RegisterUnitEvent(unit, EVENT_UNIT_DEATH)
          .AddAction(() =>
          {
            CurrentKillCount++;
            DestroyTrigger(GetTriggeringTrigger());
          });
      }
    }
  }
}