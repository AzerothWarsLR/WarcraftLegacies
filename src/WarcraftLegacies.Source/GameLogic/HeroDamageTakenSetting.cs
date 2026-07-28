using MacroTools.Setup;
using WCSharp.Events;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Globally scales damage taken by hero units. Controlled by the Custom Options vote.
/// </summary>
public static class HeroDamageTakenSetting
{
  /// <summary>
  /// The multiplier currently applied to damage taken by heroes. Defaults to a no-op until the Custom Options
  /// vote concludes and sets it.
  /// </summary>
  public static float Multiplier { get; set; } = 1f;

  /// <summary>
  /// Registers the damage-scaling hook for all players.
  /// <remarks>Must run before <c>UnitTypeTraitRegistry.InitializePreplacedUnits</c>, which registers traits
  /// like Execute that set an absolute damage override on this same pre-mitigation event. WC3 fires triggers
  /// on a native event in registration order, so registering early guarantees those absolute overrides always
  /// run after - and are never rescaled by - this multiplier.</remarks>
  /// </summary>
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
