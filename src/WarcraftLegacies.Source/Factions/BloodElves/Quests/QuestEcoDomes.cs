using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.BloodElves.Quests;

/// <summary>Grow Arboretums in Netherstorm's eco-domes to feed the elves exiled to Outland.</summary>
public sealed class QuestEcoDomes : QuestData
{
  private const int GoldReward = 300;
  private const int ArboretumLimitBonus = 2;
  private const string DomeArea = "in one of the 3 Eco-domes in Netherstorm";

  public QuestEcoDomes(Rectangle dome1, Rectangle dome2, Rectangle dome3) : base("Eco-domes",
    "Our people must learn to live in the inhospitable Netherstorm. Its eco-domes, remnants of the verdant Farahlon, would make fine homes for growth facilities to feed our people.",
    @"ReplaceableTextures\CommandButtons\BTNFeatherMoonAura.blp")
  {
    AddObjective(new ObjectiveUpgrade(UNIT_H0C5_SANCTUARY_SUNFURY_T3, UNIT_H02P_HOLDING_SUNFURY_T1));
    AddObjective(new ObjectiveBuildInRect(dome1, DomeArea, UNIT_H0C7_ARBORETUM_SUNFURY_FARM));
    AddObjective(new ObjectiveBuildInRect(dome2, DomeArea, UNIT_H0C7_ARBORETUM_SUNFURY_FARM));
    AddObjective(new ObjectiveBuildInRect(dome3, DomeArea, UNIT_H0C7_ARBORETUM_SUNFURY_FARM));
    ResearchId = UPGRADE_R09I_QUEST_COMPLETED_ECO_DOMES;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The eco-domes bloom once more. With food secured, our people can spread across Netherstorm.";

  /// <inheritdoc />
  protected override string RewardDescription => Loc.Format(
    "Gain {gold} gold, build {bonus} more {arboretum}s, and learn to build more {ancientPool}s and {artificerCourt}s",
    ("{gold}", GoldReward.ToString()),
    ("{bonus}", ArboretumLimitBonus.ToString()),
    ("{arboretum}", GetObjectName(UNIT_H0C7_ARBORETUM_SUNFURY_FARM)),
    ("{ancientPool}", GetObjectName(UNIT_H0CA_ANCIENT_POOL_SUNFURY_SPECIALIST)),
    ("{artificerCourt}", GetObjectName(UNIT_H0CI_ARTIFICER_S_COURT_SUNFURY_SIEGE)));

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.ModObjectLimit(UNIT_H0C7_ARBORETUM_SUNFURY_FARM, ArboretumLimitBonus);
    if (completingFaction.Player != null)
    {
      completingFaction.Player.Gold += GoldReward;
    }
  }
}
