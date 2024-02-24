using War3Api.Object;
using War3Api.Object.Abilities;

namespace Launcher.IntegrityChecker.TestSupport
{
  /// <summary>
  /// Contains <see cref="BaseObject"/>s that are inaccessible to the game.
  /// </summary>
  public sealed class InaccessibleObjectCollection
  {
    public List<Unit> Units { get; }
    
    public List<Ability> Abilities { get; }

    public InaccessibleObjectCollection(List<Unit> units, List<Ability> abilities)
    {
      Units = units;
      Abilities = abilities;
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

      // if (unit.IsAbilitiesNormalModified)
      //   foreach (var ability in unit.AbilitiesNormal)
      //     RemoveWithChildren(ability);
    }

    private void RemoveWithChildren(Ability ability)
    {
      if (!Abilities.Contains(ability))
        return;

      Abilities.Remove(ability);
      
      switch (ability)
      {
        case SummonSeaElemental summonSeaElemental:
        {
          for (var i = 0; i < summonSeaElemental.StatsLevels; i++)
            if (summonSeaElemental.IsDataSummonedUnitTypeModified[i])
              RemoveWithChildren(summonSeaElemental.DataSummonedUnitType[i]);

          return;
        }
      }
    }
  }
}