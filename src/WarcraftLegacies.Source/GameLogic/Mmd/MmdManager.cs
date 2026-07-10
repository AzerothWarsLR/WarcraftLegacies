using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Legends;
using WCSharp.W3MMD;

namespace WarcraftLegacies.Source.GameLogic.Mmd;

public static class MmdManager
{
  private static readonly Dictionary<player, MmdPlayerStats> _statsByPlayer = new();

  public static IReadOnlyDictionary<player, MmdPlayerStats> StatsByPlayer => _statsByPlayer;

  public static event Action<player, Faction>? PlayerRegistered;

  public static void Setup()
  {
    PlayerData.FactionChange += args =>
    {
      if (args.Player.GetPlayerData().Faction is { } faction)
      {
        RegisterPlayer(args.Player, faction);
      }
    };
  }

  public static void RegisterPlayer(player p, Faction faction)
  {
    if (!MmdUtils.IsMmdPlayer(p))
    {
      return;
    }

    if (!_statsByPlayer.TryGetValue(p, out var stats))
    {
      stats = new MmdPlayerStats(p.Id);
      _statsByPlayer[p] = stats;

      faction.ScoreStatusChanged += changedFaction =>
      {
        if (changedFaction.ScoreStatus == ScoreStatus.Defeated)
        {
          SetResult(p, "loss");
        }
      };

      PlayerRegistered?.Invoke(p, faction);
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
    stats.TurnsSurvived = GameTimeManager.Turn;
  }

  public static void FinalizeUndecidedResults()
  {
    foreach (var (p, stats) in _statsByPlayer)
    {
      if (stats.Result != "Unknown")
      {
        continue;
      }

      if (p.GetPlayerData().Faction?.ScoreStatus != ScoreStatus.Defeated)
      {
        stats.Result = "win";
        stats.TurnsSurvived = GameTimeManager.Turn;
      }
    }
  }

  public static void WriteToMmd()
  {
    foreach (var p in MmdManager.StatsByPlayer.Keys)
    {
      if (!MmdUtils.IsMmdPlayer(p))
      {
        continue;
      }

      if (!_statsByPlayer.TryGetValue(p, out var s))
      {
        continue;
      }

      MmdVariables.HeroKills.Set(p, s.HeroKills);
      MmdVariables.HeroDeaths.Set(p, s.HeroDeaths);
      MmdVariables.HeroDamageDealt.Set(p, s.HeroDamageDealt);
      MmdVariables.HeroDamageTaken.Set(p, s.HeroDamageTaken);
      MmdVariables.HeroRevives.Set(p, s.HeroRevives);

      MmdVariables.UnitsKilled.Set(p, s.UnitsKilled);
      MmdVariables.UnitsLost.Set(p, s.UnitsLost);
      MmdVariables.DamageToUnits.Set(p, s.DamageToUnits);
      MmdVariables.DamageToHeroes.Set(p, s.DamageToHeroes);
      MmdVariables.DamageTakenUnits.Set(p, s.DamageTakenUnits);
      MmdVariables.DamageTakenHeroes.Set(p, s.DamageTakenHeroes);

      MmdVariables.GoldEarned.Set(p, s.GoldEarned);
      MmdVariables.GoldSpent.Set(p, s.GoldSpent);

      MmdVariables.CpMinutesOwned.Set(p, s.CpMinutesOwned);
      MmdVariables.CpCaptures.Set(p, s.CpCaptures);
      MmdVariables.CpValueControlled.Set(p, s.CpValueControlled);

      MmdVariables.TurnsSurvived.Set(p, s.TurnsSurvived);
      MmdVariables.Score.Set(p, MmdScoring.Compute(s));

      foreach (var c in s.CapitalsDestroyed)
      {
        MmdVariables.CapitalDestroyedEvent.Emit(p.Name, c);
      }

      if (s.Result == "win")
      {
        W3Mmd.SetPlayerFlag(p, W3MmdFlag.Winner);
      }
      else if (s.Result == "loss")
      {
        W3Mmd.SetPlayerFlag(p, W3MmdFlag.Loser);
      }
    }
  }
}
