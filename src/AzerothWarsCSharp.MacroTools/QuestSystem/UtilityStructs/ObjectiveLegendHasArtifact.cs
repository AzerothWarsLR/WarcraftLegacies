using AzerothWarsCSharp.MacroTools.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveLegendHasArtifact : Objective
  {
    private readonly Artifact _targetArtifact;
    private readonly Legend _targetLegend;

    public ObjectiveLegendHasArtifact(Legend targetLegend, Artifact targetArtifact)
    {
      Description = targetLegend.Name + " has " + GetItemName(targetArtifact.Item);
      _targetLegend = targetLegend;
      _targetArtifact = targetArtifact;
      targetArtifact.PickedUp += OnPickedUp;
    }

    internal override void OnAdd()
    {
      if (_targetArtifact.OwningUnit == _targetLegend.Unit) Progress = QuestProgress.Complete;
    }

    private void OnPickedUp(object? sender, Artifact artifact)
    {
      Progress = _targetArtifact.OwningUnit == _targetLegend.Unit
        ? QuestProgress.Complete
        : QuestProgress.Incomplete;
    }
  }
}