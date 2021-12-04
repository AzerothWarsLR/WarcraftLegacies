using AzerothWarsCSharp.MacroTools;

namespace AzerothWarsCSharp.Source.QuestOutcomes
{
  public class QuestOutcomeChangeFactionName : QuestOutcome
  {
    private readonly string _newName;
    
    public QuestOutcomeChangeFactionName(string newName)
    {
      _newName = newName;
      Description = $"Your faction's name is changed to {newName}";
    }

    public override void Fire()
    {
      if (ParentFaction != null) ParentFaction.Name = _newName;
    }
  }
}