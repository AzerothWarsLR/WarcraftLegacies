using System.Collections.Generic;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory
{
  public static class UnitFactory
  {
    public const float SPEED_BASE_CASTER = 220f;
    public const float SCALING_VALUE_CASTER = 0.85f;
    public const float COLLISION_SIZE_CASTER = 11f;
    public const float BUILD_TIME_CASTER = 3f;

    public static Unit CreateWorker(UnitType baseType, string newRawCode, string name, string model, string icon, IEnumerable<Ability> abilities = null, IEnumerable<Unit> structuresBuilt = null)
    {
      var newUnit = CreateUnit(baseType, newRawCode, name, model, icon, abilities);
      newUnit.StatsUnitClassification = new UnitClassification[] { UnitClassification.Peon };
      newUnit.TechtreeStructuresBuilt = structuresBuilt;
      return newUnit;
    }

    public static Unit CreateUnit(UnitType baseType, string newRawCode, string name, string model, string icon, IEnumerable<Ability> abilities = null)
    {
      var newUnit = new Unit(UnitType.Footman, newRawCode)
      {
        TextName = name,
        TextTooltipBasic = $"Train {name}",
        ArtModelFile = model,
        ArtIconGameInterface = icon,
        AbilitiesNormal = abilities,
      };
      return newUnit;
    }
  }
}