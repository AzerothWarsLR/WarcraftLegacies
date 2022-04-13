using System;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Artifacts;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Frames.Books.Powers;
using AzerothWarsCSharp.MacroTools.UserInterface;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      Console.WriteLine("Setting up Legend...");
      Legend.Setup();
      Console.WriteLine("Setting up LegendSetup...");
      LegendSetup.Setup();
      Console.WriteLine("Setting up ShoreSetup...");
      //ShoreSetup.Setup();
      Console.WriteLine("Setting up InstanceSetup...");
      //InstanceSetup.Setup();
      Console.WriteLine("Setting up TeamSetup...");
      TeamSetup.Setup();
      Console.WriteLine("Setting up AllFactionSetup...");
      AllFactionSetup.Setup();
      Console.WriteLine("Setting up PersonSetup...");
      PersonSetup.Setup();
      Console.WriteLine("Setting up Artifact...");
      Artifact.Setup();
      Console.WriteLine("Setting up ArtifactSetup...");
      ArtifactSetup.Setup();
      Console.WriteLine("Setting up ControlPointSetup...");
      ControlPointSetup.Setup();
      Console.WriteLine("Setting up AllQuestSetup...");
      AllQuestSetup.Setup();
      Console.WriteLine("Setting up ResearchSetup...");
      //ResearchSetup.Setup();
      Console.WriteLine("Setting up ObserverSetup...");
      //ObserverSetup.Setup();
      Console.WriteLine("Setting up SpellSetup...");
      SpellSetup.Setup();
      Console.WriteLine("Setting up CpCapture...");
      //CpCapture.Setup();
      Console.WriteLine("Setting up DestructibleHider...");
      DestructibleHider.Setup();
      Console.WriteLine("Setting up CheatSetup...");
      CheatSetup.Setup();
      Console.WriteLine("Setting up CommandSetup...");
      //CommandSetup.Setup();
      Console.WriteLine("Setting up ControlPointVictory...");
      //ControlPointVictory.Setup();
      Console.WriteLine("Setting up IncompatibleTierConfig...");
      //IncompatibleTierConfig.Setup();
      Console.WriteLine("Setting up FactionMultiboard...");
      FactionMultiboard.Setup();
      Console.WriteLine("Setting up PowerBook...");
      PowerBook.Initialize();
    }
  }
}