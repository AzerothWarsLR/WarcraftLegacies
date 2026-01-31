using MacroTools.ArtifactSystem;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;

namespace WarcraftLegacies.Source.Quests.Ironforge;

public sealed class QuestExpedition : QuestData
{
  private readonly int _rewardArtifactItemTypeId;

  public override string RewardFlavour =>
    $"After months of digging, excavating, and tomb raiding, the Explorer's Guild has finally unearthed an artifact from Ul'dum: {GetObjectName(_rewardArtifactItemTypeId)}.";

  protected override string RewardDescription => $"The Artifact {GetObjectName(_rewardArtifactItemTypeId)} appears at Uldum";

  public QuestExpedition(int rewardArtifactItemTypeId) : base("Secrets of Uldum",
    "Uldum was once a vast jungle, until the Forge of Origination stationed there wiped the slate clean. Now, buried under the sands lies a veritable trove of ancient relics.",
    @"ReplaceableTextures\CommandButtons\BTNGatherGold.blp")
  {
    Knowledge = 5;
    _rewardArtifactItemTypeId = rewardArtifactItemTypeId;
    AddObjective(new ObjectiveControlLevel(UNIT_N0BD_ULDUM, 5));
  }

  protected override void OnComplete(Faction whichFaction)
  {
    var uldumPosition = ControlPointManager.Instance.GetFromUnitType(UNIT_N0BD_ULDUM).Unit.GetPosition();
    var rewardItem = item.Create(_rewardArtifactItemTypeId, uldumPosition.X, uldumPosition.Y);
    var rewardArtifact = new Artifact(rewardItem);
    ArtifactManager.Register(rewardArtifact);
  }
}
