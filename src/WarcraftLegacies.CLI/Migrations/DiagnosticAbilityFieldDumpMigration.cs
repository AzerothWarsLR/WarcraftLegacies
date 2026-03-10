using System;
using War3Api.Object;
using War3Net.Build;
using Warcraft.Cartographer.Migrations;

namespace WarcraftLegacies.CLI.Migrations;

public sealed class DiagnosticAbilityFieldDumpMigration : IMapMigration
{
  public void Migrate(Map map, ObjectDatabase objectDatabase)
  {

    const int testUnitId = 1848652358;

    var unit = objectDatabase.TryGetUnit(testUnitId);
    if (unit == null)
    {
      Console.WriteLine("Could not load 1848652358.");
      return;
    }

    Console.WriteLine("=== Ability Field Diagnostics ===");

    try
    {
      Console.WriteLine("AbilitiesNormal: " +
                        (unit.AbilitiesNormal == null ? "null" : unit.AbilitiesNormal.GetType().FullName));
    }
    catch (Exception e)
    {
      Console.WriteLine("AbilitiesNormal: EXCEPTION -> " + e.Message);
    }

    try
    {
      Console.WriteLine("AbilitiesNormalRaw: " +
                        (unit.AbilitiesNormalRaw == null ? "null" : unit.AbilitiesNormalRaw.GetType().FullName));
    }
    catch (Exception e)
    {
      Console.WriteLine("AbilitiesNormalRaw: EXCEPTION -> " + e.Message);
    }

    Console.WriteLine("=== End Diagnostics ===");
  }
}
