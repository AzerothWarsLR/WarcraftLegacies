using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Artifacts;
using AzerothWarsCSharp.Source.Game_Logic;
using AzerothWarsCSharp.Source.Mechanics.Quelthalas;

namespace AzerothWarsCSharp.Source.Setup
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
      ControlPointSetup.Setup();
      AllQuestSetup.Setup();
      ResearchSetup_OnInit();
      ObserverSetup_OnInit();
      SpellsSetup.Setup();
      CpCapture.Setup();
      DestructibleHider.Setup();
      CheatSetup.Setup();

      SilvermoonDies.Setup();
      ZinrokhAssembly.Setup();
    }
  }
}