using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Stormwind.Quests.Stromgarde;

/// <summary>All three Trollbanes reach the height of their power.</summary>
public sealed class QuestTrollbaneLegacy : QuestData
{
  private const int BonusAttributes = 5;

  private readonly LegendaryHero[] _trollbanes;

  public QuestTrollbaneLegacy(LegendaryHero thoras, LegendaryHero danath, LegendaryHero galen) : base("The Trollbane Legacy",
    "The Trollbane line has ruled Stromgarde since the days of Arathor. Let the king, his brother and his heir prove themselves worthy of the name.",
    @"ReplaceableTextures\CommandButtons\BTNTheCaptain.blp")
  {
    _trollbanes = new[] { thoras, danath, galen };
    AddObjective(new ObjectiveLegendLevel(thoras, 10));
    AddObjective(new ObjectiveLegendLevel(danath, 10));
    AddObjective(new ObjectiveLegendLevel(galen, 10));
    ResearchId = UPGRADE_R11Y_QUEST_COMPLETED_THE_TROLLBANE_LEGACY_STROMGARDE;
  }

  /// <inheritdoc/>
  public override string RewardFlavour => "Thoras, Danath and Galen stand together at the height of their power. The Trollbane name is feared once more.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Thoras, Danath and Galen each gain 5 Strength, Agility and Intelligence, the Kingsguard gain 250 hit points and 10 damage, and you can research the upgrades that turn your Swordsmen, Spearmen, Lancers and Marshals into their veteran forms";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    foreach (var trollbane in _trollbanes)
    {
      var hero = trollbane.Unit;
      if (hero != null)
      {
        hero.AddHeroAttributes(BonusAttributes, BonusAttributes, BonusAttributes);
      }
    }
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
}
