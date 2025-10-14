using MacroTools.Extensions;
using MacroTools.LegendSystem;
using WCSharp.Events;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Responsible for managing hero glow colours.
/// </summary>
public static class HeroGlowFix
{
  /// <summary>
  /// Causes heroes trained to have their colours manually set to the colour indicated by their <see cref="Legend"/>
  /// class. This avoids a Warcraft 3 issue wherein revived heroes do not have their attachment colours updated to match their colour.
  /// </summary>
  public static void Setup()
  {
    PlayerUnitEvents.Register(HeroTypeEvent.FinishesRevive, () =>
    {
      var triggerUnit = @event.Unit;
      var triggerPlayer = @event.Player;
      var revivedLegend = LegendaryHeroManager.GetFromUnit(triggerUnit);
      if (revivedLegend?.HasCustomColor == true)
      {
        triggerUnit.SetColor(revivedLegend.PlayerColor);
      }
      else
      {
        triggerUnit.SetColor(triggerPlayer.GetPlayerData().Faction?.PlayerColor ?? playercolor.Coal);
      }
    });
  }
}
