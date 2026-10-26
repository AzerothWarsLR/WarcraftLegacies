using MacroTools.Artifacts;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Factions.BloodElves.Quests;

/// <summary>Slay the naaru M'uru in Outland and take its heart.</summary>
public sealed class QuestHeartOfMuru : QuestData
{
  private const float MuruX = 2304;
  private const float MuruY = -19616;
  private const float MuruFacing = 270;

  public QuestHeartOfMuru() : base("The Naaru's Heart",
    "The naaru M'uru drifts through Outland, its heart brimming with holy light. Slay it and tear that heart free, and its power will be ours to use.",
    @"ReplaceableTextures\CommandButtons\BTNAquaGem.blp")
  {
    var muru = unit.Create(player.NeutralAggressive, UNIT_N0Z3_M_URU_CREEP, MuruX, MuruY, MuruFacing);
    HeartOfMuru = new Artifact(item.Create(ITEM_I0WH_HEART_OF_M_URU, MuruX, MuruY));
    muru.AddItem(HeartOfMuru.Item);
    ArtifactManager.Register(HeartOfMuru);
    AddObjective(new ObjectiveKillUnit(muru));
  }

  /// <summary>The artifact M'uru drops when it dies.</summary>
  public Artifact HeartOfMuru { get; }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "M'uru's light gutters and fails. Its heart, still warm with holy power, falls into the hands of the Blood Elves.";

  /// <inheritdoc />
  protected override string RewardDescription => "M'uru drops the Heart of M'uru, which increases its carrier's attributes";
}
