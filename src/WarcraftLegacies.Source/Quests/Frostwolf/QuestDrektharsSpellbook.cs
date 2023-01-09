using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using static War3Api.Common;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  public sealed class QuestDrektharsSpellbook : QuestData
  {
    public QuestDrektharsSpellbook() : base("Drekthar's Spellbook",
      "The savage Night Elves threaten the safety of the entire Horde. Capture their World Tree and bring Thrall to its roots.",
      "ReplaceableTextures\\CommandButtons\\BTNNecromancerMaster.blp")
    {
      AddObjective(new ObjectiveControlCapital(LegendDruids.LegendNordrassil, false));
      AddObjective(new ObjectiveLegendInRect(LegendFrostwolf.LegendThrall, Regions.Drekthars_Spellbook,
        "Nordrassil"));
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "The World Tree, Nordrassil, has been captured by the forces of the Horde. Drek'thar has gifted Warchief Thrall his magical spellbook for this achievement.";

    /// <inheritdoc />
    protected override string RewardDescription => "Drek'thar's Spellbook";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      var drektharsSpellBook = new Artifact(CreateItem(Constants.ITEM_DTSB_DREK_THAR_S_SPELLBOOK, 0, 0));
      ArtifactManager.Register(drektharsSpellBook);
      LegendFrostwolf.LegendThrall?.Unit?.AddItemSafe(drektharsSpellBook.Item);
    }
  }
}