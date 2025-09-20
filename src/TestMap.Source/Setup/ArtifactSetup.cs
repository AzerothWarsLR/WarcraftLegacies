using MacroTools.ArtifactSystem;

namespace TestMap.Source.Setup;

public static class ArtifactSetup
{
  public static Artifact Killmaim { get; private set; }
  public static Artifact OrbOfFrost { get; private set; }
  public static Artifact KelensDagger { get; private set; }

  public static void Setup()
  {
    Killmaim = new Artifact(CreateItem(FourCC("klmm"), 0, 0));
    ArtifactManager.Register(Killmaim);

    OrbOfFrost = new Artifact(CreateItem(FourCC("ofro"), 0, 0));
    ArtifactManager.Register(OrbOfFrost);

    KelensDagger = new Artifact(CreateItem(FourCC("desc"), 0, 0));
    ArtifactManager.Register(KelensDagger);
  }
}
