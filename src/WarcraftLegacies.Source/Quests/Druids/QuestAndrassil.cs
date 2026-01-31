using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Quests.Druids;

public sealed class QuestAndrassil : QuestData
{
  private readonly Capital _vordrassil;

  private readonly LegendaryHero _ursoc;
  private readonly Factions.Scourge _scourge;

  public QuestAndrassil(Capital vordrassil, LegendaryHero ursoc, Factions.Scourge scourge) : base("Crown of the Snow",
    "Long ago, Fandral Staghelm cut a sapling from Nordrassil and used it to grow Andrassil in Northrend. Without the blessing of the Aspects, it fell to the Old Gods' corruption. If Northrend were to be reclaimed, Andrassil's growth could begin anew.",
    @"ReplaceableTextures\CommandButtons\BTNTreant.blp")
  {
    AddObjective(new ObjectiveBuildInRect(Regions.GrizzlyHills, "in Grizzly Hills",
     UNIT_ETOL_TREE_OF_LIFE_DRUIDS_T1, 3));
    AddObjective(new ObjectiveControlPoint(UNIT_N03U_GRIZZLY_HILLS));
    ResearchId = UPGRADE_R002_QUEST_COMPLETED_CROWN_OF_THE_SNOW_DRUIDS;
    _vordrassil = vordrassil;
    _ursoc = ursoc;
    _scourge = scourge;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "With Grizzly Hills now being tended by the Trees of Life, the time is ripe to regrow Andrassil in the hope that it can help reclaim this barren land.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"Gain a new capital at Grizzly Hills that can research a powerful upgrade for your {GetObjectName(UNIT_EDOC_DRUID_OF_THE_CLAW_DRUIDS)}, and learn to train the hero Ursoc from the {GetObjectName(UNIT_EATE_ALTAR_OF_ELDERS_DRUIDS_ALTAR)}. If you're allied to the Scourge, {_ursoc.Name}'s starting experience is halved";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    _vordrassil.Unit = unit.Create(completingFaction.Player, UNIT_N04F_ANDRASSIL_DRUIDS_OTHER, Regions.Andrassil.Rect.CenterX, Regions.Andrassil.Rect.CenterY, 0);

    if (ShouldApplyExperiencePenalty(completingFaction))
    {
      _ursoc.StartingXp /= 2;
    }
  }

  private bool ShouldApplyExperiencePenalty(Faction completingFaction)
  {
    var scourgePlayer = _scourge.Player;
    return scourgePlayer != null && completingFaction.Player != null &&
           scourgePlayer.GetPlayerData().Team?.Contains(completingFaction.Player) != false;
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(UPGRADE_R05X_BLESSING_OF_URSOL_DRUIDS, Faction.Unlimited);
  }
}
