using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Legends;
using WarcraftLegacies.Source.Save;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic.Mmd;

public static class MmdManager
{
  private static readonly Dictionary<player, MmdPlayerStats> _statsByPlayer = new();

  public static IReadOnlyDictionary<player, MmdPlayerStats> StatsByPlayer => _statsByPlayer;

  public static void RegisterPlayer(player p, Faction faction)
  {
    if (!_statsByPlayer.TryGetValue(p, out var stats))
    {
      stats = new MmdPlayerStats(p.Id);
      _statsByPlayer[p] = stats;
    }

    stats.PlayerName = p.Name;
    stats.FactionName = faction.Name;
    stats.TeamName = faction.TraditionalTeam?.Name;
  }

  public static MmdPlayerStats? GetStats(player p)
  {
    _statsByPlayer.TryGetValue(p, out var stats);
    return stats;
  }

  public static void SetHero(player p, LegendaryHero hero)
  {
    var stats = GetStats(p);
    if (stats == null)
    {
      return;
    }

    stats.HeroName = hero.Name;
  }

  public static void AddGoldEarned(player p, float amount)
  {
    var stats = GetStats(p);
    if (stats == null)
    {
      return;
    }

    stats.GoldEarned += amount;
  }

  public static void AddGoldSpent(player p, float amount)
  {
    var stats = GetStats(p);
    if (stats == null)
    {
      return;
    }

    stats.GoldSpent += amount;
  }

  public static void AddCpCapture(player p, int cpValue)
  {
    var stats = GetStats(p);
    if (stats == null)
    {
      return;
    }

    stats.CpCaptures += 1;
    stats.CpValueControlled += cpValue;
  }

  public static void AddCpMinutesOwned(player p, float cpCount)
  {
    var stats = GetStats(p);
    if (stats == null)
    {
      return;
    }

    stats.CpMinutesOwned += cpCount;
  }

  public static void AddUpgrade(player p, int researchId)
  {
    var stats = GetStats(p);
    if (stats == null)
    {
      return;
    }

    stats.UpgradesCompleted.Add(researchId);
  }

  public static void AddCapitalDestroyed(player p, string capitalName)
  {
    var stats = GetStats(p);
    if (stats == null)
    {
      return;
    }

    stats.CapitalsDestroyed.Add(capitalName);
  }

  public static void SetResult(player p, string result)
  {
    var stats = GetStats(p);
    if (stats == null)
    {
      return;
    }

    stats.Result = result;
  }

  public static void WriteToMmdCache()
  {
    foreach (var p in Util.EnumeratePlayers())
    {
      if (!_statsByPlayer.TryGetValue(p, out var s))
      {
        continue;
      }

      var save = MmdSaveManager.Get(p);
      save.PlayerId = p.Id;

      save.GamesPlayed += 1;

      save.LastScore = s.UnitsKilled
                       + s.HeroKills * 5
                       + s.CpCaptures * 3
                       + (int)(s.GoldEarned / 100);

      save.TotalScore += save.LastScore;

      if (s.Result == "win")
      {
        save.Wins += 1;
      }
      else if (s.Result == "loss")
      {
        save.Losses += 1;
      }

      MmdSaveManager.Save(save);
    }
  }
}
