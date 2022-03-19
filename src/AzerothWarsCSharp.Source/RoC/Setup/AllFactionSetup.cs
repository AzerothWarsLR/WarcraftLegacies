using AzerothWarsCSharp.Source.RoC.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.RoC.Setup
{
  public static class AllFactionSetup
  {
    public static void Setup()
    {
      ScourgeSetup_OnInit();
      LegionSetup_OnInit();
      LordaeronSetup_OnInit();
      DalaranSetup_OnInit();
      QuelthalasSetup_OnInit();
      SentinelsSetup_OnInit();
      DruidsSetup_OnInit();
      FelHordeSetup_OnInit();
      FrostwolfSetup_OnInit();
      WarsongSetup_OnInit();
      StormwindSetup_OnInit();
      IronforgeSetup_OnInit();
      KultirasSetup_OnInit();
      NagaSetup_OnInit();
      GilneasSetup_OnInit();
      TrollSetup_OnInit();
      GoblinSetup.Setup();
      TwilightSetup_OnInit();
      ScarletSetup_OnInit();
      CthunSetup_OnInit();
      ForsakenSetup_OnInit();
      BlackEmpireSetup_OnInit();
      DraeneiSetup_OnInit();
    }
  }
}