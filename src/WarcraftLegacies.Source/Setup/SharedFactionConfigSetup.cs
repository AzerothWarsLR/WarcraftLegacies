using MacroTools.Factions;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Responsible for registering all researches shared by all <see cref="Faction"/>s.
/// </summary>
public static class SharedFactionConfigSetup
{
  /// <summary>
  /// Adds to the <see cref="Faction"/> any globally shared object limits, like basic attack and defense researches.
  /// </summary>
  public static void AddSharedFactionConfig(Faction faction)
  {
    faction.ModObjectLimit(UPGRADE_RHME_COPPER_FORGED_WEAPONRY_UNIVERSAL_UPGRADE, 8);
    faction.ModObjectLimit(UPGRADE_RHAR_COPPER_ARMOR_PLATING_UNIVERSAL_UPGRADE, 8);
    faction.ModObjectLimit(UPGRADE_R04R_NAVIGATION_UNIVERSAL_UPGRADE, Faction.Unlimited);
    faction.ModObjectLimit(UPGRADE_R09X_FLIGHT_UNIVERSAL_UPGRADE, Faction.Unlimited);
    faction.ModObjectLimit(UPGRADE_R00C_IMPROVED_CANNONS_UNIVERSAL_UPGRADE, Faction.Unlimited);
    faction.ModObjectLimit(UPGRADE_R006_FORTIFIED_HULLS_UNIVERSAL_UPGRADE, Faction.Unlimited);
  }
}
