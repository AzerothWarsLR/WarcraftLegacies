using WarcraftLegacies.Source.Factions.Dalaran.Mechanics;
using WarcraftLegacies.Source.Factions.FelHorde.Mechanics;
using WarcraftLegacies.Source.Factions.Gilneas.Mechanics;
using WarcraftLegacies.Source.Factions.Illidari.Mechanics;
using WarcraftLegacies.Source.Factions.Ironforge.Mechanics;
using WarcraftLegacies.Source.Factions.Kultiras.Mechanics;
using WarcraftLegacies.Source.Factions.Legion.Mechanics;
using WarcraftLegacies.Source.Factions.Lordaeron.Mechanics;
using WarcraftLegacies.Source.Factions.Quelthalas.Mechanics;
using WarcraftLegacies.Source.Factions.Scourge.Mechanics;
using WarcraftLegacies.Source.Factions.Stormwind.Mechanics;
using WarcraftLegacies.Source.Factions.Sunfury.Mechanics;
using WarcraftLegacies.Source.GameLogic.Rocks;

namespace WarcraftLegacies.Source.GameLogic;

public static class HardModeSetting
{
  public static bool EarlyGameSkipped { get; private set; }

  public static void Apply()
  {
    GrantUniversalTechUnlocks();
    ApplyWithoutTechUnlocks();
  }

  public static void ApplyWithoutTechUnlocks()
  {
    EarlyGameSkipped = true;
    RockSystem.RemoveAll();
    ScourgeHardModeSetup.Setup();
    LegionHardModeSetup.Setup();
    LordaeronHardModeSetup.Setup();
    QuelthalasHardModeSetup.Setup();
    IronforgeHardModeSetup.Setup();
    StormwindHardModeSetup.Setup();
    KultirasHardModeSetup.Setup();
    FelHordeHardModeSetup.Setup();
  }

  public static void ApplyToWildcardFactions()
  {
    DalaranHardModeSetup.Setup();
    GilneasHardModeSetup.Setup();
    IllidariHardModeSetup.Setup();
    SunfuryHardModeSetup.Setup();
  }

  private static void GrantUniversalTechUnlocks()
  {
    ResearchGranting.GrantToAllPlayers(UPGRADE_R09X_FLIGHT_UNIVERSAL_UPGRADE);
    ResearchGranting.GrantToAllPlayers(UPGRADE_R04R_NAVIGATION_UNIVERSAL_UPGRADE);
    ResearchGranting.GrantToAllPlayers(UPGRADE_RDBD_DEEP_BURROW_C_THUN);
  }
}
