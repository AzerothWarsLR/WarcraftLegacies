using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.FelHorde.Quests;

/// <summary>
/// Once Stormwind falls, Rend rallies the Blackrock clan into the Dark Horde, freeing him from Blackrock Spire.
/// </summary>
public sealed class QuestDarkHorde : QuestData
{
  private readonly LegendaryHero _rend;

  public QuestDarkHorde(Capital stormwindKeep, Capital blackrockSpire, LegendaryHero rend) : base("The Dark Horde",
    "With Stormwind in ruins, Rend Blackhand means to rally the Blackrock clan beneath the spire and forge a Dark Horde that answers to no one but him.",
    @"ReplaceableTextures\CommandButtons\BTNBlackhand.blp")
  {
    _rend = rend;
    AddObjective(new ObjectiveCapitalDead(stormwindKeep));
    AddObjective(new ObjectiveControlCapital(blackrockSpire, false));
    AddObjective(new ObjectiveLegendAlive(rend));
    ResearchId = UPGRADE_R0AC_QUEST_COMPLETED_THE_DARK_HORDE_FEL_HORDE;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The Blackrock banners rise over the burning spire. The Dark Horde is born, and Rend Blackhand bows to no fortress.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Fel Grunts, Fel Raiders, Bonebreakers and Fel Crossbowmen gain 100 hit points, 10 damage and 2 armor. Rend Blackhand gains a level and 175 hit points, and can be revived even without Blackrock Spire";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner != null)
    {
      owner.SetTechResearched(UPGRADE_R0AD_THE_DARK_HORDE_REND_BLACKHAND_FEL_HORDE, 1);
    }

    _rend.ClearUnitDependencies();
    var rendUnit = _rend.Unit;
    if (rendUnit != null)
    {
      rendUnit.SetLevel(rendUnit.HeroLevel + 1);
    }
  }
}
