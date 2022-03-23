
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestLivingShadow : QuestData{


    protected override string CompletionPopup => 
      return "Uther has discovered the Living Embodiment of Shadow in the ruins of the Twilight Citadel";
    }

    protected override string CompletionDescription => 
      return "The Living Shadow && the Ashbringer Quest discovery";
    }

    protected override void OnComplete(){
      GeneralHelpers.UnitAddItemSafe(LEGEND_UTHER.Unit, ARTIFACT_LIVINGSHADOW.item);
      FACTION_LORDAERON.AddQuest(THE_ASHBRINGER);
      THE_ASHBRINGER.Progress = QUEST_PROGRESS_INCOMPLETE;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Living Embodiment of Shadow", "The Dark Fortress looming over the Twilight Highlands is a beacon of darkness. Destroy it && clear the surrounding lands of evil.", "ReplaceableTextures\\CommandButtons\\BTNShadow Orb.blp");
      this.AddQuestItem(new QuestItemLegendInRect(LEGEND_UTHER, gg_rct_TwilightOutside, "Twilight Citadel"));
      this.AddQuestItem(new QuestItemLegendDead(LEGEND_TWILIGHTCITADEL));
      ;;
    }


  }
}
