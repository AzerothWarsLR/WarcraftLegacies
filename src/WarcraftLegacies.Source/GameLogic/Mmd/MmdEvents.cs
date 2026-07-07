using MacroTools.ControlPoints;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Legends;
using MacroTools.Setup;
using WCSharp.Events;

namespace WarcraftLegacies.Source.GameLogic.Mmd;

public static class MmdEvents
{
  public static void SubscribeToPlayerRegistration()
  {
    MmdManager.PlayerRegistered += RegisterPlayerEvents;
  }

  public static void Setup()
  {
    SetupControlPointEvents();
    SetupCapitalEvents();
    SetupHeroReviveEvents();
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
