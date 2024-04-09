using MacroTools.HintSystem;
using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Setup
{
  public static class HintConfig
  {
    public static void Setup()
    {
      Hint.Register(new Hint("Quests are unique objectives that grant rewards when completed. View the Quest Menu (F9) to see the quests available to your faction."));
      Hint.Register(new Hint("Artifacts are unique items that can grant major advantages. You can find out where Artifacts are using the Artifact Menu at the top-left of your screen."));
      Hint.Register(new Hint("Some heroes can't be revived, and some can only be revived if you control certain capitals when they die."));
      Hint.Register(new Hint("If you have low FPS, try turning off your health bars."));
      Hint.Register(new Hint("We have a thriving Discord community at https://discord.gg//4eGZn"));
      Hint.Register(new Hint("When a player leaves, their units are funded, then their gold and hero experience are spread among their remaining allies."));
      Hint.Register(new Hint("There are water passageways at the edge of the map you can use to instantly move to the other side of the map."));
      Hint.Register(new Hint("Every faction can build an item shop that contains useful purchasable items."));
      Hint.Register(new Hint("When you unlock a hero through a Quest, you usually still need to summon that hero from an Altar."));
      Hint.Register(new Hint($"The best way to travel between continent by using {GetObjectName(ITEM_STWP_TOWN_PORTAL_SCROLL)}s."));
      Hint.Register(new Hint("If you want to support the team, support our Patreon at: https://www.patreon.com/lordsebas"));
      Hint.Register(new Hint("Control Points have towers which get stronger every turn, or when you research Fortify."));
      Hint.Register(new Hint($"Each turn, every Capital and every gate gains bonus maximum hit points. Capitals gain {CapitalManager.HitPointPercentagePerTurn*100}% and gates gain {MacroTools.PassiveAbilities.Gate.HitPointPercentagePerTurn*100}%."));
      Hint.Register(new Hint($"There are 4 {GetObjectName(UNIT_H014_TRADING_POST_SEA)}s scattered throughout the seas, which each give a large amount of income when controlled."));
      Hint.Register(new Hint("Summoned units grant no experience when slain."));
    }
  }
}