using MacroTools.ControlPoints;
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
    SetupHeroEvents();
    SetupUnitEvents();
    SetupControlPointEvents();
    SetupCapitalEvents();
  }

  private static void SetupHeroEvents()
  {
    foreach (var p in Util.EnumeratePlayers())
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerFinishesTraining, OnHeroTrained, p.Id);
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnHeroDealsDamage, p.Id);
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakesDamage, OnHeroTakesDamage, p.Id);
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnHeroDeath, p.Id);
    }
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
    if (stats == null)
    {
      return;
    }

    stats.HeroName = hero.Name;
  }

  private static void OnHeroDealsDamage()
  {
    var source = @event.DamageSource;
    var target = @event.Unit;
    if (source == null || target == null)
    {
      return;
    }

    var stats = MmdManager.GetStats(source.Owner);
    if (stats == null)
    {
      return;
    }

    if (LegendaryHeroManager.GetFromUnit(source) != null)
    {
      stats.HeroDamageDealt += @event.Damage;
    }
  }

  private static void OnHeroTakesDamage()
  {
    var source = @event.DamageSource;
    var target = @event.Unit;
    if (source == null || target == null)
    {
      return;
    }

    var stats = MmdManager.GetStats(target.Owner);
    if (stats == null)
    {
      return;
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
    if (stats == null)
    {
      return;
    }

    stats.HeroDeaths += 1;
  }

  private static void SetupUnitEvents()
  {
    foreach (var p in Util.EnumeratePlayers())
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.FactionUnitKills, OnUnitKill, p.Id);
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnUnitDeath, p.Id);
    }
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
    if (stats == null)
    {
      return;
    }

    stats.UnitsKilled += 1;
  }

  private static void OnUnitDeath()
  {
    var unit = @event.Unit;
    var stats = MmdManager.GetStats(unit.Owner);
    if (stats == null)
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
        var stats = MmdManager.GetStats(owner);
        if (stats == null)
        {
          return;
        }

        stats.CapitalsDestroyed.Add(capital.Name);
      };
    }
  }
}
