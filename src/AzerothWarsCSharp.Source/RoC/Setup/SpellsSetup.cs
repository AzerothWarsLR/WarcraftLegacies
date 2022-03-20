using AzerothWarsCSharp.Source.Main.Spells;
using AzerothWarsCSharp.Source.Main.Spells.Fel_Horde;
using AzerothWarsCSharp.Source.RoC.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.RoC.Setup
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
    }
  }
}