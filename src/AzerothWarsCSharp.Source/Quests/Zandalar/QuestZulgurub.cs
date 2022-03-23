using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestZulgurub : QuestData{

  
    private const int ZULGURUB_RESEARCH = FourCC("R02M");
    private const int TROLL_SHRINE_ID = FourCC("o04X");
    private const int RAVAGER_ID = FourCC("o021");
  


    protected override string CompletionPopup => "ZulFourCC(Gurub has fallen. The Gurubashi trolls lend their might to the " + Holder.Team.Name  + ".";

    protected override string CompletionDescription => 
      return "Control of ZulFourCC("Gurub, 300 gold tribute && the ability to train " + GetObjectName(RAVAGER_ID") + "s from the " + GetObjectName(TROLL_SHRINE_ID);
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, ZULGURUB_RESEARCH, 1);
      AdjustPlayerStateBJ( 300, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(ZULGURUB_RESEARCH, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Heart of Hakkar", "The Gurubashi trolls of ZulFourCC("Gurub follow the sacred Heart of Hakkar, hidden within their shrine. Capture it to gain their loyalty.", "ReplaceableTextures\\CommandButtons\\BTNTrollRavager.blp"");
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_ZULGURUB, false));
      ;;
    }


  }
}
