using MacroTools.ControlPoints;
using MacroTools.Factions;
using MacroTools.GameTime;
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
    GameTimeManager.OnTurn(1, RunGameStartChecks);
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
        Logger.LogWarning($"{controlPoint.Name} is owned by Neutral Passive and is not invulnerable.");
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

      var intendedName = $"{faction.Name} exists";
      var actualName = GetObjectName(faction.UndefeatedResearch);
      if (actualName != intendedName)
      {
        Logger.LogWarning($"{faction.Name}'s {nameof(faction.UndefeatedResearch)} should be named {intendedName} but it is instead named {actualName}.");
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

        var intendedName = $"Quest Completed: {quest.Title}";
        var actualName = GetObjectName(quest.ResearchId);
        if (!actualName.Equals(intendedName))
        {
          Logger.LogWarning(
            $"{quest.Title}'s {nameof(quest.ResearchId)} should be named {intendedName} but it is instead named {actualName}.");
        }
      }
    }
  }
}
