library HintConfig initializer OnInit requires Hint

  private function OnInit takes nothing returns nothing
    call Hint.create("Quests are unique objectives that grant rewards when completed. View the Quest Menu (F9) to see the quests available to your faction.")
    call Hint.create("Artifacts are unique items that can grant major advantages. You can find out where Artifacts are using the Artifact Menu at the top-left of your screen.")
    call Hint.create("Some heroes can't be revived, and some can only be revived if you control certain capitals when they die.")
    call Hint.create("If you have low FPS, try turning off your health bars.")
    call Hint.create("We have a welcoming Discord community at https://discord.gg//4eGZn")
    call Hint.create("When a player leaves, their gold, lumber, units and hero experience are spread among their remaining allies.")
    call Hint.create("There are water passageways at the edge of the map you can use to instantly move to the other side of the map.")
    call Hint.create("Every faction can build an item shop that contains useful purchasable items.")
    call Hint.create("When you unlock a hero through a Quest, you still need to summon that hero from an Altar.")
    call Hint.create("Workers do not require drop site for lumber")
    call Hint.create("All quest to unlock cities will fail at turn 24, turning the city hostile to everyone")
    call Hint.create("The best way to travel between continent is to use Town portal scrolls!")
    call Hint.create("If you want to support the team, support our Patreon at: https://www.patreon.com/lordsebas")
  endfunction

endlibrary