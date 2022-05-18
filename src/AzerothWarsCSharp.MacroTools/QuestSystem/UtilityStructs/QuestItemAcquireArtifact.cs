using System;
using AzerothWarsCSharp.MacroTools.ArtifactSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  ///   Completes when the quest holder picks up a particular <see cref="Artifact" />.
  /// </summary>
  public sealed class QuestItemAcquireArtifact : QuestItemData
  {
    private readonly Artifact _target;

    public QuestItemAcquireArtifact(Artifact target)
    {
      Description = "Acquire " + GetItemName(target.Item);
      _target = target;
      target.PickedUp += OnPickedUp;
    }

    internal override void OnAdd()
    {
      if (_target.OwningPlayer == Holder.Player) 
        Progress = QuestProgress.Complete;
    }

    private void OnPickedUp(object? sender, Artifact artifact)
    {
      Progress = _target.OwningPlayer == Holder.Player ? QuestProgress.Complete : QuestProgress.Incomplete;
    }
  }
}