using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public class QuestKarazhan{


    protected override string CompletionPopup => 
      return "Karazhan has been captured. " + this.Holder.Name + "FourCC(s  archivists scour its halls for arcane resources.";
    }

    protected override string CompletionDescription => 
      return "Learn to research three powerful upgrades at Karazhan.";
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(FourCC(R020), UNLIMITED)   ;//Rain: An Amalgam
      Holder.ModObjectLimit(FourCC(R03M), UNLIMITED)   ;//Methods of Control
      Holder.ModObjectLimit(FourCC(R01B), UNLIMITED)   ;//A Treatise on Barriers
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Secrets of Karazhan", "The spire of Medivh stands mysteriously idle. Dalaran could make use of its grand magicks.", "ReplaceableTextures\\CommandButtons\\BTNTomeBrown.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_KARAZHAN, false));
      ;;
    }


  }
}
