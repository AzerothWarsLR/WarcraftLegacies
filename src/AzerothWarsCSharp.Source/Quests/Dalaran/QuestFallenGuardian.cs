using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestFallenGuardian : QuestData
  {
    private static readonly int ResearchId = FourCC("R04K");
    private static readonly int MedivhId = FourCC("Haah");

    public QuestFallenGuardian() : base("The Fallen Guardian",
      "Medivh's body was corrupted by Sargeras at conception. Now that he is dead, the secrets of the Tomb of Sargeras and Karazhan combined might allow the mages of Dalaran to cleanse his spirit.",
      "ReplaceableTextures\\CommandButtons\\BTNMedivh.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LEGEND_KARAZHAN, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00J"))));
      base.ResearchId = FourCC("R04K");
      ;
      ;
    }


    protected override string CompletionPopup =>
      "Medivh's spirit has been cleansed of Sargeras' influence, allowing him to return to Azeroth for a time.";

    protected override string CompletionDescription => "You can summon Medivh from the Altar of Knowledge";

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, UNLIMITED);
      Holder.ModObjectLimit(MedivhId, 1);
    }
  }
}