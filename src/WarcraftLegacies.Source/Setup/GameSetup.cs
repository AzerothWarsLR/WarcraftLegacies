using System;
using MacroTools;
using MacroTools.Mechanics;
using MacroTools.PassiveAbilitySystem;
using MacroTools.UserInterface;
using WarcraftLegacies.Source.ArtifactBehaviour;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.GameLogic.GameEnd;
using WarcraftLegacies.Source.Hints;
using WarcraftLegacies.Source.Mechanics.Quelthalas;
using WarcraftLegacies.Source.Mechanics.Scourge.Blight;
using WarcraftLegacies.Source.Rocks;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.UnitTypes;

namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// Responsible for setting up the entire game.
  /// </summary>
  public static class GameSetup
  {
    /// <summary>
    /// Initialize the entire game.
    /// </summary>
    public static void Setup()
    {
      var preplacedUnitSystem = new PreplacedUnitSystem();
      Console.WriteLine("a");
      SoundLibrary.Setup();
      Console.WriteLine("a");
      var artifactSetup = new ArtifactSetup(preplacedUnitSystem);
      Console.WriteLine("a");
      AllLegendSetup.Setup(preplacedUnitSystem, artifactSetup);
      Console.WriteLine("a");
      ShoreSetup.Setup();
      Console.WriteLine("a");
      ControlPointSetup.Setup();
      Console.WriteLine("a");
      InstanceSetup.Setup(preplacedUnitSystem);
      Console.WriteLine("a");
      TeamSetup.Setup();
      Console.WriteLine("a");
      AllFactionSetup.Setup(preplacedUnitSystem, artifactSetup);
      Console.WriteLine("a");
      PlayerSetup.Setup();
      Console.WriteLine("a");
      NeutralHostileSetup.Setup();
      Console.WriteLine("a");
      AllQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      Console.WriteLine("a");
      ObserverSetup.Setup();
      Console.WriteLine("a");
      SpellsSetup.Setup();
      Console.WriteLine("a");
      CheatSetup.Setup();
      Console.WriteLine("a");
      CommandSetup.Setup();
      Console.WriteLine("a");
      ControlPointVictory.Setup();
      Console.WriteLine("a");
      SilvermoonDies.Setup();
      Console.WriteLine("a");
      GameTime.Setup();
      Console.WriteLine("a");
      FactionMultiboard.Setup();
      Console.WriteLine("a");
      BookSetup.Setup();
      Console.WriteLine("a");
      HintConfig.Setup();
      Console.WriteLine("a");
      WaygateManager.Setup(Constants.UNIT_N0AO_WAY_GATE_DALARAN);
      Console.WriteLine("a");
      BlightSystem.Setup(ScourgeSetup.Scourge);
      Console.WriteLine("a");
      BlightSetup.Setup(preplacedUnitSystem);
      Console.WriteLine("a");
      QuestMenuSetup.Setup();
      Console.WriteLine("a");
      CinematicMode.Start(59);
      Console.WriteLine("a");
      DialogueSetup.Setup();
      Console.WriteLine("a");
      DisplayIntroText.Setup(10);
      Console.WriteLine("a");
      GameSettings.Setup();
      Console.WriteLine("a");
      InfoQuests.Setup();
      Console.WriteLine("a");
      DestructibleSetup.Setup(preplacedUnitSystem);
      Console.WriteLine("a");
      ResearchSetup.Setup(preplacedUnitSystem);
      Console.WriteLine("a");
      PatronSystem.Setup(preplacedUnitSystem);
      Console.WriteLine("a");
      OpenAllianceVote.Setup();
      Console.WriteLine("a");
      AugmentSetup.Setup();
      Console.WriteLine("a");
      RockSetup.Setup();
      Console.WriteLine("a");
      TurnResearchSetup.Setup();
      Console.WriteLine("a");
      UnitTypeConfig.Setup();
      Console.WriteLine("a");
      ShipyardBanZones.Setup(new[]
      {
        Regions.CaerDarrowShipyard,
        Regions.InstanceNazjatar,
        Regions.Arathi_Ships,
        Regions.Auberdine_Ships,
        Regions.Kali_Ships,
        Regions.Dustwallow_Ships,
        Regions.STV_Ships,
        Regions.Fenris_ships,
        Regions.Auberdine_Ships_2,
        Regions.Outland_Ships,
        Regions.Northern_Kali_Ships,
        Regions.Scholo_Ships,
        Regions.DalaranDungeon,
        Regions.Stromwind_antiship,
        Regions.StratholmeShipyard,
        Regions.Gilneas_Canals,
        Regions.TwistingNether,
        Regions.Dun_Morogh_Ships,
        Regions.Northrend_ships,
        Regions.Desolace_Ships,
        Regions.South_EK_Ships,
        Regions.IcecrownShipyard,
        Regions.Loch_Modan_Ships,
        Regions.Tomb_Of_Sargeras_Ships,
        Regions.Quel_Ships_1,
        Regions.Quel_Ships_2,
        Regions.Quel_Ships_3
      });
      Console.WriteLine("a");
      BlockerSetup.Setup();
      Console.WriteLine("a");
      NeutralVictimAndPassiveSetup.Setup();
      Console.WriteLine("a");
      GateSetup.Setup();
      Console.WriteLine("a");
      StartingResources.Setup();
      Console.WriteLine("a");
      StartingQuestPopup.Setup(63);
      Console.WriteLine("a");
      RefundZeroLimitUnits.Setup();
      Console.WriteLine("a");
      HeroGlowFix.Setup();
      Console.WriteLine("a");
      CleanPersons.Setup();
      Console.WriteLine("a");
      PlayerLeaves.Setup();
      Console.WriteLine("a");
      FloatingTextSetup.Setup(60, 10);
      Console.WriteLine("a");
      AmbianceSetup.Setup();
      Console.WriteLine("a");
      PassiveAbilityManager.InitializePreplacedUnits();
      Console.WriteLine("a");
      IncompatibleResearchSetup.Setup();
      Console.WriteLine("a");
      DemonGateSetup.Setup();
      Console.WriteLine("a");
      SummonRallyPoints.Setup();
      Console.WriteLine("a");
      RemoveUnusedAreas.Run();
      Console.WriteLine("a");
      EyeOfSargerasCooldowns.Setup();
      Console.WriteLine("a");
    }
  }
}