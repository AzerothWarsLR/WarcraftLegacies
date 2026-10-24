using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Theramore.Quests;

/// <summary>Take Ratchet so its goblin shipwrights build juggernauts for Theramore.</summary>
public sealed class QuestGoblinShipyard : QuestData
{
  private const int GoldReward = 300;
  private const int JuggernautCount = 2;
  private const float HarbourX = -6985;
  private const float HarbourY = -10595;

  public QuestGoblinShipyard() : base("The Goblin Shipyard",
    "The goblins of Ratchet build warships for anyone who can pay. Take the port, and their shipwrights will build juggernauts for Theramore instead.",
    @"ReplaceableTextures\CommandButtons\BTNGoblinShipyard.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N0A6_RATCHET));
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Ratchet is in Theramore's hands. Its goblin shipwrights have built two juggernauts, and they wait in Theramore's harbour.";

  /// <inheritdoc />
  protected override string RewardDescription => "You gain 300 gold and 2 Juggernauts in Theramore's harbour";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner == null)
    {
      return;
    }

    owner.Gold += GoldReward;
    PathBase.CreateUnits(owner, UNIT_H0AN_JUGGERNAUT_ALLIANCE, JuggernautCount, HarbourX, HarbourY);
  }
}
