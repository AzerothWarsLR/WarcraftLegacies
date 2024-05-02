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
      foreach (var unit in units)
      {
        DetermineTooltip(unit);
      }
    }

    private static void DetermineTooltip(Unit unit)
    {
      var tooltipBuilder = new StringBuilder();
      tooltipBuilder.AppendLine("A really cool unit.");
      foreach (var ability in unit.AbilitiesNormal)
      {
        tooltipBuilder.AppendLine(ability.TextName);
      }

      unit.TextTooltipExtended = tooltipBuilder.ToString();
    }
  }
}