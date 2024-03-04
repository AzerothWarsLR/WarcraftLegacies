using MacroTools.Extensions;
using MacroTools.LegendSystem;
using WCSharp.Events;


namespace WarcraftLegacies.Source.GameLogic
{
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
        var triggerUnit = GetTriggerUnit();
        var revivedLegend = LegendaryHeroManager.GetFromUnit(triggerUnit);
        if (revivedLegend?.HasCustomColor == true)
        {
          SetUnitColor(triggerUnit, revivedLegend.PlayerColor);
        }
        else
        {
          SetUnitColor(triggerUnit, GetTriggerPlayer()?.GetFaction()?.PlayerColor ?? PLAYER_COLOR_COAL);
        }
      });
    }
  }
}