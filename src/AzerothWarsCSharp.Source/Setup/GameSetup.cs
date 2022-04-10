using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Artifacts;
using AzerothWarsCSharp.Source.Game_Logic;
using AzerothWarsCSharp.Source.Game_Logic.GameEnd;
using AzerothWarsCSharp.Source.Mechanics.Quelthalas;
using AzerothWarsCSharp.Source.User_Interface;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      Legend.Setup();
      ShoreSetup.Setup();
      InstanceSetup.Setup();
      TeamSetup.Setup();
      AllFactionSetup.Setup();
      PersonSetup.Setup();
      ArtifactSetup.Setup();
      ControlPointSetup.Setup();
      AllQuestSetup.Setup();
      //ResearchSetup.Setup();
      ObserverSetup.Setup();
      SpellsSetup.Setup();
      CpCapture.Setup();
      DestructibleHider.Setup();
      CheatSetup.Setup();
      CommandSetup.Setup();
      ControlPointVictory.Setup();
      SilvermoonDies.Setup();
      ZinrokhAssembly.Setup();
      //IncompatibleTierConfig.Setup();
      FactionMultiboard.Setup();
    }
  }
}