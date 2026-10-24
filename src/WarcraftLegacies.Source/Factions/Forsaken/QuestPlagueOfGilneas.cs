using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Forsaken;

/// <summary>Destroy Gilneas Castle once Gilneas has come out from behind its wall.</summary>
public sealed class QuestPlagueOfGilneas : QuestData
{
  private const int GoldReward = 500;

  public QuestPlagueOfGilneas(Capital gilneasCastle) : base("Plague of Gilneas",
    "While Lordaeron burned, Genn Greymane hid his kingdom behind a wall. Now Gilneas has come out from hiding. Bring down Gilneas Castle, and let the Forsaken plague take the city.",
    @"ReplaceableTextures\CommandButtons\BTNPlagueCloud.blp")
  {
    AddObjective(new ObjectiveCapitalDead(gilneasCastle));
    AddObjective(new ObjectiveSelfExists());
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Gilneas Castle falls, and the plague seeps through the city's streets. Sylvanas's apothecaries study its dead, and their plague grows deadlier still.";

  /// <inheritdoc />
  protected override string RewardDescription => "You gain 500 gold and can research a second level of Epidemic";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.ModObjectLimit(UPGRADE_R10D_EPIDEMIC_FORSAKEN, 1);
    var owner = completingFaction.Player;
    if (owner != null)
    {
      owner.Gold += GoldReward;
    }
  }
}
