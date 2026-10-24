using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Legion.Quests;

namespace WarcraftLegacies.Source.Objectives.QuestBased;

/// <summary>Completes when one of the holder's heroes finishes the summoning of the Burning Legion, and fails if anyone else does.</summary>
public sealed class ObjectiveOwnHeroSummonsLegion : Objective
{
  private readonly QuestSummonLegion _summonLegion;

  public ObjectiveOwnHeroSummonsLegion(QuestSummonLegion summonLegion, Faction legion)
  {
    _summonLegion = summonLegion;
    SetDescription("One of your heroes completes the summoning of the Burning Legion");
    legion.QuestProgressChanged += OnQuestProgressChanged;
  }

  /// <summary>The hero that completed the summoning, if it was one of the holder's.</summary>
  public unit? Summoner { get; private set; }

  private void OnQuestProgressChanged(FactionQuestProgressChangedEventArgs args)
  {
    if (args.Quest != _summonLegion || args.Quest.Progress != QuestProgress.Complete || Progress != QuestProgress.Incomplete)
    {
      return;
    }

    var summoner = _summonLegion.Summoner;
    if (summoner != null && summoner.IsUnitType(unittype.Hero) && EligibleFactions.Contains(summoner.Owner))
    {
      Summoner = summoner;
      Progress = QuestProgress.Complete;
      return;
    }

    Progress = QuestProgress.Failed;
  }
}
