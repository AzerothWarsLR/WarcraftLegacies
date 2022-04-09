using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestLegionCaptureSunwell : QuestData
  {
    public QuestLegionCaptureSunwell() : base("Fall of Silvermoon",
      "The Sunwell is the source of the High Elves' immortality and magical prowess. Under control of the Scourge, it would be the source of immense necromantic power.",
      "ReplaceableTextures\\CommandButtons\\BTNOrbOfCorruption.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendQuelthalas.LegendSunwell, false));
      ResearchId = FourCC("R054");
    }

    protected override string CompletionPopup =>
      "The Sunwell has been captured by the Scourge. It now writhes with necromantic energy.";

    protected override string RewardDescription => "A research improving your Dreadlords";


    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}