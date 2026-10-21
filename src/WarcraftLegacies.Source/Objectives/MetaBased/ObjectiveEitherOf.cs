using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Save;

namespace WarcraftLegacies.Source.Objectives.MetaBased;

public sealed class ObjectiveEitherOf : Objective
{
  public Objective ObjectiveA { get; }

  public Objective ObjectiveB { get; }

  private readonly string? _description;

  public ObjectiveEitherOf(Objective objectiveA, Objective objectiveB, string? description = null)
  {
    ObjectiveA = objectiveA;
    ObjectiveB = objectiveB;
    _description = description;
    SaveManager.RunWhenLocalPlayerSettingsReady(RefreshDescription);
    objectiveA.ProgressChanged += OnChildProgressChanged;
    objectiveB.ProgressChanged += OnChildProgressChanged;
    Position = ObjectiveA.Position;
  }

  /// <summary>Rebuilds the description from the two objectives, for when one of them has changed.</summary>
  public void RefreshDescription()
  {
    if (_description != null)
    {
      SetDescription(_description);
    }
    else
    {
      SetDescription("{a} or {b}", ("{a}", ObjectiveA.Description), ("{b}", ObjectiveB.Description));
    }
  }

  public override void OnAdd(Faction whichFaction)
  {
    foreach (var eligibleFaction in EligibleFactions)
    {
      ObjectiveA.EligibleFactions.Add(eligibleFaction);
      ObjectiveB.EligibleFactions.Add(eligibleFaction);
    }
    ObjectiveA.OnAdd(whichFaction);
    ObjectiveB.OnAdd(whichFaction);
    Update();
  }

  private void Update()
  {
    if (ObjectiveA.Progress == QuestProgress.Complete || ObjectiveB.Progress == QuestProgress.Complete)
    {
      Progress = QuestProgress.Complete;
      return;
    }

    if (ObjectiveA.Progress == QuestProgress.Failed && ObjectiveB.Progress == QuestProgress.Failed)
    {
      Progress = QuestProgress.Failed;
      return;
    }

    Progress = QuestProgress.Incomplete;
  }

  private void OnChildProgressChanged(Objective _)
  {
    Update();
  }
}
