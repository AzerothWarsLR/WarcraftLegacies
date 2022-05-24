using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestJainaSoulGem : QuestData
  {
    public QuestJainaSoulGem() : base("The Soul Gem",
      "Scholomance is home to a wide variety of profane artifacts. Bring Jaina there to see what might be discovered.",
      "ReplaceableTextures\\CommandButtons\\BTNSoulGem.blp")
    {
      AddObjective(new ObjectiveLegendInRect(LegendDalaran.LegendJaina, Regions.Jaina_soul_gem, "Scholomance"));
      AddObjective(new ObjectiveLegendDead(LegendForsaken.LegendScholomance));
    }


    protected override string CompletionPopup =>
      "Jaina Proudmoore has discovered the Soul Gem within the ruined vaults at Scholomance.";

    protected override string RewardDescription => "The Soul Gem";

    protected override void OnComplete(Faction completingFaction)
    {
      LegendDalaran.LegendJaina.Unit.AddItemSafe(ArtifactSetup.ArtifactSoulgem.Item);
    }
  }
}