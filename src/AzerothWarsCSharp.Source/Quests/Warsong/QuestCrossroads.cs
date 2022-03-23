//If any Horde unit enters the Crossroads area, OR a time elapses, OR someone becomes a solo Horde Path, give the Crossroads to a Horde player.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestCrossroads : QuestData
  {
    protected override string CompletionPopup =>
  }

  protected override string CompletionDescription => "Control of the Crossroads";

  private void GiveCrossroads(player whichPlayer ){
  internal unit u;

  //Transfer all Neutral Passive units in Crossroads to one of the above factions
  u =

  internal FirstOfGroup(udg_Crossroad);
    while(true) {
    if (u == null) break;
    if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) UnitRescue(u, whichPlayer);
    GroupRemoveUnit(udg_Crossroad, u);
    u = FirstOfGroup(udg_Crossroad);
  }

  //Give resources and display message
  internal CreateUnit(whichPlayer, FourCC("oeye"), -12844, -1975, 0);
  internal CreateUnit(whichPlayer, FourCC("oeye"), -10876, -2066, 0);
  internal CreateUnit(whichPlayer, FourCC("oeye"), -11922, -824, 0);

  //Cleanup
  internal DestroyGroup(udg_Crossroad);
  internal AdjustPlayerStateBJ(2000, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
  }

  protected override void OnFail( ){
  internal GiveCrossroads(Player(PLAYER_NEUTRAL_AGGRESSIVE));
  }

  protected override void OnComplete(){
  internal GiveCrossroads(this.Holder.Player);
  }

  public QuestCrossroads ( ) : base("The Crossroads",
  "The Horde still needs to establish a strong strategic foothold into Kalimdor. There is an opportune crossroads nearby."
  , "ReplaceableTextures\\CommandButtons\\BTNBarracks.blp"){
  this.

  internal AddQuestItem(QuestItemKillUnit.create(gg_unit_nrzm_0113)); //Razorman Medicine Man
    this.

  internal AddQuestItem(
  internal new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01T"))));
  this.
  internal AddQuestItem(

  internal new QuestItemExpire(1460));
    this.

  internal AddQuestItem(

  internal new QuestItemSelfExists());
    ;;
  }
}

}