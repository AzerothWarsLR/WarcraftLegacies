using MacroTools.Setup;
using WCSharp.Events;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic;

public static class HeroDamageTakenSetting
{
  public static float Multiplier { get; set; } = 1f;

  public static void Setup()
  {
    foreach (var player in Util.EnumeratePlayers())
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakingDamage, OnPlayerTakingDamage, player.Id);
    }
  }

  private static void OnPlayerTakingDamage()
  {
    if (Multiplier == 1f)
    {
      return;
    }

    var target = @event.Unit;
    if (unit.IsHero(target.UnitType))
    {
      @event.Damage *= Multiplier;
    }
  }
}
