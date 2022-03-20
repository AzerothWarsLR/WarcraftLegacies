using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;

namespace AzerothWarsCSharp.Source.Quests.Cthun
{
  public sealed class QuestDragonSoul : QuestData
  {
    protected override string CompletionPopup => "Skeram will be granted the Dragon Soul";

    protected override string CompletionDescription => "The Dragon Soul will be granted to Skeram";

    protected override void OnComplete()
    {
      GeneralHelpers.UnitAddItemSafe(LegendCthun.LEGEND_SKERAM.Unit, ArtifactSetup.artifactDemonsoul.Item);
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