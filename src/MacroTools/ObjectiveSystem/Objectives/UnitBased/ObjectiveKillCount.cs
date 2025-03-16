using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.Setup;
using WCSharp.Events;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  /// <summary>
  /// Completes when the holder kills a certain number of units.
  /// </summary>
  public sealed class ObjectiveKillCount : Objective
  {
    private int _currentCount;
    private readonly int _requiredCount;

    private int CurrentCount
    {
      get => _currentCount;
      set
      {
        _currentCount = value;
        Description = $"Kill {_requiredCount} units ({_currentCount}/{_requiredCount})";
        if (_currentCount >= _requiredCount)
          Progress = QuestProgress.Complete;
      }
    }
    
    public ObjectiveKillCount(int requiredCount)
    {
      _requiredCount = requiredCount;
    }

    /// <inheritdoc/>
    public override void OnAdd(Faction faction)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.FactionUnitKills, OnKillUnit, faction.Id);
      CurrentCount = 0;
    }

    private void OnKillUnit() => CurrentCount++;
  }
}