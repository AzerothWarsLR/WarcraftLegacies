using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FelHorde.Quests.Maghar;

/// <summary>An Elder Shaman communes with the elemental spirits at the Throne of the Elements.</summary>
public sealed class QuestThroneOfTheElements : QuestData
{
  private const int ChannelDuration = 60;
  private static readonly Rectangle _throne = new(-2833, -28044, -2577, -27788);

  public QuestThroneOfTheElements() : base("The Throne of the Elements",
    "The elemental spirits of Nagrand answer only to shamans they trust. Secure Nagrand, and let an Elder Shaman commune with them at the Throne of the Elements.",
    @"ReplaceableTextures\CommandButtons\BTNEarthTotem.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N00B_NAGRAND));
    AddObjective(new ObjectiveControlPoint(UNIT_N0CV_HALAAR));
    AddObjective(new ObjectiveChannelRect(_throne, "the Throne of the Elements", UNIT_O20B_ELDER_SHAMAN_MAGHAR,
      "an Elder Shaman", ChannelDuration, 90));
    ResearchId = UPGRADE_R11P_QUEST_COMPLETED_THE_THRONE_OF_THE_ELEMENTS_MAGHAR;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The elements answer the Elder Shaman's call. Every totem the Mag'har raise now draws strength from the Throne.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Totemic Bond can strengthen a totem with up to 6 nearby totems instead of 4";
}
