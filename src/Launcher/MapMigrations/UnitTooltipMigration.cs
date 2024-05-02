using System;
using System.Linq;
using System.Text;
using War3Api.Object;
using War3Net.Build;

namespace Launcher.MapMigrations
{
  /// <summary>
  /// Sets all unit tooltips in the game.
  /// </summary>
  public sealed class UnitTooltipMigration : IMapMigration
  {
    /// <inheritdoc />
    public void Migrate(Map map, ObjectDatabase objectDatabase)
    {
      var units = objectDatabase.GetUnits();
      var copiedUnits = units.ToList();
      foreach (var unit in copiedUnits)
      {
        DetermineTooltip(unit);
      }

      var unitData = objectDatabase.GetAllData().UnitData;
      map.UnitObjectData = unitData;
      map.UnitSkinObjectData = unitData;
    }

    private static void DetermineTooltip(Unit unit)
    {
      var tooltipBuilder = new StringBuilder();
      if (unit.IsTextNameModified)
      {
        Console.WriteLine($"Modifying {unit.TextName}...");
      }
      else
      {
        return;
      }

      AppendFlavour(tooltipBuilder, unit);

      foreach (var ability in unit.AbilitiesNormal)
      {
        try
        {
          tooltipBuilder.AppendLine(ability.TextName);
          Console.WriteLine($"Successfully got name {ability.TextName}");
        }
        catch
        {
          Console.WriteLine($"Failed to get {ability} TextName");
        }
      }

      var extendedTooltip = tooltipBuilder.ToString();
      Console.WriteLine(extendedTooltip);
      unit.TextTooltipExtended = extendedTooltip;
    }

    private static void AppendFlavour(StringBuilder stringBuilder, Unit unit)
    {
      try
      {
        var split = unit.TextTooltipExtended.Split("|n");
        stringBuilder.Append(split[0]);
      }
      catch
      {
        Console.WriteLine($"Failed to get {unit} extended tooltip");
      }
    }
  }
}