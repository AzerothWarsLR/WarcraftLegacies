namespace AzerothWarsCSharp.MacroTools
{
  public abstract class QuestObjective
  {
    public string Description { get; protected init; }
    public QuestProgress Progress { get; protected set; }
  }
}