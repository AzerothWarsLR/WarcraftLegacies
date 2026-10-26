using MacroTools.Artifacts;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Gilneas.Quests;

/// <summary>Gilneas, standing alone, calls Goldrinn with the Scythe of Elune at Shadowfang Keep.</summary>
public sealed class QuestWolfWithin : QuestData
{
  private const int ChannelDuration = 60;
  private const float ChannelFacing = 135;
  private const float ChannelSpotX = 5539;
  private const float ChannelSpotY = 4274;
  private const float ChannelSpotHalfSize = 100;

  private readonly LegendaryHero _goldrinn;
  private readonly Artifact _scytheOfElune;

  public QuestWolfWithin(LegendaryHero tess, LegendaryHero goldrinn, Artifact scytheOfElune, Capital shadowfangKeep) : base("The Wolf Within",
    "No druid will come to tame the curse, so Gilneas must master it alone. Beneath the night sky at Shadowfang Keep, Tess Greymane can channel the Scythe of Elune to call out to Goldrinn, the wolf god whose fang made the worgen.",
    @"ReplaceableTextures\CommandButtons\BTNWorgenHunger.blp")
  {
    _goldrinn = goldrinn;
    _scytheOfElune = scytheOfElune;
    var level = new ObjectiveLegendLevel(tess, 7);
    var hasScythe = new ObjectiveLegendHasArtifact(tess, scytheOfElune);
    var controlKeep = new ObjectiveControlCapital(shadowfangKeep, false);
    var night = new ObjectiveNight();
    AddObjective(level);
    AddObjective(hasScythe);
    AddObjective(controlKeep);
    AddObjective(night);
    AddObjective(new ObjectiveChannelRect(ChannelSpot, "Shadowfang Keep", tess, ChannelDuration,
      ChannelFacing, "The Wolf Within")
    {
      StartCondition = () => level.Progress == QuestProgress.Complete && hasScythe.Progress == QuestProgress.Complete &&
                             controlKeep.Progress == QuestProgress.Complete && night.Progress == QuestProgress.Complete
    });
    ResearchId = UPGRADE_R07U_QUEST_COMPLETED_SHRINE_OF_THE_WOLF_GOD_OR_THE_WOLF_WITHIN;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Beneath the moon, Tess Greymane drives the Scythe of Elune into the earth of Shadowfang Keep. The scythe shatters as Goldrinn's spirit tears free of it, and the wolf god returns to the world, savage and unbound, to hunt beside the people his fang created.";

  /// <inheritdoc/>
  protected override string RewardDescription => Loc.Format(
    "The Scythe of Elune is consumed. Learn to train {hero} from the {altar}, and learn to train {unit} from the {building}",
    ("{hero}", _goldrinn.Name),
    ("{altar}", GetObjectName(UNIT_H02X_ALTAR_OF_KINGS_GILNEAS_ALTAR)),
    ("{unit}", GetObjectName(UNIT_O06P_WORGEN_SHAMAN_GILNEAS)),
    ("{building}", GetObjectName(UNIT_H03E_WORGEN_MANOR_GILNEAS_SPECIALIST)));

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    if (ArtifactManager.GetFromTypeId(_scytheOfElune.Item.TypeId) == _scytheOfElune)
    {
      ArtifactManager.Destroy(_scytheOfElune);
    }
  }

  private static Rectangle ChannelSpot => new(ChannelSpotX - ChannelSpotHalfSize, ChannelSpotY - ChannelSpotHalfSize,
    ChannelSpotX + ChannelSpotHalfSize, ChannelSpotY + ChannelSpotHalfSize);
}
