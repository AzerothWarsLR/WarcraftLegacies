using AzerothWarsCSharp.MacroTools.Artifacts;
using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class QuestItemLegendHasArtifact : QuestItemData
  {
    private readonly Artifact _targetArtifact;
    private readonly Legend _targetLegend;

    public QuestItemLegendHasArtifact(Legend targetLegend, Artifact targetArtifact)
    {
      Description = targetLegend.Name + " has " + GetItemName(targetArtifact.Item);
      _targetLegend = targetLegend;
      _targetArtifact = targetArtifact;
      targetArtifact.Acquired += OnAcquired;
    }

    internal override void OnAdd()
    {
      if (_targetArtifact.OwningUnit == _targetLegend.Unit) Progress = QuestProgress.Complete;
    }

    private void OnAcquired(object? sender, Artifact artifact)
    {
      Progress = _targetArtifact.OwningUnit == _targetLegend.Unit
        ? QuestProgress.Complete
        : QuestProgress.Incomplete;
    }
  }
}