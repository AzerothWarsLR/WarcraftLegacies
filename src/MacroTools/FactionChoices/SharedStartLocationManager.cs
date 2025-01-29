using System.Collections.Generic;

namespace WarcraftLegacies.Source.GameLogic
{
  public class SharedStartLocationManager
  {
    private readonly Dictionary<Faction, int> _factionWorkerUnitTypes = new Dictionary<Faction, int>();

    public void RegisterFactionWorkerUnitType(Faction faction, int workerUnitTypeId)
    {
      if (!_factionWorkerUnitTypes.ContainsKey(faction))
      {
        _factionWorkerUnitTypes.Add(faction, workerUnitTypeId);
      }
    }

    public int GetWorkerUnitTypeId(Faction faction)
    {
      return _factionWorkerUnitTypes.TryGetValue(faction, out var workerUnitTypeId) ? workerUnitTypeId : -1;
    }

    public void ReplacePreplacedUnits(IEnumerable<Unit> preplacedUnits)
    {
      foreach (var unit in preplacedUnits)
      {
        if (unit.IsWorker)
        {
          var faction = GetFactionForUnit(unit);
          var workerUnitTypeId = GetWorkerUnitTypeId(faction);
          if (workerUnitTypeId != -1)
          {
            ReplaceUnit(unit, workerUnitTypeId);
          }
        }
      }
    }

    private Faction GetFactionForUnit(Unit unit)
    {
      return unit.Faction;
    }

    private void ReplaceUnit(Unit unit, int newUnitTypeId)
    {
      unit.ReplaceWith(newUnitTypeId);
    }
  }

  public class Faction
  {
    public string Name { get; set; }

  }

  public class Unit
  {
    public bool IsWorker { get; set; }
    public Faction Faction { get; set; }
    public int UnitType { get; set; }

    public void ReplaceWith(int newUnitTypeId)
    {
      UnitType = newUnitTypeId;
    }
  }
}