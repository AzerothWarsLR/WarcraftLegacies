using MacroTools.ControlPoints;
using MacroTools.Legends;
using MacroTools.Setup;
using WCSharp.Events;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic.Mmd;

public static class MmdEvents_W3MMD
{
  public static void Setup()
  {
    SetupHeroKillEvents();
    SetupUnitKillEvents();
    SetupCapitalEvents();
    SetupControlPointEvents();
  }

  private static void SetupHeroKillEvents()
  {
    foreach (var p in Util.EnumeratePlayers())
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnHeroDeath, p.Id);
    }
  }

  private static void OnHeroDeath()
  {
    var unit = @event.Unit;
    var killer = @event.KillingUnit;
    if (killer == null)
    {
      return;
    }

    var hero = LegendaryHeroManager.GetFromUnit(unit);
    if (hero == null)
    {
      return;
    }

    MmdVariables.hero_kill_event.Emit(killer.Owner.Name, unit.Owner.Name);
  }

  private static void SetupUnitKillEvents()
  {
    foreach (var p in Util.EnumeratePlayers())
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.FactionUnitKills, OnUnitKill, p.Id);
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

    MmdVariables.unit_kill_event.Emit(killer.Owner.Name, victim.Owner.Name);
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

        MmdVariables.capital_destroyed_event.Emit(capital.Unit.Owner.Name, capital.Name);
      };
    }
  }

  private static void SetupControlPointEvents()
  {
    foreach (var cp in ControlPointManager.Instance.GetAllControlPoints())
    {
      cp.OwnerAllianceChanged += controlPoint =>
      {
        MmdVariables.cp_capture_event.Emit(controlPoint.Owner.Name, controlPoint.Value.ToString());
      };
    }
  }
}
