using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Localization;
using WarcraftLegacies.Shared.FactionObjectLimits;

namespace WarcraftLegacies.Source.Factions.Scourge;

/// <summary>Raises the Scourge's unit limits while it has no allies.</summary>
public sealed class ScourgeSoloLimits
{
  private readonly Faction _scourge;
  private readonly List<int> _boostedObjects = new();

  public ScourgeSoloLimits(Faction scourge) => _scourge = scourge;

  public void Start()
  {
    TeamChanges.OnAnyTeamChanged(Refresh);
    GameTimeManager.RegisterOnTurnRepeating(GameTimeManager.Turn + 1, Refresh);
    Refresh();
  }

  private bool IsAlone()
  {
    var team = _scourge.Player?.GetPlayerData().Team;
    return team != null && team.Bloc == null && team.UndefeatedPlayerCount == 1;
  }

  private void Refresh()
  {
    if (!IsAlone())
    {
      RemoveBonus();
      return;
    }

    var hadBonus = _boostedObjects.Count > 0;
    foreach (var objectId in ScourgeObjectInfo.StandingAloneUnits)
    {
      if (!_boostedObjects.Contains(objectId) &&
          _scourge.GetObjectLimit(objectId) > 0)
      {
        _scourge.ModObjectLimit(objectId, ScourgeObjectInfo.StandingAloneBonus);
        _boostedObjects.Add(objectId);
      }
    }

    if (!hadBonus && _boostedObjects.Count > 0)
    {
      _scourge.Player?.DisplayTextTo(Loc.Format("With no allies to share his attention, the Lich King bends his full will upon the Scourge. It can field {bonus} more of each of its limited units until another faction joins it.",
        ("{bonus}", ScourgeObjectInfo.StandingAloneBonus.ToString())));
    }
  }

  private void RemoveBonus()
  {
    if (_boostedObjects.Count == 0)
    {
      return;
    }

    foreach (var objectId in _boostedObjects)
    {
      _scourge.ModObjectLimit(objectId, -ScourgeObjectInfo.StandingAloneBonus);
    }

    _boostedObjects.Clear();
    _scourge.Player?.DisplayTextTo(Loc.Get("The Scourge no longer stands alone, and the Lich King's attention is divided once more. Its extra unit limits are lost."));
  }
}
