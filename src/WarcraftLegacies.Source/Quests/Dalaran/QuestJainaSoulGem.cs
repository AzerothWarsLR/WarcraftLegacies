using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Dalaran
{
  public sealed class QuestJainaSoulGem : QuestData
  {
    public QuestJainaSoulGem() : base("The Soul Gem",
      "Scholomance is home to a wide variety of profane artifacts. Bring Jaina there to see what might be discovered.",
      "ReplaceableTextures\\CommandButtons\\BTNSoulGem.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendDalaran.LegendJaina, Regions.CaerDarrow, "Caer Darrow"));
      AddObjective(new ObjectiveControlCapital(LegendNeutral.Caerdarrow, false));
    }
    
    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Jaina Proudmoore has discovered the Soul Gem within the ruined vaults at Scholomance.";

    /// <inheritdoc />
    protected override string RewardDescription => "The Soul Gem";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      var soulGem = new Artifact(CreateItem(Constants.ITEM_GSOU_SOUL_GEM, 0, 0));
      ArtifactManager.Register(soulGem);
      LegendDalaran.LegendJaina?.Unit?.AddItemSafe(soulGem.Item);
    }
  }
}