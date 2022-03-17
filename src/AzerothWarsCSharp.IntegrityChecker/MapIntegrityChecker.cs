using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object;
using War3Net.Build.Object;

namespace AzerothWarsCSharp.IntegrityChecker
{
  /// <summary>
  /// A tool to identify unused models in a Warcraft 3 map.
  /// </summary>
  public static class MapIntegrityChecker
  {
    private static bool UnitDataContainsModel(IEnumerable<Unit> units, ModelData model)
    {
      foreach (var unit in units)
      {
        if (string.Equals(unit.ArtModelFile, model.RelativePathMdl, StringComparison.OrdinalIgnoreCase)) return true;

        if (model.IsPortrait && string.Equals(unit.ArtModelFile, model.RelativePathWithoutPortraitSuffixMdl,
          StringComparison.OrdinalIgnoreCase))
          return true;

        if (string.Equals(unit.CombatAttack1ProjectileArt, model.RelativePathMdl,
          StringComparison.OrdinalIgnoreCase)) return true;

        if (string.Equals(unit.CombatAttack2ProjectileArt, model.RelativePathMdl,
          StringComparison.OrdinalIgnoreCase)) return true;
      }

      return false;
    }

    private static bool DestructableDataContainsModel(IEnumerable<Destructable> destructables, ModelData model)
    {
      foreach (var destructible in destructables)
        if (string.Equals(destructible.ArtModelFile, model.RelativePathMdl, StringComparison.OrdinalIgnoreCase))
          return true;
      return false;
    }

    private static bool DoodadDataContainsModel(IEnumerable<Doodad> doodads, ModelData model)
    {
      foreach (var doodad in doodads)
        if (string.Equals(doodad.ArtModelFile, model.RelativePathMdl, StringComparison.OrdinalIgnoreCase))
          return true;
      return false;
    }

    private static bool AbilityDataContainsModel(IEnumerable<Ability> abilities, ModelData model)
    {
      foreach (var ability in abilities)
        if (ability.ArtTarget.ToList().Contains(model.RelativePathMdx))
          return true;
      return false;
    }

    /// <summary>
    ///   Checks whether or not an <see cref="ObjectDatabase" /> contains a model.
    ///   A database contains a model if the model string is in use by a Unit, Item, Ability, Doodad, Destructable, Buff,
    ///   or is present in code.
    /// </summary>
    public static bool ObjectDatabaseContainsModel(ObjectDatabase objectDatabase, ModelData model)
    {
      return UnitDataContainsModel(objectDatabase.GetUnits(), model)
             || DestructableDataContainsModel(objectDatabase.GetDestructables(), model)
             || DoodadDataContainsModel(objectDatabase.GetDoodads(), model)
             || AbilityDataContainsModel(objectDatabase.GetAbilities(), model);
    }

    /// <summary>
    ///   Returns a list of all unused model strings in a map.
    /// </summary>
    /// <param name="objectData">The object data in the map.</param>
    /// <param name="modelFilePaths">A list of models that are present in the map.</param>
    /// <param name="rootMapFolderPath">The location of the map folder.</param>
    public static IEnumerable<ModelData> FindUnusedModels(ObjectData objectData, IEnumerable<string> modelFilePaths,
      string rootMapFolderPath)
    {
      var unusedModels = modelFilePaths.Select(modelFilePath => new ModelData(modelFilePath, rootMapFolderPath))
        .ToList();

      //Get seperated object data from provided ObjectData object
      var fallbackDatabase = new ObjectDatabase();
      var tempObjectDatabase = new ObjectDatabase(fallbackDatabase);
      tempObjectDatabase.AddObjects(objectData);

      //Find all models for which a unit, destructable, or doodad has that model, then remove those models from the set.
      foreach (var model in
        unusedModels.ToList().Where(model => ObjectDatabaseContainsModel(tempObjectDatabase, model)))
        unusedModels.Remove(model);
      return unusedModels;
    }
  }
}