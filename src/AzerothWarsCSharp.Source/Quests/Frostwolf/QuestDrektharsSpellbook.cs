using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestDrektharsSpellbook : QuestData
  {
    protected override string CompletionPopup =>
      "The World Tree, Nordrassil, has been captured by the forces of the Horde. Drek'thar has gifted Warchief Thrall his magical spellbook for this achievement.";

    protected override string CompletionDescription => "Drek'thar's Spellbook";

    protected override void OnComplete()
    {
      var drektharsSpellbook = ArtifactSetup.artifactDrektharsspellbook;
      if (drektharsSpellbook != null && LegendFrostwolf.legendThrall?.Unit != null)
      {
        drektharsSpellbook.Status = Artifact.ARTIFACT_STATUS_GROUND;
        GeneralHelpers.UnitAddItemSafe(LegendFrostwolf.legendThrall.Unit, drektharsSpellbook.Item);
      }
    }

    public QuestDrektharsSpellbook() : base("Drekthar's Spellbook",
      "The savage Night Elves threaten the safety of the entire Horde. Capture their World Tree and bring Thrall to its roots.",
      "ReplaceableTextures\\CommandButtons\\BTNSorceressMaster.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendDruids.LEGEND_NORDRASSIL, false));
      AddQuestItem(new QuestItemLegendInRect(LegendFrostwolf.legendThrall, Regions.Drekthars_Spellbook.Rect,
        "Nordrassil"));
    }
  }
}