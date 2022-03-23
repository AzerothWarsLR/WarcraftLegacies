using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestKarazhan : QuestData{


    protected override string CompletionPopup => "Karazhan has been captured. " + Holder.Name + "FourCC(s  archivists scour its halls for arcane resources.";

    protected override string CompletionDescription => "Learn to research three powerful upgrades at Karazhan.";

    protected override void OnAdd( ){
      Holder.ModObjectLimit(FourCC("R020"), UNLIMITED)   ;//Rain: An Amalgam
      Holder.ModObjectLimit(FourCC("R03M"), UNLIMITED)   ;//Methods of Control
      Holder.ModObjectLimit(FourCC("R01B"), UNLIMITED)   ;//A Treatise on Barriers
    }

    public  QuestKarazhan ( ){
      thistype this = thistype.allocate("Secrets of Karazhan", "The spire of Medivh stands mysteriously idle. Dalaran could make use of its grand magicks.", "ReplaceableTextures\\CommandButtons\\BTNTomeBrown.blp");
      AddQuestItem(new QuestItemControlLegend(LEGEND_KARAZHAN, false));
      ;;
    }


  }
}
