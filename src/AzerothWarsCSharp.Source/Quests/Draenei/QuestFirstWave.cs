using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public class QuestFirstWave{



    protected override string CompletionPopup => 
      return "The Draenei have holded long enough && most of their civilisation had time to join the Exodar";
    }

    protected override string CompletionDescription => 
      return "The Divine Citadel, Teleporter, Astral Sanctum && Crystal Spire will !be deleted from Azuremyst";
    }

    private void OnFail( ){
      KillUnit(gg_unit_o051_3356);
      KillUnit(gg_unit_o055_3337);
      KillUnit(gg_unit_o054_3338);
      KillUnit(gg_unit_n0BU_0220);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Broken Civilisation", "The Fel Orc attack will begin at any moment, the Draenei need to evacuate their civilians aboard the Exodar", "ReplaceableTextures\\CommandButtons\\BTNDraeneiDivineCitadel.blp");
      this.AddQuestItem(QuestItemTime.create(720));
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_EXODARSHIP));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
