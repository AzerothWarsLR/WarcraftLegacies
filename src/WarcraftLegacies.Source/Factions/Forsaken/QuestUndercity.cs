using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Forsaken;

/// <summary>Take Capital City to make the Undercity beneath it the Forsaken's home.</summary>
public sealed class QuestUndercity : QuestData
{
  private readonly ForsakenBases _bases;

  public QuestUndercity(Capital capitalPalace, ForsakenBases bases) : base("The Undercity",
    "Beneath the ruins of Capital City lie the royal crypts of Lordaeron. Seize the palace above them, and the Forsaken will have a home no master can take from them.",
    @"ReplaceableTextures\CommandButtons\BTNSacrificialPit.blp")
  {
    _bases = bases;
    AddObjective(new ObjectiveControlCapital(capitalPalace, false, true));
    AddObjective(new ObjectiveSelfExists());
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The Forsaken descend into the catacombs beneath Capital City, and make the Undercity their home.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Gain the Undercity beneath Capital City, with its graves, a Plaguetorium and a Graveyard";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction) => _bases.BuildUndercity();
}
