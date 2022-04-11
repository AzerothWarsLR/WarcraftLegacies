using AzerothWarsCSharp.MacroTools.Factions;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemFactionDefeated : QuestItemData
  {
    public QuestItemFactionDefeated(Faction whichFaction)
    {
      Description = whichFaction.Name + " has been defeated";
      whichFaction.ScoreStatusChanged += OnAnyFactionScoreStatusChanged;
    }

    private  void OnAnyFactionScoreStatusChanged(object? sender, Faction faction)
    {
      if (faction.ScoreStatus == ScoreStatus.Defeated)
        Progress = QuestProgress.Complete;
    }
  }
}