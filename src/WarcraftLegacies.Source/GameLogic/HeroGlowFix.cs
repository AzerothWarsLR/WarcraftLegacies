using MacroTools.Extensions;
using MacroTools.Legends;
using WCSharp.Events;
using WCSharp.Shared.Data;

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
    PlayerUnitEvents.Register(HeroTypeEvent.FinishesRevive, () => RefreshColor(@event.Unit, @event.Player));

    var entersMap = trigger.Create();
    entersMap.RegisterEnterRegion(Rectangle.WorldBounds.Region, null);
    entersMap.AddAction(() => RefreshColor(@event.EnteringUnit, @event.EnteringUnit.Owner));
  }

  /// <summary>Recolours the unit so attachments like hero glows match its owner's faction rather than the lobby colour.</summary>
  private static void RefreshColor(unit whichUnit, player owner)
  {
    var legend = LegendaryHeroManager.GetFromUnit(whichUnit);
    if (legend?.HasCustomColor == true)
    {
      whichUnit.SetColor(legend.PlayerColor);
      return;
    }

    var faction = owner.GetPlayerData().Faction;
    if (faction != null)
    {
      whichUnit.SetColor(faction.PlayerColor);
    }
  }
}
