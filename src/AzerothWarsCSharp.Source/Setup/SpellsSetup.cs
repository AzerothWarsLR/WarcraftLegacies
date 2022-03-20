using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Spells;
using AzerothWarsCSharp.Source.Spells.Fel_Horde;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class SpellsSetup
  {
    public static void Setup()
    {
      MassAms.Setup();
      WarsongSetup.Setup();
      BombingRun.Setup();
      IllusionaryLance.Setup();
      ThunderFists.Setup();
      InspireMadness.Setup();
    }
  }
}