using System;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Frames.Books.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.Frames.Books.Powers;
using AzerothWarsCSharp.MacroTools.Mechanics;
using AzerothWarsCSharp.MacroTools.UserInterface;
using AzerothWarsCSharp.Source.ArtifactBehaviour;
using AzerothWarsCSharp.Source.Game_Logic.GameEnd;
using AzerothWarsCSharp.Source.Hints;
using AzerothWarsCSharp.Source.Mechanics.Quelthalas;
using AzerothWarsCSharp.Source.Mechanics.Scourge.Blight;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      Console.WriteLine("Initializing PreplacedUnitSystem...");
      PreplacedUnitSystem.Initialize();
      Console.WriteLine("Setting up AllLegendSetup...");
      AllLegendSetup.Setup();
      Console.WriteLine("Setting up ShoreSetup...");
      ShoreSetup.Setup();
      Console.WriteLine("Setting up InstanceSetup...");
      InstanceSetup.Setup();
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
      ObserverSetup.Setup();
      Console.WriteLine("Setting up SpellsSetup...");
      SpellsSetup.Setup();
      Console.WriteLine("Setting up CheatSetup...");
      CheatSetup.Setup();
      Console.WriteLine("Setting up CommandSetup...");
      CommandSetup.Setup();
      Console.WriteLine("Setting up ControlPointVictory...");
      ControlPointVictory.Setup();
      Console.WriteLine("Setting up SilvermoonDies...");
      SilvermoonDies.Setup();
      Console.WriteLine("Setting up ZinrokhAssembly...");
      ZinrokhAssembly.Setup();
      Console.WriteLine("Setting up IncompatibleTierConfig...");
      //IncompatibleTierConfig.Setup();
      Console.WriteLine("Setting up FactionMultiboard...");
      FactionMultiboard.Setup();
      Console.WriteLine("Setting up ArtifactBook...");
      ArtifactBook.Initialize();
      Console.WriteLine("Setting up PowerBook...");
      PowerBook.Initialize();
      Console.WriteLine("Setting up HintConfig...");
      HintConfig.Setup();
      Console.WriteLine("Setting up WaygateManager...");
      WaygateManager.Setup(Constants.UNIT_N0AO_WAY_GATE_DALARAN);
      Console.WriteLine("Setting up BlightSystem...");
      BlightSystem.Setup(ScourgeSetup.FactionScourge);
      Console.WriteLine("Setting up BlightSetup...");
      BlightSetup.Setup();
      Console.WriteLine("Shutting down PreplacedUnitSystem...");
      PreplacedUnitSystem.Shutdown();
      Console.WriteLine("Setting up QuestMenuSetup...");
      QuestMenuSetup.Setup();
    }
  }
}