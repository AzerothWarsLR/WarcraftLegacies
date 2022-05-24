using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestAshbringer : QuestData
  {
    private const float DUMMY_X = 22700;
    private const float DUMMY_Y = 23734;

    public QuestAshbringer() : base("The Ashbringer",
      "The Living Shadow must be purged, with enough Holy Magic and the craftiness of the Dwarves, it could be reforged into the strongest weapon of the Light",
      "ReplaceableTextures\\CommandButtons\\BTNAshbringer2blp")
    {
      AddQuestItem(new ObjectiveAcquireArtifact(ArtifactSetup.ArtifactLivingshadow));
      AddQuestItem(new ObjectiveLegendNotPermanentlyDead(LegendIronforge.LegendGreatforge));
      AddQuestItem(new ObjectiveArtifactInRect(ArtifactSetup.ArtifactLivingshadow, Regions.AshbringerForge,
        "The Great Forge"));
      AddQuestItem(new ObjectiveChannelRect(Regions.AshbringerForge, "The Great Forge", LegendLordaeron.LegendUther, 60,
        340));
      Global = true;
    }

    protected override string CompletionPopup =>
      "The Ashbringer has been forged and Mograine has returned from exile to wield it";

    protected override string RewardDescription => "Gain the hero Mograine and the artifact Ashbringer";

    protected override void OnComplete()
    {
      LegendLordaeron.LegendMograine.Spawn(Holder.Player, Regions.AshbringerForge.Center.X,
        Regions.AshbringerForge.Center.Y, 270);
      SetHeroLevel(LegendLordaeron.LegendMograine.Unit, 10, false);
      LegendLordaeron.LegendMograine.Unit.AddItemSafe(ArtifactSetup.ArtifactAshbringer.Item);
      SetItemPosition(ArtifactSetup.ArtifactLivingshadow.Item, DUMMY_X, DUMMY_Y);
      ArtifactSetup.ArtifactLivingshadow.Status = ArtifactStatus.Ground;
      ArtifactSetup.ArtifactLivingshadow.Description = "Used to create the Ashbringer";
    }
  }
}