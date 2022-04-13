using System;
using AzerothWarsCSharp.MacroTools.Artifacts;
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
      target.Acquired += OnAcquired;
    }

    internal override void OnAdd()
    {
      if (_target.OwningPerson == Holder.Person) Progress = QuestProgress.Complete;
    }

    private void OnAcquired(object? sender, Artifact artifact)
    {
      Progress = _target.OwningPerson == Holder.Person ? QuestProgress.Complete : QuestProgress.Incomplete;
    }
  }
}