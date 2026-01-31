using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WarcraftLegacies.Source.Powers;

namespace WarcraftLegacies.Source.Quests.Scourge;

public sealed class QuestCultoftheDamned : QuestData
{
  private readonly LegendaryHero _rivendare;
  private readonly Faction _lordaeron;

  public QuestCultoftheDamned(Faction lordaeron, LegendaryHero rivendare) : base("The Cult of the Damned",
    "To prepare the destruction of the Lordaeron kingdom, a secret cult will be formed.",
    @"ReplaceableTextures\CommandButtons\BTNBaronRivendare.blp")
  {
    _lordaeron = lordaeron;
    _rivendare = rivendare;
    AddObjective(new ObjectiveTime(420));
    ResearchId = UPGRADE_R01H_QUEST_COMPLETED_THE_CULT_OF_THE_DAMNED;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "With the Cult of the Damned established, the Scourge can plan their invasion of Lordaeron. The powerful Baron Rivendare has also joined the Cult to serve the Lich King.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"Gain vision over Lordaeron until you unleash the Plague, the Plague of Undeath research becomes available in the {GetObjectName(UNIT_U000_FROZEN_THRONE_SCOURGE_MAIN)}, and {_rivendare.Name} becomes trainable at the {GetObjectName(UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR)}";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    var power = new PlayerVisionPower("Cult Spies",
      "Grants vision of all of Lordaeron's units.",
      "Acolyte",
      new[]
      {
        _lordaeron.Player
      });
    completingFaction.AddPower(power);
    completingFaction.Player?.DisplayPowerAcquired(power);
  }
}
