using MacroTools.FactionSystem;
using WCSharp.Shared.Data;

namespace MacroTools.QuestSystem.UtilityStructs
{
  public class ObjectiveEitherOf : Objective
  {
    public Objective ObjectiveA { get; }

    public Objective ObjectiveB { get; }

    public ObjectiveEitherOf(Objective questItemA, Objective questItemB)
    {
      ObjectiveA = questItemA;
      ObjectiveB = questItemB;
      Description = $"{questItemA.Description} or {questItemB.Description}";
      questItemA.ProgressChanged += OnChildProgressChanged;
      questItemB.ProgressChanged += OnChildProgressChanged;
    }

    public override Point Position => new(ObjectiveA.Position.X, ObjectiveB.Position.Y);

    internal override void OnAdd(Faction whichFaction)
    {
      ObjectiveA.OnAdd(whichFaction);
      ObjectiveB.OnAdd(whichFaction);
      foreach (var eligibleFaction in EligibleFactions)
      {
        ObjectiveA.AddEligibleFaction(eligibleFaction);
        ObjectiveB.AddEligibleFaction(eligibleFaction);
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
        Progress = QuestProgress.Failed;
    }

    private void OnChildProgressChanged(object? sender, Objective objective)
    {
      Update();
    }
  }
}