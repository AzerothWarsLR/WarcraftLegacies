using System.Collections.Generic;
using System.Linq;
using War3Api.Object;
using War3Net.Build.Object;

namespace AzerothWarsCSharp.IntegrityChecker
{
  public static class MapIntegrityChecker
  {
    public static IEnumerable<ModelData> FindUnusedModels(ObjectData objectData, IEnumerable<string> modelFilePaths, string rootMapFolderPath)
    {
      var unusedModels = new List<ModelData>();
      foreach (var modelFilePath in modelFilePaths)
      {
        unusedModels.Add(new ModelData(modelFilePath, rootMapFolderPath));
      }
      
      //Get seperated object data from provided ObjectData object
      var tempObjectDatabase = new ObjectDatabase();
      tempObjectDatabase.AddObjects(objectData);
      var allUnits = tempObjectDatabase.GetUnits().ToList();
      var allDestructables = tempObjectDatabase.GetDestructables().ToList();
      var allDoodads = tempObjectDatabase.GetDoodads().ToList();
      var allAbilities = tempObjectDatabase.GetAbilities().ToList();
      
      //Find all models for which a unit, destructable, or doodad has that model, then remove those models from the set.
      foreach (var model in unusedModels.ToList())
      {
        foreach (var unit in allUnits)
        {
          if (unit.IsArtModelFileModified && unit.ArtModelFile == model.RelativePathMdl)
          {
            unusedModels.Remove(model);
            break;
          }
        }

        foreach (var destructible in allDestructables)
        {
          if (destructible.IsArtModelFileModified && destructible.ArtModelFile == model.RelativePathMdl)
          {
            unusedModels.Remove(model);
            break;
          }
        }

        foreach (var doodad in allDoodads)
        {
          if (doodad.IsArtModelFileModified && doodad.ArtModelFile == model.RelativePathMdl)
          {
            unusedModels.Remove(model);
            break;
          }
        }
        
        foreach (var ability in allAbilities)
        {
          if (ability.IsArtTargetModified && ability.ArtTarget.ToList().Contains(model.RelativePathMdx))
          {
            unusedModels.Remove(model);
            break;
          }
        }
      }
      
      return unusedModels;
    }
  }
}