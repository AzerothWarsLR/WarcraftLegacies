using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestMograine : QuestData
  {
    private static readonly int AltarId = FourCC("halt");
    private static readonly int HeroId = FourCC("H01J");

    protected override string CompletionPopup =>
      "With the Lich King eliminated, the Kingdom of Lordaeron is free of its greatest threat. Alexandros Mograine gains recognition as a champion of the war, and prepares himself to aid Lordaeron in future conflicts in a greater capacity.";

    protected override string RewardDescription =>
      "You can summon Alexandros Mograine from the " + GetObjectName(AltarId);

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(HeroId, 1);
    }

    public QuestMograine() : base("The Exile",
      "The Lich King, looming over Northrend from Icecrown's peak, is the greatest threat Lordaeron has ever faced. He must be destroyed.",
      "ReplaceableTextures\\CommandButtons\\BTNAlexandros.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LegendScourge.LegendLichking));
      ResearchId = FourCC("R06P");
    }
  }
}