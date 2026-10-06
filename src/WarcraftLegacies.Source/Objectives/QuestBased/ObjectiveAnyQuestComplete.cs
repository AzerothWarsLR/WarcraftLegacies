using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.QuestBased;

public sealed class ObjectiveAnyQuestComplete : Objective
{
  private readonly List<QuestData> _targets;

  public ObjectiveAnyQuestComplete(params QuestData[] targets)
  {
    _targets = targets.ToList();
    SetDescription("Complete any of the quests {quests}",
      ("{quests}", string.Join(", ", _targets.Select(x => Loc.Get(x.Title)))));
  }

  public override void OnAdd(Faction faction) => faction.QuestProgressChanged += OnQuestProgressChanged;

  private void OnQuestProgressChanged(FactionQuestProgressChangedEventArgs args)
  {
    if (!_targets.Contains(args.Quest))
    {
      return;
    }

    if (_targets.Any(x => x.Progress == QuestProgress.Complete))
    {
      Progress = QuestProgress.Complete;
    }
    else if (_targets.All(x => x.Progress == QuestProgress.Failed))
    {
      Progress = QuestProgress.Failed;
    }
  }
}
