//Escapes Kalimdor, Find the Skull of Guldan

using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestIllidanChapterThree : QuestData
  {
    private static readonly int RitualId = FourCC("A0KY");

    public QuestIllidanChapterThree() : base("Chapter Three: Dwellers from the Deep",
      "Awakening the Naga will give Illidan the army he needs to achieve his goals.",
      "ReplaceableTextures\\CommandButtons\\BTNNagaMyrmidon.blp")
    {
      this.AddQuestItem(new QuestItemLegendReachRect(LegendNaga.LegendIllidan, Regions.StartQuest3.Rect, "the exit"));
      this.AddQuestItem(new QuestItemLegendReachRect(LegendNaga.LegendIllidan, Regions.MaelstromAmbient.Rect, "the Maelstrom"));
      AddQuestItem(new QuestItemCastSpell(RitualId, true));
      ;
      ;
    }


    protected override string CompletionPopup => "Illidan must awaken the Naga from the depth of the ocean";

    protected override string CompletionDescription => "Nazjatar && the NagaFourCC(s loyalty";

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.NagaUnlock2.Rect, Holder.Player);
      RescueNeutralUnitsInRect(Regions.NagaUnlock1.Rect, Holder.Player);
      NagaSetup.FactionNaga.AddQuest(REDEMPTION_PATH);
      REDEMPTION_PATH.Progress = QUEST_PROGRESS_UNDISCOVERED;
      NagaSetup.FactionNaga.AddQuest(EXILE_PATH);
      EXILE_PATH.Progress = QUEST_PROGRESS_UNDISCOVERED;
      NagaSetup.FactionNaga.AddQuest(MADNESS_PATH);
      MADNESS_PATH.Progress = QUEST_PROGRESS_UNDISCOVERED;
      //call NagaSetup.FactionNaga.AddQuest(ALLIANCE_NAGA)
      //set ALLIANCE_NAGA.Progress = QUEST_PROGRESS_UNDISCOVERED
      NagaSetup.FactionNaga.AddQuest(CONQUER_BLACK_TEMPLE);
      CONQUER_BLACK_TEMPLE.Progress = QUEST_PROGRESS_UNDISCOVERED;
      NagaSetup.FactionNaga.AddQuest(KILL_FROZEN_THRONE);
      KILL_FROZEN_THRONE.Progress = QUEST_PROGRESS_UNDISCOVERED;
      SetUnitInvulnerable(gg_unit_n045_3377, true);
    }
  }
}