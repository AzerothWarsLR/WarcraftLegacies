using System.Collections.Generic;
using MacroTools.ControlPoints;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Legends;
using MacroTools.Setup;
using WCSharp.Events;

namespace WarcraftLegacies.Source.GameLogic.Mmd;

public static class MmdEvents
{
  private static readonly Dictionary<player, int> _lastGold = new();
  private static readonly Dictionary<player, int> _trackedGoldSpent = new();

  public static void SubscribeToPlayerRegistration()
  {
    MmdManager.PlayerRegistered += RegisterPlayerEvents;
  }

  public static void Setup()
  {
    SetupControlPointEvents();
    SetupCapitalEvents();
    SetupHeroReviveEvents();
    SetupGoldTracking();
    SetupTurnsSurvivedTracking();
  }

  private static bool IsMmdPlayer(player p)
  {
    return GetPlayerController(p) == MAP_CONTROL_USER
        && GetPlayerSlotState(p) != PLAYER_SLOT_STATE_EMPTY;
  }

  private static void RegisterPlayerEvents(player p, Faction faction)
  {
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerFinishesTraining, OnHeroTrained, p.Id);
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnPlayerDealsDamage, p.Id);
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakesDamage, OnPlayerTakesDamage, p.Id);
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnHeroDeath, p.Id);
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.FactionUnitKills, OnUnitKill, faction.Id);
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnUnitDeath, p.Id);
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerStartsTraining, OnPlayerStartsTraining, p.Id);
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerStartsConstruction, OnPlayerStartsConstruction, p.Id);

    _lastGold[p] = p.GetState(playerstate.ResourceGold);
    _trackedGoldSpent[p] = 0;
  }

  private static void OnHeroTrained()
  {
    var unit = @event.TrainedUnit;
    var hero = LegendaryHeroManager.GetFromUnit(unit);
    if (hero == null)
    {
      return;
    }

    var stats = MmdManager.GetStats(unit.Owner);
    if (stats == null || !IsMmdPlayer(unit.Owner))
    {
      return;
    }

    stats.HeroName = hero.Name;
  }

  private static void OnPlayerDealsDamage()
  {
    var source = @event.DamageSource;
    var target = @event.Unit;
    if (source == null || target == null)
    {
      return;
    }

    var stats = MmdManager.GetStats(source.Owner);
    if (stats == null || !IsMmdPlayer(source.Owner))
    {
      return;
    }

    if (LegendaryHeroManager.GetFromUnit(target) != null)
    {
      stats.DamageToHeroes += @event.Damage;
    }
    else
    {
      stats.DamageToUnits += @event.Damage;
    }

    if (LegendaryHeroManager.GetFromUnit(source) != null)
    {
      stats.HeroDamageDealt += @event.Damage;
    }
  }

  private static void OnPlayerTakesDamage()
  {
    var source = @event.DamageSource;
    var target = @event.Unit;
    if (source == null || target == null)
    {
      return;
    }

    var stats = MmdManager.GetStats(target.Owner);
    if (stats == null || !IsMmdPlayer(target.Owner))
    {
      return;
    }

    if (LegendaryHeroManager.GetFromUnit(source) != null)
    {
      stats.DamageTakenHeroes += @event.Damage;
    }
    else
    {
      stats.DamageTakenUnits += @event.Damage;
    }

    if (LegendaryHeroManager.GetFromUnit(target) != null)
    {
      stats.HeroDamageTaken += @event.Damage;
    }
  }

  private static void OnHeroDeath()
  {
    var unit = @event.Unit;
    var hero = LegendaryHeroManager.GetFromUnit(unit);
    if (hero == null)
    {
      return;
    }

    var stats = MmdManager.GetStats(unit.Owner);
    if (stats == null || !IsMmdPlayer(unit.Owner))
    {
      return;
    }

    stats.HeroDeaths += 1;
  }

  private static void OnUnitKill()
  {
    var killer = @event.KillingUnit;
    var victim = @event.Unit;
    if (killer == null || victim == null)
    {
      return;
    }

    var stats = MmdManager.GetStats(killer.Owner);
    if (stats == null || !IsMmdPlayer(killer.Owner))
    {
      return;
    }

    stats.UnitsKilled += 1;

    var victimHero = LegendaryHeroManager.GetFromUnit(victim);
    if (victimHero != null)
    {
      stats.HeroKills += 1;
      MmdVariables.HeroKillEvent.Emit(killer.Owner.Name, victimHero.Name);
    }
  }

  private static void OnUnitDeath()
  {
    var unit = @event.Unit;

    var stats = MmdManager.GetStats(unit.Owner);
    if (stats == null || !IsMmdPlayer(unit.Owner))
    {
      return;
    }

    stats.UnitsLost += 1;
  }

  private static void OnPlayerStartsTraining()
  {
    var p = @event.Player;
    if (!IsMmdPlayer(p))
    {
      return;
    }

    var cost = IsUnitIdType(@event.TrainedUnitType, unittype.Hero) ? PlayerDistributor.HeroCost : GetUnitGoldCost(@event.TrainedUnitType);
    if (cost > 0)
    {
      _trackedGoldSpent[p] += cost;
    }
  }

  private static void OnPlayerStartsConstruction()
  {
    var p = @event.Player;
    if (!IsMmdPlayer(p))
    {
      return;
    }

    var structure = @event.ConstructingStructure;
    var cost = structure == null ? 0 : structure.GoldCost;
    if (cost > 0)
    {
      _trackedGoldSpent[p] += cost;
    }
  }

  private static void SetupControlPointEvents()
  {
    foreach (var cp in ControlPointManager.Instance.GetAllControlPoints())
    {
      cp.OwnerAllianceChanged += controlPoint =>
      {
        var owner = controlPoint.Owner;

        if (!IsMmdPlayer(owner))
        {
          return;
        }

        var stats = MmdManager.GetStats(owner);
        if (stats == null)
        {
          return;
        }

        stats.CpCaptures += 1;
        stats.CpValueControlled += controlPoint.Value;
      };
    }

    GameTimeManager.RegisterOnTurnRepeating(1, () =>
    {
      foreach (var cp in ControlPointManager.Instance.GetAllControlPoints())
      {
        var owner = cp.Owner;

        if (!IsMmdPlayer(owner))
        {
          continue;
        }

        var stats = MmdManager.GetStats(owner);
        if (stats == null)
        {
          continue;
        }

        stats.CpMinutesOwned += 1f;
      }
    });
  }

  private static void SetupGoldTracking()
  {
    var goldTrackingTimer = CreateTimer();
    TimerStart(goldTrackingTimer, 1.0f, true, () =>
    {
      foreach (var p in _lastGold.Keys)
      {
        if (!IsMmdPlayer(p))
        {
          continue;
        }

        var stats = MmdManager.GetStats(p);
        if (stats == null)
        {
          continue;
        }

        var currentGold = p.GetState(playerstate.ResourceGold);
        var rawDelta = currentGold - _lastGold[p];
        var trackedSpent = _trackedGoldSpent[p];
        var reconstructedEarned = rawDelta + trackedSpent;

        if (reconstructedEarned >= 0)
        {
          stats.GoldEarned += reconstructedEarned;
          stats.GoldSpent += trackedSpent;
        }
        else
        {
          // The tracked spend alone doesn't explain the full drop in gold, meaning something spent gold that
          // wasn't captured by the training/construction hooks. Attribute the entire drop to spending rather
          // than letting the unexplained portion offset GoldEarned.
          stats.GoldSpent += trackedSpent - reconstructedEarned;
        }

        _lastGold[p] = currentGold;
        _trackedGoldSpent[p] = 0;
      }
    });
  }

  private static void SetupTurnsSurvivedTracking()
  {
    GameTimeManager.RegisterOnTurnRepeating(1, () =>
    {
      foreach (var p in MmdManager.StatsByPlayer.Keys)
      {
        if (!IsMmdPlayer(p))
        {
          continue;
        }

        var stats = MmdManager.GetStats(p);
        if (stats == null || stats.Result != "Unknown")
        {
          continue;
        }

        stats.TurnsSurvived = GameTimeManager.Turn;
      }
    });
  }

  private static void SetupCapitalEvents()
  {
    foreach (var capital in LegendaryHeroManager.GetAll())
    {
      capital.Died += args =>
      {
        if (capital.Unit == null)
        {
          return;
        }

        var owner = capital.Unit.Owner;

        if (!IsMmdPlayer(owner))
        {
          return;
        }

        var stats = MmdManager.GetStats(owner);
        if (stats == null)
        {
          return;
        }

        stats.CapitalsDestroyed.Add(capital.Name);
      };
    }
  }

  private static void SetupHeroReviveEvents()
  {
    foreach (var hero in LegendaryHeroManager.GetAll())
    {
      hero.Revived += () =>
      {
        if (hero.Unit == null)
        {
          return;
        }

        var owner = hero.Unit.Owner;

        if (!IsMmdPlayer(owner))
        {
          return;
        }

        var stats = MmdManager.GetStats(owner);
        if (stats == null)
        {
          return;
        }

        stats.HeroRevives += 1;
      };
    }
  }
}
