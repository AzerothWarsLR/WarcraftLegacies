using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>Destroy Boralus to plunder the Kul Tiran treasury.</summary>
public sealed class QuestDrownedFleet : QuestData
{
  private const int GoldReward = 750;

  public QuestDrownedFleet(Capital boralus) : base("The Drowned Fleet",
    "Kul Tiras rules the seas, and the Proudmoore treasury is the richest in the Eastern Kingdoms. Destroy Boralus and plunder its coffers.",
    @"ReplaceableTextures\CommandButtons\BTNNorthrendShipyard.blp")
  {
    AddObjective(new ObjectiveCapitalDead(boralus));
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Boralus lies in ruins, and its treasury has been carried off to Shadowforge City.";

  /// <inheritdoc />
  protected override string RewardDescription => Loc.Format("Gain {gold} gold", ("{gold}", GoldReward.ToString()));

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var whichPlayer = completingFaction.Player;
    if (whichPlayer != null)
    {
      whichPlayer.Gold += GoldReward;
    }
  }
}
