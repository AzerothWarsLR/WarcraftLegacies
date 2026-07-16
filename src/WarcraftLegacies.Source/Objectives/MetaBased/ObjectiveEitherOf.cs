using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Save;

namespace WarcraftLegacies.Source.Objectives.MetaBased;

public sealed class ObjectiveEitherOf : Objective
{
  public Objective ObjectiveA { get; }

  public Objective ObjectiveB { get; }

  public ObjectiveEitherOf(Objective objectiveA, Objective objectiveB)
  {
    ObjectiveA = objectiveA;
    ObjectiveB = objectiveB;
    SaveManager.RunWhenLocalPlayerSettingsReady(() =>
      SetDescription("{a} or {b}", ("{a}", objectiveA.Description), ("{b}", objectiveB.Description)));
    objectiveA.ProgressChanged += OnChildProgressChanged;
    objectiveB.ProgressChanged += OnChildProgressChanged;
    Position = ObjectiveA.Position;
  }

  public override void OnAdd(Faction whichFaction)
  {
    ObjectiveA.OnAdd(whichFaction);
    ObjectiveB.OnAdd(whichFaction);
    foreach (var eligibleFaction in EligibleFactions)
    {
      ObjectiveA.EligibleFactions.Add(eligibleFaction);
      ObjectiveB.EligibleFactions.Add(eligibleFaction);
    }
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
