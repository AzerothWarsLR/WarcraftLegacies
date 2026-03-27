using MacroTools.ControlPoints;

namespace WarcraftLegacies.Source.Setup;

public static class ControlPointManagerSetup
{
  public static void PreSetup()
  {
    ControlPointManager.Instance = new ControlPointManager
    {
      StartingMaxHitPoints = 1900,
      HostileStartingCurrentHitPoints = 1000,
      RegenerationAbility = ABILITY_A0UT_CP_LIFE_REGEN_NEUTRAL,
      PiercingResistanceAbility = ABILITY_A13X_MAGIC_RESISTANCE_CONTROL_POINT_TOWER,
      IncreaseControlLevelAbilityTypeId = ABILITY_A0A8_FORTIFY_CONTROL_POINTS_SHARED,
      ControlPointSettings = new ControlPointSettings
      {
        ArmorPerControlLevel = 1,
        HitPointsPerControlLevel = 70,
        ControlLevelMaximum = 30
      }
    };
  }
}
