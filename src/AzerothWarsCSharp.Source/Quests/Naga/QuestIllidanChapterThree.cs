using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.QuestSetup;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestIllidanChapterThree : QuestData
  {
    private static readonly int RitualId = FourCC("A0KY");
    private readonly unit _unitToMakeInvulnerable;
    
    public QuestIllidanChapterThree(unit unitToMakeInvulnerable) : base("Chapter Three: Dwellers from the Deep",
      "Awakening the Naga will give Illidan the army he needs to achieve his goals.",
      "ReplaceableTextures\\CommandButtons\\BTNNagaMyrmidon.blp")
    {
      _unitToMakeInvulnerable = unitToMakeInvulnerable;
      AddQuestItem(new QuestItemLegendReachRect(LegendNaga.LegendIllidan, Regions.StartQuest3.Rect, "the exit"));
      AddQuestItem(new QuestItemLegendReachRect(LegendNaga.LegendIllidan, Regions.MaelstromAmbient.Rect, "the Maelstrom"));
      AddQuestItem(new QuestItemCastSpell(RitualId, true));
    }
    
    protected override string CompletionPopup => "Illidan must awaken the Naga from the depth of the ocean";

    protected override string RewardDescription => "Nazjatar and the Naga's loyalty";

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.NagaUnlock2.Rect, Holder.Player);
      RescueNeutralUnitsInRect(Regions.NagaUnlock1.Rect, Holder.Player);
      NagaSetup.FactionNaga.AddQuest(NagaQuestSetup.REDEMPTION_PATH);
      NagaQuestSetup.REDEMPTION_PATH.Progress = QuestProgress.Undiscovered;
      NagaSetup.FactionNaga.AddQuest(NagaQuestSetup.EXILE_PATH);
      NagaQuestSetup.EXILE_PATH.Progress = QuestProgress.Undiscovered;
      NagaSetup.FactionNaga.AddQuest(NagaQuestSetup.MADNESS_PATH);
      NagaQuestSetup.MADNESS_PATH.Progress = QuestProgress.Undiscovered;
      //call NagaSetup.FactionNaga.AddQuest(ALLIANCE_NAGA)
      //set ALLIANCE_NAGA.Progress = QuestProgress.Undiscovered
      NagaSetup.FactionNaga.AddQuest(NagaQuestSetup.CONQUER_BLACK_TEMPLE);
      NagaQuestSetup.CONQUER_BLACK_TEMPLE.Progress = QuestProgress.Undiscovered;
      NagaSetup.FactionNaga.AddQuest(NagaQuestSetup.KILL_FROZEN_THRONE);
      NagaQuestSetup.KILL_FROZEN_THRONE.Progress = QuestProgress.Undiscovered;
      SetUnitInvulnerable(_unitToMakeInvulnerable, true);
    }
  }
}