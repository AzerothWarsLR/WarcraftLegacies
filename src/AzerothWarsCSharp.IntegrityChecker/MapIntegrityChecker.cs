using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object;
using War3Net.Build.Object;

namespace AzerothWarsCSharp.IntegrityChecker
{
  public static class MapIntegrityChecker
  {
    private static bool UnitDataContainsModel(IEnumerable<Unit> units, ModelData model)
    {
      foreach (var unit in units)
      {
        if (!unit.IsArtModelFileModified) continue;
        
        if (string.Equals(unit.ArtModelFile, model.RelativePathMdl, StringComparison.OrdinalIgnoreCase))
        {
          return true;
        }

        if (model.IsPortrait && string.Equals(unit.ArtModelFile, model.RelativePathWithoutPortraitSuffixMdl,
          StringComparison.OrdinalIgnoreCase))
        {
          return true;
        }

        if (unit.IsCombatAttack1ProjectileArtModified && string.Equals(unit.CombatAttack1ProjectileArt, model.RelativePathMdl, StringComparison.OrdinalIgnoreCase))
        {
          return true;
        }
            
        if (unit.IsCombatAttack2ProjectileArtModified && string.Equals(unit.CombatAttack2ProjectileArt, model.RelativePathMdl, StringComparison.OrdinalIgnoreCase))
        {
          return true;
        }
      }
      return false;
    }

    private static bool DestructableDataContainsModel(IEnumerable<Destructable> destructables, ModelData model)
    {
      foreach (var destructible in destructables)
      {
        if (destructible.IsArtModelFileModified && string.Equals(destructible.ArtModelFile, model.RelativePathMdl, StringComparison.OrdinalIgnoreCase))
        {
          return true;
        }
      }
      return false;
    }

    private static bool DoodadDataContainsModel(IEnumerable<Doodad> doodads, ModelData model)
    {
      foreach (var doodad in doodads)
      {
        if (doodad.IsArtModelFileModified && string.Equals(doodad.ArtModelFile, model.RelativePathMdl, StringComparison.OrdinalIgnoreCase))
        {
          return true;
        }
      }
      return false;
    }

    private static bool AbilityDataContainsModel(IEnumerable<Ability> abilities, ModelData model)
    {
      foreach (var ability in abilities)
      {
        if (ability.IsArtTargetModified && ability.ArtTarget.ToList().Contains(model.RelativePathMdx))
        {
          return true;
        }
      }
      return false;
    }
    
    public static bool ObjectDatabaseContainsModel(ObjectDatabase objectDatabase, ModelData model)
    {
      return UnitDataContainsModel(objectDatabase.GetUnits(), model)
             || DestructableDataContainsModel(objectDatabase.GetDestructables(), model)
             || DoodadDataContainsModel(objectDatabase.GetDoodads(), model)
             || AbilityDataContainsModel(objectDatabase.GetAbilities(), model);
    }

    public static IEnumerable<ModelData> FindUnusedModels(ObjectData objectData, IEnumerable<string> modelFilePaths, string rootMapFolderPath)
    {
      var unusedModels = modelFilePaths.Select(modelFilePath => new ModelData(modelFilePath, rootMapFolderPath)).ToList();

      //Get seperated object data from provided ObjectData object
      var tempObjectDatabase = new ObjectDatabase();
      tempObjectDatabase.AddObjects(objectData);

      //Find all models for which a unit, destructable, or doodad has that model, then remove those models from the set.
      foreach (var model in unusedModels.ToList().Where(model => ObjectDatabaseContainsModel(tempObjectDatabase, model)))
      {
        unusedModels.Remove(model);
      }
      return unusedModels;
    }
  }
}