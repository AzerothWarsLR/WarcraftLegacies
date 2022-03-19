namespace AzerothWarsCSharp.Source.RoC.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      ShoreSetup_OnInit();
      InstanceSetup_OnInit();
      TeamSetup_OnInit();
      AllFactionSetup.Setup();
      PersonSetup_OnInit();
      ArtifactSetup_OnInit();
      ControlPointSetup_OnInit();
      AllQuestSetup.Setup();
      ResearchSetup_OnInit();
      ObserverSetup_OnInit();
    }
  }
}