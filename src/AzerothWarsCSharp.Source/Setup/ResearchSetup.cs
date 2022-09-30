using AzerothWarsCSharp.Source.Researches.Lordaeron;
using AzerothWarsCSharp.Source.Researches.Ironforge;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class ResearchSetup
  {
    public static void Setup()
    {
      VeteranFootmen.Setup();
      TitanForgeArtifact.Setup();
    }
  }
}