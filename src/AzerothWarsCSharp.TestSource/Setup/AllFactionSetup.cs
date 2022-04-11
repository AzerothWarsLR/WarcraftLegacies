using AzerothWarsCSharp.TestSource.Setup.FactionSetup.FactionSetup;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class AllFactionSetup
  {
    public static void Setup()
    {
      DalaranSetup.Setup();
      DruidsSetup.Setup();
      CthunSetup.Setup();
      BlackEmpireSetup.Setup();
      DraeneiSetup.Setup();
    }
  }
}