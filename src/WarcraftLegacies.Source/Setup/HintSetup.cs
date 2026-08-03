using MacroTools.Hints;
using MacroTools.Legends;
using MacroTools.Localization;
using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Setup;

public static class HintConfig
{
  public static void Setup()
  {
    Hint.Register(() => Loc.Get("Quests are unique objectives that grant rewards when completed. View the Quest Menu (F9) to see the quests available to your faction."));
    Hint.Register(() => Loc.Get("Artifacts are unique items that can grant major advantages. You can find out where Artifacts are using the Artifact Menu at the top-left of your screen."));
    Hint.Register(() => Loc.Get("Some heroes can't be revived, and some can only be revived if you control certain capitals when they die."));
    Hint.Register(() => Loc.Get("If you have low FPS, try turning off your health bars."));
    Hint.Register(() => Loc.Format("We have a thriving Discord community at {url}", ("{url}", "https://discord.gg//4eGZn")));
    Hint.Register(() => Loc.Get("When a player leaves, their units are refunded, then their gold and hero experience are spread among their remaining allies."));
    Hint.Register(() => Loc.Get("There are water passageways at the edge of the map you can use to instantly move to the other side of the map."));
    Hint.Register(() => Loc.Get("Every faction can build an item shop that contains useful purchasable items."));
    Hint.Register(() => Loc.Get("When you unlock a hero through a Quest, you usually still need to summon that hero from an Altar."));
    Hint.Register(() => Loc.Format(
      "The fastest way to travel between continents is by using items of type {item}.",
      ("{item}", GetObjectName(ITEM_STWP_TOWN_PORTAL_SCROLL))));
    Hint.Register(() => Loc.Get("Control Points have towers which get stronger every turn, or when you research Fortify."));
    Hint.Register(() => Loc.Format(
      "Each turn, every Capital and every gate gains bonus maximum hit points. Capitals gain {capitalPercent}% and gates gain {gatePercent}%.",
      ("{capitalPercent}", (CapitalManager.HitPointPercentagePerTurn * 100).ToString()),
      ("{gatePercent}", (Gate.HitPointPercentagePerTurn * 100).ToString())));
    Hint.Register(() => Loc.Format(
      "There are 4 units of type {unit} scattered throughout the seas, which each give a large amount of income when controlled.",
      ("{unit}", GetObjectName(UNIT_H014_TRADING_POST_SEA))));
    Hint.Register(() => Loc.Get("Summoned units grant no experience when slain."));
    Hint.Register(() => Loc.Get("All players get bonus income for the first 10 turns. Use it to train a strong army, complete your starting quests, and secure Control Points."));
  }
}
