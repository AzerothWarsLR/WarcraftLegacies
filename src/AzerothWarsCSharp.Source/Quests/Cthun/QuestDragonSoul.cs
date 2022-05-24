using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Quests.Cthun
{
  public sealed class QuestDragonSoul : QuestData
  {
    public QuestDragonSoul() : base("The Dragon Soul",
      "The Dragon Soul was lost in the Blackrock Mountain long ago. Skeram might be powerful enough to restore it.",
      "ReplaceableTextures\\CommandButtons\\BTNBrokenAmulet.blp")
    {
      AddQuestItem(new ObjectiveChannelRect(Regions.DragonSoulChannel, "Burning Steppe", LegendCthun.legendSkeram, 240,
        160));
    }

    protected override string CompletionPopup => "Skeram will be granted the Dragon Soul";

    protected override string RewardDescription => "The Dragon Soul will be granted to Skeram";

    protected override void OnComplete()
    {
      LegendCthun.legendSkeram.Unit.AddItemSafe(ArtifactSetup.ArtifactDemonsoul.Item);
    }
  }
}