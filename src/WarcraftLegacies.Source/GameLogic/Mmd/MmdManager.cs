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

      MmdVariables.hero_kills.Set(p, s.HeroKills);
      MmdVariables.hero_deaths.Set(p, s.HeroDeaths);
      MmdVariables.hero_damage_dealt.Set(p, s.HeroDamageDealt);
      MmdVariables.hero_damage_taken.Set(p, s.HeroDamageTaken);
      MmdVariables.hero_revives.Set(p, s.HeroRevives);

      MmdVariables.units_killed.Set(p, s.UnitsKilled);
      MmdVariables.units_lost.Set(p, s.UnitsLost);
      MmdVariables.damage_to_units.Set(p, s.DamageToUnits);
      MmdVariables.damage_to_heroes.Set(p, s.DamageToHeroes);
      MmdVariables.damage_taken_units.Set(p, s.DamageTakenUnits);
      MmdVariables.damage_taken_heroes.Set(p, s.DamageTakenHeroes);

      MmdVariables.gold_earned.Set(p, s.GoldEarned);
      MmdVariables.gold_spent.Set(p, s.GoldSpent);

      MmdVariables.cp_minutes_owned.Set(p, s.CpMinutesOwned);
      MmdVariables.cp_captures.Set(p, s.CpCaptures);
      MmdVariables.cp_value_controlled.Set(p, s.CpValueControlled);

      MmdVariables.turns_survived.Set(p, s.TurnsSurvived);
      MmdVariables.score.Set(p, MmdScoring.Compute(s));

      foreach (var c in s.CapitalsDestroyed)
      {
        MmdVariables.capital_destroyed_event.Emit(p.Name, c);
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
