//Jaina goes to Scholomance while Scholomance building is destroyed and retrieves the Soul Gem

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public class QuestJainaSoulGem{


    protected override string CompletionPopup => 
      return "Jaina Proudmoore has discovered the Soul Gem within the ruined vaults at Scholomance.";
    }

    protected override string CompletionDescription => 
      return "The Soul Gem";
    }

    protected override void OnComplete(){
      GeneralHelpers.UnitAddItemSafe(LEGEND_JAINA.Unit, ARTIFACT_SOULGEM.item);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Soul Gem", "Scholomance is home to a wide variety of profane artifacts. Bring Jaina there to see what might be discovered.", "ReplaceableTextures\\CommandButtons\\BTNSoulGem.blp");
      this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_JAINA, gg_rct_Jaina_soul_gem, "Scholomance"));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_SCHOLOMANCE));
      ;;
    }


  }
}
