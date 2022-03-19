using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.RoC.Legends;
using AzerothWarsCSharp.Source.RoC.Setup;

namespace AzerothWarsCSharp.Source.RoC.Quests.Cthun
{
  public sealed class QuestDragonSoul : QuestData
  {
    protected override string CompletionPopup => "Skeram will be granted the Dragon Soul";

    protected override string CompletionDescription => "The Dragon Soul will be granted to Skeram";

    protected override void OnComplete()
    {
      UnitAddItemSafe(LegendCthun.LEGEND_SKERAM.Unit, ArtifactSetup.artifactDemonsoul.Item);
    }

    public QuestDragonSoul() : base("The Dragon Soul",
      "The Dragon Soul was lost in the Blackrock Mountain long ago. Skeram might be powerful enough to restore it.",
      "ReplaceableTextures\\CommandButtons\\BTNBrokenAmulet.blp")
    {
      AddQuestItem(new QuestItemChannelRect(Regions.DragonSoulChannel, "Burning Steppe", LegendCthun.LEGEND_SKERAM, 240,
        160));
    }
  }
}