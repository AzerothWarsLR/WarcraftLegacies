using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestFreeNerzhul : QuestData{


    protected override string CompletionPopup => "NerFourCC(zhul is finally free from his tortured existence as the bearer of the Helm of Domination. With his dying breath, he passes his wisdom on to Thrall.";

    protected override string CompletionDescription => "Thrall gains 10 Strength, 10 Agility && 10 Intelligence";

    protected override void OnComplete(){
      GeneralHelpers.AddHeroAttributes(LEGEND_THRALL.Unit, 10, 10, 10);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Jailor of the Damned", "Before he became the Lich King, NerFourCC("zhul was the chieftain && elder shaman of the Shadowmoon Clan. Perhaps something of his former self still survives within the Frozen Throne.", "ReplaceableTextures\\CommandButtons\\BTNShaman.blp"");
      this.AddQuestItem(new QuestItemKillUnit(LEGEND_LICHKING.Unit));
      ;;
    }


  }
}
