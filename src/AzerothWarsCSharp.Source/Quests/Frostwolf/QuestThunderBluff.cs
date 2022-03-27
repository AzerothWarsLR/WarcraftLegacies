//If the Centaur Khan dies, OR a time elapses, give Thunder Bluff to a Horde player.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestThunderBluff : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R05I");


    private group _thunderBluffUnits;


    protected override string CompletionPopup =>
  }

  protected override string CompletionDescription => "Control of Thunder Bluff";

  protected override void OnFail( ){
  GeneralHelpers.RescueNeutralUnitsInRect(Regions.ThunderBluff.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
  }

  protected override void OnComplete(){
  GeneralHelpers.RescueNeutralUnitsInRect(Regions.ThunderBluff.Rect, this.Holder.Player);
  if (GetLocalPlayer() == this.Holder.Player){
    PlayThematicMusicBJ("war3mapImported\\TaurenTheme.mp3");
  }
  }

  public QuestThunderBluff ( ) : base("The Long March",
  "The Tauren have been wandering for too long. The plains of Mulgore would offer respite from this endless journey.",
  "ReplaceableTextures\\CommandButtons\\BTNCentaurKhan.blp"){
  this.
  internal AddQuestItem(

  internal new QuestItemLegendDead(LEGEND_CENTAURKHAN));
    this.

  internal AddQuestItem(
  internal new QuestItemAnyUnitInRect(Regions.ThunderBluff, "Thunder Bluff".Rect, true));
  this.
  internal AddQuestItem(

  internal new QuestItemExpire(1455));
    this.

  internal AddQuestItem(

  internal new QuestItemSelfExists());
    this.ResearchId = QUEST_RESEARCH_ID;
  
  }


  public static void Setup( ){
  //Setup initially invulnerable and hidden group at Thunder Bluff
  internal group tempGroup = CreateGroup();
  internal unit u;
  internal var i = 0;
  ThunderBluffUnits =
  internal CreateGroup();

  internal GroupEnumUnitsInRect(tempGroup, Regions.ThunderBluff.Rect, null);
    while(true) {
    u = FirstOfGroup(tempGroup);
    if (u == null) break;
    if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE))
    {
      SetUnitInvulnerable(u, true);
      GroupAddUnit(ThunderBluffUnits, u);
    }

    GroupRemoveUnit(tempGroup, u);
    i = i + 1;
  }

  internal DestroyGroup(tempGroup);
  
  }
}

}