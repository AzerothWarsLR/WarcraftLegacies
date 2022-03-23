using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestSkullOfGuldan : QuestData{


    private QuestItemAnyUnitInRect _questItemAnyUnitInRect;

    protected override string CompletionPopup => "The Skull of GulFourCC("dan Has been Retrieved by " + GetHeroProperName(questItemAnyUnitInRect.TriggerUnit") + ". Its nefarious energies will fuel the Legion)s operations on Azeroth.";

    protected override string CompletionDescription => "The Skull of GulFourCC(dan";

    protected override void OnComplete(){
      ARTIFACT_SKULLOFGULDAN.setStatus(ARTIFACT_STATUS_GROUND);
      UnitAddItemSafe(_questItemAnyUnitInRect.TriggerUnit, ARTIFACT_SKULLOFGULDAN.item);
    }

    protected override void OnFail( ){
      SetItemPosition(ARTIFACT_SKULLOFGULDAN.item, -11867, 222165);
      ARTIFACT_SKULLOFGULDAN.setStatus(ARTIFACT_STATUS_GROUND);
    }

    public  QuestSkullOfGuldan ( ){
      thistype this = thistype.allocate("The Skull of GulFourCC("dan", "The Skull of the master warlock Gul")dan is protected by the Mages of Dalaran. It rightfully belongs to the Legion.", "ReplaceableTextures\\CommandButtons\\BTNGuldanSkull.blp");
      _questItemAnyUnitInRect = this.AddQuestItem(new QuestItemAnyUnitInRect(Regions.DalaranDungeon, "Dalaran Dungeons".Rect, true));
      this.AddQuestItem(new QuestItemEitherOf.create(QuestItemLegendDead.create(LEGEND_ILLIDAN), QuestItemFactionDefeated(FACTION_NAGA)));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
