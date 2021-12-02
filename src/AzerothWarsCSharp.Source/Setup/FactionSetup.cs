using AzerothWarsCSharp.Source.Setup.Factions;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class FactionSetup
  {
    public static void Setup()
    {
      LegionSetup.Initialize();
      FelHordeSetup.Initialize();
      LordaeronSetup.Initialize();
      IronforgeSetup.Initialize();
      DalaranSetup.Initialize();
      QuelthalasSetup.Initialize();
      FrostwolfSetup.Initialize();
      WarsongSetup.Initialize();
      SentinelsSetup.Initialize();
      StormwindSetup.Initialize();
      DruidsSetup.Initialize();
    }
  }
}