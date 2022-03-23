using AzerothWarsCSharp.MacroTools.QuestSystem;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestWarMachine : QuestData
  {
    private GetObjectName(FourCC
    private GetObjectName()
    private GetObjectName()
    private GetObjectName()


    protected override string CompletionPopup =>
      "The massive exploitation of Ashenvale has bolstered the entire HordeFourCC(s weapons, armour && defenses.";

    protected override string CompletionDescription =>
    return "You && all of your allies gain the researches " +("Rhme")) + ", " +Rhar)) + ", " +Rorb)) + ", && " +Rosp));
  }

  private void BlessPlayer(player whichPlayer ){
  internal SetPlayerTechResearched(whichPlayer, FourCC("Rhme"),
  internal GetPlayerTechCount(whichPlayer, )Rhme), true) + 1);
  internal SetPlayerTechResearched(whichPlayer, FourCC("Rhar"),
  internal GetPlayerTechCount(whichPlayer, )Rhar), true) + 1);
  internal SetPlayerTechResearched(whichPlayer, FourCC("Rorb"), 3);
  internal SetPlayerTechResearched(whichPlayer, FourCC("Rosp"), 3);
  }

  protected override void OnComplete(){
  internal var i = 0;
    while(true) {
    if (i == MAX_PLAYERS) break;
    if (this.Holder.Team.ContainsPlayer(Player(i))) BlessPlayer(Player(i));
    i = i + 1;
  }
  }

  protected override void OnAdd( ){
  this.Holder.ModObjectLimit(FourCC("R021"), UNLIMITED);
  }

  public QuestWarMachine ( ) : base("The War Machine",
  "The bountiful woodlands of Ashenvale are now accessible to the Horde. It is time to begin harvesting && armament operations."
  , "ReplaceableTextures\\CommandButtons\\BTNBundleOfLumber.blp"){
  this.
  internal AddQuestItem(
  internal new QuestItemResearch(FourCC("R021"), )o01I)));
  ;;
  }
}

}