namespace AzerothWarsCSharp.MacroTools.QuestOutcomes
{
  public class QuestOutcomeRemoveArtifact : QuestOutcome
  {
    private readonly Artifact _artifactToRemove;

    public QuestOutcomeRemoveArtifact(Artifact artifactToRemove)
    {
      _artifactToRemove = artifactToRemove;
      Description = $"{artifactToRemove.Name} is permanently destroyed";
    }
    
    public override void Fire()
    {
      _artifactToRemove.Dispose();
    }
  }
}