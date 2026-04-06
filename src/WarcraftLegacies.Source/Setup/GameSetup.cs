using MacroTools.Cinematics;
using MacroTools.ControlPoints;
using MacroTools.Factions;
using MacroTools.GameModes;
using MacroTools.GameTime;
using MacroTools.Save;
using MacroTools.Sounds;
using MacroTools.UnitNames;
using MacroTools.UnitTraits;
using MacroTools.UserInterface;
using WarcraftLegacies.Source.Factions.FelHorde.Mechanics;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.GameLogic.ArtifactBehaviour;
using WarcraftLegacies.Source.GameLogic.GameEnd;
using WarcraftLegacies.Source.GameModes;
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
    SetupControlPointManager();
    SetupControlPointDefenderManager();
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
    var gameModeManager = new GameModeManager(new IGameMode[]
    {
      new ClosedAlliance(),
      new OpenAlliance(),
      new GreatWar()
    })
    {
      TimeToDisplay = 49,
      VoteLength = 10
    };
    gameModeManager.Setup();
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

  private static void SetupControlPointManager()
  {
    ControlPointManager.Instance = new ControlPointManager
    {
      StartingMaxHitPoints = 1900,
      HostileStartingCurrentHitPoints = 1000,
      RegenerationAbility = ABILITY_A0UT_CP_LIFE_REGENERATION_NEUTRAL,
      PiercingResistanceAbility = ABILITY_A13X_MAGIC_RESISTANCE_CONTROL_POINT_TOWER,
      IncreaseControlLevelAbilityTypeId = ABILITY_A0A8_FORTIFY_CONTROL_POINTS_SHARED,
      ControlPointSettings = new ControlPointSettings
      {
        ArmorPerControlLevel = 1,
        HitPointsPerControlLevel = 70,
        ControlLevelMaximum = 30
      }
    };
  }

  private static void SetupControlPointDefenderManager()
  {
    ControlPointDefenderManager.Initialize(ControlPointManager.Instance, new ControlPointDefenderSettings
    {
      DamageBase = 3,
      DamagePerControlLevel = 1
    });
  }
}
