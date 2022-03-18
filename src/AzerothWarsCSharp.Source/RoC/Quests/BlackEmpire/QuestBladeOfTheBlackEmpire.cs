using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.RoC.Legends;
using AzerothWarsCSharp.Source.RoC.Setup;

namespace AzerothWarsCSharp.Source.RoC.Quests.BlackEmpire
{
  public sealed class QuestBladeOfTheBlackEmpire : QuestData
  {
    protected override string CompletionPopup => "Herald Volazj has found the Black Blade, Xal'alath.";

    protected override string CompletionDescription =>
      "Xal'alath will be ours and the Tomb of Tyr quest will be revealed.";

    protected override void OnComplete()
    {
      if (LegendBlackEmpire.LEGEND_VOLAZJ.Unit != null && ArtifactSetup.artifactXalatath != null)
      {
        UnitAddItemSafe(LegendBlackEmpire.LEGEND_VOLAZJ.Unit, ArtifactSetup.artifactXalatath.Item);
      }
      FACTION_BLACKEMPIRE.AddQuest(TOMB_OF_TYR);
      TOMB_OF_TYR.Progress = QUEST_PROGRESS_INCOMPLETE;
    }

    public QuestBladeOfTheBlackEmpire() : base("The Blade of the Black Empire",
      "XalFourCC(alath is one of the oldest && most powerful entities serving the Old Gods, living inside a cursed blade. A human priestess stole it long ago; the blade is entombed with her in Duskwood Crypt.",
      "ReplaceableTextures\\CommandButtons\\BTNmidnightGS.blp")
    {
      this.AddQuestItem(new QuestItemLegendInRect(LEGEND_VOLAZJ, gg_rct_DuskwoodCrypt, "Duskwood Graveyard Crypt"));
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_DUSKWOODGRAVEYARD, false));
    }
  }
}