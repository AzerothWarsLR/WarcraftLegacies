using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Gilneas.Quests;

public sealed class QuestGoldrinn : QuestData
{
  private readonly LegendaryHero _goldrinn;
  private readonly Faction _druids;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestGoldrinn"/> class.
  /// </summary>
  public QuestGoldrinn(LegendaryHero tess, LegendaryHero goldrinn, Faction druids) : base("Shrine of the Wolf God",
    "The Worgen curse originated from Goldrinn, the embodiment of ferocity, savagery, and unyielding will. Traveling to Mount Hyjal we might contact the wolf god to help us against our curse.",
    @"ReplaceableTextures\CommandButtons\BTNWorgenHunger.blp")
  {
    AddObjective(new ObjectiveLegendLevel(tess, 8));
    AddObjective(new ObjectiveLegendInRect(tess, Regions.MountHyjal, "Mount Hyjal"));
    ResearchId = UPGRADE_R07U_QUEST_COMPLETED_SHRINE_OF_THE_WOLF_GOD;
    _druids = druids;
    _goldrinn = goldrinn;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Tess Greymane calls to Goldrinn's spirit. Revolted at the horrors that his fang had wrought on the Gilnean people but impressed with their ferocity, he returns to the mortal world, ready to rend and tear for his new people.";

  /// <inheritdoc/>
  protected override string RewardDescription => Loc.Format(
    "Learn to train {hero} from the {altar}, and learn to train {unit} from the {building}. If you're allied to the Druids, {hero}'s starting experience is halved",
    ("{hero}", _goldrinn.Name),
    ("{altar}", GetObjectName(UNIT_H02X_ALTAR_OF_KINGS_GILNEAS_ALTAR)),
    ("{unit}", GetObjectName(UNIT_O06P_WORGEN_SHAMAN_GILNEAS)),
    ("{building}", GetObjectName(UNIT_H03E_WORGEN_MANOR_GILNEAS_SPECIALIST)));

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    if (ShouldApplyExperiencePenalty(completingFaction))
    {
      _goldrinn.StartingXp /= 2;
    }
  }

  private bool ShouldApplyExperiencePenalty(Faction completingFaction)
  {
    var druidsPlayer = _druids.Player;
    return druidsPlayer != null && completingFaction.Player != null &&
           druidsPlayer.GetPlayerData().Team?.Contains(completingFaction.Player) != false;
  }
}
