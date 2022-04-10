using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestDrektharsSpellbook : QuestData
  {
    public QuestDrektharsSpellbook() : base("Drekthar's Spellbook",
      "The savage Night Elves threaten the safety of the entire Horde. Capture their World Tree and bring Thrall to its roots.",
      "ReplaceableTextures\\CommandButtons\\BTNSorceressMaster.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendDruids.LegendNordrassil, false));
      AddQuestItem(new QuestItemLegendInRect(LegendFrostwolf.LegendThrall, Regions.Drekthars_Spellbook.Rect,
        "Nordrassil"));
    }

    protected override string CompletionPopup =>
      "The World Tree, Nordrassil, has been captured by the forces of the Horde. Drek'thar has gifted Warchief Thrall his magical spellbook for this achievement.";

    protected override string RewardDescription => "Drek'thar's Spellbook";

    protected override void OnComplete()
    {
      var drektharsSpellbook = ArtifactSetup.ArtifactDrektharsspellbook;
      if (drektharsSpellbook != null && LegendFrostwolf.LegendThrall?.Unit != null)
      {
        drektharsSpellbook.Status = ArtifactStatus.Ground;
        UnitAddItemSafe(LegendFrostwolf.LegendThrall.Unit, drektharsSpellbook.Item);
      }
    }
  }
}