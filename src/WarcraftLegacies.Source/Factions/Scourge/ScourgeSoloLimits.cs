using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Factions.Scourge;

/// <summary>
/// While the Scourge stands alone after breaking from the Legion, it can field more of its limited units. The bonus is
/// removed as soon as anyone joins its team.
/// </summary>
public sealed class ScourgeSoloLimits
{
  private const int Bonus = 2;

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
    foreach (var objectId in _scourge.GetLimitedObjects())
    {
      if (!_boostedObjects.Contains(objectId) && CanBoost(objectId))
      {
        _scourge.ModObjectLimit(objectId, Bonus);
        _boostedObjects.Add(objectId);
      }
    }

    if (!hadBonus && _boostedObjects.Count > 0)
    {
      _scourge.Player?.DisplayTextTo(Loc.Format("Standing alone, the Scourge can field {bonus} more of each of its limited units until another faction joins it.",
        ("{bonus}", Bonus.ToString())));
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
      _scourge.ModObjectLimit(objectId, -Bonus);
    }

    _boostedObjects.Clear();
    _scourge.Player?.DisplayTextTo(Loc.Get("The Scourge no longer stands alone and loses its extra unit limits."));
  }

  private bool CanBoost(int objectId)
  {
    var limit = _scourge.GetObjectLimit(objectId);
    return limit > 1 && limit < Faction.Unlimited &&
           !IsUnitIdType(objectId, unittype.Hero) && !IsUnitIdType(objectId, unittype.Structure) &&
           (IsUnitIdType(objectId, unittype.Ground) || IsUnitIdType(objectId, unittype.Flying));
  }
}
