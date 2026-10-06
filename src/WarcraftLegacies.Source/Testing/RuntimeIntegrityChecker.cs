using System;
using MacroTools.ControlPoints;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Localization;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Testing;

/// <summary>
/// Performs basic checks during runtime to ensure that the map is configured correctly.
/// </summary>
public static class RuntimeIntegrityChecker
{
  /// <summary>
  /// Runs the <see cref="RuntimeIntegrityChecker"/>.
  /// </summary>
  public static void Setup()
  {
    GameTimeManager.RegisterOnTurn(1, RunGameStartChecks);
    CheckUndefeatedResearchNames();
    CheckQuestResearchNames();
  }

  /// <summary>
  /// Run checks that are only relevant once the game has finished initializing.
  /// </summary>
  private static void RunGameStartChecks()
  {
    NoNeutralPassiveVulnerableControlPoints();
  }

  private static void NoNeutralPassiveVulnerableControlPoints()
  {
    foreach (var controlPoint in ControlPointManager.Instance.GetAllControlPoints())
    {
      if (controlPoint.Owner == player.NeutralPassive && !controlPoint.Unit.IsInvulnerable)
      {
        Logger.LogWarning(Loc.Format("{name} is owned by Neutral Passive and is not invulnerable.", ("{name}", controlPoint.Name)));
      }
    }
  }

  private static void CheckUndefeatedResearchNames()
  {
    foreach (var faction in FactionManager.GetAllFactions())
    {
      if (faction.UndefeatedResearch == 0)
      {
        continue;
      }

      // The research is named after the faction, and GetObjectName returns the localised object data, so the
      // expected name has to be built in the same language. The faction's name is resolved the same way for the
      // same reason, and the suffix is a template rather than a literal, because a translation may put it on
      // either side of the name.
      var language = Loc.GetSystemLanguage();
      var intendedName = Loc.Format("{name} exists", language, ("{name}", Loc.Get(faction.Name, language)));
      var actualName = GetObjectName(faction.UndefeatedResearch);
      if (actualName != intendedName)
      {
        Logger.LogWarning($"{Loc.Get(faction.Name, language)}'s {nameof(faction.UndefeatedResearch)} should be named {intendedName} but it is instead named {actualName}.");
      }
    }
  }

  private static void CheckQuestResearchNames()
  {
    foreach (var faction in FactionManager.GetAllFactions())
    {
      foreach (var quest in faction.GetAllQuests())
      {
        if (quest.ResearchId == 0)
        {
          continue;
        }

        // The research is named after the quest. QuestData keeps the title as the source states it and localises
        // only the quest object it creates, so the title has to be resolved here; GetObjectName already returns the
        // localised object data. Both sides are then in the same language.
        //
        // What the check can insist on is that the research's name contains the quest's: a research may carry a
        // prefix, such as the "Quest Completed: " one this map's quests use, or a suffix naming the faction that
        // gets it, and either leaves the title itself intact. Demanding an exact match would mean the map cannot
        // be translated, because a title that is a fragment of a longer name has nothing to match against.
        var title = Loc.Get(quest.Title, Loc.GetSystemLanguage());
        var actualName = GetObjectName(quest.ResearchId);
        if (!actualName.Contains(title, StringComparison.Ordinal))
        {
          Logger.LogWarning(
            $"{title}'s {nameof(quest.ResearchId)} should be named {title} but it is instead named {actualName}.");
        }
      }
    }
  }
}
