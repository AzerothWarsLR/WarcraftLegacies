using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.HintSystem;

namespace AzerothWarsCSharp.Source.Hints
{
  public class HintConfig{

    public static void Setup( ){
      Hint.Register(new Hint("Quests are unique objectives that grant rewards when completed. View the Quest Menu (F9) to see the quests available to your faction."));
      Hint.Register(new Hint("Artifacts are unique items that can grant major advantages. You can find out where Artifacts are using the Artifact Menu at the top-left of your screen."));
      Hint.Register(new Hint("Some heroes canFourCC(t be revived, and some can only be revived if (you control certain capitals when they die."));
      Hint.Register(new Hint("If you have low FPS, try turning off your health bars."));
      Hint.Register(new Hint("We have a welcoming Discord community at https:;//discord.gg//4eGZn"));
      Hint.Register(new Hint("When a player leaves, their gold, lumber, units and hero experience are spread among their remaining allies."));
      Hint.Register(new Hint("There are water passageways at the edge of the map you can use to instantly move to the other side of the map."));
      Hint.Register(new Hint("Every faction can build an item shop that contains useful purchasable items."));
      Hint.Register(new Hint("When you unlock a hero through a Quest, you still need to summon that hero from an Altar."));
      Hint.Register(new Hint("Workers do !require drop site for lumber"));
      Hint.Register(new Hint("All quest to unlock cities will fail at turn 24, turning the city hostile to everyone"));
      Hint.Register(new Hint("The best way to travel between continent is to use Town portal scrolls!"));
      Hint.Register(new Hint("If you want to support the team, support our Patreon at: https:;//www.patreon.com/lordsebas"));
    }

  }
}
