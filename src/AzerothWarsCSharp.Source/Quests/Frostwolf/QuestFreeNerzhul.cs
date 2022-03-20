using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public class QuestFreeNerzhul{


    protected override string CompletionPopup => 
      return "NerFourCC(zhul is finally free from his tortured existence as the bearer of the Helm of Domination. With his dying breath, he passes his wisdom on to Thrall.";
    }

    protected override string CompletionDescription => 
      return "Thrall gains 10 Strength, 10 Agility && 10 Intelligence";
    }

    protected override void OnComplete(){
      GeneralHelpers.AddHeroAttributes(LEGEND_THRALL.Unit, 10, 10, 10);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Jailor of the Damned", "Before he became the Lich King, NerFourCC(zhul was the chieftain && elder shaman of the Shadowmoon Clan. Perhaps something of his former self still survives within the Frozen Throne.", "ReplaceableTextures\\CommandButtons\\BTNShaman.blp");
      this.AddQuestItem(QuestItemKillUnit.create(LEGEND_LICHKING.Unit));
      ;;
    }


  }
}
