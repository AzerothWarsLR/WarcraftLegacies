using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.FelHorde.Quests.Maghar;

/// <summary>Rebuild Hellfire Citadel from its ruins as a Mag'har stronghold.</summary>
public sealed class QuestRestoreHellfire : QuestData
{
  private const float HellfireX = 960;
  private const float HellfireY = -26688;

  private readonly LegendaryHero _garrosh;

  public QuestRestoreHellfire(LegendaryHero garrosh) : base("Restore Hellfire",
    "Hellfire Citadel was raised by orc hands long before Magtheridon claimed it. Take back the peninsula and rebuild it as a fortress of the Mag'har.",
    @"ReplaceableTextures\CommandButtons\BTNFelOrcFortress.blp")
  {
    _garrosh = garrosh;
    AddObjective(new ObjectiveControlPoint(UNIT_N00S_HELLFIRE_PENINSULA));
    AddObjective(new ObjectiveResearch(UPGRADE_R11N_REBUILD_HELLFIRE_CITADEL_MAGHAR, UNIT_O20T_GARADAR_MAGHAR, true));
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Hellfire Citadel rises again, its walls rebuilt by Mag'har hands and its banners free of the demons' mark.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Hellfire Citadel is rebuilt as a Mag'har capital that can train your workers and elites, and Garrosh gains a level";

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction) =>
    whichFaction.ModObjectLimit(UPGRADE_R11N_REBUILD_HELLFIRE_CITADEL_MAGHAR, Faction.Unlimited);

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner == null)
    {
      return;
    }

    var garrosh = _garrosh.Unit;
    if (garrosh != null)
    {
      garrosh.SetLevel(garrosh.HeroLevel + 1);
    }

    foreach (var ruins in GlobalGroup.EnumUnitsInRange(HellfireX, HellfireY, 500))
    {
      if (ruins.UnitType == UNIT_N0Z7_RUINS_OF_HELLFIRE_CITADEL_MAGHAR)
      {
        ruins.Dispose();
      }
    }

    var hellfire = PathBase.CreateStructure(owner, UNIT_O20X_HELLFIRE_CITADEL_MAGHAR, HellfireX, HellfireY);
    if (hellfire == null)
    {
      return;
    }

    CapitalManager.Register(new Capital
    {
      Unit = hellfire,
      DeathMessage = "The rebuilt Hellfire Citadel has fallen."
    });
  }
}
