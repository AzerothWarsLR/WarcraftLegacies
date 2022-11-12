using MacroTools;
using MacroTools.Frames.Books.ArtifactSystem;
using MacroTools.Frames.Books.Powers;
using MacroTools.Mechanics;
using MacroTools.PassiveAbilitySystem;
using MacroTools.UserInterface;
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
      PreplacedUnitSystem.Initialize();
      AllLegendSetup.Setup();
      ShoreSetup.Setup();
      ControlPointSetup.Setup();
      InstanceSetup.Setup();
      TeamSetup.Setup();
      AllFactionSetup.Setup();
      PlayerSetup.Setup();
      NeutralHostileSetup.Setup();
      ArtifactSetup.Setup();
      AllQuestSetup.Setup();
      //ResearchSetup.Setup();
      ObserverSetup.Setup();
      SpellsSetup.Setup();
      CheatSetup.Setup();
      CommandSetup.Setup();
      ControlPointVictory.Setup();
      SilvermoonDies.Setup();
      //IncompatibleTierConfig.Setup();
      GameTime.Setup();
      FactionMultiboard.Setup();
      ArtifactBook.Initialize();
      PowerBook.Initialize();
      HintConfig.Setup();
      WaygateManager.Setup(Constants.UNIT_N0AO_WAY_GATE_DALARAN);
      BlightSystem.Setup(ScourgeSetup.Scourge);
      BlightSetup.Setup();
      QuestMenuSetup.Setup();
      CinematicMode.Start(59);
      DialogueSetup.Setup();
      DisplayIntroText.Setup(10);
      GameSettings.Setup();
      InfoQuests.Setup();
      DestructibleSetup.Setup();
      ResearchSetup.Setup();
      PatronSystem.Setup();
      PreplacedUnitSystem.Shutdown();
      OpenAllianceVote.Setup();
      AugmentSetup.Setup();
      RockSetup.Setup();
      TurnResearchSetup.Setup();
      UnitTypeConfig.Setup();
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
      //Todo: uncomment below
      // foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      // {
      //   var newFogModifier = CreateFogModifierRect(player, FOG_OF_WAR_VISIBLE, Regions.MercTavern, true, true);
      //   FogModifierStart(newFogModifier);
      // }
      BlockerSetup.Setup();
      NeutralVictimAndPassiveSetup.Setup();
      GateSetup.Setup();
      StartingResources.Setup();
      StartingQuestPopup.Setup(63);
      RefundZeroLimitUnits.Setup();
      HeroGlowFix.Setup();
      CleanPersons.Setup();
      PlayerLeaves.Setup();
      FloatingTextSetup.Setup(60, 10);
      AmbianceSetup.Setup();
      PassiveAbilityManager.InitializePreplacedUnits();
      IncompatibleResearchSetup.Setup();
      DemonGateSetup.Setup();
    }
  }
}