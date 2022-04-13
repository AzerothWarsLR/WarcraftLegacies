using AzerothWarsCSharp.MacroTools.Artifacts;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestSkullOfGuldan : QuestData
  {
    private readonly QuestItemAnyUnitInRect _questItemAnyUnitInRect;

    public QuestSkullOfGuldan() : base(
      "The Skull of Gul'dan",
      "The Skull of the master warlock Gul'dan is protected by the Mages of Dalaran. It rightfully belongs to the Legion.",
      "ReplaceableTextures\\CommandButtons\\BTNGuldanSkull.blp")
    {
      _questItemAnyUnitInRect = new QuestItemAnyUnitInRect(Regions.DalaranDungeon, "Dalaran Dungeons", true);
      AddQuestItem(_questItemAnyUnitInRect);

      AddQuestItem(new QuestItemEitherOf(new QuestItemLegendDead(LegendNaga.LegendIllidan),
        new QuestItemFactionDefeated(NagaSetup.FactionNaga)));
      AddQuestItem(new QuestItemSelfExists());
    }

    protected override string CompletionPopup => "The Skull of Gul'dan";

    protected override string RewardDescription => "The Skull of Gul'dan has been retrieved by " +
                                                       GetHeroProperName(_questItemAnyUnitInRect.TriggerUnit) +
                                                       ". Its nefarious energies will fuel the Legion's operations on Azeroth.";

    protected override void OnComplete()
    {
      ArtifactSetup.ArtifactSkullofguldan.Status = ArtifactStatus.Ground;
      UnitAddItemSafe(_questItemAnyUnitInRect.TriggerUnit, ArtifactSetup.ArtifactSkullofguldan.Item);
    }

    protected override void OnFail()
    {
      SetItemPosition(ArtifactSetup.ArtifactSkullofguldan.Item, -11867, 222165);
      ArtifactSetup.ArtifactSkullofguldan.Status = ArtifactStatus.Ground;
    }
  }
}