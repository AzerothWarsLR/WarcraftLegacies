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

      if (unit.IsTechtreeResearchesAvailableModified)
        foreach (var research in unit.TechtreeResearchesAvailable)
          RemoveWithChildren(research);
    }

    private void RemoveWithChildren(Upgrade upgrade)
    {
      if (!Upgrades.Contains(upgrade))
        return;

      Upgrades.Remove(upgrade);
    }
  }
}