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

      map.UnitObjectData = objectDatabase.GetAllData().UnitData;
    }

    private static void DetermineTooltip(Unit unit)
    {
      var tooltipBuilder = new StringBuilder();
      AppendFlavour(tooltipBuilder, unit);
      try
      {
        foreach (var ability in unit.AbilitiesNormal)
        {
          try
          {
            tooltipBuilder.AppendLine(ability.TextName);
            Console.WriteLine("nice!");
          }
          catch
          {
            Console.WriteLine("oh wow");
          }
        }
      }
      catch
      {
        Console.WriteLine("not good");
      }


      unit.TextTooltipExtended = tooltipBuilder.ToString();
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
        Console.WriteLine("bugger");
      }
    }
  }
}