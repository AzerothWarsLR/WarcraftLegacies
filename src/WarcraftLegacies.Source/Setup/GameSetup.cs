using MacroTools.Cinematics;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Save;
using MacroTools.Sounds;
using MacroTools.UnitNames;
using MacroTools.UnitTraits;
using MacroTools.UserInterface;
using WarcraftLegacies.Source.ArtifactBehaviour;
using WarcraftLegacies.Source.Factions.FelHorde.Mechanics;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.GameLogic.GameEnd;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Testing;

namespace WarcraftLegacies.Source.Setup;

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
    FactionManager.Setup();
    UnitTypeSetup.Setup();
    SaveManager.Initialize();
    DisplayIntroText.Setup(25);
    CinematicMode.Setup(59);
    ControlPointManagerSetup.Setup();
    ControlPointDefenderManagerSetup.Setup();
    SoundLibrary.Setup();
    Artifacts.Setup();
    AllLegends.Setup();
    ShoreSetup.Setup();
    ControlPointSetup.Setup();
    InstanceSetup.Setup();
    NeutralHostileSetup.Setup();
    CommandSetup.Setup();
    CheatSetup.Setup();
    TeamSetup.Setup();
    FactionStartingResources.Setup();
    FactionMultiboard.Setup();
    PlayerSetup.Setup();
    FactionChoiceDialogSetup.Setup();
    SharedQuestSetup.Setup();
    SharedSpellSetup.Setup();
    BookSetup.Setup();
    HintConfig.Setup();
    QuestMenuSetup.Setup();
    GameTimeManager.Start();
    GameTimeDialog.Setup();
    MapFlagSetup.Setup();
    InfoQuests.Setup();
    DestructibleSetup.Setup();
    GameModeManagerSetup.Setup();
    RockSetup.Setup();
    TurnResearchSetup.Setup();
    ShipyardBanZonesSetup.Setup();
    BlockerSetup.Setup();
    NeutralVictimAndPassiveSetup.Setup();
    GateSetup.Setup();
    StartingQuestPopup.Setup(63);
    RefundZeroLimitUnits.Setup();
    HeroGlowFix.Setup();
    CleanupUnoccupiedPlayerSlots.Setup();
    PlayerElimination.Setup();
    PlayerLeaves.Setup();
    FloatingTextSetup.Setup(60, 10);
    AmbianceSetup.Setup();
    UnitTypeTraitRegistry.InitializePreplacedUnits();
    IncompatibleResearchSetup.Setup();
    DemonGateSetup.Setup();
    SummonRallyPoints.Setup();
    EyeOfSargerasCooldowns.Setup();
    CapturableUnitSetup.Setup();
    EyeOfSargerasPickup.Setup();
    RuntimeIntegrityChecker.Setup();
    DarkPortalControlNexusSetup.Setup();
    TagSummonedUnits.Setup();
    DynamicUnitNameRegistry.Setup(UniqueEliteNames.GetNames());
  }
}
