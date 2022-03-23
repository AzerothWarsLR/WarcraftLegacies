using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestAshbringer : QuestData{

  
    private const float DUMMY_X = 22700;
    private const float DUMMY_Y = 23734;
  



    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => "The Ashbringer has been forged && Mograine has returned from exile to wield it";

    protected override string CompletionDescription => "Gain the hero Mograine && the artifact Ashbringer";

    protected override void OnComplete(){
      LEGEND_MOGRAINE.Spawn(Holder.Player, GetRectCenterX(Regions.AshbringerForge), GetRectCenterY(gg_rct_AshbringerForge).Rect, 270);
      SetHeroLevel(LEGEND_MOGRAINE.Unit, 10, false);
      UnitAddItemSafe(LEGEND_MOGRAINE.Unit, ARTIFACT_ASHBRINGER.item);
      SetItemPosition(ARTIFACT_LIVINGSHADOW.item, DUMMY_X, DUMMY_Y);
      ARTIFACT_LIVINGSHADOW.setStatus(ARTIFACT_STATUS_HIDDEN);
      ARTIFACT_LIVINGSHADOW.setDescription("Used to create the Ashbringer");
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Ashbringer", "The Living Shadow must be purged, with enough Holy Magic && the craftiness of the Dwarves, it could be reforged into the strongest weapon of the Light", "ReplaceableTextures\\CommandButtons\\BTNAshbringer2blp");
      AddQuestItem(new QuestItemAcquireArtifact(ARTIFACT_LIVINGSHADOW));
      this.AddQuestItem(new QuestItemLegendNotPermanentlyDead(LEGEND_GREATFORGE));
      AddQuestItem(new QuestItemArtifactInRect(ARTIFACT_LIVINGSHADOW, Regions.AshbringerForge.Rect, "The Great Forge"));
      AddQuestItem(new QuestItemChannelRect(Regions.AshbringerForge, "The Great Forge", LEGEND_UTHER, 60.Rect, 340));
      
    }


  }
}
