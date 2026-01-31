using MacroTools.Commands;
using MacroTools.ControlPoints;
using MacroTools.Factions;
using MacroTools.GameModes;
using MacroTools.Save;
using MacroTools.Sounds;
using MacroTools.Systems;
using MacroTools.UnitNames;
using MacroTools.UnitTraits;
using MacroTools.UserInterface;
using WarcraftLegacies.Source.ArtifactBehaviour;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.GameLogic.GameEnd;
using WarcraftLegacies.Source.GameModes;

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
    KeyboardSetup.InitializeKeyboard();
    DisplayIntroText.Setup(25);
    CinematicMode.Setup(59);
    SetupControlPointManager();
    SoundLibrary.Setup();
    Artifacts.Setup();
    AllLegends.Setup();
    ShoreSetup.Setup();
    ControlPointSetup.Setup();
    InstanceSetup.Setup();
    NeutralHostileSetup.Setup();
    var commandManager = new CommandManager();
    CommandSetup.Setup(commandManager);
    CheatSetup.Setup(commandManager);
    TeamSetup.Setup();
    PlayerSetup.Setup();
    FactionChoiceDialogSetup.Setup();
    SharedQuestSetup.Setup();
    SpellsSetup.Setup();
    FactionMultiboard.Setup();
    BookSetup.Setup();
    HintConfig.Setup();
    QuestMenuSetup.Setup();
    GameTime.Start();

    MapFlagSetup.Setup();
    InfoQuests.Setup();
    DestructibleSetup.Setup();
    PatronSystem.Setup();
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
    StartingResources.Setup();
    StartingQuestPopup.Setup(63);
    RefundZeroLimitUnits.Setup();
    HeroGlowFix.Setup();
    CleanupUnoccupiedPlayerSlots.Setup();
    PlayerLeaves.Setup();
    FloatingTextSetup.Setup(60, 10);
    AmbianceSetup.Setup();
    UnitTypeTraitRegistry.InitializePreplacedUnits();
    IncompatibleResearchSetup.Setup();
    DemonGateSetup.Setup();
    SummonRallyPoints.Setup();
    RemoveUnusedAreas.Run();
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
      RegenerationAbility = ABILITY_A0UT_CP_LIFE_REGEN_NEUTRAL,
      PiercingResistanceAbility = ABILITY_A13X_MAGIC_RESISTANCE_CONTROL_POINT_TOWER,
      IncreaseControlLevelAbilityTypeId = ABILITY_A0A8_FORTIFY_CONTROL_POINTS_SHARED,
      ControlLevelSettings = new ControlLevelSettings
      {
        DefaultDefenderUnitTypeId = UNIT_H03W_CONTROL_POINT_DEFENDER_LORDAERON,
        DamageBase = 8,
        DamagePerControlLevel = 1,
        ArmorPerControlLevel = 1,
        HitPointsPerControlLevel = 70,
        ControlLevelMaximum = 30
      }
    };
  }
}
