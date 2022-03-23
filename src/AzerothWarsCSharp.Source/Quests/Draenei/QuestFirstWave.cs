using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public sealed class QuestFirstWave : QuestData{



    protected override string CompletionPopup => "The Draenei have holded long enough && most of their civilisation had time to join the Exodar";

    protected override string CompletionDescription => "The Divine Citadel, Teleporter, Astral Sanctum && Crystal Spire will !be deleted from Azuremyst";

    private void OnFail( ){
      KillUnit(gg_unit_o051_3356);
      KillUnit(gg_unit_o055_3337);
      KillUnit(gg_unit_o054_3338);
      KillUnit(gg_unit_n0BU_0220);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Broken Civilisation", "The Fel Orc attack will begin at any moment, the Draenei need to evacuate their civilians aboard the Exodar", "ReplaceableTextures\\CommandButtons\\BTNDraeneiDivineCitadel.blp");
      this.AddQuestItem(new QuestItemTime(720));
      this.AddQuestItem(new QuestItemLegendNotPermanentlyDead(LEGEND_EXODARSHIP));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
