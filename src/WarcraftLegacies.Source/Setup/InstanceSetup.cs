using MacroTools.Instances;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Responsible for setting up all <see cref="Instance"/>s.
/// </summary>
public static class InstanceSetup
{
  /// <summary>
  /// Sets up all <see cref="Instance"/>s.
  /// </summary>
  public static void Setup()
  {
    InstanceSystem.Register(
      new Instance(Regions.MonolithNoBuild)
    );

    InstanceSystem.Register(
      new Instance(Regions.InstanceOutland)
    );

    InstanceSystem.Register(new Instance(Regions.ArtifactDummyInstance));
  }
}
