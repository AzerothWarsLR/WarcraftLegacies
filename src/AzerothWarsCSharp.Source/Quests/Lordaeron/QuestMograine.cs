//Destroy the Frozen Throne to unlock Mograine.

using AzerothWarsCSharp.MacroTools.QuestSystem;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestMograine : QuestData
  {
    private static readonly int AltarId = FourCC("halt");
    private static readonly int HeroId = FourCC("H01J");
    private GetObjectName(ALTAR_ID);


    protected override string CompletionPopup =>
      "With the Lich King eliminated, the Kingdom of Lordaeron is free of its greatest threat. Alexandros Mograine gains recognition as a champion of the war, && prepares himself to aid Lordaeron in future conflicts in a greater capacity.";

    protected override string CompletionDescription =>
    return "You can summon Alexandros Mograine from the " +
  }

  protected override void OnAdd( ){
  this.Holder.ModObjectLimit(HERO_ID, 1);
  }

  public QuestMograine ( ){
  internal thistype this = thistype.allocate("The Exile", "The Lich King, looming over Northrend from IcecrownFourCC("
  internal s peak, is
  internal the greatest
  internal threat Lordaeron
  internal has ever
  internal faced.He must be destroyed.", "ReplaceableTextures\\CommandButtons\\BTNAlexandros.blp");
  this.
  internal AddQuestItem(

  internal new QuestItemLegendDead(LEGEND_LICHKING));
    this.ResearchId =
  internal FourCC("R06P");
  }
}

}