using System;
using System.IO;
using System.Linq;
using War3Api.Object;
using War3Net.Build;

namespace Launcher.MapMigrations
{
  public sealed class PortraitModelFileMapMigration : IMapMigration
  {
    private readonly string logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "migration_log.txt");

    public void Migrate(Map map, ObjectDatabase objectDatabase)
    {
      try
      {
        // Start logging to file
        LogToFile("Starting migration...");

        // Log the number of units before migration
        LogToFile($"Number of units before migration: {objectDatabase.GetUnits().Count()}");

        foreach (var unit in objectDatabase.GetUnits())
        {
          // Minimal processing: Just log the units for now
          LogToFile($"Processing unit: {unit.OldId}");
        }

        // Assign unit data and log completion
        map.UnitObjectData = objectDatabase.GetAllData().UnitData;
        LogToFile("Migration completed.");
      }
      catch (Exception ex)
      {
        // Log the exception details
        LogToFile($"Exception occurred: {ex.Message}");
        LogToFile($"Stack trace: {ex.StackTrace}");
        throw; // Re-throw the exception to propagate it
      }
    }

    private void LogToFile(string message)
    {
      using (StreamWriter writer = new StreamWriter(logFilePath, true))
      {
        writer.WriteLine(message);
      }
    }
  }
}
