using System.Collections.Generic;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public static class BuildingFactory
  {
    private static string GenerateExtendedTooltip(string flavourText, IEnumerable<Unit> unitsTrained, IEnumerable<Upgrade> upgradesResearched)
    {
      return null;
    }

    public static void CreateBuilding(string newRawCode, IEnumerable<Unit> units, IEnumerable<Upgrade> upgrades, 
      string name, string model, string icon, string soundSet)
    {
      var newBuilding = new Unit(UnitType.Humanbarracks, newRawCode)
      {
        TextTooltipBasic = name,
        TechtreeUnitsTrained = units,
        TechtreeResearchesAvailable = upgrades,
        ArtModelFile = model,
        ArtIconGameInterface = icon,
        SoundUnitSoundSet = soundSet,
        TextTooltipExtended = GenerateExtendedTooltip("Primary troop production building.", units, upgrades);
      };
    }
  }
}