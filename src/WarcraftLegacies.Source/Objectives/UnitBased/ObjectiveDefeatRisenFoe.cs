using System;
using MacroTools.Localization;
using MacroTools.Quests;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>Once another objective is done, a hostile foe rises nearby; completed when it is killed.</summary>
public sealed class ObjectiveDefeatRisenFoe : Objective
{
  private readonly int _unitTypeId;
  private readonly Point _spawnPoint;
  private readonly float _facing;
  private unit? _foe;

  /// <param name="trigger">The foe rises when this objective is completed.</param>
  /// <param name="unitTypeId">The foe's unit type.</param>
  /// <param name="foeName">The foe's name, as shown in the description.</param>
  /// <param name="spawnPoint">Where the foe rises.</param>
  /// <param name="facing">Which way the foe faces when it rises.</param>
  public ObjectiveDefeatRisenFoe(Objective trigger, int unitTypeId, string foeName, Point spawnPoint, float facing)
  {
    _unitTypeId = unitTypeId;
    _spawnPoint = spawnPoint;
    _facing = facing;
    SetDescription("Kill {foe}", ("{foe}", Loc.Get(foeName)));
    DisplaysPosition = true;
    Position = spawnPoint;
    trigger.ProgressChanged += OnTriggerProgressChanged;
  }

  /// <summary>Fired when the foe rises.</summary>
  public event Action<unit>? FoeRisen;

  private void OnTriggerProgressChanged(Objective trigger)
  {
    if (_foe != null || trigger.Progress != QuestProgress.Complete || Progress == QuestProgress.Complete)
    {
      return;
    }

    _foe = unit.Create(player.NeutralAggressive, _unitTypeId, _spawnPoint.X, _spawnPoint.Y, _facing);
    PlayerUnitEventsHelper.RegisterDiesOrChangesOwnerOnce(OnFoeDies, _foe);
    FoeRisen?.Invoke(_foe);
  }

  private void OnFoeDies() => Progress = QuestProgress.Complete;
}
