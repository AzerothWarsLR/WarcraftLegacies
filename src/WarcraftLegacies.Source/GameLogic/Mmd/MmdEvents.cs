using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.GameTime;
using MacroTools.Legends;
using MacroTools.Setup;
using WCSharp.Events;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic.Mmd;

public static class MmdEvents
{
  public static void Setup()
  {
    SetupHeroTracking();
    SetupKillDeathDamageTracking();
    SetupControlPointTracking();
  }

  private static void SetupHeroTracking()
  {
    foreach (var p in Util.EnumeratePlayers())
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerFinishesTraining, OnHeroTrained, p.Id);
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnHeroDamageEvent, p.Id);
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnHeroDeathEvent, p.Id);
    }

    foreach (var hero in LegendaryHeroManager.GetAll())
    {
      hero.Died += args =>
      {
        if (!args.Permanent && hero.Unit != null)
        {
          var stats = MmdManager.GetStats(hero.Unit.Owner);
          if (stats != null)
          {
            stats.HeroRevives += 1;
          }
        }
      };
    }
  }

  private static void OnHeroTrained()
  {
    var trained = @event.TrainedUnit;
    var hero = LegendaryHeroManager.GetFromUnit(trained);
    if (hero == null)
    {
      return;
    }

    MmdManager.SetHero(trained.Owner, hero);
  }

  private static void OnHeroDamageEvent()
  {
    var source = @event.DamageSource;
    var target = @event.Unit;
    var owner = source.Owner;
    var stats = MmdManager.GetStats(owner);
    if (stats == null)
    {
      return;
    }

    var isSourceHero = LegendaryHeroManager.GetFromUnit(source) != null;
    var isTargetHero = LegendaryHeroManager.GetFromUnit(target) != null;

    if (isSourceHero)
    {
      stats.HeroDamageDealt += @event.Damage;
    }

    if (isTargetHero)
    {
      stats.HeroDamageTaken += @event.Damage;
    }
  }

  private static void OnHeroDeathEvent()
  {
    var unit = @event.Unit;
    var hero = LegendaryHeroManager.GetFromUnit(unit);
    if (hero == null)
    {
      return;
    }

    var stats = MmdManager.GetStats(unit.Owner);
    if (stats == null)
    {
      return;
    }

    stats.HeroDeaths += 1;
  }

  private static void SetupKillDeathDamageTracking()
  {
    foreach (var p in Util.EnumeratePlayers())
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnUnitDeathEvent, p.Id);
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.FactionUnitKills, OnUnitKillEvent, p.Id);
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamageEvent, p.Id);
    }
  }

  private static void OnUnitDeathEvent()
  {
    var unit = @event.Unit;
    var owner = unit.Owner;
    var stats = MmdManager.GetStats(owner);
    if (stats == null)
    {
      return;
    }

    var isHero = LegendaryHeroManager.GetFromUnit(unit) != null;
    if (isHero)
    {
      stats.HeroDeaths += 1;
    }
    else
    {
      stats.UnitsLost += 1;
    }
  }

  private static void OnUnitKillEvent()
  {
    var killer = @event.KillingUnit;
    var owner = killer.Owner;
    var stats = MmdManager.GetStats(owner);
    if (stats == null)
    {
      return;
    }

    var isHero = LegendaryHeroManager.GetFromUnit(killer) != null;
    if (isHero)
    {
      stats.HeroKills += 1;
    }
    else
    {
      stats.UnitsKilled += 1;
    }
  }

  private static void OnDamageEvent()
  {
    var source = @event.DamageSource;
    var target = @event.Unit;
    var sourceStats = MmdManager.GetStats(source.Owner);
    var targetStats = MmdManager.GetStats(target.Owner);

    if (sourceStats == null && targetStats == null)
    {
      return;
    }

    var targetIsHero = LegendaryHeroManager.GetFromUnit(target) != null;

    if (sourceStats != null)
    {
      if (targetIsHero)
      {
        sourceStats.DamageToHeroes += @event.Damage;
      }
      else
      {
        sourceStats.DamageToUnits += @event.Damage;
      }
    }

    if (targetStats != null)
    {
      if (targetIsHero)
      {
        targetStats.DamageTakenHeroes += @event.Damage;
      }
      else
      {
        targetStats.DamageTakenUnits += @event.Damage;
      }
    }
  }

  private static void SetupControlPointTracking()
  {
    foreach (var cp in ControlPointManager.Instance.GetAllControlPoints())
    {
      cp.OwnerAllianceChanged += controlPoint =>
      {
        var owner = controlPoint.Owner;
        var stats = MmdManager.GetStats(owner);
        if (stats == null)
        {
          return;
        }

        stats.CpCaptures += 1;
        stats.CpValueControlled += controlPoint.Value;
      };
    }

    GameTimeManager.RegisterOnTurnRepeating(60, () =>
    {
      foreach (var p in Util.EnumeratePlayers(playerslotstate.Playing, mapcontrol.User))
      {
        var stats = MmdManager.GetStats(p);
        if (stats == null)
        {
          continue;
        }

        var playerData = p.GetPlayerData();
        var cpCount = playerData.ControlPoints.Count;
        MmdManager.AddCpMinutesOwned(p, cpCount);
      }
    });
  }
}
