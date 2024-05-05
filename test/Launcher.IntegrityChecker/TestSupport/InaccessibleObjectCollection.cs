using War3Api.Object;

namespace Launcher.IntegrityChecker.TestSupport
{
  /// <summary>
  /// Contains <see cref="BaseObject"/>s that are inaccessible to the game.
  /// </summary>
  public sealed class InaccessibleObjectCollection
  {
    public List<Unit> Units { get; }
    
    public List<Upgrade> Upgrades { get; }

    public InaccessibleObjectCollection(List<Unit> units, List<Upgrade> upgrades)
    {
      Units = units;
      Upgrades = upgrades;
    }

    public void RemoveWithChildren(BaseObject baseObject)
    {
      switch (baseObject)
      {
        case Unit unit:
          RemoveWithChildren(unit);
          break;
        case Upgrade upgrade:
          RemoveWithChildren(upgrade);
          break;
      }
    }
    
    public void RemoveWithChildren(Unit unit)
    {
      if (!Units.Contains(unit))
        return;
      
      Units.Remove(unit);

      if (unit.IsTechtreeUnitsTrainedModified)
        foreach (var trainedUnit in unit.TechtreeUnitsTrained)
          RemoveWithChildren(trainedUnit);

      if (unit.IsTechtreeStructuresBuiltModified)
        foreach (var builtStructure in unit.TechtreeStructuresBuilt)
          RemoveWithChildren(builtStructure);
      
      if (unit.IsTechtreeUpgradesToModified)
        foreach (var upgradesTo in unit.TechtreeUpgradesTo)
          RemoveWithChildren(upgradesTo);

      if (unit.IsTechtreeResearchesAvailableModified)
        foreach (var research in unit.TechtreeResearchesAvailable)
          RemoveWithChildren(research);
    }

    /// <summary>
    /// Returns all <see cref="BaseObject"/>s in the collection.
    /// </summary>
    public List<BaseObject> GetAllObjects()
    {
      var objects = new List<BaseObject>();
      objects.AddRange(Units);
      objects.AddRange(Upgrades);
      return objects;
    }
    
    private void RemoveWithChildren(Upgrade upgrade)
    {
      if (!Upgrades.Contains(upgrade))
        return;

      Upgrades.Remove(upgrade);
    }
  }
}