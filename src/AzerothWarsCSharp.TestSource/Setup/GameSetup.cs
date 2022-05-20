using System;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Frames.Books.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.Frames.Books.Powers;
using AzerothWarsCSharp.MacroTools.Mechanics;
using AzerothWarsCSharp.MacroTools.UserInterface;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      PreplacedUnitSystem.Initialize();
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
      Console.WriteLine("Setting up ArtifactBook...");
      ArtifactBook.Initialize();
      Console.WriteLine("Setting up TestSetup...");
      TestSetup.Setup();
      Console.WriteLine("Setting up WaygateManager...");
      WaygateManager.Setup(FourCC("nwgt"));
      Console.WriteLine("Setting up HintSetup...");
      HintSetup.Setup();
      PreplacedUnitSystem.Shutdown();
    }
  }
}