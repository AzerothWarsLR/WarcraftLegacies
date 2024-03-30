using MacroTools.HintSystem;

namespace TestMap.Source.Setup
{
  public static class HintSetup
  {
    public static void Setup( ){
      Hint.Register(new Hint("Quests are unique objectives that grant rewards when completed. View the Quest Menu (F9) to see the quests available to your faction."));
      Hint.Register(new Hint("Artifacts are unique items that can grant major advantages. You can find out where Artifacts are using the Artifact Menu at the top-left of your screen."));
      Hint.Register(new Hint("Some heroes can't be revived, and some can only be revived if you control certain capitals when they die."));
      Hint.Register(new Hint("If you have low FPS, try turning off your health bars."));
      Hint.Register(new Hint("We have a welcoming Discord community at https:;//discord.gg//4eGZn"));
      Hint.Register(new Hint("When a player leaves, their units are funded, then their hero experience and gold are spread among their remaining allies."));
      Hint.Register(new Hint("There are water passageways at the edge of the map you can use to instantly move to the other side of the map."));
      Hint.Register(new Hint("Every faction can build an item shop that contains useful purchasable items."));
      Hint.Register(new Hint("When you unlock a hero through a Quest, you usually still need to summon that hero from an Altar."));
      Hint.Register(new Hint("The best way to travel between continent is to use Town portal scrolls!"));
      Hint.Register(new Hint("You can send gold to your allies using the commands found in the Quests menu."));
      Hint.Register(new Hint("You can share control with your allies using the command found in the Quests menu."));
    }
  }
}