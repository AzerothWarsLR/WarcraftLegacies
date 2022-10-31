using System.Collections.Generic;
using System.Linq;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.Mechanics.TwilightHammer
{
  public sealed class PowerCorruptWorker : Power
  {
    private readonly Continent[] _continents;
    private readonly List<unit> _corruptedWorkers = new();
    private readonly PeriodicTrigger<CorruptWorkerPeriodicAction> _corruptWorkerPeriodicTrigger;
    private readonly int[] _cultistUnitTypeIds;
    private readonly float _period;
    private Continent _activeContinent = null!;

    /// <summary>
    /// Periodically corrupts a random uncorrupted worker in one of the specified continents.
    /// </summary>
    /// <param name="period">How frequently to corrupt workers.</param>
    /// <param name="changeContinentAbilityId">This ability, when cast, changes the target of this <see cref="Power"/>
    /// to any continent that contains the spell's target.</param>
    /// <param name="cultistUnitTypeIds">This power can transform all corrupted workers into a random unit from this provided list.</param>
    /// <param name="continents">The continents in which workers can be corrupted.</param>
    public PowerCorruptWorker(float period, int changeContinentAbilityId, IEnumerable<Continent> continents,
      IEnumerable<int> cultistUnitTypeIds)
    {
      _period = period;
      _cultistUnitTypeIds = cultistUnitTypeIds.ToArray();
      _corruptWorkerPeriodicTrigger = new PeriodicTrigger<CorruptWorkerPeriodicAction>(period);
      _continents = continents.ToArray();
      ActiveContinent = _continents.First();
      Name = "Induction Rites";
      PlayerUnitEvents.Register(PlayerUnitEvent.SpellFinish, ChangeContinent, changeContinentAbilityId);
    }

    private Continent ActiveContinent
    {
      get => _activeContinent;
      set
      {
        foreach (var action in _corruptWorkerPeriodicTrigger.Actions)
        {
          action.Continent = value;
        }

        _activeContinent = value;
        RefreshDescription();
      }
    }

    /// <summary>
    /// Converts all corrupted workers into cultists.
    /// </summary>
    public void ConvertAllWorkers(player owningPlayer)
    {
      foreach (var unit in _corruptedWorkers)
      {
        KillUnit(unit);
        var pos = unit.GetPosition();
        var facing = GetUnitFacing(unit);
        RemoveUnit(unit);
        CreateUnit(owningPlayer, _cultistUnitTypeIds[GetRandomInt(0, _cultistUnitTypeIds.Length - 1)], pos.X, pos.Y,
          facing);
      }

      _corruptedWorkers.Clear();
    }

    private void RefreshDescription()
    {
      Description =
        $"Every {_period} seconds, you corrupt a random worker in {_activeContinent.Name}. You gain 1 Income for each corrupted worker and have vision over them.";
    }

    private void ChangeContinent()
    {
      var targetUnit = GetSpellTargetUnit();
      Point targetPoint =
        targetUnit != null ? targetUnit.GetPosition() : new Point(GetSpellTargetX(), GetSpellTargetY());

      foreach (var continent in _continents)
      {
        if (continent.Area.Contains(targetPoint))
        {
          ActiveContinent = continent;
          return;
        }
      }
    }

    public override void OnAdd(player whichPlayer)
    {
      _corruptWorkerPeriodicTrigger.Add(
        new CorruptWorkerPeriodicAction(whichPlayer, ActiveContinent, _corruptedWorkers));
    }

    public override void OnRemove(player whichPlayer)
    {
      foreach (var periodicAction in _corruptWorkerPeriodicTrigger.Actions)
        periodicAction.Active = false;
    }
  }
}