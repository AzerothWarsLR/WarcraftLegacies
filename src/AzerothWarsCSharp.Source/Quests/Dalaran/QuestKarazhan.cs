using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestKarazhan : QuestData
  {
    public QuestKarazhan() : base("Secrets of Karazhan",
      "The spire of Medivh stands mysteriously idle. Dalaran could make use of its grand magicks.",
      "ReplaceableTextures\\CommandButtons\\BTNTomeBrown.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LEGEND_KARAZHAN, false));
      ;
      ;
    }


    protected override string CompletionPopup => "Karazhan has been captured. " + Holder.Name +
                                                 "FourCC(s  archivists scour its halls for arcane resources.";

    protected override string CompletionDescription => "Learn to research three powerful upgrades at Karazhan.";

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(FourCC("R020"), Faction.UNLIMITED); //Rain: An Amalgam
      Holder.ModObjectLimit(FourCC("R03M"), Faction.UNLIMITED); //Methods of Control
      Holder.ModObjectLimit(FourCC("R01B"), Faction.UNLIMITED); //A Treatise on Barriers
    }
  }
}