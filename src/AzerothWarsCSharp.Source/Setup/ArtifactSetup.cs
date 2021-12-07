using AzerothWarsCSharp.MacroTools;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class ArtifactSetup
  {
    private const float DummyX = 0;
    private const float DummyY = 0;
    
    public static Artifact KillmaimSetup()
    {
      var killmaim = new Artifact(CreateItem(FourCC("klmm"), 0, 0));
      FactionSystem.Add(killmaim);
      return killmaim;
    }

    public static Artifact DrektharsSpellbookSetup()
    {
      var artifact = new Artifact(CreateItem(FourCC("dtsb"), 0, 0));
      FactionSystem.Add(artifact);
      return artifact;
    }

    public static void FillerArtifactSetup()
    {
      for (var i = 0; i < 20; i++)
      {
        var artifact = new Artifact(CreateItem(FourCC("dtsb"), 0, 0));
        FactionSystem.Add(artifact);
      }
    }
  }
}