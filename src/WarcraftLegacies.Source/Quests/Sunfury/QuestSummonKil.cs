using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Sunfury
{
  /// <summary>
  /// Kael summons Kiljaeden
  /// </summary>
  public sealed class QuestSummonKil : QuestData
  {
    private readonly LegendaryHero _kael;

    /// <inheritdoc />
    public QuestSummonKil(Capital stormwindKeep, Capital karazhan, LegendaryHero kael) : base("The Deceiver",
      "The tower of Karazhan has residual fel energy from when Mediv succumbed to the Burning Legion. For Kael to properly channel it, the city of Stormwind and their Wizard tower will need to be destroyed.",
      @"ReplaceableTextures\CommandButtons\BTNKiljaedin.blp")
    {
      _kael = kael;
      AddObjective(new ObjectiveLegendLevel(_kael, 8));
      AddObjective(new ObjectiveCapitalDead(stormwindKeep));
      AddObjective(new ObjectiveControlCapital(karazhan, false));
      AddObjective(new ObjectiveChannelRect(Regions.KilSummon, "Karazhan", _kael, 180, 90, "Summoning Kil'jaeden"));
      ResearchId = Constants.UPGRADE_R09J_QUEST_COMPLETED_THE_DECEIVER;
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "With the residual fel energy inside of Karazhan and Stormwind destroyed, Kael can finally summon Kil'jaeden into the world.";
    
    /// <inheritdoc />
    protected override string RewardDescription =>
      "Kil'jaeden is now trainable at the Altar and you can train Warlocks";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      
    }
  }
}