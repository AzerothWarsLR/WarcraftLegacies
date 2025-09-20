using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.MetaBased;

public sealed class ObjectiveEitherOf : Objective
{
  public Objective ObjectiveA { get; }

  public Objective ObjectiveB { get; }

  public ObjectiveEitherOf(Objective objectiveA, Objective objectiveB)
  {
    ObjectiveA = objectiveA;
    ObjectiveB = objectiveB;
    Description = $"{objectiveA.Description} or {objectiveB.Description}";
    objectiveA.ProgressChanged += OnChildProgressChanged;
    objectiveB.ProgressChanged += OnChildProgressChanged;
    Position = ObjectiveA.Position;
  }

  public override void OnAdd(FactionSystem.Faction whichFaction)
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
    }
  }

  private void OnChildProgressChanged(object? sender, Objective objective)
  {
    Update();
  }
}
