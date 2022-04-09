using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Artifacts;
using AzerothWarsCSharp.Source.Game_Logic;
using AzerothWarsCSharp.Source.Game_Logic.GameEnd;
using AzerothWarsCSharp.Source.IncompatibleUpgrades;
using AzerothWarsCSharp.Source.Mechanics.Quelthalas;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      ShoreSetup.Setup();
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
      CommandSetup.Setup();
      ControlPointVictory.Setup();
      SilvermoonDies.Setup();
      ZinrokhAssembly.Setup();
      IncompatibleTierConfig.Setup();
    }
  }
}