using System.Collections.Generic;
using System.Text;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Buildings
{
  class GenericBuilding
  {
    private static string GenerateExtendedTooltip(string flavourText, IEnumerable<Unit> unitsTrained = null, IEnumerable<Upgrade> upgradesResearched = null)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append(flavourText);
      stringBuilder.AppendLine("Trains: ");
      foreach (var unit in unitsTrained)
      {
        stringBuilder.Append(unit.TextName);
      }
      stringBuilder.AppendLine("Researches: ");
      foreach (var upgrade in upgradesResearched)
      {
        stringBuilder.Append(upgrade.TextName);
      }
      return stringBuilder.ToString();
    }

    public static Unit CreateBuilding(UnitType baseType, string newRawCode, string name, IEnumerable<Unit> units = null, IEnumerable<Upgrade> upgrades = null)
    {
      var newBuilding = new Unit(baseType, newRawCode)
      {
        TextTooltipBasic = name,
        TechtreeUnitsTrained = units,
        TechtreeResearchesAvailable = upgrades,
        TextTooltipExtended = GenerateExtendedTooltip("Primary troop production building.", units, upgrades),
      };
      return newBuilding;
    }
  }
}