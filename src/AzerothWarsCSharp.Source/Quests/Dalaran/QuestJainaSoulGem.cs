//Jaina goes to Scholomance while Scholomance building is destroyed and retrieves the Soul Gem

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestJainaSoulGem : QuestData{


    protected override string CompletionPopup => "Jaina Proudmoore has discovered the Soul Gem within the ruined vaults at Scholomance.";

    protected override string CompletionDescription => "The Soul Gem";

    protected override void OnComplete(){
      UnitAddItemSafe(LEGEND_JAINA.Unit, ARTIFACT_SOULGEM.item);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Soul Gem", "Scholomance is home to a wide variety of profane artifacts. Bring Jaina there to see what might be discovered.", "ReplaceableTextures\\CommandButtons\\BTNSoulGem.blp");
      AddQuestItem(new QuestItemLegendInRect(LEGEND_JAINA, Regions.JainaSoulGem.Rect, "Scholomance"));
      AddQuestItem(new QuestItemLegendDead(LEGEND_SCHOLOMANCE));
      
    }


  }
}
