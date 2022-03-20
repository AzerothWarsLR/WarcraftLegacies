using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Lordaeron
{
  public class QuestAshbringer{

  
    private const float DUMMY_X = 22700;
    private const float DUMMY_Y = 23734;
  



    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "The Ashbringer has been forged && Mograine has returned from exile to wield it";
    }

    protected override string CompletionDescription => 
      return "Gain the hero Mograine && the artifact Ashbringer";
    }

    protected override void OnComplete(){
      LEGEND_MOGRAINE.Spawn(Holder.Player, GetRectCenterX(gg_rct_AshbringerForge), GetRectCenterY(gg_rct_AshbringerForge), 270);
      SetHeroLevel(LEGEND_MOGRAINE.Unit, 10, false);
      UnitAddItemSafe(LEGEND_MOGRAINE.Unit, ARTIFACT_ASHBRINGER.item);
      SetItemPosition(ARTIFACT_LIVINGSHADOW.item, DUMMY_X, DUMMY_Y);
      ARTIFACT_LIVINGSHADOW.setStatus(ARTIFACT_STATUS_HIDDEN);
      ARTIFACT_LIVINGSHADOW.setDescription("Used to create the Ashbringer");
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Ashbringer", "The Living Shadow must be purged, with enough Holy Magic && the craftiness of the Dwarves, it could be reforged into the strongest weapon of the Light", "ReplaceableTextures\\CommandButtons\\BTNAshbringer2blp");
      this.AddQuestItem(QuestItemAcquireArtifact.create(ARTIFACT_LIVINGSHADOW));
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_GREATFORGE));
      this.AddQuestItem(QuestItemArtifactInRect.create(ARTIFACT_LIVINGSHADOW, gg_rct_AshbringerForge, "The Great Forge"));
      this.AddQuestItem(QuestItemChannelRect.create(gg_rct_AshbringerForge, "The Great Forge", LEGEND_UTHER, 60, 340));
      ;;
    }


  }
}
