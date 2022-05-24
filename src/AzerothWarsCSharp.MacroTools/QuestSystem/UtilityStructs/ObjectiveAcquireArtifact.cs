using AzerothWarsCSharp.MacroTools.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  ///   Completes when the quest holder picks up a particular <see cref="Artifact" />.
  /// </summary>
  public sealed class ObjectiveAcquireArtifact : Objective
  {
    private readonly Artifact _target;

    public ObjectiveAcquireArtifact(Artifact target)
    {
      Description = "Acquire " + GetItemName(target.Item);
      _target = target;
      target.PickedUp += OnPickedUp;
    }

    internal override void OnAdd(Faction whichFaction)
    {
      if (EligibleFactions.Contains(_target.OwningPlayer))
        Progress = QuestProgress.Complete;
    }

    private void OnPickedUp(object? sender, Artifact artifact)
    {
      Progress = EligibleFactions.Contains(_target.OwningPlayer) ? QuestProgress.Complete : QuestProgress.Incomplete;
    }
  }
}