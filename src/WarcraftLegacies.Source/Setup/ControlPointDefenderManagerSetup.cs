using MacroTools.ControlPoints;

namespace WarcraftLegacies.Source.Setup;

public static class ControlPointDefenderManagerSetup
{
  public static void PreSetup()
  {
    ControlPointDefenderManager.Initialize(ControlPointManager.Instance, new ControlPointDefenderSettings
    {
      DamageBase = 3,
      DamagePerControlLevel = 1
    });
  }
}
